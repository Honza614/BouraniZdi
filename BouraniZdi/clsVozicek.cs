using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouraniZdi
{
	internal class clsVozicek
	{
		// kreslící knihovna
		Graphics mobjGrafika;

		// parametry vozíčku
		int mintSouradniceX, mintSouradniceY;
		const int mcnSirka = 120, mcnVyska = 5;

		// --------------------------------
		// konstruktor
		// --------------------------------
		public clsVozicek(Graphics objGrafika, int intX, int intY)
		{
			// zaznamenat hodnoty do proměnných
			mobjGrafika = objGrafika;
			mintSouradniceX = intX;
			mintSouradniceY = intY;
		}

		// --------------------------------
		// vykreslení
		// --------------------------------
		public void NakresliSe()
		{
			mobjGrafika.FillRectangle(Brushes.Black, mintSouradniceX, mintSouradniceY, mcnSirka, mcnVyska);
		}
	}
}
