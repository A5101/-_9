using NUnit.Framework;
using System;
using ŒŒ¿Ëƒ_9;

namespace FileSystemTests
{
    public class Tests
    {
        [Test]
        public void TestAddWithEqualenceOnObject()
        {
            Component dir = new Directory("disk");
            Component file = new File("1.txt", 500);
            dir.Add(file);
            Assert.Throws<Exception>(()=>dir.Add(file));
        }
        [Test]
        public void TestAddWithEqualenceOnName()
        {
            Component dir = new Directory("disk");
            Component file = new File("1.txt", 500);
            Component file1 = new File("1.txt", 500);
            dir.Add(file);
            Assert.Throws<Exception>(() => dir.Add(file1));
        }
        [Test]
        public void TestRemove()
        {
            Component dir = new Directory("disk");
            Component file = new File("1.txt", 500);
            dir.Add(file);
            dir.Remove(file);
            Assert.DoesNotThrow(() => dir.Add(file));
        }
        [Test]
        public void TestSize()
        {
            Component dir = new Directory("disk");
            Component file = new File("1.txt", 500);
            Component file1 = new File("2.txt", 700);
            dir.Add(file);
            dir.Add(file1);
            Assert.AreEqual(1200, dir.Size());
        }
    }
}