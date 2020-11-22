'------------------------------------------------------------------------------
' Módulo para los colores de los temas a usar                       (22/Nov/20)
'
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

Module ColoresTemas
    Public VentanaFondo As Color() = {Color.FromKnownColor(KnownColor.Control), Color.Black, Color.DarkBlue}
    Public VentanaTexto As Color() = {Color.FromKnownColor(KnownColor.WindowText), Color.LightGray, Color.Cyan}
    Public PanelFondo As Color() = {Color.FromKnownColor(KnownColor.Info), Color.Black, Color.DarkBlue}
    Public PanelTexto As Color() = {Color.FromKnownColor(KnownColor.WindowText), Color.LightGray, Color.Cyan}
    Public PanelBorde As Color() = {Color.DarkGoldenrod, Color.Yellow, Color.Cyan}
    Public ItemIgual As Color() = {Color.FromKnownColor(KnownColor.WindowText), Color.LightGray, Color.Cyan}
    Public ItemFechaMayor As Color() = {Color.Blue, Color.Yellow, Color.Magenta}
    Public ItemFechaMenor As Color() = {Color.SlateBlue, Color.LightYellow, Color.DarkMagenta}
    Public ItemTamañoMayor As Color() = {Color.Green, Color.LightGreen, Color.LightGreen}
    Public ItemTamañoMenor As Color() = {Color.DarkGreen, Color.Green, Color.Green}
    Public ItemNoExiste As Color() = {Color.Firebrick, Color.LightCoral, Color.Red}
    Public ItemDirBack As Color() = {Color.LightGoldenrodYellow, Color.Gray, Color.DarkCyan}
    Public ItemDirFore As Color() = {Color.DarkOliveGreen, Color.LightGray, Color.LightGoldenrodYellow}

End Module
