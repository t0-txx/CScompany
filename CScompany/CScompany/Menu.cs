using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CScompany
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void ประเภทสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemType form = new ItemType();
            form.Show();
        }

        private void สนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Item form = new Item();
            form.Show();
        }

        private void ลกคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer form = new Customer();
            form.Show();
        }

        private void แผนกToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Department form = new Department();
            form.Show();
        }

        private void พนกงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee form = new Employee();
            form.Show();
        }
    }
}
