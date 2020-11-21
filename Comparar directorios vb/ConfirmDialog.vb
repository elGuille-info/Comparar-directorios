'------------------------------------------------------------------------------
' ConfirmDialog formulario de cuadro de diálogo de confiramción     (20/Nov/20)
'
' Para confirmar la copia, borrado, etc. de los ficheros y directorios
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


Imports System.Windows.Forms

#Region " Enumeraciones para el cuadro de diálogo "

''' <summary>
''' Enumeración del resultado de mostrar el cuadro de diálogo
''' </summary>
Public Enum DialogConfirmResult
    None = DialogResult.None ' 0
    OK = DialogResult.OK ' 1
    Cancel = DialogResult.Cancel ' 2
    Abort = DialogResult.Abort ' 3
    Retry = DialogResult.Retry ' 4
    Ignore = DialogResult.Ignore ' 5
    Yes = DialogResult.Yes ' 6
    No = DialogResult.No ' 7
    '
    YesToAll = 8
    NoToAll = DialogResult.Cancel ' 2 ¿9?
End Enum

''' <summary>
''' Los botones a mostrar en el cuadro de diálogo.
''' Por ahora:
'''     All: todos los botones: Sí, Sí a todo, No y No a todo
'''     YesNo: los botones Sí y No
'''     YesNoCancel: los botones Sí, No y No a todo con el texto Cancelar/Cancel
'''     OK: el botón Sí con el texto Aceptar/OK
'''     OKCancel: los botones Sí con el texto Aceptar y No a todo con el texto Cancelar
''' </summary>
Public Enum DialogConfirmButtons
    OK = MessageBoxButtons.OK ' 0
    OKCancel = MessageBoxButtons.OKCancel ' 1
    'AbortRetryIgnore = MessageBoxButtons.AbortRetryIgnore ' 2
    YesNoCancel = MessageBoxButtons.YesNoCancel ' 3
    YesNo = MessageBoxButtons.YesNo ' 4
    'RetryCancel = MessageBoxButtons.RetryCancel ' 5
    '
    All = 255 ' 255 (mostrar todos los botones)
End Enum

''' <summary>
''' La imagen a mostrar en el cuadro de diálogo
''' </summary>
Public Enum DialogConfirmIcon
    ''' <summary>
    ''' Una X blanca en un círculo con un fondo rojo.
    ''' </summary>
    Asterisk = MessageBoxIcon.Asterisk ' 64
    ''' <summary>
    ''' Una X blanca en un círculo con un fondo rojo.
    ''' </summary>
    [Error] = MessageBoxIcon.Error ' 16
    ''' <summary>
    ''' Un signo de exclamación en un triángulo con un fondo amarillo.
    ''' </summary>
    Exclamation = MessageBoxIcon.Exclamation ' 48
    ''' <summary>
    ''' Una X blanca en un círculo con un fondo rojo.
    ''' </summary>
    Hand = MessageBoxIcon.Hand ' 16
    ''' <summary>
    ''' Una i minúscula en un círculo.
    ''' </summary>
    Information = MessageBoxIcon.Information ' 64
    ''' <summary>
    ''' No contiene ningún símbolo.
    ''' </summary>
    None = MessageBoxIcon.None ' 0
    ''' <summary>
    ''' Un signo de interrogación en un círculo. Ya no se recomienda el icono de mensaje con el signo de interrogación, porque no representa claramente un tipo específico de mensaje y porque la formulación de un mensaje como una pregunta podría aplicarse a cualquier tipo de mensaje. Además, los usuarios pueden confundir el símbolo de interrogación con el de información de ayuda. Por lo tanto, no use este símbolo de interrogación en los cuadros de mensaje. El sistema sigue permitiendo que se incluya únicamente por cuestiones de compatibilidad con versiones anteriores.
    ''' </summary>
    Question = MessageBoxIcon.Question ' 32
    ''' <summary>
    ''' Una X blanca en un círculo con un fondo rojo.
    ''' </summary>
    [Stop] = MessageBoxIcon.Stop ' 16
    ''' <summary>
    ''' Un signo de exclamación en un triángulo con un fondo amarillo.
    ''' </summary>
    Warning = MessageBoxIcon.Warning ' 48
End Enum

#End Region

