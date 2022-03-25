Public Class Class1

End Class
'int PORT = 9876;
'UdpClient udpClient = New UdpClient();
'udpClient.Client.Bind(New IPEndPoint(IPAddress.Any, PORT));

'var from = New IPEndPoint(0, 0);
'Task.Run(() >=
'{
'    while (true)
'    {
'        var recvBuffer = udpClient.Receive(ref from);
'        Console.WriteLine(Encoding.UTF8.GetString(recvBuffer));
'    }
'});

'var data = Encoding.UTF8.GetBytes("ABCD");
'udpClient.Send(data, data.Length, "255.255.255.255", PORT);