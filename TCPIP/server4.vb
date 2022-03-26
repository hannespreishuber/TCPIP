Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class server4
    Public Sub Listen()
        Dim localAddr = IPAddress.Parse("127.0.0.1")
        Dim Server = New TcpListener(localAddr, 21001)

        Server.Start()
        Dim srv = Server.AcceptTcpClient()
        Dim netstream = srv.GetStream()
        Dim writer As New StreamWriter(netstream, Encoding.ASCII)
        Dim buffer(1499) As Byte
        writer.AutoFlush = True
        While srv.Connected
            writer.WriteLine("OK" + Environment.NewLine)
            'Using Fs = New FileStream("c:\temp\big3.zip", FileMode.OpenOrCreate, FileAccess.Write)
            '    netstream.CopyTo(Fs)
            'End Using

            'Using bufferStream = New BufferedStream(netstream)
            Using reader = New BinaryReader(netstream)
                Dim bytes = reader.BaseStream
                Using Fs = New FileStream("c:\temp\temp.zip", FileMode.OpenOrCreate, FileAccess.Write)

                    Using fswriter = New BinaryWriter(Fs)
                        While bytes.Read(buffer) > 0
                            Fs.Write(buffer)
                            '  Console.Write("x")
                        End While

                    End Using

                End Using



            End Using
            ''End Using
        End While
    End Sub
End Class
