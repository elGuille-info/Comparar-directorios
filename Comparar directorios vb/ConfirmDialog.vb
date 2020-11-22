'------------------------------------------------------------------------------
' ConfirmDialog formulario de cuadro de diálogo de confirmación     (20/Nov/20)
'
' Para confirmar la copia, borrado, etc. de los ficheros y directorios
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
Imports System.IO

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

    ''' <summary>
    ''' El valor de la opción configurable.
    ''' </summary>
    ''' <returns>Si no se ha indicado el texto a mostrar, devuelve Nothing, si no, devuelve True o False</returns>
    Public Shared ReadOnly Property OpcionConfigurable As Boolean?
        Get
            If String.IsNullOrEmpty(textoOpcionConfigurable) Then
                Return Nothing
            End If
            Return _opcionConfigurable.Value
        End Get
    End Property

    Private Shared _opcionConfigurable As Boolean?
    Private Shared textoOpcionConfigurable As String

    Public Sub New(message As String,
                   caption As String,
                   buttons As DialogConfirmButtons,
                   dialogIcon As DialogConfirmIcon,
                   Optional textoOpcion As String = "",
                   Optional valorOpcion As Boolean = False)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.Text = caption
        ' Hacer más alto si el texto es largo
        Dim lineas = message.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        Dim t = lineas.Length
        For i = 0 To lineas.Length - 1
            If lineas(i).Any Then
                If lineas(i).Length > 40 Then
                    t += 1 + (lineas(i).Length \ 45) '45 50 38
                End If
            End If
        Next
        If t > 8 Then
            Me.Height += (t - 8) * 17
        End If
        Me.LabelMessage.Text = message
        SetButtons(buttons)
        Select Case dialogIcon
            Case DialogConfirmIcon.Error,
                 DialogConfirmIcon.Hand, DialogConfirmIcon.Stop
                'PicIcon.Image = My.Resources._error
                Me.PicIcon.Image = ImageConvert.Base64ToImage(error_Ico)
            Case DialogConfirmIcon.Information, DialogConfirmIcon.Asterisk
                'PicIcon.Image = My.Resources.info
                Me.PicIcon.Image = ImageConvert.Base64ToImage(information_Ico)
            Case DialogConfirmIcon.Question
                'PicIcon.Image = My.Resources.help
                Me.PicIcon.Image = ImageConvert.Base64ToImage(question_Ico)
            Case DialogConfirmIcon.Exclamation, DialogConfirmIcon.Warning
                'PicIcon.Image = My.Resources.Warning
                Me.PicIcon.Image = ImageConvert.Base64ToImage(warning_Ico)
            Case Else 'DialogConfirmIcon.None
                PicIcon.Image = Nothing
        End Select

        textoOpcionConfigurable = textoOpcion
        _OpcionConfigurable = valorOpcion
        If textoOpcion.Any Then
            ChkOpcion.Text = textoOpcion
            ChkOpcion.Visible = True
            ChkOpcion.Checked = valorOpcion
        End If

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
                                          Optional dialogIcon As DialogConfirmIcon = DialogConfirmIcon.Exclamation,
                                          Optional textoOpcion As String = "",
                                          Optional valorOpcion As Boolean = False) As DialogConfirmResult
        Dim fd As New ConfirmDialog(message, caption, buttons, dialogIcon, textoOpcion, valorOpcion)
        fd.ShowDialog()

        ' Si se pulsa en NotAll comprobar si debe ser Cancel
        If confirmResult = DialogConfirmResult.NoToAll Then
            ' Si se muestra OKCancel NotToAll será Cancel
            If ConfirmDialog.buttons = Global.Comparar_directorios_vb.DialogConfirmButtons.OKCancel OrElse ConfirmDialog.buttons = Global.Comparar_directorios_vb.DialogConfirmButtons.YesNoCancel Then
                confirmResult = DialogConfirmResult.Cancel
            End If
            ' Si se pulsa Yes, comprobar si debe ser OK
        ElseIf confirmResult = DialogConfirmResult.Yes Then
            If ConfirmDialog.buttons = Global.Comparar_directorios_vb.DialogConfirmButtons.OKCancel OrElse ConfirmDialog.buttons = Global.Comparar_directorios_vb.DialogConfirmButtons.OK Then
                confirmResult = DialogConfirmResult.OK
            End If
        End If

        Return confirmResult
    End Function

    Private Shared confirmResult As DialogConfirmResult = DialogConfirmResult.Cancel
    Private Shared buttons As DialogConfirmButtons

    ''' <summary>
    ''' Mostrar los botones según el valor de buttons
    ''' y asignar el texto adecuado
    ''' </summary>
    ''' <param name="buttons">
    ''' Un valor del tipo <see cref="DialogConfirmButtons"/> 
    ''' según los botones y el texto a mostar
    ''' </param>
    Private Sub SetButtons(buttons As DialogConfirmButtons)
        ConfirmDialog.buttons = buttons

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

    Private Sub ConfirmDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub ConfirmDialog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'If e.CloseReason = CloseReason.UserClosing Then
        '    If _ConfirmResult = DialogConfirmResult.None Then
        '        _ConfirmResult = DialogConfirmResult.Cancel
        '    End If
        'End If
    End Sub

    Private Sub BtnSi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSi.Click
        confirmResult = DialogConfirmResult.Yes
        Me.Close()
    End Sub

    Private Sub BtnNoTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNoTodo.Click
        confirmResult = DialogConfirmResult.NoToAll
        Me.Close()
    End Sub

    Private Sub BtnSiTodo_Click(sender As Object, e As EventArgs) Handles BtnSiTodo.Click
        confirmResult = DialogConfirmResult.YesToAll
        Me.Close()
    End Sub

    Private Sub BtnNo_Click(sender As Object, e As EventArgs) Handles BtnNo.Click
        confirmResult = DialogConfirmResult.No
        Me.Close()
    End Sub

