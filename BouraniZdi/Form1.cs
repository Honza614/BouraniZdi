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

		// balonky
		clsBalonek [] mobjBalonek;
		const int cnPocetBalonku = 26;

		// vozíček
		clsVozicek mobjVozicek;

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
			int lintX, lintY;

			// připojit grafiku k pictureboxu
			mobjGrafika = pbPlatno.CreateGraphics();

			// vytvořit kuličku
			mobjKulicka = new clsKulicka(mobjGrafika, 150, 40);

			// vytvořit pole
			mobjBalonek = new clsBalonek[cnPocetBalonku];

			// vytvořit balonek
			lintX = lintY = 10;
			for (int i = 0; i < cnPocetBalonku; i++)
			{
				// vytvořit
				mobjBalonek[i] = new clsBalonek(mobjGrafika, lintX, lintY);

				// posun x
				lintX = lintX + 60;

				// posun y
				if (lintX > pbPlatno.Width)
				{
					lintX = 10;
					lintY = lintY + 60;
				}
			}

			// vytvořit vozíček
			mobjVozicek = new clsVozicek(mobjGrafika, pbPlatno.Width/2 - 60, pbPlatno.Height-20);

			// spustit timer
			tmrVykreslovani.Interval = 10;
			tmrVykreslovani.Start();
		}

		// ---------------------------------
		// vykreslit hru
		// ---------------------------------
		private void timer1_Tick(object sender, EventArgs e)
		{
			// smazat plátno
			//mobjGrafika.Clear(Color.White);

			// vykreslit kuličku
			mobjKulicka.PosunVykresli();

			// vykreslit balonek
			for (int i = 0; i < cnPocetBalonku; i++)
			{
				// test kolize
				mobjBalonek[i].TestKolize(mobjKulicka.intX, mobjKulicka.intY, 20);

				// vykreslit
				mobjBalonek[i].Vykresli();
			}

			// vykreslit vozíček
			mobjVozicek.NakresliSe();

			// odraz od vozíčku
			mobjKulicka.OdrazOdPlosiny(mobjVozicek.mintSouradniceX, mobjVozicek.mintSouradniceY, 150);
		}

		// ---------------------------------
		// stisk klávesy
		// ---------------------------------
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			// posun doleva
			if (e.KeyCode == Keys.A)
				mobjVozicek.PosunSe(-10);

			// posun doprava
			if (e.KeyCode == Keys.D)
				mobjVozicek.PosunSe(10);
		}
	}
}
