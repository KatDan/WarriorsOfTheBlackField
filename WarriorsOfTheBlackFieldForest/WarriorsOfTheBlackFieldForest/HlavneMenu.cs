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
        internal TextBox textbox_vysoke_skore;
        internal Button submitni;

        internal PictureBox nazov;
        internal Button nova_hra;
        internal Button skore;
        internal Button ako_hrat;
        internal Button kredity;
        internal PictureBox pozadicko;

        public HlavneMenu(PictureBox nazovv, Button nova_hra, Button intro,Button skore, Button credits, PictureBox pozadicko, TextBox textbox, Button posli)
        {
            nazov = nazovv;
            this.nova_hra = nova_hra;
            this.skore = skore;
            this.ako_hrat = intro;
            this.kredity = credits;
            this.pozadicko = pozadicko;
            textbox_vysoke_skore = textbox;
            submitni = posli;
            //pozadicko.Visible = true;
        }

        public void zmizni_menu()
        {
            nazov.Visible = false;
            nova_hra.Visible = false;
            skore.Visible = false;
            ako_hrat.Visible = false;
            //pozadicko.Visible = false;
            kredity.Visible = false;
            kredity.SendToBack();
        }

        public void ukaz_menu()
        {
            pozadicko.Visible = true;
            pozadicko.BringToFront();
            nazov.Visible = true;
            nazov.BringToFront();

            nova_hra.Visible = true;
            nova_hra.BringToFront();
            skore.Visible = true;
            skore.BringToFront();
            ako_hrat.Visible = true;
            ako_hrat.BringToFront();
            
            kredity.Visible = true;
            kredity.BringToFront();
        }

    }
}
