using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ON163;
using ON163.DB;

namespace ON163.ClassHelper
{
    public class EFClass
    {
        public static Entities context { get; } = new Entities();
    
    }
}
