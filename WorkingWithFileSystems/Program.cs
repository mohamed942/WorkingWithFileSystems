using static System.IO.Directory;
using static System.Console;
using static System.IO.Path;
using static System.Environment;

namespace WorkingWithFileSystems
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            SectionTitle("* Handling cross-platform environments and filesystems");
 
            WriteLine("{0,-33} {1}", arg0: "Path.PathSeparator",arg1: PathSeparator);
            WriteLine("{0,-33} {1}", arg0: "Path.DirectorySeparatorChar",
             arg1: DirectorySeparatorChar);
            WriteLine("{0,-33} {1}", arg0: "Directory.GetCurrentDirectory()",
             arg1: GetCurrentDirectory());
            WriteLine("{0,-33} {1}", arg0: "Environment.CurrentDirectory",
             arg1: CurrentDirectory);
            WriteLine("{0,-33} {1}", arg0: "Environment.SystemDirectory",
             arg1: SystemDirectory);
            WriteLine("{0,-33} {1}", arg0: "Path.GetTempPath()",
             arg1: GetTempPath());
            WriteLine("GetFolderPath(SpecialFolder");
            WriteLine("{0,-33} {1}", arg0: " .System)",
             arg1: GetFolderPath(SpecialFolder.System));
            WriteLine("{0,-33} {1}", arg0: " .ApplicationData)", arg1: GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0,-33} {1}", arg0: " .MyDocuments)",
             arg1: GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0,-33} {1}", arg0: " .Personal)",
             arg1: GetFolderPath(SpecialFolder.Personal));


            // manage Drives

            SectionTitle("Managing drives");
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
             "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");

            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
                     drive.Name,
                     drive.DriveType,
                     drive.DriveFormat,
                     drive.TotalSize,
                     drive.AvailableFreeSpace );
                }
                else
                {
                    WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
                     drive.Name,
                     drive.DriveType,
                     "N/A",
                     "N/A",
                     "N/A" );
                }
               

            }

            // managing directories

            SectionTitle("Managing directories");
            string newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "NewFolder");
            WriteLine($"Working with: {newFolder}");
            // check if it exists
            WriteLine($"Does it exist? {Path.Exists(newFolder)}");
            // create directory 
            WriteLine("Creating it...");
            CreateDirectory(newFolder);
            WriteLine($"Does it exist? {Path.Exists(newFolder)}");

            Write("Confirm the directory exists, and then press ENTER: ");
            ReadLine();
            // delete directory
            WriteLine("Deleting it...");
            Delete(newFolder,recursive: true);
            WriteLine($"Does it exist? {Path.Exists(newFolder)}");
            ReadKey();
        }
    }
}
