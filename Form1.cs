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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool GuncellemeMi = false;
        int SeciliSatirNo = 0;

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (GuncellemeMi)
                PersonelGuncelle();
            else
                PersonelEkle();

            dataGridView1.Rows[0].Height = 50;
        }

        private void PersonelGuncelle()
        {
            dataGridView1.Rows[SeciliSatirNo].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[SeciliSatirNo].Cells[1].Value = maskedTextBox1.Text;
            dataGridView1.Rows[SeciliSatirNo].Cells[2].Value = comboBox1.Text;
            if (pictureBox1.ImageLocation != null)
            {
                Image resim = Image.FromFile(pictureBox1.ImageLocation);
                dataGridView1.Rows[SeciliSatirNo].Cells[3].Value = resim;
            }

            GuncellemeMi = false;
            FormuAc();
            MessageBox.Show("Kaydedildi");
        }

        void GenislikAyarla()
        {
            int en = dataGridView1.Width / 4;

            dataGridView1.Columns[0].Width = en;
            dataGridView1.Columns[1].Width = en;
            dataGridView1.Columns[2].Width = en;
            dataGridView1.Columns[3].Width = en;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormuHazirla();
            GenislikAyarla();
        }
        void FormuHazirla()
        {
            dataGridView1.Columns.Add("AdSoyad", "Ad Soyad");
            dataGridView1.Columns.Add("Telefon", "Tel");
            dataGridView1.Columns.Add("Departman", "Departman");
            DataGridViewImageColumn imgSutun = new DataGridViewImageColumn();
            dataGridView1.Columns.Add(imgSutun);

        }
        private void btnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string dosyaYolu = ofd.FileName; // c:/users/wissen/desktop/1.jpg
            pictureBox1.ImageLocation = dosyaYolu;
        }
        void PersonelEkle()
        {
            var No = dataGridView1.Rows.Add();
            dataGridView1.Rows[No].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[No].Cells[1].Value = maskedTextBox1.Text;
            dataGridView1.Rows[No].Cells[2].Value = comboBox1.Text;

            if (pictureBox1.ImageLocation != null)
            {
                Image resim = Image.FromFile(pictureBox1.ImageLocation);
                dataGridView1.Rows[No].Cells[3].Value = resim;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            GenislikAyarla();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(item);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var secilen = dataGridView1.SelectedRows[0];
            textBox1.Text = secilen.Cells[0].Value.ToString();
            maskedTextBox1.Text = secilen.Cells[1].Value.ToString();
            comboBox1.Text = (string)secilen.Cells[2].Value;

            FormuKitle();

            GuncellemeMi = true;
            SeciliSatirNo = dataGridView1.SelectedRows[0].Index;

        }

        private void FormuKitle()
        {
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            dataGridView1.Enabled = false;
        }

        private void FormuAc()
        {
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            dataGridView1.Enabled = true;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = string.Empty;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string aranan = textBox2.Text;
            foreach (DataGridViewRow satir in dataGridView1.Rows)
            {
                foreach (DataGridViewCell hucre in satir.Cells)
                {
                    if (hucre.Value != null && hucre.ColumnIndex != 3 && hucre.Value.ToString().Contains(aranan))
                    {
                        hucre.Style.BackColor = Color.Yellow;
                    }
                    else
                        hucre.Style.BackColor = Color.White;
                }
            }
        }
    }
}
