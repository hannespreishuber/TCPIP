Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class Server0

    Public Sub Start()
        Dim ipHostInfo = Dns.GetHostEntry(Dns.GetHostName())
        Dim ipAddress = ipHostInfo.AddressList.Where(Function(x) x.AddressFamily = AddressFamily.InterNetwork)(0)
        Dim localEndPoint = New IPEndPoint(ipAddress, 11000)
        Dim listener = New Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
        listener.Bind(localEndPoint)
        listener.Listen(100)
        Console.WriteLine(ipAddress.ToString)
        Dim handler = listener.Accept()

        Task.Run(Sub()
                     Dim buffer(10) As Byte
                     While True
                         Try

                             handler.Receive(buffer)
                             Console.WriteLine(Encoding.UTF8.GetString(buffer))
                         Catch ex As Exception
                             Dim a = 0
                         End Try


                     End While
                 End Sub)

        Console.ReadKey()
    End Sub
End Class
