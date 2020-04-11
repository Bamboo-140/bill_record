using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bill_record
{
    class CalcMask
    {
        public static string RestoreMask(string message, int key)
        {
            if (message.Equals("") || message.Length == 0)
            {
                return "";
            }
            StringBuilder str = new StringBuilder();
            str.Append("");
            for (int j = 0; j < (8 * key); j++)
            {
                str.Clear();
                for (int i = 0; i < message.Length; i++)
                {
                    str.Append((char)(((int)message[i]) - ((i * 168 + key) % 128)));
                }
                message = str.ToString();
            }
            return str.ToString();
        }

        public static string CalcMaskFunc(string message, int key)
        {
            if (message.Equals("") || message.Length == 0)
            {
                return "";
            }
            StringBuilder str = new StringBuilder();
            str.Append("");
            for (int j = 0; j < (8 * key); j++)
            {
                str.Clear();
                for (int i = 0; i < message.Length; i++)
                {
                    str.Append((char)(((int)message[i]) + ((i * 168 + key) % 128)));
                }
                message = str.ToString();
            }
            return str.ToString();
        }
    }
}
