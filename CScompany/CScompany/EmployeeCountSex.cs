﻿using System;
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
    public partial class EmployeeCountSex : Form
    {
        //ประกาศตัวแปล
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public EmployeeCountSex()
        {
            InitializeComponent();
            connectDB();
            getEmployeeCountSex();
        }

        public void connectDB()
        {
            //Computer มหาลัย
            //conn.ConnectionString = "Data Source=4924-F3;Initial Catalog=CScompany ;Integrated Security=True;";

            //Computer หอ
            conn.ConnectionString = "Data Source=DESKTOP-LIDE7TR;Initial Catalog=CScompany;Integrated Security=True";

            //conn.ConnectionString = "Data Source=DYMONJII-PC;Initial Catalog=CScompany;Integrated Security=True";
            conn.Open();
            cmd.Connection = conn;
        }

        public void getEmployeeCountSex()
        {
            cmd.CommandText = "select sex,count(*) from employee group by sex";

            //ดึงข้อมูล มาใส่ใน adapter
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            //สร้าง table มารับข้อมูลใน adapter
            DataTable table = new DataTable();
            adapter.Fill(table);

            bindingSource1.DataSource = table;
            dataGridView1.DataSource = bindingSource1;

            dataGridView1.Columns[0].HeaderText = "เพศ";
            dataGridView1.Columns[1].HeaderText = "จำนวน";

        }
    }
}
