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
using System.IO;
using System.Reflection.Emit;

namespace CScompany
{
    public partial class Item : Form
    {
        //ประกาศตัวแปล
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public Item()
        {
            InitializeComponent();
            connectDB();
            getItem();
            getItemType();
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

        public void getItem()
        {
            cmd.CommandText = "select itemCode,itemName,typeCode,price,qty,price*qty,image from item";

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
            dataGridView1.Columns[2].HeaderText = "ปรเภท";
            dataGridView1.Columns[3].HeaderText = "ราคา";
            dataGridView1.Columns[4].HeaderText = "จำนวน";
            dataGridView1.Columns[5].HeaderText = "เป็นเงิน";
            dataGridView1.Columns[6].HeaderText = "ชื่อรูป";
        }

        public void getItemType()
        {
            cmd.CommandText = "select * from itemType";

            //ดึงข้อมูล มาใส่ใน adapter
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            //สร้าง table มารับข้อมูลใน adapter
            DataTable table = new DataTable();
            adapter.Fill(table);

            bindingSource2.DataSource = table;

            itemType.DataSource = bindingSource2;
            itemType.DisplayMember = "typeName";
            itemType.ValueMember = "typeCode";
            typeCode.Text = itemType.SelectedValue.ToString();
        }

        private void itemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(itemType.SelectedIndex >= 0)
            {
                typeCode.Text = itemType.SelectedValue.ToString();
            }
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            itemCode.Clear();
            itemName.Clear();
            price.Clear();
            qty.Clear();
            amount.Clear();
            itemCode.Focus();
        }

        private void bInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string extension = "",pictureName = "";
                extension = System.IO.Path.GetExtension(openFileDialog1.FileName);
                pictureName = itemCode.Text + extension;
                System.IO.File.Copy(openFileDialog1.FileName, "G:\\CIT0003\\CScompany\\img\\" + pictureName);
                cmd.CommandText = "insert into item values('" + itemCode.Text + "','" + itemName.Text + "','" + typeCode.Text + "','" + price.Text + "','" + qty.Text + "','" + pictureName + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("บันทึกสำเร็จ");
                getItem();
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
                string extension = "", pictureName = "";
                if(openFileDialog1.FileName == "openFileDialog1") 
                {
                    extension = System.IO.Path.GetExtension(openFileDialog1.FileName);
                    pictureName = itemCode.Text + extension;
                    //System.IO.File.Delete("G:\\CIT0003\\CScompany\\img\\" + pictureName);
                    System.IO.File.Copy(openFileDialog1.FileName, "G:\\CIT0003\\CScompany\\img\\" + pictureName);
                }
                cmd.CommandText = "update item set itemName = '" + itemName.Text + "',typeCode = '" + typeCode.Text + "',price = '" + price.Text + "',qty = '" + qty.Text + "',image = '" + pictureName + "'  where itemCode = '" + itemCode.Text + "' ";
                cmd.ExecuteNonQuery();
                MessageBox.Show("update สำเร็จ");
                getItem();
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
                    cmd.CommandText = "delete from item where itemCode = '" + itemCode.Text + "' ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("delete สำเร็จ");
                    getItem();
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

        private void itemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmd.CommandText = "select *,price*qty from item where itemCode = '" + itemCode.Text + "' ";
                //อ่านข้อมูล
                SqlDataReader rs = cmd.ExecuteReader();
                if (rs.HasRows)
                {
                    rs.Read();
                    itemName.Text = rs.GetString(1);
                    price.Text = rs.GetInt32(3).ToString();
                    qty.Text = rs.GetInt32(4).ToString();
                    try { 
                        pictureBox1.Image = System.Drawing.Image.FromFile("G:\\CIT0003\\CScompany\\img\\" + rs.GetString(5)); 
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    itemName.Clear();
                }
                rs.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);

        }

        private void amountText() {
            try
            {
                amount.Text = (int.Parse(price.Text) * int.Parse(qty.Text)) + "";
            }
            catch (Exception ex)
            {
                amount.Clear();
            }
        }

        private void price_TextChanged(object sender, EventArgs e)
        {
            amountText();
        }

        private void qty_TextChanged(object sender, EventArgs e)
        {
            amountText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //System.IO.File.Copy("F:\\profile\\profile (1).jpg", "F:\\CIT0003\\CScompany\\img\\1.jpg");
            //System.IO.File.Delete("F:\\CIT0003\\CScompany\\img\\1.jpg");
        }
    }
}
