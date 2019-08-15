using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WarriorsOfTheBlackFieldForest
{
    public class Postava
    {
        internal int zivot = 10;
        internal int max_zivot = 10;
        internal int utok = 1;
        internal int obrana = 1;
        internal int vzdialenost = 100;
        internal int level = 1;
        internal int xp_k_disp = 5;
        internal Postava nepriatel;
        internal int pocet_potionov;
        internal bool vyhra;
        internal Random rnd;

        internal int ciel_poz_x;
        internal bool prebieha;

        //vizual
        internal ProgressBar hpbar;
        internal Label ujma;
        internal PictureBox box_left;
        internal PictureBox box_right;
        internal PictureBox box_potion;
        internal PictureBox box_sword;
        internal PictureBox telo;
        internal PictureBox[] boxy_akcii;
        internal Boolean vykonane;
        internal Label show_hp;

        internal Timer krok_vpred_t;
        internal Timer krok_vzad_t;
        internal Timer utok_pohyb;

        public Postava()
        {
            zivot = 10;
            utok = 1;
            obrana = 1;
            vzdialenost = 100;
            level = 1;
            xp_k_disp = 0;

            staty[0] = zivot;
            staty[1] = utok;
            staty[2] = obrana;
        }

        public Postava(PictureBox kvz, PictureBox kdo, PictureBox me, PictureBox pot, ProgressBar ziv, Label au, Label uky)
        {
            pocet_potionov = 0;
            zivot = 10;
            utok = 2;
            obrana = 1;
            zisti_vzdialenost();
            level = 1;
            xp_k_disp = 0;
            vyhra = false;

            staty[0] = zivot;
            staty[1] = utok;
            staty[2] = obrana;

            hpbar = ziv;
            hpbar.Maximum = zivot;

            box_left = kvz;
            box_right = kdo;
            box_potion = pot;
            box_sword = me;

            boxy_akcii = new PictureBox[4] { box_left, box_right, box_potion, box_sword };

            ujma = au;
            show_hp = uky;

        }

        public void zisti_vzdialenost()
        {
            vzdialenost = telo.Location.X - nepriatel.telo.Location.X + telo.Width;
            if (vzdialenost < 0) vzdialenost = -vzdialenost;
            nepriatel.vzdialenost = vzdialenost;
        }

        internal int[] xp = new int[] { 2, 2, 3, 3, 3 };
        internal int[] staty = new int[3];

        internal int akt_sila_utoku;

        Random rand = new Random();

        //metody

        public int lvl_xp_sum(int level)
        {
            int pom = 0;
            for (int i = 0; i < level; i++)
            {
                pom += xp[i];
            }
            return pom;
        }

        public void zmen_zivot(int zivot)
        {
            this.zivot = zivot;
            hpbar.Value = zivot;
        }

        public void zmen_utok(int utok)
        {
            this.utok = utok;
        }

        public void zmen_obranu(int obrana)
        {
            this.obrana = obrana;
        }

        public void update_stats()
        {
            zivot = staty[0] / 2 + 2;
            utok = staty[1] % (level + 1) + 1;

            obrana = staty[2];

            max_zivot = zivot;
            hpbar.Maximum = zivot;
            hpbar.Value = zivot;

        }

        public void vygeneruj_bubaka(int level)
        {
            xp_k_disp = lvl_xp_sum(level);
            for (int i = 0; i < 3; i++)
            {
                int pom = rand.Next(0, xp_k_disp + 1);
                staty[i] += pom;
                xp_k_disp -= pom;
            }
            update_stats();
        }

        public void Nastav_nepriatela(Postava nepritel)
        {
            nepriatel = nepritel;
            vzdialenost = nepritel.telo.Location.X - telo.Location.X;
        }

        public void sila_utoku()
        {
            int a = rand.Next(0, 2);
            if (a == 1) a = -1;
            else a = 1;
            akt_sila_utoku = utok + a * rand.Next(0, utok / 2);
        }

        public void utoc()
        {
            if (akt_sila_utoku > 0) nepriatel.zivot = nepriatel.zivot - akt_sila_utoku;
            if (nepriatel.zivot > 0) nepriatel.hpbar.Value = nepriatel.zivot;
            else nepriatel.hpbar.Value = 0;
        }

        public void bran_sa()
        {
            nepriatel.akt_sila_utoku -= (rand.Next(0, 51) / 40) * obrana;
        }

        public void urob_pohyb_neschopnosti()
        {
            for (int i = 0; i < 10; i++)
            {

                System.Threading.Thread.Sleep(10);
                telo.Location = new Point(telo.Location.X, telo.Location.Y + 1);
                telo.Update();
            }
            System.Threading.Thread.Sleep(10);
            for (int i = 0; i < 10; i++)
            {

                System.Threading.Thread.Sleep(10);
                telo.Location = new Point(telo.Location.X, telo.Location.Y - 1);
                telo.Update();
            }
            //odmizni_akcie();
            hpbar.Visible = true;
            show_hp.Visible = true;
            vykonane = true;
        }

        public bool zisti_ci_mozes_utocit()
        {
            if (vzdialenost < 80) return true;
            else return false;
        }

        //akcie tahu

        public void zisti_ci_som_vyhral()
        {
            if (nepriatel.hpbar.Value == 0) { vyhra = true; level += 1; }
            else vyhra = false;
        }

        public void akcia_utok()
        {
            vykonane = false;
            if (zisti_ci_mozes_utocit() == true)
            {
                sila_utoku();
                nepriatel.bran_sa();
                utoc();
                nepriatel.show_hp.Update();
                //urob_utocny_pohyb();
                //zobraz_ujmu();
                vykonane = true;
                animacia_utoku();
                nepriatel.show_hp.Text = nepriatel.hpbar.Value.ToString();
                show_hp.Text = hpbar.Value.ToString();
                show_hp.Update();
                hpbar.Update();
                nepriatel.hpbar.Update();

                zisti_ci_som_vyhral();
            }
            else { animacia_utoku(); vykonane = true; }
            //else { vykonane = false; urob_pohyb_neschopnosti(); }
        }

        public void akcia_napi_sa(int o_kolko)
        {
            vykonane = false;
            zivot += o_kolko;
            vykonane = true;
        }

        public virtual void akcia_krok_dopredu()
        {
            vykonane = false;
            if (telo.Location.X + telo.Width + 60 <= 1000 && telo.Location.X + telo.Width + 60 <= nepriatel.telo.Location.X)
            {
                vzdialenost -= 60;
                nepriatel.vzdialenost -= 60;
                ciel_poz_x = telo.Location.X + 60;
                krok_vpred_t.Start();
                //nastav_poziciu(telo.Location.X + 60, telo.Location.Y);
                vykonane = true;
            }
            else urob_pohyb_neschopnosti();
            //else vykonane = false;

        }

        public virtual void akcia_krok_dozadu()
        {
            vykonane = false;
            if (telo.Location.X - 60 >= 0 && telo.Location.X - 60 <= nepriatel.telo.Location.X + nepriatel.telo.Width)
            {
                vzdialenost += 60;
                nepriatel.vzdialenost += 60;
                ciel_poz_x = telo.Location.X - 60;
                krok_vzad_t.Start();
                //nastav_poziciu(telo.Location.X - 60, telo.Location.Y);
                vykonane = true;
            }
            //else vykonane = false;
            else urob_pohyb_neschopnosti();
        }

        //vizualna stranka postavy

        public void nastav_poziciu(int x, int y)
        {
            telo.Location = new Point(x, y);
            hpbar.Location = new Point(telo.Location.X, telo.Location.Y - 10);
            show_hp.Location = new Point(hpbar.Location.X - show_hp.Size.Width, hpbar.Location.Y);

            hpbar.BringToFront();

            if (boxy_akcii != null)
            {
                for (int i = 0; i <= 3; i++)
                {
                    PictureBox ikonka = boxy_akcii[i];
                    ikonka.Size = new Size(20, 20);
                    ikonka.Location = new Point(telo.Location.X + i * 30, telo.Location.Y + telo.Size.Height + 10);
                    ikonka.BringToFront();
                }
            }
            telo.BringToFront();
            hpbar.BringToFront();
            show_hp.BringToFront();
            show_hp.Text = hpbar.Value.ToString();
        }

        public virtual void urob_utocny_pohyb()
        {
            ciel_poz_x = telo.Location.X + 10;

            krok_vzad_t.Interval = 1;
            utok_pohyb.Start();
            utoc();

        }

        public void zmizni_akcie()
        {
            for (int x = 0; x <= 3; x++)
            {
                boxy_akcii[x].Visible = false;
            }
        }

        public void odmizni_akcie()
        {
            for (int x = 0; x <= 3; x++)
            {
                boxy_akcii[x].Visible = true;
            }
        }

        public void Nahodna_akcia()
        {
            //Random rnd = new Random();

            if (vzdialenost <= 60)
            {
                switch (rnd.Next(0, 4))
                {
                    case 0: akcia_krok_dopredu(); break;
                    default: akcia_utok(); break;
                }
            }
            else
            {
                switch (rnd.Next(0, 5))
                {
                    case 0: akcia_krok_dopredu(); break;
                    case 1: akcia_krok_dopredu(); break;
                    case 2: akcia_krok_dozadu(); break;
                    case 3: akcia_krok_dozadu(); break;
                    default: akcia_utok(); break;
                }
            }
            if (vykonane == false) Nahodna_akcia();

        }

        public void tah_padoucha()
        {
            //zmizni_akcie();
            nepriatel.Nahodna_akcia();
            nepriatel.show_hp.Text = nepriatel.hpbar.Value.ToString();
            nepriatel.show_hp.Update();
            //pockej si
            //odmizni_akcie();
        }

        public virtual void animacia_utoku()
        {

            for (int i = 0; i < 20; i++)
            {
                //Console.WriteLine("utok vpred");
                System.Threading.Thread.Sleep(10);

                telo.Location = new Point(telo.Location.X + 1, telo.Location.Y);
                telo.Update();

            }
            System.Threading.Thread.Sleep(10);
            for (int i = 0; i < 20; i++)
            {
                //Console.WriteLine("utok vzad");
                System.Threading.Thread.Sleep(10);
                telo.Location = new Point(telo.Location.X - 1, telo.Location.Y);
                telo.Update();
            }
            odmizni_akcie();
            hpbar.Visible = true;
            show_hp.Visible = true;

        }
    }
}
