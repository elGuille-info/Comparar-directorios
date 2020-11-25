'------------------------------------------------------------------------------
' Ejemplo para el libro Manual Imprescindible de Visual Basic 2005
'
' Aplicación Windows para comprimir/descomprimir usando las clases de .NET 4.8
'
' Para saber más de los formatos usados por GZipStream y DeflateStream
' ver la página de gzip: http://www.gzip.org/
'
' Para saber más sobre las dos especificaciones:
' http://www.ietf.org/rfc/rfc1951.txt
' http://www.ietf.org/rfc/rfc1952.txt
'
' Especificación del formato Zip
' https://docs.fileformat.com/compression/zip/
'
'------------------------------------------------------------------------------
' Nota:
' Esta clase contiene todos los métodos compartidos por tanto no es necesario
' crear una instancia para usarla.
' También se puede convertir en un módulo, la dejo como Class para obligar a
' usar el nombre de la clase para usar los métodos.
' 
' La definimos como no heredable para no usarla como base de otras clases y
' con un constructor privado para no permitir crear nuevas instancias.
'------------------------------------------------------------------------------
'
' ©Guillermo 'guille' Som, 2006, 2020
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On
Option Infer On

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Linq

Public Enum FormatosCompresion
    Desconocido
    Deflate
    GZip
    TarGZip
    Tar
    Zip
End Enum

