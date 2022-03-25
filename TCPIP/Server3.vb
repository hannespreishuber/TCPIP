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
        Dim writer As New StreamWriter(netstream, Encoding.ASCII)
        writer.AutoFlush = True
        While srv.Connected
            writer.WriteLine("OK" + Environment.NewLine)

            ' Using bufferStream = New BufferedStream(netstream)
            Using reader = New BinaryReader(netstream)
                Dim bytes = reader.BaseStream
                Using Fs = New FileStream("c:\temp\temp.zip", FileMode.OpenOrCreate, FileAccess.Write)
                    Using fswriter = New BinaryWriter(Fs)
                        While bytes.CanRead
                            Fs.WriteByte(bytes.ReadByte)
                            Console.Write("x")
                        End While

                    End Using

                End Using



            End Using
            'End Using
        End While
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