using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WarriorsOfTheBlackFieldForest
{
    public class Hrdina : Postava
    {
        public Hrdina()
        {
            zivot = 10;
            utok = 1;
            obrana = 1;
            vzdialenost = 100;
            level = 1;
        }

        public Hrdina(PictureBox kvz, PictureBox kdo, PictureBox me, PictureBox pot, ProgressBar ziv, Label uky, Timer krok_vpred, Timer krok_vzad, Timer vypad)
        {
            zivot = 10;
            utok = 2;
            obrana = 1;
            rnd = new Random();

            level = 1;
            xp_k_disp = 0;
            vyhra = false;

            staty[0] = zivot;
            staty[1] = utok;
            staty[2] = obrana;

            hpbar = ziv;
            hpbar.Maximum = zivot;
            hpbar.Value = hpbar.Maximum;

            box_left = kvz;
            box_right = kdo;
            box_potion = pot;
            box_sword = me;

            boxy_akcii = new PictureBox[4] { box_left, box_right, box_potion, box_sword };

            //ujma = au;
            show_hp = uky;

            krok_vpred_t = krok_vpred;
            krok_vzad_t = krok_vzad;
            utok_pohyb = vypad;
        }

        public void nastav_vychodziu_poziciu()
        {
            nastav_poziciu(200, 300);
        }

        public void vytvor_zakladneho_hrdinu()
        {
            zivot = 10;
            utok = 2;
            obrana = 1;

            level = 1;
            xp_k_disp = 0;
            vyhra = false;

            staty[0] = zivot;
            staty[1] = utok;
            staty[2] = obrana;

            hpbar.Maximum = zivot;
            hpbar.Value = hpbar.Maximum;
        }

        public void ukaz_sa()
        {
            nastav_poziciu(telo.Location.X, telo.Location.Y);
            hpbar.Visible = true;
            show_hp.Visible = true;
            show_hp.Text = hpbar.Value.ToString();
        }

    }
}
