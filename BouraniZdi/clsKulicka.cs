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

		// public souradnice X
		public int intX
		{
			get { return mintSouradniceX; }
		}

		// public souradnice Y
		public int intY
		{
			get { return mintSouradniceY; }
		}

		// ---------------------------------
		// konstruktor
		// ---------------------------------
		public clsKulicka(Graphics objGrafika, int intX, int intY)
		{
			// zaznamenat hodnoty do proměnných
			mobjGrafika = objGrafika;
			mintSouradniceX = intX;
			mintSouradniceY = intY;
			mintPosunX = mintPosunY = 5;
		}

		// ---------------------------------
		// posun a vykreslení
		// ---------------------------------
		public void PosunVykresli()
		{
			// vykreslit kuličku
			mobjGrafika.FillEllipse(Brushes.White, mintSouradniceX, mintSouradniceY, mcnVelikost, mcnVelikost);

			// pohnout kuličkou
			mintSouradniceX = mintSouradniceX + mintPosunX;
			mintSouradniceY = mintSouradniceY + mintPosunY;

			// test odrazu Y
			if (((mintSouradniceY + mcnVelikost) > mobjGrafika.VisibleClipBounds.Height) || (mintSouradniceY < 0))
				mintPosunY = mintPosunY * (-1);

			// test odrazu X
			if (((mintSouradniceX + mcnVelikost) > mobjGrafika.VisibleClipBounds.Width) || (mintSouradniceX < 0))
				mintPosunX = mintPosunX * (-1);

			// vykreslit kuličku
			mobjGrafika.FillEllipse(Brushes.Blue, mintSouradniceX, mintSouradniceY, mcnVelikost, mcnVelikost);
		}

		// ---------------------------------
		// odraz od vozíčku
		// ---------------------------------
		public void OdrazOdPlosiny(int intX, int intY, int intSirka)
		{
			int lintStredKulickyX;

			// vypočítat souřadnici X středu kuličky
			lintStredKulickyX = mintSouradniceX + mcnVelikost / 2;

			// test kolize
			if (mintSouradniceY + mcnVelikost > intY)
			{
				if ((lintStredKulickyX > intX) && (lintStredKulickyX < (intX + intSirka)))
					mintPosunY = mintPosunY * (-1);
			}
		}
	}
}
