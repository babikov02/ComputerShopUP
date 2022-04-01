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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            ShowProduct();
        }

       void ShowProduct()
        {
            listViewNet.Items.Clear();
            listViewPer.Items.Clear();
            listViewProc.Items.Clear();

            foreach (ProductsSet products in Program.computerShop.ProductsSet)
            {
                if (products.Pr_group == "Периферийные устройства")
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        products.id_product.ToString(), products.Title, products.Price.ToString(),
                        products.Kol.ToString(), products.Mark.ToString(), products.Description
                    });

                    item.Tag = products;

                    listViewPer.Items.Add(item);
                }
                else if (products.Pr_group == "Ноутбуки")
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        products.id_product.ToString(), products.Title, products.Price.ToString(),
                        products.Kol.ToString(), products.Mark.ToString(), products.Description
                    });

                    item.Tag = products;

                    listViewNet.Items.Add(item);
                }
                else if (products.Pr_group == "Процессоры")
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        products.id_product.ToString(), products.Title, products.Price.ToString(),
                        products.Kol.ToString(), products.Mark.ToString(), products.Description
                    });

                    item.Tag = products;

                    listViewProc.Items.Add(item);
                }
            }
            listViewProc.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewPer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewNet.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void comboBoxPr_group_Enter(object sender, EventArgs e)
        {
            if (comboBoxPr_group.Text == "Товарная группа")
            {
                comboBoxPr_group.Text = "";
            }
        }

        private void textBoxTitle_Enter(object sender, EventArgs e)
        {
            if (textBoxTitle.Text == " Наименование")
            {
                textBoxTitle.Clear();
            }
        }

        private void textBoxPrice_Enter(object sender, EventArgs e)
        {
            if (textBoxPrice.Text == " Цена")
            {
                textBoxPrice.Clear();
            }
        }

        private void textBoxKol_Enter(object sender, EventArgs e)
        {
            if (textBoxKol.Text == " Количество")
            {
                textBoxKol.Clear();
            }
        }

        private void textBoxMark_Enter(object sender, EventArgs e)
        {
            if (textBoxMark.Text == " Рейтинг")
            {
                textBoxMark.Clear();
            }
        }

        private void textBoxDescription_Enter(object sender, EventArgs e)
        {
            if (textBoxDescription.Text == " Описание")
            {
               textBoxDescription.Clear();
            }
        }

        private void comboBoxPr_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPr_group.SelectedIndex == 0)
            {
                listViewNet.Visible = false;
                listViewProc.Visible = false;
                listViewPer.Visible = true;

                textBoxTitle.Text = " Наименование";
                textBoxPrice.Text = " Цена";
                textBoxKol.Text = " Количество";
                textBoxMark.Text = " Рейтинг";
                textBoxDescription.Text = " Описание";
            }

            else if (comboBoxPr_group.SelectedIndex == 1)
            {
                listViewNet.Visible = true;
                listViewProc.Visible = false;
                listViewPer.Visible = false;

                textBoxTitle.Text = " Наименование";
                textBoxPrice.Text = " Цена";
                textBoxKol.Text = " Количество";
                textBoxMark.Text = " Рейтинг";
                textBoxDescription.Text = " Описание";
            }

            else if (comboBoxPr_group.SelectedIndex == 2)
            {
                listViewNet.Visible = false;
                listViewProc.Visible = true;
                listViewPer.Visible = false;

                textBoxTitle.Text = " Наименование";
                textBoxPrice.Text = " Цена";
                textBoxKol.Text = " Количество";
                textBoxMark.Text = " Рейтинг";
                textBoxDescription.Text = " Описание";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ProductsSet products = new ProductsSet();
            products.Title = textBoxTitle.Text;
            products.Price = Convert.ToDouble(textBoxPrice.Text);
            products.Kol = Convert.ToInt32(textBoxKol.Text);
            products.Mark = Convert.ToDouble(textBoxMark.Text);
            products.Description = textBoxDescription.Text;

            if (comboBoxPr_group.SelectedIndex == 0)
            {
                products.Pr_group = "Периферийные устройства";
            }
            else if (comboBoxPr_group.SelectedIndex == 1)
            {
                products.Pr_group = "Ноутбуки";
            }
            else if (comboBoxPr_group.SelectedIndex == 2)
            {
                products.Pr_group = "Процессоры";
            }

            Program.computerShop.ProductsSet.Add(products);
            Program.computerShop.SaveChanges();
            ShowProduct();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxPr_group.SelectedIndex == 0)
            {
                if (listViewPer.SelectedItems.Count == 1)
                {
                    ProductsSet products = listViewPer.SelectedItems[0].Tag as ProductsSet;
                    products.Title = textBoxTitle.Text;
                    products.Price = Convert.ToDouble(textBoxPrice.Text);
                    products.Kol = Convert.ToInt32(textBoxKol.Text);
                    products.Mark = Convert.ToDouble(textBoxMark.Text);
                    products.Description = textBoxDescription.Text;
                    products.Pr_group = "Периферийные устройства";

                    Program.computerShop.SaveChanges();
                    ShowProduct();
                }
            }
            else if (comboBoxPr_group.SelectedIndex == 1)
            {
                if (listViewNet.SelectedItems.Count == 1)
                {
                    ProductsSet products = listViewNet.SelectedItems[0].Tag as ProductsSet;
                    products.Title = textBoxTitle.Text;
                    products.Price = Convert.ToDouble(textBoxPrice.Text);
                    products.Kol = Convert.ToInt32(textBoxKol.Text);
                    products.Mark = Convert.ToDouble(textBoxMark.Text);
                    products.Description = textBoxDescription.Text;
                    products.Pr_group = "Ноутбуки";

                    Program.computerShop.SaveChanges();
                    ShowProduct();
                }
            }
            else if (comboBoxPr_group.SelectedIndex == 2)
            {
                if (listViewProc.SelectedItems.Count == 1)
                {
                    ProductsSet products = listViewProc.SelectedItems[0].Tag as ProductsSet;
                    products.Title = textBoxTitle.Text;
                    products.Price = Convert.ToDouble(textBoxPrice.Text);
                    products.Kol = Convert.ToInt32(textBoxKol.Text);
                    products.Mark = Convert.ToDouble(textBoxMark.Text);
                    products.Description = textBoxDescription.Text;
                    products.Pr_group = "Процессоры";

                    Program.computerShop.SaveChanges();
                    ShowProduct();
                }
            }
        }

        private void listViewProc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewProc.SelectedItems.Count == 1)
            {
                ProductsSet products = listViewProc.SelectedItems[0].Tag as ProductsSet;
                comboBoxPr_group.Text = "Процессоры";
                textBoxTitle.Text = products.Title;
                textBoxPrice.Text = products.Price.ToString();
                textBoxKol.Text = products.Kol.ToString();
                textBoxMark.Text = products.Mark.ToString();
                textBoxDescription.Text = products.Description;

            }
            else
            {
                comboBoxPr_group.Text = "Товарная группа";
                textBoxTitle.Text = " Наименование";
                textBoxPrice.Text = " Цена";
                textBoxKol.Text = " Количество";
                textBoxMark.Text = " Рейтинг";
                textBoxDescription.Text = " Описание";                
            }
        }

        private void listViewPer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPer.SelectedItems.Count == 1)
            {
                ProductsSet products = listViewPer.SelectedItems[0].Tag as ProductsSet;
                comboBoxPr_group.Text = "Периферийные устройства";
                textBoxTitle.Text = products.Title;
                textBoxPrice.Text = products.Price.ToString();
                textBoxKol.Text = products.Kol.ToString();
                textBoxMark.Text = products.Mark.ToString();
                textBoxDescription.Text = products.Description;

            }
            else
            {
                comboBoxPr_group.Text = "Товарная группа";
                textBoxTitle.Text = " Наименование";
                textBoxPrice.Text = " Цена";
                textBoxKol.Text = " Количество";
                textBoxMark.Text = " Рейтинг";
                textBoxDescription.Text = " Описание";
            }
        }

        private void listViewNet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewNet.SelectedItems.Count == 1)
            {
                ProductsSet products = listViewNet.SelectedItems[0].Tag as ProductsSet;
                comboBoxPr_group.Text = "Ноутбуки";
                textBoxTitle.Text = products.Title;
                textBoxPrice.Text = products.Price.ToString();
                textBoxKol.Text = products.Kol.ToString();
                textBoxMark.Text = products.Mark.ToString();
                textBoxDescription.Text = products.Description;

            }
            else
            {
                comboBoxPr_group.Text = "Товарная группа";
                textBoxTitle.Text = " Наименование";
                textBoxPrice.Text = " Цена";
                textBoxKol.Text = " Количество";
                textBoxMark.Text = " Рейтинг";
                textBoxDescription.Text = " Описание";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPr_group.SelectedIndex == 0)
                {
                    if (listViewPer.SelectedItems.Count == 1)
                    {
                        ProductsSet products = listViewPer.SelectedItems[0].Tag as ProductsSet;
                        Program.computerShop.ProductsSet.Remove(products);
                        Program.computerShop.SaveChanges();
                        ShowProduct();
                    }

                    comboBoxPr_group.Text = "Товарная группа";
                    textBoxTitle.Text = " Наименование";
                    textBoxPrice.Text = " Цена";
                    textBoxKol.Text = " Количество";
                    textBoxMark.Text = " Рейтинг";
                    textBoxDescription.Text = " Описание";
                }
                else if (comboBoxPr_group.SelectedIndex == 1)
                {
                    if (listViewNet.SelectedItems.Count == 1)
                    {
                        ProductsSet products = listViewNet.SelectedItems[0].Tag as ProductsSet;
                        Program.computerShop.ProductsSet.Remove(products);
                        Program.computerShop.SaveChanges();
                        ShowProduct();
                    }

                    comboBoxPr_group.Text = "Товарная группа";
                    textBoxTitle.Text = " Наименование";
                    textBoxPrice.Text = " Цена";
                    textBoxKol.Text = " Количество";
                    textBoxMark.Text = " Рейтинг";
                    textBoxDescription.Text = " Описание";
                }
                else if (comboBoxPr_group.SelectedIndex == 2)
                {
                    if (listViewProc.SelectedItems.Count == 1)
                    {
                        ProductsSet products = listViewProc.SelectedItems[0].Tag as ProductsSet;
                        Program.computerShop.ProductsSet.Remove(products);
                        Program.computerShop.SaveChanges();
                        ShowProduct();
                    }

                    comboBoxPr_group.Text = "Товарная группа";
                    textBoxTitle.Text = " Наименование";
                    textBoxPrice.Text = " Цена";
                    textBoxKol.Text = " Количество";
                    textBoxMark.Text = " Рейтинг";
                    textBoxDescription.Text = " Описание";
                }
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
