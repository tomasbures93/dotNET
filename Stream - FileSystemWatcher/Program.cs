namespace Stream___FileSystemWatcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pfad = @"C:\Lookup";
            using var watcher = new FileSystemWatcher(pfad);

            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Filter = "*.lookup";

            //watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Renamed += OnRenamed;
            watcher.Deleted += OnDeleted;

            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        public static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File {e.Name} has been deleted.");
        }

        public static void OnRenamed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File renamed | {e.Name} | {e.FullPath}");
        }

        public static void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Neue datei hinzugefügt | {e.Name} | {e.FullPath}");
        }

        public static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File Created | {e.Name} | {e.FullPath}");
        }
    }
}
