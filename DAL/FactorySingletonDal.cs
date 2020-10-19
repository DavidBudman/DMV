using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactorySingletonDal
    {
       protected static Idal instance = null;

        protected FactorySingletonDal(){}

        public static Idal getInstance()
        {
            if(instance == null)
            {
               instance = new Dal_XML();
               // instance = new DummyDal();
            }
            return instance;
        }
    }
}
