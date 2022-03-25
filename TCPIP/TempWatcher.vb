Imports System.IO

Public Class TempWatcher
    Public Sub Start()
        Using watcher As New FileSystemWatcher(Path.GetTempPath())

            watcher.NotifyFilter = NotifyFilters.Attributes _
                                 Or NotifyFilters.CreationTime _
                                 Or NotifyFilters.DirectoryName _
                                 Or NotifyFilters.FileName _
                                 Or NotifyFilters.LastAccess _
                                 Or NotifyFilters.LastWrite _
                                 Or NotifyFilters.Security _
                                 Or NotifyFilters.Size

            AddHandler watcher.Created, AddressOf OnCreated

            AddHandler watcher.Error, AddressOf OnError

            ' watcher.Filter = "*.txt"
            watcher.EnableRaisingEvents = True

            Console.WriteLine($"Watching {Path.GetTempPath()  } Press enter to exit.")
            Console.ReadLine()
        End Using

    End Sub
    Private Shared Sub OnCreated(sender As Object, e As FileSystemEventArgs)
        Console.WriteLine($"Created: {e.FullPath}")
    End Sub
    Private Shared Sub OnError(sender As Object, e As ErrorEventArgs)
        Dim ex = e.GetException()
        Console.WriteLine($"Message: {ex.Message}")
    End Sub
End Class

'Private static void OnChanged(object sender, FileSystemEventArgs e)
'        {
'            if (e.ChangeType != WatcherChangeTypes.Changed)
'            {
'                return;
'            }
'            Console.WriteLine($"Changed: {e.FullPath}");
'        }

'        private static void OnCreated(object sender, FileSystemEventArgs e)
'        {
'            string value = $"Created: {e.FullPath}";
'            Console.WriteLine(value);
'        }

'        private static void OnDeleted(object sender, FileSystemEventArgs e) =>
'            Console.WriteLine($"Deleted: {e.FullPath}");

'        private static void OnRenamed(object sender, RenamedEventArgs e)
'        {
'            Console.WriteLine($"Renamed:");
'            Console.WriteLine($"    Old: {e.OldFullPath}");
'            Console.WriteLine($"    New: {e.FullPath}");
'        }

'        private static void OnError(object sender, ErrorEventArgs e) =>
'            PrintException(e.GetException());

'        private static void PrintException(Exception? ex)
'        {
'            if (ex != null)
'            {
'                Console.WriteLine($"Message: {ex.Message}");
'                Console.WriteLine("Stacktrace:");
'                Console.WriteLine(ex.StackTrace);
'                Console.WriteLine();
'                PrintException(ex.InnerException);
'            }
'        }
'End Class
