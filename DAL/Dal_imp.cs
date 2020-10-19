using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Tools;

namespace DAL
{
    public class Dal_imp : Idal
    {
        private void initTester()
        {
            AddTester(new Tester
            {
                ID = "1111",
                Name = new Name ("jojo","chalass"),
                Address = new Address("havvad haleumi", 21, "Jerusalem"),
                
                DateOfBirth = DateTime.Now.AddYears(-45),
                Gender = BE.Enums.Gender.MALE,
                YearsExperience = 10,
                Expertise = CarType.Truck_Heavy,
                MaxDistance = 2,
                MaxTestsPerWeek = 1,
                Luz = new Schedule
                {
                    Data = new bool[5][]
                    {
                        new bool[6] { false, false, true, false, false, false},
                        new bool[6] { false, false, false, false, false, false},
                        new bool[6] { false, false, false, false, false, false},
                        new bool[6] { false, false, true, false, false, false},
                        new bool[6] { false, false, false, false, false, false}
                    }
                }
            });
        }

        public Dal_imp()
        {
            DS.DataSource.init();
        }
        public bool AddDrivingTest(DrivingTest drivingTest)
        {
            DS.DataSource.DrivingtestsList.Add(drivingTest.Clone());
            return true;
        }

        public bool AddTester(Tester tester)
        {
            foreach (Tester item in DS.DataSource.TestersList)
            {
                if(item.ID == tester.ID)
                {
                    throw new Exception("Tester already exist");
                 //   return false;
                }
            }
            DS.DataSource.TestersList.Add(tester.Clone());
            return true;
        }

        public bool AddTrainee(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public List<DrivingTest> GetDrivingTests()
        {
            throw new NotImplementedException();
        }

        public List<Tester> GetTesters()
        {
            // return
            //(from item in DS.DataSource.TestersList
            // select item.Clone()
            //).ToList();
                      
            return DS.DataSource.TestersList.Select(item => item.Clone()).ToList();
        }
        // do not use Predicate<T> with Linq, instead use Func<T,bool>
        // public List<Trainee> GetTrainees(Predicate<Trainee> p =null) 
        public List<Trainee> GetTrainees(Func<Trainee,bool> p = null)
        {
            IEnumerable<Trainee> result = null;
           
            if(p !=null)
            {
                result = from t in DS.DataSource.TraineesList
                         where (p(t))
                         select t.Clone();
            }
            else
            {
            result = from t in DS.DataSource.TraineesList
                        select t.Clone();
            }
            return result.ToList();
        }

        public bool RemoveDrivingTest(DrivingTest drivingTest)
        {
             DrivingTest killit = (from d in DS.DataSource.DrivingtestsList
                                   where (d.DrivingTestID==drivingTest.DrivingTestID)
                                   select d).FirstOrDefault();

            return DS.DataSource.DrivingtestsList.Remove(killit);
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
            var x = (from d in DS.DataSource.DrivingtestsList
                     where (d.DrivingTestID == drivingTest.DrivingTestID)
                     select d).FirstOrDefault();

            //x.Tester_ID = drivingTest.Tester_ID;
            //x.StartingPoint = drivingTest.StartingPoint;

            DS.DataSource.DrivingtestsList.Remove(x);
            DS.DataSource.DrivingtestsList.Add(drivingTest.Clone());

           return true;
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
