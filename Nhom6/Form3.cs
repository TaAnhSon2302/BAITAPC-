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
    public partial class frmQuanLy : Form
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }
        SqlConnection cn;
        SqlCommand cmd;
        string sql = @"Data Source=ADMIN-PC\SQLEXPRESS01;Initial Catalog=Test;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();

        void loaddata()
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "Select * from HV where LopHoc = '" + cbLopHoc.Text + "' ";
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void updatedata()
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "Select * from HV";
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(sql);
            cn.Open();
            var cmd = new SqlCommand("select * from Classroom", cn);
            var dr = cmd.ExecuteReader();
            var table = new DataTable();
            table.Load(dr);
            //dr.Dispose();

            cbLopHoc.DataSource = table;
            cbLopHoc.DisplayMember = "LopHoc";

            var table1 = new DataTable();
            table1 = table.Copy();

            cbLop.DataSource = table1;
            cbLop.DisplayMember = "LopHoc";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "insert into HV values('" + txtID.Text + "',N'" + txtName.Text + "','" + dtBirth.Text + " ','" + cbGender.Text + "', N'" + txtAddress.Text + "', N'" + cbLop.Text + "')";
            cmd.ExecuteNonQuery();
            loaddata();
            foreach (Control c in this.Infor.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
            foreach (Control a in this.Infor.Controls)
            {
                if (a is ComboBox)
                    a.Text = "";
            }

        }
       


        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "Delete from HV where MaHV='" + txtID.Text + "'";
            cmd.ExecuteNonQuery();
            loaddata();
            foreach (Control c in this.Infor.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
            foreach (Control a in this.Infor.Controls)
            {
                if (a is ComboBox)
                    a.Text = "";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dtBirth.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cbGender.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            cbLop.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtID.Enabled = false;
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            cmd = cn.CreateCommand();
            cmd.CommandText = "Update HocVien set MaHV ='" + txtID.Text + "',TenHV = N'" + txtName.Text + "',NgaySinh = '" + dtBirth.Value + " ',GioiTinh=N'" + cbGender.Text + "',DiaChi=N'" + txtAddress.Text + "',LopHoc=N'" + cbLop.Text + "' where HiddenId = ";
            cmd.ExecuteNonQuery();
            loaddata();
        }

        private void frmQuanLy_DoubleClick(object sender, EventArgs e)
        {
            txtID.Enabled = true;
            foreach (Control c in this.Infor.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
            foreach (Control a in this.Infor.Controls)
            {
                if (a is ComboBox)
                    a.Text = "";
            }
        }

        private void Infor_Enter(object sender, EventArgs e)
        {

        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbLopHoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //cn = new SqlConnection(sql);
            //cn.Open();
            //loaddata();
        }

        private void cbLopHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát", "Thông Báo", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin(); ;
            frmLogin.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            frmResult frm = new frmResult();
            frm.Sender(txtName.Text);
            frm.Sender2(txtID.Text);
            frm.Show();

        }
    }
}