#Region " Las imágenes (iconos) "

    Const warning_Ico As String = "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
ZgAAAABJRU5ErkJggg=="

    Const information_Ico As String = "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
RU5ErkJggg=="

    Const error_Ico As String = "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
E6r1PJkxIJTAAAAAAElFTkSuQmCC"

    Const question_Ico As String = "iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8
YQUAABT9SURBVGhDvZkHWFVntoan3ZuZuam29KoxllgB6b2IUSNNOsTeULHEWOMYY0EkSlXKBaQoFsRI
R5oUpaM0QUTUKGKLGgtGEb751j6HUe+UzE1m5n+e79nn7LPPv9+19vrXWv85v/ol4/OlS4dQHtRWKo1q
ou5Q3U9J3st5+Vyuk+uHqKf4zw/evC/lSu1bsXx5S1BgYE16WlpzQ0PDdY4fHz582NXd3Y0eyXs5L5/L
dXK9fE++r56nr3rqf+/gjZ6nPJZ/8UWFv7//iYqKiguPHj163NnZie+//x4Np5qQlXMMEXGZ2Ox/AGt9
9uBrvwTsjE5B+pEi1NU14saNG5DradTj8vLyCzKPzCfzyvzqW/3rByfX5o2+DQgIqG5tbb1Gz3bdvHkT
JaWViEnIwubQ41jk1wjPdWfhuPos7Jafgc2y01Q9bJaegM2SY5i8JAczVh3Gpu0JyC84phjT1dX1mPNd
lXllfrmP+pb/usFJ3dasXl1fWVHR2gN+JOcowhJOYNueq/g85Doc1rTBevF5jPU+i7ELz8ByQTMsFjbx
SM2vh/n8k7CYWwnLuSUwn5mLifNS4bpwD2J2J+Pq1asSal0V5eVn5T68n7v61r98cLIl27dtq2QM3+Fj
R0VFNWISKxGSeB2LA29g8peXYOl9jrDnYOXdCquFLbCkARYLm2G+oBFmXqdgOq8exrNrYDT7BExmV8B0
dilMZxXCYuYRmE9JhPvCCGRk5qKjowPXrl37gfeTkFqqRvj5QyaJjoqqlDi/desWvk0rRGRyO1aF3YTD
6jYCCvj5vwHeBLP5pwhP8Hm1BK+B4axqGM6sgsHMChhML4P+9GMwnF4Io2nZMP7sW5h77MI6n2i0t7dD
7hcdHV35i4yQL+/iJJJFrly5gv2HyxGUeAML/K/CRMC9Cb5IvH5WDX5GATf1aoTRnHqC1kB/5kmqGvoz
Kgks4OU8lkFv2nHoTi2CzpQCaHvmQfezIzD67DAMXGLgMmc7mk6fVrJXVGSkGLFEjfTPD37JXR6jeEI8
ErG/BsFJt+G+vo2eJfQigW8leIsCbja/CbozGqA7vU6BN/Oqw/jFdZhAWXvT+zMroTutDCNdizDarRA6
nip4LY98aLrnQcstG2Nc06DnlkQjdmG8hw+ampqUTOXr63uCPPZqtJ8evFiHC6lOYlEW1+6kUgQdvMVF
epGgDBWCP+1143mNMJ5zCqvD2pBRdh9NFzrRfhO49wC4/xC4fbcb5y4/RHXTXRzMuwr3NVUY4ZSH0a55
hM+Fpms2NF2yMNo5HRrOh6Hjuh96ThFwmbkJbZcvy9O/s2rlSimCo9SIf3/woucllUk2kAWVkFQM/33X
uVC/YxY5qwL3ZoZhnFswXAxmNWD6xlaca+/CT49uRR0PHiG1sB06HtkY7pgJDZcMjHJKwwjHFIxw+BYj
HRIxZvJujLELgfeKbbh37x4KCgrOfrFs2R7y/V6N+rcHL/CQfCwp7XhJOUIOtGHBtnZ6+QzhZZGqwM3n
N1KnoDHlJLbublfx/YPBcMbjx9148KATHfc7eOYxEtLPYrj9YUKnUskY7nAIw+yT8LHtAZ7fC63J0dCz
80PCvsNSK7o3b9pUv3TJkolq1L8ehO9D75e2tLRck6oaHFuCVaHXYTy3WR0uPfBMi14NTI11GO1eBZ+Y
SyrKfzDEgC4+pM7OLsZ1J+7eva+c3xZbg/7jEwmsgh9ml4ihNgfwsc0+jLCNhY7DTpg6/AmXLrWhurr6
yrLPP8+d7+X1ohr52UED3FjWxfuPk1NzWaDaMXlVK+NeChJTo+J1gktqnFNL1WCUWwU2Rp1XYLq7JERU
Q9UqPMLjzsfqM6onIAYwLzCMOvnZI1TXX8bgTxMIfhDDBZ7eH0r4oTYJNCIWo+0joWP3DbYHRsmc3V+v
X3964YIF49TIzw4asJ+9zXnx/uqAMiwNbIPh7AYa8FQxIrjR7JMUc/osLkaXUnwd2UI8wj16gJSsKnj9
KRmOi1IxYV4KbBakwS+qHF2PH1MqeBGTCx5yLdy8eQf6zrswaNJ+DLMV7SX8bgydFE/FYrhtFLTtg2Ht
zKfQ1obEAwcueC9c+A1xf6OiVg/CD5HuUNLm0cIS+MVfgNuXLYoBxgo40+MsdTEiuCGLkf6MMj4B6X/q
UFnTggXrDqG/ZQQGfpqC4c45GOmcjWEOmQyRJATE1dDjnVwDj5QQkrXwkOL9YOcVhwHj4zHCjmFjl0Do
eBpCA2zjMMxmF0bb7oTWhK+Qmp6F77777keytro4O7+hRlcNnvSQFlcevV/wPqwOvUgvq8Fn1z4FXgmD
GT3FqAR6U4tZiAp44yQMtUuHpsdRKhcablnQcFVlmKH2KdBxS8N3bTe5gB/gPtXR8RAPOh6hk8bYzonC
e1a7GErxGDQxDh9NiKH4VCZEY/CEKAybGArNiT6Yu3iDkpG+Wrfu3KyZMyWMfq2i56ABPikpKc3SHS7Z
mAn7FU2EpccZLqoWgODSAgj8tFIWpWJVJfUshLZHAfP5UWixIGm6Z/8FXMM5jekxFUNsDsHAMw3NLZdw
+fJVtgrX2e/cwg+37+Jy+w0MsvRFX8MIvGkaSYXjTWPKNIwKxVvUu2bBGGy1BcaTPucTuIjwsLAL8+bO
XUPs36noOWhAcm1t7dXaulNwXVEMCy8BF4/39C7idQFXtwD0uja9ra1Asxixkmq6EVyBT8cox1QMnpSE
98ftRy+DeCxcn4nqqmqcPFmP5qZWXLjQjjs/3EFxeTP66vjiDdMIwobjLbMwRW8rCqV20oAQDLT0w+ix
y1FQeAx09A2vefN2E/tJTaABjay6D5KSc2C7tAymbHtV4cJY7+ldphSz/EsbIPD5Ko8TvCdcRhN8uEMK
10AS3rbch9dM4/G8bgy0nfchPSMPBUeLUVpaxU1NE862XEAXw9VnRyZe1txO6Ai8bU5o6h1FoYreNd+J
98x3YKCVP0ZarUHhsUpJp50L5s/PJ/YLlCqMaIC0yl1bg/bAflkZwdktsneRONedIvBPvK4ClxbgSZyP
oMf7jz+I1832oq9xPPoZx+FFnRgMYoqM35eJTC7ADMWIElRW1OLypcvIL65FP621Sti8Yy4SaJUB7yrw
oYQPxfsWO/GRVRBGjv0KSSn5OHv2bPcib+96YvemfttjANN/NxavCuLuqYJhogKXpksWqZayOKXxUoWL
BuE1CT5SDf6GxT6C71bDx+JF3WiYeu5HdHwGMtIycOhQOlJTs5GTU8hQqsWF85dg5LgNvXUD8B4z13uW
4XhfZBHGIyVHC4EPwwd8P2hsCEaN2wDfgF1Ku/3FF1+0Efs16r+fMWCm9xZMWFSqWpz0ugpe1TFquuUo
4Eq4sPEaZJOMt6wOEDiBiid8HBWDV/R2Mf3FY/e+DGSlZyApKY0GpCE5ORPFRaU4c6YFM5dHo5e2Hz60
3oUPx0bw+EQDn9KH1pHK54OtwzDqk834emukYgBbiovEfotSrYO/PIGV22DtVYgxHmxxKQHXYLhosGPU
cJE4z1Di/F3rRMb4XgVcgTeKoXaht34U+lvHMmxykJOVwwWXpYCLigqOIze/FJOmB+E1vW+YJmOYJiVV
RmPIxGgMfUa7FA1hOhUNnxgBrfFbEBy+v8eAS8R+j/pDjwE3Hzx40OXrH4mxczIxxj2HMZ5D4Gx6O5Pp
MIPHNOb6w3jDXBUuKq/Hoo9hDBXNVBiFP2qGw3FhIspKjivhkpV1FJmZ+ShicUxOzcfocevxplEIhn4a
i2GfxmD4pBiMsFFpJHsfleJUsonjeR5ZkTVs/xe6kzYjOaOIfdElLFm8+Dyx36f+2GNA7eXLlzsS+ait
ph/AGEmJLkcwyllaXaZF51R8xLT4urlqkSrhQq8LeG+DKPRRFIGXdMKwNTQPNdUnUVxcgaKiMmaeSqa/
MujY+CgpUaBGsM8ZRdjRdnHQsI+ndkPTPuEp7VWkYbeX1+xmOxEFI9tNyCsoxalTp7D2yy/PEvuDpw04
dOLEiavVJ05i7GcR0HZLYSuQzuyi6tMHTTqI18wSCM2QMRKvM1wI3dsgUgEX9dJjDmc+T84oR21NPcrL
a1BRUYOG+lNYuIpp0mg7RhFmlBpay4Fgjnuh7bQPOk77qQPQpeTYI21HavI+GEyOgtXkDaioPIG0tLSO
xYsW5RH7mSewOSU5uVn2vg7TfaDtclDdoyczryeq45zgPV5nrPfSJ7R+OProh/F9KHrrhWLguCh6uwon
q2tRWVmDGhoiRmhM2KSEjKZDArQcEwi3D3rO3Hm5JEKf99J35VZS0SG+plxU0nOWLeYBmDiHw3mGD27d
uo2w0NAfJjs4BBD7mTXgGRwUVCPNldfidbzJHvY3B/GRAh+njnPxusBHMtOEUwTX26moj/5O9DPcyYwR
yVxdhOPFJQyfElSUVyEvv4Qp0JetsQpc1/mAAi3Ahm6HYOiaDCM+cZVSFRmKXFMJnwxj1wMwcwzC2o1h
7F5vgnuWa4YGBrOJLVnouR4DBrIbPceF3JmSlskefLuSCt80i0Fvelzl9UiGSYQC/rLuTryiuwO9qN76
IXiN8ErfYhEOTbtwGDmHwNRlByzdw2DuFobRNlFq8EQ1+GEqBcbuqVQala6SWwYNUMnQVY4pMHNLgJXT
N8jOLcKJqqpH3NC0vvrqq6bEfpX6L8UAGTQitri4+LykKV3r+RjySSjjPUKJcwkXAX9FNxQv6+ygATvw
ik4IDQhGX4MQ9jLsWVh4BlixAFlF8DXT6dgYhlQcM04C4QX8oMrj4um/QGdQmVSWSiySRj1yPQJT92RY
ukbBbeYWtHE/sCMw8HtHR8d44g6nelGqSiyDBjj4+fnVcP/ZtWGTHwYYr8OrhkFcoKEEF/idCvxL2iE8
BtOAYFbSILzOtPg2e5b+hO9vFU7QOMxZcwirt6Zi7bZMzF6bTQMY5y6HCSgeF3CBzqZyeC6XylNk5JZP
cJG8PwIL90PczAQhdvdh3Llzp5tbyqu6urrexB1AyQ/Bz7TUr3Dnf6yxsfGqWKtlPh1vGWxhfAcq3n6Z
4C9pB1EBfB3Ac/78LIjtbwg9zqaLT0DPOQb7k3KRl5OLXCovNxfVlVWIPVjDeBbPi8cJzqqughbYo1SB
IkORi7zOgxmNHOsaA5cZvrjI3J+0d+/daVOnFr3wwgsmxH2TUsX/04NG2G719a1lVe4Ki4jCB3pL8YaB
Lz3tj5e1AvGiVgBe0pLX29GLBvQzCGLsh7B/UYXQKt8UNmxHmepyqGykp+ciJ/soGhsauNXMhzZ3aCqP
q8ANXQsJXARD5yIYOB+HvlMxj4UwccmBlftBTHDdjsPsobiREe9f09bWXk7MnvB5sh/oGTTgD3wKB48f
P36OjwweM5bhHd2VeFXXh+B+eEFzG4/baYA0Yv543TAA77A4DbAKVfqYyN15rLrFrMD5yKSkEufnF+Nk
1Ums3JKNUZPSGSb0OL1sQHB9J4E+Dj1HEXd4Dsdh6FgAC9d0WDuFYt3GcNy+fRux4eG33FxdM5977jlz
Ykr6lPz/JHyeHjRixMoVK5pZme+0trbCZNxUxYg+2hsJ74uXNP0YQt+gr/52tgVB7Bh34KNx4UrTtT0y
n7DVKCwsRUFBiXIsKalk/9+ChWvTMHpSluJxA+di6Dmx43Vg42hfxkpbhjH2pdB3KIapUxbGOkVj2pxN
aD13Ho01NQ+5kb8ycOBASZ0jqT7Uk+zztwabJXsfH5+T8tskKzRGGbnTiBXop70BvcZsYfj4oZ++P942
DcaAsaFsyCIxaFw0nLwPop67uubGRhaxBr5uZOt8HpXVjTBmtdVnqEiY6NLbCrhtObQUlUHXrhgmjkdg
6RgDB48N3Pg04MH9+90rli27oqent5lYhtS71N/3/tOD5XquFDfpUqvoVZNxU/A+18Sbeuvwuv4Wen87
NxzBDJ0wdo5RSiM22i4enp8fwq4ENnDFVcgvqIRvEHO5Uyy07bKVONd1KFE8rmlToUjLhvC2RTCZnAFL
tgxuUzfhZE2d/BqHDWvXXrG0sIggjjU1mHqF+uvY/zvj13x0XoGBgXU//vjj49Onm+ExfTE+MpiP/sZr
8YHpFgywDMRg1ovhn0YrjZn0Nhp2+zGK3aahYzR0bSIxzHo3e5x8hg7DhrGubV+CMYQW8DGTuAbs8mBq
/y2s7IOxbFUAmpvPoIOL1ufLL69ZWlpGkWMSJT/sygZG+v+f9v5T4zesfPM3btjQcPHixXvXrl1DQHAY
RhpPw1Cz5YTbjBETA6FhEw4t+xiCJrAOJLJYJfOYzqOkS1m0R2HgVAi9yceg43BMCRd9+zyY2KfC3G4X
rO02ITb+oPw7g3OnTz9eu3x5D7wtNYaStkFC59kftP7J8ds5s2c7swdpyc7OviQ/8bW2nsOadb7QsZwB
rXGrGQJ+0J+8k16OJvAemLgnKlXUhHnflJt+U1ZVY+ccmDixurI9N3dKgpkt9x52G7DBJwz1DY3oZB+W
sX//vaWLFl1nryPNmg0l8O9QUrSeVN2fMX73maenATfTqXwap9mTM6p+7K6rq0dQSDisbafDaPwCmNj+
CWaTv4GVaxjGecTgE8+9PCawIMXBwjESFnaBsLT9Gg6uKxARGY8Ggv/Y0YGq4uKHPitXfj9typSqj4cO
XcX7fUJpUG9Tvxi+Z/xWU1Ozz9QpU2ZzgdesX7++JS0l5fp9xqv8ntrefgVt7deRX1iBmIQ0bPGPx1c+
MfD1T0B0XBqO5JSg6fQ5nL/wnfKf8v27d7szExM7fFatuuk1d+45M1PTHc8//7wr7yON2sfU69T/yH2p
f9mQGPy9jo5OfxYWL4ZWBlNu+4b16y8kJyU9qKurA+sH7t+/D8lePWKXq5yvr69nm5GDoK++urfC2/uH
KZ6eFQQP6dOnzxTOa0VpUrLTkp9MZMH+rJj/qSFZQAqJ/LD0mqmJiRU3GGs8PTz2zJo5s1QaLuoBCyJ6
xPcPWeG/nz5t2kl2k2lWlpY7Bw8evJjf/5QyowT8Q5mPkpCR+f9f2ebnDPGONFRiSD9KSvxQSmAMKCn7
kr8nUPLPihzlvZyXz+U6uV6+J9+XeWS+f4vX/9GQG4rHJM29TAmMdItSNSUcxLMD1cf+lJyXz+U6uV6+
J9//j4P/3yGPXCCkUoonZb8qcBISPZL3cl4+l+vk+l8YKr/61Z8BvT6m57+Nb9YAAAAASUVORK5CYII="

