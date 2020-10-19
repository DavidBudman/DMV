using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactorySingletonBL
    {
           protected static IBL instance = null;

            protected FactorySingletonBL() { }

            public static IBL getInstance()
            {
                if (instance == null)
                {
                    instance = new Dept_BL();
                }
                return instance;
            }
        }
    }
