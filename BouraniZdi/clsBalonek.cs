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
		bool mblJeVidet;

		// --------------------------------
		// konstruktor
		// --------------------------------
		public clsBalonek(Graphics objGrafika, int intX, int intY)
		{
			// zaznamenat hodnoty do proměnných
			mobjGrafika = objGrafika;
			mintSouradniceX = intX;
			mintSouradniceY = intY;
			mblJeVidet = true;
		}

		// --------------------------------
		// vykreslení
		// --------------------------------
		public void Vykresli()
		{
			// vykreslit balonek
			if (mblJeVidet == true)
			{
				mobjGrafika.DrawEllipse(Pens.Blue, mintSouradniceX, mintSouradniceY, mcnVelikost, mcnVelikost);
			}
			else
			{
				mobjGrafika.DrawEllipse(Pens.White, mintSouradniceX, mintSouradniceY, mcnVelikost, mcnVelikost);
			}
		}

		// --------------------------------
		// test kolize
		// --------------------------------
		public void TestKolize(int intX, int intY, int intVelikost)
		{
			int lintBalonekX, lintBalonekY;
			int lintKulickaX, lintKulickaY;
			double ldblVzdalenostStredu, ldblSoucetPolomeru;

			// střed balonku
			lintBalonekX = mintSouradniceX + (mcnVelikost / 2);
			lintBalonekY = mintSouradniceY + (mcnVelikost / 2);

			// střed kuličky
			lintKulickaX = intX + (intVelikost / 2);
			lintKulickaY = intY + (intVelikost / 2);

			// součet poloměrů výpočet
			ldblSoucetPolomeru = (mcnVelikost / 2) + (intVelikost / 2);

			// výpočet vzdálenosti středů
			ldblVzdalenostStredu = Math.Sqrt(Math.Pow(lintBalonekX - lintKulickaX, 2) + Math.Pow(lintBalonekY - lintKulickaY, 2));

			// Kontrola kolize
			if (ldblVzdalenostStredu < ldblSoucetPolomeru)
			{
				mblJeVidet = false; // Změna na bílou barvu
			}
		}
	}
}
