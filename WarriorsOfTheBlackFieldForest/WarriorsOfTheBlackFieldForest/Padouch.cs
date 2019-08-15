﻿using System;
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
        public Padouch(Hrdina hrdina, ProgressBar ziv, Label uky, Timer krok_vpred, Timer krok_vzad, Timer utocny_krok)
        {
            //nastavi vhodnu obtiaznost
            rnd = new Random();
            hpbar = ziv;
            vygeneruj_bubaka(hrdina.level);
            //hpbar.Maximum = hrdina.level * 10;
            hpbar.Value = hpbar.Maximum;
            //ujma = jau;
            nepriatel = hrdina;
            show_hp = uky;
            vyhra = false;

            krok_vpred_t = krok_vpred;
            krok_vzad_t = krok_vzad;
            utok_pohyb = utocny_krok;

            update_stats();
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
            //Random rnd = new Random();
            switch (rnd.Next(1, 12))
            {
                case 1: telo.Image = Image.FromFile(@"bubak1-removebg.png"); break;
                case 2: telo.Image = Image.FromFile(@"bubak2-removebg.png"); break;
                case 3: telo.Image = Image.FromFile(@"bubak3-removebg.png"); break;
                case 4: telo.Image = Image.FromFile(@"bubak4-removebg.png"); break;
                case 5: telo.Image = Image.FromFile(@"bubak5-removebg.png"); break;
                case 6: telo.Image = Image.FromFile(@"bubak6-removebg.png"); break;
                case 7: telo.Image = Image.FromFile(@"bubak7-removebg.png"); break;
                case 8: telo.Image = Image.FromFile(@"bubak8-removebg.png"); break;
                case 9: telo.Image = Image.FromFile(@"bubak9-removebg.png"); break;
                case 10: telo.Image = Image.FromFile(@"bubak10-removebg.png"); break;
                case 11: telo.Image = Image.FromFile(@"bubak11-removebg.png"); break;
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
            show_hp.Visible = true;
            hpbar.Visible = true;
        }
    }
}
