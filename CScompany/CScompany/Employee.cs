using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // ต้องนำเข้า database

namespace CScompany
{
    public partial class Employee : Form
    {
        //ประกาศตัวแปล
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public Employee()
        {
            InitializeComponent();
            connectDB();
            getEmployee();
        }

        public void connectDB()
        {
            //Computer มหาลัย
            //conn.ConnectionString = "Data Source=4924-F3;Initial Catalog=CScompany2567 ;Integrated Security=True;";

            //Computer หอ
            conn.ConnectionString = "Data Source=DESKTOP-LIDE7TR;Initial Catalog=CScompany;Integrated Security=True";
            conn.Open();
            cmd.Connection = conn;
        }

        public void getEmployee()
        {
            cmd.CommandText = "select * from employee";

            //ดึงข้อมูล มาใส่ใน adapter
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            //สร้าง table มารับข้อมูลใน adapter
            DataTable table = new DataTable();
            adapter.Fill(table);

            bindingSource1.DataSource = table;
            dataGridView1.DataSource = bindingSource1;

            dataGridView1.Columns[0].HeaderText = "รหัส";
            dataGridView1.Columns[1].HeaderText = "ชื่อ";
            dataGridView1.Columns[2].HeaderText = "แผนก";
            dataGridView1.Columns[3].HeaderText = "เงินเดือน";
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            employeeCode.Clear();
            employeeName.Clear();
            salary.Clear();
            employeeCode.Focus();
        }

        private void bInsert_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "insert into employee values('" + employeeCode.Text + "','" + employeeName.Text + "','" + departmentCode.Text + "','" + salary.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("บันทึกสำเร็จ");
                getEmployee();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ค่าซ้ำ");
            }
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "update employee set employeeName = '" + employeeName.Text + "',departmentCode = '" + departmentCode.Text + "',salary = '" + salary.Text + "' where employeeCode = '" + employeeCode.Text + "' ";
                cmd.ExecuteNonQuery();
                MessageBox.Show("update สำเร็จ");
                getEmployee();
            }
            catch (Exception ex)
            {
                MessageBox.Show("update ไม่สำเร็จ");
            }
        }

        private void bDelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("delete หรือไม่", "คำเตือน", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    cmd.CommandText = "delete from employee where employeeCode = '" + employeeCode.Text + "' ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("delete สำเร็จ");
                    getEmployee();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("delete ไม่สำเร็จ");
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close หรือไม่", "คำเตือน", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Close();
            }
        }

        private void employeeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmd.CommandText = "select * from employee where employeeCode = '" + employeeCode.Text + "' ";
                //อ่านข้อมูล
                SqlDataReader rs = cmd.ExecuteReader();
                if (rs.HasRows)
                {
                    rs.Read();
                    employeeName.Text = rs.GetString(1);
                    salary.Text = rs.GetInt32(3).ToString();
                }
                else
                {
                    employeeName.Clear();
                }
                rs.Close();
            }
        }
    }
}
