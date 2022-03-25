Public Class Filewatcher

End Class
'Private Static PhysicalFileProvider _fileProvider;
'        Private Static IChangeToken _fileChangeToken;

'        Static void Main(String[] args)
'        {
'            _fileProvider = New PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "."));
'            WatchForFileChanges();

'            Console.ReadKey(False);
'        }

'        Private Static void WatchForFileChanges()
'        {
'            _fileChangeToken = _fileProvider.Watch("*.*");
'            _fileChangeToken.RegisterChangeCallback(Notify, default);
'        }

'        Private Static void Notify(Object state)
'        {
'            Console.WriteLine("File change detected");
'            WatchForFileChanges();
'        }