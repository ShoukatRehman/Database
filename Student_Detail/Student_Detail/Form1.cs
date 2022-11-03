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
using HelperSpace;

namespace Student_Detail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            String SqlQuery = "INSERT INTO tbl_student VALUES('"+txt_RgdtID.Text+"','"+txt_Name.Text+"','"+txt_Fname.Text+"','"+txt_Mobile.Text+"','"+txt_RollNo.Text+"','"+txt_Email.Text+"','"+txt_Address.Text+"')";
            SqlConnection con = new SqlConnection(Helper.ConString);
            con.Open();
            SqlCommand cmd = new SqlCommand(SqlQuery, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Save Successfully", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Helper.Clear(this);
            this.tbl_studentTableAdapter.Fill(this.csharpdbDataSet.tbl_student);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'csharpdbDataSet.tbl_student' table. You can move, or remove it, as needed.
            this.tbl_studentTableAdapter.Fill(this.csharpdbDataSet.tbl_student);

        }
    }
}
