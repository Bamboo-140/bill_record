using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bill_record
{
    class RecalcMask
    {
        public String CalcMask(string str)
        {
            //string calcResult= string.Empty;
            if(String.IsNullOrEmpty(str))
            {
                return "";
            }
            StringBuilder strMask = new StringBuilder();
            int i = 0;
            for(i = 0; i < str.Length;i++)
            {
                strMask.Append((char)(((int)(str[i])) + (((i * 186)) % 128) - 1));
            }
            return strMask.ToString();
        }
    }
}
