using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventArgs
{
    class MyCustomExceptions : Exception
    {
        public new Exception InnerException { get; private set; }
        public MyCustomExceptions()
        {

        }
        public MyCustomExceptions(string str, Exception ex) : base(str)
        {
            InnerException = ex;
        }


    }

}
