using System.Collections.Generic;
using System.ComponentModel;
using BE;

namespace BL
{
    public interface IBL
    {
        bool AddDrivingTest(DrivingTest drivingTest);
        bool AddTester(Tester tester);
        bool AddTrainee(Trainee trainee);

        bool RemoveDrivingTest(DrivingTest drivingTest);
        bool RemoveTester(Tester tester);
        bool RemoveTrainee(Trainee trainee);

        bool UpdateDrivingTest(DrivingTest drivingTest);
        bool UpdateTester(Tester tester);
        bool UpdateTrainee(Trainee trainee);

        List<DrivingTest> GetDrivingTests();
        List<Tester> GetTesters();
        List<Trainee> GetTrainees();
        IEnumerable<Person> GetAllPersons();
        void checkTesterDistance(Address addr1, RunWorkerCompletedEventHandler completed);

    }
}