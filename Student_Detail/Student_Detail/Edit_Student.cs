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
    public partial class Edit_Student : Form
    {
        public Edit_Student()
        {
            InitializeComponent();
        }

        private void Edit_Student_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'csharpdbDataSet1.tbl_student' table. You can move, or remove it, as needed.
            this.tbl_studentTableAdapter.Fill(this.csharpdbDataSet1.tbl_student);

        }

        private void cmb_RegdID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Query = "SELECT * FROM tbl_student Where RegistrationID='"+cmb_RegdID.Text+"'";
            SqlConnection con = new SqlConnection(Helper.ConString);
            con.Open();
            SqlCommand cmd=new SqlCommand(Query, con);
            SqlDataReader DR= cmd.ExecuteReader();
            if (DR.Read())
            {
                txt_Name.Text = DR["Name"].ToString();
                txt_Fname.Text = DR["FatherName"].ToString();
                txt_Mobile.Text = DR["Mobile"].ToString();
                txt_RNo.Text = DR["RNo"].ToString();
                txt_Address.Text = DR["Address"].ToString();
                txt_Email.Text = DR["Email"].ToString();

            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
          DialogResult result=  MessageBox.Show("Are you sure you want to delete "+txt_Name.Text+" Record","Confirmation Message",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result==DialogResult.Yes)
            {
                string Query = "DELETE FROM tbl_student Where RegistrationID='" + cmb_RegdID.Text + "'";
                SqlConnection con = new SqlConnection(Helper.ConString);
                con.Open();
                SqlCommand Cmd = new SqlCommand(Query, con);
                Cmd.ExecuteNonQuery();
                Helper.Clear(this);
                MessageBox.Show("Data delete successfully!");
            }
           

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string SqlQuery = "UPDATE tbl_student SET Name='" + txt_Name.Text + "',FatherName='" + txt_Fname.Text + "',Mobile='" + txt_Mobile.Text + "',RNo='" + txt_RNo + "',Address='"+txt_Address.Text+"',Email='"+txt_Email.Text+ "' WHERE RegistrationID='\" + cmb_RegdID.Text + \"' ";
            SqlConnection con = new SqlConnection(Helper.ConString);
            con.Open();
            SqlCommand Cmd = new SqlCommand(SqlQuery, con);
            Cmd.ExecuteNonQuery();
            MessageBox.Show("Update successfully!");
        }
    }
}
