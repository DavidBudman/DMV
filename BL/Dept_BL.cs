using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BE;

namespace BL
{
    internal class Dept_BL : IBL
    {
        private static DAL.Idal instance = DAL.FactorySingletonDal.getInstance();
        //MapQuest API KEY requested for using it
        String API_KEY = @"pcNsEXrtoCyYnfAQFBGTTHCx1cUDnMT3";

        public bool AddTester(Tester tester)
        {
            if (DateTime.Now.Year - tester.DateOfBirth.Year < 40)
            {
                throw new Exception("tester under 40 years");
                //  return false;
            }
            try
            {
                instance.AddTester(tester);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }
        public bool RemoveTester(Tester tester) { return true; }
        public bool UpdateTester(Tester tester) { return true; }

        public bool AddTrainee(Trainee trainee)
        {
            try
            {
                instance.AddTrainee(trainee);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }
        public bool RemoveTrainee(Trainee trainee) { return true; }
        public bool UpdateTrainee(Trainee trainee) { return true; }

        public bool AddDrivingTest(DrivingTest drivingTest) { return true; }
        public bool RemoveDrivingTest(DrivingTest drivingTest) { return true; }
        public bool UpdateDrivingTest(DrivingTest drivingTest) { return true; }

        public List<Tester> GetTesters()
        {
            return instance.GetTesters();
        }
        public List<Trainee> GetTrainees() //Male only
        {
            try
            {
                return instance.GetTrainees((Trainee t) => t.Gender == BE.Enums.Gender.MALE);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public List<DrivingTest> GetDrivingTests() { return null; }

        
        public void checkTesterDistance(Address addr1,RunWorkerCompletedEventHandler completed)
        {
            BackgroundWorker backgroundworker;
            foreach (var item in GetTesters())
            {
                backgroundworker = new BackgroundWorker();
                backgroundworker.DoWork += Backgroundworker_DoWork;
                backgroundworker.RunWorkerCompleted += completed;
                backgroundworker.RunWorkerAsync(new List<Object> { addr1, item });
            }
        }

        private void Backgroundworker_DoWork(object sender, DoWorkEventArgs e)
        {
            double distinKm;

            List<Object> objs = e.Argument as List<Object>;

            //List<BE.Address> addr = e.Argument as List<BE.Address>;
            Address traineeAddress = objs[0] as Address;
            Tester currentTester = objs[1] as Tester;


            string KEY = API_KEY;

            string origin = traineeAddress.Street + " " + traineeAddress.Number + " st. " + traineeAddress.City;
            string destination = currentTester.Address.Street + " " + currentTester.Address.Number + " st. " + currentTester.Address.City;

            string url = @"https://www.mapquestapi.com/directions/v2/route" +
            @"?key=" + KEY +
            @"&from=" + origin +
            @"&to=" + destination +
            @"&outFormat=xml" +
            @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
            @"&enhancedNarrative=false&avoidTimedConditions=false";
            //request from MapQuest service the distance between the 2 addresses
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            //the response is given in an XML format
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
            //we have the expected answer
            {
                //display the returned distance
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                double distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);
                // Console.WriteLine("Distance In KM: " + distInMiles * 1.609344);

                distinKm = (distInMiles * 1.609344);

                if (distinKm <= currentTester.MaxDistance)
                {
                    e.Result = currentTester;
                }
                else
                {
                    e.Result = null;
                }
                 //display the returned driving time
                // XmlNodeList formattedTime = xmldoc.GetElementsByTagName("formattedTime");
                // string fTime = formattedTime[0].ChildNodes[0].InnerText;
                //  Console.WriteLine("Driving Time: " + fTime);
            }
            //else if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "402")
            ////we have an answer that an error occurred, one of the addresses is not found
            //{
            //    // Console.WriteLine("an error occurred, one of the addresses is not found. try again.");
            //    throw new Exception("an error occurred, one of the addresses is not found. try again.");
            //    //MessageBox.Show("an error occurred, one of the addresses is not found. try again.");
            //}
            //else //busy network or other error...
            //{
            //    // Console.WriteLine("We have'nt got an answer, maybe the net is busy...");
            //    throw new Exception("We have'nt got an answer, maybe the net is busy...");
            //    //MessageBox.Show("We have'nt got an answer, maybe the net is busy...");
            //}
        }

        public IEnumerable<Person> GetAllPersons()
        {
            IEnumerable<Person> result1 = (from p in instance.GetTrainees(null)
                                           select p);
            IEnumerable<Person> result2 = (from p in instance.GetTesters()
                                           select p);
            return result1.Concat(result2);

            //List<Person> list = new List<Person>();

            //list.AddRange(GetTrainees());
            //list.AddRange(GetTesters());

            //return list;
        }
        // private bool SelectMaleTrainee(Trainee t)
        // {
        //       return (t.Gender==Gender.MALE);
        // }
    }
}
