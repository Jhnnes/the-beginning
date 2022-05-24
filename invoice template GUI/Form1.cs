using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        double totalPrice = 0;
        double totalTaxes = 0;

        List<object[]> table = new List<object[]>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int amount = int.Parse(comboBoxAmount.SelectedItem.ToString());
            double price = double.Parse(textBoxPrice.Text);
            string name = textBoxName.Text;
            

            table.Add(new object[] { name, amount, price });

            coverLetter();

            richTextBox1.Text += "\nProdukt\t\tMenge\t\tUst. 19%\t\tPreis\t\tGesamt\n";


            for (int i = 0; i < table.Count; i++)
            {
                printRow(i);
            }

            printShippingCosts();

            richTextBox1.Text += "Gesamtsumme \t\t\t Ust.: " + Math.Round(totalTaxes, 2) + "€\t\t\t" + Math.Round(totalPrice, 2) + "€\n";






        }

        void printShippingCosts()
        {
            if (totalPrice > 25)
            {
                richTextBox1.Text += "\nVersandkosten \t\t\t\t\t\t\t" + 0 + "€\n\n";
            }
            else if (totalPrice > 15)
            {
                richTextBox1.Text += "\nVersandkosten \t\t\t\t\t" + Math.Round(2.95 * 0.19, 2) + "€\t\t" + 2.95 + "€\n\n";
                totalTaxes = totalTaxes + 2.95 * 0.19;
                totalPrice = totalPrice + 2.95;
            }
            else
            {
                richTextBox1.Text += "\nVersandkosten \t\t\t\t\t" + Math.Round(5.95 * 0.19, 2) + "€\t\t" + 5.95 + "€\n\n";
                totalTaxes = totalTaxes + 5.95 * 0.19;
                totalPrice = totalPrice + 5.95;
            }
        }

        void printRow(int rowNumber)
        {
            showPrice((string)table[rowNumber][0], (int)table[rowNumber][1], (double)table[rowNumber][2]);
        }


        void showPrice(string productName, int amount, double price)
        {
            double total = amount * price;
            totalPrice = totalPrice + total;


            double taxes = total * 0.19;
            totalTaxes = totalTaxes + taxes;


            richTextBox1.Text += productName + "\t\t" + amount + "\t\t" + Math.Round(taxes, 2) + "€\t\t" + Math.Round(price, 2) + "€\t\t" + total + "€" + @"  
 ";
        }

        void coverLetter()
        {
            string addname = textBox1.Text;
            string date1 = dateTimePicker1.Text;

            string name = addname;
            string date = date1;
            richTextBox1.Text = "Sehr geehrte/r " + name + @",

Hiermit übersende ich Ihnen die Rechnung für meine Leistungen am " + date + @". 
Vielen Dank, dass Sie unsere Dienste genutzt haben.

Mit freundlichen Grüßen
Johannes Hald
";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}