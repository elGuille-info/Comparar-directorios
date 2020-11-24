'------------------------------------------------------------------------------
' Ejemplo para el libro Manual Imprescindible de Visual Basic 2005
'
' Aplicación Windows para comprimir/descomprimir usando las clases de .NET 2.0
'
' Esta clase sirve para leer el contenido de los archivos .tar
' También se inlcuyen métodos para extraer el .tar de un .tar.gz
'
' ©Guillermo 'guille' Som, 2006
'------------------------------------------------------------------------------
Option Strict On
Option Explicit On

Imports Microsoft.VisualBasic
Imports vb = Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections.Generic

Public Class UtilTar

    Public Shared Function ArchivosTar(arch As String) As List(Of Tar)
        ' Leer el contenido del archivo con formato tar
        ' y devolver cada archivo como un elemento de una lista del tipo Tar

        Return leerContenidoTar(arch)
    End Function

    Private Shared Function leerContenidoTar(archCompri As String) As List(Of Tar)
        Dim archs As New List(Of Tar)
        Dim arch As String = archCompri

        ' No lanzar un error, devolver la colección vacia
        If File.Exists(arch) = False Then
            Throw New FileNotFoundException(String.Format("No existe el archivo '{0}'", arch))
            'Return archs
        End If

        Select Case UtilCompress.Formato(arch)
            Case FormatosCompresion.TarGZip
                ' Extraer el archivo .tar
                arch = Path.GetTempFileName & ".tar"
                UtilCompress.DescomprimirGZip(arch, archCompri)

            Case FormatosCompresion.Tar
                ' Es tar sin comprimir, nada especial que hacer
            Case Else
                Throw New FormatoIncorrectoException
                'Return archs
        End Select

        Dim bytesCabecera(0 To 511) As Byte
        Dim ht As Tar
        Dim posArch As Long
        '
        Using fs As New FileStream(arch, FileMode.Open, FileAccess.Read, FileShare.Read)
            While fs.Read(bytesCabecera, 0, 512) > 0
                posArch = fs.Position
                ht = Tar.FromByteArray(bytesCabecera, posArch)
                If ht.Size > 0 Then
                    ' El nombre del archivo .tar lo guardamos en cada objeto,
                    ' por si estaba comprimido y es un archivo temporal.
                    ht.archivoTar = arch
                    archs.Add(ht)
                End If

                ' Ajustarlo a múltiplos de 512
                Dim offset As Long = ht.Size
                While offset > 0
                    posArch += 512
                    offset -= 512
                End While
                fs.Position = posArch
            End While
        End Using
        '
        Return archs
    End Function

End Class
