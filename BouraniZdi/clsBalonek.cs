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

		// --------------------------------
		// vykreslení
		// --------------------------------
		public void Vykresli()
		{
			// vykreslit balonek
			mobjGrafika.DrawEllipse(Pens.Blue, mintSouradniceX, mintSouradniceY, mcnVelikost, mcnVelikost);
		}

		// --------------------------------
		// test kolize
		// --------------------------------
		public void TestKolize(int intX, int intY, int intVelikost)
		{
			int lintBalonekX, lintBalonekY;
			int lintKulickaX, lintKulickaY;

			// střed balonku
			lintBalonekX = mintSouradniceX + (mcnVelikost / 2);
			lintBalonekY = mintSouradniceY + (mcnVelikost / 2);

			// střed kuličky
			lintKulickaX = intX + (intVelikost / 2);
			lintKulickaY = intY + (intVelikost / 2);
		}
	}
}
