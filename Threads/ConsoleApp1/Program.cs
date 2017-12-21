using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;


namespace FIles
{
    class Program
    {
        public static DateTime now = DateTime.Now;
        static void Main(string[] args)
        {
           
            string buf = "";
            RAALog pasLog = new RAALog();

            pasLog.EventIO += RAALog.OnEvent;

            pasLog.Write(
                new string[] {
                    "56456234",
                    "344561231324565",
                    "453423423423453453456"
                }
            );
            Console.WriteLine("\nПострочныый вывод из файла: " + pasLog.path + "\n");
            pasLog.Read(pasLog.path);
            Console.WriteLine("Введите строку для поиска");
            buf = Console.ReadLine();
            Console.WriteLine("Поиск по строке");
            pasLog.Search(buf);

            RAADiskInfo info = new RAADiskInfo();
            info.InfoOfDrivers();

            RAAFileInfo fileInfo = new RAAFileInfo();
            fileInfo.InfoOfFiles(pasLog.path);


            RAAFileManager manager = new RAAFileManager();

            manager.ListOfFiles();
            manager.Task2();

            manager.Task3(@"D:\", "txt");

            manager.Task4();
            Console.ReadLine();
        }

        class RAALog
        {
            public delegate void del(string m, string path);
            public event del EventIO;
            public string path = @"RAAlogfile.txt";
            public void Write(string[] s)
            {
                string buf = "";
                int countStr = 1;
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    foreach (string str in s)
                    {
                        sw.WriteLine(str);
                    }
                    
                    sw.Close();
                }

                Type type = typeof(RAALog);

                foreach (MethodInfo m in type.GetMethods())
                {
                    if (m.Name == "Write")
                    {
                        buf = m.Name;
                    }
                }

                EventIO(buf, path);
            }
            public void Read(string path)
            {
                string buf = "";
                Type type = typeof(RAALog);

                foreach (MethodInfo m in type.GetMethods())
                {
                    if (m.Name == "Read")
                    {
                        buf = m.Name;
                    }
                }

                EventIO(buf, path);
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                    sr.Close();
                }
            }
            public void Search(string search)
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == search)
                        {
                            Console.WriteLine("Найдено совпадение " + line);
                            Console.WriteLine(sr.ReadLine());
                        }
                    }
                    sr.Close();
                }
            }
            public static void OnEvent(string m, string path)
            {
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Пользователь вызвал метод: " + m);
                    sw.WriteLine("Время: " + now);
                }
            }
        }
        class RAADiskInfo
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            public void InfoOfDrivers()
            {
                foreach (DriveInfo drive in drives)
                {
                    Console.WriteLine("Название: {0}", drive.Name);
                    Console.WriteLine("Тип: {0}", drive.DriveType);
                    if (drive.IsReady)
                    {
                        Console.WriteLine("Объем диска: {0}", drive.TotalSize);
                        Console.WriteLine("Свободное пространство: {0}", drive.TotalFreeSpace);
                        Console.WriteLine("Метка: {0}", drive.VolumeLabel);
                    }
                    Console.WriteLine();
                }
            }

        }
        class RAAFileInfo
        {
            public void InfoOfFiles(string path)
            {

                FileInfo fileInf = new FileInfo(path);
                if (!fileInf.Exists) return;

                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Путь : {0}", fileInf.FullName);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf.Length);
            }
        }
        class RAAFileManager
        {
            public void ListOfFiles()
            {
                string dirName = @"C:\";
                string[] dirs = Directory.GetDirectories(dirName);
                string[] files = Directory.GetFiles(dirName);
                if (!Directory.Exists(dirName)) return;


                Console.WriteLine("Подкаталоги:");

                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");

                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
            public void Task2()
            {
                string dirName = @"C:\";
                string prefPath = @"";
                string[] dirs = Directory.GetDirectories(dirName);
                string[] files = Directory.GetFiles(dirName);
                DirectoryInfo directory = new DirectoryInfo(prefPath + @"RAAInspect");
                directory.Create();

                string path = prefPath + @"RAAInspect\RAAdirinfo.txt";

                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Подкаталоги:");

                    foreach (string s in dirs)
                    {
                        sw.WriteLine(s);
                    }
                    sw.WriteLine();
                    sw.WriteLine("Файлы:");

                    foreach (string s in files)
                    {
                        sw.WriteLine(s);
                    }

                    Console.WriteLine("Зaписано");

                }

                string newPath = prefPath + @"PASInspect\NEWPASdirinfo.txt"; ;
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    fileInf.CopyTo(newPath, true);
                }
                File.Delete(prefPath + @"PASInspect\PASdirinfo.txt");


            }
            public void Task3(string dirName, string txt)
            {
                string prefPath = @"";
                DirectoryInfo directory = new DirectoryInfo(prefPath + "RAAFiles");
                directory.Create();

                string[] files = Directory.GetFiles(dirName, "*." + txt);

                foreach (var s in files)
                {

                    FileInfo fileInf = new FileInfo(s);

                    if (fileInf.ToString() == s)
                    {
                        Console.WriteLine(s);

                        fileInf.CopyTo(prefPath + @"RAAFiles\" + fileInf.Name, true);

                    }
                }

                DirectoryInfo dirInfo = new DirectoryInfo(prefPath + @"RAAInspect");
                dirInfo.Delete(true);
                Directory.Move(prefPath + @"RAAFiles", prefPath + @"RAAInspect\");



            }
            public void Task4()
            {
                string prefPath = @"";
                string startPath = prefPath + @"RAAInspect";
                string zipPath = prefPath + @"result.zip";
                string extractPath = prefPath + @"result";

                ZipFile.CreateFromDirectory(startPath, zipPath);        
            }
        }
    }
}