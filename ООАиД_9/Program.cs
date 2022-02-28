﻿using System;
using System.Collections.Generic;

namespace ООАиД_9
{
    class Program
    {
        static void Main()
        {
            Component fileSystem = new Directory("Файловая система");
            Component diskC = new Directory("Диск С");
            Component pngFile = new File("12345.png", 100);
            Component docxFile = new File("Document.docx", 200);          
            fileSystem.Add(diskC);
            Component docsFolder = new Directory("Мои Документы");
            diskC.Add(docsFolder);
            diskC.Add(pngFile);
            diskC.Add(docxFile);
            Component fold1 = new Directory("Program files");
            Component fold2 = new Directory("Program files (x86)");
            Component fold3 = new Directory("Users");
            Component fold4 = new Directory("Games");
            Component fold5 = new Directory("Drivers");
            //Component fold6 = new Directory("Drivers");
            diskC.Add(fold1);
            diskC.Add(fold2);
            diskC.Add(fold3);
            diskC.Add(fold4);
            diskC.Add(fold5);
            //diskC.Add(fold6);
            Component txtFile = new File("readme.txt", 300);
            //Component txtFile1 = new File("Readme.txt", 300);
            Component csFile = new File("Program.cs", 400);
            Component file1 = new File("Engine.exe", 1500);
            docsFolder.Add(csFile);
            diskC.Add(txtFile);
            //diskC.Add(txtFile1);
            diskC.Add(file1);
            diskC.Print();
            Console.WriteLine(diskC.Size() + " байт");
            Console.Read();
        }
    }
    public abstract class Component
    {
        protected internal string name;
        public Component(string name) => this.name = name;
        public virtual void Add(Component component) { }
        public virtual void Remove(Component component) { }
        public virtual int Size() { return 0; }
        public virtual void Print() => Console.WriteLine(name + " ");
    }
    public class Directory : Component
    {
        private List<Component> foldersAndFiles = new List<Component>();
        public Directory(string name) : base(name) { }
        public override void Add(Component component) 
        {
            if (foldersAndFiles.Contains(component)) throw new Exception("Такой объект уже есть");
            foreach (var item in foldersAndFiles)
            {
                if (item.name.ToUpper() == component.name.ToUpper()) throw new Exception("Такой объект уже есть");
            }
            foldersAndFiles.Add(component);
        }
        public override void Remove(Component component) => foldersAndFiles.Remove(component);
        public override int Size()
        {
            int size = 0;
            foreach (var dir in foldersAndFiles) size += dir.Size();
            return size;
        }
        //public override void Print()
        //{
        //    foldersAndFiles.Sort((c1, c2) =>
        //    {
        //        if (c1.GetType() == c2.GetType()) return 0;
        //        if (c1 is File) return 1;
        //        return -1;
        //    });
        //    Console.WriteLine("Каталог: " + name);
        //    if (foldersAndFiles.Count != 0)
        //    {
        //        Console.WriteLine("Вложеные каталоги и файлы: ");
        //        for (int i = 1; i <= foldersAndFiles.Count; i++)
        //            if (i % 4 == 0) Console.WriteLine(foldersAndFiles[i - 1].name + ", ");
        //            else Console.Write( foldersAndFiles[i - 1].name +  ", ");
        //        Console.WriteLine();
        //        Console.WriteLine();
        //    }
        //}
        public override void Print()
        {
            foldersAndFiles.Sort((c1, c2) =>
            {
                if (c1.name == c2.name) return 0;
                if (string.Compare(c1.name, c2.name) > 0) return 1;
                return -1;
            });
            Console.WriteLine("Каталог: " + name);
            if (foldersAndFiles.Count != 0)
            {
                Console.WriteLine("Вложеные каталоги: ");
                for (int i = 0; i < foldersAndFiles.Count; i++)
                    if (foldersAndFiles[i] is Directory) Console.Write(foldersAndFiles[i].name + ", ");
                Console.WriteLine();
                Console.WriteLine("Вложеные файлы: ");
                for (int i = 0; i < foldersAndFiles.Count; i++)
                    if (foldersAndFiles[i] is File) Console.Write(foldersAndFiles[i].name + ", ");
                Console.WriteLine();
            }
        }
    }
    public class File : Component
    {
        int size;
        public File(string name, int size) : base(name) => this.size = size;
        public override int Size() { return size; }
    }
}
