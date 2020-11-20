'------------------------------------------------------------------------------
' Mostrar 2 paneles con ficheros 
'
'
' (c) Guillermo (elGuille) Som, 2020
'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports System
'Imports System.Data
Imports System.Collections.Generic
Imports System.Text
Imports System.Linq
Imports Microsoft.VisualBasic
Imports vb = Microsoft.VisualBasic
Imports System.IO
Imports System.Diagnostics

Public Class Form1

    ''' <summary>
    ''' El prefijo de los ficheros de configuración
    ''' </summary>
    Const prefijoConfig As String = "CompararDirectorios"

    ''' <summary>
    ''' Colección con los últimos directorios mostrados
    ''' en ambos paneles
    ''' </summary>
    Private ultimosDirs As New List(Of String)

    ''' <summary>
    ''' El panel en el que se ha pulsado un fichero o directorio
    ''' </summary>
    Private quePanel As ListView

    ''' <summary>
    ''' Si se han comparado los ficheros
    ''' </summary>
    Private comparado As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lvDirDer.Items.Clear()
        lvDirIzq.Items.Clear()

        ' Leer los datos de la configuración
        LeerConfig()
        ' Empezar comparando los directorios
        CompararDirectorios()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        LabelIzq1.Width = ToolStripIzq.Width - (btnAbrirDirIzq.Width + 24)
        LabelDer1.Width = ToolStripDer.Width - (btnAbrirDirDer.Width + 24)

        Dim sCopyR = "(c) Guillermo Som (elGuille), 2020"
        If Date.Now.Year > 2020 Then
            sCopyR &= $"-{Date.Now.Year}"
        End If
        LabelInfo.Text = $"{Application.ProductName} v{Application.ProductVersion}, {sCopyR} " &
            $"- Ventana: Width: {Me.Width}, Height: {Me.Height} " &
            $"- LabelIzq1.Width: {LabelIzq1.Width}, LabelDer1.Width: {LabelDer1.Width}"

        If lvDirIzq.Tag IsNot Nothing Then
            MostrarNombreDirectorio(lvDirIzq.Tag.ToString, lvDirIzq)
        End If
        If lvDirDer.Tag IsNot Nothing Then
            MostrarNombreDirectorio(lvDirDer.Tag.ToString, lvDirDer)
        End If
    End Sub

    Private Sub BtnAbrirDirIzq_Click(sender As Object, e As EventArgs) Handles btnAbrirDirIzq.Click
        AbrirCarpeta(lvDirIzq)
    End Sub

    Private Sub BtnAbrirDirDer_Click(sender As Object, e As EventArgs) Handles btnAbrirDirDer.Click
        AbrirCarpeta(lvDirDer)
    End Sub

    ''' <summary>
    ''' Seleccionar la carpeta a abrir en el ListView (panel) indicado
    ''' </summary>
    ''' <param name="lv">ListView donde se mostrará el directorio seleccionado</param>
    Private Sub AbrirCarpeta(lv As ListView)

        Dim sDir As String = ""
        If lv.Tag IsNot Nothing Then
            sDir = lv.Tag.ToString
        End If
        Dim fb As New FolderBrowserDialog With {
            .Description = "Selecciona el directorio a mostrar",
            .SelectedPath = Environment.SpecialFolder.MyDocuments.ToString
        }
        If sDir.Any Then
            fb.SelectedPath = sDir
        End If
        If fb.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        MostrarContenidoDirectorio(fb.SelectedPath, lv)
    End Sub

    ''' <summary>
    ''' Guardar los datos de configuración:
    '''     Nombre del directorio de cada panel,
    '''     Los últimos directorios mostrados en ambos paneles
    ''' </summary>
    ''' <param name="sDir">Cadena con el nombre del directorio</param>
    ''' <param name="lv">ListView donde se muestra el contenido del directorio</param>
    Private Sub GuardarConfig(sDir As String, lv As ListView)
        ' Guardar el nombre del directorio abierto
        Dim dirCfg = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        Dim ficCfg As String
        If lv Is lvDirIzq Then
            ficCfg = $"{prefijoConfig}_Izq.config.txt"
        Else
            ficCfg = $"{prefijoConfig}_Der.config.txt"
        End If
        Dim fic = Path.Combine(dirCfg, ficCfg)
        Using sw As New StreamWriter(fic, False, Encoding.Default)
            sw.Write(sDir)
            sw.Flush()
            sw.Close()
        End Using

        ' Guardar todos los directorios abiertos
        If ultimosDirs.Count = 0 Then Return

        ficCfg = $"{prefijoConfig}_UltimosDirectorios.config.txt"
        fic = Path.Combine(dirCfg, ficCfg)
        Using sw As New StreamWriter(fic, False, Encoding.Default)
            For Each s In ultimosDirs
                If s.Any Then
                    sw.WriteLine(s)
                End If
            Next
            sw.Flush()
            sw.Close()
        End Using

    End Sub

    ''' <summary>
    ''' Leer la configuración con los nombres de los dos directorios usados
    ''' y la lista de los últimos directorios
    ''' </summary>
    Private Sub LeerConfig()
        Dim dirCfg = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim ficCfg As String

        ficCfg = $"{prefijoConfig}_Izq.config.txt"
        Dim fic = Path.Combine(dirCfg, ficCfg)
        Dim dIzq As String
        If File.Exists(fic) Then
            Using sr As New StreamReader(fic, Encoding.Default, True)
                dIzq = sr.ReadLine
                sr.Close()
            End Using

            ' Mostrar los ficheros en el panel izquierdo
            MostrarContenidoDirectorio(dIzq, lvDirIzq)
        End If

        ficCfg = $"{prefijoConfig}_Der.config.txt"
        fic = Path.Combine(dirCfg, ficCfg)
        If File.Exists(fic) Then
            Using sr As New StreamReader(fic, Encoding.Default, True)
                dIzq = sr.ReadLine
                sr.Close()
            End Using

            ' Mostrar los ficheros en el panel derecho
            MostrarContenidoDirectorio(dIzq, lvDirDer)
        End If

        ' Leer los últimos directorios abiertos
        ultimosDirs.Clear()
        ficCfg = $"{prefijoConfig}_UltimosDirectorios.config.txt"
        fic = Path.Combine(dirCfg, ficCfg)
        If File.Exists(fic) Then
            Using sr As New StreamReader(fic, Encoding.Default, True)
                Do While Not sr.EndOfStream
                    Dim s = sr.ReadLine
                    If s.Any Then
                        ultimosDirs.Add(s)
                    End If
                Loop
                sr.Close()
            End Using
        End If

    End Sub

    ''' <summary>
    ''' Mostrar el nombre del directorio en la etiqueta adecuada
    ''' </summary>
    ''' <param name="sDir">Cadena con el nombre del directorio</param>
    ''' <param name="lv">ListView donde se muestra el contenido del directorio</param>
    Private Sub MostrarNombreDirectorio(sDir As String, lv As ListView)
        Dim dir = New DirectoryInfo(sDir)

        If lv Is lvDirIzq Then
            Dim s = dir.FullName
            ' El ancho predeterminado es 384 y 70 caracteres
            Dim maxLeng = CInt(LabelIzq1.Width / 5.6)
            If s.Length > maxLeng Then
                s = s.Substring(0, 10) & "..." & s.Substring(s.Length - (maxLeng - 14))
            End If
            LabelIzq1.Text = s ' dir.Name 'dir.FullName
            LabelIzq1.ToolTipText = dir.FullName
        Else
            Dim s = dir.FullName
            Dim maxLeng = CInt(LabelIzq1.Width / 5.6)
            If s.Length > maxLeng Then
                s = s.Substring(0, 10) & "..." & s.Substring(s.Length - (maxLeng - 14))
            End If
            LabelDer1.Text = s ' dir.Name 'dir.FullName
            LabelDer1.ToolTipText = dir.FullName
        End If

    End Sub

    ''' <summary>
    ''' Mostrar el contenido del directorio indicado
    ''' </summary>
    ''' <param name="sDir">Cadena con el nombre del directorio</param>
    ''' <param name="lv">ListView donde se muestra el contenido del directorio</param>
    Private Sub MostrarContenidoDirectorio(sDir As String, lv As ListView)
        ' Comprobación de error, por si no existe el directorio
        If Not Directory.Exists(sDir) Then
            sDir = Environment.CurrentDirectory
        End If
        Dim dir = New DirectoryInfo(sDir)
        lv.Tag = dir

        MostrarNombreDirectorio(sDir, lv)

        Dim dirs = dir.GetDirectories
        Dim files = dir.GetFiles

        lv.Items.Clear()
        If dir.Parent IsNot Nothing Then
            Dim it = lv.Items.Add("[..]")
            'it.SubItems.Add("")
            it.SubItems.Add($"[{dir.Parent.Name.ToUpper}]")
            it.SubItems.Add("[UP--DIR]")
            'it.SubItems.Add(dir.Parent.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss"))
            it.SubItems.Add(dir.Parent.LastWriteTime.ToString("dd/MM/yyyy HH:mm"))
            it.ForeColor = Color.DarkOliveGreen
            'it.BackColor = Color.Yellow
            it.BackColor = Color.LightGoldenrodYellow
            it.Font = New Font(it.Font, FontStyle.Bold)
            it.Tag = dir.Parent '.FullName
            it.Checked = False
            it.ToolTipText = dir.Parent.FullName
        End If
        For Each di In dirs
            Dim it = lv.Items.Add("DIR")
            ' Mostrar en mayúsculas los nombres de los directorios
            it.SubItems.Add(di.Name.ToUpper)
            it.SubItems.Add("[SUB--DIR]")
            it.SubItems.Add(di.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss"))
            it.ForeColor = Color.DarkOliveGreen
            it.BackColor = Color.LightGoldenrodYellow
            it.Checked = False
            it.Tag = di '.FullName
            it.ToolTipText = di.FullName
            'it.Font = New Font(it.Font, FontStyle.Bold)
        Next
        For Each fi In files
            Dim it = lv.Items.Add("")
            it.SubItems.Add(fi.Name)
            it.SubItems.Add(fi.Length.ToString("#,##0"))
            it.SubItems.Add(fi.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss"))
            it.Checked = False
            it.Tag = fi
        Next

        ' Guardar el directorio usado actualmente
        ' y añadirlo a la lista de últimos directorios (si no está ya)
        If Not ultimosDirs.Contains(sDir) Then
            ultimosDirs.Add(sDir)
        End If

        ' Guardar la información del directorio actual y los últimos abiertos
        GuardarConfig(sDir, lv)

        If lv Is lvDirDer AndAlso comparado Then
            CompararDirectorios()
        Else
            comparado = False
        End If
    End Sub

    Private Sub LvDirIzq_Click(sender As Object, e As EventArgs) Handles lvDirIzq.Click
        ' comprobar si es un fichero
        If lvDirIzq.SelectedItems.Count > 0 Then
            Dim fi = TryCast(lvDirIzq.SelectedItems(0).Tag, FileInfo)
            If fi Is Nothing Then Return

            If lvDirDer.SelectedItems.Count > 0 Then
                lvDirDer.SelectedItems.Clear()
            End If

            ' Buscar el elemento en la otra lista
            Dim nombre = lvDirIzq.SelectedItems(0).SubItems(1).Text
            For i = 0 To lvDirDer.Items.Count - 1
                Dim nombreDer = lvDirDer.Items(i).SubItems(1).Text
                If String.IsNullOrEmpty(nombreDer) Then Continue For
                If nombre = nombreDer Then
                    lvDirDer.Items(i).Selected = True
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub LvDirIzq_DoubleClick(sender As Object, e As EventArgs) Handles lvDirIzq.DoubleClick ', lvDirIzq.Click
        IrParentDir(lvDirIzq)
    End Sub

    Private Sub LvDirDer_DoubleClick(sender As Object, e As EventArgs) Handles lvDirDer.DoubleClick
        IrParentDir(lvDirDer)
    End Sub

    Private Sub IrParentDir(lv As ListView)
        ' Comprobar si es un elemento con directorio
        If lv.SelectedItems.Count > 0 Then
            ' ir a ese directorio
            Dim di = TryCast(lv.SelectedItems(0).Tag, DirectoryInfo)
            If di Is Nothing Then Return

            Dim sDir = di.FullName
            If Not String.IsNullOrEmpty(sDir) Then
                MostrarContenidoDirectorio(sDir, lv)
            End If
        End If
    End Sub

    Private Sub BtnComparar_Click(sender As Object, e As EventArgs) Handles btnComparar.Click
        CompararDirectorios()
    End Sub

    ''' <summary>
    ''' Comparar el contenido de los ficheros de los dos directorios mostrados
    ''' </summary>
    Private Sub CompararDirectorios()
        ' Comparar el contenido de los 2 directorios
        ' Recorrer los ficheros del panel izquierdo buscando cambios con el derecho
        ' Comprobar la fecha antes que el tamaño
        '   No existe           x   FireBrick
        '   La fecha es mayor   f>  Blue
        '   La fecha es menor   f<  SlateBlue
        '   Es más grande       t>  Green
        '   Es más pequeño      t<  DarkGreen
        '   Son iguales         =
        Dim diIzq = TryCast(lvDirIzq.Tag, DirectoryInfo)
        If diIzq Is Nothing Then Return
        Dim diDer = TryCast(lvDirDer.Tag, DirectoryInfo)
        If diDer Is Nothing Then Return

        LabelInfo.Text = "Comparando los directorios..."
        Application.DoEvents()

        comparado = True

        Dim t = 0
        Dim tf = 0
        Dim tn = 0
        Dim ttma = 0
        Dim ttme = 0
        Dim tfma = 0
        Dim tfme = 0
        Dim ti = 0

        For i = 0 To lvDirIzq.Items.Count - 1
            Dim itIzq = lvDirIzq.Items(i)
            Dim fiIzq = TryCast(itIzq.Tag, FileInfo)
            If fiIzq Is Nothing Then Continue For
            ' Asignar el color del texto predeterminado
            itIzq.ForeColor = Color.FromKnownColor(KnownColor.WindowText)
            tf += 1
            Dim fiDer As FileInfo
            Dim existe As Boolean = False
            For j = 0 To lvDirDer.Items.Count - 1
                fiDer = TryCast(lvDirDer.Items(j).Tag, FileInfo)
                If fiDer Is Nothing Then Continue For
                If fiIzq.Name = fiDer.Name Then
                    existe = True
                    t += 1
                    itIzq.Text = "="
                    itIzq.ToolTipText = "Son iguales"
                    If fiIzq.LastWriteTime.ToString("yyyy/MM/dd HH:mm") > fiDer.LastWriteTime.ToString("yyyy/MM/dd HH:mm") Then
                        itIzq.Text = "f>"
                        itIzq.ForeColor = Color.Blue
                        itIzq.ToolTipText = "La fecha es mayor"
                        tfma += 1
                        ti += 1
                    ElseIf fiIzq.LastWriteTime.ToString("yyyy/MM/dd HH:mm") < fiDer.LastWriteTime.ToString("yyyy/MM/dd HH:mm") Then
                        itIzq.Text = "f<"
                        itIzq.ForeColor = Color.SlateBlue
                        itIzq.ToolTipText = "La fecha es menor"
                        tfme += 1
                        ti += 1
                    ElseIf fiIzq.Length > fiDer.Length Then
                        itIzq.ForeColor = Color.Green
                        itIzq.Text = "t>"
                        itIzq.ToolTipText = "El tamaño es mayor"
                        ttma += 1
                        ti += 1
                    ElseIf fiIzq.Length < fiDer.Length Then
                        itIzq.ForeColor = Color.DarkGreen
                        itIzq.Text = "t<"
                        itIzq.ToolTipText = "El tamaño es menor"
                        ttme += 1
                        ti += 1
                    End If
                    Exit For
                End If
            Next
            If Not existe Then
                itIzq.ForeColor = Color.Firebrick
                itIzq.Text = "x"
                itIzq.ToolTipText = "No existe"
                tn += 1
            End If
        Next

        If ti = 1 Then
            'LabelInfo.Text = $"De {tf} ficheros {t} tienen el mismo nombre, 1 es distinto, {tn} no existen, t> {ttma}, t< {ttme}, f> {tfma}, f< {tfme}"
            LabelInfo.Text = $"De {tf} ficheros {t} tienen el mismo nombre, {tn} no existen, 1 es distinto: {tfma + tfme} con fechas distintas, {ttma + ttme} con tamaños distintos"
        ElseIf ti > 1 Then
            'LabelInfo.Text = $"De {tf} ficheros {t} tienen el mismo nombre, {ti} son distintos, {tn} no existen, t> {ttma}, t< {ttme}, f> {tfma}, f< {tfme}"
            LabelInfo.Text = $"De {tf} ficheros {t} tienen el mismo nombre, {tn} no existen, {ti} son distintos: {tfma + tfme} con fechas distintas, {ttma + ttme} con tamaños distintos"
        Else
            LabelInfo.Text = $"De {tf} ficheros los {t} son iguales."
        End If
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Releer()
    End Sub

    ''' <summary>
    ''' Releer el contenido de los dos directorios
    ''' </summary>
    Private Sub Releer()
        MostrarContenidoDirectorio(lvDirIzq.Tag.ToString, lvDirIzq)
        MostrarContenidoDirectorio(lvDirDer.Tag.ToString, lvDirDer)
    End Sub

    Private Sub LvDirIzq_Enter(sender As Object, e As EventArgs) Handles lvDirIzq.Enter, lvDirDer.Enter
        quePanel = TryCast(sender, ListView)
    End Sub

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        VerFichero()
    End Sub

    ''' <summary>
    ''' Mostrar el fichero seleccionado en Notepad (bloc de notas)
    ''' </summary>
    Private Sub VerFichero()
        If quePanel Is Nothing Then Return
        If quePanel.SelectedItems.Count = 0 Then Return
        Dim fi = TryCast(quePanel.SelectedItems(0).Tag, FileInfo)
        Dim pi As New ProcessStartInfo With {
            .FileName = "Notepad.exe",
            .Arguments = fi.FullName,
            .UseShellExecute = True,
            .WindowStyle = ProcessWindowStyle.Normal
        }
        Dim p As New Process With {
            .StartInfo = pi
        }
        p.Start()

    End Sub

    Private Sub BtnCopiar_Click(sender As Object, e As EventArgs) Handles btnCopiar.Click
        CopiarFichero()
    End Sub

    ''' <summary>
    ''' Copiar un fichero del panel activo al otro panel
    ''' </summary>
    Private Sub CopiarFichero()
        ' Si no está asignado el panel activo, salir
        If quePanel Is Nothing Then Return
        ' Si no hay fichero seleccionado en el panel activo, salir
        If quePanel.SelectedItems.Count = 0 Then Return
        ' El fichero (FileInfo) del primer fichero seleccionado
        Dim fi = TryCast(quePanel.SelectedItems(0).Tag, FileInfo)
        If fi Is Nothing Then Return

        Dim lvDest As ListView
        If quePanel Is lvDirIzq Then
            lvDest = lvDirDer
        Else
            lvDest = lvDirIzq
        End If
        Dim diDest = TryCast(lvDest.Tag, DirectoryInfo)
        If diDest Is Nothing Then Return
        Dim fDest = Path.Combine(diDest.FullName, fi.Name)
        If File.Exists(fDest) Then
            Dim s = "Ya existe un fichero con ese nombre en el destino." & vbCrLf &
                    $"{diDest.FullName}" & vbCrLf &
                    "¿Quieres sobre escribirlo?"
            Dim sTit = "Copiar fichero"

            If MessageBox.Show(s, sTit,
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If
            Try
                File.Delete(fDest)
            Catch ex As Exception
                LabelInfo.Text = ex.Message
                Return
            End Try
        End If
        File.Copy(fi.FullName, fDest)

        ' Releer el directorio de destino
        MostrarContenidoDirectorio(lvDest.Tag.ToString, lvDest)
    End Sub

    Private Sub BtnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        BorrarFichero()
    End Sub

    ''' <summary>
    ''' Borrar el fichero seleccionado en el panel activo
    ''' </summary>
    Private Sub BorrarFichero()
        ' Si no está asignado el panel activo, salir
        If quePanel Is Nothing Then Return
        ' Si no hay fichero seleccionado en el panel activo, salir
        If quePanel.SelectedItems.Count = 0 Then Return
        ' El fichero (FileInfo) del primer fichero seleccionado
        Dim fi = TryCast(quePanel.SelectedItems(0).Tag, FileInfo)
        If fi Is Nothing Then Return

        If fi.Exists Then
            Dim s = "¿Quieres borrar el fichero" & vbCrLf & $"{fi.FullName}?"
            Dim sTit = "Borrar fichero"

            If MessageBox.Show(s, sTit,
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If
            Try
                fi.Delete()
            Catch ex As Exception
                LabelInfo.Text = ex.Message
                Return
            End Try
        End If

        ' Releer el directorio de destino
        MostrarContenidoDirectorio(quePanel.Tag.ToString, quePanel)

    End Sub
End Class
