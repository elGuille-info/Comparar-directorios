'------------------------------------------------------------------------------
' TarHeader
' Clase para manipular el contenido de los archivos .tar
'
' Ejemplo para el libro Manual Imprescindible de Visual Basic 2005
'
' ©Guillermo 'guille' Som, 2006
'------------------------------------------------------------------------------
Option Strict On
Option Explicit On

Imports Microsoft.VisualBasic
Imports vb = Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Text

Public Class Tar
    Implements IComparable

    Private h0_arch_name As String ' 100
    ' La posición dentro del .tar
    Private m_pos As Long
    Private m_Size As Integer
    Private m_DateTime As DateTime
    Private m_FileName As String
    Private m_DirectoryName As String

    Public Shared Function FromByteArray(bytes() As Byte, pos As Long) As Tar
        '  0   100   108   116 124 136
        '100, no_8, no_8, no_8, 12, 12
        Dim ht As New Tar
        Dim utf8Enc As New UTF8Encoding()
        Dim arch As String = utf8Enc.GetString(bytes, 0, 100).Replace(ChrW(0), "").Trim

        ' Si el nombre es una cadena vacía,
        ' devolver un objeto vacío
        If vb.Len(arch) = 0 Then
            Return New Tar
        End If

        ht.FullFileName = arch
        ht.m_Size = octToInt(utf8Enc.GetString(bytes, 124, 12).Replace(ChrW(0), "").Trim)
        ht.m_DateTime = octToDate(utf8Enc.GetString(bytes, 136, 12).Replace(ChrW(0), "").Trim)
        ht.m_pos = pos

        Return ht
    End Function

    Private Sub New()
    End Sub

    Public Sub New(arch_name As String, size As String, mtime As String)
        Me.FullFileName = arch_name.Trim
        Me.m_Size = octToInt(size.Trim)
        Me.m_DateTime = octToDate(mtime.Trim)
    End Sub

    Public Sub New(arch_name As String, size As String, mtime As String, pos As Long)
        Me.FullFileName = arch_name.Trim
        Me.m_Size = octToInt(size.Trim)
        Me.m_DateTime = octToDate(mtime.Trim)
        Me.m_pos = pos
    End Sub

    Public Overrides Function ToString() As String
        Dim sb As New StringBuilder
        sb.AppendFormat("{0}{1}", Me.FullFileName, vbCrLf)
        sb.AppendFormat("{0}{1}", Me.Size.ToString("#,##0"), vbCrLf)
        sb.AppendFormat("{0}{1}", Me.DateTime.ToString("dd/MM/yyyy HH:mm:ss"), vbCrLf)

        Return sb.ToString()
    End Function


    Public ReadOnly Property DateTime() As DateTime
        Get
            Return m_DateTime
        End Get
    End Property

    Public ReadOnly Property Size() As Integer
        Get
            Return m_Size
        End Get
    End Property

    Public Property FullFileName() As String
        Get
            Return h0_arch_name
        End Get
        Private Set(value As String)
            If vb.Len(value) > 0 Then
                h0_arch_name = value
                m_FileName = Path.GetFileName(value)
                m_DirectoryName = Path.GetDirectoryName(value)
            End If
        End Set
    End Property

    Public ReadOnly Property FileName() As String
        Get
            Return m_FileName
        End Get
    End Property

    Public ReadOnly Property DirectoryName() As String
        Get
            Return m_DirectoryName
        End Get
    End Property

    Private m_archivoTar As String
    Friend Property archivoTar() As String
        Get
            Return m_archivoTar
        End Get
        Set(value As String)
            m_archivoTar = value
        End Set
    End Property

    Public Function LeerContenido() As String
        Dim ret As String = ""

        If File.Exists(m_archivoTar) = False Then Return ret

        Using fs As New FileStream(m_archivoTar, FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim bytes(0 To Me.Size - 1) As Byte
            fs.Position = Me.m_pos
            fs.Read(bytes, 0, Me.Size)
            ret = New UTF8Encoding().GetString(bytes)
        End Using

        Return ret
    End Function

    'Private Function LeerContenido(archTar As String) As String
    '    Dim ret As String = ""

    '    If File.Exists(archTar) = False Then Return ret

    '    Using fs As New FileStream(archTar, FileMode.Open, FileAccess.Read, FileShare.Read)
    '        Dim bytes(0 To Me.Size - 1) As Byte
    '        fs.Position = Me.m_pos
    '        fs.Read(bytes, 0, Me.Size)
    '        ret = New UTF8Encoding().GetString(bytes)
    '    End Using

    '    Return ret
    'End Function
    '
    '--------------------------------------------------------------------------
    ' Funciones para convertir los datos de la cabecera del .tar
    ' Adaptadas de un programa para VB6 de Marco v/d Berg y John Korejwa
    '--------------------------------------------------------------------------
    '
    Private Shared Function octToDate(mtime As String) As DateTime
        Dim octDate As Integer = octToInt(mtime)
        Dim doubleDateTime As Double = vb.DateSerial(1970, 1, 1).ToOADate() + CDbl(octDate / 86400)

        Return Date.FromOADate(doubleDateTime).ToLocalTime
    End Function

    Private Shared Function octToInt(octVal As String) As Integer
        Dim octNum As String
        Dim res As Integer

        octNum = octVal.Replace(ChrW(0), "").Trim
        ' Quitar los ceros del principio
        Do While vb.Left(octNum, 1) = "0"
            octNum = vb.Mid(octNum, 2)
        Loop
        For i As Integer = 1 To vb.Len(octNum)
            'res = CInt(res + CInt(vb.Val(vb.Mid(octNum, i, 1))) * 8 ^ (vb.Len(octNum) - i))
            res = CInt(res + CInt(vb.Mid(octNum, i, 1)) * 8 ^ (vb.Len(octNum) - i))
        Next

        Return res
    End Function


    Public Function CompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
        If TypeOf obj Is Tar Then
            Dim objTH As Tar = DirectCast(obj, Tar)
            'Return String.Compare(Me.FullFileName, objTH.FullFileName)
            'Return String.Compare(Me.DirectoryName, objTH.DirectoryName)
            Return String.Compare(Me.DirectoryName & "." & Me.FileName, objTH.DirectoryName & "." & objTH.FileName)
        Else
            Return String.Compare(Me.ToString, obj.ToString)
        End If
    End Function
End Class
