using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YapaySinir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double[] agirlik = new double[11] { -2.110000, 0.690000, 1.830000, 1.120000, 1.490000, 1.970000, -2.890000, -1.360000, -0.240000, -2.400000, -2.120000 };
        public double[,] ornek_veri;
        public double[,] test_veri;

        public double momentum2;
        string islem = "";
        public int sayac_Test = 0, sayac_Ornek = 0;
        private void button33_Click(object sender, EventArgs e)
        {
            sayac_Test = 0; sayac_Ornek = 0;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            momentum2 = Convert.ToDouble(textBox2.Text);
            if (checkBox1.Checked) { sayac_Test++; } 
            else {; sayac_Ornek++; }
            if (checkBox2.Checked) { sayac_Test++; } 
            else {; sayac_Ornek++; }
            if (checkBox3.Checked) { sayac_Test++; } 
            else {; sayac_Ornek++; }
            if (checkBox4.Checked) { sayac_Test++; } 
            else {; sayac_Ornek++; }
            if (checkBox5.Checked) { sayac_Test++; } 
            else {; sayac_Ornek++; }
            if (checkBox6.Checked) { sayac_Test++; } 
            else {; sayac_Ornek++; }
            if (checkBox7.Checked) { sayac_Test++; } 
            else {; sayac_Ornek++; }
            if (checkBox8.Checked) { sayac_Test++; } 
            else {; sayac_Ornek++; }
            test_veri = new double[sayac_Test, 4];
            ornek_veri = new double[sayac_Ornek, 4];
            sayac_Ornek = 0; sayac_Test = 0;
            int momentum = Convert.ToInt32(textBox2.Text);
            if (checkBox1.Checked) { giris(sayac_Test, 2, new double[4] { 0, 0, 0, 0 }); sayac_Test++; } 
            else { giris(sayac_Ornek, 1, new double[4] { 0, 0, 0, 0 }); sayac_Ornek++; }
            if (checkBox2.Checked) { giris(sayac_Test, 2, new double[4] { 0, 0, 1, 1 }); sayac_Test++; } 
            else { giris(sayac_Ornek, 1, new double[4] { 0, 0, 1, 1 }); sayac_Ornek++; }
            if (checkBox3.Checked) { giris(sayac_Test, 2, new double[4] { 0, 1, 0, 0 }); sayac_Test++; } 
            else { giris(sayac_Ornek, 1, new double[4] { 0, 1, 0, 0 }); sayac_Ornek++; }
            if (checkBox4.Checked) { giris(sayac_Test, 2, new double[4] { 0, 1, 1, 0 }); sayac_Test++; } 
            else { giris(sayac_Ornek, 1, new double[4] { 0, 1, 1, 0 }); sayac_Ornek++; }
            if (checkBox5.Checked) { giris(sayac_Test, 2, new double[4] { 1, 0, 0, 0 }); sayac_Test++; } 
            else { giris(sayac_Ornek, 1, new double[4] { 1, 0, 0, 0 }); sayac_Ornek++; }
            if (checkBox6.Checked) { giris(sayac_Test, 2, new double[4] { 1, 0, 1, 0 }); sayac_Test++; } 
            else { giris(sayac_Ornek, 1, new double[4] { 1, 0, 1, 0 }); sayac_Ornek++; }
            if (checkBox7.Checked) { giris(sayac_Test, 2, new double[4] { 1, 1, 0, 1 }); sayac_Test++; } 
            else { giris(sayac_Ornek, 1, new double[4] { 1, 1, 0, 1 }); sayac_Ornek++; }
            if (checkBox8.Checked) { giris(sayac_Test, 2, new double[4] { 1, 1, 1, 1 }); sayac_Test++; } 
            else { giris(sayac_Ornek, 1, new double[4] { 1, 1, 1, 1 }); sayac_Ornek++; }
            int epoc = Convert.ToInt32(textBox1.Text);
            for (int t = 1; t <= epoc; t++)
            {
                listBox1.Items.Add("");
                listBox1.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------------  " + t.ToString() + ". EPOC  ----------------------------------------------------------------------------------------------------------------------------------------------");
                listBox1.Items.Add("                       X1     X2      X3        W11          W12         W21          W22            W31           W32         W13            W23         WB1            WB2            WB3            ÇIKIŞ HATASI           Y\n\n");
               
                for (int i = 0; i < sayac_Ornek; i++)
                {
                    islem = (i + 1) + ". İterasyon ---  " + ornek_veri[i, 0].ToString() + "       " + ornek_veri[i, 1].ToString() + "        " + ornek_veri[i, 2].ToString() + "    \n\n";
                    for (int j = 0; j < 11; j++)
                        islem += agirlik[j].ToString("N6") + "   ";
                    ileriyayilim_Ornek(i);
                }
            listBox1.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------  " + t.ToString() + ". EPOC SONU  -----------------------------------------------------------------------------------------------------------------------------------------\n\n\n");
            }
            for (int i = 0; i < sayac_Test; i++)
            {
                islem = (i + 1) + ". İterasyon -    " + test_veri[i, 0].ToString() + "       " + test_veri[i, 1].ToString() + "        " + test_veri[i, 2].ToString() + "    ";
                listBox2.Items.Add("                       X1     X2      X3        W11          W12         W21          W22            W31           W32         W13            W23         WB1            WB2            WB3                  DEĞER               Y");
                for (int j = 0; j < 11; j++)
                    islem += agirlik[j].ToString("N6") + "   ";
                ileriyayilim_Test(i);
            }
        }
        public void ileriyayilim_Ornek(int i)
        {
            double func1 = ornek_veri[i, 0] * agirlik[0] + ornek_veri[i, 1] * agirlik[2] + ornek_veri[i, 2] * agirlik[4] + 1 * agirlik[8];
            func1 = 1 / (1 + Math.Exp(-1 * func1));
            double func2 = ornek_veri[i, 0] * agirlik[1] + ornek_veri[i, 1] * agirlik[3] + ornek_veri[i, 2] * agirlik[5] + 1 * agirlik[9];
            func2 = 1 / (1 + Math.Exp(-1 * func2));
            double func3 = func1 * agirlik[6] + func2 * agirlik[7] + 1 * agirlik[10];
            func3 = 1 / (1 + Math.Exp(-1 * func3));
            double Hata_Orani = 0.5 * (ornek_veri[i, 3] - func3) * (ornek_veri[i, 3] - func3);
            if (Hata_Orani == 0)
                MessageBox.Show("Sonuç 0");
            islem += "          " + Hata_Orani.ToString("N6");
            islem += "              " + ornek_veri[i, 3];
            listBox1.Items.Add(islem);
            //Geri Yayilim Yonlendirmesi
            double noron = func3 * (1 - func3) * (0 - func3);

            agirlik[10] = agirlik[10] + momentum2 * noron * 1;
            agirlik[6] = agirlik[6] + momentum2 * noron * func1;
            agirlik[7] = agirlik[7] + momentum2 * noron * func2;

            double noron_Y1 = func1 * (1 - func1) * agirlik[6] * noron;
            agirlik[8] = agirlik[8] + momentum2 * noron_Y1 * 1;
            agirlik[0] = agirlik[0] + momentum2 * noron_Y1 * 1;
            agirlik[2] = agirlik[2] + momentum2 * noron_Y1 * 1;
            agirlik[4] = agirlik[4] + momentum2 * noron_Y1 * 1;
            double noron_Y2 = func2 * (1 - func2) * agirlik[7] * noron;
            agirlik[9] = agirlik[9] + momentum2 * noron_Y1 * 1;
            agirlik[1] = agirlik[1] + momentum2 * noron_Y1 * 1;
            agirlik[3] = agirlik[3] + momentum2 * noron_Y1 * 1;
            agirlik[5] = agirlik[5] + momentum2 * noron_Y1 * 1;

        }
        public void ileriyayilim_Test(int i)
        {
            double func1 = test_veri[i, 0] * agirlik[0] + test_veri[i, 1] * agirlik[2] + test_veri[i, 2] * agirlik[4] + 1 * agirlik[8];
            func1 = 1 / (1 + Math.Exp(-1 * func1));
            double func2 = test_veri[i, 0] * agirlik[1] + test_veri[i, 1] * agirlik[3] + test_veri[i, 2] * agirlik[5] + 1 * agirlik[9];
            func2 = 1 / (1 + Math.Exp(-1 * func2));
            double func3 = func1 * agirlik[6] + func2 * agirlik[7] + 1 * agirlik[10];
            func3 = 1 / (1 + Math.Exp(-1 * func3));
            islem += "          " + func3.ToString("N6");
            islem += "              " + test_veri[i, 3];
            listBox2.Items.Add(islem);
        }


        public void giris(int satir, int diziid, double[] veri)
        {
            if (diziid == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    ornek_veri[satir, i] = veri[i];
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    test_veri[satir, i] = veri[i];
                }
            }
        }


    }
}
