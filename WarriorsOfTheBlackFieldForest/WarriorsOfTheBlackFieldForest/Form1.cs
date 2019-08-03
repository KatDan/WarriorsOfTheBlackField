using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarriorsOfTheBlackFieldForest
{
    public partial class Form1 : Form
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
            internal int i;
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
                if(akt_sila_utoku > 0) nepriatel.zivot = nepriatel.zivot - akt_sila_utoku;
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
                    telo.Location = new Point(telo.Location.X, telo.Location.Y+1);
                    telo.Update();
                }
                System.Threading.Thread.Sleep(10);
                for (int i = 0; i < 10; i++)
                {
                    
                    System.Threading.Thread.Sleep(10);
                    telo.Location = new Point(telo.Location.X, telo.Location.Y-1);
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

                for (int i = 0; i < 20; i++){
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

            //pridaj timer simulujuci pohyb postavy

        }

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

            public Hrdina(PictureBox kvz, PictureBox kdo, PictureBox me, PictureBox pot, ProgressBar ziv, Label au, Label uky, Timer krok_vpred, Timer krok_vzad, Timer vypad)
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

                ujma = au;
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

        public class Padouch : Postava
        {
            public Padouch(Hrdina hrdina, ProgressBar ziv, Label jau, Label uky, Timer krok_vpred, Timer krok_vzad, Timer utocny_krok)
            {
                //nastavi vhodnu obtiaznost
                rnd = new Random();
                hpbar = ziv;
                vygeneruj_bubaka(hrdina.level);
                //hpbar.Maximum = hrdina.level * 10;
                hpbar.Value = hpbar.Maximum;
                ujma = jau;
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

        public class Level
        {
            internal PictureBox pozadie;
            internal Hrdina hrdina;
            internal Padouch padouch;
            internal int obtiaznost;
            internal PictureBox nazov_levelu;
            internal Random rnd;

            public Level(int uroven, Hrdina hhrdina, Padouch padouch, PictureBox pozadiee, PictureBox nazov)
            {
                obtiaznost = uroven;
                this.hrdina = hhrdina;
                this.pozadie = pozadiee;
                nazov_levelu = nazov;
                rnd = new Random();
                //nepriatel
                this.padouch = padouch;
                padouch.vygeneruj_bubaka(uroven);
            }

            public void nastav_nazov(int i)
            {
                switch (i)
                {
                    case 1: nazov_levelu.Image = Image.FromFile(@"level1.png"); break;
                    case 2: nazov_levelu.Image = Image.FromFile(@"level2.png"); break;
                    case 3: nazov_levelu.Image = Image.FromFile(@"level3.png"); break;
                    case 4: nazov_levelu.Image = Image.FromFile(@"level4.png"); break;
                    case 5: nazov_levelu.Image = Image.FromFile(@"level5.png"); break;
                }
                nazov_levelu.Visible = true;
                nazov_levelu.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            public void vygeneruj_pozadie()
            {
                switch (rnd.Next(1, 10))
                {
                    case 1: pozadie.Image = Image.FromFile(@"gif1.gif"); break;
                    case 2: pozadie.Image = Image.FromFile(@"gif2.gif"); break;
                    case 3: pozadie.Image = Image.FromFile(@"gif3.gif"); break;
                    case 4: pozadie.Image = Image.FromFile(@"gif4.gif"); break;
                    case 5: pozadie.Image = Image.FromFile(@"gif5.gif"); break;
                    case 6: pozadie.Image = Image.FromFile(@"pozadie1.jpg"); break;
                    case 7: pozadie.Image = Image.FromFile(@"pozadie2.jpg"); break;
                    case 8: pozadie.Image = Image.FromFile(@"pozadie3.jpg"); break;
                    case 9: pozadie.Image = Image.FromFile(@"pozadie4.jpg"); break;
                }

                pozadie.SizeMode = PictureBoxSizeMode.StretchImage;
                pozadie.SendToBack();
            }

            public void zrob_novy_level()
            {
                vygeneruj_pozadie();
                hrdina.odmizni_akcie();
                nastav_nazov(hrdina.level);
                padouch.vygeneruj_bubaka(hrdina.level);
                hrdina.nastav_vychodziu_poziciu();
                padouch.nastav_vychodziu_poziciu();
                padouch.vygeneruj_telo();
                hrdina.ukaz_sa();
                padouch.ukaz_sa();
                //hrdina.zmizni_akcie();
                hrdina.nepriatel = padouch;
                hrdina.zisti_vzdialenost();
                hrdina.hpbar.Value = hrdina.hpbar.Maximum;
                hrdina.show_hp.Text = hrdina.max_zivot.ToString();
                padouch.hpbar.Maximum = padouch.max_zivot;

                padouch.hpbar.Value = padouch.max_zivot;
                padouch.vyhra = false;
                hrdina.vyhra = false;
            }
        }

        public class Main_menu
        {
            internal PictureBox nazov;
            internal Button nova_hra;
            internal Button skore;
            internal Button credits;
            internal PictureBox pozadicko;

            public Main_menu(PictureBox nazovv, Button nova_hra, Button skore, Button credits, PictureBox pozadicko)
            {
                nazov = nazovv;
                this.nova_hra = nova_hra;
                this.skore = skore;
                this.credits = credits;
                this.pozadicko = pozadicko;
            }

            public void Zmizni_menu()
            {
                nazov.Visible = false;
                nova_hra.Visible = false;
                skore.Visible = false;
                //pozadicko.Visible = false;
                credits.Visible = false;
            }
        }

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

            public LevelUp(Label xp, Button o1, Button o2, Button o3, Button o4, Hrdina geroj, Label s1, Label s2, Label s3, Label s4, PictureBox pozadicko, PictureBox text)
            {
                obtiaznost = 0;
                xp_left = xp;
                option1 = o1;
                option2 = o2;
                option3 = o3;
                option4 = o4;
                hrdina = geroj;
                stat1 = s1;
                stat2 = s2;
                stat3 = s3;
                stat4 = s4;
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

        public Form1()
        {

            sp = new System.Media.SoundPlayer(@"kitkatbeznikolka.wav");
            sp.PlayLooping();
            

            hudba = new Button
            {
                Size = new Size(120, 40),
                Location = new Point(30, 30),
                Text = "Music : On",
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(hudba);
            hudba.Click += new EventHandler(hudba_Click);

            how_to_play = new Label
            {
                Size = new Size(900, 300),
                Location = new Point(50, 350),
                Text = "HOW TO PLAY:\n" +
                "==================\n" +
                "You went camping to the Black Field forest with your friends and while you were on a walk, they ate all Horalky you had. Naturally, you got really angry.\n" +
                "Your task is to defeat 5 of your 'friends'. Each turn you have 4 options:\n" +
                "# move forwards\n" +
                "# move backwards\n" +
                "# drink a magical potion - A shot of borovička restores you 5HP. At start, you have 0 shots of borovička.\n" +
                "# stab - when you are close enough to your opponent, you can stab him. Damage dealt depends on your attack stats and your opponent's defense stats.\n" +
                "       - if you are not close enough, you just stab air for practice.\n" +
                "\n" +
                "Good luck, warrior!\n",
                Font = new System.Drawing.Font("Comic Sans", 10F),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(2,2,2,2)
            };
            how_to_play.Visible = false;
            Controls.Add(how_to_play);

            //timery
            {
                i = 0;
                hrdina_timer_krok_vpred = new Timer();
                hrdina_timer_krok_vpred.Interval = 10;
                hrdina_timer_krok_vpred.Tick += new EventHandler(hrdina_timer_krok_vpred_Tick);
                //Controls.Add(hrdina_timer_krok_vpred);

                hrdina_timer_krok_vzad = new Timer();
                hrdina_timer_krok_vzad.Interval = 10;
                hrdina_timer_krok_vzad.Tick += new EventHandler(hrdina_timer_krok_vzad_Tick);

                padouch_timer_krok_vpred = new Timer();
                padouch_timer_krok_vpred.Interval = 40;
                padouch_timer_krok_vpred.Tick += new EventHandler(padouch_timer_krok_vpred_Tick);

                padouch_timer_krok_vzad = new Timer();
                padouch_timer_krok_vzad.Interval = 40;
                padouch_timer_krok_vzad.Tick += new EventHandler(padouch_timer_krok_vzad_Tick);

                dopredny_utok = new Timer();
                dopredny_utok.Interval = 1;
                dopredny_utok.Tick += new EventHandler(dopredny_utok_Tick);

                spatny_utok = new Timer();
                spatny_utok.Interval = 1;
                spatny_utok.Tick += new EventHandler(spatny_utok_Tick);
            }

            //ikony akcii
            {
                Image obrazok_akcie_utok = Image.FromFile(@"mec.png");
                Image obrazok_akcie_napi_sa = Properties.Resources.potion;
                Image obrazok_akcie_krok_dozadu = Properties.Resources.sipka_vlavo;
                Image obrazok_akcie_krok_dopredu = Properties.Resources.sipka_vpravo;
            }

            //hrdina

            //boxy
            {
                box_krokvpred = new PictureBox
                {
                    Size = new Size(50, 50),
                    Image = Image.FromFile(@"sipka_vpravo.png"),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(0, 0)
                };
                Controls.Add(box_krokvpred);
                box_krokvpred.Click += new EventHandler(this.box_krokvpred_Click);
                box_krokvpred.SendToBack();

                box_krokvzad = new PictureBox
                {
                    Size = new Size(50, 50),
                    Image = Image.FromFile(@"sipka_vlavo.png"),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(0, 0)
                };
                Controls.Add(box_krokvzad);
                box_krokvzad.Click += new EventHandler(this.box_krokvzad_Click);
                box_krokvzad.SendToBack();

                box_mec = new PictureBox
                {
                    Size = new Size(50, 50),
                    Image = Image.FromFile(@"mec.png"),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(0, 0)
                };
                Controls.Add(box_mec);
                box_mec.Click += new EventHandler(this.box_mec_Click);
                box_mec.SendToBack();

                box_pitie = new PictureBox
                {
                    Size = new Size(50, 50),
                    Image = Image.FromFile(@"potion.png"),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(0, 0)
                };
                Controls.Add(box_pitie);
                box_pitie.Click += new EventHandler(this.box_pitie_Click);
                box_pitie.SendToBack();
            }

            hp_hrdina = new ProgressBar
            {
                Size = new Size(80, 20),
                Location = new Point(0, 0),
                Minimum = 0,
                Maximum = 10
            };
            Controls.Add(hp_hrdina);

            show_hp_hrdina = new Label
            {
                Size = new Size(2 * hp_hrdina.Size.Height, hp_hrdina.Size.Height),
                Location = new Point(hp_hrdina.Location.X - Size.Height, hp_hrdina.Location.Y),
                Text = hp_hrdina.Value.ToString(),
                Parent = hp_hrdina,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };
            Controls.Add(show_hp_hrdina);

            hp_padouch = new ProgressBar
            {
                Size = new Size(80, 20),
                Location = new Point(0, 0),
                Minimum = 0,
                Maximum = 10
            };
            Controls.Add(hp_padouch);

            show_hp_padouch = new Label
            {
                Size = new Size(2 * hp_padouch.Size.Height, hp_padouch.Size.Height),
                Location = new Point(hp_padouch.Location.X - Size.Height, hp_padouch.Location.Y),
                Text = hp_padouch.Value.ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Parent = hp_padouch,
                BackColor = Color.Transparent,
            };
            Controls.Add(show_hp_padouch);

            hrdina = new Hrdina(box_krokvzad, box_krokvpred, box_mec, box_pitie, hp_hrdina, ujma_hrdina, show_hp_hrdina,hrdina_timer_krok_vpred,hrdina_timer_krok_vzad,dopredny_utok);
            hrdina.telo = new PictureBox
            {
                Parent = pozadie,
                Size = new Size(160, 185),
                Location = new Point(240, 450),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Image.FromFile(@"ja-removebg.png"),
                BackColor = Color.Transparent
            };
            Controls.Add(hrdina.telo);

            //padouch
            padouch = new Padouch(hrdina, hp_padouch, ujma_padouch, show_hp_padouch,padouch_timer_krok_vpred,padouch_timer_krok_vzad,spatny_utok);
            padouch.telo = new PictureBox
            {
                Parent = pozadie,
                Size = new Size(160, 185),
                Location = new Point(600, 450),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Image.FromFile(@"bubak1-removebg.png"),
                //Image = padouchovo_telo,

                BackColor = Color.Transparent
            };
            Controls.Add(padouch.telo);
            padouch.telo.BringToFront();

            padouch.nepriatel = hrdina;
            hrdina.nepriatel = padouch;

            hrdina.vzdialenost = hrdina.telo.Location.X - hrdina.nepriatel.telo.Location.X + hrdina.telo.Width;
            if (hrdina.vzdialenost < 0) hrdina.vzdialenost = -hrdina.vzdialenost;
            padouch.vzdialenost = hrdina.vzdialenost;

            //uvodne menu
            {
                Napis_nad_levelom = new PictureBox
                {
                    Parent = pozadie,
                    Size = new Size(320, 180),
                    Location = new Point(340, 45),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(@"image.png"),
                    BackColor = Color.Transparent
                };
                Controls.Add(Napis_nad_levelom);

                button_NovaHra = new Button
                {

                    Size = new Size(300, 60),
                    Location = new Point(350, 268),
                    Text = "New Game",
                    Font = new System.Drawing.Font("Carta Magna Line", 16F)

                };
                Controls.Add(button_NovaHra);
                button_NovaHra.Click += new EventHandler(this.button_NovaHra_Click);

                button_How_to_play = new Button
                {
                    Size = new Size(300, 60),
                    Location = new Point(350, 341),
                    Text = "How to play",
                    Font = new System.Drawing.Font("Carta Magna Line", 16F)
                };
                Controls.Add(button_How_to_play);
                button_How_to_play.Click += new EventHandler(this.button_How_to_play_Click);
                //button_VysokeSkore.Click += new EventHandler(this.button_VysokeSkore_Click);

                button_Credits = new Button
                {
                    Size = new Size(300, 60),
                    Location = new Point(350, 414),
                    Text = "Credits",
                    Font = new System.Drawing.Font("Carta Magna Line", 16F)
                };
                Controls.Add(button_Credits);
                button_Credits.Click += new EventHandler(this.button_kredity_Click);

                pozadie_menu = new PictureBox
                {
                    Size = new Size(1000, 700),

                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(@"gif1.gif"),
                    Location = new Point(0, 0),
                };

                pozadie = pozadie_menu;

                Controls.Add(pozadie_menu);
            }
            menu = new Main_menu(this.Napis_nad_levelom, this.button_NovaHra, this.button_How_to_play, this.button_Credits, this.pozadie_menu);

            level = new Level(1, hrdina, padouch, pozadie, Napis_nad_levelom);

            padouch.telo.Parent = pozadie;
            Napis_nad_levelom.Parent = pozadie;
            hrdina.telo.Parent = pozadie;

            box_krokvzad.SendToBack();
            box_krokvpred.SendToBack();
            box_mec.SendToBack();
            box_pitie.SendToBack();
            hp_hrdina.SendToBack();
            hp_padouch.SendToBack();

            //levelup
            Smrtys = new PictureBox
            {
                Parent = pozadie,
                Size = new Size(320, 180),
                Location = new Point(340, 45),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Image.FromFile(@"image.png"),
                BackColor = Color.Transparent
            };
            Controls.Add(Smrtys);
            Smrtys.Visible = false;

            xp_left = new Label
            {
                Size = new Size(140, 100),
                Location = new Point(800, 230),
                Parent = pozadie,
                Text = "Each upgrade costs 1 xp:\n__ xp left",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12),
            };
            Controls.Add(xp_left);

            option_1 = new Button
            {
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "+1 Potion (+5 HP)",
                Size = new Size(140, 40),
                Location = new Point(800, 370)
            };
            Controls.Add(option_1);
            option_1.Click += new EventHandler(this.option_1_Click);

            option_2 = new Button
            {
                Text = "+3 attack",
                Size = new Size(140, 40),
                Location = new Point(800, 420)
            };
            Controls.Add(option_2);
            option_2.Click += new EventHandler(this.option_2_Click);

            option_3 = new Button
            {
                Text = "+7 HP",
                Size = new Size(140, 40),
                Location = new Point(800, 470)
            };
            Controls.Add(option_3);
            option_3.Click += new EventHandler(this.option_3_Click);

            option_4 = new Button
            {
                Text = "+2 defense",
                Size = new Size(140, 40),
                Location = new Point(800, 520)
            };
            Controls.Add(option_4);
            option_4.Click += new EventHandler(this.option_4_Click);

            stat_1 = new Label
            {
                Size = new Size(150, 50),
                Location = new Point(500, 370),
                Text = "  Potions :               __",
                TextAlign = ContentAlignment.MiddleLeft
            };
            Controls.Add(stat_1);

            stat_2 = new Label
            {
                Size = new Size(150, 50),
                Location = new Point(500, 420),
                Text = "  ATTACK :             __",
                TextAlign = ContentAlignment.MiddleLeft
            };
            Controls.Add(stat_2);

            stat_3 = new Label
            {
                Size = new Size(150, 50),
                Location = new Point(500, 470),
                Text = "  HP :                      __",
                TextAlign = ContentAlignment.MiddleLeft
            };
            Controls.Add(stat_3);

            stat_4 = new Label
            {
                Size = new Size(150, 50),
                Location = new Point(500, 520),
                Text = "  DEFENSE :          __",
                TextAlign = ContentAlignment.MiddleLeft
            };
            Controls.Add(stat_4);

            levelup = new LevelUp(xp_left, option_1, option_2, option_3, option_4, hrdina, stat_1, stat_2, stat_3, stat_4, pozadie, Napis_nad_levelom);
            levelup.zmizni();

            levelup.text_levelup.Parent = levelup.pozadie;

            konfety = new PictureBox
            {
                Size = new Size(1000, 700),
                Image = Image.FromFile(@"konfety.gif"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Parent = pozadie
            };
            konfety.SendToBack();
            konfety.Visible = false;

            rnd = new Random();

            InitializeComponent();
        }

        internal Timer hrdina_timer_krok_vpred;
        internal Timer hrdina_timer_krok_vzad;
        internal Timer padouch_timer_krok_vpred;
        internal Timer padouch_timer_krok_vzad;
        internal Timer dopredny_utok;
        internal Timer spatny_utok;
        internal Button hudba;

        internal int i;

        //deklaracie
        internal Hrdina hrdina;
        internal ProgressBar hp_hrdina;
        internal Label ujma_hrdina;
        internal PictureBox box_krokvpred;
        internal PictureBox box_krokvzad;
        internal PictureBox box_mec;
        internal PictureBox box_pitie;
        internal Label show_hp_hrdina;
        internal Random rnd;
        internal System.Media.SoundPlayer sp;

        internal Padouch padouch;
        internal ProgressBar hp_padouch;
        internal Label ujma_padouch;
        internal Label show_hp_padouch;

        internal Main_menu menu;
        internal Level level;
        internal PictureBox pozadie;
        internal PictureBox Napis_nad_levelom;
        internal PictureBox Smrtys;
        internal PictureBox konfety;

        internal LevelUp levelup;
        internal Label xp_left;
        internal Button option_1;
        internal Button option_2;
        internal Button option_3;
        internal Button option_4;
        internal Label stat_1;
        internal Label stat_2;
        internal Label stat_3;
        internal Label stat_4;
        internal Label how_to_play;       

        private void button_kredity_Click(object sender, EventArgs e)
        {

            button_NovaHra.Visible = false;
            button_How_to_play.Visible = false;
            button_Credits.Visible = false;
            titulky.Visible = true;
            titulky.BringToFront();
        }

        private void Nazov_hry_Click(object sender, EventArgs e)
        {
            pozadie_menu.BringToFront();
            button_NovaHra.BringToFront();
            button_NovaHra.Visible = true;
            button_How_to_play.BringToFront();
            button_How_to_play.Visible = true;
            button_Credits.BringToFront();
            button_Credits.Visible = true;
            Napis_nad_levelom.BringToFront();
        }

        private void button_How_to_play_Click(object sender, EventArgs e)
        {
            button_How_to_play.Visible = false;
            button_Credits.Visible = false;
            how_to_play.Visible = true;
            titulky.Visible = false;
        }

        private void button_NovaHra_Click(object sender, EventArgs e)
        {
            how_to_play.Visible = false;
            titulky.Visible = false;
            menu.Zmizni_menu();
            level.nastav_nazov(1);
            level.vygeneruj_pozadie();
            level.hrdina.nastav_vychodziu_poziciu();
            level.padouch.nastav_vychodziu_poziciu();
            level.hrdina.zisti_vzdialenost();
            level.hrdina.odmizni_akcie();
            level.hrdina.vytvor_zakladneho_hrdinu();
            level.padouch.vygeneruj_bubaka(1);
            level.padouch.vygeneruj_telo();
            level.padouch.hpbar.Value = level.padouch.hpbar.Maximum;
            button_NovaHra.Visible = false;
            level.padouch.vyhra = false;
        }

        private void box_krokvpred_Click(object sender, EventArgs e)
        {
            hrdina.akcia_krok_dopredu();
            while (hrdina.prebieha)
            {
                hrdina.odmizni_akcie();
            }
        }

        private void box_krokvzad_Click(object sender, EventArgs e)
        {
            hrdina.akcia_krok_dozadu();
            while (hrdina.prebieha)
            {
                hrdina.odmizni_akcie();
            }
        }

        private void box_mec_Click(object sender, EventArgs e)
        {
            //spatny_utok.Start();
            hrdina.akcia_utok();

            hrdina.hpbar.Update();
            hrdina.show_hp.Update();
            
            if (hrdina.vyhra == true) { if (hrdina.level > 5) vyhral_si(); else { Console.WriteLine(hrdina.level); hrdina.zmizni_akcie(); levelup.ukaz_sa(); updateni_level_up(hrdina.level); } }
            else rozhyb_padoucha();
        }

        private void box_pitie_Click(object sender, EventArgs e)
        {
            if (hrdina.pocet_potionov > 0)
            {
                hrdina.pocet_potionov -= 1;
                hrdina.zivot += 5;
                if (hrdina.zivot <= hrdina.max_zivot) hrdina.hpbar.Value += 5;
                else hrdina.hpbar.Value = hrdina.hpbar.Maximum;
            }
            else hrdina.urob_pohyb_neschopnosti();
            rozhyb_padoucha();
        }

        private void option_1_Click(object sender, EventArgs e)
        {
            if (levelup.xp_now > 0)
            {
                levelup.xp_now -= 1;
                levelup.hrdina.pocet_potionov += 1;
                levelup.updateni_veci();
            }
            if (levelup.xp_now == 0)
            {
                levelup.zmizni();
                level.nastav_nazov(hrdina.level);
                level.zrob_novy_level();
            }
        }

        private void option_2_Click(object sender, EventArgs e)
        {
            if (levelup.xp_now > 0)
            {
                levelup.xp_now -= 1;
                levelup.hrdina.utok += 3;
                levelup.updateni_veci();
            }
            if (levelup.xp_now == 0)
            {
                levelup.zmizni();
                level.zrob_novy_level();
            }
        }

        private void option_3_Click(object sender, EventArgs e)
        {
            if (levelup.xp_now > 0)
            {
                levelup.xp_now -= 1;
                levelup.hrdina.max_zivot += 7;
                levelup.hrdina.hpbar.Maximum = levelup.hrdina.max_zivot;
                levelup.updateni_veci();
            }
            if (levelup.xp_now == 0)
            {
                levelup.zmizni();
                level.zrob_novy_level();
            }
        }

        private void option_4_Click(object sender, EventArgs e)
        {
            if (levelup.xp_now > 0)
            {
                levelup.xp_now -= 1;
                levelup.hrdina.obrana += 2;
                levelup.updateni_veci();
            }
            if (levelup.xp_now == 0)
            {
                levelup.zmizni();
                level.zrob_novy_level();
            }
        }

        private void rozhyb_padoucha()
        {
            if (hrdina.vyhra == true)
            {
                if (hrdina.level < 5) levelup.ukaz_sa();
                else vyhral_si();
            }
            else
            {
                hrdina.tah_padoucha();
                padouch.show_hp.Text = padouch.hpbar.Value.ToString();
                padouch.show_hp.Update();
                if (padouch.vyhra == true)
                {
                    game_over();
                }
            }
        }

        private void vyhral_si()
        {
            hrdina.nepriatel.telo.Visible = false;
            hrdina.nepriatel.hpbar.Visible = false;
            hrdina.nepriatel.show_hp.Visible = false;
            konfety.BringToFront();
            konfety.Visible = true;
            hrdina.zmizni_akcie();
            hrdina.hpbar.Visible = false;
            hrdina.show_hp.Visible = false;
            hrdina.telo.BringToFront();
            Napis_nad_levelom.BringToFront();
            Napis_nad_levelom.Image = Image.FromFile(@"vyhrys.png");
        }

        private void game_over()
        {
            Napis_nad_levelom.Visible = true;
            Napis_nad_levelom.Image = Image.FromFile(@"smrt.png");
            button_NovaHra.Visible = true;
            Napis_nad_levelom.Parent = pozadie;
            Napis_nad_levelom.BackColor = Color.Transparent;
            hrdina.zmizni_akcie();
            hrdina.vytvor_zakladneho_hrdinu();
            hrdina.level = 1;
            padouch.vygeneruj_bubaka(1);
            padouch.vygeneruj_telo();
            hrdina.pocet_potionov = 0;
            button_NovaHra.BringToFront();

        }

        private void updateni_level_up(int obtiaznost)
        {
            levelup.updateni_veci();
            levelup.xp_now = hrdina.xp[obtiaznost - 1];
            levelup.xp_left.Text = levelup.xp_now.ToString();
            levelup.updateni_veci();
        }

        private void padouch_timer_krok_vpred_Tick(object sender, EventArgs e)
        {
            if (padouch.telo.Location.X > padouch.ciel_poz_x)
            {
                padouch.prebieha = true;
                padouch.nastav_poziciu(padouch.telo.Location.X - 1, padouch.telo.Location.Y);
                hrdina.zmizni_akcie();
            }
            else
            {   
                hrdina.odmizni_akcie();
                padouch.prebieha = false;
                padouch_timer_krok_vpred.Stop();
            }
        }

        private void padouch_timer_krok_vzad_Tick(object sender, EventArgs e)
        {
            if (padouch.telo.Location.X < padouch.ciel_poz_x)
            {
                padouch.prebieha = true;
                padouch.nastav_poziciu(padouch.telo.Location.X + 1, padouch.telo.Location.Y);
                hrdina.zmizni_akcie();
            }
            else
            {
                
                hrdina.odmizni_akcie();
                padouch.prebieha = false;
                padouch_timer_krok_vzad.Stop();
            }
        }

        private void hrdina_timer_krok_vpred_Tick(object sender, EventArgs e)
        {
            hrdina.prebieha = true;
            if (hrdina.telo.Location.X < hrdina.ciel_poz_x)
            {
                hrdina.prebieha = true;
                hrdina.zmizni_akcie();
                hrdina.nastav_poziciu(hrdina.telo.Location.X + 1, hrdina.telo.Location.Y);
            }
            else
            {
                hrdina.odmizni_akcie();
                hrdina.vykonane = true;
                hrdina.prebieha = false;

                if (hrdina.vykonane) rozhyb_padoucha();
                else hrdina.urob_pohyb_neschopnosti();
                hrdina_timer_krok_vpred.Stop();
            }
        }

        private void hrdina_timer_krok_vzad_Tick(object sender, EventArgs e)
        {
            hrdina.prebieha = true;
            if (hrdina.telo.Location.X > hrdina.ciel_poz_x)
            {
                hrdina.prebieha = true;
                hrdina.zmizni_akcie();
                hrdina.nastav_poziciu(hrdina.telo.Location.X - 1, hrdina.telo.Location.Y);
            }
            else
            {
                hrdina.odmizni_akcie();
                hrdina.vykonane = true;
                hrdina.prebieha = false;

                if (hrdina.vykonane) rozhyb_padoucha();
                else hrdina.urob_pohyb_neschopnosti();
                hrdina_timer_krok_vzad.Stop();
                hrdina_timer_krok_vzad.Enabled = false;
            }
        }

        private void dopredny_utok_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("tik");
            if (hrdina.telo.Location.X < hrdina.ciel_poz_x)
            {
                //Console.WriteLine("utok");
                hrdina.prebieha = true;
                hrdina.telo.Location = new Point(hrdina.telo.Location.X + 1, hrdina.telo.Location.Y);
            }
            else
            {
                hrdina.vykonane = true;
                hrdina.prebieha = false;
                System.Threading.Thread.Sleep(15 * hrdina.utok_pohyb.Interval);
                hrdina.ciel_poz_x = hrdina.telo.Location.X - 10;
                hrdina.krok_vzad_t.Start();
                hrdina.krok_vpred_t.Interval = 10;
                hrdina.krok_vzad_t.Interval = 10;
                dopredny_utok.Stop();
            }
        }

        private void spatny_utok_Tick(object sender, EventArgs e)
        {
            hrdina.show_hp.Visible = false;
            hrdina.hpbar.Visible = false;
            hrdina.zmizni_akcie();
        }

        private void hudba_Click(object sender, EventArgs e)
        {
            if(hudba.Text == "Music : On")
            {
                sp.Stop();
                hudba.Text = "Music : Off";
            }
            else
            {
                sp.PlayLooping();
                hudba.Text = "Music : On";
            }
        }
    }
}


