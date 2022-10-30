using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connecting_SQL
{
    public partial class Form1 : Form
    {
        string ConString = System.Configuration.ConfigurationManager.ConnectionStrings["myConString"].ToString();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string sqlQuery = "INSERT INTO tbl_student VALUES('" + txt_RgdID.Text + "','" + txt_Name.Text + "','" + txt_Fname.Text + "','" + txt_Mobile.Text + "','" + txt_Rno.Text + "','" + txt_Email.Text + "','" + txt_Address.Text + "')";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.ExecuteNonQuery();
        }
    }
}
