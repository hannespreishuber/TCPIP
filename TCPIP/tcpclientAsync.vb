'https://riptutorial.com/csharp/example/28048/async-tcp-client
Imports System.IO
Imports System.Net.Sockets

Public Class tcpclientAsync
    Public Async Sub Start(ByVal server As String, ByVal message As String)
        Using client = New TcpClient()
            Await client.ConnectAsync(server, 21001)
            Using netstream = client.GetStream()
                Using writer = New StreamWriter(netstream)
                    Using reader = New StreamReader(netstream)
                        netstream.ReadTimeout = 2000
                        writer.AutoFlush = True
                        ' Await writer.WriteLineAsync(message)
                        writer.WriteLine(message)

                        Dim response = Await reader.ReadLineAsync()
                        Console.WriteLine(String.Format($"Server: {response}"))


                        Await writer.WriteLineAsync(message)


                        response = Await reader.ReadLineAsync()
                        Console.WriteLine(String.Format($"Server: {response}"))
                    End Using
                End Using
            End Using
        End Using

    End Sub
End Class
