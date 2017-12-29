using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamCypher.Helper
{
    static class UIEx
    {
        public static void ShowNotice(string caption, string message)
        {
            var buttons = MessageBoxButtons.OK;
            var result = MessageBox.Show(message, caption, buttons);
        }
    }
}