Public Class ConfirmDialog

    Public Sub New(message As String,
                   caption As String,
                   buttons As DialogConfirmButtons,
                   dialogIcon As DialogConfirmIcon)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Text = caption
        Me.Label1.Text = message
        SetButtons(buttons)
        Select Case dialogIcon
            Case DialogConfirmIcon.Error,
                 DialogConfirmIcon.Hand, DialogConfirmIcon.Stop
                PicIcon.Image = My.Resources._error
            Case DialogConfirmIcon.Information, DialogConfirmIcon.Asterisk
                PicIcon.Image = My.Resources.info
            Case DialogConfirmIcon.Question
                PicIcon.Image = My.Resources.help
            Case DialogConfirmIcon.Exclamation, DialogConfirmIcon.Warning
                PicIcon.Image = My.Resources.Warning
            Case Else 'DialogConfirmIcon.None
                PicIcon.Image = Nothing
        End Select
    End Sub

    ''' <summary>
    ''' Muestra la ventana del cuadro de confirmación.
    ''' </summary>
    ''' <param name="message">El mensaje a mostrar en el cuadro de diálogo</param>
    ''' <param name="caption">El título a mostrar en el cuadro de diálogo</param>
    ''' <param name="buttons">Los botones a mostrar (uno de lso indicados en <see cref="DialogConfirmButtons"/></param>
    ''' <returns>Devuelve un valor de <see cref="DialogConfirmResult"/></returns>
    Public Overloads Shared Function Show(message As String,
                                          Optional caption As String = "Diálogo de confirmación",
                                          Optional buttons As DialogConfirmButtons = DialogConfirmButtons.All,
                                          Optional dialogIcon As DialogConfirmIcon = DialogConfirmIcon.Exclamation) As DialogConfirmResult
        Dim fd As New ConfirmDialog(message, caption, buttons, dialogIcon)
        fd.ShowDialog()

        ' Si se pulsa en NotAll comprobar si debe ser Cancel
        If _ConfirmResult = DialogConfirmResult.NoToAll Then
            ' Si se muestra OKCancel NotToAll será Cancel
            If _Buttons = DialogConfirmButtons.OKCancel OrElse _Buttons = DialogConfirmButtons.YesNoCancel Then
                _ConfirmResult = DialogConfirmResult.Cancel
            End If
            ' Si se pulsa Yes, comprobar si debe ser OK
        ElseIf _ConfirmResult = DialogConfirmResult.Yes Then
            If _Buttons = DialogConfirmButtons.OKCancel OrElse _Buttons = DialogConfirmButtons.OK Then
                _ConfirmResult = DialogConfirmResult.OK
            End If
        End If

        Return _ConfirmResult
    End Function

    'Private Shared _Icon As DialogConfirmIcon = DialogConfirmIcon.None
    Private Shared _ConfirmResult As DialogConfirmResult = DialogConfirmResult.Cancel
    Private Shared _Buttons As DialogConfirmButtons

    ''' <summary>
    ''' Mostrar los botones según el valor de buttons
    ''' y asignar el texto adecuado
    ''' </summary>
    ''' <param name="buttons">
    ''' Un valor del tipo <see cref="DialogConfirmButtons"/> 
    ''' según los botones y el texto a mostar
    ''' </param>
    Private Sub SetButtons(buttons As DialogConfirmButtons)
        _Buttons = buttons

        ' Asignar y mostrar el texto adecuado
        If buttons = DialogConfirmButtons.All Then Return
        If buttons = DialogConfirmButtons.OK Then
            ' mostrar solo Sí
            BtnSi.Text = "Aceptar"
            BtnSiTodo.Visible = False
            BtnNo.Visible = False
            BtnNoTodo.Visible = False
            FlowLayoutPanelBotones.Controls.Remove(BtnSiTodo)
            FlowLayoutPanelBotones.Controls.Remove(BtnNo)
            FlowLayoutPanelBotones.Controls.Remove(BtnNoTodo)
        ElseIf buttons = DialogConfirmButtons.OKCancel Then
            ' mostrar sí, no a todo
            BtnSi.Text = "Aceptar"
            BtnNoTodo.Text = "Cancelar"
            BtnSiTodo.Visible = False
            BtnNo.Visible = False
            FlowLayoutPanelBotones.Controls.Remove(BtnSiTodo)
            FlowLayoutPanelBotones.Controls.Remove(BtnNo)
        ElseIf buttons = DialogConfirmButtons.YesNo Then
            BtnSi.Text = "Sí"
            BtnNo.Text = "No"
            BtnSiTodo.Visible = False
            BtnNoTodo.Visible = False
            FlowLayoutPanelBotones.Controls.Remove(BtnSiTodo)
            FlowLayoutPanelBotones.Controls.Remove(BtnNoTodo)
        ElseIf buttons = DialogConfirmButtons.YesNoCancel Then
            BtnSi.Text = "Sí"
            BtnNo.Text = "No"
            BtnNoTodo.Text = "Cancelar"
            BtnSiTodo.Visible = False
            FlowLayoutPanelBotones.Controls.Remove(BtnSiTodo)
        End If
    End Sub


    'Private WriteOnly Property Buttons As DialogConfirmButtons
    '    Set(value As DialogConfirmButtons)
    '        _Buttons = value
    '        ' Asignar y mostrar el texto adecuado
    '        SetButtons(value)
    '    End Set
    'End Property

    '''' <summary>
    '''' El texto a mostar en el título del cuadro de diálogo
    '''' </summary>
    'Public WriteOnly Property Caption As String
    '    Set(value As String)
    '        Me.Text = value
    '    End Set
    'End Property

    '''' <summary>
    '''' El mensaje a mostrar en el cuadro de diálogo
    '''' </summary>
    'Public WriteOnly Property Message As String
    '    Set(value As String)
    '        Me.Label1.Text = value
    '    End Set
    'End Property

    Private Sub ConfirmDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Private Sub ConfirmDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '    If e.CloseReason = CloseReason.UserClosing Then
    '        _ConfirmResult = DialogConfirmResult.Cancel
    '    End If
    'End Sub

    Private Sub BtnSi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSi.Click
        _ConfirmResult = DialogConfirmResult.Yes
        Me.Close()
    End Sub

    Private Sub BtnNoTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNoTodo.Click
        _ConfirmResult = DialogConfirmResult.NoToAll
        Me.Close()
    End Sub

    Private Sub BtnSiTodo_Click(sender As Object, e As EventArgs) Handles BtnSiTodo.Click
        _ConfirmResult = DialogConfirmResult.YesToAll
        Me.Close()
    End Sub

    Private Sub BtnNo_Click(sender As Object, e As EventArgs) Handles BtnNo.Click
        _ConfirmResult = DialogConfirmResult.No
        Me.Close()
    End Sub

End Class
