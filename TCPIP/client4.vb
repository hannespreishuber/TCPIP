Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Public Class client4
    Public Sub start()
        Using client = New TcpClient("127.0.0.1", 21001)
            Using netstream As NetworkStream = client.GetStream()
                Using writer As New BinaryWriter(netstream)

                    Using reader = New StreamReader(netstream, Encoding.UTF8)
                        Using Fs = New FileStream("c:\temp\big.zip", FileMode.Open, FileAccess.Read,
                                                  FileShare.Read, 1500, FileOptions.SequentialScan)
                            Dim buffer(1499) As Byte
                            Dim bytesRead = Fs.Read(buffer, 0, 1500)
                            While bytesRead > 0

                                writer.Write(buffer)

                                bytesRead = Fs.Read(buffer, 0, 1500)
                            End While

                        End Using
                        Console.WriteLine("file transfered")
                        Console.ReadKey()
                    End Using
                End Using
            End Using

        End Using
    End Sub

End Class
