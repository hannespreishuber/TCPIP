Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class UdpServer
    Private Const listenPort As Integer = 21000

    Private Sub StartListener()
        Dim listener As UdpClient = New UdpClient(listenPort)
        Dim groupEP As IPEndPoint = New IPEndPoint(IPAddress.Any, listenPort) '0.0.0,0

        Try

            While True
                Console.WriteLine("Waiting for broadcast")
                Dim bytes As Byte() = listener.Receive(groupEP)
                Console.WriteLine($"Received broadcast from {groupEP.Address} :")
                Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}")
            End While

        Catch e As SocketException
            Console.WriteLine(e)
        Finally
            listener.Close()
        End Try
    End Sub

    Public Sub Start()
        StartListener()
    End Sub

End Class
