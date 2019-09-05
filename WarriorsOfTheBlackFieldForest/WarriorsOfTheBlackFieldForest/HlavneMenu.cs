using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarriorsOfTheBlackFieldForest
{
    public class HlavneMenu
    {
        internal PictureBox nazov;
        internal Button nova_hra;
        internal Button skore;
        internal Button kredity;
        internal PictureBox pozadicko;

        public HlavneMenu(PictureBox nazovv, Button nova_hra, Button skore, Button credits, PictureBox pozadicko)
        {
            nazov = nazovv;
            this.nova_hra = nova_hra;
            this.skore = skore;
            this.kredity = credits;
            this.pozadicko = pozadicko;
        }

        public void zmizni_menu()
        {
            nazov.Visible = false;
            nova_hra.Visible = false;
            skore.Visible = false;
            //pozadicko.Visible = false;
            kredity.Visible = false;
        }
    }
}
