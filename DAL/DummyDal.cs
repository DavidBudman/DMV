using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    class DummyDal : Idal
    {
        public bool AddDrivingTest(DrivingTest drivingTest)
        {
            DS.DataSource.DrivingtestsList.Add(drivingTest.Clone());
            return true;
        }

        public bool AddTester(Tester tester)
        {
            //  DS.DataSource.TestersList.Add(tester.Clone());
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
            return DS.DataSource.TestersList.ToList();
        }

        public List<Trainee> GetTrainees(Predicate<Trainee> p = null)
        {
            throw new NotImplementedException();
        }

        public List<Trainee> GetTrainees(Func<Trainee, bool> p)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDrivingTest(DrivingTest drivingTest)
        {
            throw new NotImplementedException();
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