using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFootballProject.models;

namespace MyFootballProject
{
    public partial class ReportControl1 : UserControl
    {
        FootballProjectEntities db = new FootballProjectEntities();
        public ReportControl1()
        {
            InitializeComponent();
        }

        public void FillDataGrid()
        {
            dtgReport.DataSource = db.Rezervs.Select(r => new
            {
                Customer_Name = r.Customer.Fullname,
                r.Price
            }).ToList();
            db.SaveChanges();
        }

        private void ReportControl1_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }
    }
}