#End Region

    Private Sub ChkOpcion_CheckedChanged(sender As Object, e As EventArgs) Handles ChkOpcion.CheckedChanged
        _OpcionConfigurable = ChkOpcion.Checked
    End Sub

End Class

''' <summary>
''' Clase con funciones para convertir una imagen en cadena y viceversa
''' usando Base64.
''' </summary>
''' <remarks>
''' Código adaptado de C# publicado en:
''' https://stackoverflow.com/a/18827264/14338047
''' </remarks>
Public Class ImageConvert
    ''' <summary>
    ''' Convierte una cadena (base 64) en imagen.
    ''' </summary>
    ''' <param name="base64String">La cadena con la imagen en Base64</param>
    ''' <returns>Un objeto Image con la imagen contenida en la cadena Base64</returns>
    Public Shared Function Base64ToImage(base64String As String) As Image
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)

        Using ms = New MemoryStream(imageBytes, 0, imageBytes.Length)
            Dim image As Image = Image.FromStream(ms, True)
            Return image
        End Using
    End Function

    ''' <summary>
    ''' Convertir una imagen en una cadena base 64
    ''' </summary>
    ''' <param name="image">La imagen a convertir</param>
    ''' <param name="format">El formato a usar (Bmp, png, jpeg, etc.)</param>
    ''' <returns>Devuelve la imagen en formato de cadena base 64</returns>
    Public Shared Function ImageToBase64(image As Image, format As System.Drawing.Imaging.ImageFormat) As String
        Using ms As MemoryStream = New MemoryStream()
            image.Save(ms, format)
            Dim imageBytes As Byte() = ms.ToArray()
            Dim base64String As String = Convert.ToBase64String(imageBytes)
            Return base64String
        End Using
    End Function
End Class
