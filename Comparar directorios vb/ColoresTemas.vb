'------------------------------------------------------------------------------
' Módulo para los colores de los temas a usar                       (22/Nov/20)
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

Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Módulo con los colores de los temas a usar,
''' así como la enumeración de los temas definidos (<see cref="Temas"/>) y
''' la propiedad <see cref="TemaActual"/> con el tema seleccionado.
''' </summary>
Module ColoresTemas

    ''' <summary>
    ''' Enumeración con los tipos de temas a usar
    ''' </summary>
    Public Enum Temas As Integer
        Predeterminado
        Oscuro
        ComandanteNorton
    End Enum

    ''' <summary>
    ''' El tema a usar
    ''' </summary>
    Public Property TemaActual As Temas = Temas.Predeterminado

    ''' <summary>
    ''' Asigna el tema a un control derivado de <see cref="Control"/>
    ''' </summary>
    ''' <param name="btn">El control al que se aplicará el tema actual (<see cref="TemaActual"/></param>
    ''' <param name="fondo">Array con los colores del fondo</param>
    ''' <param name="texto">Array con los colores del texto</param>
    Public Sub AsignarTema(btn As Control, fondo As Color(), texto As Color())
        btn.BackColor = fondo(TemaActual)
        btn.ForeColor = texto(TemaActual)
        If TemaActual = Temas.ComandanteNorton Then
            btn.Font = New Font(btn.Font, FontStyle.Bold)
        Else
            btn.Font = New Font(btn.Font, FontStyle.Regular)
        End If
    End Sub

    ''' <summary>
    ''' Asigna el tema a un control derivado de <see cref="ToolStripItem"/>
    ''' </summary>
    ''' <param name="btn">El control al que se aplicará el tema actual (<see cref="TemaActual"/></param>
    ''' <param name="fondo">Array con los colores del fondo</param>
    ''' <param name="texto">Array con los colores del texto</param>
    Public Sub AsignarTema(btn As ToolStripItem, fondo As Color(), texto As Color())
        btn.BackColor = fondo(TemaActual)
        btn.ForeColor = texto(TemaActual)
        If TemaActual = Temas.ComandanteNorton Then
            btn.Font = New Font(btn.Font, FontStyle.Bold)
        Else
            btn.Font = New Font(btn.Font, FontStyle.Regular)
        End If
    End Sub

    ''' <summary>
    ''' Asigna el tema a un control derivado de <see cref="ListViewItem"/>
    ''' </summary>
    ''' <param name="btn">El control al que se aplicará el tema actual (<see cref="TemaActual"/></param>
    ''' <param name="fondo">Array con los colores del fondo</param>
    ''' <param name="texto">Array con los colores del texto</param>
    Public Sub AsignarTema(btn As ListViewItem, fondo As Color(), texto As Color())
        btn.BackColor = fondo(TemaActual)
        btn.ForeColor = texto(TemaActual)
        If TemaActual = Temas.ComandanteNorton Then
            btn.Font = New Font(btn.Font, FontStyle.Bold)
        Else
            btn.Font = New Font(btn.Font, FontStyle.Regular)
        End If
    End Sub

    ''' <summary>
    ''' Asigna el tema a los controles contenidos en el control de tipo <see cref="ToolStrip"/>
    ''' </summary>
    ''' <param name="elControl">
    ''' El control <see cref="ToolStrip"/> con los controles 
    ''' a los que se asignarán los colores
    ''' </param>
    ''' <param name="fondo">Array con los colores del fondo</param>
    ''' <param name="texto">Array con los colores del texto</param>
    Public Sub AsignarTemaBotones(elControl As ToolStrip, fondo As Color(), texto As Color())
        For Each btn As ToolStripItem In elControl.Items
            AsignarTema(btn, fondo, texto)
        Next
    End Sub


    Public ReadOnly Property BotonesFondo As Color() = {Color.FromKnownColor(KnownColor.Control), Color.FromArgb(80, 80, 80), Color.MediumBlue}
    Public ReadOnly Property BotonesTexto As Color() = {Color.Black, Color.Yellow, Color.Yellow}
    Public ReadOnly Property StatusFondo As Color() = {Color.FloralWhite, Color.LightGray, Color.Cyan}
    Public ReadOnly Property StatusTexto As Color() = {Color.Black, Color.Black, Color.MediumBlue}
    Public ReadOnly Property VentanaFondo As Color() = {Color.FromKnownColor(KnownColor.Control), Color.Black, Color.MediumBlue}
    Public ReadOnly Property VentanaTexto As Color() = {Color.FromKnownColor(KnownColor.WindowText), Color.LightGray, Color.Cyan}
    Public ReadOnly Property PanelFondo As Color() = {Color.FromKnownColor(KnownColor.Info), Color.Black, Color.MediumBlue}
    Public ReadOnly Property PanelTexto As Color() = {Color.FromKnownColor(KnownColor.WindowText), Color.LightGray, Color.Cyan}
    Public ReadOnly Property PanelBordeActivo As Color() = {Color.DarkGoldenrod, Color.Yellow, Color.Yellow}
    Public ReadOnly Property PanelBorde As Color() = {Color.FromKnownColor(KnownColor.Control), Color.LightGray, Color.MediumBlue}

    ' Los colores de los elementos
    Public ReadOnly Property ItemIgual As Color() = {Color.FromKnownColor(KnownColor.WindowText), Color.LightGray, Color.Cyan}
    Public ReadOnly Property ItemFechaMayor As Color() = {Color.MediumBlue, Color.Yellow, Color.Yellow}
    Public ReadOnly Property ItemFechaMenor As Color() = {Color.SlateBlue, Color.LightBlue, Color.LightBlue}
    Public ReadOnly Property ItemTamañoMayor As Color() = {Color.Green, Color.LightGreen, Color.LightGreen}
    Public ReadOnly Property ItemTamañoMenor As Color() = {Color.DarkGreen, Color.Green, Color.Green}
    Public ReadOnly Property ItemNoExiste As Color() = {Color.Firebrick, Color.LightCoral, Color.Salmon}
    ''' <summary>
    ''' Color para los ficheros indicados en <see cref="ExtensionesBin"/>
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ItemBin As Color() = {Color.DarkSlateBlue, Color.GreenYellow, Color.YellowGreen}
    Public ReadOnly Property ItemVisor As Color() = {Color.DarkSlateGray, Color.YellowGreen, Color.GreenYellow}

    ''' <summary>
    ''' Las extensiones consideradas como ficheros binarios
    ''' </summary>
    Public ReadOnly ExtensionesBin As New HashSet(Of String) From {".zip", ".exe", ".obj", ".pdb", ".dll", ".com", ".bin", ".tlb", ".lnk", ".ocx"}

    ' Los colores de los directorios
    Public ReadOnly Property ItemDirBack As Color() = {Color.LightGoldenrodYellow, Color.FromArgb(64, 64, 64), Color.DarkCyan}
    Public ReadOnly Property ItemDirFore As Color() = {Color.DarkOliveGreen, Color.GhostWhite, Color.LightGoldenrodYellow}

End Module
