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

        public Level(int uroven, Hrdina hhrdina, Padouch padouch, PictureBox pozadiee, PictureBox nazov)
        {
            obtiaznost = uroven;
            this.hrdina = hhrdina;
            this.pozadie = pozadiee;
            nazov_levelu = nazov;
            nahodne = new Random();
            //nepriatel
            this.padouch = padouch;
            padouch.vygeneruj_nepriatela(uroven);
        }

        public void nastav_nazov(int i)
        {
            switch (i)
            {
                case 1: nazov_levelu.Image = Properties.Resources.level1; break;
                case 2: nazov_levelu.Image = Properties.Resources.level2; break;
                case 3: nazov_levelu.Image = Properties.Resources.level3; break;
                case 4: nazov_levelu.Image = Properties.Resources.level4; break;
                case 5: nazov_levelu.Image = Properties.Resources.level5; break;
            }
            nazov_levelu.Visible = true;
            nazov_levelu.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void vygeneruj_pozadie()
        {
            switch (nahodne.Next(1, 10))
            {
                case 1: pozadie.Image = Properties.Resources.gif1; break;
                case 2: pozadie.Image = Properties.Resources.gif2; break;
                case 3: pozadie.Image = Properties.Resources.gif3; break;
                case 4: pozadie.Image = Properties.Resources.gif4; break;
                case 5: pozadie.Image = Properties.Resources.gif5; break;
                case 6: pozadie.Image = Properties.Resources.pozadie1; break;
                case 7: pozadie.Image = Properties.Resources.pozadie2; break;
                case 8: pozadie.Image = Properties.Resources.pozadie3; break;
                case 9: pozadie.Image = Properties.Resources.pozadie4; break;
            }

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
            //hrdina.zmizni_akcie();
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
