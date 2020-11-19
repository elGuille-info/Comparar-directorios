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

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lvDirDer.Items.Clear()
        lvDirIzq.Items.Clear()

        Dim dirCfg = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim ficCfg As String

        ficCfg = "Mostrar2Directorios_Izq.config.txt"
        Dim fic = Path.Combine(dirCfg, ficCfg)
        Dim dIzq As String
        If File.Exists(fic) Then
            Using sr As New StreamReader(fic, Encoding.Default, True)
                dIzq = sr.ReadLine
                sr.Close()
            End Using

            ' Mostrar los ficheros en el panel izquierdo
            MostrarDirectorio(dIzq, lvDirIzq)
        End If

        ficCfg = "Mostrar2Directorios_Der.config.txt"
        fic = Path.Combine(dirCfg, ficCfg)
        If File.Exists(fic) Then
            Using sr As New StreamReader(fic, Encoding.Default, True)
                dIzq = sr.ReadLine
                sr.Close()
            End Using

            ' Mostrar los ficheros en el panel derecho
            MostrarDirectorio(dIzq, lvDirDer)
        End If

    End Sub

    Private Sub BtnAbrirDirIzquierdo_Click(sender As Object, e As EventArgs) Handles btnAbrirDirIzquierdo.Click
        AbrirCarpeta(lvDirIzq)
    End Sub

    Private Sub BtnAbrirDirDerecho_Click(sender As Object, e As EventArgs) Handles btnAbrirDirDerecho.Click
        AbrirCarpeta(lvDirDer)
    End Sub

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

        ' Guardar el nombre del directorio abierto
        Dim dirCfg = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        Dim ficCfg As String
        If lv Is lvDirIzq Then
            ficCfg = "Mostrar2Directorios_Izq.config.txt"
        Else
            ficCfg = "Mostrar2Directorios_Der.config.txt"
        End If
        Dim fic = Path.Combine(dirCfg, ficCfg)
        Using sw As New StreamWriter(fic, False, Encoding.Default)
            sw.Write(fb.SelectedPath)
            sw.Flush()
            sw.Close()
        End Using

        MostrarDirectorio(fb.SelectedPath, lv)
    End Sub

    Private Sub MostrarDirectorio(sDir As String, lv As ListView)
        lv.Tag = sDir
        Dim dir = New DirectoryInfo(sDir)

        If lv Is lvDirIzq Then
            LabelIzq.Text = dir.FullName ' dir.Name
            'LabelIzq.ToolTipText = dir.FullName
        Else
            LabelDer.Text = dir.FullName ' dir.Name
            'LabelDer.ToolTipText = dir.FullName
        End If

        Dim dirs = dir.GetDirectories
        Dim files = dir.GetFiles
        lv.Items.Clear()
        If dir.Parent IsNot Nothing Then
            Dim it = lv.Items.Add("..")
            it.BackColor = Color.Yellow
            it.Tag = dir.Parent.FullName
            it.Checked = False
            it.ToolTipText = dir.Parent.FullName
        End If
        For Each di In dirs
            Dim it = lv.Items.Add("DIR")
            it.SubItems.Add(di.Name)
            it.SubItems.Add(di.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss"))
            it.ForeColor = Color.DarkOliveGreen
            it.BackColor = Color.LightGoldenrodYellow
            it.Checked = False
            it.Tag = di.FullName
            it.ToolTipText = di.FullName
            'it.Font = New Font(it.Font, FontStyle.Bold)
        Next
        For Each fi In files
            Dim it = lv.Items.Add("")
            it.SubItems.Add(fi.Name)
            it.SubItems.Add(fi.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss"))
            it.Checked = False
            it.Tag = Nothing
        Next

    End Sub

    Private Sub LvDirIzq_DoubleClick(sender As Object, e As EventArgs) Handles lvDirIzq.DoubleClick, lvDirIzq.Click
        IrParentDir(lvDirIzq)
    End Sub

    Private Sub LvDirDer_DoubleClick(sender As Object, e As EventArgs) Handles lvDirDer.DoubleClick, lvDirDer.Click
        IrParentDir(lvDirDer)
    End Sub

    Private Sub IrParentDir(lv As ListView)
        ' Comprobar si es un elemento con directorio
        If lv.SelectedItems.Count > 0 Then
            ' ir a ese directorio
            Dim sDir = lv.SelectedItems(0).Tag.ToString
            If Not String.IsNullOrEmpty(sDir) Then
                MostrarDirectorio(sDir, lv)
            End If
        End If
    End Sub

    Private Sub BtnComparar_Click(sender As Object, e As EventArgs) Handles btnComparar.Click
        ' Comparar el contenido de los 2 directorios

    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        MostrarDirectorio(lvDirIzq.Tag.ToString, lvDirIzq)
        MostrarDirectorio(lvDirDer.Tag.ToString, lvDirDer)
    End Sub
End Class
