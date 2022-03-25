Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class Client3
    Public Sub start()
        Using client = New TcpClient("127.0.0.1", 21001)
            Using netstream As NetworkStream = client.GetStream()
                Using writer As New BinaryWriter(netstream)

                    Using reader = New StreamReader(netstream, Encoding.UTF8)



                        Using Fs = New FileStream("c:\temp\black.zip", FileMode.Open, FileAccess.Read)
                            Using fsreader = New BinaryReader(Fs)

                                While fsreader.BaseStream.Length > fsreader.BaseStream.Position
                                    writer.Write(fsreader.ReadByte)
                                    Console.Write("x")
                                End While
                            End Using

                        End Using
                    End Using
                End Using
            End Using

        End Using
    End Sub

End Class
