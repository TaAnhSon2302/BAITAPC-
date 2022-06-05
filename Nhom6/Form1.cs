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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS01;Initial Catalog=Test;Integrated Security=True");
           
                conn.Open();
                string tk = txtName.Text;
                string mk = txtPass.Text;
                string sql = "Select * from NguoiDung Where Username='" + tk + "' and Password='" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    Form frm = new frmQuanLy();
                    this.Hide();
                    frm.Show();
                }    
                else
                {
                    MessageBox.Show("Đăng nhập thât bại");
                }    
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.YesNo);
            if (tb == DialogResult.Yes)
                Application.ExitThread();
        }

        private void btnreType_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPass.Clear();
        }
    }
}
