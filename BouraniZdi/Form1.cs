using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouraniZdi
{
	public partial class Form1 : Form
	{
		// kreslící knihovna
		Graphics mobjGrafika;

		// kulička
		clsKulicka mobjKulicka;

		// ---------------------------------
		// konstruktor
		// ---------------------------------
		public Form1()
		{
			InitializeComponent();
		}

		// ---------------------------------
		// načíst formulář
		// ---------------------------------
		private void Form1_Load(object sender, EventArgs e)
		{
			// připojit grafiku k pictureboxu
			mobjGrafika = pbPlatno.CreateGraphics();

			// vytvořit kuličku
			mobjKulicka = new clsKulicka(mobjGrafika, 150, 40);

			// spustit timer
			tmrVykreslovani.Interval = 50;
			tmrVykreslovani.Start();
		}

		// ---------------------------------
		// vykreslit hru
		// ---------------------------------
		private void timer1_Tick(object sender, EventArgs e)
		{
			// smazat plátno
			mobjGrafika.Clear(Color.White);

			// vykreslit kuličku
			mobjKulicka.PosunVykresli();
		}
	}
}
