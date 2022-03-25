Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class Server
    Dim server As TcpListener
    Public Sub New()
        Dim localAddr = IPAddress.Parse("127.0.0.1")
        server = New TcpListener(localAddr, 21001)

        server.Start()
        StartListener()
    End Sub
    Public Sub StartListener()
        Try

            While True
                Console.WriteLine("Waiting for connection...")
                Dim srv As TcpClient = server.AcceptTcpClient()
                Console.WriteLine("Connected!")
                Dim t As Thread = New Thread(New ParameterizedThreadStart(AddressOf HandleDevice))
                t.Start(srv)
            End While

        Catch e As SocketException
            Console.WriteLine("SocketException: {0}", e)
            server.[Stop]()
        End Try
    End Sub

    Public Sub HandleDevice(ByVal obj As Object)
        Dim client As TcpClient = CType(obj, TcpClient)
        Dim stream = client.GetStream()
        Dim data As String
        Dim bytes As Byte() = New Byte(255) {}
        Dim numBytesRead As Integer
        Try

            Do
                numBytesRead = stream.Read(bytes, 0, bytes.Length)
                Dim hex As String = BitConverter.ToString(bytes)
                data = Encoding.ASCII.GetString(bytes, 0, numBytesRead)
                Console.WriteLine("{1}: {0}", data, Thread.CurrentThread.ManagedThreadId)
                'System.Runtime.InteropServices.RuntimeInformation.OSDescription
                Dim reply As Byte() = System.Text.Encoding.ASCII.GetBytes($"Hallo Device! { Date.Now.ToString()}")
                stream.Write(reply, 0, reply.Length)

                Console.WriteLine("{0}:", Thread.CurrentThread.ManagedThreadId)
            Loop While numBytesRead > 0

        Catch e As Exception
            Console.WriteLine("Exception: {0}", e.ToString())
            client.Close()
        End Try
    End Sub
End Class


