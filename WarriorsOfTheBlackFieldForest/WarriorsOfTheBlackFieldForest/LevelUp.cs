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
        internal Label xp_left;
        internal int xp_now;
        internal Button option1;
        internal Button option2;
        internal Button option3;
        internal Button option4;
        internal Hrdina hrdina;
        internal Label stat1;
        internal Label stat2;
        internal Label stat3;
        internal Label stat4;
        internal PictureBox pozadie;
        internal PictureBox text_levelup;
        internal int obtiaznost;

        public LevelUp(Label xp, Hra.Options o, Hrdina geroj, Hra.Stats s, PictureBox pozadicko, PictureBox text)
        {
            obtiaznost = 0;
            xp_left = xp;
            option1 = o.buttony[0];
            option2 = o.buttony[1];
            option3 = o.buttony[2];
            option4 = o.buttony[3];
            hrdina = geroj;
            stat1 = s.staty[0];
            stat2 = s.staty[1];
            stat3 = s.staty[2];
            stat4 = s.staty[3];
            pozadie = pozadicko;
            text_levelup = text;
            xp_now = hrdina.xp[obtiaznost];
        }

        public void ukaz_sa()
        {
            updateni_veci();
            text_levelup.Image = Image.FromFile(@"levelupys.png");
            xp_left.Visible = true;
            option1.Visible = true;
            option2.Visible = true;
            option3.Visible = true;
            option4.Visible = true;
            hrdina.telo.Location = new Point(200, hrdina.telo.Location.Y);
            hrdina.telo.Visible = true;
            stat1.Visible = true;
            stat2.Visible = true;
            stat3.Visible = true;
            stat4.Visible = true;
            hrdina.nepriatel.telo.Visible = false;
            hrdina.nepriatel.hpbar.Visible = false;
            hrdina.nepriatel.show_hp.Visible = false;
            pozadie.SendToBack();
            hrdina.hpbar.Visible = false;
            hrdina.show_hp.Visible = false;
            text_levelup.Visible = true;
            text_levelup.BringToFront();
            hrdina.zmizni_akcie();
        }

        public void zmizni()
        {
            xp_left.Visible = false;
            option1.Visible = false;
            option2.Visible = false;
            option3.Visible = false;
            option4.Visible = false;
            //hrdina.telo.Visible = false;
            stat1.Visible = false;
            stat2.Visible = false;
            stat3.Visible = false;
            stat4.Visible = false;
        }

        public void updateni_veci()
        {
            stat1.Text = "  Potions :               " + hrdina.pocet_potionov.ToString();
            stat2.Text = "  ATTACK :             " + hrdina.utok.ToString();
            stat3.Text = "  HP :                      " + hrdina.max_zivot.ToString();
            stat4.Text = "  DEFENSE :          " + hrdina.obrana.ToString();
            xp_left.Text = "Each upgrade costs 1 xp:\n" + xp_now.ToString() + " xp left";

        }
    }
}
