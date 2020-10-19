using Microsoft.VisualStudio.TestTools.UnitTesting;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Tests
{
    [TestClass()]
    public class ScheduleTests
    {
        Schedule stam = new Schedule(new bool[5, 6]
        {
                    { false, false, true, false, false, false},
                    { true, false, false, false, false, false},
                    { false, false, false, false, false, false},
                    { true, false, true, true, false, false},
                    { false, false, false, false, false, false}
        });
        [TestMethod()]
        public void ScheduleTest()
        {
            Console.WriteLine("kuku");
            Assert.Fail();
        }

        [TestMethod()]
        public void Testshedule()
        {
            Console.WriteLine(stam);
            Assert.Fail();
        }
        [TestMethod()]
        public void CloneTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }
    }
}