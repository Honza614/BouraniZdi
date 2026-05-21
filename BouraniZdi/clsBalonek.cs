using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouraniZdi
{
	internal class clsBalonek
	{
		// kreslící knihovna
		Graphics mobjGrafika;

		// parametry balonku
		int mintSouradniceX, mintSouradniceY;
		const int mcnVelikost = 40;

		// --------------------------------
		// konstruktor
		// --------------------------------
		public clsBalonek(Graphics objGrafika, int intX, int intY)
		{
			// zaznamenat hodnoty do proměnných
			mobjGrafika = objGrafika;
			mintSouradniceX = intX;
			mintSouradniceY = intY;
		}
	}
}
