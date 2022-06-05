using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Nhom6
{
    public partial class frmResult : Form
    {
        public delegate void SendMessage(string Message);
        public SendMessage Sender,Sender2;
        SqlConnection cn;
        SqlCommand cmd;
        string sql = @"Data Source=ADMIN-PC\SQLEXPRESS01;Initial Catalog=Test;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
           public frmResult()
        {
            InitializeComponent();
            Sender = new SendMessage(GetName); 
            Sender2 = new SendMessage(GetID);
           
        }

        public void GetName(string Message)
        {
           lblName.Text = Message;
        }
        public void GetID(string Message)
        {
            lblID.Text = Message;
        }


        void loaddata()
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "Select DiemBT, DiemKT, DiemFinal, TongKet from HV inner join KetQua on HV.MaHV = KetQua.MaHV where HV.MaHV ='"+lblID.Text+"'";
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            txtBT.Enabled = false;
            txtKT.Enabled = false; 
            txtTest.Enabled = false;
            
        }

        private void frmResult_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(sql);
            loaddata();
            this.txtBT.Text = dt.Rows[0][0].ToString();
            this.txtKT.Text = dt.Rows[0][1].ToString();
            this.txtTest.Text = dt.Rows[0][2].ToString();
            this.txtFinal.Text = dt.Rows[0][3].ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
