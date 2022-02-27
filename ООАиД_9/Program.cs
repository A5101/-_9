using System;
using System.Collections.Generic;

namespace ООАиД_9
{
    class Program
    {
        static void Main()
        {
            Component fileSystem = new Directory("Файловая система");//
            // определяем новый диск
            Component diskC = new Directory("Диск С");
            // новые файлы
            Component pngFile = new File("12345.png", 100);
            Component docxFile = new File("Document.docx", 200);
            // добавляем файлы на диск С
            diskC.AddFile(pngFile);
            diskC.AddFile(docxFile);
            // добавляем диск С в файловую систему
            fileSystem.AddFolder(diskC);
            // удаляем с диска С файл
            //diskC.RemoveFile(pngFile);
            // создаем новую папку
            Component docsFolder = new Directory("Мои Документы");
            Component fold1 = new Directory("Program files");
            Component fold2 = new Directory("Program files (x86)");
            Component fold3 = new Directory("Users");
            Component fold4 = new Directory("Games");
            Component fold5 = new Directory("Divers");
            diskC.AddFolder(fold1);
            diskC.AddFolder(fold2);
            diskC.AddFolder(fold3);
            diskC.AddFolder(fold4);
            diskC.AddFolder(fold5);
            //diskC.AddFolder(fold1);
            // добавляем в нее файлы
            Component txtFile = new File("readme.txt", 300);
            Component csFile = new File("Program.cs", 400);
            Component file1 = new File("Engine.exe", 1500);
            //docsFolder.AddFile(txtFile);
            docsFolder.AddFile(csFile);
            diskC.AddFile(txtFile);
            diskC.AddFile(file1);
            diskC.AddFolder(docsFolder);
            diskC.Print();
            Console.WriteLine(diskC.Size());
            Console.Read();
        }
    }
    abstract class Component
    {
        protected internal string name;
        public Component(string name) { this.name = name; }
        public virtual void AddFolder(Component component) { }
        public virtual void AddFile(Component component) { }
        public virtual void RemoveFolder(Component component) { }
        public virtual void RemoveFile(File component) { }
        public virtual int Size() { return 0; }
        public virtual void Print() => Console.WriteLine(name + " ");
    }
    class Directory : Component
    {
        private List<Component> folders = new List<Component>();
        private List<Component> files = new List<Component>();
        public Directory(string name) : base(name) { }
        public override void AddFolder(Component component)
        {
            if (!folders.Contains(component)) folders.Add(component);
        }
        public override void AddFile(Component file)
        {
            if (!files.Contains(file))
                files.Add(file);
        }
        public override void RemoveFolder(Component component) => folders.Remove(component);
        public override void RemoveFile(File component) => files.Remove(component);
        public override int Size()
        {
            int size = 0;
            foreach (var item in files) size += item.Size();
            foreach (var dir in folders) size += dir.Size();
            return size;
        }
        //public override void Print()
        //{
        //    Console.WriteLine("Каталог: " + name);
        //    if (folders.Count != 0)
        //    {
        //        Console.WriteLine("Вложеные каталоги:");
        //        for (int i = 0; i < folders.Count; i++) folders[i].Print();
        //    }
        //    if (files.Count != 0)
        //    {
        //        Console.WriteLine("Файлы:");
        //        for (int i = 0; i < files.Count; i++) files[i].Print();
        //    }
        //    //Console.WriteLine();
        //}
        public override void Print()
        {
            Console.WriteLine("Каталог: " + name);
            if (folders.Count != 0)
            {
                Console.WriteLine("Вложеные каталоги:");
                for (int i = 1; i <= folders.Count; i++)
                    if (i % 4 == 0) Console.WriteLine("\\" + folders[i - 1].name + "\\    ");
                    else Console.Write("\\" + folders[i - 1].name + "\\    ");
                Console.WriteLine();
            }
            if (files.Count != 0)
            {
                Console.WriteLine("Файлы:");
                for (int i = 1; i <= files.Count; i++) Console.Write(files[i - 1].name + "  ");
            }
            Console.WriteLine();
        }
    }
    class File : Component
    {
        int size;
        //public int Size { get { return size; } set { size = value; } }
        public File(string name, int size) : base(name) => this.size = size;
        public override int Size()
        {
            return size;
        }
    }
}
