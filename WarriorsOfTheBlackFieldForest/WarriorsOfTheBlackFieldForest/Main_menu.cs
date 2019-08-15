using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarriorsOfTheBlackFieldForest
{
    public class Main_menu
    {
        internal PictureBox nazov;
        internal Button nova_hra;
        internal Button skore;
        internal Button credits;
        internal PictureBox pozadicko;

        public Main_menu(PictureBox nazovv, Button nova_hra, Button skore, Button credits, PictureBox pozadicko)
        {
            nazov = nazovv;
            this.nova_hra = nova_hra;
            this.skore = skore;
            this.credits = credits;
            this.pozadicko = pozadicko;
        }

        public void Zmizni_menu()
        {
            nazov.Visible = false;
            nova_hra.Visible = false;
            skore.Visible = false;
            //pozadicko.Visible = false;
            credits.Visible = false;
        }
    }
}
