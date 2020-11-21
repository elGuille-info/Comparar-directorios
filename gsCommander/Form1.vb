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
    Private ReadOnly ultimosDirs As New List(Of String)

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
        Dim s = ""
        Dim diIzq = TryCast(lvDirIzq.Tag, DirectoryInfo)
        If diIzq IsNot Nothing Then s = $"{diIzq.FullName}"
        Dim diDer = TryCast(lvDirDer.Tag, DirectoryInfo)
        If diDer IsNot Nothing Then s &= $"{vbCrLf}y{vbCrLf}{diDer.FullName}"
        If Not s.Any Then Return

        Dim ret = ConfirmDialog.Show("¿Quieres comparar los dos directorios?:" & vbCrLf & vbCrLf &
                                     s,
                                     "Comparar directorios",
                                     DialogConfirmButtons.YesNo,
                                     DialogConfirmIcon.Information)
        If ret = DialogConfirmResult.Yes Then
            CompararDirectorios()
        End If

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

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Releer()
    End Sub

    Private Sub LvDirIzq_Enter(sender As Object, e As EventArgs) Handles lvDirIzq.Enter, lvDirDer.Enter
        quePanel = TryCast(sender, ListView)
    End Sub

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        VerFichero()
    End Sub

    Private Sub BtnCopiar_Click(sender As Object, e As EventArgs) Handles btnCopiar.Click
        CopiarFicheros()
    End Sub

    Private Sub BtnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        BorrarFicheros()
    End Sub

    Private Sub BtnNuevoFichero_Click(sender As Object, e As EventArgs) Handles btnNuevoFichero.Click
        NuevoFichero()
    End Sub

    Private Sub BtnMover_Click(sender As Object, e As EventArgs) Handles btnMover.Click
        MoverFicheros()
    End Sub

    Private Sub BtnMkDir_Click(sender As Object, e As EventArgs) Handles btnMkDir.Click
        CrearDirectorio()
    End Sub

    Private Sub BtnCopiarDir_Click(sender As Object, e As EventArgs) Handles btnCopiarDir.Click
        CopiarDirectorios()
    End Sub

    Private Sub BtnMoverDir_Click(sender As Object, e As EventArgs) Handles btnMoverDir.Click
        MoverDirectorios()
    End Sub

    Private Sub BtnBorrarDir_Click(sender As Object, e As EventArgs) Handles btnBorrarDir.Click
        BorrarDirectorios()
    End Sub

    ''' <summary>
    ''' Crear un nuevo fichero en el panel activo
    ''' </summary>
    Private Sub NuevoFichero()
        ' Si no está asignado el panel activo, salir
        If quePanel Is Nothing Then Return
        ' El directorio del panel activo
        Dim diDest = TryCast(quePanel.Tag, DirectoryInfo)
        If diDest Is Nothing Then Return

        Dim dNuevo = InputBox($"Nombre para el nuevo fichero a crear en:{vbCrLf}{vbCrLf}{diDest.FullName}",
                              "Crear fichero",
                              "prueba.txt")
        If dNuevo.Any Then
            Dim dDest = Path.Combine(diDest.FullName, dNuevo)
            If File.Exists(dDest) Then
                ConfirmDialog.Show("Ya existe un fichero con ese nombre.",
                                   "Crear fichero",
                                   DialogConfirmButtons.OK,
                                   DialogConfirmIcon.Information)
            Else
                Try
                    ' CreateText usa la codificación UTF-8
                    File.CreateText(dDest)
                Catch ex As Exception
                    LabelInfo.Text = ex.Message
                    ConfirmDialog.Show($"Error al crear el fichero {dNuevo}{vbCrLf}{vbCrLf}{ex.Message}",
                                       "Crear fichero",
                                       DialogConfirmButtons.OK,
                                       DialogConfirmIcon.Warning)
                End Try
            End If
        End If
        MostrarContenidoDirectorio(quePanel.Tag.ToString, quePanel)

    End Sub

    ''' <summary>
    ''' Crear un directorio en el panel activo
    ''' </summary>
    Private Sub CrearDirectorio()
        ' Si no está asignado el panel activo, salir
        If quePanel Is Nothing Then Return
        ' El directorio del panel activo
        Dim diDest = TryCast(quePanel.Tag, DirectoryInfo)
        If diDest Is Nothing Then Return

        Dim dNuevo = InputBox($"Nombre para el nuevo directorio a crear en:{vbCrLf}{vbCrLf}{diDest.FullName}",
                              "Crear directorio",
                              "Nuevo directorio")
        If dNuevo.Any Then
            Dim dDest = Path.Combine(diDest.FullName, dNuevo)
            If Directory.Exists(dDest) Then
                ConfirmDialog.Show("Ya existe un directorio con ese nombre.",
                                   "Crear directorio",
                                   DialogConfirmButtons.OK,
                                   DialogConfirmIcon.Information)
            Else
                Try
                    Directory.CreateDirectory(dDest)
                Catch ex As Exception
                    LabelInfo.Text = ex.Message
                    ConfirmDialog.Show($"Error al crear el directorio {dNuevo}{vbCrLf}{vbCrLf}{ex.Message}",
                                       "Crear directorio",
                                       DialogConfirmButtons.OK,
                                       DialogConfirmIcon.Warning)
                End Try
            End If
        End If
        MostrarContenidoDirectorio(quePanel.Tag.ToString, quePanel)
    End Sub

    ''' <summary>
    ''' Copiar los directorios seleccionados
    ''' </summary>
    Private Sub CopiarDirectorios()
        ' Si no está asignado el panel activo, salir
        If quePanel Is Nothing Then Return
        ' Si no hay nada seleccionado en el panel activo, salir
        If quePanel.SelectedIndices.Count = 0 Then Return

        Dim lvDest As ListView
        If quePanel Is lvDirIzq Then
            lvDest = lvDirDer
        Else
            lvDest = lvDirIzq
        End If
        Dim diDest = TryCast(lvDest.Tag, DirectoryInfo)
        If diDest Is Nothing Then Return

        Dim copiarTodos = False

        ' Copiar todos los directorios seleccionados
        For i = 0 To quePanel.SelectedIndices.Count - 1
            ' El directorio (DirectoryInfo) seleccionado
            Dim di = TryCast(quePanel.Items(quePanel.SelectedIndices(i)).Tag, DirectoryInfo)
            ' Si no es un directorio, continuar
            If di Is Nothing Then Continue For

            Dim dDest = Path.Combine(diDest.FullName, di.Name)
            If Directory.Exists(dDest) Then
                Dim s = $"Ya existe un directorio con el nombre {di.Name} en el destino." & vbCrLf & vbCrLf &
                    $"{dDest}" & vbCrLf & vbCrLf &
                    "¿Quieres sobrescribir todos los ficheros que contenga?"
                Dim sTit = "Copiar directorio"

                Dim ret As DialogConfirmResult

                ' Si se debe volver a mostrar el diálogo de confirmación
                If Not copiarTodos Then
                    ret = ConfirmDialog.Show(s, sTit, DialogConfirmButtons.All, DialogConfirmIcon.Warning)
                    If ret = DialogConfirmResult.NoToAll Then
                        Return
                    ElseIf ret = DialogConfirmResult.No Then
                        Continue For
                    ElseIf ret = DialogConfirmResult.YesToAll Then
                        copiarTodos = True
                    End If
                End If
                'Else
                '    ' Crear el directorio en el destino
                '    ' en realidad no es necesario
                '    ' copiarFiles2Dir lo crea si no existe
                '    Directory.CreateDirectory(dDest)
            End If

            ' Copiar cada directorio y ficheros del directorio de origen en el destino
            ' primero copiar los ficheros
            Dim files = di.GetFiles
            copiarFiles2Dir(files, dDest)

            ' a coninuación los directorios y sus ficheros, etc.
            ' hay que hacerlo recursivo
            Dim dirs = di.GetDirectories
            copiarDirs2Dir(dirs, dDest)
        Next

        ' Releer los dos directorios
        'MostrarContenidoDirectorio(lvDest.Tag.ToString, lvDest)
        Releer()

    End Sub

    ''' <summary>
    ''' Copiar recursivamente los directorios de origen a destino
    ''' </summary>
    ''' <param name="dirs">Array de tipo DirectoryInfo con los directorios a del origen</param>
    ''' <param name="dDest">Directorio de destino, si no existe se creará</param>
    Private Sub copiarDirs2Dir(dirs As DirectoryInfo(), dDest As String)
        ' si no existe, crear el directorio de destino
        If Not Directory.Exists(dDest) Then
            Directory.CreateDirectory(dDest)
        End If

        For Each di In dirs
            Dim dDest2 = Path.Combine(dDest, di.Name)
            If Not Directory.Exists(dDest2) Then
                Directory.CreateDirectory(dDest2)
            End If
            LabelInfo.Text = $"Copiando el directorio {di.Name} en {dDest2}..."
            Application.DoEvents()

            ' Copiar todos los ficheros
            Dim files = di.GetFiles
            copiarFiles2Dir(files, dDest2)

            ' comprobar si hay más directorios
            ' y copiarlos recursivamente
            Dim dirs2 = di.GetDirectories
            copiarDirs2Dir(dirs2, dDest2)
        Next
    End Sub

    ''' <summary>
    ''' Copiar los ficheros indicados en el directorio de destino.
    ''' </summary>
    ''' <param name="files">Array del tipo FileInfo con los ficheros de origen a copiar</param>
    ''' <param name="dDest">Directorio de destino, si no existe se creará</param>
    Private Sub copiarFiles2Dir(files As FileInfo(), dDest As String)
        ' si no existe, crear el directorio de destino
        If Not Directory.Exists(dDest) Then
            Directory.CreateDirectory(dDest)
        End If
        ' copiar todos los ficheros indicados
        For Each fi In files
            Dim fDest = Path.Combine(dDest, fi.Name)
            Try
                LabelInfo.Text = $"Copiando {fi.Name} en {dDest}..."
                Application.DoEvents()

                'fi.CopyTo(fDest, True)
                File.Copy(fi.FullName, fDest, True)
            Catch ex As Exception
                LabelInfo.Text = ex.Message
                Continue For
            End Try
        Next
    End Sub

    ''' <summary>
    ''' Mover los directorios seleccionados en el panel activo al otro panel
    ''' </summary>
    Private Sub MoverDirectorios()
        ' Si no está asignado el panel activo, salir
        If quePanel Is Nothing Then Return
        ' Si no hay fichero seleccionado en el panel activo, salir
        If quePanel.SelectedIndices.Count = 0 Then Return

        Dim lvDest As ListView
        If quePanel Is lvDirIzq Then
            lvDest = lvDirDer
        Else
            lvDest = lvDirIzq
        End If
        Dim diDest = TryCast(lvDest.Tag, DirectoryInfo)
        If diDest Is Nothing Then Return

        Dim moverTodos = False
        Dim sobrescribirTodos = False

        ' Mover todos los ficheros seleccionados
        For i = quePanel.SelectedIndices.Count - 1 To 0 Step -1
            ' El directorio (DirectoryInfo) seleccionado
            Dim di = TryCast(quePanel.Items(quePanel.SelectedIndices(i)).Tag, DirectoryInfo)
            ' Si no es un directorio, continuar
            If di Is Nothing Then Continue For

            Dim dOri = di.FullName

            ' Preguntar si lo quiere mover
            Dim s = $"¿Quieres mover el directorio {di.Name}?{vbCrLf}{vbCrLf}{di.FullName}{vbCrLf}"
            Dim sTit = "Mover directorio"

            Dim ret As DialogConfirmResult
            ' Si se debe volver a mostrar el diálogo de confirmación
            If Not moverTodos Then
                ret = ConfirmDialog.Show(s, sTit, DialogConfirmButtons.All, DialogConfirmIcon.Warning)
                If ret = DialogConfirmResult.NoToAll Then
                    Return
                ElseIf ret = DialogConfirmResult.No Then
                    Continue For
                ElseIf ret = DialogConfirmResult.YesToAll Then
                    moverTodos = True
                End If
            End If

            ' Comprobar si ya existe y lo quiere sobrescribir
            Dim dDest = Path.Combine(diDest.FullName, di.Name)
            If Directory.Exists(dDest) Then
                s = $"Ya existe un directorio con el nombre '{di.Name}' en el directorio de destino." & vbCrLf & vbCrLf &
                    $"{diDest.FullName}" & vbCrLf & vbCrLf &
                    "¿Quieres sobrescribirlo?"
                sTit = "Mover directorio"

                'ret = DialogConfirmResult.None

                ' Si se debe volver a mostrar el diálogo de confirmación
                If Not sobrescribirTodos Then
                    ret = ConfirmDialog.Show(s, sTit, DialogConfirmButtons.All, DialogConfirmIcon.Warning)
                    If ret = DialogConfirmResult.NoToAll Then
                        Return
                    ElseIf ret = DialogConfirmResult.No Then
                        Continue For
                    ElseIf ret = DialogConfirmResult.YesToAll Then
                        sobrescribirTodos = True
                    End If
                End If
            End If
            Try
                ' Antes de moverlo, hay que eliminar el de destino
                ' pero debe estar vacío
                If Directory.Exists(dDest) Then
                    LabelInfo.Text = $"Eliminando el directorio {di.Name}..."
                    Application.DoEvents()

                    eliminarContenidoDir(dDest)
                    If Directory.Exists(dDest) Then
                        Directory.Delete(dDest)
                    End If
                End If
                ' Mover el directorio,
                ' en realidad es copiar pero con todo el contenido que tenga
                Directory.Move(dOri, dDest)
            Catch ex As Exception
                LabelInfo.Text = ex.Message
                Continue For
            End Try

        Next

        ' Releer los dos directorios
        Releer()

    End Sub

    ''' <summary>
    ''' Eliminar todo el contenido de un directorio
    ''' </summary>
    ''' <param name="sDir">El nombre del directorio a eliminar</param>
    Private Sub eliminarContenidoDir(sDir As String)
        Dim di = New DirectoryInfo(sDir)
        ' eliminar los ficheros
        Dim files = di.GetFiles
        For i = files.Length - 1 To 0 Step -1
            files(i).Delete()
        Next
        Dim dirs = di.GetDirectories
        For i = dirs.Length - 1 To 0 Step -1
            eliminarContenidoDir(dirs(i).FullName)
        Next
    End Sub

    ''' <summary>
    ''' Eliminar los directorios seleccionados en el panel activo
    ''' </summary>
    Private Sub BorrarDirectorios()
        ' Si no está asignado el panel activo, salir
        If quePanel Is Nothing Then Return
        ' Si no hay nada seleccionado en el panel activo, salir
        If quePanel.SelectedIndices.Count = 0 Then Return

        Dim diDest = TryCast(quePanel.Tag, DirectoryInfo)
        If diDest Is Nothing Then Return

        Dim borrarTodos = False

        For i = quePanel.SelectedIndices.Count - 1 To 0 Step -1
            ' El directorio (DirectoryInfo) seleccionado
            Dim di = TryCast(quePanel.Items(quePanel.SelectedIndices(i)).Tag, DirectoryInfo)
            ' Si no es un directorio, continuar
            If di Is Nothing Then Continue For

            ' Confirmar solo si existe
            If di.Exists Then
                Dim s = $"¿Quieres borrar el directorio {di.Name}{vbCrLf}{vbCrLf} de {di.FullName}?"
                Dim sTit = "Borrar directorio"

                Dim ret As DialogConfirmResult

                ' Si se debe volver a mostrar el diálogo de confirmación
                If Not borrarTodos Then
                    ret = ConfirmDialog.Show(s, sTit, DialogConfirmButtons.All, DialogConfirmIcon.Warning)
                    If ret = DialogConfirmResult.NoToAll Then
                        Return
                    ElseIf ret = DialogConfirmResult.No Then
                        Continue For
                    ElseIf ret = DialogConfirmResult.YesToAll Then
                        borrarTodos = True
                    End If
                End If

                Try
                    di.Delete()
                Catch ex As Exception
                    LabelInfo.Text = ex.Message
                    Continue For
                End Try
            End If

        Next

        ' Releer el directorio
        MostrarContenidoDirectorio(quePanel.Tag.ToString, quePanel)

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
            'it.SubItems.Add($"[↑ {dir.Parent.Name.ToUpper}]")
            it.SubItems.Add($"[..\{dir.Parent.Name.ToUpper}]")
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

    ''' <summary>
    ''' Copiar un fichero del panel activo al otro panel
    ''' </summary>
    Private Sub CopiarFicheros()
        ' Si no está asignado el panel activo, salir
        If quePanel Is Nothing Then Return
        ' Si no hay fichero seleccionado en el panel activo, salir
        If quePanel.SelectedIndices.Count = 0 Then Return

        Dim lvDest As ListView
        If quePanel Is lvDirIzq Then
            lvDest = lvDirDer
        Else
            lvDest = lvDirIzq
        End If
        Dim diDest = TryCast(lvDest.Tag, DirectoryInfo)
        If diDest Is Nothing Then Return

        Dim copiarTodos = False

        ' Copiar todos los ficheros seleccionados
        For i = 0 To quePanel.SelectedIndices.Count - 1
            ' El fichero (FileInfo) seleccionado
            Dim fi = TryCast(quePanel.Items(quePanel.SelectedIndices(i)).Tag, FileInfo)
            ' Si no es un fichero, continuar
            If fi Is Nothing Then Continue For

            Dim fDest = Path.Combine(diDest.FullName, fi.Name)
            If File.Exists(fDest) Then
                Dim s = $"Ya existe un fichero con el nombre {fi.Name} en el destino." & vbCrLf & vbCrLf &
                    $"{diDest.FullName}" & vbCrLf & vbCrLf &
                    "¿Quieres sobrescribirlo?"
                Dim sTit = "Copiar fichero"

                Dim ret As DialogConfirmResult

                ' Si se debe volver a mostrar el diálogo de confirmación
                If Not copiarTodos Then
                    ret = ConfirmDialog.Show(s, sTit, DialogConfirmButtons.All, DialogConfirmIcon.Information)
                    If ret = DialogConfirmResult.NoToAll Then
                        Return
                    ElseIf ret = DialogConfirmResult.No Then
                        Continue For
                    ElseIf ret = DialogConfirmResult.YesToAll Then
                        copiarTodos = True
                    End If
                End If

            End If
            Try
                File.Copy(fi.FullName, fDest, True)
            Catch ex As Exception
                LabelInfo.Text = ex.Message
                Return
            End Try
        Next

        ' Releer el directorio de destino
        'MostrarContenidoDirectorio(lvDest.Tag.ToString, lvDest)
        Releer()
    End Sub

    ''' <summary>
    ''' Mover los ficheros seleccionados del panel activo al otro panel
    ''' </summary>
    Private Sub MoverFicheros()
        ' Si no está asignado el panel activo, salir
        If quePanel Is Nothing Then Return
        ' Si no hay fichero seleccionado en el panel activo, salir
        If quePanel.SelectedIndices.Count = 0 Then Return

        Dim lvDest As ListView
        If quePanel Is lvDirIzq Then
            lvDest = lvDirDer
        Else
            lvDest = lvDirIzq
        End If
        Dim diDest = TryCast(lvDest.Tag, DirectoryInfo)
        If diDest Is Nothing Then Return

        Dim moverTodos = False
        Dim sobrescribirTodos = False

        ' Mover todos los ficheros seleccionados
        For i = quePanel.SelectedIndices.Count - 1 To 0 Step -1
            ' El fichero (FileInfo) seleccionado
            Dim fi = TryCast(quePanel.Items(quePanel.SelectedIndices(i)).Tag, FileInfo)
            ' Si no es un fichero, continuar
            If fi Is Nothing Then Continue For

            Dim fOri = fi.FullName

            ' Preguntar si lo quiere mover
            Dim s = $"¿Quieres mover el fichero {fi.Name}?{vbCrLf}{vbCrLf}{fi.FullName}{vbCrLf}"
            Dim sTit = "Mover fichero"

            Dim ret As DialogConfirmResult
            ' Si se debe volver a mostrar el diálogo de confirmación
            If Not moverTodos Then
                ret = ConfirmDialog.Show(s, sTit, DialogConfirmButtons.All, DialogConfirmIcon.Warning)
                If ret = DialogConfirmResult.NoToAll Then
                    Return
                ElseIf ret = DialogConfirmResult.No Then
                    Continue For
                ElseIf ret = DialogConfirmResult.YesToAll Then
                    moverTodos = True
                End If
            End If

            ' Comprobar si ya existe y lo quiere sobrescribir
            Dim fDest = Path.Combine(diDest.FullName, fi.Name)
            If File.Exists(fDest) Then
                s = $"Ya existe un fichero con el nombre '{fi.Name}' en el directorio de destino." & vbCrLf & vbCrLf &
                    $"{diDest.FullName}" & vbCrLf & vbCrLf &
                    "¿Quieres sobrescribirlo?"
                sTit = "Mover fichero"

                'ret = DialogConfirmResult.None

                ' Si se debe volver a mostrar el diálogo de confirmación
                If Not sobrescribirTodos Then
                    ret = ConfirmDialog.Show(s, sTit, DialogConfirmButtons.All, DialogConfirmIcon.Warning)
                    If ret = DialogConfirmResult.NoToAll Then
                        Return
                    ElseIf ret = DialogConfirmResult.No Then
                        Continue For
                    ElseIf ret = DialogConfirmResult.YesToAll Then
                        sobrescribirTodos = True
                    End If
                End If
            End If
            Try
                ' Antes de moverlo, hay que borrar el de destino
                ' si no dará error de que no se puede mover un fichero que ya existe
                If File.Exists(fDest) Then
                    File.Delete(fDest)
                End If
                ' Mover el fichero, en realidad es copiar
                File.Move(fOri, fDest)
            Catch ex As Exception
                LabelInfo.Text = ex.Message
                Continue For
            End Try

        Next

        ' Releer los dos directorios
        Releer()

    End Sub

    ''' <summary>
    ''' Borrar el fichero seleccionado en el panel activo
    ''' </summary>
    Private Sub BorrarFicheros()
        ' Si no está asignado el panel activo, salir
        If quePanel Is Nothing Then Return
        ' Si no hay fichero seleccionado en el panel activo, salir
        If quePanel.SelectedIndices.Count = 0 Then Return

        Dim borrarTodos = False

        ' Borrar todos los ficheros seleccionados
        For i = 0 To quePanel.SelectedIndices.Count - 1
            ' El fichero (FileInfo) seleccionado
            Dim fi = TryCast(quePanel.Items(quePanel.SelectedIndices(i)).Tag, FileInfo)
            ' Si no es un fichero, continuar
            If fi Is Nothing Then Continue For

            ' Confirmar solo si existe
            If fi.Exists Then
                Dim s = $"¿Quieres borrar el fichero{vbCrLf}{vbCrLf}{fi.FullName}?"
                Dim sTit = "Borrar fichero"

                Dim ret As DialogConfirmResult

                ' Si se debe volver a mostrar el diálogo de confirmación
                If Not borrarTodos Then
                    ret = ConfirmDialog.Show(s, sTit, DialogConfirmButtons.All, DialogConfirmIcon.Warning)
                    If ret = DialogConfirmResult.NoToAll Then
                        Return
                    ElseIf ret = DialogConfirmResult.No Then
                        Continue For
                    ElseIf ret = DialogConfirmResult.YesToAll Then
                        borrarTodos = True
                    End If
                End If

                Try
                    fi.Delete()
                Catch ex As Exception
                    LabelInfo.Text = ex.Message
                    Continue For
                End Try
            End If

        Next

        ' Releer el directorio
        MostrarContenidoDirectorio(quePanel.Tag.ToString, quePanel)

    End Sub

    ''' <summary>
    ''' Releer el contenido de los dos directorios
    ''' </summary>
    Private Sub Releer()
        MostrarContenidoDirectorio(lvDirIzq.Tag.ToString, lvDirIzq)
        MostrarContenidoDirectorio(lvDirDer.Tag.ToString, lvDirDer)
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

End Class