Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class Server3
    Public Sub Listen()
        Dim localAddr = IPAddress.Parse("127.0.0.1")
        Dim Server = New TcpListener(localAddr, 21001)
        Server.Start()
        Dim srv = Server.AcceptTcpClient()
        Dim netstream = srv.GetStream()
        Try
            Using Fs = New FileStream("c:\temp\temp.bmp", FileMode.OpenOrCreate, FileAccess.Write)
                netstream.CopyTo(Fs)
            End Using
        Catch
        End Try

    End Sub
End Class




















'Private Sub Speichern(ByVal Input As String, ByVal nwstream As NetworkStream)
'    Dim leange As Integer = CInt(Input)
'    Dim a As Integer = 0
'    Dim data(1024) As Byte
'    Dim sum As Long = 0
'    Dim str As New FileStream("pfad", FileMode.Create, FileAccess.Write)
'    Do
'        a = nwstream.Read(data, 0, data.Length)
'        mw.Write(data, 0, a)
'        sum += a
'        If sum = leange Then
'            str.Flush()
'            str.Close()
'            Exit Do
'Loop