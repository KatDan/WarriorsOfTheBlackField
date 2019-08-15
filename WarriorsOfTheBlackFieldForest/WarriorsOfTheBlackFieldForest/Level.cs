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
        internal Random rnd;

        public Level(int uroven, Hrdina hhrdina, Padouch padouch, PictureBox pozadiee, PictureBox nazov)
        {
            obtiaznost = uroven;
            this.hrdina = hhrdina;
            this.pozadie = pozadiee;
            nazov_levelu = nazov;
            rnd = new Random();
            //nepriatel
            this.padouch = padouch;
            padouch.vygeneruj_bubaka(uroven);
        }

        public void nastav_nazov(int i)
        {
            switch (i)
            {
                case 1: nazov_levelu.Image = Image.FromFile(@"level1.png"); break;
                case 2: nazov_levelu.Image = Image.FromFile(@"level2.png"); break;
                case 3: nazov_levelu.Image = Image.FromFile(@"level3.png"); break;
                case 4: nazov_levelu.Image = Image.FromFile(@"level4.png"); break;
                case 5: nazov_levelu.Image = Image.FromFile(@"level5.png"); break;
            }
            nazov_levelu.Visible = true;
            nazov_levelu.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void vygeneruj_pozadie()
        {
            switch (rnd.Next(1, 10))
            {
                case 1: pozadie.Image = Image.FromFile(@"gif1.gif"); break;
                case 2: pozadie.Image = Image.FromFile(@"gif2.gif"); break;
                case 3: pozadie.Image = Image.FromFile(@"gif3.gif"); break;
                case 4: pozadie.Image = Image.FromFile(@"gif4.gif"); break;
                case 5: pozadie.Image = Image.FromFile(@"gif5.gif"); break;
                case 6: pozadie.Image = Image.FromFile(@"pozadie1.jpg"); break;
                case 7: pozadie.Image = Image.FromFile(@"pozadie2.jpg"); break;
                case 8: pozadie.Image = Image.FromFile(@"pozadie3.jpg"); break;
                case 9: pozadie.Image = Image.FromFile(@"pozadie4.jpg"); break;
            }

            pozadie.SizeMode = PictureBoxSizeMode.StretchImage;
            pozadie.SendToBack();
        }

        public void zrob_novy_level()
        {
            vygeneruj_pozadie();
            hrdina.odmizni_akcie();
            nastav_nazov(hrdina.level);
            padouch.vygeneruj_bubaka(hrdina.level);
            hrdina.nastav_vychodziu_poziciu();
            padouch.nastav_vychodziu_poziciu();
            padouch.vygeneruj_telo();
            hrdina.ukaz_sa();
            padouch.ukaz_sa();
            //hrdina.zmizni_akcie();
            hrdina.nepriatel = padouch;
            hrdina.zisti_vzdialenost();
            hrdina.hpbar.Value = hrdina.hpbar.Maximum;
            hrdina.show_hp.Text = hrdina.max_zivot.ToString();
            padouch.hpbar.Maximum = padouch.max_zivot;

            padouch.hpbar.Value = padouch.max_zivot;
            padouch.vyhra = false;
            hrdina.vyhra = false;
        }
    }
}