Public NotInheritable Class UtilCompress

    ' Nueva propiedad en la DLL
    Public Shared ReadOnly Property Version() As String
        Get
            ' Esto devuelve el valor de "Versión de archivo" no de "Versión de ensamblado",
            ' pero el ensamblado que se tiene en cuenta es el de la biblioteca de clases.
            Dim ensamblado As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
            Dim fvi As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(ensamblado.Location)
            'Return ensamblado.GetName.Name & " v" & fvi.FileVersion
            Return fvi.FileVersion

            ' Esto devuelve la versión de la aplicación, no del ensamblado
            'Return My.Application.Info.Version.ToString

            'Return "1.0.0.1"
        End Get
    End Property

    ' Todos los métodos están compartidos, 
    ' por tanto no permitir crear nuevos objetos
    Private Sub New()
    End Sub

    Public Shared Function FormatoPorExtension(arch As String) As FormatosCompresion
        Dim formatoArchivo As FormatosCompresion = FormatosCompresion.Desconocido

        arch = arch.ToLower

        Select Case Path.GetExtension(arch)
            Case ".gz", ".gzz"
                formatoArchivo = FormatosCompresion.GZip
                If arch.EndsWith(".tar.gz") OrElse arch.EndsWith(".tar.gzz") Then
                    formatoArchivo = FormatosCompresion.TarGZip
                End If
            Case ".gzd"
                formatoArchivo = FormatosCompresion.Deflate
            Case ".tar"
                formatoArchivo = FormatosCompresion.Tar
            Case ".zip"
                formatoArchivo = FormatosCompresion.Zip
        End Select

        Return formatoArchivo
    End Function

    Public Shared Function Formato(archComprimido As String) As FormatosCompresion
        ' Leer el formato usado en el archivo y devolver el valor adecuado.
        ' El formato se averiguará comprobando el contenido de los 3 primeros bytes
        ' del archivo, buscando unas secuencias que "posiblemente" nos informen del
        ' sistema de compresión usado.
        ' Los archivos gZip    tienen los bytes 1F 8B 08
        ' Los archivos Deflate tienen los bytes ED BD 07
        ' Los .tar tienen una firma en la posición: 100,8 (644)
        Dim bytesActual(0 To 2) As Byte
        Dim formatoArchivo As FormatosCompresion = FormatosCompresion.Desconocido
        Dim utf8Enc As New UTF8Encoding()
        ' Convertir las cabeceras de bytes en cadenas para facilitar la comprobación
        ' En realidad la cabecera de .gz, .gzip es: &H1F, &H8B
        ' el tercer valor (&H8) indica "deflate"
        Dim cabeceraGZip As String = utf8Enc.GetString(New Byte() {&H1F, &H8B, &H8})
        Dim cabeceraDeflate As String = utf8Enc.GetString(New Byte() {&HED, &HBD, &H7})
        '04034b50
        Dim cabeceraZip As String = utf8Enc.GetString(New Byte() {&H50, &H4B, &H3, &H4})
        Dim marcaTar As String = "644"
        Dim cabeceraActual As String

        ' Comprobar si es una extensión reconocida
        Select Case Path.GetExtension(archComprimido).ToLower
            Case ".gz", ".gzz"
                If archComprimido.ToLower.EndsWith(".tar.gz") OrElse
                   archComprimido.ToLower.EndsWith(".tar.gzz") Then
                    formatoArchivo = FormatosCompresion.TarGZip
                Else
                    formatoArchivo = FormatosCompresion.GZip
                End If
            Case ".gzd"
                formatoArchivo = FormatosCompresion.Deflate
            Case ".tar"
                ' Los .tar tienen una firma en la posición:
                ' 100,8 (644) y 108,8 (337)
                '
                formatoArchivo = FormatosCompresion.Tar

            Case ".zip"
                formatoArchivo = FormatosCompresion.Zip
            Case Else
                Return FormatosCompresion.Desconocido
        End Select

        ' Leemos los bytes para saber el formato del archivo
        Using fs As New FileStream(archComprimido, FileMode.Open, FileAccess.Read, FileShare.Read)
            If formatoArchivo = FormatosCompresion.Tar Then
                fs.Position = 100
                ' Leer solo 7 porque el último es ChrW(0)
                ReDim bytesActual(0 To 6)
                fs.Read(bytesActual, 0, 7)
            ElseIf formatoArchivo = FormatosCompresion.Zip Then
                ReDim bytesActual(0 To 3)
                fs.Read(bytesActual, 0, 4)
            Else
                fs.Read(bytesActual, 0, 3)
            End If
            fs.Close()
        End Using
        cabeceraActual = utf8Enc.GetString(bytesActual)

        ' Comprobamos si los bytes son los esperados
        If formatoArchivo = FormatosCompresion.Deflate Then
            If cabeceraActual <> cabeceraDeflate Then
                Return FormatosCompresion.Desconocido
            End If
        ElseIf formatoArchivo = FormatosCompresion.Tar Then
            If cabeceraActual.Trim <> marcaTar Then
                Return FormatosCompresion.Desconocido
            End If
        ElseIf formatoArchivo = FormatosCompresion.Zip Then
            If cabeceraActual.Trim <> cabeceraZip Then
                Return FormatosCompresion.Desconocido
            End If
        Else
            If cabeceraActual <> cabeceraGZip Then
                Return FormatosCompresion.Desconocido
            End If
        End If

        Return formatoArchivo
    End Function

    Public Shared Sub Comprimir(archCompri As String, archTexto As String, formatoArch As FormatosCompresion)
        Select Case formatoArch
            Case FormatosCompresion.Deflate
                ComprimirDeflate(archCompri, archTexto)
            Case FormatosCompresion.GZip
                ComprimirGZip(archCompri, archTexto)
        End Select
    End Sub

    Public Shared Sub ComprimirTexto(archCompri As String,
                    texto As String,
                    formatoArch As FormatosCompresion)
        Select Case formatoArch
            Case FormatosCompresion.Deflate
                ComprimirTextoDeflate(archCompri, texto)
            Case FormatosCompresion.GZip
                ComprimirTextoGZip(archCompri, texto)
        End Select
    End Sub

    Public Shared Sub ComprimirGZip(archCompri As String, archTexto As String)
        Dim datos() As Byte = File.ReadAllBytes(archTexto)
        ComprimirGZip(archCompri, datos)
    End Sub

    Public Shared Sub ComprimirTextoGZip(archCompri As String, texto As String)
        Dim datos() As Byte = New UTF8Encoding().GetBytes(texto)
        ComprimirGZip(archCompri, datos)
    End Sub

    Public Shared Sub ComprimirGZip(archCompri As String, datos() As Byte)
        Dim fs As New FileStream(archCompri, FileMode.OpenOrCreate, FileAccess.Write)
        Dim gz As New GZipStream(fs, CompressionMode.Compress, True)
        gz.Write(datos, 0, datos.Length)
        gz.Close()
        fs.Close()
    End Sub


    Public Shared Sub ComprimirDeflate(archCompri As String, archTexto As String)
        Dim datos() As Byte = File.ReadAllBytes(archTexto)
        ComprimirDeflate(archCompri, datos)
    End Sub

    Public Shared Sub ComprimirTextoDeflate(archCompri As String, texto As String)
        Dim datos() As Byte = New UTF8Encoding().GetBytes(texto)
        ComprimirDeflate(archCompri, datos)
    End Sub

    Public Shared Sub ComprimirDeflate(archCompri As String, datos() As Byte)
        Dim fs As New FileStream(archCompri, FileMode.OpenOrCreate, FileAccess.Write)
        Dim gz As New DeflateStream(fs, CompressionMode.Compress, True)
        gz.Write(datos, 0, datos.Length)
        gz.Close()
        fs.Close()
    End Sub

    Public Shared Function Descomprimir(archCompri As String) As String
        Select Case Formato(archCompri)
            'Case FormatosCompresion.GZip
            '    Return DescomprimirGZip(archCompri)
            'Case FormatosCompresion.Deflate
            '    Return DescomprimirDeflate(archCompri)
            'Case FormatosCompresion.TarGZip
            '    ' Descomprimir el archivo y extraer el contenido,
            '    ' que estará en formato .tar,
            '    ' de ese .tar solo se extraerá el primer archivo.
            '    Dim tmpArch As String = Path.GetTempFileName & ".tar"
            '    DescomprimirGZip(tmpArch, archCompri)
            '    Dim archs As List(Of Tar) = UtilTar.ArchivosTar(tmpArch)
            '    Return archs(0).LeerContenido()
            'Case FormatosCompresion.Tar
            '    ' Extraer el primer archivo del .tar
            '    Dim archs As List(Of Tar) = UtilTar.ArchivosTar(archCompri)
            '    Return archs(0).LeerContenido()
            Case FormatosCompresion.Zip
                Return DescomprimirZipInfo(archCompri)
            Case Else
                ' Lanzar una excepción de que no es un formato adecuado
                'Throw New FormatoIncorrectoException("El archivo no tiene un formato comprimido correcto")
                Return ""
        End Select
    End Function

    ''' <summary>
    ''' Devuelve una cadena con los ficheros contenidos en el zip indicado
    ''' </summary>
    ''' <param name="archCompri">El path al archivo comprimido</param>
    ''' <returns></returns>
    Public Shared Function DescomprimirZipInfo(archCompri As String) As String
        Dim contZip = UtilCompress.ContenidoZip(archCompri)
        Dim archs As HashSet(Of ZipArchiveEntry) = contZip.ZipEntries
        Dim sb As New StringBuilder

        For Each zipEntry As ZipArchiveEntry In archs
            sb.AppendLine(zipEntry.Name)
            sb.AppendLine("  Tamaño:" & zipEntry.Length.ToString("#,##0"))
            sb.AppendLine("   Fecha: " & zipEntry.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss"))
            If zipEntry.FullName.Any Then
                sb.AppendLine("    Path: " & Path.GetDirectoryName(zipEntry.FullName))
            End If
            sb.AppendLine()
        Next

        Return sb.ToString
    End Function


    Public Shared Function Descomprimir(archCompri As String, archDest As String) As String
        ' Descomprime el archivo indicado y devuelve el nombre del archivo descomprimido
        ' si hay error, devuelve una cadena vacía.
        Select Case Formato(archCompri)
            'Case FormatosCompresion.GZip
            '    DescomprimirGZip(archDest, archCompri)

            'Case FormatosCompresion.Deflate
            '    DescomprimirDeflate(archDest, archCompri)

            'Case FormatosCompresion.TarGZip
            '    ' Descomprimir el archivo y extraer el contenido,
            '    ' que estará en formato .tar,
            '    ' de ese .tar solo se extraerá el primer archivo.
            '    Dim tmpArch As String = Path.GetTempFileName & ".tar"
            '    DescomprimirGZip(archDest, tmpArch)

            '    Dim archs As List(Of Tar) = UtilTar.ArchivosTar(tmpArch)
            '    My.Computer.FileSystem.WriteAllText(archDest, archs(0).LeerContenido(), False)

            'Case FormatosCompresion.Tar
            '    Dim archs As List(Of Tar) = UtilTar.ArchivosTar(archCompri)
            '    My.Computer.FileSystem.WriteAllText(archDest, archs(0).LeerContenido(), False)

            Case Else
                ' Lanzar una excepción de que no es un formato adecuado
                'Throw New FormatoIncorrectoException("El archivo no tiene un formato comprimido correcto")
                Return ""
        End Select

        If File.Exists(archDest) = False Then
            Return ""
        Else
            Return archDest
        End If
    End Function

    Public Shared Function DescomprimirDeflate(archCompri As String) As String
        ' Crear un stream en memoria con los bytes del archivo comprimido
        Dim datos() As Byte = File.ReadAllBytes(archCompri)
        Dim ms As New MemoryStream(datos)
        ' Crear un stream para descomprimir usando DeflateStream
        ' Asegurarse de que el stream de origen esté en el inicio
        ms.Position = 0
        ' Debemos mantener abierto el stream a descomprimir,
        ' porque lo usaremos nuevamente.
        Dim gz As New DeflateStream(ms, CompressionMode.Decompress, True)
        ' Tenemos que averiguar los bytes una vez descomprimido
        Dim total As Integer = totalBytesDelStream(gz)
        ' Preparar el array de bytes con el total una vez descomprimido
        ReDim datos(0 To total - 1)
        gz.Close()
        ' Volver a descomprimir
        ' Esto es necesario porque no se puede posicionar
        ' el stream que descomprime.
        ' También hay que reposicionar al principio el stream a descomprimir.
        ms.Position = 0
        gz = New DeflateStream(ms, CompressionMode.Decompress)
        ' Leemos todos los bytes y los asignamos al array
        total = gz.Read(datos, 0, datos.Length)
        gz.Close()

        ' Devolvemos la cadena quitando los caracteres nulos.
        Return New UTF8Encoding().GetString(datos) '.Replace(ChrW(0), "")
    End Function

    Public Shared Sub DescomprimirDeflate(archCompri As String, archDest As String)
        ' Crear un stream en memoria con los bytes del archivo comprimido
        Dim datos() As Byte = File.ReadAllBytes(archCompri)
        Dim ms As New MemoryStream(datos)
        ' El archivo que contendrá el texto normal
        Dim fs As New FileStream(archDest, FileMode.OpenOrCreate, FileAccess.Write)
        ' Crear un stream para descomprimir usando DeflateStream
        ' Asegurarse de que el stream de origen esté en el inicio
        ms.Position = 0
        ' Debemos mantener abierto el stream a descomprimir,
        ' porque lo usaremos nuevamente.
        Dim gz As New DeflateStream(ms, CompressionMode.Decompress, True)
        ' Tenemos que averiguar los bytes una vez descomprimido
        Dim total As Integer = totalBytesDelStream(gz)
        ' Preparar el array de bytes con el total una vez descomprimido
        'Array.Resize(datos, total)
        ReDim datos(0 To total - 1)
        gz.Close()
        ' Volver a descomprimir
        ' Esto es necesario porque no se puede posicionar
        ' el stream que descomprime.
        ' También hay que reposicionar al principio el stream a descomprimir.
        ms.Position = 0
        gz = New DeflateStream(ms, CompressionMode.Decompress)
        ' Leemos todos los bytes y los asignamos al array
        total = gz.Read(datos, 0, datos.Length)
        ' Lo guardamos en el archivo de destino
        fs.Write(datos, 0, datos.Length)
        gz.Close()
        fs.Close()
    End Sub

    Public Shared Function DescomprimirGZip(archCompri As String) As String
        ' Crear un stream en memoria con los bytes del archivo comprimido
        Dim datos() As Byte = File.ReadAllBytes(archCompri)
        Dim ms As New MemoryStream(datos)
        ' Crear un stream para descomprimir usando DeflateStream
        ' Asegurarse de que el stream de origen esté en el inicio
        ms.Position = 0
        ' Debemos mantener abierto el stream a descomprimir,
        ' porque lo usaremos nuevamente.
        Dim gz As New GZipStream(ms, CompressionMode.Decompress, True)
        ' Tenemos que averiguar los bytes una vez descomprimido
        Dim total As Integer = totalBytesDelStream(gz)
        ' Preparar el array de bytes con el total una vez descomprimido
        'Array.Resize(datos, total)
        ReDim datos(0 To total - 1)
        gz.Close()
        ' Volver a descomprimir
        ' Esto es necesario porque no se puede posicionar
        ' el stream que descomprime.
        ' También hay que reposicionar al principio el stream a descomprimir.
        ms.Position = 0
        gz = New GZipStream(ms, CompressionMode.Decompress)
        ' Leemos todos los bytes y los asignamos al array
        total = gz.Read(datos, 0, datos.Length)
        gz.Close()

        ' Devolvemos la cadena quitando los caracteres nulos.
        Return New UTF8Encoding().GetString(datos) '.Replace(ChrW(0), "")
    End Function

    Public Shared Sub DescomprimirGZip(arch As String, archCompri As String)
        ' Crear un stream en memoria con los bytes del archivo comprimido
        Dim datos() As Byte = File.ReadAllBytes(archCompri)
        Dim ms As New MemoryStream(datos)
        ' El archivo que contendrá el texto normal
        Dim fs As New FileStream(arch, FileMode.OpenOrCreate, FileAccess.Write)
        ' Crear un stream para descomprimir usando DeflateStream
        ' Asegurarse de que el stream de origen esté en el inicio
        ms.Position = 0
        ' Debemos mantener abierto el stream a descomprimir,
        ' porque lo usaremos nuevamente.
        Dim gz As New GZipStream(ms, CompressionMode.Decompress, True)
        ' Tenemos que averiguar los bytes una vez descomprimido
        Dim total As Integer = totalBytesDelStream(gz)
        ' Preparar el array de bytes con el total una vez descomprimido
        'Array.Resize(datos, total)
        ReDim datos(0 To total - 1)
        gz.Close()
        ' Volver a descomprimir
        ' Esto es necesario porque no se puede posicionar
        ' el stream que descomprime.
        ' También hay que reposicionar al principio el stream a descomprimir.
        ms.Position = 0
        gz = New GZipStream(ms, CompressionMode.Decompress)
        ' Leemos todos los bytes y los asignamos al array
        total = gz.Read(datos, 0, datos.Length)
        ' Lo guardamos en el archivo de destino
        fs.Write(datos, 0, datos.Length)
        gz.Close()
        fs.Close()
    End Sub

    ''' <summary>
    ''' Devuelve los ficheros contenidos en el zip.
    ''' </summary>
    ''' <param name="archCompri">El path completo del archivo zip</param>
    ''' <returns>Una colección del tipo <see cref="ZipArchiveEntry"/></returns>
    Public Shared Function ContenidoZip(archCompri As String) As (ZipEntries As HashSet(Of ZipArchiveEntry), ArchivoZip As ZipArchive)
        Dim col As New HashSet(Of ZipArchiveEntry)

        Dim archive As ZipArchive = ZipFile.OpenRead(archCompri)
        'Using archive = ZipFile.OpenRead(archCompri)

        For Each entry As ZipArchiveEntry In archive.Entries
            col.Add(entry)
        Next

        'End Using

        Return (col, archive)
    End Function

    ''' <summary>
    ''' Extrae el fichero indicado y devuelve el contenido del fichero extraído.
    ''' </summary>
    ''' <param name="archZip">Referencia al archivo zip</param>
    ''' <param name="zipEntry">Un objeto del tipo <see cref="ZipArchiveEntry"/> con el fichero a extraer</param>
    ''' <returns>Devuelve una cadena con el contenido</returns>
    Public Shared Function ExtraerZipEntry(archZip As ZipArchive, zipEntry As ZipArchiveEntry) As String
        Dim extractPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        extractPath = Path.Combine(extractPath, Application.ProductName)
        If Not Directory.Exists(extractPath) Then
            Directory.CreateDirectory(extractPath)
        End If

        Dim destinationPath = Path.GetFullPath(Path.Combine(extractPath, zipEntry.FullName))
        If (destinationPath.StartsWith(extractPath, StringComparison.Ordinal)) Then
            extractPath = Path.GetDirectoryName(destinationPath)
            If Not Directory.Exists(extractPath) Then
                Directory.CreateDirectory(extractPath)
            End If
            If File.Exists(destinationPath) Then
                File.Delete(destinationPath)
            End If
            zipEntry.ExtractToFile(destinationPath)
        End If

        Dim contenido As String
        Using sr As New StreamReader(destinationPath, Encoding.UTF8, True)
            contenido = sr.ReadToEnd
            sr.Close()
        End Using

        Return contenido
    End Function

    ''' <summary>
    ''' Extrae el fichero indicado y devuelve el path donde se ha extraído.
    ''' </summary>
    ''' <param name="archZip">Referencia al archivo zip</param>
    ''' <param name="zipEntry">Un objeto del tipo <see cref="ZipArchiveEntry"/> con el fichero a extraer</param>
    ''' <returns>Devuelve el path donde se ha extraído el fichero</returns>
    Public Shared Function ExtraerZipPath(archZip As ZipArchive, zipEntry As ZipArchiveEntry) As String
        Dim extractPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        extractPath = Path.Combine(extractPath, Application.ProductName)
        If Not Directory.Exists(extractPath) Then
            Directory.CreateDirectory(extractPath)
        End If

        Dim destinationPath = Path.GetFullPath(Path.Combine(extractPath, zipEntry.FullName))
        If (destinationPath.StartsWith(extractPath, StringComparison.Ordinal)) Then
            extractPath = Path.GetDirectoryName(destinationPath)
            If Not Directory.Exists(extractPath) Then
                Directory.CreateDirectory(extractPath)
            End If
            If File.Exists(destinationPath) Then
                File.Delete(destinationPath)
            End If
            zipEntry.ExtractToFile(destinationPath)
        End If

        Return destinationPath
    End Function


    Private Shared Function totalBytesDelStream(stream As Stream) As Integer
        ' Averiguar cuantos bytes se producen al descomprimir
        Dim buffer(100) As Byte
        Dim totalCount As Integer = 0
        While True
            Dim bytesRead As Integer = stream.Read(buffer, 0, 100)
            If bytesRead = 0 Then
                Exit While
            End If
            totalCount += bytesRead
        End While
        Return totalCount
    End Function

End Class

