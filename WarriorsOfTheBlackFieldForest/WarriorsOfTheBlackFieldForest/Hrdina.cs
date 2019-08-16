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

        public Hrdina(Hra.Boxy b, Hra.Zivot ziv, Hra.TimerKrok kroky)
        {
            zivot = 10;
            utok = 2;
            obrana = 1;
            rand = new Random();

            level = 1;
            xp_k_disp = 0;
            vyhra = false;

            staty[0] = zivot;
            staty[1] = utok;
            staty[2] = obrana;

            hpbar = ziv.bar;
            hpbar.Maximum = zivot;
            hpbar.Value = hpbar.Maximum;

            box_left = b.boxy[0];
            box_right = b.boxy[1];
            box_potion = b.boxy[2];
            box_sword = b.boxy[3];

            boxy_akcii = b.boxy;

            //ujma = au;
            show_hp = ziv.show;

            krok_vpred_t = kroky.timery[0];
            krok_vzad_t = kroky.timery[1];
            utok_pohyb = kroky.timery[2];
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
