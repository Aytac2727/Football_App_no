using MyFootballProject.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFootballProject
{
    public partial class AdminForm : Form
    {
        
        public AdminForm()
        {
            InitializeComponent();
            SlidePanel.Height = btnHome.Height;
            SlidePanel.Top = btnHome.Top;
            homeControl12.BringToFront();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnHome.Height;
            SlidePanel.Top = btnHome.Top;
            homeControl12.BringToFront();
        }


      

            

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnCustomer.Height;
            SlidePanel.Top = btnCustomer.Top;
            userCustomerControl12.BringToFront();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnRoom.Height;
            SlidePanel.Top = btnRoom.Top;
            roomControl12.BringToFront();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStadium_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnStadium.Height;
            SlidePanel.Top = btnStadium.Top;
            stadiumControl12.BringToFront();
        }


        private void btnWorker_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnWorker.Height;
            SlidePanel.Top = btnWorker.Top;
            workerControl11.BringToFront();
        }

        private void btnRezervations_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnRezervations.Height;
            SlidePanel.Top = btnRezervations.Top;
            reservationsControl11.BringToFront();
        }
    }
    }

