<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConfirmDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfirmDialog))
        Me.BtnNo = New System.Windows.Forms.Button()
        Me.BtnSiTodo = New System.Windows.Forms.Button()
        Me.BtnSi = New System.Windows.Forms.Button()
        Me.BtnNoTodo = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelMessage = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
        Me.PicIcon = New System.Windows.Forms.PictureBox()
        Me.ChkOpcion = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanelBotones.SuspendLayout()
        CType(Me.PicIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnNo
        '
        Me.BtnNo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnNo.Location = New System.Drawing.Point(304, 6)
        Me.BtnNo.Margin = New System.Windows.Forms.Padding(0, 6, 12, 6)
        Me.BtnNo.Name = "BtnNo"
        Me.BtnNo.Size = New System.Drawing.Size(73, 23)
        Me.BtnNo.TabIndex = 2
        Me.BtnNo.Text = "No"
        Me.ToolTip1.SetToolTip(Me.BtnNo, "No copiar este y seguir")
        '
        'BtnSiTodo
        '
        Me.BtnSiTodo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnSiTodo.Location = New System.Drawing.Point(219, 6)
        Me.BtnSiTodo.Margin = New System.Windows.Forms.Padding(0, 6, 12, 6)
        Me.BtnSiTodo.Name = "BtnSiTodo"
        Me.BtnSiTodo.Size = New System.Drawing.Size(73, 23)
        Me.BtnSiTodo.TabIndex = 1
        Me.BtnSiTodo.Text = "Sí a Todo"
        Me.ToolTip1.SetToolTip(Me.BtnSiTodo, "Copiar este y todos los restantes sin pedir más confirmación")
        '
        'BtnSi
        '
        Me.BtnSi.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnSi.Location = New System.Drawing.Point(132, 6)
        Me.BtnSi.Margin = New System.Windows.Forms.Padding(0, 6, 12, 6)
        Me.BtnSi.Name = "BtnSi"
        Me.BtnSi.Size = New System.Drawing.Size(75, 23)
        Me.BtnSi.TabIndex = 0
        Me.BtnSi.Text = "Sí"
        Me.ToolTip1.SetToolTip(Me.BtnSi, "Copiar este y seguir preguntando si existen los siguientes")
        '
        'BtnNoTodo
        '
        Me.BtnNoTodo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnNoTodo.Location = New System.Drawing.Point(389, 6)
        Me.BtnNoTodo.Margin = New System.Windows.Forms.Padding(0, 6, 12, 6)
        Me.BtnNoTodo.Name = "BtnNoTodo"
        Me.BtnNoTodo.Size = New System.Drawing.Size(73, 23)
        Me.BtnNoTodo.TabIndex = 3
        Me.BtnNoTodo.Text = "No a Todo"
        Me.ToolTip1.SetToolTip(Me.BtnNoTodo, "No copiar este y cancelar la copia")
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.LabelMessage)
        Me.Panel1.Controls.Add(Me.PicIcon)
        Me.Panel1.Location = New System.Drawing.Point(17, 17)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(440, 134)
        Me.Panel1.TabIndex = 1
        '
        'LabelMessage
        '
        Me.LabelMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMessage.BackColor = System.Drawing.SystemColors.Control
        Me.LabelMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LabelMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMessage.Location = New System.Drawing.Point(124, 8)
        Me.LabelMessage.Margin = New System.Windows.Forms.Padding(8)
        Me.LabelMessage.Multiline = True
        Me.LabelMessage.Name = "LabelMessage"
        Me.LabelMessage.Size = New System.Drawing.Size(308, 118)
        Me.LabelMessage.TabIndex = 1
        Me.LabelMessage.TabStop = False
        Me.LabelMessage.Text = "LabelMessage" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "223456789-123456789-123456789-123456789-123456789-123456789-" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "5" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "6" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "8" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "10" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "11" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "12" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "13"
        '
        'FlowLayoutPanelBotones
        '
        Me.FlowLayoutPanelBotones.Controls.Add(Me.BtnNoTodo)
        Me.FlowLayoutPanelBotones.Controls.Add(Me.BtnNo)
        Me.FlowLayoutPanelBotones.Controls.Add(Me.BtnSiTodo)
        Me.FlowLayoutPanelBotones.Controls.Add(Me.BtnSi)
        Me.FlowLayoutPanelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanelBotones.Location = New System.Drawing.Point(0, 185)
        Me.FlowLayoutPanelBotones.Name = "FlowLayoutPanelBotones"
        Me.FlowLayoutPanelBotones.Size = New System.Drawing.Size(474, 41)
        Me.FlowLayoutPanelBotones.TabIndex = 2
        '
        'PicIcon
        '
        Me.PicIcon.Image = CType(resources.GetObject("PicIcon.Image"), System.Drawing.Image)
        Me.PicIcon.Location = New System.Drawing.Point(8, 27)
        Me.PicIcon.Margin = New System.Windows.Forms.Padding(8)
        Me.PicIcon.Name = "PicIcon"
        Me.PicIcon.Size = New System.Drawing.Size(100, 79)
        Me.PicIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicIcon.TabIndex = 0
        Me.PicIcon.TabStop = False
        '
        'ChkOpcion
        '
        Me.ChkOpcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkOpcion.AutoSize = True
        Me.ChkOpcion.Location = New System.Drawing.Point(17, 162)
        Me.ChkOpcion.Name = "ChkOpcion"
        Me.ChkOpcion.Size = New System.Drawing.Size(121, 17)
        Me.ChkOpcion.TabIndex = 3
        Me.ChkOpcion.Text = "Opción configurable"
        Me.ChkOpcion.UseVisualStyleBackColor = True
        Me.ChkOpcion.Visible = False
        '
        'ConfirmDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 226)
        Me.ControlBox = False
        Me.Controls.Add(Me.ChkOpcion)
        Me.Controls.Add(Me.FlowLayoutPanelBotones)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(451, 242)
        Me.Name = "ConfirmDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ConfirmDialog"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.FlowLayoutPanelBotones.ResumeLayout(False)
        CType(Me.PicIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents BtnSi As Button
    Private WithEvents BtnSiTodo As Button
    Private WithEvents BtnNoTodo As Button
    Private WithEvents BtnNo As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Panel1 As Panel
    Private WithEvents LabelMessage As TextBox
    Private WithEvents PicIcon As PictureBox
    Private WithEvents FlowLayoutPanelBotones As FlowLayoutPanel
    Private WithEvents ChkOpcion As CheckBox
End Class
