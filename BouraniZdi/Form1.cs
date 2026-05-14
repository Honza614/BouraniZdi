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

		// parametry kuličky
		int mintSouradniceX, mintSouradniceY;
		int mintPosunX, mintPosunY;
		const int mcnVelikost = 20;

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

			// nastavení kuličky
			mintSouradniceX = mintSouradniceY = 100;
			mintPosunX = mintPosunY = 3;

			// spustit timer
			tmrVykreslovani.Interval = 50;
			tmrVykreslovani.Start(); // tmrVykreslovani.Stop();
		}

		// ---------------------------------
		// vykreslit hru
		// ---------------------------------
		private void timer1_Tick(object sender, EventArgs e)
		{
			// smazat plátno
			mobjGrafika.Clear(Color.White);

			// vykreslit kuličku
			mobjGrafika.FillEllipse(Brushes.Blue, mintSouradniceX, mintSouradniceY, 20, 20);

			// pohnout kuličkou
			mintSouradniceX = mintSouradniceX + mintPosunX;
			mintSouradniceY = mintSouradniceY + mintPosunY;

			// test odrazu Y
			if (((mintSouradniceY + mcnVelikost) > pbPlatno.Height) || (mintSouradniceY < 0))
				mintPosunY = mintPosunY * (-1);

			// test odrazu X
			if (((mintSouradniceX + mcnVelikost) > pbPlatno.Width) || (mintSouradniceX < 0))
				mintPosunX = mintPosunX * (-1);
		}
	}
}
