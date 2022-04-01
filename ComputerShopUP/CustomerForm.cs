using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerShopUP
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            ShowCustomer();
        }
        
        void ShowCustomer()
        {
            listViewCustomer.Items.Clear();
            foreach (CustomerSet customer in Program.computerShop.CustomerSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    customer.id_customer.ToString(), customer.LastName, customer.FirstName, customer.MiddleName,
                    customer.Phone, customer.Email
                });
                item.Tag = customer;
                listViewCustomer.Items.Add(item);

            }
            listViewCustomer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void textBoxLName_Enter(object sender, EventArgs e)
        {
            if (textBoxLName.Text == " Фамилия")
            {
                textBoxLName.Clear();
            }
        }

        private void textBoxFName_Enter(object sender, EventArgs e)
        {
            if (textBoxFName.Text == " Имя")
            {
                textBoxFName.Clear();
            }
        }

        private void textBoxMName_Enter(object sender, EventArgs e)
        {
            if (textBoxMName.Text == " Отчество")
            {
                textBoxMName.Clear();
            }
        }

        private void textBoxPhone_Enter(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == " Телефон")
            {
                textBoxPhone.Clear();
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == " Email")
            {
                textBoxEmail.Clear();
            }
        }

        private void listViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCustomer.SelectedItems.Count == 1)
            {
                CustomerSet customer = listViewCustomer.SelectedItems[0].Tag as CustomerSet;
                textBoxLName.Text = customer.LastName;
                textBoxFName.Text = customer.FirstName;
                textBoxMName.Text = customer.MiddleName;
                textBoxPhone.Text = customer.Phone;
                textBoxEmail.Text = customer.Email;
            }
            else
            {
                textBoxLName.Text = " Фамилия";
                textBoxFName.Text = " Имя";
                textBoxMName.Text = " Отчество";
                textBoxPhone.Text = " Телефон";
                textBoxEmail.Text = " Email";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CustomerSet customer = new CustomerSet();
            customer.LastName = textBoxLName.Text;
            customer.FirstName = textBoxFName.Text;
            customer.MiddleName = textBoxMName.Text;
            customer.Phone = textBoxPhone.Text;
            customer.Email = textBoxEmail.Text;
            Program.computerShop.CustomerSet.Add(customer);
            Program.computerShop.SaveChanges();
            ShowCustomer();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewCustomer.SelectedItems.Count == 1)
            {
                CustomerSet customer = listViewCustomer.SelectedItems[0].Tag as CustomerSet;
                customer.LastName = textBoxLName.Text;
                customer.FirstName = textBoxFName.Text;
                customer.MiddleName = textBoxMName.Text;
                customer.Phone = textBoxPhone.Text;
                customer.Email = textBoxEmail.Text;
                Program.computerShop.SaveChanges();
                ShowCustomer();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewCustomer.SelectedItems.Count == 1)
                {
                    CustomerSet customer = listViewCustomer.SelectedItems[0].Tag as CustomerSet;
                    Program.computerShop.CustomerSet.Remove(customer);
                    Program.computerShop.SaveChanges();
                    ShowCustomer();
                }
                textBoxLName.Text = " Фамилия";
                textBoxFName.Text = " Имя";
                textBoxMName.Text = " Отчество";
                textBoxPhone.Text = " Телефон";
                textBoxEmail.Text = " Email";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
