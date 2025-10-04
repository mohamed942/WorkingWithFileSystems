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



            #region Managing Drives
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

            #endregion

            #region Managing directories
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
            #endregion

            #region Managing files

            SectionTitle("Managing files");
            // define   directory Path
            string  dir = Combine(GetFolderPath(SpecialFolder.Personal), "OutputFiles.");

            // create directory
            CreateDirectory(dir);

            // define file Path
            string textfile = Combine(dir, "textFile.txt");
            string backupfile = Combine(dir, "backupFile.bak");

            // Check if textfile exists
            WriteLine($"Does TextFile Exists? {Path.Exists(textfile)}");

            // create a new text file and write a line to it
            StreamWriter sw = File.CreateText(textfile);
            sw.WriteLine("Hello World!");
            sw.Close();

            // Check if textfile exists
            WriteLine($"Does TextFile Exists? {Path.Exists(textfile)}");

            // copy the file, and overwrite if it already exists
            File.Copy(textfile, backupfile, true);

            // Check if backupfile exists
            WriteLine($"Does Backup file Exists? {Path.Exists(backupfile)}");

            Write("Confirm the files exist, and then press ENTER: ");
            ReadLine();
            // delete file
            File.Delete(textfile);
            WriteLine($"Does TextFile Exists? {Path.Exists(textfile)}");

            // read from the text file backup
            WriteLine($"Does TextFile Exists? {Path.Exists(backupfile)}");

            StreamReader sr = File.OpenText(backupfile);
            WriteLine(sr.ReadToEnd());
            sr.Close();

            #endregion

            #region Manging Path

            SectionTitle("Manging Path");

            WriteLine($"Folder Name : {GetDirectoryName("backupFile")}");
            WriteLine($"File Name : {GetFileName("TextFile.txt")}");
            WriteLine($"File Name without extension : {GetFileNameWithoutExtension("TextFile.txt")}");
            WriteLine($"File Extension : {GetExtension("TextFile.txt")}");
            WriteLine($"Get random file name : {GetRandomFileName()}");
            WriteLine($"Get temp file name : {GetTempFileName()}");
            #endregion


            #region Get File Infromation

            SectionTitle("Getting file information");
            FileInfo fileInfo = new FileInfo("backupFile.bak");
            WriteLine($"File Name : {fileInfo.Name}");
            WriteLine($"File Extension : {fileInfo.Extension}");
            
            // WriteLine($"File Size : {fileInfo.Length}");
            WriteLine($"File Creation Time : {fileInfo.CreationTime}");
            WriteLine($"File Last Access Time : {fileInfo.LastAccessTime}");
            WriteLine($"File Last Write Time : {fileInfo.LastWriteTime}");
            WriteLine($"File Directory : {fileInfo.Directory}");
            WriteLine($"File Directory Name : {fileInfo.DirectoryName}");
            WriteLine($"Does the file read only? {fileInfo.IsReadOnly}");


            #endregion

            #region Controlling how to work with files

            FileStream file = File.Open(backupfile, FileMode.Open, FileAccess.Read, FileShare.Read);

            #endregion
            ReadKey();
        }
    }
}
