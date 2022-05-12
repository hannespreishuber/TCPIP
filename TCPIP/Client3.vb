Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class Client3
    Public Sub start()
        Using client = New TcpClient("127.0.0.1", 21001)
            Using netstream As NetworkStream = client.GetStream()
                Using reader = New StreamReader(netstream)
                    Using Fs = New FileStream("c:\temp\big.zip", FileMode.Open, FileAccess.Read)
                        Fs.CopyTo(netstream)
                    End Using
                End Using
            End Using
        End Using
    End Sub

End Class
