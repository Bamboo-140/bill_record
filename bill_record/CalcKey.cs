using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bill_record
{
    class CalcKey
    {
        public static int CalcKeyFun(string seed)
        {
            int key = 1;
            if (seed.Length != 0)
            {
                for (int i = 0; i < seed.Length; i++)
                {
                    key += (int)seed[i];
                }
            }
            return key;
        }
    }

}
