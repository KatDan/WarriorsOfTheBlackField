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
            nahodne = new Random();

            level = 1;
            xp_k_disp = 0;
            vyhra = false;

            atributy[0] = zivot;
            atributy[1] = utok;
            atributy[2] = obrana;

            hpbar = ziv.bar;
            hpbar.Maximum = zivot;
            hpbar.Value = hpbar.Maximum;

            box_vlavo = b.boxy[0];
            box_vpravo = b.boxy[1];
            box_elixir = b.boxy[2];
            box_mec = b.boxy[3];

            boxy_akcii = b.boxy;

            ukaz_hp = ziv.ukaz;

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
            max_zivot = 10;
            utok = 2;
            obrana = 1;

            level = 1;
            xp_k_disp = 0;
            vyhra = false;

            atributy[0] = zivot;
            atributy[1] = utok;
            atributy[2] = obrana;

            hpbar.Maximum = zivot;
            hpbar.Value = hpbar.Maximum;
            ukaz_hp.Text = hpbar.Maximum.ToString();

        }

        public void ukaz_sa()
        {
            nastav_poziciu(telo.Location.X, telo.Location.Y);
            hpbar.Visible = true;
            ukaz_hp.Visible = true;
            ukaz_hp.Text = hpbar.Value.ToString();
        }

    }
}
