Imports System
Imports System.Threading

Module Program
    Sub Main(args As String())
        If args.FirstOrDefault = "c" Then
            Dim c As New client
            c.start()
        ElseIf args.FirstOrDefault = "ca" Then
            Dim c As New tcpclientAsync
            c.Start("127.0.0.1", "Helo")
        ElseIf args.FirstOrDefault = "u" Then
            Dim u As New UdpServer
            u.Start()
        ElseIf args.FirstOrDefault = "uc" Then
            Dim u As New UdpClnt

            u.CallServer()
        ElseIf args.FirstOrDefault = "w" Then
            Dim u As New TempWatcher

            u.Start()
        ElseIf args.FirstOrDefault = "s2" Then
            Dim s As New Server2
            s.Listen()
        ElseIf args.FirstOrDefault = "c2" Then
            Dim s As New Client2
            s.start()
        ElseIf args.FirstOrDefault = "s3" Then
            Dim s As New Server3
            s.Listen()
        ElseIf args.FirstOrDefault = "c3" Then
            Dim s As New Client3
            s.start()
        Else

            Dim t As New Thread(Sub()
                                    Dim myserver As Server = New Server()
                                End Sub)
            t.Start()
            Console.WriteLine("Server Started...!")
        End If

    End Sub

End Module
