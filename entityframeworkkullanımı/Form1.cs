using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace entityframeworkkullanımı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btngetir_Click(object sender, EventArgs e)
        {
            AdventureWorks2019Entities db = new AdventureWorks2019Entities();
            List<Product> urunlistesi = db.Products.Where(kayit=>kayit.Color=="kirmizi").ToList();  
            foreach (var item in urunlistesi)
            {
                listBox1.Items.Add(item.Name);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear(); 
            string renk=textBox1.Text;
            AdventureWorks2019Entities db = new AdventureWorks2019Entities();
            List<Product> urunlistesi = db.Products.Where(kayit => kayit.Color == textBox1.Text).ToList(); 
            foreach (var item in urunlistesi)
            {
                listBox2.Items.Add($"{item.Color} {item.Name}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            decimal min, max;
            min = Convert.ToDecimal(txtmin.Text);
            max = Convert.ToDecimal(txtmax.Text);

            AdventureWorks2019Entities db = new AdventureWorks2019Entities();
            List<Product> urunlistesi =db.Products.Where(p => p.ListPrice>=min &&p.ListPrice<=max).ToList();
            
            foreach (var item in urunlistesi)
            {
                listBox3.Items.Add(item.ListPrice+" "+item.Color);
            }
        }
    }
}
