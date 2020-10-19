using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace BE
{
    /// <summary>
    /// טסט
    /// </summary>
    public class DrivingTest
    {
        public int DrivingTestID { get; set; }
        private DateTime _date;
        private List<string> _requirements = new List<string>();
        //  private ArrayList _requirements = new ArrayList();
        /// <summary>
        /// get set the Trainee ID
        /// </summary>
        public String Trainee_ID { get; set; }
        /// <summary>
        /// get set the Tester ID
        /// </summary>
        public String Tester_ID { get; set; }

        public DateTime Date { get => _date.Date; set => _date = value.Date; }
        public TimeSpan Time { get => Date.TimeOfDay; set => _date.AddMilliseconds(value.TotalMilliseconds); }
        public Address StartingPoint { get; set; }
        //public List<String> Requirements {
        //    get => _requirements;
        //    set => _requirements = value;
        //}
        public List<String> Requirements
        {
            get
            {
                return _requirements;
            }
            set
            {
                _requirements = value;
            }
        }
        public bool Success { get; set; }
        public String Comment { get; set; }


        public static int CurrentNumber { get; set; } = Configuration.INITIAL_TEST_NUMBER;

        public int TestNumber { get; set; }
        public string TesterID { get; set; }
        public string TraineeID { get; set; }
        public DateTime DateTime { get; set; }
        public Address StartAddress { get; set; }
        public Enums.VehicleType VehicleType { get; set; }
        public bool PassedMaintainDistance { get; set; }
        public bool PassedParkInReverse { get; set; }
        public bool PassedUseMirrors { get; set; }
        public bool PassedUseSignals { get; set; }
        public bool PassedTest { get; set; }
        public string TesterComment { get; set; }

        public override string ToString()
        {
            string result = "";

            result += String.Format("Test Number: {0}\n", TestNumber);
            result += String.Format("Tester ID: {0}\n", TesterID);
            result += String.Format("Trainee ID: {0}\n", TraineeID);
            result += String.Format("Date Time: {0}\n", DateTime);
            result += String.Format("Start Address: {0}\n", StartAddress);
            result += String.Format("Maintain Distance: {0}\n", PassedMaintainDistance ? "Passed" : "Failed");
            result += String.Format("Park In Reverse: {0}\n", PassedParkInReverse ? "Passed" : "Failed");
            result += String.Format("Use Mirrors: {0}\n", PassedUseMirrors ? "Passed" : "Failed");
            result += String.Format("Use Signals: {0}\n", PassedUseSignals ? "Passed" : "Failed");
            result += String.Format("Score: {0}\n", PassedTest ? "Passed" : "Failed");
            result += String.Format("Tester's Comment: {0}\n", TesterComment);

            return result;
        }
        public DrivingTest deepClone()
        {
            return new DrivingTest
            {
                TestNumber = this.TestNumber,
                TesterID = this.TesterID,
                TraineeID = this.TraineeID,
                DateTime = new DateTime(this.DateTime.Year, this.DateTime.Month, this.DateTime.Day),
                StartAddress = this.StartAddress,
                VehicleType = this.VehicleType,
                PassedMaintainDistance = this.PassedMaintainDistance,
                PassedParkInReverse = this.PassedParkInReverse,
                PassedUseMirrors = this.PassedUseMirrors,
                PassedUseSignals = this.PassedUseSignals,
                PassedTest = this.PassedTest,
                TesterComment = this.TesterComment
            };
        }
    }
}
