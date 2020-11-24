'------------------------------------------------------------------------------
' Visor de texto, HTML y Tar y Zip                                  (24/Nov/20)
'
' Usando parte del código de los formularios usados en guilleUtilComprimir
' VisorArchivosTar
' VisorArhivosWeb
' VisorTexto
'
' ©Guillermo 'guille' Som, 2006, 2020
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports Microsoft.VisualBasic
Imports vb = Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing

'Imports System.Text
'Imports System.IO
'Imports System.Collections.Generic

Imports elGuille.Utilidades.Comprimir
Imports System.IO.Compression
Imports System.IO
Imports System.Text

Public Class visorTexto

    Private Shared ExtensionesWeb As New HashSet(Of String) From {".htm", ".html", ".svg"}
    Private Shared ExtensionesImagen As New HashSet(Of String) From {".bmp", ".jpg", ".jpeg", ".gif", ".png", ".ico", ".tiff"}
    Private Shared ExtensionesZip As New HashSet(Of String) From {".zip", ".rar", ".tar", ".gz", ".gzz", ".gzd", ".tar.gz", ".tar.gzz"}
    Private Shared ExtensionesTexto As New HashSet(Of String) From {".txt", ".rtf", ".ini", ".log", ".md", ".css", ".asp", ".aspx", ".js", ".config", ".resx", ".user"}
    Private Shared ExtensionesCodigo As New HashSet(Of String) From {".bas", ".frm", ".cls", ".mak", ".vbp", ".sln", ".vbproj", ".csproj", ".cs", ".vb", ".cpp", ".c", ".h", ".vbs"}

    Public Shared ExtensionesVisor As New HashSet(Of String)

    Shared Sub New()
        ExtensionesVisor.Clear()
        'AddExtensiones(ExtensionesBin)
        AddExtensiones(ExtensionesCodigo)
        AddExtensiones(ExtensionesImagen)
        AddExtensiones(ExtensionesTexto)
        AddExtensiones(ExtensionesWeb)
        AddExtensiones(ExtensionesZip)
    End Sub
    Private Shared Sub AddExtensiones(col As HashSet(Of String))
        For i = 0 To col.Count - 1
            ExtensionesVisor.Add(col(i))
        Next
    End Sub

    Private Sub ocultarControles()
        rtbTexto.Visible = False
        WebBrowser1.Visible = False
        lvTar.Visible = False
        ToolStrip1.Visible = False
        PictureBox1.Visible = False
    End Sub

    Private Sub MostrarLvTar()
        ocultarControles()
        lvTar.Dock = DockStyle.Fill
        lvTar.Visible = True
    End Sub

    Private Sub MostrarImagen(img As Image)
        ocultarControles()
        'PictureBox1.Dock = DockStyle.Fill
        PictureBox1.Dock = DockStyle.None
        PictureBox1.Size = New Drawing.Size(Panel1.Size.Width - 12, Panel1.Size.Height - 12)
        PictureBox1.Location = New Point(6, 6)
        PictureBox1.Image = img
        PictureBox1.Visible = True

        If statusLabelInfo.Text.Any Then
            statusLabelInfo.Text &= " - Pulsa con el botón derecho para mover y cambiar el tamaño de la imagen."
        End If

    End Sub

    Private Sub MostrarRtb()
        ocultarControles()
        rtbTexto.Dock = DockStyle.Fill
        rtbTexto.Visible = True
    End Sub

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        With lvTar
            .View = View.Details
            .GridLines = True
            .FullRowSelect = True
            .LabelEdit = False
            .MultiSelect = False
            .HideSelection = False
            '.Columns.Clear()
            '.Columns.Add("Nombre", 150, HorizontalAlignment.Left)
            '.Columns.Add("Tamaño", 80, HorizontalAlignment.Right)
            '.Columns.Add("Fecha", 130, HorizontalAlignment.Right)
            '.Columns.Add("Directorio", 200, HorizontalAlignment.Left)
            .Items.Clear()
        End With

        ocultarControles()

        rtbTexto.Dock = DockStyle.Fill
        rtbTexto.Visible = True

        Dim sCopyR = "(c) Guillermo Som (elGuille), 2020"
        If Date.Now.Year > 2020 Then
            sCopyR &= $"-{Date.Now.Year}"
        End If

        statusLabelInfo.Text = $"{Application.ProductName} v{Application.ProductVersion}, {sCopyR} "
        Me.Text = statusLabelInfo.Text & " [Visor]"

    End Sub

    ''' <summary>
    ''' Mostrar el contenido de un fichero .tar
    ''' </summary>
    ''' <param name="th"></param>
    Public Sub New(th As Tar)
        Me.New()

        MostrarTexto(th)

        Me.statusLabelInfo.Text = String.Format("Archivo {0}, Tamaño: {1:#,##0}, Fecha Modificación: {2:dd/MM/yyyy HH:mm:ss}",
                                                th.FileName, th.Size, th.DateTime)
    End Sub

    ''' <summary>
    ''' Para mostrar el contenido de una entrada de un fichero zip
    ''' </summary>
    ''' <param name="archZip"></param>
    ''' <param name="zipEntry"></param>
    Public Sub New(archZip As ZipArchive, zipEntry As ZipArchiveEntry)
        Me.New

        MostrarTexto(archZip, zipEntry)

        Me.statusLabelInfo.Text = String.Format("Archivo {0}, Tamaño: {1:#,##0}, Fecha Modificación: {2:dd/MM/yyyy HH:mm:ss}",
                                                zipEntry.Name, zipEntry.Length, zipEntry.LastWriteTime)
    End Sub

    ''' <summary>
    ''' Mostrar el navegador usando la URI indicada
    ''' </summary>
    ''' <param name="url"></param>
    Public Sub New(url As Uri)
        Me.New()

        MostrarWeb(url)
    End Sub

    ''' <summary>
    ''' Mostrar la imagen indicada
    ''' </summary>
    ''' <param name="img"></param>
    Public Sub New(img As Image)
        Me.New()

        'statusLabelInfo.Text = ""
        MostrarImagen(img)
    End Sub


    ''' <summary>
    ''' Constructor para indicar el path de un archivo .tar o .zip a mostrar el contenido.
    ''' </summary>
    ''' <param name="archivo">Path del archivo de tipo .tar o .zip a mostrar</param>
    ''' <remarks></remarks>
    Public Sub New(archivo As String)
        Me.New()

        abrirArchivo(archivo)
    End Sub

    ''' <summary>
    ''' Abrir el archivo indicado, se comprueba si está comprimido.
    ''' </summary>
    ''' <param name="arch">El archivo a abrir</param>
    ''' <remarks></remarks>
    Private Sub abrirArchivo(arch As String)
        If vb.Len(arch) = 0 Then Exit Sub

        If File.Exists(arch) = False Then
            statusLabelInfo.Text = "No existe el archivo " & Path.GetFileName(arch)
            Exit Sub
        End If
        statusLabelInfo.Text = "Mostrando el archivo " & Path.GetFileName(arch)

        ' Si es un archivo comprimido, extraerlo
        ' Si es un archivo .tar mostrar los archivos que contiene
        ' Si es un archivo de texto mostrar el contenido en la caja de textos
        ' que al ser del tipo RichTextBox, acepta más formatos.
        Dim formatoArch As FormatosCompresion = UtilCompress.FormatoPorExtension(arch)
        Select Case formatoArch
            Case FormatosCompresion.TarGZip, FormatosCompresion.Tar
                abrirTarZip(arch)
            Case FormatosCompresion.Deflate, FormatosCompresion.GZip
                descomprimirMostrar(arch)
            Case FormatosCompresion.Zip
                rtbTexto.Text = UtilCompress.DescomprimirZipInfo(arch)
                abrirTarZip(arch)
            Case Else
                ' Si no es un archivo "reconocido",
                ' abrir el archivo y mostrarlo en el RichTextBox.

                Dim ext = Path.GetExtension(arch).ToLower
                If ext = ".rtf" Then
                    'Dim fVT As New visorTexto
                    MostrarRtb()
                    rtbTexto.LoadFile(arch)
                ElseIf ExtensionesWeb.Contains(ext) Then
                    MostrarWeb(New Uri(arch))
                ElseIf ExtensionesImagen.Contains(ext) Then
                    Dim img As Image = Image.FromFile(arch)
                    MostrarImagen(img)
                Else
                    MostrarRtb()
                    Dim f As Encoding = Encoding.UTF8
                    Using sr As New StreamReader(arch, f, True)
                        rtbTexto.Text = sr.ReadToEnd
                        sr.Close()
                    End Using
                End If
        End Select
    End Sub

    ''' <summary>
    ''' Abrir el archivo de tipo .tar o .zip y mostrar los archivos que contiene.
    ''' </summary>
    ''' <param name="arch">El archivo .tar o .zip a abrir</param>
    ''' <remarks>Si no es un archivo .tar o .zip no se muestra nada ni se produce error</remarks>
    Private Sub abrirTarZip(arch As String)
        If File.Exists(arch) = False Then
            statusLabelInfo.Text = "No existe el archivo " & Path.GetFileName(arch)
            Exit Sub
        End If
        statusLabelInfo.Text = "Mostrando el archivo " & Path.GetFileName(arch)

        MostrarTarZip(arch)
    End Sub

    ''' <summary>
    ''' Descomprimir el archivo indicado y mostrarlo en la caja de textos.
    ''' </summary>
    ''' <param name="arch">El archivo a descomprimir</param>
    ''' <remarks></remarks>
    Private Sub descomprimirMostrar(arch As String)
        If File.Exists(arch) = False Then
            statusLabelInfo.Text = "No existe el archivo " & Path.GetFileName(arch)
            Exit Sub
        End If
        statusLabelInfo.Text = "Contenido del archivo " & Path.GetFileName(arch)

        rtbTexto.Text = ""
        rtbTexto.Refresh()
        rtbTexto.Text = UtilCompress.Descomprimir(arch)
    End Sub

    ''' <summary>
    ''' Mostrar la Uri indicada en el navegador
    ''' </summary>
    ''' <param name="url"></param>
    Public Sub MostrarWeb(url As Uri)
        ocultarControles()
        ToolStrip1.Visible = True
        WebBrowser1.Dock = DockStyle.Fill
        WebBrowser1.Visible = True

        tsDireccion.Width = ToolStrip1.ClientRectangle.Width - tsLabelDireccion.Width - tsbIr.Width - 60

        Me.tsDireccion.Text = url.AbsolutePath
        Me.WebBrowser1.Navigate(url)
    End Sub


    Public Sub MostrarTexto(th As Tar)
        MostrarRtb()
        Me.statusLabelInfo.Text = "Contenido de: " & th.FileName
        Me.rtbTexto.Text = th.LeerContenido()
    End Sub

    Public Sub MostrarTexto(archZip As ZipArchive, zipEntry As ZipArchiveEntry)
        MostrarRtb()
        Me.statusLabelInfo.Text = "Contenido de: " & zipEntry.Name
        Me.rtbTexto.Text = UtilCompress.ExtraerZipEntry(archZip, zipEntry)
    End Sub

    '
    ' Mostrar archivos Tar y Zip
    '

    ''' <summary>
    ''' Método para indicar que archivo .tar o .zip mostraremos.
    ''' </summary>
    ''' <param name="archivo">El path al archivo a mostrar</param>
    ''' <remarks></remarks>
    Public Sub MostrarTarZip(archivo As String)
        MostrarLvTar()

        Dim formatoArch As FormatosCompresion = UtilCompress.FormatoPorExtension(archivo)

        If formatoArch = FormatosCompresion.Tar Then
            Dim archs As List(Of Tar) = UtilTar.ArchivosTar(archivo)

            For Each th As Tar In archs
                Dim lvi As ListViewItem = lvTar.Items.Add(th.FileName)
                lvi.SubItems.Add(th.Size.ToString("#,##0"))
                lvi.SubItems.Add(th.DateTime.ToString("dd/MM/yyyy HH:mm:ss"))
                lvi.SubItems.Add(th.DirectoryName)
                ' Guardamos una referencia al objeto de tipo Tar
                lvi.Tag = th
            Next
        ElseIf formatoArch = FormatosCompresion.Zip Then
            Dim contZip = UtilCompress.ContenidoZip(archivo)
            Dim archs As HashSet(Of ZipArchiveEntry) = contZip.ZipEntries
            lvTar.Tag = contZip.ArchivoZip

            For Each zipEntry As ZipArchiveEntry In archs
                Dim lvi As ListViewItem = lvTar.Items.Add(zipEntry.Name)
                lvi.SubItems.Add(zipEntry.Length.ToString("#,##0"))
                lvi.SubItems.Add(zipEntry.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss"))
                lvi.SubItems.Add(Path.GetDirectoryName(zipEntry.FullName))
                ' Guardamos una referencia al objeto de tipo ZipArchiveEntry
                lvi.Tag = zipEntry
            Next
        End If

        Me.statusLabelInfo.Text = String.Format("{0} con {1} archivos",
                        Path.GetFileName(archivo), lvTar.Items.Count)
    End Sub

    ''' <summary>
    ''' Mostrar el archivo seleccionado en el ListView
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lvTar_DoubleClick(sender As Object, e As EventArgs) Handles lvTar.DoubleClick
        If lvTar.SelectedIndices.Count = 0 Then Exit Sub

        Dim lvi As ListViewItem = lvTar.SelectedItems(0)

        ' Convertimos la referencia al objeto asociado a este elemento del ListView
        ' comprobar si es un archivo .tar
        Dim th As Tar = TryCast(lvi.Tag, Tar)
        If th IsNot Nothing Then
            Dim fVT As New visorTexto(th)
            fVT.MostrarTexto(th)
            fVT.BringToFront()
            fVT.Show()
            Return
        End If

        Dim zip As ZipArchiveEntry
        zip = TryCast(lvi.Tag, ZipArchiveEntry)
        If zip Is Nothing Then Return
        Dim archZip = TryCast(lvTar.Tag, ZipArchive)
        If archZip Is Nothing Then Return

        Dim ext = Path.GetExtension(zip.Name)
        If ext = ".rtf" Then
            Dim arch = UtilCompress.ExtraerZipPath(archZip, zip)
            Dim fVT As New visorTexto
            fVT.rtbTexto.LoadFile(arch)
            fVT.Show()
            fVT.BringToFront()
        ElseIf ExtensionesImagen.Contains(ext) Then
            Dim arch = UtilCompress.ExtraerZipPath(archZip, zip)
            Dim img As Image = Image.FromFile(arch)
            Dim fWe As New visorTexto(img)
            fWe.Show()
            fWe.BringToFront()
        ElseIf ExtensionesImagen.Contains(ext) Then
            Dim arch = UtilCompress.ExtraerZipPath(archZip, zip)
            Dim fWe As New visorTexto(New Uri(arch))
            fWe.Show()
            fWe.BringToFront()
        Else
            Dim arch = UtilCompress.ExtraerZipPath(archZip, zip)
            Dim fVT As New visorTexto
            fVT.rtbTexto.LoadFile(arch, RichTextBoxStreamType.PlainText)
            fVT.Show()
            fVT.BringToFront()
        End If

    End Sub

    '
    ' Para el navegador web
    '

    Private Sub tsbIr_Click(sender As System.Object, e As System.EventArgs) Handles tsbIr.Click
        Me.WebBrowser1.Navigate(tsDireccion.Text)
    End Sub

    Private Sub visor_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        If Me.WindowState <> FormWindowState.Minimized Then
            Me.tsDireccion.Width = Me.ToolStrip1.ClientRectangle.Width - Me.tsLabelDireccion.Width - Me.tsbIr.Width - 60
        End If
    End Sub

    Private Sub tsDireccion_Enter(sender As Object, e As System.EventArgs) Handles tsDireccion.Enter
        tsDireccion.SelectAll()
    End Sub

    Private Sub visorTexto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CambiarTema()
        AsignarEventos(Me)
    End Sub

    ''' <summary>
    ''' Cambiar los colores al tema seleccionado
    ''' </summary>
    Private Sub CambiarTema()
        AsignarTema(Me, VentanaFondo, VentanaTexto)

        AsignarTema(Panel1, VentanaFondo, VentanaTexto)
        AsignarTema(lvTar, VentanaFondo, VentanaTexto)
        AsignarTema(rtbTexto, VentanaFondo, VentanaTexto)
        AsignarTema(PictureBox1, VentanaFondo, VentanaTexto)

        AsignarTema(StatusStrip1, StatusFondo, StatusTexto)
        For Each btn As Control In StatusStrip1.Controls
            AsignarTema(btn, BotonesFondo, BotonesTexto)
        Next

    End Sub

    ' Para cambiar el tamaño del picture
    Private DX, DY As Integer

    ' Declaraciones del API para 32 bits
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" _
        (ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" _
        (ByVal hwnd As Integer, ByVal nIndex As Integer,
         ByVal dwNewLong As Integer) As Integer
    Private Declare Function SetWindowPos Lib "user32" _
        (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer,
         ByVal X As Integer, ByVal Y As Integer,
         ByVal cX As Integer, ByVal cY As Integer,
         ByVal wFlags As Integer) As Integer
    '
    ' Constantes para usar con el API
    Const GWL_STYLE As Integer = (-16)
    Const WS_THICKFRAME As Integer = &H40000 ' Con borde redimensionable
    '
    Const SWP_DRAWFRAME As Integer = &H20
    Const SWP_NOMOVE As Integer = &H2
    Const SWP_NOSIZE As Integer = &H1
    Const SWP_NOZORDER As Integer = &H4

    Private Sub AsignarEventos(ByVal elControl As Control)
        Dim ctrl As Control
        ' 
        For Each ctrl In elControl.Controls
            ' No asignar estos evento al botón salir
            If ctrl.Name = "Panel1" OrElse ctrl.Name = "PictureBox1" Then
                ' Curiosamente un control GroupBox en apariencia
                ' no tiene estos eventos, pero... se le asigna y...
                ' ¡funciona!
                AddHandler ctrl.MouseDown, AddressOf Me.Control_MouseDown
                AddHandler ctrl.MouseMove, AddressOf Me.Control_MouseMove

                AsignarEventos(ctrl)
            End If
        Next
    End Sub

    Private Sub Control_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        ' Cuando se pulsa con el ratón
        DX = e.X
        DY = e.Y
        ' Al pulsar con el botón derecho, 
        ' cambiar el estilo entre redimensionable y normal
        If e.Button = MouseButtons.Right Then
            CambiarEstilo(CType(sender, Control))
        Else
            ' Cuando se pulsa en un control, posicionarlo encima del resto
            CType(sender, Control).BringToFront()
        End If
    End Sub

    Private Sub Control_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        ' Cuando se mueve el ratón y se pulsa el botón izquierdo... mover el control
        If e.Button = MouseButtons.Left Then
            CType(sender, Control).Left = e.X + CType(sender, Control).Left - DX
            CType(sender, Control).Top = e.Y + CType(sender, Control).Top - DY
        End If
    End Sub

    Private Sub CambiarEstilo(ByVal aControl As Control)
        ' Hacer este control redimensionable, usando el API
        ' Pone o quita el estilo dimensionable
        Dim Style As Integer
        '
        ' Si se produce un error, no hacer nada...
        Try
            Style = GetWindowLong(aControl.Handle.ToInt32, GWL_STYLE)
            If (Style And WS_THICKFRAME) = WS_THICKFRAME Then
                ' Si ya lo tiene, lo quita
                Style = Style Xor WS_THICKFRAME
            Else
                ' Si no lo tiene, lo pone
                Style = Style Or WS_THICKFRAME
            End If
            SetWindowLong(aControl.Handle.ToInt32, GWL_STYLE, Style)
            SetWindowPos(aControl.Handle.ToInt32, Me.Handle.ToInt32, 0, 0, 0, 0, SWP_NOZORDER Or SWP_NOSIZE Or SWP_NOMOVE Or SWP_DRAWFRAME)
        Catch 'e As Exception
            'MsgBox("El control " & queControl.Name & " no permite que se redimensione", MsgBoxStyle.Information)
            'Exit Sub
        End Try
    End Sub

End Class
