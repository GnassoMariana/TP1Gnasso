using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1Gnasso.WForms.Helpers
{
    public class ErrorHelper
    {
        public static void ShowErrors(List<string> errorList)
        {
            string errors = string.Join("\n", errorList);
            MessageBox.Show(errors, "Errores",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}

