using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WarriorsOfTheBlackFieldForest
{
    public class Padouch : Postava
    {
        internal Image[] ksichty;

        public Padouch(Hrdina hrdina, Hra.Zivot ziv, Hra.TimerKrok krok)
        {
            //nastavi vhodnu obtiaznost
           
            hpbar = ziv.bar;
            
            level = hrdina.level;
            hpbar.Value = hpbar.Maximum;
            nepriatel = hrdina;
            ukaz_hp = ziv.ukaz;
            vyhra = false;
            vygeneruj_nepriatela(hrdina.level);

            krok_vpred_t = krok.timery[0];
            krok_vzad_t = krok.timery[1];
            utok_pohyb = krok.timery[2];

            aktualizuj_atributy();

            ksichty = new Image[]
            {
                Properties.Resources.bubak1_removebg,
                Properties.Resources.bubak2_removebg,
                Properties.Resources.bubak3_removebg,
                Properties.Resources.bubak4_removebg,
                Properties.Resources.bubak5_removebg,
                Properties.Resources.bubak6_removebg,
                Properties.Resources.bubak7_removebg,
                Properties.Resources.bubak8_removebg,
                Properties.Resources.bubak9_removebg,
                Properties.Resources.bubak10_removebg,
                Properties.Resources.bubak11_removebg
            };
        }



        public override void urob_utocny_pohyb()
        {
            ciel_poz_x = telo.Location.X - 10;

            krok_vzad_t.Interval = 1;
            utok_pohyb.Start();
        }

        public override void animacia_utoku()
        {

            for (int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(10);
                telo.Location = new Point(telo.Location.X - 1, telo.Location.Y);
                telo.Update();
            }
            System.Threading.Thread.Sleep(10);
            for (int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(10);
                telo.Location = new Point(telo.Location.X + 1, telo.Location.Y);
                telo.Update();
            }


        }

        public void nastav_vychodziu_poziciu()
        {
            nastav_poziciu(500, 300);
        }

        public void vygeneruj_telo()
        {
            Random nahodne = new Random();
            telo.Image = ksichty[nahodne.Next(0, 11)];
            
        }

        public override void akcia_krok_dopredu()
        {
            vykonane = false;
            if (telo.Location.X - 40 >= 0 && telo.Location.X - 40 >= nepriatel.telo.Location.X + nepriatel.telo.Width)
            {
                vzdialenost -= 40;
                nepriatel.vzdialenost -= 40;

                ciel_poz_x = telo.Location.X - 40;
                krok_vpred_t.Start();
                vykonane = true;
            }
            else vykonane = false;

        }

        public override void akcia_krok_dozadu()
        {
            vykonane = false;
            if (telo.Location.X + telo.Width <= 700)
            {
                vzdialenost += 40;
                nepriatel.vzdialenost += 40;

                ciel_poz_x = telo.Location.X + 40;
                krok_vzad_t.Start();
                vykonane = true;
            }
            else vykonane = false;
        }

        public void ukaz_sa()
        {
            telo.Visible = true;
            ukaz_hp.Visible = true;
            hpbar.Visible = true;
        }
    }
}
