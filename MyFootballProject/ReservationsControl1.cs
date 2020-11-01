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
    public partial class ReservationsControl1 : UserControl
    {
        FootballProjectEntities db = new FootballProjectEntities();
        public ReservationsControl1()
        {
            InitializeComponent();
        }
        public void FillDataRezerv()
        {
            dtgRezervation.DataSource = db.Rezervs.Select(re => new
            {
                re.Id,
                Customer_Name = re.Customer.Fullname,
                Stadium_Name = re.Stadion.Name,              
                Start_Time = re.DateFrom,
                End_Time = re.DateTo,
                re.Price

            }).ToList();
            dtgRezervation.Columns[0].Visible = false;
            db.SaveChanges();
        }

        private void ReservationsControl1_Load(object sender, EventArgs e)
        {
            FillDataRezerv();
        }
    }
}
