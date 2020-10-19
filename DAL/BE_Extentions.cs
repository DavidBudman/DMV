using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DAL
{
    internal static class BE_Extentions
    {
        /// <summary>
        /// doesn't work with nested classes as proofedint ToolsTests
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        //public static T Clone<T>(this T t) where T : class, new()
        //{
        //    T result = new T();
        //    if (t.GetType().Name != "BE.Person")
        //    {

        //        result = new T();
        //        foreach (PropertyInfo item in t.GetType().GetProperties())
        //        {
        //            item.SetValue(result, item.GetValue(t, null));
        //        }
        //    }
        //    return result;
        //}

        public static Name Clone(this Name n)
        {
            return new Name
            {
                FirstName = n.FirstName,
                LastName = n.LastName
            };
        }

        public static XElement ToXML(this Name n)
        {
            return new XElement("Name",
                new XElement("FirstName", n.FirstName),
                new XElement("LastName", n.LastName)
            );
        }

        public static Name ToName(this XElement n)
        {
            return new Name
            {
                FirstName = n.Element("FirstName").Value,
                LastName = n.Element("LastName").Value
            };
        }

        public static Address Clone(this Address a)
        {
            return new Address
            {
                City = a.City,
                Number = a.Number,
                StreetName = a.StreetName
            };
        }

        public static XElement ToXML(this Address a)
        {
            return new XElement("Address",
                new XElement("City", a.City),
                new XElement("Number", a.Number.ToString()),
                new XElement("StreetName", a.StreetName)
                );
        }

        public static Address ToAddress(this XElement a)
        {
            return new Address
            {
                City = a.Element("City").Value,
                Number = Int32.Parse(a.Element("Number").Value),
                StreetName = a.Element("StreetName").Value
            };
        }

        public static DrivingTest Clone(this DrivingTest d)  //amok 
        {
            return new DrivingTest
            {
                Tester_ID = d.Tester_ID,
                Trainee_ID = d.Trainee_ID,
                Date = d.Date,
                Comment = d.Comment,
                Requirements = d.Requirements.ToList(),
                StartingPoint = d.StartingPoint.Clone(),
                Success = d.Success,
                Time = d.Time
            };
        }

        public static XElement ToXML(this DrivingTest d)
        {
            return new XElement("drivingtest",
                                 new XElement("Tester_ID", d.Tester_ID.ToString()),
                                 new XElement("Trainee_ID", d.Trainee_ID.ToString()),
                                 new XElement("Date", d.Date.ToString()),
                                 new XElement("Comment", d.Comment.ToString()),
                                 new XElement("Requirements",
                                                    (from r in d.Requirements
                                                     select new XElement("Require", r)).ToList()),
                                 new XElement(d.StartingPoint.ToXML()),
                                 new XElement("Success", d.Success.ToString()),
                                 new XElement("Time", d.Time.ToString())
                                );
        }
        public static DrivingTest toDrivingTest(this XElement d)
        {
            return new DrivingTest
            {
                Tester_ID = d.Element("Tester_ID").Value,
                Comment = d.Element("Comment").Value,
                Trainee_ID = d.Element("Trainee_ID").Value,
                Date = DateTime.Parse(d.Element("Date").Value),
                Requirements = (from s in d.Element("Requirements").Elements("Require")
                                select s.Value).ToList(),
                Success = Boolean.Parse(d.Element("Success").Value),
                StartingPoint = d.Element("StartingPoint").ToAddress(),
                Time = TimeSpan.Parse(d.Element("Time").Value)
            };
        }

        //public static Person Clone(this Person p)  //deep clone 
        //{
        //    return new Person
        //    {
        //        ID = p.ID,
        //        Address = new Address
        //        {
        //            City = p.Address.City,
        //            Number = p.Address.Number,
        //            StreetName = p.Address.StreetName//,
        //            //ZipCode = p.Address.ZipCode
        //        },
        //        DayOfBirth = p.DayOfBirth,
        //        Gender = p.Gender,
        //        Name = p.Name
        //    };
        //}

        public static Schedule Clone(this Schedule s)
        {
            Schedule result = new Schedule();
            for (int i = 0; i < s.Data.Length; i++)
            {
                if (result.Data[i].Count() > 0)
                {
                    result.Data[i] = s.Data[i].ToArray();
                }
            }
            return result;
        }

        //public static XElement ToXML(this Schedule s)
        //{
        //    return new XElement("Schedule",
        //        new XElement("Sunday", 


        //}

        public static Tester Clone(this Tester t)
        {
            Tester result = null;
            result = new Tester
            {
                Address = t.Address.Clone(),
                DayOfBirth = t.DayOfBirth,
                Expertise = t.Expertise,
                Gender = t.Gender,
                ID = t.ID,
                MaxDistance = t.MaxDistance,
                Name = t.Name,
                Experience = t.Experience,
                MaxTestsPerWeek = t.MaxTestsPerWeek,
                Luz = t.Luz.Clone()
            };
            return result;
        }



        public static Trainee Clone(this Trainee t)
        {
            Trainee result = new Trainee
            {
                Address = t.Address.Clone(),
                DayOfBirth = t.DayOfBirth,
                Gender = t.Gender,
                ID = t.ID,
                Name = t.Name,
                CarTrained = t.CarTrained,
                DrivingSchool = t.DrivingSchool,
                GearType = t.GearType,
                Instructor = t.Instructor,
                LessonsNb = t.LessonsNb // new balance running shoes
            };
            return result;
        }

        public static void SaveToXml<T>(this T source, string fullfilename)
        {
            using (FileStream file = new FileStream(fullfilename, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
                xmlSerializer.Serialize(file, source);
                file.Close();
            }
        }
        public static string ToXMLstring<T>(this T toSerialize)
        {
            using (StringWriter textWriter = new StringWriter())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
        public static T ToObject<T>(this string toDeserialize)
        {
            using (StringReader textReader = new StringReader(toDeserialize))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }
    }
}
