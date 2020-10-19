using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Tools.Tests
{
    [TestClass()]
    public class ToolsTests
    {
        BE.Address address = new BE.Address
        {
            City = "Jerusalem",
            Number = 21,
            StreetName = "havvad haleumi",
            //         ZipCode = 91160
        };
        //[TestMethod()]
        //public void CloneTest()
        //{
        //    BE.Address kfil = address.Clone();
        //    address.Number = 90;

        //    Console.WriteLine(address);
        //    Console.WriteLine(kfil);
        //    Assert.AreNotEqual(address, kfil);
        //}
        //[TestMethod()]
        //public void CloneTest2()
        //{
        //    Person p1 = new Person
        //    {
        //        ID = "12345",
        //        Name = new Name { FirstName = "jojo", LastName = "chalass" },
        //        Address = new Address
        //        {
        //            City = "Jerusalem",
        //            Number = 21,
        //            StreetName = "havvad haleumi",
        //            //                  ZipCode = 91160
        //        },
        //        DayOfBirth = DateTime.Now.AddYears(-20),
        //        Gender = Gender.MALE
        //    };

        //    Person p2 = p1.Clone();
        //    p1.Address.City = "TLV";
        //    Console.WriteLine(p1);
        //    Console.WriteLine(p2);
        //    Assert.AreNotEqual(address, p2);
        //}
        [TestMethod()]
        public void TesterTestToString()
        {
            Tester tester = new Tester
            {
                ID = "12345",
                Name = new Name { FirstName = "jojo", LastName = "chalass" },
                Address = new Address
                {
                    City = "Jerusalem",
                    Number = 21,
                    StreetName = "havvad haleumi",
                    //                  ZipCode = 91160
                },
                DayOfBirth = DateTime.Now.AddYears(-20),
                Gender = Gender.MALE,
                Experience = 10,
                Expertise = CarType.Truck_Heavy,
                MaxDistance = 2,
                MaxTestsPerWeek = 1,
                Luz = new Schedule
                {
                    Data = new bool[5][]
                     {
                         new bool[]{ false, false, true, false, false, false},
                         new bool[]{ false, false, false, false, false, false},
                         new bool[]{ false, false, false, false, false, false},
                         new bool[]{ false, false, true, false, false, false},
                         new bool[]{ false, false, false, false, false, false}
                     }
                }
            };
            string printed = tester.ToString();
            Console.WriteLine(tester);
            Assert.AreEqual(printed, "hyugyuyg");
        }
        [TestMethod()]
        public void Testshedule()
        {
            Schedule stam = new Schedule();
            stam.Data = new bool[5][]
            {
                new bool[6] { false, false, true, false, false, false},
                new bool[6] { true, false, false, false, false, false},
                new bool[6] { false, false, false, false, false, false},
                new bool[6] { true, false, true, true, false, false},
                new bool[6] { false, false, false, false, false, false}
            };
            Console.WriteLine(stam);
            Assert.IsTrue(stam != null);
        }
    };
}
