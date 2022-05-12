Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class Client2
    Public Sub start()
        Using client = New TcpClient("127.0.0.1", 21001)
            Using netstream As NetworkStream = client.GetStream()
                Using writer As New StreamWriter(netstream, Encoding.ASCII)
                    writer.AutoFlush = True
                    Using reader = New StreamReader(netstream, Encoding.UTF8)
                        For i = 1 To 100
                            writer.WriteLine($"INC {i}")
                            Console.WriteLine($"Sent: {i}")

                            Console.WriteLine($"Received: {reader.ReadLine}")
                            Thread.Sleep(1000)
                        Next
                    End Using
                End Using
            End Using

        End Using

    End Sub
End Class
