using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WarriorsOfTheBlackFieldForest
{
    public class LevelUp
    {
        internal Label zvysne_xp;
        internal int xp_teraz;
        internal Button moznost1;
        internal Button moznost2;
        internal Button moznost3;
        internal Button moznost4;
        internal Hrdina hrdina;
        internal Label atribut1;
        internal Label atribut2;
        internal Label atribut3;
        internal Label atribut4;
        internal PictureBox pozadie;
        internal PictureBox text_levelup;
        internal int obtiaznost;

        public LevelUp(Label xp, Hra.Moznosti o, Hrdina geroj, Hra.Atributy s, PictureBox pozadicko, PictureBox text)
        {
            obtiaznost = 0;
            zvysne_xp = xp;
            moznost1 = o.tlacitka[0];
            moznost2 = o.tlacitka[1];
            moznost3 = o.tlacitka[2];
            moznost4 = o.tlacitka[3];
            hrdina = geroj;
            atribut1 = s.atributy[0];
            atribut2 = s.atributy[1];
            atribut3 = s.atributy[2];
            atribut4 = s.atributy[3];
            pozadie = pozadicko;
            text_levelup = text;
            xp_teraz = hrdina.xp[obtiaznost];
        }

        public void ukaz_sa()
        {
            aktualizuj_veci();
            text_levelup.Image = Properties.Resources.levelupys;
            zvysne_xp.Visible = true;
            moznost1.Visible = true;
            moznost2.Visible = true;
            moznost3.Visible = true;
            moznost4.Visible = true;
            hrdina.telo.Location = new Point(200, hrdina.telo.Location.Y);
            hrdina.telo.Visible = true;
            atribut1.Visible = true;
            atribut2.Visible = true;
            atribut3.Visible = true;
            atribut4.Visible = true;
            hrdina.nepriatel.telo.Visible = false;
            hrdina.nepriatel.hpbar.Visible = false;
            hrdina.nepriatel.ukaz_hp.Visible = false;
            pozadie.SendToBack();
            hrdina.hpbar.Visible = false;
            hrdina.ukaz_hp.Visible = false;
            text_levelup.Visible = true;
            text_levelup.BringToFront();
            hrdina.zmizni_akcie();
            
        }

        public void zmizni()
        {
            zvysne_xp.Visible = false;
            moznost1.Visible = false;
            moznost2.Visible = false;
            moznost3.Visible = false;
            moznost4.Visible = false;
            atribut1.Visible = false;
            atribut2.Visible = false;
            atribut3.Visible = false;
            atribut4.Visible = false;
            text_levelup.SendToBack();
        }

        public void aktualizuj_veci()
        {
            atribut1.Text = "  Potions :               " + hrdina.pocet_elixirov.ToString();
            atribut2.Text = "  ATTACK :             " + hrdina.utok.ToString();
            atribut3.Text = "  HP :                      " + hrdina.max_zivot.ToString();
            atribut4.Text = "  DEFENSE :          " + hrdina.obrana.ToString();
            zvysne_xp.Text = "Each upgrade costs 1 xp:\n" + xp_teraz.ToString() + " xp left";

        }
    }
}
