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
    public partial class StaffForm : Form
    {
        public StaffForm()
        {
            InitializeComponent();
            ShowStaff();
        }

        void ShowStaff()
        {
            listViewStaff.Items.Clear();
            foreach (StaffSet staff in Program.computerShop.StaffSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    staff.id_staff.ToString(), staff.LastName, staff.FirstName, staff.MiddleName,
                    staff.Phone, staff.Purpose
                });
                item.Tag = staff;
                listViewStaff.Items.Add(item);

            }
            listViewStaff.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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

        private void textBoxPurpose_Enter(object sender, EventArgs e)
        {
            if (textBoxPurpose.Text == " Должность")
            {
                textBoxPurpose.Clear();
            }
        }

        private void listViewStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewStaff.SelectedItems.Count == 1)
            {
                StaffSet staff = listViewStaff.SelectedItems[0].Tag as StaffSet;
                textBoxLName.Text = staff.LastName;
                textBoxFName.Text = staff.FirstName;
                textBoxMName.Text = staff.MiddleName;
                textBoxPhone.Text = staff.Phone;
                textBoxPurpose.Text = staff.Purpose;
            }
            else
            {
                textBoxLName.Text = " Фамилия";
                textBoxFName.Text = " Имя";
                textBoxMName.Text = " Отчество";
                textBoxPhone.Text = " Телефон";
                textBoxPurpose.Text = " Должность";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            StaffSet staff = new StaffSet();
            staff.LastName = textBoxLName.Text;
            staff.FirstName = textBoxFName.Text;
            staff.MiddleName = textBoxMName.Text;
            staff.Phone = textBoxPhone.Text;
            staff.Purpose = textBoxPurpose.Text;
            Program.computerShop.StaffSet.Add(staff);
            Program.computerShop.SaveChanges();
            ShowStaff();          
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewStaff.SelectedItems.Count == 1)
            {
                StaffSet staff = listViewStaff.SelectedItems[0].Tag as StaffSet;
                staff.LastName = textBoxLName.Text;
                staff.FirstName = textBoxFName.Text;
                staff.MiddleName = textBoxMName.Text;
                staff.Phone = textBoxPhone.Text;
                staff.Purpose = textBoxPurpose.Text;
                Program.computerShop.SaveChanges();
                ShowStaff();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewStaff.SelectedItems.Count == 1)
                {
                    StaffSet staff = listViewStaff.SelectedItems[0].Tag as StaffSet;
                    Program.computerShop.StaffSet.Remove(staff);
                    Program.computerShop.SaveChanges();
                    ShowStaff();
                }
                textBoxLName.Text = " Фамилия";
                textBoxFName.Text = " Имя";
                textBoxMName.Text = " Отчество";
                textBoxPhone.Text = " Телефон";
                textBoxPurpose.Text = " Должность";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
