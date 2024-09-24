using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // ต้องนำเข้า database
using System.Windows.Forms;

namespace CScompany
{
    public partial class DepartmentList : Form
    {
        //ประกาศตัวแปล
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public DepartmentList()
        {
            InitializeComponent();
            connectDB();
            getDepartmentList();
        }

        public void connectDB()
        {
            //Computer มหาลัย
            conn.ConnectionString = "Data Source=4924-F3;Initial Catalog=CScompany ;Integrated Security=True;";

            //Computer หอ
            //conn.ConnectionString = "Data Source=DESKTOP-LIDE7TR;Initial Catalog=CScompany;Integrated Security=True";
            conn.Open();
            cmd.Connection = conn;
        }

        public void getDepartmentList()
        {
            cmd.CommandText = "select * from department";

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
        }
    }
}
