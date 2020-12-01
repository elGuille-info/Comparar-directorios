Imports System
Imports System.Windows.Forms
Imports System.Drawing

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"DIR", "generarClaveSHA1.sln", "9.108.320.256", "19/11/2020 21:16:30"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.FlowLayoutPanelIzq = New System.Windows.Forms.FlowLayoutPanel()
        Me.ToolStripIzq = New System.Windows.Forms.ToolStrip()
        Me.btnAbrirDirIzq = New System.Windows.Forms.ToolStripButton()
        Me.BtnAbrirDirIzqDropDown = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CboDirIzq = New System.Windows.Forms.ComboBox()
        Me.lvDirIzq = New System.Windows.Forms.ListView()
        Me.chInfoIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNombreIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTamañoIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFechaIzq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FlowLayoutPanelDer = New System.Windows.Forms.FlowLayoutPanel()
        Me.ToolStripDer = New System.Windows.Forms.ToolStrip()
        Me.btnAbrirDirDer = New System.Windows.Forms.ToolStripButton()
        Me.BtnAbrirDirDerDropDown = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CboDirDer = New System.Windows.Forms.ComboBox()
        Me.lvDirDer = New System.Windows.Forms.ListView()
        Me.chInfoDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNombreDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTamañoDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFechaDer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStripComparar = New System.Windows.Forms.ToolStrip()
        Me.btnComparar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnReleer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnRenombrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnVer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnCopiarSplit = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnMoverSplit = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnNuevoDropDown = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnEliminarSplit = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnIntercambiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuTemas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTemaPredeterminado = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTemaOscuro = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuNortonCommander = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnMover = New System.Windows.Forms.ToolStripButton()
        Me.btnMoverDir = New System.Windows.Forms.ToolStripButton()
        Me.btnCopiar = New System.Windows.Forms.ToolStripButton()
        Me.btnCopiarDir = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminarDir = New System.Windows.Forms.ToolStripButton()
        Me.btnNuevoFichero = New System.Windows.Forms.ToolStripButton()
        Me.BtnNuevoDir = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripInfo = New System.Windows.Forms.StatusStrip()
        Me.LabelInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LabelFechaHora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.picAdmin = New System.Windows.Forms.ToolStripStatusLabel()
        Me.EditarItemTextBox = New System.Windows.Forms.TextBox()
        Me.TimerFechaHora = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MnuFichero = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFicComparar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFicReleer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuFicRenombrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFicVer = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFicEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFicCopiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFicMover = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFicNuevoDirectorio = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFicNuevoFichero = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFicEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuFicActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuFicIntercambiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuFicAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuFicSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuOpciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuCompararAlCambiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuAvisarActualizarEnIzquierdo = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAvisarAlActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuColorearTiposFicheros = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuModificarColores = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuVentana = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuAcoplarIzquierda = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAcoplarDerecha = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDesacoplar = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.FlowLayoutPanelIzq.SuspendLayout()
        Me.ToolStripIzq.SuspendLayout()
        Me.FlowLayoutPanelDer.SuspendLayout()
        Me.ToolStripDer.SuspendLayout()
        Me.ToolStripComparar.SuspendLayout()
        Me.StatusStripInfo.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(10, 56)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.FlowLayoutPanelIzq)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lvDirIzq)
        Me.SplitContainer1.Panel1.Margin = New System.Windows.Forms.Padding(1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.FlowLayoutPanelDer)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvDirDer)
        Me.SplitContainer1.Panel2.Margin = New System.Windows.Forms.Padding(1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1154, 573)
        Me.SplitContainer1.SplitterDistance = 573
        Me.SplitContainer1.TabIndex = 0
        '
        'FlowLayoutPanelIzq
        '
        Me.FlowLayoutPanelIzq.Controls.Add(Me.ToolStripIzq)
        Me.FlowLayoutPanelIzq.Controls.Add(Me.CboDirIzq)
        Me.FlowLayoutPanelIzq.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanelIzq.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanelIzq.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanelIzq.Name = "FlowLayoutPanelIzq"
        Me.FlowLayoutPanelIzq.Size = New System.Drawing.Size(571, 26)
        Me.FlowLayoutPanelIzq.TabIndex = 2
        '
        'ToolStripIzq
        '
        Me.ToolStripIzq.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripIzq.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripIzq.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAbrirDirIzq, Me.BtnAbrirDirIzqDropDown, Me.ToolStripSeparator1})
        Me.ToolStripIzq.Location = New System.Drawing.Point(1, 1)
        Me.ToolStripIzq.Margin = New System.Windows.Forms.Padding(1)
        Me.ToolStripIzq.Name = "ToolStripIzq"
        Me.ToolStripIzq.Size = New System.Drawing.Size(100, 25)
        Me.ToolStripIzq.TabIndex = 0
        Me.ToolStripIzq.Text = "ToolStrip2"
        '
        'btnAbrirDirIzq
        '
        Me.btnAbrirDirIzq.AutoToolTip = False
        Me.btnAbrirDirIzq.Image = CType(resources.GetObject("btnAbrirDirIzq.Image"), System.Drawing.Image)
        Me.btnAbrirDirIzq.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrirDirIzq.Name = "btnAbrirDirIzq"
        Me.btnAbrirDirIzq.Size = New System.Drawing.Size(53, 22)
        Me.btnAbrirDirIzq.Text = "Abrir"
        Me.btnAbrirDirIzq.ToolTipText = "Seleccionar el directorio a abrir en el panel izquierdo"
        '
        'BtnAbrirDirIzqDropDown
        '
        Me.BtnAbrirDirIzqDropDown.AutoToolTip = False
        Me.BtnAbrirDirIzqDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnAbrirDirIzqDropDown.Image = CType(resources.GetObject("BtnAbrirDirIzqDropDown.Image"), System.Drawing.Image)
        Me.BtnAbrirDirIzqDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAbrirDirIzqDropDown.Name = "BtnAbrirDirIzqDropDown"
        Me.BtnAbrirDirIzqDropDown.Size = New System.Drawing.Size(29, 22)
        Me.BtnAbrirDirIzqDropDown.Text = "..."
        Me.BtnAbrirDirIzqDropDown.ToolTipText = "Seleccionar un directorio de los últimos directorios usados"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'CboDirIzq
        '
        Me.CboDirIzq.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboDirIzq.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.CboDirIzq.FormattingEnabled = True
        Me.CboDirIzq.Location = New System.Drawing.Point(105, 3)
        Me.CboDirIzq.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.CboDirIzq.Name = "CboDirIzq"
        Me.CboDirIzq.Size = New System.Drawing.Size(461, 21)
        Me.CboDirIzq.TabIndex = 1
        '
        'lvDirIzq
        '
        Me.lvDirIzq.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDirIzq.BackColor = System.Drawing.SystemColors.Info
        Me.lvDirIzq.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chInfoIzq, Me.chNombreIzq, Me.chTamañoIzq, Me.chFechaIzq})
        Me.lvDirIzq.FullRowSelect = True
        Me.lvDirIzq.HideSelection = False
        ListViewItem1.StateImageIndex = 0
        Me.lvDirIzq.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvDirIzq.Location = New System.Drawing.Point(6, 32)
        Me.lvDirIzq.Name = "lvDirIzq"
        Me.lvDirIzq.ShowItemToolTips = True
        Me.lvDirIzq.Size = New System.Drawing.Size(560, 536)
        Me.lvDirIzq.TabIndex = 1
        Me.lvDirIzq.UseCompatibleStateImageBehavior = False
        Me.lvDirIzq.View = System.Windows.Forms.View.Details
        '
        'chInfoIzq
        '
        Me.chInfoIzq.Text = "Info"
        Me.chInfoIzq.Width = 36
        '
        'chNombreIzq
        '
        Me.chNombreIzq.Text = "Nombre"
        Me.chNombreIzq.Width = 256
        '
        'chTamañoIzq
        '
        Me.chTamañoIzq.Text = "Tamaño bytes"
        Me.chTamañoIzq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chTamañoIzq.Width = 108
        '
        'chFechaIzq
        '
        Me.chFechaIzq.Text = "Fecha Modificación"
        Me.chFechaIzq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.chFechaIzq.Width = 140
        '
        'FlowLayoutPanelDer
        '
        Me.FlowLayoutPanelDer.Controls.Add(Me.ToolStripDer)
        Me.FlowLayoutPanelDer.Controls.Add(Me.CboDirDer)
        Me.FlowLayoutPanelDer.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanelDer.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanelDer.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanelDer.Name = "FlowLayoutPanelDer"
        Me.FlowLayoutPanelDer.Size = New System.Drawing.Size(575, 26)
        Me.FlowLayoutPanelDer.TabIndex = 5
        '
        'ToolStripDer
        '
        Me.ToolStripDer.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripDer.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripDer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAbrirDirDer, Me.BtnAbrirDirDerDropDown, Me.ToolStripSeparator2})
        Me.ToolStripDer.Location = New System.Drawing.Point(1, 1)
        Me.ToolStripDer.Margin = New System.Windows.Forms.Padding(1)
        Me.ToolStripDer.Name = "ToolStripDer"
        Me.ToolStripDer.Size = New System.Drawing.Size(100, 25)
        Me.ToolStripDer.TabIndex = 1
        Me.ToolStripDer.Text = "ToolStrip1"
        '
        'btnAbrirDirDer
        '
        Me.btnAbrirDirDer.AutoToolTip = False
        Me.btnAbrirDirDer.Image = CType(resources.GetObject("btnAbrirDirDer.Image"), System.Drawing.Image)
        Me.btnAbrirDirDer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrirDirDer.Name = "btnAbrirDirDer"
        Me.btnAbrirDirDer.Size = New System.Drawing.Size(53, 22)
        Me.btnAbrirDirDer.Text = "Abrir"
        Me.btnAbrirDirDer.ToolTipText = "Seleccionar el directorio a abrir en el panel derecho"
        '
        'BtnAbrirDirDerDropDown
        '
        Me.BtnAbrirDirDerDropDown.AutoToolTip = False
        Me.BtnAbrirDirDerDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BtnAbrirDirDerDropDown.Image = CType(resources.GetObject("BtnAbrirDirDerDropDown.Image"), System.Drawing.Image)
        Me.BtnAbrirDirDerDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAbrirDirDerDropDown.Name = "BtnAbrirDirDerDropDown"
        Me.BtnAbrirDirDerDropDown.Size = New System.Drawing.Size(29, 22)
        Me.BtnAbrirDirDerDropDown.Text = "..."
        Me.BtnAbrirDirDerDropDown.ToolTipText = "Seleccionar un directorio de los últimos directorios usados"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'CboDirDer
        '
        Me.CboDirDer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboDirDer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.CboDirDer.FormattingEnabled = True
        Me.CboDirDer.Location = New System.Drawing.Point(105, 3)
        Me.CboDirDer.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.CboDirDer.Name = "CboDirDer"
        Me.CboDirDer.Size = New System.Drawing.Size(465, 21)
        Me.CboDirDer.TabIndex = 2
        '
        'lvDirDer
        '
        Me.lvDirDer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDirDer.BackColor = System.Drawing.SystemColors.Info
        Me.lvDirDer.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chInfoDer, Me.chNombreDer, Me.chTamañoDer, Me.chFechaDer})
        Me.lvDirDer.FullRowSelect = True
        Me.lvDirDer.HideSelection = False
        Me.lvDirDer.Location = New System.Drawing.Point(6, 32)
        Me.lvDirDer.Name = "lvDirDer"
        Me.lvDirDer.ShowItemToolTips = True
        Me.lvDirDer.Size = New System.Drawing.Size(564, 536)
        Me.lvDirDer.TabIndex = 4
        Me.lvDirDer.UseCompatibleStateImageBehavior = False
        Me.lvDirDer.View = System.Windows.Forms.View.Details
        '
        'chInfoDer
        '
        Me.chInfoDer.Text = "Info"
        Me.chInfoDer.Width = 36
        '
        'chNombreDer
        '
        Me.chNombreDer.Text = "Nombre"
        Me.chNombreDer.Width = 256
        '
        'chTamañoDer
        '
        Me.chTamañoDer.Text = "Tamaño bytes"
        Me.chTamañoDer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chTamañoDer.Width = 108
        '
        'chFechaDer
        '
        Me.chFechaDer.Text = "Fecha Modificación"
        Me.chFechaDer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.chFechaDer.Width = 140
        '
        'ToolStripComparar
        '
        Me.ToolStripComparar.AutoSize = False
        Me.ToolStripComparar.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripComparar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnComparar, Me.ToolStripSeparator3, Me.btnReleer, Me.ToolStripSeparator4, Me.BtnRenombrar, Me.ToolStripSeparator5, Me.BtnVer, Me.ToolStripSeparator19, Me.BtnEditar, Me.ToolStripSeparator6, Me.BtnCopiarSplit, Me.ToolStripSeparator7, Me.BtnMoverSplit, Me.ToolStripSeparator8, Me.BtnNuevoDropDown, Me.ToolStripSeparator9, Me.BtnEliminarSplit, Me.ToolStripSeparator10, Me.BtnActualizar, Me.ToolStripSeparator11, Me.BtnIntercambiar, Me.ToolStripSeparator12})
        Me.ToolStripComparar.Location = New System.Drawing.Point(0, 24)
        Me.ToolStripComparar.Margin = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.ToolStripComparar.Name = "ToolStripComparar"
        Me.ToolStripComparar.Size = New System.Drawing.Size(1174, 25)
        Me.ToolStripComparar.TabIndex = 3
        Me.ToolStripComparar.Text = "ToolStripComparar"
        '
        'btnComparar
        '
        Me.btnComparar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnComparar.Image = CType(resources.GetObject("btnComparar.Image"), System.Drawing.Image)
        Me.btnComparar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnComparar.Name = "btnComparar"
        Me.btnComparar.Size = New System.Drawing.Size(23, 22)
        Me.btnComparar.Text = "Comparar"
        Me.btnComparar.ToolTipText = "Comparar el contenido de los dos directorios (Alt+C)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(es posible que antes debas" &
    " pulsar en Releer)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnReleer
        '
        Me.btnReleer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnReleer.Image = CType(resources.GetObject("btnReleer.Image"), System.Drawing.Image)
        Me.btnReleer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReleer.Name = "btnReleer"
        Me.btnReleer.Size = New System.Drawing.Size(23, 22)
        Me.btnReleer.Text = "Releer"
        Me.btnReleer.ToolTipText = "Volver a leer el contenido de los dos directorios (Alt+R)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BtnRenombrar
        '
        Me.BtnRenombrar.AutoToolTip = False
        Me.BtnRenombrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnRenombrar.Image = CType(resources.GetObject("BtnRenombrar.Image"), System.Drawing.Image)
        Me.BtnRenombrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRenombrar.Name = "BtnRenombrar"
        Me.BtnRenombrar.Size = New System.Drawing.Size(23, 22)
        Me.BtnRenombrar.Text = "Renombrar"
        Me.BtnRenombrar.ToolTipText = "Cambiar el nombre del fichero o directorio seleccionado en el panel activo (F2)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'BtnVer
        '
        Me.BtnVer.AutoToolTip = False
        Me.BtnVer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnVer.Image = CType(resources.GetObject("BtnVer.Image"), System.Drawing.Image)
        Me.BtnVer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnVer.Name = "BtnVer"
        Me.BtnVer.Size = New System.Drawing.Size(23, 22)
        Me.BtnVer.Text = "Ver"
        Me.BtnVer.ToolTipText = "Abrir en el visor el primer fichero seleccionado del panel activo (F3)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(si es un" &
    " fichero comprimido mostrará el contenido y se podrán abrir esos ficheros)"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(6, 25)
        '
        'BtnEditar
        '
        Me.BtnEditar.AutoToolTip = False
        Me.BtnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEditar.Image = CType(resources.GetObject("BtnEditar.Image"), System.Drawing.Image)
        Me.BtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Size = New System.Drawing.Size(23, 22)
        Me.BtnEditar.Text = "Editar"
        Me.BtnEditar.ToolTipText = "Editar el fichero seleccionado (F4)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'BtnCopiarSplit
        '
        Me.BtnCopiarSplit.AutoToolTip = False
        Me.BtnCopiarSplit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnCopiarSplit.Image = CType(resources.GetObject("BtnCopiarSplit.Image"), System.Drawing.Image)
        Me.BtnCopiarSplit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCopiarSplit.Name = "BtnCopiarSplit"
        Me.BtnCopiarSplit.Size = New System.Drawing.Size(29, 22)
        Me.BtnCopiarSplit.Text = "Copiar"
        Me.BtnCopiarSplit.ToolTipText = "Selecciona la opción para copiar ficheros o directorios " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(o pulsa F5 para copiar" &
    " los ficheros y directorios seleccionados)"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'BtnMoverSplit
        '
        Me.BtnMoverSplit.AutoToolTip = False
        Me.BtnMoverSplit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnMoverSplit.Image = CType(resources.GetObject("BtnMoverSplit.Image"), System.Drawing.Image)
        Me.BtnMoverSplit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnMoverSplit.Name = "BtnMoverSplit"
        Me.BtnMoverSplit.Size = New System.Drawing.Size(29, 22)
        Me.BtnMoverSplit.Text = "Mover"
        Me.BtnMoverSplit.ToolTipText = "Selecciona la opción para mover ficheros o directorios " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(o pulsa F6 para mover l" &
    "os ficheros y directorios seleccionados)"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'BtnNuevoDropDown
        '
        Me.BtnNuevoDropDown.AutoToolTip = False
        Me.BtnNuevoDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNuevoDropDown.Image = CType(resources.GetObject("BtnNuevoDropDown.Image"), System.Drawing.Image)
        Me.BtnNuevoDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNuevoDropDown.Name = "BtnNuevoDropDown"
        Me.BtnNuevoDropDown.Size = New System.Drawing.Size(29, 22)
        Me.BtnNuevoDropDown.Text = "Nuevo"
        Me.BtnNuevoDropDown.ToolTipText = "Selecciona la opción para crear un nuevo fichero o un nuevo directorio " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(o pulsa" &
    " F7  para crear un directorio o Ctrl+N para crear un fichero)"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'BtnEliminarSplit
        '
        Me.BtnEliminarSplit.AutoToolTip = False
        Me.BtnEliminarSplit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnEliminarSplit.Image = CType(resources.GetObject("BtnEliminarSplit.Image"), System.Drawing.Image)
        Me.BtnEliminarSplit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEliminarSplit.Name = "BtnEliminarSplit"
        Me.BtnEliminarSplit.Size = New System.Drawing.Size(29, 22)
        Me.BtnEliminarSplit.Text = "Eliminar"
        Me.BtnEliminarSplit.ToolTipText = "Selecciona la opción para eliminar ficheros o directorios " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(o pulsa F8 para elim" &
    "inar los ficheros y directorios seleccionados)"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'BtnActualizar
        '
        Me.BtnActualizar.AutoToolTip = False
        Me.BtnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(23, 22)
        Me.BtnActualizar.Text = "Actualizar"
        Me.BtnActualizar.ToolTipText = "Actualiza los ficheros más recientes (o no existentes) del panel izquierdo y los " &
    "copia en el derecho (F9)"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'BtnIntercambiar
        '
        Me.BtnIntercambiar.AutoToolTip = False
        Me.BtnIntercambiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnIntercambiar.Image = CType(resources.GetObject("BtnIntercambiar.Image"), System.Drawing.Image)
        Me.BtnIntercambiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIntercambiar.Name = "BtnIntercambiar"
        Me.BtnIntercambiar.Size = New System.Drawing.Size(23, 22)
        Me.BtnIntercambiar.Text = "Intercambiar"
        Me.BtnIntercambiar.ToolTipText = "Intercambiar los directorios de panel (Ctrl+U)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(por si quieres actualizar, ya qu" &
    "e solo actualiza del izquierdo al derecho)"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'MnuTemas
        '
        Me.MnuTemas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuTemaPredeterminado, Me.MnuTemaOscuro, Me.MnuNortonCommander})
        Me.MnuTemas.Image = CType(resources.GetObject("MnuTemas.Image"), System.Drawing.Image)
        Me.MnuTemas.Name = "MnuTemas"
        Me.MnuTemas.Size = New System.Drawing.Size(187, 22)
        Me.MnuTemas.Text = "Temas"
        '
        'MnuTemaPredeterminado
        '
        Me.MnuTemaPredeterminado.Image = CType(resources.GetObject("MnuTemaPredeterminado.Image"), System.Drawing.Image)
        Me.MnuTemaPredeterminado.Name = "MnuTemaPredeterminado"
        Me.MnuTemaPredeterminado.Size = New System.Drawing.Size(182, 22)
        Me.MnuTemaPredeterminado.Text = "Predeterminado"
        '
        'MnuTemaOscuro
        '
        Me.MnuTemaOscuro.Image = CType(resources.GetObject("MnuTemaOscuro.Image"), System.Drawing.Image)
        Me.MnuTemaOscuro.Name = "MnuTemaOscuro"
        Me.MnuTemaOscuro.Size = New System.Drawing.Size(182, 22)
        Me.MnuTemaOscuro.Text = "Oscuro"
        '
        'MnuNortonCommander
        '
        Me.MnuNortonCommander.Image = CType(resources.GetObject("MnuNortonCommander.Image"), System.Drawing.Image)
        Me.MnuNortonCommander.Name = "MnuNortonCommander"
        Me.MnuNortonCommander.Size = New System.Drawing.Size(182, 22)
        Me.MnuNortonCommander.Text = "Norton Commander"
        '
        'btnMover
        '
        Me.btnMover.AutoToolTip = False
        Me.btnMover.Image = CType(resources.GetObject("btnMover.Image"), System.Drawing.Image)
        Me.btnMover.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMover.Name = "btnMover"
        Me.btnMover.Size = New System.Drawing.Size(61, 22)
        Me.btnMover.Text = "Mover fichero"
        Me.btnMover.ToolTipText = "Mover los ficheros seleccionados del panel activo al otro panel (directorio)"
        '
        'btnMoverDir
        '
        Me.btnMoverDir.AutoToolTip = False
        Me.btnMoverDir.Image = CType(resources.GetObject("btnMoverDir.Image"), System.Drawing.Image)
        Me.btnMoverDir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMoverDir.Name = "btnMoverDir"
        Me.btnMoverDir.Size = New System.Drawing.Size(61, 22)
        Me.btnMoverDir.Text = "Mover directorio"
        Me.btnMoverDir.ToolTipText = "Mover los directorios seleccionados del panel activo al otro panel (directorio)"
        '
        'btnCopiar
        '
        Me.btnCopiar.AutoToolTip = False
        Me.btnCopiar.Image = CType(resources.GetObject("btnCopiar.Image"), System.Drawing.Image)
        Me.btnCopiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(62, 22)
        Me.btnCopiar.Text = "Copiar fichero"
        Me.btnCopiar.ToolTipText = "Copiar los ficheros seleccionados del panel activo al otro panel (directorio)"
        '
        'btnCopiarDir
        '
        Me.btnCopiarDir.AutoToolTip = False
        Me.btnCopiarDir.Image = CType(resources.GetObject("btnCopiarDir.Image"), System.Drawing.Image)
        Me.btnCopiarDir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopiarDir.Name = "btnCopiarDir"
        Me.btnCopiarDir.Size = New System.Drawing.Size(62, 22)
        Me.btnCopiarDir.Text = "Copiar directorio"
        Me.btnCopiarDir.ToolTipText = "Copiar los directorios seleccionados del panel activo al otro panel (directorio)"
        '
        'btnEliminar
        '
        Me.btnEliminar.AutoToolTip = False
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(115, 22)
        Me.btnEliminar.Text = "Eliminar ficheros"
        Me.btnEliminar.ToolTipText = "Eliminar los ficheros seleccionados del panel activo"
        '
        'btnEliminarDir
        '
        Me.btnEliminarDir.AutoToolTip = False
        Me.btnEliminarDir.Image = CType(resources.GetObject("btnEliminarDir.Image"), System.Drawing.Image)
        Me.btnEliminarDir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminarDir.Name = "btnEliminarDir"
        Me.btnEliminarDir.Size = New System.Drawing.Size(129, 22)
        Me.btnEliminarDir.Text = "Eliminar directorios"
        Me.btnEliminarDir.ToolTipText = "Eliminar los directorios seleccionados en el panel activo"
        '
        'btnNuevoFichero
        '
        Me.btnNuevoFichero.AutoToolTip = False
        Me.btnNuevoFichero.Image = CType(resources.GetObject("btnNuevoFichero.Image"), System.Drawing.Image)
        Me.btnNuevoFichero.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevoFichero.Name = "btnNuevoFichero"
        Me.btnNuevoFichero.Size = New System.Drawing.Size(62, 22)
        Me.btnNuevoFichero.Text = "Nuevo fichero"
        Me.btnNuevoFichero.ToolTipText = "Crear un nuevo fichero en el panel (directorio) activo"
        '
        'BtnNuevoDir
        '
        Me.BtnNuevoDir.AutoToolTip = False
        Me.BtnNuevoDir.Image = CType(resources.GetObject("BtnNuevoDir.Image"), System.Drawing.Image)
        Me.BtnNuevoDir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNuevoDir.Name = "BtnNuevoDir"
        Me.BtnNuevoDir.Size = New System.Drawing.Size(62, 22)
        Me.BtnNuevoDir.Text = "Nuevo directorio"
        Me.BtnNuevoDir.ToolTipText = "Crear un nuevo directorio en el panel activo"
        '
        'StatusStripInfo
        '
        Me.StatusStripInfo.BackColor = System.Drawing.Color.Transparent
        Me.StatusStripInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelInfo, Me.LabelFechaHora, Me.picAdmin})
        Me.StatusStripInfo.Location = New System.Drawing.Point(0, 634)
        Me.StatusStripInfo.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.StatusStripInfo.Name = "StatusStripInfo"
        Me.StatusStripInfo.ShowItemToolTips = True
        Me.StatusStripInfo.Size = New System.Drawing.Size(1174, 24)
        Me.StatusStripInfo.TabIndex = 1
        Me.StatusStripInfo.Text = "StatusStrip1"
        '
        'LabelInfo
        '
        Me.LabelInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LabelInfo.Image = CType(resources.GetObject("LabelInfo.Image"), System.Drawing.Image)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(1040, 19)
        Me.LabelInfo.Spring = True
        Me.LabelInfo.Text = "ToolStripStatusLabel1"
        Me.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelFechaHora
        '
        Me.LabelFechaHora.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.LabelFechaHora.Name = "LabelFechaHora"
        Me.LabelFechaHora.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LabelFechaHora.Size = New System.Drawing.Size(97, 19)
        Me.LabelFechaHora.Text = "24.nov.20 02:55"
        '
        'picAdmin
        '
        Me.picAdmin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.picAdmin.Image = CType(resources.GetObject("picAdmin.Image"), System.Drawing.Image)
        Me.picAdmin.Name = "picAdmin"
        Me.picAdmin.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.picAdmin.Size = New System.Drawing.Size(22, 19)
        '
        'EditarItemTextBox
        '
        Me.EditarItemTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditarItemTextBox.Location = New System.Drawing.Point(1120, 5)
        Me.EditarItemTextBox.Name = "EditarItemTextBox"
        Me.EditarItemTextBox.Size = New System.Drawing.Size(100, 20)
        Me.EditarItemTextBox.TabIndex = 4
        Me.EditarItemTextBox.Visible = False
        '
        'TimerFechaHora
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFichero, Me.MnuOpciones, Me.MnuVentana})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1174, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MnuFichero
        '
        Me.MnuFichero.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFicComparar, Me.MnuFicReleer, Me.ToolStripSeparator13, Me.MnuFicRenombrar, Me.MnuFicVer, Me.MnuFicEditar, Me.MnuFicCopiar, Me.MnuFicMover, Me.MnuFicNuevoDirectorio, Me.MnuFicNuevoFichero, Me.MnuFicEliminar, Me.ToolStripSeparator14, Me.MnuFicActualizar, Me.ToolStripSeparator15, Me.MnuFicIntercambiar, Me.ToolStripSeparator16, Me.MnuFicAcercaDe, Me.ToolStripSeparator17, Me.MnuFicSalir})
        Me.MnuFichero.Name = "MnuFichero"
        Me.MnuFichero.Size = New System.Drawing.Size(58, 20)
        Me.MnuFichero.Text = "&Fichero"
        '
        'MnuFicComparar
        '
        Me.MnuFicComparar.Name = "MnuFicComparar"
        Me.MnuFicComparar.ShortcutKeyDisplayString = "Alt+C"
        Me.MnuFicComparar.Size = New System.Drawing.Size(231, 22)
        Me.MnuFicComparar.Text = "&Comparar"
        '
        'MnuFicReleer
        '
        Me.MnuFicReleer.Name = "MnuFicReleer"
        Me.MnuFicReleer.ShortcutKeyDisplayString = "Alt+R"
        Me.MnuFicReleer.Size = New System.Drawing.Size(231, 22)
        Me.MnuFicReleer.Text = "&Releer"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(228, 6)
        '
        'MnuFicRenombrar
        '
        Me.MnuFicRenombrar.Name = "MnuFicRenombrar"
        Me.MnuFicRenombrar.ShortcutKeyDisplayString = "F2"
        Me.MnuFicRenombrar.Size = New System.Drawing.Size(231, 22)
        Me.MnuFicRenombrar.Text = "Re&nombrar"
        '
        'MnuFicVer
        '
        Me.MnuFicVer.Name = "MnuFicVer"
        Me.MnuFicVer.ShortcutKeyDisplayString = "F3"
        Me.MnuFicVer.Size = New System.Drawing.Size(231, 22)
        Me.MnuFicVer.Text = "Mostrar en el &visor..."
        '
        'MnuFicEditar
        '
        Me.MnuFicEditar.Name = "MnuFicEditar"
        Me.MnuFicEditar.ShortcutKeyDisplayString = "F4"
        Me.MnuFicEditar.Size = New System.Drawing.Size(231, 22)
        Me.MnuFicEditar.Text = "&Editar"
        '
        'MnuFicCopiar
        '
        Me.MnuFicCopiar.Name = "MnuFicCopiar"
        Me.MnuFicCopiar.ShortcutKeyDisplayString = "F5"
        Me.MnuFicCopiar.Size = New System.Drawing.Size(231, 22)
        Me.MnuFicCopiar.Text = "Copiar"
        '
        'MnuFicMover
        '
        Me.MnuFicMover.Name = "MnuFicMover"
        Me.MnuFicMover.ShortcutKeyDisplayString = "F6"
        Me.MnuFicMover.Size = New System.Drawing.Size(231, 22)
        Me.MnuFicMover.Text = "Mover"
        '
        'MnuFicNuevoDirectorio
        '
        Me.MnuFicNuevoDirectorio.Name = "MnuFicNuevoDirectorio"
        Me.MnuFicNuevoDirectorio.ShortcutKeyDisplayString = "F7"
        Me.MnuFicNuevoDirectorio.Size = New System.Drawing.Size(231, 22)
        Me.MnuFicNuevoDirectorio.Text = "Nuevo Directorio"
        '
        'MnuFicNuevoFichero
        '
        Me.MnuFicNuevoFichero.Name = "MnuFicNuevoFichero"
        Me.MnuFicNuevoFichero.ShortcutKeyDisplayString = "Ctrl+N"
        Me.MnuFicNuevoFichero.Size = New System.Drawing.Size(231, 22)
        Me.MnuFicNuevoFichero.Text = "Nuevo Fichero"
        '
        'MnuFicEliminar
        '
        Me.MnuFicEliminar.Name = "MnuFicEliminar"
        Me.MnuFicEliminar.ShortcutKeyDisplayString = "F8"
        Me.MnuFicEliminar.Size = New System.Drawing.Size(231, 22)
        Me.MnuFicEliminar.Text = "Eliminar"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(228, 6)
        '
        'MnuFicActualizar
        '
        Me.MnuFicActualizar.Name = "MnuFicActualizar"
        Me.MnuFicActualizar.ShortcutKeyDisplayString = "F9"
        Me.MnuFicActualizar.Size = New System.Drawing.Size(231, 22)
        Me.MnuFicActualizar.Text = "Actualizar contenido"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(228, 6)
        '
        'MnuFicIntercambiar
        '
        Me.MnuFicIntercambiar.Name = "MnuFicIntercambiar"
        Me.MnuFicIntercambiar.ShortcutKeyDisplayString = "Alt+I"
        Me.MnuFicIntercambiar.Size = New System.Drawing.Size(231, 22)
        Me.MnuFicIntercambiar.Text = "Intercambiar contenido"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(228, 6)
        '
        'MnuFicAcercaDe
        '
        Me.MnuFicAcercaDe.Image = CType(resources.GetObject("MnuFicAcercaDe.Image"), System.Drawing.Image)
        Me.MnuFicAcercaDe.Name = "MnuFicAcercaDe"
        Me.MnuFicAcercaDe.ShortcutKeyDisplayString = "F1"
        Me.MnuFicAcercaDe.Size = New System.Drawing.Size(231, 22)
        Me.MnuFicAcercaDe.Text = "Acerca de..."
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(228, 6)
        '
        'MnuFicSalir
        '
        Me.MnuFicSalir.Image = CType(resources.GetObject("MnuFicSalir.Image"), System.Drawing.Image)
        Me.MnuFicSalir.Name = "MnuFicSalir"
        Me.MnuFicSalir.ShortcutKeyDisplayString = "Alt+F4"
        Me.MnuFicSalir.Size = New System.Drawing.Size(231, 22)
        Me.MnuFicSalir.Text = "Salir"
        '
        'MnuOpciones
        '
        Me.MnuOpciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCompararAlCambiar, Me.ToolStripSeparator18, Me.MnuAvisarActualizarEnIzquierdo, Me.MnuAvisarAlActualizar, Me.ToolStripSeparator22, Me.MnuColorearTiposFicheros, Me.ToolStripSeparator21, Me.MnuModificarColores})
        Me.MnuOpciones.Name = "MnuOpciones"
        Me.MnuOpciones.Size = New System.Drawing.Size(69, 20)
        Me.MnuOpciones.Text = "&Opciones"
        '
        'MnuCompararAlCambiar
        '
        Me.MnuCompararAlCambiar.Name = "MnuCompararAlCambiar"
        Me.MnuCompararAlCambiar.Size = New System.Drawing.Size(331, 22)
        Me.MnuCompararAlCambiar.Text = "Comparar al cambiar de directorio"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(328, 6)
        '
        'MnuAvisarActualizarEnIzquierdo
        '
        Me.MnuAvisarActualizarEnIzquierdo.Name = "MnuAvisarActualizarEnIzquierdo"
        Me.MnuAvisarActualizarEnIzquierdo.Size = New System.Drawing.Size(331, 22)
        Me.MnuAvisarActualizarEnIzquierdo.Text = "Avisar si al actualizar está activo el panel derecho"
        '
        'MnuAvisarAlActualizar
        '
        Me.MnuAvisarAlActualizar.Name = "MnuAvisarAlActualizar"
        Me.MnuAvisarAlActualizar.Size = New System.Drawing.Size(331, 22)
        Me.MnuAvisarAlActualizar.Text = "Avisar al actualizar"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(328, 6)
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(328, 6)
        '
        'MnuColorearTiposFicheros
        '
        Me.MnuColorearTiposFicheros.Name = "MnuColorearTiposFicheros"
        Me.MnuColorearTiposFicheros.Size = New System.Drawing.Size(331, 22)
        Me.MnuColorearTiposFicheros.Text = "Colorear los tipos de ficheros"
        '
        'MnuModificarColores
        '
        Me.MnuModificarColores.Image = CType(resources.GetObject("MnuModificarColores.Image"), System.Drawing.Image)
        Me.MnuModificarColores.Name = "MnuModificarColores"
        Me.MnuModificarColores.Size = New System.Drawing.Size(331, 22)
        Me.MnuModificarColores.Text = "Modificar los colores del tema activo"
        '
        'MnuVentana
        '
        Me.MnuVentana.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuTemas, Me.ToolStripSeparator20, Me.MnuAcoplarIzquierda, Me.MnuAcoplarDerecha, Me.MnuDesacoplar})
        Me.MnuVentana.Name = "MnuVentana"
        Me.MnuVentana.Size = New System.Drawing.Size(61, 20)
        Me.MnuVentana.Text = "&Ventana"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(184, 6)
        '
        'MnuAcoplarIzquierda
        '
        Me.MnuAcoplarIzquierda.Image = CType(resources.GetObject("MnuAcoplarIzquierda.Image"), System.Drawing.Image)
        Me.MnuAcoplarIzquierda.Name = "MnuAcoplarIzquierda"
        Me.MnuAcoplarIzquierda.Size = New System.Drawing.Size(187, 22)
        Me.MnuAcoplarIzquierda.Text = "Acoplar a la izquierda"
        '
        'MnuAcoplarDerecha
        '
        Me.MnuAcoplarDerecha.Image = CType(resources.GetObject("MnuAcoplarDerecha.Image"), System.Drawing.Image)
        Me.MnuAcoplarDerecha.Name = "MnuAcoplarDerecha"
        Me.MnuAcoplarDerecha.Size = New System.Drawing.Size(187, 22)
        Me.MnuAcoplarDerecha.Text = "Acoplar a la derecha"
        '
        'MnuDesacoplar
        '
        Me.MnuDesacoplar.Image = CType(resources.GetObject("MnuDesacoplar.Image"), System.Drawing.Image)
        Me.MnuDesacoplar.Name = "MnuDesacoplar"
        Me.MnuDesacoplar.Size = New System.Drawing.Size(187, 22)
        Me.MnuDesacoplar.Text = "Restaurar posición"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1174, 658)
        Me.Controls.Add(Me.EditarItemTextBox)
        Me.Controls.Add(Me.ToolStripComparar)
        Me.Controls.Add(Me.StatusStripInfo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(1040, 500)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comparar directorios - Mostrar el contenido de 2 directorios y gestionarlos"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.FlowLayoutPanelIzq.ResumeLayout(False)
        Me.FlowLayoutPanelIzq.PerformLayout()
        Me.ToolStripIzq.ResumeLayout(False)
        Me.ToolStripIzq.PerformLayout()
        Me.FlowLayoutPanelDer.ResumeLayout(False)
        Me.FlowLayoutPanelDer.PerformLayout()
        Me.ToolStripDer.ResumeLayout(False)
        Me.ToolStripDer.PerformLayout()
        Me.ToolStripComparar.ResumeLayout(False)
        Me.ToolStripComparar.PerformLayout()
        Me.StatusStripInfo.ResumeLayout(False)
        Me.StatusStripInfo.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents ToolStripIzq As ToolStrip
    Private WithEvents btnAbrirDirIzq As ToolStripButton
    Private WithEvents btnAbrirDirDer As ToolStripButton
    Private WithEvents lvDirIzq As ListView
    Private WithEvents chInfoIzq As ColumnHeader
    Private WithEvents chNombreIzq As ColumnHeader
    Private WithEvents chFechaIzq As ColumnHeader
    Private WithEvents SplitContainer1 As SplitContainer
    Private WithEvents ToolStripComparar As ToolStrip
    Private WithEvents ToolStripDer As ToolStrip
    Private WithEvents ToolStripSeparator3 As ToolStripSeparator
    Private WithEvents btnReleer As ToolStripButton
    Private WithEvents chTamañoIzq As ColumnHeader
    Private WithEvents lvDirDer As ListView
    Private WithEvents chInfoDer As ColumnHeader
    Private WithEvents chNombreDer As ColumnHeader
    Private WithEvents chFechaDer As ColumnHeader
    Private WithEvents chTamañoDer As ColumnHeader
    Private WithEvents StatusStripInfo As StatusStrip
    Private WithEvents LabelInfo As ToolStripStatusLabel
    Private WithEvents ToolStripSeparator4 As ToolStripSeparator
    Private WithEvents ToolStripSeparator5 As ToolStripSeparator
    Private WithEvents btnCopiar As ToolStripButton
    Private WithEvents ToolStripSeparator1 As ToolStripSeparator
    Private WithEvents ToolStripSeparator2 As ToolStripSeparator
    Private WithEvents btnEliminar As ToolStripButton
    Private WithEvents btnMover As ToolStripButton
    Private WithEvents ToolStripSeparator6 As ToolStripSeparator
    Private WithEvents BtnNuevoDir As ToolStripButton
    Private WithEvents btnCopiarDir As ToolStripButton
    Private WithEvents btnMoverDir As ToolStripButton
    Private WithEvents btnEliminarDir As ToolStripButton
    Private WithEvents btnNuevoFichero As ToolStripButton
    Private WithEvents BtnAbrirDirIzqDropDown As ToolStripDropDownButton
    Private WithEvents BtnAbrirDirDerDropDown As ToolStripDropDownButton
    Private WithEvents ToolStripSeparator7 As ToolStripSeparator
    Private WithEvents BtnActualizar As ToolStripButton
    Private WithEvents ToolStripSeparator10 As ToolStripSeparator
    Private WithEvents ToolStripSeparator8 As ToolStripSeparator
    Private WithEvents ToolStripSeparator9 As ToolStripSeparator
    Private WithEvents BtnNuevoDropDown As ToolStripDropDownButton
    Private WithEvents ToolStripSeparator11 As ToolStripSeparator
    Private WithEvents EditarItemTextBox As TextBox
    Private WithEvents BtnRenombrar As ToolStripButton
    Private WithEvents MnuTemas As ToolStripMenuItem
    Private WithEvents MnuTemaPredeterminado As ToolStripMenuItem
    Private WithEvents MnuTemaOscuro As ToolStripMenuItem
    Private WithEvents MnuNortonCommander As ToolStripMenuItem
    Private WithEvents BtnIntercambiar As ToolStripButton
    Private WithEvents ToolStripSeparator12 As ToolStripSeparator
    Private WithEvents BtnEditar As ToolStripButton
    Private WithEvents FlowLayoutPanelIzq As FlowLayoutPanel
    Private WithEvents FlowLayoutPanelDer As FlowLayoutPanel
    Private WithEvents CboDirIzq As ComboBox
    Private WithEvents CboDirDer As ComboBox
    Private WithEvents BtnCopiarSplit As ToolStripDropDownButton
    Private WithEvents BtnMoverSplit As ToolStripDropDownButton
    Private WithEvents BtnEliminarSplit As ToolStripDropDownButton
    Private WithEvents picAdmin As ToolStripStatusLabel
    Private WithEvents LabelFechaHora As ToolStripStatusLabel
    Private WithEvents TimerFechaHora As Timer
    Private WithEvents MenuStrip1 As MenuStrip
    Private WithEvents MnuFichero As ToolStripMenuItem
    Private WithEvents MnuFicComparar As ToolStripMenuItem
    Private WithEvents MnuFicReleer As ToolStripMenuItem
    Private WithEvents ToolStripSeparator13 As ToolStripSeparator
    Private WithEvents MnuFicRenombrar As ToolStripMenuItem
    Private WithEvents MnuFicVer As ToolStripMenuItem
    Private WithEvents MnuFicEditar As ToolStripMenuItem
    Private WithEvents MnuFicCopiar As ToolStripMenuItem
    Private WithEvents MnuFicMover As ToolStripMenuItem
    Private WithEvents MnuFicNuevoDirectorio As ToolStripMenuItem
    Private WithEvents MnuFicNuevoFichero As ToolStripMenuItem
    Private WithEvents MnuFicEliminar As ToolStripMenuItem
    Private WithEvents ToolStripSeparator14 As ToolStripSeparator
    Private WithEvents MnuFicActualizar As ToolStripMenuItem
    Private WithEvents ToolStripSeparator15 As ToolStripSeparator
    Private WithEvents MnuFicIntercambiar As ToolStripMenuItem
    Private WithEvents ToolStripSeparator16 As ToolStripSeparator
    Private WithEvents MnuFicAcercaDe As ToolStripMenuItem
    Private WithEvents ToolStripSeparator17 As ToolStripSeparator
    Private WithEvents MnuFicSalir As ToolStripMenuItem
    Private WithEvents MnuVentana As ToolStripMenuItem
    Private WithEvents MnuOpciones As ToolStripMenuItem
    Private WithEvents MnuCompararAlCambiar As ToolStripMenuItem
    Private WithEvents ToolStripSeparator18 As ToolStripSeparator
    Private WithEvents MnuAvisarActualizarEnIzquierdo As ToolStripMenuItem
    Private WithEvents MnuAvisarAlActualizar As ToolStripMenuItem
    Private WithEvents ToolStripSeparator19 As ToolStripSeparator
    Private WithEvents btnComparar As ToolStripButton
    Private WithEvents BtnVer As ToolStripButton
    Private WithEvents ToolStripSeparator20 As ToolStripSeparator
    Private WithEvents MnuAcoplarIzquierda As ToolStripMenuItem
    Private WithEvents MnuAcoplarDerecha As ToolStripMenuItem
    Private WithEvents MnuDesacoplar As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator21 As ToolStripSeparator
    Friend WithEvents MnuModificarColores As ToolStripMenuItem
    Private WithEvents ToolStripSeparator22 As ToolStripSeparator
    Private WithEvents MnuColorearTiposFicheros As ToolStripMenuItem
End Class