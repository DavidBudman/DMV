using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;

namespace DAL
{
    internal class Dal_XML : Idal
    {

 
        public Dal_XML()
        {
        }

        public bool AddDrivingTest(DrivingTest drivingTest)
        {
            DS.DataSourceXML.DrivingTests.Add(drivingTest.ToXML());
            DS.DataSourceXML.SaveDrivingtests();
            return true;
        }

        public bool AddTester(Tester tester)
        {
            string str = tester.ToXMLstring();
            XElement xml = XElement.Parse(str);
            DS.DataSourceXML.Testers.Add(xml);
            DS.DataSourceXML.SaveTesters();
            return true;
        }

        public bool AddTrainee(Trainee trainee)
        {
            string str = trainee.ToXMLstring();
            XElement xml = XElement.Parse(str);
            DS.DataSourceXML.Trainees.Add(xml);
            DS.DataSourceXML.SaveTrainees();
            return true;
        }

        public List<DrivingTest> GetDrivingTests()
        {
            var serializer = new XmlSerializer(typeof(DrivingTest));

            var elements = DS.DataSourceXML.Testers.Elements("DrivingTest");
            return elements.Select(element => (DrivingTest)serializer.Deserialize(element.CreateReader())).ToList();
        }

        public List<Tester> GetTesters()
        {
            var serializer = new XmlSerializer(typeof(Tester));

            var elements = DS.DataSourceXML.Testers.Elements("Tester");
            return elements.Select(element => (Tester)serializer.Deserialize(element.CreateReader())).ToList();
        }

        public List<Trainee> GetTrainees(Func<Trainee, bool> p)
        {
            var result = from t in DS.DataSourceXML.Trainees.Elements("Trainee")
                         select new Trainee
                         {
                             ID = t.Element("ID").Value,
                             Name = new Name
                             {
                                 FirstName = t.Element("Name").Element("FirstName").Value,
                                 LastName = t.Element("Name").Element("LastName").Value
                             },
                             Address = new Address
                             {
                                 City = t.Element("Address").Element("City").Value,
                                 Number = Int32.Parse(t.Element("Address").Element("Number").Value),
                                 StreetName = t.Element("Address").Element("StreetName").Value
                             },
                             Instructor = new Name
                             {
                                 FirstName = t.Element("Instructor").Element("FirstName").Value,
                                 LastName = t.Element("Instructor").Element("LastName").Value
                             },
                             CarTrained = (CarType)Enum.Parse(typeof(CarType), t.Element("CarTrained").Value),
                             DayOfBirth = DateTime.Parse(t.Element("DayOfBirth").Value),
                             DrivingSchool = t.Element("DrivingSchool").Value,
                             LessonsNb = Int32.Parse(t.Element("LessonsNb").Value),
                             GearType = (GearType)Enum.Parse(typeof(GearType), t.Element("GearType").Value),
                             Gender = (Gender)Enum.Parse(typeof(Gender), t.Element("Gender").Value)
                         };
            if (p != null)
            {
                return (from tr in result
                        where p(tr)
                        select tr).ToList();
            }
            return result.ToList();
        }

        public bool RemoveDrivingTest(DrivingTest drivingTest)
        {
            XElement drivingTests = DS.DataSourceXML.DrivingTests;
            var found = (from d in drivingTests.Elements()
                        where (d.Element("DrivingTestID").Value== drivingTest.DrivingTestID.ToString())
                        select d).FirstOrDefault();

            if (found == null)
            {
                return false;
            }
            found.Remove();
            DS.DataSourceXML.SaveDrivingtests();
            return true;
        }

        public bool RemoveTester(Tester tester)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTrainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDrivingTest(DrivingTest drivingTest)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTester(Tester tester)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTrainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }
    }
}
