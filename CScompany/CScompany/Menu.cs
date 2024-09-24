using CrystalDecisions.CrystalReports.Engine;
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

        private void สนคาToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemList form = new ItemList();
            form.Show();
        }

        private void ประเภทสนคาToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemTypeList form = new ItemTypeList();
            form.Show();
        }

        private void พนกงานToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EmployeeList form = new EmployeeList();
            form.Show();
        }

        private void ลกคาToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomerList form = new CustomerList();
            form.Show();
        }

        private void แผนกToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DepartmentList form = new DepartmentList();
            form.Show();
        }

        private void สรปยอดขายแยกตาใลมใบToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceDetailCount form = new InvoiceDetailCount();
            form.Show();
        }

        private void สรปจำนวนพนกงานแยกตามเพศToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeCountSex form = new EmployeeCountSex();
            form.Show();
        }

        private void รวมมลคาสนคาในคลงสยแยกตามประเภทToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemCount form = new ItemCount();
            form.Show();
        }

        private void สรปจำนวนพนกงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeCount form = new EmployeeCount();
            form.Show();
        }

        private void แสดงขอมลลกคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEmployeeReport form = new ShowEmployeeReport();
            form.Show();
        }

        private void showReportAll(String filename) {
            ReportDocument report = new ReportDocument();
            report.Load("E:\\CIT0003\\CScompany\\CScompany\\" + filename);

            ShowAllReport form = new ShowAllReport();
            form.crystalReportViewer1.ReportSource = report;
            form.crystalReportViewer1.Refresh();
            form.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showReportAll("CustomerReport.rpt");
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showReportAll("EmployeeReport.rpt");
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showReportAll("ItemReport.rpt");
        }
    }
}
