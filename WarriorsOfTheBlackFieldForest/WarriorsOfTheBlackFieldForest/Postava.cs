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
        internal int pocet_elixirov;
        internal bool vyhra;
        internal static Random nahodne;

        internal int ciel_poz_x;
        internal bool prebieha;

        //vizual
        internal ProgressBar hpbar;
        internal Label ujma;
        internal PictureBox box_vlavo;
        internal PictureBox box_vpravo;
        internal PictureBox box_elixir;
        internal PictureBox box_mec;
        internal PictureBox telo;
        internal PictureBox[] boxy_akcii;
        internal Boolean vykonane;
        internal Label ukaz_hp;

        internal Timer krok_vpred_t;
        internal Timer krok_vzad_t;
        internal Timer utok_pohyb;

        public Postava() { }

        public Postava(PictureBox kvz, PictureBox kdo, PictureBox me, PictureBox pot, ProgressBar ziv, Label au, Label uky)
        {
            pocet_elixirov = 0;
            zivot = 10;
            utok = 2;
            obrana = 1;
            zisti_vzdialenost();
            level = 1;
            xp_k_disp = 0;
            vyhra = false;

            atributy[0] = zivot;
            atributy[1] = utok;
            atributy[2] = obrana;

            hpbar = ziv;
            hpbar.Maximum = zivot;

            box_vlavo = kvz;
            box_vpravo = kdo;
            box_elixir = pot;
            box_mec = me;

            boxy_akcii = new PictureBox[4] { box_vlavo, box_vpravo, box_elixir, box_mec };

            ujma = au;
            ukaz_hp = uky;
            nahodne = new Random();

        }

        public void zisti_vzdialenost()
        {
            vzdialenost = telo.Location.X - nepriatel.telo.Location.X + telo.Width;
            if (vzdialenost < 0) vzdialenost = -vzdialenost;
            nepriatel.vzdialenost = vzdialenost;
        }

        internal int[] xp = new int[] { 2, 2, 3, 3, 3 };
        internal int[] atributy = new int[3];

        internal int akt_sila_utoku;
        
        //metody

        public int lvl_xp_sucet(int l)
        {
            int pom = 0;
            for (int i = 0; i < l; i++)
            {
                if (i < xp.Length) pom += xp[i];
                else pom += xp[xp.Length % i];
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



        public void nastav_nepriatela(Postava nepritel)
        {
            nepriatel = nepritel;
            vzdialenost = nepritel.telo.Location.X - telo.Location.X;
        }

        public void sila_utoku()
        {
            int a = nahodne.Next(0, 2);
            if (a == 1) a = -1;
            else a = 1;
            akt_sila_utoku = utok + a * nahodne.Next(0, utok / 2);
        }

        public void utoc()
        {
            if (akt_sila_utoku > 0) nepriatel.zivot = nepriatel.zivot - akt_sila_utoku;
            if (nepriatel.zivot > 0) nepriatel.hpbar.Value = nepriatel.zivot;
            else nepriatel.hpbar.Value = 0;
        }

        public void bran_sa()
        {
            nepriatel.akt_sila_utoku -= (nahodne.Next(0, 51) / 40) * obrana;
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
            hpbar.Visible = true;
            ukaz_hp.Visible = true;
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
                nepriatel.ukaz_hp.Update();
                vykonane = true;
                animacia_utoku();
                nepriatel.ukaz_hp.Text = nepriatel.hpbar.Value.ToString();
                ukaz_hp.Text = hpbar.Value.ToString();
                ukaz_hp.Update();
                hpbar.Update();
                nepriatel.hpbar.Update();

                zisti_ci_som_vyhral();
            }
            else { animacia_utoku(); vykonane = true; }
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
                vykonane = true;
            }
            else urob_pohyb_neschopnosti();

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
                vykonane = true;
            }
            else urob_pohyb_neschopnosti();
        }

        //vizualna stranka postavy

        public void nastav_poziciu(int x, int y)
        {
            telo.Location = new Point(x, y);
            hpbar.Location = new Point(telo.Location.X, telo.Location.Y - 10);
            ukaz_hp.Location = new Point(hpbar.Location.X - ukaz_hp.Size.Width, hpbar.Location.Y);

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
            ukaz_hp.BringToFront();
            ukaz_hp.Text = hpbar.Value.ToString();
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

        //mechanizmus pre padoucha
        public void zakerna_akcia()
        {
            if (vzdialenost <= 60)
            {
                if (nepriatel.hpbar.Value > hpbar.Value && 2.5 * akt_sila_utoku < nepriatel.hpbar.Value)
                {
                    akcia_krok_dozadu();
                    if (vykonane == false) akcia_utok();
                }
                else akcia_utok();

            }
            else
            {
                if (nepriatel.hpbar.Value > hpbar.Value && 2.5 * akt_sila_utoku < nepriatel.hpbar.Value)
                {
                    akcia_krok_dozadu();
                    if (vykonane == false) akcia_utok();
                }
                else akcia_krok_dopredu();

            }
            if (vykonane == false) akcia_utok();
            
        }

        public void aktualizuj_atributy()
        {
            //zivot = 2 * level + atributy[0] * 2 + 3;
            zivot = 5 + atributy[0] * nahodne.Next(2, 8);
            if (zivot < 7) zivot = 7;
            //utok = atributy[1] % (level + 1) + 1;
            utok = 1 + atributy[1] * nahodne.Next(1, 4);

            akt_sila_utoku = utok;

            obrana = 1 + atributy[2]*nahodne.Next(1,3);

            max_zivot = zivot;
            hpbar.Maximum = zivot;
            hpbar.Value = zivot;
            hpbar.Update();
            ukaz_hp.Text = nepriatel.hpbar.Value.ToString();
            ukaz_hp.Update();
        }

        public void vygeneruj_nepriatela(int lev)
        {
            xp_k_disp = lvl_xp_sucet(lev) - 1;
            for (int i = 0; i < atributy.Length; i++)
            {
                atributy[i] = 0;
            }

            for (int i = 0; i < 3; i++)
            {
                int pom = nahodne.Next(0, xp_k_disp + 1);
                atributy[i] += pom;
                xp_k_disp -= pom;
            }
            aktualizuj_atributy();
            ukaz_hp.Text = hpbar.Maximum.ToString();
            ukaz_hp.Update();
            level = lev;
        }


        public void tah_nepriatela()
        {
            nepriatel.ukaz_hp.Text = nepriatel.hpbar.Value.ToString();
            nepriatel.ukaz_hp.Update();
            nepriatel.zakerna_akcia();
            nepriatel.ukaz_hp.Text = nepriatel.hpbar.Value.ToString();
            nepriatel.ukaz_hp.Update();
        }

        public virtual void animacia_utoku()
        {

            for (int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(10);

                telo.Location = new Point(telo.Location.X + 1, telo.Location.Y);
                telo.Update();

            }
            System.Threading.Thread.Sleep(10);
            for (int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(10);
                telo.Location = new Point(telo.Location.X - 1, telo.Location.Y);
                telo.Update();
            }
            odmizni_akcie();
            hpbar.Visible = true;
            ukaz_hp.Visible = true;

        }
    }
}
