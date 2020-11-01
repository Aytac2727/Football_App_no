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
    
    public partial class WorkersForm : Form
    {
        FootballProjectEntities db = new FootballProjectEntities();
        private AllWorker ActiveWorker;
        
      
        public WorkersForm(AllWorker wor)
        {
            ActiveWorker = wor;
            InitializeComponent();
        }

        public void FillDataRezerv()
        {
            dtgRezervation.DataSource = db.Rezervs.Select(re => new
            {
                re.Id,
                Customer_Name = re.Customer.Fullname,
                Stadium_Name = re.Stadion.Name,
                Room_Name = re.Reservation_To_Rooms,
                re.DateFrom,
                re.DateTo,
                re.Price

            }).ToList();
            dtgRezervation.Columns[0].Visible = false;
            db.SaveChanges();
        }
      
        public void FillComboCustomer()
        {
            cmbCustomer.Items.AddRange(db.Customers.Select(c => c.Fullname).ToArray());
        }

        public void FillComboRoom()
        {
            cmbRoom.Items.AddRange(db.Rooms.Select(c => c.Name).ToArray());
        }

        public void FillComboStadium()
        {
            cmbStadium.Items.AddRange(db.Stadions.Select(c => c.Name).ToArray());
        }

        private void WorkersForm_Load(object sender, EventArgs e)
        {
            FillComboCustomer();
            FillComboStadium();
            FillComboRoom();
            FillDataRezerv();
        }

        

        private void btnAddRezerv_Click(object sender, EventArgs e)
        {
            string cusName = cmbCustomer.Text;
            string roomNam = cmbRoom.Text;
            string stadiumName = cmbStadium.Text;
            decimal price = numPrice.Value;
            DateTime dateF = dateFrom.Value;
            DateTime dateT = dateTo.Value;
           
            string[] myArr = new string[] { cusName, stadiumName};
            if(extentions.IsEmpty(myArr, string.Empty))
            {
                if(dateT > dateF)
                {
                    List<int> rmList = AddRoom();
                    if(rmList.Count > 0)
                    {
                        Room selRoom = db.Rooms.First(m => m.Name == roomNam);
                        if (!checkRoom.Items.Contains(selRoom))
                        {
                            checkRoom.Items.Add(selRoom, true);
                        }
                        for (int i = 0; i < rmList.Count; i++)
                        {
                            int stId = db.Stadions.First(s => s.Name == stadiumName).Id;
                            int cusId = db.Customers.First(c => c.Fullname == cusName).Id;
                            Rezerv newRezerv = new Rezerv()
                            {
                                RoomId = rmList[i],
                                StadiumId = stId,
                                CustomerId = cusId,
                             
                                DateFrom = dateF,
                                DateTo = dateT,
                                Price = price
                            };
                            db.Rezervs.Add(newRezerv);
                            db.SaveChanges();                          
                            FillDataRezerv();                          
                        }
                        
                    }
                   
                }
            }
        }

        private void checkRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = checkRoom.SelectedIndex;
            if (selected != -1)
            {
                checkRoom.Items.RemoveAt(selected);
            }
        }
        public List<int> AddRoom()
        {
            List<int> roomListId = new List<int>();
            for (int i = checkRoom.Items.Count - 1; i >= 0; i--)
            {
                string RoomName = checkRoom.Items[i].ToString();
                Room selectedRoom = db.Rooms.FirstOrDefault(ro => ro.Name == RoomName);
                int roomId;
                if (selectedRoom != null)
                {
                    roomId = selectedRoom.Id;
                    roomListId.Add(roomId);
                    db.Reservation_To_Rooms.Add(new Reservation_To_Rooms()
                    {
                        RoomId = roomId
                    });

                    db.Customer_To_Rooms.Add(new Customer_To_Rooms()
                    {
                        RoomId = roomId
                    });
                }
               
            }
            return roomListId;
        }

        private void cmbRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                string roomName = cmbRoom.Text;
                if(!checkRoom.Items.Contains(roomName))
                {
                    checkRoom.Items.Add(roomName);
                }
            }
        }
    }
}
