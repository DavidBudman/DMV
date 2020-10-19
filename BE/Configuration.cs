using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Configuration
    {
        // tester
        public const int MIN_TESTER_AGE = 40;
        public const int MAX_TESTER_AGE = 99;
        public const int MIN_TESTING_HOUR = 9;
        public const int MAX_TESTING_HOUR = 14;
        public const int INITIAL_TEST_NUMBER = 0;

        // trainee
        public const int MIN_TRAINEE_AGE = 18;

        // test
        public const int MIN_DAYS_FROM_LAST_TEST = 7;
        public const int MIN_TRAINEE_LESSONS = 20;
    }
}
