using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Messagecs
    {
        public static void showMessageBox(string type, string message)
        {
            switch (type)
            {
                case "ok":
                    MessageBox.Show(message, "成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                    break;
                case "error":
                    MessageBox.Show(message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
