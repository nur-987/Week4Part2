using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventArgs
{
    class MyCustomArgs : EventArgs
    {
        public int NewCount { get; set; }
    }
}
