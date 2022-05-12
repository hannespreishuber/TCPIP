Imports System.Net.Sockets
Imports System.Threading

Public Class client
    Public Sub start()



        Dim t1 As New Thread(Sub()

                                 Thread.CurrentThread.IsBackground = True
                                 Connect("127.0.0.1", "Hello ...")
                             End Sub)
        t1.Start()




        Console.ReadLine()
    End Sub

    Private Shared Sub Connect(ByVal server As String, ByVal message As String)
        Try
            Dim port As Int32 = 21001
            Dim client As TcpClient = New TcpClient(server, port)
            Dim stream As NetworkStream = client.GetStream()

            While True
                Dim data As Byte() = System.Text.Encoding.ASCII.GetBytes(message + Date.Now)
                stream.Write(data, 0, data.Length)
                Console.WriteLine("Sent: {0}", message)
                data = New Byte(255) {}
                Dim response As String = String.Empty
                Dim bytes As Int32 = stream.Read(data, 0, data.Length)
                response = System.Text.Encoding.ASCII.GetString(data, 0, bytes)
                Console.WriteLine("Received: {0}", response)
                Thread.Sleep(2000)
            End While

            stream.Close()
            client.Close()
        Catch e As Exception
            Console.WriteLine("Exception: {0}", e)
        End Try

        Console.Read()
    End Sub
End Class
