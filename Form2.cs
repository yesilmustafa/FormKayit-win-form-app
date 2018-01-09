using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormKayit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            pictureBox1.ImageLocation = path;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            listBox2.Items.Add(maskedTextBox1.Text);
            listBox3.Items.Add(comboBox1.Text);
        }

        private void PersonelSatirSec(object sender, EventArgs e)
        {
            //[index]
            ListBox secilen = (ListBox)sender;
            int secilenSiraNo = secilen.SelectedIndex;
            listBox1.SelectedIndex = secilenSiraNo;
            listBox2.SelectedIndex = secilenSiraNo;
            listBox3.SelectedIndex = secilenSiraNo;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = string.Empty;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int SatirNo = -1;
            string aranan = textBox2.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
                foreach (string isim in listBox1.Items)
                    if (isim.ToLower().Contains(aranan))
                        SatirNo = listBox1.Items.IndexOf(isim);

            listBox1.SelectedIndex = SatirNo;
        }
    }
}
