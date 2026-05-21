using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BouraniZdi
{
	internal class clsKulicka
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
		public clsKulicka(Graphics objGrafika, int intX, int intY)
		{
			// zaznamenat hodnoty do proměnných
			mobjGrafika = objGrafika;
			mintSouradniceX = intX;
			mintSouradniceY = intY;
			mintPosunX = mintPosunY = 3;
		}

		// ---------------------------------
		// posun a vykreslení
		// ---------------------------------
		public void PosunVykresli()
		{
			// vykreslit kuličku
			mobjGrafika.FillEllipse(Brushes.Blue, mintSouradniceX, mintSouradniceY, mcnVelikost, mcnVelikost);

			// pohnout kuličkou
			mintSouradniceX = mintSouradniceX + mintPosunX;
			mintSouradniceY = mintSouradniceY + mintPosunY;

			// test odrazu Y
			if (((mintSouradniceY + mcnVelikost) > mobjGrafika.VisibleClipBounds.Height) || (mintSouradniceY < 0))
				mintPosunY = mintPosunY * (-1);

			// test odrazu X
			if (((mintSouradniceX + mcnVelikost) > mobjGrafika.VisibleClipBounds.Width) || (mintSouradniceX < 0))
				mintPosunX = mintPosunX * (-1);
		}
	}
}
