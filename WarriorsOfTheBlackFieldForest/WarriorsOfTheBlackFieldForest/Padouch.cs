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
        public Padouch(Hrdina hrdina, Hra.Zivot ziv, Hra.TimerKrok krok)
        {
            //nastavi vhodnu obtiaznost
           
            hpbar = ziv.bar;
            
            level = hrdina.level;
            //hpbar.Maximum = hrdina.level * 10;
            hpbar.Value = hpbar.Maximum;
            //ujma = jau;
            nepriatel = hrdina;
            ukaz_hp = ziv.ukaz;
            vyhra = false;
            vygeneruj_nepriatela(hrdina.level);

            krok_vpred_t = krok.timery[0];
            krok_vzad_t = krok.timery[1];
            utok_pohyb = krok.timery[2];

            //this.rand = new Random();

            aktualizuj_atributy();
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
                //Console.WriteLine("utok vpred");
                System.Threading.Thread.Sleep(10);
                telo.Location = new Point(telo.Location.X - 1, telo.Location.Y);
                telo.Update();
            }
            System.Threading.Thread.Sleep(10);
            for (int i = 0; i < 20; i++)
            {
                //Console.WriteLine("utok vzad");
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
            switch (nahodne.Next(1, 12))
            {
                case 1: telo.Image = Properties.Resources.bubak1_removebg; break;
                case 2: telo.Image = Properties.Resources.bubak2_removebg; break;
                case 3: telo.Image = Properties.Resources.bubak3_removebg; break;
                case 4: telo.Image = Properties.Resources.bubak4_removebg; break;
                case 5: telo.Image = Properties.Resources.bubak5_removebg; break;
                case 6: telo.Image = Properties.Resources.bubak6_removebg; break;
                case 7: telo.Image = Properties.Resources.bubak7_removebg; break;
                case 8: telo.Image = Properties.Resources.bubak8_removebg; break;
                case 9: telo.Image = Properties.Resources.bubak9_removebg; break;
                case 10: telo.Image = Properties.Resources.bubak10_removebg; break;
                case 11: telo.Image = Properties.Resources.bubak11_removebg; break;
            }

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
                //nastav_poziciu(telo.Location.X - 40, telo.Location.Y);
                //Console.WriteLine("krok dopredu");
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
                //nastav_poziciu(telo.Location.X + 40, telo.Location.Y);
                //Console.WriteLine("krok dozadu");
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
