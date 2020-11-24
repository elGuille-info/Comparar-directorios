'------------------------------------------------------------------------------
' Mostrar 2 paneles con ficheros                                    (19/Nov/20)
'
' App.config:   jueves, ‎19‎ de ‎noviembre‎ de ‎2020, ‏‎20:27:35
' Form1.vb:     viernes, ‎20‎ de ‎noviembre‎ de ‎2020, ‏‎04:05:12
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

    Private EscudoOK As Image '= LabelInfo.Image
    Private EscudoExclamation As Image '= picAdmin.Image

    ''' <summary>
    ''' El índice del editor a usar de la colección EditoresTexto
    ''' para editar (F4)
    ''' </summary>
    Friend EditorTextoIndex As Integer = 0 ' TextPad

    ''' <summary>
    ''' Lista de editores de texto
    ''' </summary>
    ''' <returns></returns>
    Friend ReadOnly Property EditoresTexto As New HashSet(Of String)

    ''' <summary>
    ''' Si se avisa de lo que se va a actualizar
    ''' </summary>
    Private avisarAlActualizar As Boolean = True

    ''' <summary>
    ''' Avisar si se pulsa en actualizar estando activo el panel derecho
    ''' </summary>
    Private avisarActualizarEnIzquierdo As Boolean = True

    ''' <summary>
    ''' Si se debe preguntar al iniciar la aplicación si se comparan los directorios
    ''' </summary>
    Private preguntarAlIniciar As Boolean = True

    ''' <summary>
    ''' Si se debe comparar los directorios al iniciar
    ''' </summary>
    Private compararAlIniciar As Boolean = True

    ''' <summary>
    ''' El Directorio donde se guarda la configuración
    ''' </summary>
    Private dirConfiguracion As String

    ''' <summary>
    ''' El nombre del fichero de configuración global
    ''' </summary>
    Private ficheroConfiguracion As String

    ''' <summary>
    ''' La extensión a usar en los ficheros de configuración
    ''' </summary>
    Friend Const ExtensionConfiguracion As String = ".config.txt"

    ''' <summary>
    ''' El prefijo de los ficheros de configuración
    ''' </summary>
    Friend Property PrefijoConfig As String = "CompararDirectorios"

    ''' <summary>
    ''' Colección con los últimos directorios mostrados
    ''' en ambos paneles
    ''' </summary>
    ''' <remarks>
    ''' Se supone que HashSet mejora la comprobación con Contains con respecto a List
    ''' </remarks>
    Friend ReadOnly Property UltimosDirs As New HashSet(Of String) ' List(Of String)

    ''' <summary>
    ''' El panel en el que se ha pulsado un fichero o directorio
    ''' </summary>
    Private quePanel As ListView

    ''' <summary>
    ''' Si se han comparado los ficheros
    ''' </summary>
    Private compararDirs As Boolean

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        EscudoOK = LabelInfo.Image
        EscudoExclamation = picAdmin.Image

        ' Los botones Nuevo y Eliminar están en ToolStripDropDownButton y ToolStripSplitButton
        ' (el que sean diferentes era para ver si alguno de ellos tenía botones
        ' pero ninguno en el diseñador lo muestra, pero si los puede tener
        ' solo que hay que añadirlos a la propiedad DropDown... y de forma manual)
        Me.BtnNuevoDropDown.DropDown = New ToolStripDropDown()
        Me.BtnNuevoDropDown.DropDown.Items.AddRange(New ToolStripItem() {btnNuevoFichero, BtnNuevoDir})

        BtnEliminarSplit.DropDown = New ToolStripDropDown()
        BtnEliminarSplit.DropDown.Items.AddRange(New ToolStripItem() {btnEliminar, btnEliminarDir})

        BtnCopiarSplit.DropDown = New ToolStripDropDown()
        BtnCopiarSplit.DropDown.Items.AddRange(New ToolStripItem() {btnCopiar, btnCopiarDir})

        BtnMoverSplit.DropDown = New ToolStripDropDown()
        BtnMoverSplit.DropDown.Items.AddRange(New ToolStripItem() {btnMover, btnMoverDir})
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lvDirDer.Items.Clear()
        lvDirIzq.Items.Clear()
        'LabelDirIzq.Text = ""
        'LabelDirDer.Text = ""

        LabelFechaHora.Text = Date.Now.ToString("dd.MMMyy HH:mm")

        TimerFechaHora.Interval = 10 * 1000
        TimerFechaHora.Enabled = True

        If EsAdministrador() Then
            picAdmin.Image = EscudoOK
            picAdmin.ToolTipText = "Ejecutando como administrador."
        Else
            picAdmin.Image = EscudoExclamation
            picAdmin.ToolTipText = "No estás ejecutando como administrador."
        End If

        Dim DirDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        dirConfiguracion = Path.Combine(DirDocumentos, Application.ProductName)
        If Not Directory.Exists(dirConfiguracion) Then
            Directory.CreateDirectory(dirConfiguracion)
        End If
        ficheroConfiguracion = Path.Combine(dirConfiguracion, Application.ProductName & ExtensionConfiguracion)


        ' Leer los datos de la configuración
        LeerConfig()

        CambiarTema()

        ' Asignar los ultimos directorios a los menús
        AsignarMenuUltimosDir(BtnAbrirDirIzqDropDown)
        AsignarMenuUltimosDir(BtnAbrirDirDerDropDown)

        Dim s = ""
        Dim diIzq = TryCast(lvDirIzq.Tag, DirectoryInfo)
        If diIzq IsNot Nothing Then s = $"{diIzq.FullName}"
        Dim diDer = TryCast(lvDirDer.Tag, DirectoryInfo)
        If diDer IsNot Nothing Then s &= $"{vbCrLf}y{vbCrLf}{diDer.FullName}"

        ' Si no hay directorios seleccionados
        If String.IsNullOrEmpty(s) Then
            Dim ret1 = ConfirmDialog.Show($"¡ATENCIÓN, no hay directorios seleccionados!{vbCrLf}{vbCrLf}" &
                                          $"Debes seleccionar un directorio para cada panel.{vbCrLf}{vbCrLf}" &
                                          "¿Quieres seleccionar el directorio del panel izquierdo y " &
                                          $"usar el directorio de 'Documentos' en el panel derecho?{vbCrLf}{vbCrLf}" &
                                          $"Pulsa NO, para seleccionar los directorios más tarde.{vbCrLf}{vbCrLf}" &
                                          "Si no hay directorios seleccionados en ambos paneles no se podrá hacer copias, etc.",
                                          "No hay directorios seleccionados",
                                          DialogConfirmButtons.YesNo,
                                          DialogConfirmIcon.Information)
            If ret1 = DialogConfirmResult.Yes Then
                AbrirCarpeta(lvDirIzq)
                lvDirDer.Tag = New DirectoryInfo(DirDocumentos)
                MostrarContenidoDirectorio(lvDirDer.Tag.ToString, lvDirDer)
            End If
            Return
        End If

        If preguntarAlIniciar Then
            Dim ret = ConfirmDialog.Show("¿Quieres comparar los dos directorios?:" & vbCrLf & vbCrLf &
                                         s,
                                         "Comparar directorios",
                                         DialogConfirmButtons.YesNo,
                                         DialogConfirmIcon.Information,
                                         textoOpcion:="Preguntar siempre al iniciar",
                                         valorOpcion:=True)
            If ret = DialogConfirmResult.Yes Then
                preguntarAlIniciar = ConfirmDialog.OpcionConfigurable.Value
                compararAlIniciar = True
                compararDirs = True
                CompararAlReleerMenu.Checked = compararDirs
            Else
                compararAlIniciar = False
            End If
        End If
        ' solo si compararDirs es true
        If compararDirs AndAlso compararAlIniciar Then
            CompararDirectorios()
        End If
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then

            If e.KeyCode = Keys.F1 Then
                ' Mostrar acerca de
                AcercaDe()

            ElseIf e.KeyCode = Keys.F2 Then
                ' YA NO - Se asigna en el evento KeyDown de los ListView
                e.Handled = True
                e.SuppressKeyPress = True
                EditarSubItem(quePanel, -2)

            ElseIf e.KeyCode = Keys.F3 Then
                ' ver
                ' inicialmente con el notepad
                VerFichero()
            ElseIf e.KeyCode = Keys.F4 Then
                ' Editar
                EditarFichero()
            ElseIf e.KeyCode = Keys.F5 Then
                CopiarTodosSeleccionados()
            ElseIf e.KeyCode = Keys.F6 Then
                MoverTodosSeleccionados()
            ElseIf e.KeyCode = Keys.F7 Then
                CrearDirectorio()
            ElseIf e.KeyCode = Keys.F8 Then
                EliminarTodosSeleccionados()
            ElseIf e.KeyCode = Keys.F9 Then
                ActualizarMasRecientes()
            End If
        Else
            If e.Control Then
                If e.KeyCode = Keys.N Then
                    NuevoFichero()
                End If
            ElseIf e.Alt Then
                If e.KeyCode = Keys.C Then
                    ' Comparar los directorios
                    CompararDirectorios()
                ElseIf e.KeyCode = Keys.R Then
                    ' Releer los directorios
                    Releer()
                End If
            End If
        End If
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        'LabelDirIzq.Width = ToolStripIzq.Width - (BtnAbrirDirIzqDropDown.Width + btnAbrirDirIzq.Width + 24)
        'LabelDirDer.Width = ToolStripDer.Width - (BtnAbrirDirDerDropDown.Width + btnAbrirDirDer.Width + 24)

        MostrarInfo()

        If lvDirIzq.Tag IsNot Nothing Then
            MostrarNombreDirectorio(lvDirIzq.Tag.ToString, lvDirIzq)
        End If
        If lvDirDer.Tag IsNot Nothing Then
            MostrarNombreDirectorio(lvDirDer.Tag.ToString, lvDirDer)
        End If
    End Sub

    '
    ' Métodos 
    '

    ''' <summary>
    ''' Copiar los ficheros y directorios seleccionados
    ''' </summary>
    Private Sub CopiarTodosSeleccionados()
        If quePanel.SelectedIndices.Count = 0 Then
            LabelInfo.Text = "No hay directorios ni ficheros seleccionados para copiar."
            BtnCopiarSplit.HideDropDown()
            Return
        End If

        CopiarFicheros()
        CopiarDirectorios()
    End Sub

    ''' <summary>
    ''' Mover los ficheros y directorios seleccionados
    ''' </summary>
    Private Sub MoverTodosSeleccionados()
        If quePanel.SelectedIndices.Count = 0 Then
            LabelInfo.Text = "No hay directorios ni ficheros seleccionados para mover."
            BtnMoverSplit.HideDropDown()
            Return
        End If

        If ConfirmDialog.Show("¿Seguro que quieres mover todos los directorios y ficheros seleccionados?" & vbCrLf & vbCrLf &
                              "Si eliges SI, se preguntará individualmente si quieres mover el directorio o el fichero.",
                              "Mover todo",
                              DialogConfirmButtons.NoYes,
                              DialogConfirmIcon.Error) = DialogConfirmResult.Yes Then
            MoverFicheros()
            MoverDirectorios()
        End If
    End Sub

    ''' <summary>
    ''' Eliminar los ficheros y directorios seleccionados
    ''' </summary>
    Private Sub EliminarTodosSeleccionados()
        If quePanel.SelectedIndices.Count = 0 Then
            LabelInfo.Text = "No hay directorios ni ficheros seleccionados para eliminar."
            BtnEliminarSplit.HideDropDown()
            Return
        End If

        If ConfirmDialog.Show("¿Seguro que quieres eliminar todos los directorios y ficheros seleccionados?" & vbCrLf & vbCrLf &
                              "Si eliges SI, se preguntará individualmente si quieres eliminar el directorio o el fichero.",
                              "Eliminar todo",
                              DialogConfirmButtons.NoYes,
                              DialogConfirmIcon.Error) = DialogConfirmResult.Yes Then
            EliminarFicheros()
            EliminarDirectorios()
        End If
    End Sub

    ''' <summary>
    ''' Comprobar si se ejecuta como administrador
    ''' </summary>
    ''' <returns></returns>
    Private Function EsAdministrador() As Boolean
        ' Código adaptado de un ejemplo de C#:
        ' https://stackoverflow.com/a/3600338/14338047
        Using identity = System.Security.Principal.WindowsIdentity.GetCurrent()
            Dim principal As New System.Security.Principal.WindowsPrincipal(identity)
            Return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator)
        End Using

        ' Este código (usando My.User) lo tenía de antes,
        ' pero no recuerdo de dónde lo saqué
        'My.User.InitializeWithWindowsUser()
        'Return My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator)

        '' Si se está ejecutando desde el IDE de Visual Studio
        ''If System.Diagnostics.Debugger.IsAttached Then
        ''    Return True
        ''Else
        ''    Return My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator)
        ''End If
    End Function


    Private Sub IrParentDir(lv As ListView)
        If lv.SelectedItems.Count = 0 Then Return

        ' Comprobar si es un elemento con directorio
        ' ir a ese directorio
        Dim di = TryCast(lv.SelectedItems(0).Tag, DirectoryInfo)
        If di IsNot Nothing Then
            Dim sDir = di.FullName
            If Not String.IsNullOrEmpty(sDir) Then
                MostrarContenidoDirectorio(sDir, lv)
                If compararDirs Then
                    CompararDirectorios()
                End If
            End If
            Return
        End If

        ' Será un fichero
        Dim fi = TryCast(lv.SelectedItems(0).Tag, FileInfo)
        If fi Is Nothing Then Return

        ' Si es uno de los ficheros soportados por el visor
        ' abrilo directamente, si no, preguntar
        Dim ext = fi.Extension.ToLower()
        If visorTexto.ExtensionesVisor.Contains(ext) Then
            Dim fVisor As New visorTexto(fi.FullName)
            fVisor.Show()
            Return
        End If

        ' Abrirlo con el programa asociado
        Dim res = ConfirmDialog.Show($"¿Quieres abrir el fichero:{vbCrLf}{fi.Name}{vbCrLf}" &
                                     $"{If(fi.Extension.ToLower().Contains("exe"),
                                        "(Es un ejecutable)",
                                        "con el programa que tenga asociado")}?{vbCrLf}{vbCrLf}" &
                                     $"Pulsa NO para mostrarlo en el visor.{vbCrLf}" &
                                     $"Pulsa Cancelar para no mostrarlo ni abrirlo.",
                              "Abrir fichero",
                              DialogConfirmButtons.YesNoCancel,
                              DialogConfirmIcon.Information)
        If res = DialogConfirmResult.Yes Then
            AbrirFicheroProcess(fi.FullName)
        ElseIf res = DialogConfirmResult.Cancel Then
            Return
        Else
            Dim fVisor As New visorTexto(fi.FullName)
            fVisor.Show()
        End If

    End Sub

    Private Sub AbrirFicheroProcess(fic As String)
        ' Si es un ejecutable, usar process
        Dim pi As New ProcessStartInfo With
            {.FileName = fic, .UseShellExecute = True, .WindowStyle = ProcessWindowStyle.Normal}
        Dim p As New Process With {.StartInfo = pi}

        Try
            ' Intentar ejecutarlo
            p.Start()

        Catch ex As Exception
            ' Si da error, mostrarlo en el visor
            Dim fVisor As New visorTexto(fic)
            fVisor.Show()
        End Try
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
        If compararDirs Then
            CompararDirectorios()
        End If
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
        If compararDirs Then
            CompararDirectorios()
        End If
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

            LabelInfo.Text = $"Copiando {di.Name} a {diDest.Name}..."
            Application.DoEvents()

            ' Copiar cada directorio y ficheros del directorio de origen en el destino
            ' primero copiar los ficheros
            Dim files = di.GetFiles
            CopiarFiles2Dir(files, dDest)

            ' a coninuación los directorios y sus ficheros, etc.
            ' hay que hacerlo recursivo
            Dim dirs = di.GetDirectories
            CopiarDirs2Dir(dirs, dDest)
        Next

        LabelInfo.Text = "Fin de la copia de directorios."
        Application.DoEvents()

        ' Releer los dos directorios
        Releer()
    End Sub

    ''' <summary>
    ''' Copiar recursivamente los directorios de origen a destino
    ''' </summary>
    ''' <param name="dirs">Array de tipo DirectoryInfo con los directorios a del origen</param>
    ''' <param name="dDest">Directorio de destino, si no existe se creará</param>
    Private Sub CopiarDirs2Dir(dirs As DirectoryInfo(), dDest As String)
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
            CopiarFiles2Dir(files, dDest2)

            ' comprobar si hay más directorios
            ' y copiarlos recursivamente
            Dim dirs2 = di.GetDirectories
            CopiarDirs2Dir(dirs2, dDest2)
        Next
    End Sub

    ''' <summary>
    ''' Copiar los ficheros indicados en el directorio de destino.
    ''' </summary>
    ''' <param name="files">Array del tipo FileInfo con los ficheros de origen a copiar</param>
    ''' <param name="dDest">Directorio de destino, si no existe se creará</param>
    Private Sub CopiarFiles2Dir(files As FileInfo(), dDest As String)
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
                LabelInfo.Text = $"Moviendo {di.Name} a {diDest.Name}..."
                Application.DoEvents()

                ' Antes de moverlo, hay que eliminar el de destino
                ' pero debe estar vacío
                If Directory.Exists(dDest) Then
                    LabelInfo.Text = $"Eliminando el directorio {di.Name}..."
                    Application.DoEvents()

                    EliminarContenidoDir(dDest)
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

        LabelInfo.Text = "Fin de mover directorios."
        Application.DoEvents()

        ' Releer los dos directorios
        Releer()

    End Sub

    ''' <summary>
    ''' Eliminar todo el contenido de un directorio
    ''' </summary>
    ''' <param name="sDir">El nombre del directorio a eliminar</param>
    Private Sub EliminarContenidoDir(sDir As String)
        Dim di = New DirectoryInfo(sDir)
        ' eliminar los ficheros
        Dim files = di.GetFiles
        For i = files.Length - 1 To 0 Step -1
            files(i).Delete()
        Next
        Dim dirs = di.GetDirectories
        For i = dirs.Length - 1 To 0 Step -1
            EliminarContenidoDir(dirs(i).FullName)
        Next
    End Sub

    ''' <summary>
    ''' Eliminar los directorios seleccionados en el panel activo
    ''' </summary>
    Private Sub EliminarDirectorios()
        ' Si no está asignado el panel activo, salir
        If quePanel Is Nothing Then Return
        ' Si no hay nada seleccionado en el panel activo, salir
        If quePanel.SelectedIndices.Count = 0 Then Return

        Dim diDest = TryCast(quePanel.Tag, DirectoryInfo)
        If diDest Is Nothing Then Return

        Dim eliminarTodos = False

        For i = quePanel.SelectedIndices.Count - 1 To 0 Step -1
            ' El directorio (DirectoryInfo) seleccionado
            Dim di = TryCast(quePanel.Items(quePanel.SelectedIndices(i)).Tag, DirectoryInfo)
            ' Si no es un directorio, continuar
            If di Is Nothing Then Continue For

            ' Confirmar solo si existe
            If di.Exists Then
                Dim s = $"¿Quieres eliminar el directorio {di.Name}{vbCrLf}{vbCrLf} de {di.FullName}?"
                Dim sTit = "Eliminar directorio"

                Dim ret As DialogConfirmResult

                ' Si se debe volver a mostrar el diálogo de confirmación
                If Not eliminarTodos Then
                    ret = ConfirmDialog.Show(s, sTit, DialogConfirmButtons.All, DialogConfirmIcon.Warning)
                    If ret = DialogConfirmResult.NoToAll Then
                        Return
                    ElseIf ret = DialogConfirmResult.No Then
                        Continue For
                    ElseIf ret = DialogConfirmResult.YesToAll Then
                        eliminarTodos = True
                    End If
                End If

                Try
                    ' El directorio debe estar vacío antes de eliminarlo
                    'Dim dDest2 = di.FullName
                    LabelInfo.Text = $"Eliminando {di.Name}..."
                    Application.DoEvents()

                    EliminarContenidoDir(di.FullName)
                    If di.Exists Then
                        di.Delete()
                    End If
                Catch ex As Exception
                    LabelInfo.Text = ex.Message
                    Continue For
                End Try
            End If

        Next

        LabelInfo.Text = "Fin de eliminar directorios."
        Application.DoEvents()

        ' Releer el directorio
        MostrarContenidoDirectorio(quePanel.Tag.ToString, quePanel)
        If compararDirs Then
            CompararDirectorios()
        End If
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

        '' Actualizar las listas de directorios
        '' Aunque se añade en MostrarContenidoDirectorio
        '' añadirlo aquí y reasignar las listas
        'If UltimosDirs.Contains(fb.SelectedPath) = False Then
        '    UltimosDirs.Add(fb.SelectedPath)
        '    ' Ajustar el menú de la lista de últimos directorios
        '    ' Asignar los ultimos directorios a los menús
        '    AsignarMenuUltimosDir(BtnAbrirDirIzqDropDown)
        '    AsignarMenuUltimosDir(BtnAbrirDirDerDropDown)
        'End If

        MostrarContenidoDirectorio(fb.SelectedPath, lv)

        If compararDirs Then
            CompararDirectorios()
        End If
    End Sub

    ''' <summary>
    ''' Guardar los datos de configuración:
    '''     Nombre del directorio de cada panel,
    '''     Los últimos directorios mostrados en ambos paneles
    ''' </summary>
    ''' <param name="sDir">Cadena con el nombre del directorio</param>
    ''' <param name="lv">ListView donde se muestra el contenido del directorio</param>
    Private Sub GuardarConfig(sDir As String, lv As ListView)
        Dim cfg = New Config(ficheroConfiguracion)

        cfg.SetValue("Opciones", "CompararDirs", compararDirs)
        cfg.SetValue("Opciones", "PreguntarAlIniciar", preguntarAlIniciar)
        cfg.SetValue("Opciones", "CompararAlIniciar", compararAlIniciar)
        cfg.SetValue("Opciones", "AvisarActualizarEnIzquierdo", avisarActualizarEnIzquierdo)
        cfg.SetValue("Opciones", "AvisarAlActualizar", avisarAlActualizar)

        cfg.SetValue("Opciones", "TemaActual", TemaActual)

        Dim s As String
        Dim cuantos As Integer
        cuantos = EditoresTexto.Count
        cfg.SetKeyValue("Editores texto", "Count", cuantos)
        For i = 0 To cuantos - 1
            s = EditoresTexto(i)
            If s.Any Then
                cfg.SetKeyValue("Editores texto", $"Editor {i}", s)
            End If
        Next

        Dim ficCfg As String

        ' Guardar todos los directorios abiertos
        ficCfg = Path.Combine(dirConfiguracion, $"{PrefijoConfig}_UltimosDirectorios{ExtensionConfiguracion}")
        Using sw As New StreamWriter(ficCfg, False, Encoding.Default)
            For Each s In UltimosDirs
                If s.Any Then
                    sw.WriteLine(s)
                End If
            Next
            sw.Flush()
            sw.Close()
        End Using

        ' Guardar el nombre del directorio abierto
        If lv Is lvDirIzq Then
            ficCfg = Path.Combine(dirConfiguracion, $"{PrefijoConfig}_Izq{ExtensionConfiguracion}")
        Else
            ficCfg = Path.Combine(dirConfiguracion, $"{PrefijoConfig}_Der{ExtensionConfiguracion}")
        End If
        Using sw As New StreamWriter(ficCfg, False, Encoding.Default)
            sw.Write(sDir)
            sw.Flush()
            sw.Close()
        End Using

        cfg.Save()
    End Sub

    ''' <summary>
    ''' Leer la configuración con los nombres de los dos directorios usados
    ''' y la lista de los últimos directorios
    ''' </summary>
    Private Sub LeerConfig()
        Dim cfg = New Config(ficheroConfiguracion)

        compararDirs = cfg.GetValue("Opciones", "CompararDirs", False)
        CompararAlReleerMenu.Checked = compararDirs
        preguntarAlIniciar = cfg.GetValue("Opciones", "PreguntarAlIniciar", True)
        compararAlIniciar = cfg.GetValue("Opciones", "CompararAlIniciar", True)
        avisarActualizarEnIzquierdo = cfg.GetValue("Opciones", "AvisarActualizarEnIzquierdo", True)
        avisarAlActualizar = cfg.GetValue("Opciones", "AvisarAlActualizar", True)
        TemaActual = CType(cfg.GetValue("Opciones", "TemaActual", Temas.Predeterminado), Temas)

        Dim s As String
        Dim cuantos As Integer
        cuantos = cfg.GetValue("Editores texto", "Count", 3)
        If cuantos = 0 Then
            s = "E:\ISOs guilleAcer5930\Instalar (registrados)\TextPad\TextPad portable\TextPad.exe"
            EditoresTexto.Add(s)
            s = "E:\gsCodigo_00\VS2008\gsEditor 2008\gsEditor2008\bin\gsEditor2008.exe"
            EditoresTexto.Add(s)
            s = "E:\gsCodigo_00\Visual Studio\net core\gsEvaluarColorearCodigoNET\gsEvaluarColorearCodigoNET vb\bin\Debug\net5.0-windows\gsEvaluarColorearCodigoNET.exe"
            EditoresTexto.Add(s)
        Else
            For i = 0 To cuantos - 1
                s = cfg.GetValue("Editores texto", $"Editor {i}", "")
                If s.Any AndAlso EditoresTexto.Contains(s) = False Then
                    EditoresTexto.Add(s)
                End If
            Next
        End If

        Dim ficCfg As String

        ' Leer los últimos directorios abiertos
        ' Leerlos antes de mostrar directorios, si no, los sobrescribe
        UltimosDirs.Clear()
        ficCfg = Path.Combine(dirConfiguracion, $"{PrefijoConfig}_UltimosDirectorios{ExtensionConfiguracion}")
        If File.Exists(ficCfg) Then
            Using sr As New StreamReader(ficCfg, Encoding.Default, True)
                Do While Not sr.EndOfStream
                    s = sr.ReadLine
                    If s.Any Then
                        UltimosDirs.Add(s)
                    End If
                Loop
                sr.Close()
            End Using
        End If

        ficCfg = Path.Combine(dirConfiguracion, $"{PrefijoConfig}_Izq{ExtensionConfiguracion}")
        Dim dIzq As String
        If File.Exists(ficCfg) Then
            Using sr As New StreamReader(ficCfg, Encoding.Default, True)
                dIzq = sr.ReadLine
                sr.Close()
            End Using

            ' Mostrar los ficheros en el panel izquierdo
            MostrarContenidoDirectorio(dIzq, lvDirIzq)
        End If

        ficCfg = Path.Combine(dirConfiguracion, $"{PrefijoConfig}_Der{ExtensionConfiguracion}")
        If File.Exists(ficCfg) Then
            Using sr As New StreamReader(ficCfg, Encoding.Default, True)
                dIzq = sr.ReadLine
                sr.Close()
            End Using

            ' Mostrar los ficheros en el panel derecho
            MostrarContenidoDirectorio(dIzq, lvDirDer)
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
            CboDirIzq.Text = dir.FullName

            'Dim s = dir.FullName
            '' El ancho predeterminado es 384 y 70 caracteres
            'Dim maxLeng = CInt(LabelDirIzq.Width / 5.6)
            'If s.Length > maxLeng Then
            '    s = s.Substring(0, 10) & "..." & s.Substring(s.Length - (maxLeng - 14))
            'End If
            'LabelDirIzq.Text = s ' dir.Name 'dir.FullName
            'LabelDirIzq.ToolTipText = dir.FullName
        Else
            CboDirDer.Text = dir.FullName

            'Dim s = dir.FullName
            'Dim maxLeng = CInt(LabelDirIzq.Width / 5.6)
            'If s.Length > maxLeng Then
            '    s = s.Substring(0, 10) & "..." & s.Substring(s.Length - (maxLeng - 14))
            'End If
            'LabelDirDer.Text = s ' dir.Name 'dir.FullName
            'LabelDirDer.ToolTipText = dir.FullName
        End If

        ' Comprobar si los dos directorios son iguales
        ' de ser así, avisar
        Dim diIzq = TryCast(lvDirIzq.Tag, DirectoryInfo)
        Dim diDer = TryCast(lvDirDer.Tag, DirectoryInfo)
        If diIzq Is Nothing OrElse diDer Is Nothing Then
            Return
        End If
        If diIzq.FullName = diDer.FullName Then
            ConfirmDialog.Show("¡Atención los paneles usan el mismo directorio!" & vbCrLf & vbCrLf &
                               "Deberían ser directorios diferentes.",
                               "Mismo directorio en los 2 paneles",
                               DialogConfirmButtons.OK,
                               DialogConfirmIcon.Information)
            LabelInfo.BackColor = ItemNoExiste(TemaActual) ' Color.Firebrick
            LabelInfo.ForeColor = VentanaFondo(TemaActual) ' Color.White
        Else
            LabelInfo.BackColor = StatusFondo(TemaActual) ' Color.FromKnownColor(KnownColor.Control)
            LabelInfo.ForeColor = StatusTexto(TemaActual) ' Color.FromKnownColor(KnownColor.WindowText)
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
            it.SubItems.Add(dir.Parent.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss"))
            AsignarTema(it, ItemDirBack, ItemDirFore)
            'it.ForeColor = ItemDirFore(TemaActual) ' Color.DarkOliveGreen
            'it.BackColor = ItemDirBack(TemaActual) ' Color.LightGoldenrodYellow
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
            AsignarTema(it, ItemDirBack, ItemDirFore)
            it.Checked = False
            it.Tag = di '.FullName
            it.ToolTipText = di.FullName
            'it.Font = New Font(it.Font, FontStyle.Bold)
        Next
        For Each fi In files
            Dim it = lv.Items.Add("")
            If visorTexto.ExtensionesVisor.Contains(fi.Extension) Then
                it.ForeColor = ItemVisor(TemaActual)
            ElseIf ExtensionesBin.Contains(fi.Extension) Then
                it.ForeColor = ItemBin(TemaActual)
            Else
                'AsignarTema(it, PanelFondo, ItemIgual)
                it.ForeColor = ItemIgual(TemaActual)
            End If

            it.SubItems.Add(fi.Name)
            it.SubItems.Add(fi.Length.ToString("#,##0"))
            it.SubItems.Add(fi.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss"))
            it.Checked = False
            it.Tag = fi
        Next

        ' Guardar el directorio usado actualmente
        ' y añadirlo a la lista de últimos directorios (si no está ya)

        ' Si ya existe, borrarlo para que se añada al principio
        If UltimosDirs.Contains(sDir) Then
            UltimosDirs.Remove(sDir)
        End If

        ' Añadirlo al principio de la lista
        ' no hace falta comprobar si existe porque ya se ha comprobado arriba ;-)

        ' Crear una colección temporal y copiar los datos en otra colección
        Dim colTmp As New HashSet(Of String)
        For i = 0 To UltimosDirs.Count - 1
            colTmp.Add(UltimosDirs(i))
        Next
        ' Eliminar los de UltimosDir
        UltimosDirs.Clear()
        ' Añadir el último directorio navegado
        UltimosDirs.Add(sDir)
        ' Añadir lo que había antes
        For i = 0 To colTmp.Count - 1
            UltimosDirs.Add(colTmp(i))
        Next
        ' Eliminar el contenido de la colección temporal
        colTmp.Clear()

        ' Ajustar el menú de la lista de últimos directorios
        ' Asignar los ultimos directorios a los menús
        If lv Is lvDirIzq Then
            AsignarMenuUltimosDir(BtnAbrirDirIzqDropDown)
        Else
            AsignarMenuUltimosDir(BtnAbrirDirDerDropDown)
        End If

        ' Guardar la información del directorio actual y los últimos abiertos
        GuardarConfig(sDir, lv)

        'If comparado Then
        '    CompararDirectorios()
        'End If
    End Sub

    ''' <summary>
    ''' Comparar el contenido de los ficheros de los dos directorios mostrados.
    ''' Devuelve el número de ficheros con fecha más reciente.
    ''' </summary>
    ''' <returns>Devuelve una tupla con:
    ''' el número de ficheros más recientes,
    ''' los que no existen y los de tamaño diferente
    ''' o -1 si no se ha procesado</returns>
    Private Function CompararDirectorios() As (FechaMasReciente As Integer, NoExisten As Integer, TamañoDiferente As Integer)
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
        If diIzq Is Nothing Then Return (-1, -1, -1)
        Dim diDer = TryCast(lvDirDer.Tag, DirectoryInfo)
        If diDer Is Nothing Then Return (-1, -1, -1)

        LabelInfo.Text = "Comparando los directorios..."
        Application.DoEvents()

        Dim t = 0
        Dim tf = 0
        Dim tn = 0
        Dim ttma = 0
        Dim ttme = 0
        Dim tfma = 0
        Dim tfme = 0
        Dim ti = 0

        ' Ponerlos todos como que no existen
        ' ya que esto no se puede hacer en el otro bucle
        ' porque si no existe en la derecha nunca llega a ese item
        For j = 0 To lvDirDer.Items.Count - 1
            Dim itDer = lvDirDer.Items(j)
            If String.IsNullOrEmpty(itDer.Text) Then
                itDer.Text = "x"
                itDer.ForeColor = ItemNoExiste(TemaActual) ' Color.Firebrick
                itDer.ToolTipText = "No existe"
            End If
        Next

        For i = 0 To lvDirIzq.Items.Count - 1
            Dim itIzq = lvDirIzq.Items(i)
            Dim fiIzq = TryCast(itIzq.Tag, FileInfo)
            If fiIzq Is Nothing Then Continue For

            ' Asignar el color del texto predeterminado
            ' pero comprobando si es una de las extensiones indicadas

            If visorTexto.ExtensionesVisor.Contains(fiIzq.Extension) Then
                itIzq.ForeColor = ItemVisor(TemaActual)
            ElseIf ExtensionesBin.Contains(fiIzq.Extension) Then
                itIzq.ForeColor = ItemBin(TemaActual)
            Else
                itIzq.ForeColor = ItemIgual(TemaActual)
            End If

            tf += 1
            Dim fiDer As FileInfo
            Dim existe As Boolean = False
            For j = 0 To lvDirDer.Items.Count - 1
                fiDer = TryCast(lvDirDer.Items(j).Tag, FileInfo)
                If fiDer Is Nothing Then Continue For

                Dim itDer = lvDirDer.Items(j)

                ' Asignar el color del texto predeterminado
                ' pero comprobando si es una de las extensiones indicadas
                If visorTexto.ExtensionesVisor.Contains(fiIzq.Extension) Then
                    itDer.ForeColor = ItemVisor(TemaActual)
                ElseIf ExtensionesBin.Contains(fiDer.Extension) Then
                    itDer.ForeColor = ItemBin(TemaActual)
                Else
                    itDer.ForeColor = ItemIgual(TemaActual)
                End If

                If fiIzq.Name = fiDer.Name Then
                    existe = True
                    t += 1
                    itIzq.Text = "="
                    itIzq.ToolTipText = "Son iguales"
                    itDer.Text = "="
                    itDer.ToolTipText = "Son iguales"
                    'itDer.ForeColor = PanelTexto(TemaActual) ' Color.FromKnownColor(KnownColor.WindowText)
                    If fiIzq.LastWriteTime.ToString("yyyy/MM/dd HH:mm") > fiDer.LastWriteTime.ToString("yyyy/MM/dd HH:mm") Then
                        itIzq.Text = "f>"
                        itIzq.ForeColor = ItemFechaMayor(TemaActual) ' Color.Blue
                        itIzq.ToolTipText = "La fecha es mayor"
                        ' Lo contrario en el otro directorio
                        itDer.Text = "f<"
                        itDer.ForeColor = ItemFechaMenor(TemaActual) ' Color.SlateBlue
                        itDer.ToolTipText = "La fecha es menor"

                        tfma += 1
                        ti += 1
                    ElseIf fiIzq.LastWriteTime.ToString("yyyy/MM/dd HH:mm") < fiDer.LastWriteTime.ToString("yyyy/MM/dd HH:mm") Then
                        itIzq.Text = "f<"
                        itIzq.ForeColor = ItemFechaMenor(TemaActual) ' Color.SlateBlue
                        itIzq.ToolTipText = "La fecha es menor"
                        '
                        itDer.Text = "f>"
                        itDer.ForeColor = ItemFechaMayor(TemaActual) 'Color.Blue
                        itDer.ToolTipText = "La fecha es mayor"

                        tfme += 1
                        ti += 1
                    ElseIf fiIzq.Length > fiDer.Length Then
                        itIzq.ForeColor = ItemTamañoMayor(TemaActual) ' Color.Green
                        itIzq.Text = "t>"
                        itIzq.ToolTipText = "El tamaño es mayor"
                        '
                        itDer.ForeColor = ItemTamañoMenor(TemaActual) ' Color.DarkGreen
                        itDer.Text = "t<"
                        itDer.ToolTipText = "El tamaño es menor"

                        ttma += 1
                        ti += 1
                    ElseIf fiIzq.Length < fiDer.Length Then
                        itIzq.ForeColor = ItemTamañoMenor(TemaActual) 'Color.DarkGreen
                        itIzq.Text = "t<"
                        itIzq.ToolTipText = "El tamaño es menor"
                        '
                        itDer.ForeColor = ItemTamañoMayor(TemaActual) 'Color.Green
                        itDer.Text = "t>"
                        itDer.ToolTipText = "El tamaño es mayor"

                        ttme += 1
                        ti += 1
                    End If
                    Exit For
                End If
            Next
            If Not existe Then
                itIzq.ForeColor = ItemNoExiste(TemaActual) ' Color.Firebrick
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

        Return (tfma, tn, ttma + ttme)
    End Function

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
                LabelInfo.Text = $"Copiando {fi.Name} a {diDest.Name}..."
                Application.DoEvents()

                File.Copy(fi.FullName, fDest, True)
            Catch ex As Exception
                LabelInfo.Text = ex.Message
                Return
            End Try
        Next

        LabelInfo.Text = "Fin de la copia de ficheros."
        Application.DoEvents()

        ' Releer los directorios
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
                LabelInfo.Text = $"Moviendo {fi.Name} a {diDest.Name}..."
                Application.DoEvents()

                ' Antes de moverlo, hay que eliminar el de destino
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

        LabelInfo.Text = "Fin de mover ficheros."
        Application.DoEvents()

        ' Releer los dos directorios
        Releer()

    End Sub

    ''' <summary>
    ''' Eliminar el fichero seleccionado en el panel activo
    ''' </summary>
    Private Sub EliminarFicheros()
        ' Si no está asignado el panel activo, salir
        If quePanel Is Nothing Then Return
        ' Si no hay fichero seleccionado en el panel activo, salir
        If quePanel.SelectedIndices.Count = 0 Then Return

        Dim eliminarTodos = False

        ' Eliminar todos los ficheros seleccionados
        For i = 0 To quePanel.SelectedIndices.Count - 1
            ' El fichero (FileInfo) seleccionado
            Dim fi = TryCast(quePanel.Items(quePanel.SelectedIndices(i)).Tag, FileInfo)
            ' Si no es un fichero, continuar
            If fi Is Nothing Then Continue For

            ' Confirmar solo si existe
            If fi.Exists Then
                Dim s = $"¿Quieres eliminar el fichero{vbCrLf}{vbCrLf}{fi.FullName}?"
                Dim sTit = "Eliminar fichero"

                Dim ret As DialogConfirmResult

                ' Si se debe volver a mostrar el diálogo de confirmación
                If Not eliminarTodos Then
                    ret = ConfirmDialog.Show(s, sTit, DialogConfirmButtons.All, DialogConfirmIcon.Warning)
                    If ret = DialogConfirmResult.NoToAll Then
                        Return
                    ElseIf ret = DialogConfirmResult.No Then
                        Continue For
                    ElseIf ret = DialogConfirmResult.YesToAll Then
                        eliminarTodos = True
                    End If
                End If

                Try
                    LabelInfo.Text = $"Eliminando {fi.Name}..."
                    Application.DoEvents()

                    fi.Delete()
                Catch ex As Exception
                    LabelInfo.Text = ex.Message
                    Continue For
                End Try
            End If

        Next

        LabelInfo.Text = "Fin de eliminar ficheros."
        Application.DoEvents()

        ' Releer el directorio
        MostrarContenidoDirectorio(quePanel.Tag.ToString, quePanel)
        If compararDirs Then
            CompararDirectorios()
        End If
    End Sub

    ''' <summary>
    ''' Releer el contenido de los dos directorios.
    ''' Cuando se relee no se comparan los directorios.
    ''' </summary>
    Private Sub Releer()
        If lvDirIzq.Tag Is Nothing OrElse lvDirDer.Tag Is Nothing Then Return

        MostrarContenidoDirectorio(lvDirIzq.Tag.ToString, lvDirIzq)
        MostrarContenidoDirectorio(lvDirDer.Tag.ToString, lvDirDer)

        If compararDirs Then
            CompararDirectorios()
        End If
    End Sub

    ''' <summary>
    ''' Mostrar el fichero seleccionado en Notepad (bloc de notas)
    ''' </summary>
    Private Sub VerFichero()
        If quePanel Is Nothing Then Return
        If quePanel.SelectedItems.Count = 0 Then Return

        Dim fi = TryCast(quePanel.SelectedItems(0).Tag, FileInfo)
        If fi Is Nothing Then Return

        Dim fVisor As New visorTexto(fi.FullName)
        fVisor.Show()

        'If quePanel Is Nothing Then Return
        'If quePanel.SelectedItems.Count = 0 Then Return
        'Dim fi = TryCast(quePanel.SelectedItems(0).Tag, FileInfo)
        'Dim pi As New ProcessStartInfo With {
        '    .FileName = "Notepad.exe",
        '    .Arguments = $"{ChrW(34)}{fi.FullName}{ChrW(34)}",
        '    .UseShellExecute = True,
        '    .WindowStyle = ProcessWindowStyle.Normal
        '}
        'Dim p As New Process With {
        '    .StartInfo = pi
        '}
        'p.Start()

        'MostrarContenidoDirectorio(quePanel.Tag.ToString, quePanel)
    End Sub

    ''' <summary>
    ''' Actualizar los ficheros más recientes del panel activo en el otro.
    ''' </summary>
    Private Sub ActualizarMasRecientes()
        ' Si no está asignado el panel activo, salir
        If quePanel Is Nothing Then Return

        ' Solo copiar del izquierdo al derecho
        If quePanel IsNot lvDirIzq AndAlso avisarActualizarEnIzquierdo Then
            Dim res = ConfirmDialog.Show("Solo se puede actualizar del panel izquierdo al derecho." & vbCrLf & vbCrLf &
                                         "¿Quieres actualizar los ficheros del panel izquierdo en el derecho?",
                                         "Actualizar más recientes",
                                         DialogConfirmButtons.YesNo,
                                         DialogConfirmIcon.Information,
                                         "No volver a mostrar este mensaje y actualizar",
                                         True)
            If res = DialogConfirmResult.Yes Then
                avisarActualizarEnIzquierdo = Not ConfirmDialog.OpcionConfigurable.Value
            Else
                Return
            End If
        End If

        'quePanel = lvDirIzq
        LvDirIzq_Enter(lvDirIzq, Nothing)

        ' Comparar los directorios
        ' Cuando lo ponga paa que compare cada panel por separado
        ' solo comparar el activo con el otro
        Releer()
        Dim tfm = CompararDirectorios()
        If tfm.FechaMasReciente = -1 Then Return

        Dim lvDest As ListView
        If quePanel Is lvDirIzq Then
            lvDest = lvDirDer
        Else
            lvDest = lvDirIzq
        End If
        Dim dDest = lvDest.Tag.ToString

        Dim sTotales As String = ""
        Dim sInicio As String = ""
        Dim sTamaño As String = ""

        If tfm.FechaMasReciente = 1 Then
            sTotales = $"un fichero más reciente "
            sInicio = "un fichero más reciente (con fecha más actual) "
        ElseIf tfm.FechaMasReciente > 1 Then
            sTotales = $"los {tfm.FechaMasReciente} ficheros más recientes "
            sInicio = "los ficheros más recientes (con fecha más actual) "
        End If

        If tfm.NoExisten = 1 Then
            If String.IsNullOrEmpty(sTotales) Then
                sTotales = "uno que no existe"
                sInicio = "uno que no existe"
            Else
                sTotales &= "y uno que no existe"
                sInicio &= "y uno que no existe"
            End If
        ElseIf tfm.NoExisten > 1 Then
            If String.IsNullOrEmpty(sTotales) Then
                sTotales = $"los {tfm.NoExisten} que no existen"
                sInicio = "los que no existen"
            Else
                sTotales &= $"y los {tfm.NoExisten} que no existen"
                sInicio &= "y los que no existen"
            End If
        End If

        If tfm.TamañoDiferente = 1 Then
            sTamaño = $"{vbCrLf}(hay 1 fichero con tamaño diferente que no se copiará)"
        ElseIf tfm.TamañoDiferente > 1 Then
            sTamaño = $"{vbCrLf}(hay {tfm.TamañoDiferente} ficheros con tamaños diferentes que no se copiarán)"
        End If

        If String.IsNullOrEmpty(sTotales) Then
            ConfirmDialog.Show($"No hay ficheros más recientes ni que no existan{sTotales}{sTamaño}.",
                               "Actualizar ficheros",
                               DialogConfirmButtons.OK,
                               DialogConfirmIcon.Information)
            Return
        End If

        If avisarAlActualizar Then
            Dim ret = ConfirmDialog.Show($"Esto copiará {sInicio} del directorio:{vbCrLf}{vbCrLf}{quePanel.Tag},{vbCrLf}{vbCrLf}al directorio:{vbCrLf}{vbCrLf}{dDest}{vbCrLf}{vbCrLf}y no se pedirá confirmación individual de sobrescritura.{vbCrLf}{vbCrLf}¿Quieres actualizar {sTotales}?{sTamaño}",
                                         "Actualizar ficheros",
                                         DialogConfirmButtons.YesNo,
                                         DialogConfirmIcon.Information,
                                         "No mostrar más este aviso",
                                         Not avisarAlActualizar)
            If ret = DialogConfirmResult.No Then Return
            avisarAlActualizar = Not ConfirmDialog.OpcionConfigurable.Value
        End If

        ' Los ficheros más recientes tendrán "f>" en el texto del item
        ' y los que no existen tendrán "x"
        For i = 0 To quePanel.Items.Count - 1
            If quePanel.Items(i).Text = "f>" OrElse quePanel.Items(i).Text = "x" Then
                Dim fi = TryCast(quePanel.Items(i).Tag, FileInfo)
                If fi Is Nothing Then Continue For
                Dim fDest = Path.Combine(dDest, fi.Name)

                LabelInfo.Text = $"Copiando {fi.Name} a {dDest}..."
                Application.DoEvents()

                fi.CopyTo(fDest, True)
            End If
        Next

        LabelInfo.Text = "Fin de actualizar ficheros más recientes (o que no existen en el destino)."
        Application.DoEvents()

        Releer()
        'CompararDirectorios()
    End Sub

    ' Para editar un subitem
    ' de una pregunta en los foros de MSDN:
    ' https://social.msdn.microsoft.com/Forums/vstudio/en-US/fe026b4a-c131-4bb7-81dd-32b8a8d98717/
    '   edit-listview-subitem?forum=vbgeneral
    Private lvModificado As ListView
    Private laFila As Integer
    Private subItemTextAnterior As String = ""

    Private Sub EditarItemTextBox_TextChanged(sender As Object, e As EventArgs) Handles EditarItemTextBox.TextChanged
        lvModificado.Items(laFila).SubItems(1).Text = EditarItemTextBox.Text
    End Sub

    Private Sub EditarItemTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EditarItemTextBox.KeyPress
        If e.KeyChar = ChrW(13) Then
            e.Handled = True

            CambiarNombre()
        End If
    End Sub

    Private Sub EditarItemTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles EditarItemTextBox.KeyDown
        If e.KeyCode = Keys.Escape Then
            EditarItemTextBox.Visible = False
            lvModificado.Items(laFila).SubItems(1).Text = subItemTextAnterior
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub EditarItemTextBox_Leave(sender As Object, e As EventArgs) Handles EditarItemTextBox.Leave
        If EditarItemTextBox.Visible = False Then Return

        CambiarNombre()
    End Sub

    Private Sub BtnCambiarNombre_Click(sender As Object, e As EventArgs) Handles BtnCambiarNombre.Click
        EditarSubItem(quePanel, -2)
    End Sub

    Private Sub MnuTemaPredeterminado_Click(sender As Object, e As EventArgs) Handles MnuTemaPredeterminado.Click
        TemaActual = Temas.Predeterminado
        CambiarTema()
    End Sub

    Private Sub MnuTemaOscuro_Click(sender As Object, e As EventArgs) Handles MnuTemaOscuro.Click
        TemaActual = Temas.Oscuro
        CambiarTema()
    End Sub

    Private Sub NortonCommanderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NortonCommanderToolStripMenuItem.Click
        TemaActual = Temas.ComandanteNorton
        CambiarTema()
    End Sub

    Private Sub BtnIntercambiar_Click(sender As Object, e As EventArgs) Handles BtnIntercambiar.Click
        Dim dIzq = lvDirIzq.Tag
        Dim dDer = lvDirDer.Tag
        lvDirIzq.Tag = dDer
        lvDirDer.Tag = dIzq
        Releer()

    End Sub

    Private Sub CboDirIzq_KeyUp(sender As Object, e As KeyEventArgs) Handles CboDirIzq.KeyUp
        If e.KeyCode = Keys.Enter Then
            ' Mostrar el contenido del directorio indicado
            MostrarContenidoDirectorio(CboDirIzq.Text, lvDirIzq)
        End If
    End Sub

    Private Sub CboDirDer_KeyUp(sender As Object, e As KeyEventArgs) Handles CboDirDer.KeyUp
        If e.KeyCode = Keys.Enter Then
            ' Mostrar el contenido del directorio indicado
            MostrarContenidoDirectorio(CboDirDer.Text, lvDirDer)
        End If
    End Sub


#Region " No borrar esto, dejarlo comentado "

    'Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles lvDirIzq.MouseClick, lvDirDer.MouseClick
    '    Dim lv = TryCast(sender, ListView)
    '    If lv Is Nothing Then Return

    '    lvModificado = lv

    '    Dim hit As ListViewHitTestInfo = lv.HitTest(e.X, e.Y)
    '    'Dim iWidth As Integer
    '    For iCol = 0 To hit.Item.SubItems.Count - 1
    '        If hit.Item.SubItems(iCol).Bounds.Left <= e.X Then
    '            If iCol = 0 AndAlso hit.Item.SubItems.Count > 1 Then
    '                If e.X <= hit.Item.SubItems(1).Bounds.Left Then
    '                    'iWidth = hit.Item.SubItems(1).Bounds.Left
    '                    laColumna = iCol
    '                    Exit For
    '                End If
    '            ElseIf e.X <= hit.Item.SubItems(iCol).Bounds.Right Then
    '                'iWidth = hit.Item.SubItems(iCol).Bounds.Width
    '                laColumna = iCol
    '                Exit For
    '            End If
    '        End If
    '    Next
    '    ' Solo permitir modificar el nombre (subItem(1))
    '    If laColumna <> 1 Then Return

    '    laFila = hit.Item.Index

    '    EditarSubItem(lv, laFila)

    '    'If lvModificado Is lvDirIzq Then
    '    '    EditarItemTextBox.Left = lv.Left + hit.SubItem.Bounds.Left + 3
    '    'Else
    '    '    EditarItemTextBox.Left = SplitContainer1.Left + SplitContainer1.SplitterDistance + lv.Left + hit.SubItem.Bounds.Left + 3 + 5
    '    'End If
    '    'EditarItemTextBox.Top = SplitContainer1.Top + lv.Top + hit.SubItem.Bounds.Top
    '    'EditarItemTextBox.Width = iWidth
    '    'EditarItemTextBox.Height = 18
    '    'EditarItemTextBox.Text = hit.SubItem.Text
    '    'EditarItemTextBox.Visible = True
    '    'EditarItemTextBox.ReadOnly = False
    '    'subItemTextAnterior = EditarItemTextBox.Text
    'End Sub

#End Region

    ''' <summary>
    ''' Editar el nombre del item seleccionado
    ''' </summary>
    ''' <param name="lv">El panel en el que se edita</param>
    ''' <param name="index">El índice del item a modificar (-2 para usar el primero seleccionado)</param>
    Private Sub EditarSubItem(lv As ListView, index As Integer)
        lvModificado = lv

        If index = -2 Then
            index = lv.SelectedIndices(0)
        End If
        Dim it = lv.Items(index)
        laFila = index

        If lvModificado Is lvDirIzq Then
            EditarItemTextBox.Left = lv.Left + it.SubItems(1).Bounds.Left + 3
        Else
            EditarItemTextBox.Left = SplitContainer1.Left + SplitContainer1.SplitterDistance + lv.Left + it.SubItems(1).Bounds.Left + 3 + 5
        End If
        EditarItemTextBox.Top = SplitContainer1.Top + lv.Top + it.SubItems(1).Bounds.Top
        EditarItemTextBox.Width = it.SubItems(1).Bounds.Width
        EditarItemTextBox.Height = it.SubItems(1).Bounds.Height ' 18
        EditarItemTextBox.Text = it.SubItems(1).Text
        EditarItemTextBox.Visible = True
        EditarItemTextBox.ReadOnly = False
        subItemTextAnterior = EditarItemTextBox.Text
        EditarItemTextBox.Focus()
    End Sub

    ''' <summary>
    ''' Cambia el nombre del fichero o directorio seleccionado (pulsar F2)
    ''' </summary>
    Private Sub CambiarNombre()
        ' Comprobar si se ha cambiado lo que había antes
        EditarItemTextBox.Visible = False
        If subItemTextAnterior <> EditarItemTextBox.Text Then
            ' ha cambiado el texto
            'Debug.WriteLine(subItemTextAnterior)

            Dim fi = TryCast(lvModificado.Items(laFila).Tag, FileInfo)
            Dim di As DirectoryInfo = Nothing
            If fi Is Nothing Then
                di = TryCast(lvModificado.Items(laFila).Tag, DirectoryInfo)
            End If
            If fi Is Nothing AndAlso di Is Nothing Then
                lvModificado.Items(laFila).SubItems(1).Text = subItemTextAnterior
                Return
            End If

            Dim nuevoNombre = EditarItemTextBox.Text

            If fi IsNot Nothing Then
                Dim fNuevo = Path.Combine(fi.DirectoryName, nuevoNombre)
                ' Si el fichero ya existe, cancelar
                If File.Exists(fNuevo) Then
                    lvModificado.Items(laFila).SubItems(1).Text = subItemTextAnterior
                    Return
                End If
                Try
                    Dim fiRenombrado = fi.CopyTo(fNuevo, True)
                    fi.Delete()
                    lvModificado.Items(laFila).Tag = fiRenombrado
                Catch ex As Exception
                    LabelInfo.Text = ex.Message
                End Try
            ElseIf di IsNot Nothing Then
                Dim dNuevo = Path.Combine(di.Parent.FullName, nuevoNombre)
                If Directory.Exists(dNuevo) Then
                    lvModificado.Items(laFila).SubItems(1).Text = subItemTextAnterior
                    Return
                End If
                Try
                    Dim diRenombrado = di.Parent.CreateSubdirectory(nuevoNombre)
                    ' eliminar el directorio, eliminando antes el contenido que tenga
                    EliminarContenidoDir(di.FullName)

                    di.Delete()

                    lvModificado.Items(laFila).Tag = diRenombrado
                Catch ex As Exception
                    LabelInfo.Text = ex.Message
                End Try
            End If

            Releer()
            'CompararDirectorios()
        End If
    End Sub

    ''' <summary>
    ''' Cambiar los colores al tema seleccionado
    ''' </summary>
    Private Sub CambiarTema()
        AsignarTema(Me, VentanaFondo, VentanaTexto)

        'AsignarTema(SplitContainer1.Panel1, PanelBorde, PanelBorde)
        'AsignarTema(SplitContainer1.Panel2, PanelBorde, PanelBorde)

        ' El panel activo del SplitContainer1 se asignan aquí
        LvDirIzq_Enter(quePanel, Nothing)

        AsignarTema(lvDirDer, PanelFondo, PanelTexto)
        AsignarTema(lvDirIzq, PanelFondo, PanelTexto)

        ' Asignarlo después de llamar a LvDirIzq_Enter
        AsignarTema(FlowLayoutPanelIzq, PanelFondo, PanelTexto)
        AsignarTema(FlowLayoutPanelDer, PanelFondo, PanelTexto)

        AsignarTema(StatusStripInfo, StatusFondo, StatusTexto)

        AsignarTema(ToolStripIzq, VentanaFondo, VentanaTexto)
        AsignarTema(ToolStripDer, VentanaFondo, VentanaTexto)
        AsignarTema(ToolStripComparar, VentanaFondo, VentanaTexto)

        AsignarTemaBotones(ToolStripIzq, BotonesFondo, BotonesTexto)
        AsignarTemaBotones(ToolStripDer, BotonesFondo, BotonesTexto)
        AsignarTemaBotones(ToolStripComparar, BotonesFondo, BotonesTexto)

        AsignarTema(CboDirIzq, BotonesFondo, BotonesTexto)
        AsignarTema(CboDirDer, BotonesFondo, BotonesTexto)

        Releer()
        'If comparado Then
        '    Releer()
        '    CompararDirectorios()
        'End If
    End Sub

    ''' <summary>
    ''' Asignar los últimos directorios a los botones
    ''' </summary>
    ''' <param name="BtnDropDown">El botón al que se añaden los menús</param>
    Private Sub AsignarMenuUltimosDir(BtnDropDown As ToolStripDropDownButton)
        ' Eliminar el contenido que hubiese de antes
        BtnDropDown.DropDownItems.Clear()

        Dim lv As ListView
        If BtnDropDown Is BtnAbrirDirIzqDropDown Then
            lv = lvDirIzq
        Else
            lv = lvDirDer
        End If

        For Each sDir In UltimosDirs
            If sDir.Any Then
                Dim mnu As New ToolStripMenuItem(sDir)
                AddHandler mnu.Click, Sub(s1 As Object, e1 As EventArgs)
                                          For Each m As ToolStripMenuItem In BtnDropDown.DropDownItems
                                              m.Checked = False
                                          Next
                                          Dim m2 = TryCast(s1, ToolStripMenuItem)
                                          m2.Checked = True
                                          MostrarContenidoDirectorio(m2.Text, lv)
                                      End Sub
                mnu.Checked = False
                BtnDropDown.DropDownItems.Add(mnu)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Edita el fichero seleccionado (si hay varios, se editará el primero)
    ''' en el editor indicado por <see cref="EditorTextoIndex"/>
    ''' </summary>
    Private Sub EditarFichero()
        If quePanel Is Nothing Then Return
        If quePanel.SelectedItems.Count = 0 Then Return

        Dim fi = TryCast(quePanel.SelectedItems(0).Tag, FileInfo)
        Dim pi As New ProcessStartInfo With {
            .FileName = $"{ChrW(34)}{EditoresTexto(EditorTextoIndex)}{ChrW(34)}",
            .Arguments = $"{ChrW(34)}{fi.FullName}{ChrW(34)}",
            .UseShellExecute = True,
            .WindowStyle = ProcessWindowStyle.Normal
        }
        Dim p As New Process With {
            .StartInfo = pi
        }
        p.Start()

        MostrarContenidoDirectorio(quePanel.Tag.ToString, quePanel)
    End Sub

    ''' <summary>
    ''' Mostrar la ventana de Acerca de
    ''' </summary>
    Private Sub AcercaDe()
        Dim sb As New StringBuilder
        sb.AppendLine(Me.Text)
        sb.AppendLine()
        sb.AppendLine(My.Application.Info.Description)
        sb.AppendLine()
        sb.AppendLine(My.Application.Info.Copyright)
        sb.AppendLine()
        sb.Append("Versión v ")
        sb.Append(My.Application.Info.Version)
        sb.Append(" (")
        sb.Append(Application.ProductVersion)
        sb.Append(")")
        sb.AppendLine()
        sb.AppendLine()
        sb.AppendLine("------------------------------------------------------------")
        sb.AppendLine()
        sb.Append("Este programa no tenía la intención de parecerse al Comandante Norton (Norton Commander), ")
        sb.AppendLine("pero ya que estaba... he usado prácticamente las mismas teclas F1 y F3 a F8 del CN y me decidí a hacer un tema parecido en los colores al del Comandante Norton.")
        sb.AppendLine()
        sb.AppendLine("Y como a la gente ahora le gusta eso de usar temas oscuros, pues... también he añadido un tema oscuro, aparte del normal o el que inicialmente empecé a usar.")
        sb.AppendLine()
        sb.AppendLine("Para cambiar de tema, en el menú Ver elige Temas y selecciona uno de los temas mostrados.")
        sb.AppendLine("En una nueva actualización podrás personalizar los colores de los temas.")
        sb.AppendLine()
        sb.AppendLine("")
        ConfirmDialog.Show(sb.ToString, "Acerca de", DialogConfirmButtons.OK, DialogConfirmIcon.Information)
    End Sub

    Private Sub MostrarInfo()
        Dim sCopyR = "(c) Guillermo Som (elGuille), 2020"
        If Date.Now.Year > 2020 Then
            sCopyR &= $"-{Date.Now.Year}"
        End If
        LabelInfo.Text = $"{Application.ProductName} v{Application.ProductVersion}, {sCopyR} " &
            $"- Ventana: Width: {Me.Width}, Height: {Me.Height} " &
            $"- Panel Izq: {lvDirIzq.Items.Count} elementos - Panel Der: {lvDirDer.Items.Count} elementos"
    End Sub

    '
    ' Métodos de evento
    '

    Private Sub BtnComparar_Click(sender As Object, e As EventArgs) Handles btnComparar.Click
        btnComparar.HideDropDown()
        CompararDirectorios()
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Releer()
    End Sub

    Private Sub BtnAbrirDirIzq_Click(sender As Object, e As EventArgs) Handles btnAbrirDirIzq.Click
        AbrirCarpeta(lvDirIzq)
    End Sub

    Private Sub BtnAbrirDirDer_Click(sender As Object, e As EventArgs) Handles btnAbrirDirDer.Click
        AbrirCarpeta(lvDirDer)
    End Sub

    Private Sub LvDirIzq_Click(sender As Object, e As EventArgs) Handles lvDirIzq.Click, lvDirDer.Click
        Dim lv = TryCast(sender, ListView)
        If lv Is Nothing Then Return
        If lv.SelectedItems.Count = 0 Then Return

        Dim lv1 As ListView
        If lv Is lvDirIzq Then
            lv1 = lvDirDer
        Else
            lv1 = lvDirIzq
        End If

        If lv1.SelectedItems.Count > 0 Then
            lv1.SelectedItems.Clear()
        End If

        ' Seleccionar todos los de la izquierda
        For i = 0 To lv.SelectedItems.Count - 1
            Dim fi = TryCast(lv.SelectedItems(0).Tag, FileInfo)
            ' Seleccionar tanto ficheros como directorios
            'If fi Is Nothing Then Return

            ' Buscar el elemento en la otra lista
            Dim nombre = lv.SelectedItems(i).SubItems(1).Text
            If String.IsNullOrEmpty(nombre) Then Continue For

            For j = 0 To lv1.Items.Count - 1
                Dim nombreDer = lv1.Items(j).SubItems(1).Text
                If String.IsNullOrEmpty(nombreDer) Then Continue For
                If nombre = nombreDer Then
                    lv1.Items(j).Selected = True
                    Exit For
                End If
            Next
        Next

    End Sub

    Private Sub LvDirIzq_DoubleClick(sender As Object, e As EventArgs) Handles lvDirIzq.DoubleClick
        IrParentDir(lvDirIzq)
    End Sub

    Private Sub LvDirDer_DoubleClick(sender As Object, e As EventArgs) Handles lvDirDer.DoubleClick
        IrParentDir(lvDirDer)
    End Sub

    Private Sub LvDirIzq_Enter(sender As Object, e As EventArgs) Handles lvDirIzq.Enter, lvDirDer.Enter
        quePanel = TryCast(sender, ListView)
        If quePanel Is Nothing Then Return

        If quePanel Is lvDirIzq Then
            lvDirDer.GridLines = False
            'SplitContainer1.Panel1.BackColor = PanelBorde(TemaActual) ' Color.DarkGoldenrod
            'SplitContainer1.Panel2.BackColor = Color.FromKnownColor(KnownColor.Control)
            AsignarTema(SplitContainer1.Panel1, PanelBordeActivo, PanelBorde)
            AsignarTema(SplitContainer1.Panel2, PanelBorde, PanelBorde)
        Else
            lvDirIzq.GridLines = False
            'SplitContainer1.Panel2.BackColor = PanelBorde(TemaActual) 'Color.DarkGoldenrod
            'SplitContainer1.Panel1.BackColor = Color.FromKnownColor(KnownColor.Control)
            AsignarTema(SplitContainer1.Panel2, PanelBordeActivo, PanelBorde)
            AsignarTema(SplitContainer1.Panel1, PanelBorde, PanelBorde)
        End If
        quePanel.GridLines = True
    End Sub

    Private Sub BtnCopiar_Click(sender As Object, e As EventArgs) Handles btnCopiar.Click
        CopiarFicheros()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        EliminarFicheros()
    End Sub

    Private Sub BtnNuevoFichero_Click(sender As Object, e As EventArgs) Handles btnNuevoFichero.Click
        NuevoFichero()
    End Sub

    Private Sub BtnMover_Click(sender As Object, e As EventArgs) Handles btnMover.Click
        MoverFicheros()
    End Sub

    Private Sub BtnMkDir_Click(sender As Object, e As EventArgs) Handles BtnNuevoDir.Click
        CrearDirectorio()
    End Sub

    Private Sub BtnCopiarDir_Click(sender As Object, e As EventArgs) Handles btnCopiarDir.Click
        CopiarDirectorios()
    End Sub

    Private Sub BtnMoverDir_Click(sender As Object, e As EventArgs) Handles btnMoverDir.Click
        MoverDirectorios()
    End Sub

    Private Sub BtnEliminarDir_Click(sender As Object, e As EventArgs) Handles btnEliminarDir.Click
        EliminarDirectorios()
    End Sub

    Private Sub BtnDropDown_DropDownOpening(sender As Object, e As EventArgs) Handles BtnAbrirDirIzqDropDown.DropDownOpening, BtnAbrirDirDerDropDown.DropDownOpening
        ' marcar como seleccionado el directorio actual
        Dim lv As ListView
        Dim BtnDropDown As ToolStripDropDownButton
        If sender Is BtnAbrirDirIzqDropDown Then
            lv = lvDirIzq
            BtnDropDown = BtnAbrirDirIzqDropDown
        Else
            lv = lvDirDer
            BtnDropDown = BtnAbrirDirDerDropDown
        End If
        If lv.Tag Is Nothing Then Return

        Dim sDir = lv.Tag.ToString
        For Each m As ToolStripMenuItem In BtnDropDown.DropDownItems
            If m.Text = sDir Then
                m.Checked = True
                'Exit For
            Else
                m.Checked = False
            End If
        Next
    End Sub
    Private Sub BtnActualizarMasRecientes_Click(sender As Object, e As EventArgs) Handles BtnActualizarMasRecientes.Click
        ActualizarMasRecientes()
    End Sub

    Private Sub TimerFechaHora_Tick(sender As Object, e As EventArgs) Handles TimerFechaHora.Tick
        LabelFechaHora.Text = Date.Now.ToString("dd.MMMyy HH:mm")
    End Sub

    Private Sub CompararAlReleerMenu_Click(sender As Object, e As EventArgs) Handles CompararAlReleerMenu.Click
        CompararAlReleerMenu.Checked = Not CompararAlReleerMenu.Checked
        compararDirs = CompararAlReleerMenu.Checked
        btnComparar.HideDropDown()
    End Sub

    Private Sub BtnCopiarSplit_Click(sender As Object, e As EventArgs) Handles BtnCopiarSplit.Click
        CopiarTodosSeleccionados()
    End Sub

    Private Sub BtnMoverSplit_Click(sender As Object, e As EventArgs) Handles BtnMoverSplit.Click
        MoverTodosSeleccionados()
    End Sub

    Private Sub BtnEliminarSplit_Click(sender As Object, e As EventArgs) Handles BtnEliminarSplit.Click
        EliminarTodosSeleccionados()
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        EditarFichero()
    End Sub

    Private Sub BtnVerEnVisor_Click(sender As Object, e As EventArgs) Handles BtnVerEnVisor.Click
        VerFichero()
    End Sub

End Class
