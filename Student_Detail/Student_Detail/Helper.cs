using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelperSpace
{
    public static class Helper
    {
        public static string ConString = System.Configuration.ConfigurationManager.ConnectionStrings["myConString"].ToString();

        public static void Clear(Form form)
        {
            foreach (var item in form.Controls)

            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
            }
        }
    }
}
