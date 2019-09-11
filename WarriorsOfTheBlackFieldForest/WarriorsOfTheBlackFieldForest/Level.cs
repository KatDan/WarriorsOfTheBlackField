using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace WarriorsOfTheBlackFieldForest
{
    public class Level
    {
        internal PictureBox pozadie;
        internal Hrdina hrdina;
        internal Padouch padouch;
        internal int obtiaznost;
        internal PictureBox nazov_levelu;
        internal Random nahodne;
        internal Image[] pozadia;
        internal Image[] cislo_levelu;

        public Level(int uroven, Hrdina hhrdina, Padouch padouch, PictureBox pozadiee, PictureBox nazov)
        {
            obtiaznost = uroven;
            this.hrdina = hhrdina;
            this.pozadie = pozadiee;
            nazov_levelu = nazov;
            nahodne = new Random();

            this.padouch = padouch;
            padouch.vygeneruj_nepriatela(uroven);

            pozadia = new Image[] {
                Properties.Resources.gif1 ,
                Properties.Resources.gif2,
                Properties.Resources.gif3,
                Properties.Resources.gif4,
                Properties.Resources.gif5,
                Properties.Resources.pozadie1,
                Properties.Resources.pozadie2,
                Properties.Resources.pozadie3,
                Properties.Resources.pozadie4
            };

            cislo_levelu = new Image[]
            {
                Properties.Resources.level1,
                Properties.Resources.level2,
                Properties.Resources.level3,
                Properties.Resources.level4,
                Properties.Resources.level5
            };

        }

        public void nastav_nazov(int i)
        {
            nazov_levelu.Image = cislo_levelu[i-1];
            
            nazov_levelu.Visible = true;
            nazov_levelu.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void vygeneruj_pozadie()
        {
            pozadie.Image = pozadia[nahodne.Next(0, 9)];
            
            pozadie.SizeMode = PictureBoxSizeMode.StretchImage;
            pozadie.SendToBack();
        }

        public void zrob_novy_level()
        {
            vygeneruj_pozadie();
            hrdina.odmizni_akcie();
            nastav_nazov(hrdina.level);
            padouch.vygeneruj_nepriatela(hrdina.level);
            hrdina.nastav_vychodziu_poziciu();
            padouch.nastav_vychodziu_poziciu();
            padouch.vygeneruj_telo();
            hrdina.ukaz_sa();
            padouch.ukaz_sa();
            hrdina.nepriatel = padouch;
            hrdina.zisti_vzdialenost();
            hrdina.hpbar.Value = hrdina.hpbar.Maximum;
            hrdina.ukaz_hp.Text = hrdina.max_zivot.ToString();
            padouch.hpbar.Maximum = padouch.max_zivot;

            padouch.hpbar.Value = padouch.max_zivot;
            padouch.vyhra = false;
            hrdina.vyhra = false;
        }
    }
}
