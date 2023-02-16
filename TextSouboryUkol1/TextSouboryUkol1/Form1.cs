using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextSouboryUkol1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog soubor = new OpenFileDialog();
            soubor.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            if (soubor.ShowDialog()==DialogResult.OK)
            {
                StreamReader cteni = new StreamReader(soubor.FileName);
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                int soucet = 0, pocetlich = 0, pocetsud = 0;
                while(!cteni.EndOfStream)
                {
                    string vstup=cteni.ReadLine();
                    listBox1.Items.Add(vstup);
                    if (vstup != "")
                    {
                        int pomocna = Convert.ToInt32(vstup);
                        if (pomocna % 2 == 0) pocetsud++;
                        else pocetlich++;
                        soucet += pomocna;
                    }
                    
                }
                cteni.Close();
                StreamWriter zapis = new StreamWriter(soubor.FileName, true);
                zapis.WriteLine("\n"+soucet);
                zapis.WriteLine(pocetlich);
                zapis.WriteLine(pocetsud);
                zapis.Close();
                cteni=new StreamReader(soubor.FileName);
                while (!cteni.EndOfStream)
                {
                    listBox2.Items.Add(cteni.ReadLine());
                }
                cteni.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Na disku je textový soubor cislo.txt (TextSouboryUkol1\\TextSouboryUkol1), v každém řádku je řetězec cifer představující celé číslo. Sečtěte čísla v jednotlivých řádcích, spočtěte počet sudých čísel a počet lichých čísel. Tyto tři výsledky zapište na konec souboru, každé číslo na samostatný řádek (žádné doplňující texty). Původní i opravený textový soubor zobrazte v komponentách ListBox.","INFO",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
