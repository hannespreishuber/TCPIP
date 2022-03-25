Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class UdpClnt
    Public Sub CallServer()
        'Dim s As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        'Dim sendbuf As Byte() = Encoding.ASCII.GetBytes("ppedv")
        'Dim ep As IPEndPoint = New IPEndPoint(IPAddress.Broadcast, 21000) '255.255.255.255

        's.SendTo(sendbuf, ep)
        's.Close()
        Dim s = New UdpClient()
        Dim sendbuf As Byte() = Encoding.ASCII.GetBytes("ppedv")
        Dim ep As IPEndPoint = New IPEndPoint(IPAddress.Broadcast, 21000) '255.255.255.255

        s.Send(sendbuf, sendbuf.Length, ep)

        s.Close()
        Console.WriteLine("Broadcast done")

    End Sub
End Class

'https://gist.github.com/zmilojko/5055246