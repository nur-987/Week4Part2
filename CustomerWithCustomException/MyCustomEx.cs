using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWithCustomException
{
    class MyCustomEx : Exception
    {
        public MyCustomEx()
        {

        }
        public MyCustomEx(string str) : base(str)
        {

        }
    }
}
