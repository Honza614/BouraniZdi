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
		const int cnPocetBalonku = 22;

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
				mobjBalonek[i].Vykresli();
		}
	}
}
