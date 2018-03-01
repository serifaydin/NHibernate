using Panel.Models;
using Panel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Panel.WindowsForms
{
    public partial class Form1 : Form
    {
        private readonly UserService userService = new UserService();
        public Form1()
        {
            InitializeComponent();
            ListFunction();
        }

        private void ListFunction()
        {
            List<User> UserList = userService.UserList().ToList();
            dataGridView1.DataSource = UserList;
        }

        private void btnEkle_Click(object sender, System.EventArgs e)
        {
            User _user = new User
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Age = int.Parse(txtAge.Text),
                RegisterDate = DateTime.Now
            };

            userService.UserAdded(_user);

            ListFunction();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
