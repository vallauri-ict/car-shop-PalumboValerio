using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppProject
{
    class ErProv
    {
        public static void setError(ErrorProvider error, Control controls, string msg) { error.SetError(controls, msg); }
        public static void resetError(ErrorProvider error, Control controls) { error.SetError(controls, string.Empty); }
    }
}
