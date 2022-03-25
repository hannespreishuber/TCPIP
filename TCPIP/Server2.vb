Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class Server2
    Public Sub Listen()
        Dim localAddr = IPAddress.Parse("127.0.0.1")
        Dim Server = New TcpListener(localAddr, 21001)
        Dim line As String

        Server.Start()
        Dim srv = Server.AcceptTcpClient()
        Dim netstream = srv.GetStream()
        Dim writer As New StreamWriter(netstream, Encoding.ASCII)
        writer.AutoFlush = True
        While srv.Connected
            writer.WriteLine("OK" + Environment.NewLine)

            'Dim reply As Byte() = System.Text.Encoding.ASCII.GetBytes($"OK{ Environment.NewLine}")
            'netstream.Write(reply, 0, reply.Length)



            ' Using bufferStream = New BufferedStream(netstream)
            Using reader = New StreamReader(netstream, Encoding.UTF8)
                line = reader.ReadLine
                While line IsNot Nothing

                    Console.WriteLine(line)
                    line = reader.ReadLine
                    writer.WriteLine("OK" + Environment.NewLine)
                End While



            End Using
            'End Using
        End While
    End Sub
End Class
