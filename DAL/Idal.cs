using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface Idal
    {
        bool AddTester   (Tester tester);
        bool RemoveTester(Tester tester);
        bool UpdateTester(Tester tester);

        bool AddTrainee(Trainee trainee);
        bool RemoveTrainee(Trainee trainee);
        bool UpdateTrainee(Trainee trainee);

        bool AddDrivingTest(DrivingTest drivingTest);
        bool RemoveDrivingTest(DrivingTest drivingTest);
        bool UpdateDrivingTest(DrivingTest drivingTest);

        List<Tester> GetTesters();
        List<Trainee> GetTrainees(Func<Trainee,bool> p);
        List<DrivingTest> GetDrivingTests();
    }
}
