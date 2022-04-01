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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            ShowStaff();
            ShowCustomer();
            ShowProduct();
            ShowOrder();
        }

        void ShowOrder()
        {
            listViewOrder.Items.Clear();
            foreach (OrderSet order in Program.computerShop.OrderSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    order.id_order.ToString(),
                    order.StaffSet.id_staff.ToString() + ". " + order.StaffSet.LastName + " " + order.StaffSet.FirstName + " " + order.StaffSet.MiddleName,
                    order.CustomerSet.id_customer.ToString() + ". " + order.CustomerSet.LastName + " " + order.CustomerSet.FirstName + " " + order.CustomerSet.MiddleName,
                    order.ProductsSet.id_product.ToString() + ". " + order.ProductsSet.Pr_group + " " + order.ProductsSet.Title                    
                });
                item.Tag = order;
                listViewOrder.Items.Add(item);
            }
        }

        void ShowStaff()
        {
            comboBoxStaff.Items.Clear();
            foreach (StaffSet staff in Program.computerShop.StaffSet)
            {
                string[] item = {staff.id_staff.ToString() + ". ", staff.LastName, staff.FirstName,
                staff.MiddleName};
                comboBoxStaff.Items.Add(string.Join(" ", item));
            }
        }

        void ShowCustomer()
        {
            comboBoxCustomer.Items.Clear();
            foreach (CustomerSet customer in Program.computerShop.CustomerSet)
            {
                string[] item = {customer.id_customer.ToString() + ". ", customer.LastName, customer.FirstName,
                customer.MiddleName};
                comboBoxCustomer.Items.Add(string.Join(" ", item));
            }
        }

        void ShowProduct()
        {
            comboBoxProduct.Items.Clear();
            foreach (ProductsSet products in Program.computerShop.ProductsSet)
            {
                string[] item = {products.id_product.ToString() + ". ", products.Pr_group + " ", products.Title};
                comboBoxProduct.Items.Add(string.Join(" ", item));
            }
        }

        private void listViewProc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count == 1)
            {
                OrderSet order = listViewOrder.SelectedItems[0].Tag as OrderSet;
                comboBoxCustomer.SelectedIndex = comboBoxCustomer.FindString(order.id_customer.ToString());
                comboBoxProduct.SelectedIndex = comboBoxProduct.FindString(order.id_product.ToString());
                comboBoxStaff.SelectedIndex = comboBoxStaff.FindString(order.id_staff.ToString());

                //comboBoxStaff.Text = order.StaffSet.id_staff.ToString() + ". " + order.StaffSet.LastName + " " + order.StaffSet.FirstName + " " + order.StaffSet.MiddleName;
                //comboBoxCustomer.Text = order.CustomerSet.id_customer.ToString() + ". " + order.CustomerSet.LastName + " " + order.CustomerSet.FirstName + " " + order.CustomerSet.MiddleName;
                //comboBoxProduct.Text = order.ProductsSet.id_product.ToString() + ". " + order.ProductsSet.Pr_group + " " + order.ProductsSet.Title;
            }
            else
            {
                comboBoxStaff.Text = "Сотрудник";
                comboBoxCustomer.Text = "Покупатель";
                comboBoxProduct.Text = "Товар";

            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxStaff_Enter(object sender, EventArgs e)
        {
            if (comboBoxStaff.Text == "Сотрудник")
            {
                comboBoxStaff.Text = "";
            }
        }

        private void comboBoxCustomer_Enter(object sender, EventArgs e)
        {
            if (comboBoxCustomer.Text == "Покупатель")
            {
                comboBoxCustomer.Text = "";
            }
        }

        private void comboBoxProduct_Enter(object sender, EventArgs e)
        {
            if (comboBoxProduct.Text == "Товар")
            {
                comboBoxProduct.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxCustomer.SelectedItem != null && comboBoxStaff.SelectedItem != null && comboBoxProduct != null)
            {
                OrderSet order = new OrderSet();
                order.id_staff = Convert.ToInt32(comboBoxStaff.SelectedItem.ToString().Split('.')[0]);
                order.id_customer = Convert.ToInt32(comboBoxCustomer.SelectedItem.ToString().Split('.')[0]);
                order.id_product = Convert.ToInt32(comboBoxProduct.SelectedItem.ToString().Split('.')[0]);               
                Program.computerShop.OrderSet.Add(order);
                
                Program.computerShop.SaveChanges();
                ShowOrder();
            }
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count == 1)
            {
                OrderSet order = listViewOrder.SelectedItems[0].Tag as OrderSet;
                order.id_staff = Convert.ToInt32(comboBoxStaff.SelectedItem.ToString().Split('.')[0]);
                order.id_customer = Convert.ToInt32(comboBoxCustomer.SelectedItem.ToString().Split('.')[0]);
                order.id_product = Convert.ToInt32(comboBoxProduct.SelectedItem.ToString().Split('.')[0]);

                Program.computerShop.SaveChanges();
                ShowOrder();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewOrder.SelectedItems.Count == 1)
                {
                    OrderSet order = listViewOrder.SelectedItems[0].Tag as OrderSet;
                    Program.computerShop.OrderSet.Remove(order);
                    Program.computerShop.SaveChanges();
                    ShowOrder();
                }
                comboBoxCustomer.SelectedItem = null;
                comboBoxProduct.SelectedItem = null;
                comboBoxStaff.SelectedItem = null;
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись уже используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
