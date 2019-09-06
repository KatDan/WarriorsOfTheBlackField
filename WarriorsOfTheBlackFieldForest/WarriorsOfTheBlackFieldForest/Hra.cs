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
    public partial class Hra : Form
    {
        public struct Boxy
        {
            internal PictureBox[] boxy;
            
            public Boxy(PictureBox b1, PictureBox b2, PictureBox b3, PictureBox b4)
            {
                boxy = new PictureBox[] { b1, b2, b3, b4 };
            }
        }

        public struct TimerKrok
        {
            internal Timer[] timery;
            

            public TimerKrok(Timer t1, Timer t2, Timer t3)
            {
                timery = new Timer[] { t1, t2, t3 };
            }
        }

        public struct Zivot
        {
            internal Label ukaz;
            internal ProgressBar bar;

            public Zivot(Label l, ProgressBar p)
            {
                ukaz = l;
                bar = p;
            }
        }

        public struct Moznosti


        {
            internal Button[] tlacitka;
            public Moznosti(Button b1, Button b2, Button b3, Button b4)
            {
                tlacitka = new Button[] { b1, b2, b3, b4 };

            }
        }

        public struct Atributy
        {
            internal Label[] atributy;
            public Atributy(Label s1, Label s2, Label s3, Label s4)
            {
                atributy = new Label[] { s1, s2, s3, s4 };
            }
        }

        public Hra()
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

            text_ku_how_to_play = new Label
            {
                Size = new Size(900, 300),
                Location = new Point(50, 250),
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
            text_ku_how_to_play.Visible = false;
            Controls.Add(text_ku_how_to_play);

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
            krok_hrdina = new TimerKrok(hrdina_timer_krok_vpred, hrdina_timer_krok_vzad, dopredny_utok);
            krok_padouch = new TimerKrok(padouch_timer_krok_vpred, padouch_timer_krok_vzad, spatny_utok);

            //boxy
            {
                box_krokvpred = new PictureBox
                {
                    Size = new Size(50, 50),
                    Image = Properties.Resources.sipka_vpravo,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(0, 0)
                };
                Controls.Add(box_krokvpred);
                box_krokvpred.Click += new EventHandler(this.box_krokvpred_Click);
                box_krokvpred.SendToBack();

                box_krokvzad = new PictureBox
                {
                    Size = new Size(50, 50),
                    Image = Properties.Resources.sipka_vlavo,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(0, 0)
                };
                Controls.Add(box_krokvzad);
                box_krokvzad.Click += new EventHandler(this.box_krokvzad_Click);
                box_krokvzad.SendToBack();

                box_mec = new PictureBox
                {
                    Size = new Size(50, 50),
                    Image = Properties.Resources.mec,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(0, 0)
                };
                Controls.Add(box_mec);
                box_mec.Click += new EventHandler(this.box_mec_Click);
                box_mec.SendToBack();

                box_pitie = new PictureBox
                {
                    Size = new Size(50, 50),
                    Image = Properties.Resources.potion,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(0, 0)
                };
                Controls.Add(box_pitie);
                box_pitie.Click += new EventHandler(this.box_pitie_Click);
                box_pitie.SendToBack();
            }
            boxy_akcii = new Boxy(box_krokvzad, box_krokvpred, box_pitie, box_mec);

            //zivoty
            {
                hp_hrdina = new ProgressBar
                {
                    Size = new Size(80, 20),
                    Location = new Point(0, 0),
                    Minimum = 0,
                    Maximum = 10
                };
                Controls.Add(hp_hrdina);

                ukaz_hp_hrdina = new Label
                {
                    Size = new Size(2 * hp_hrdina.Size.Height, hp_hrdina.Size.Height),
                    Location = new Point(hp_hrdina.Location.X - Size.Height, hp_hrdina.Location.Y),
                    Text = hp_hrdina.Value.ToString(),
                    Parent = hp_hrdina,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent
                };
                Controls.Add(ukaz_hp_hrdina);

                hp_padouch = new ProgressBar
                {
                    Size = new Size(80, 20),
                    Location = new Point(0, 0),
                    Minimum = 0,
                    Maximum = 10
                };
                Controls.Add(hp_padouch);

                ukaz_hp_padouch = new Label
                {
                    Size = new Size(2 * hp_padouch.Size.Height, hp_padouch.Size.Height),
                    Location = new Point(hp_padouch.Location.X - Size.Height, hp_padouch.Location.Y),
                    Text = hp_padouch.Value.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Parent = hp_padouch,
                    BackColor = Color.Transparent,
                };
                Controls.Add(ukaz_hp_padouch);

                hrdina_zivot = new Zivot(ukaz_hp_hrdina, hp_hrdina);
                padouch_zivot = new Zivot(ukaz_hp_padouch, hp_padouch);
            }

            //hrdina
            hrdina = new Hrdina(boxy_akcii, hrdina_zivot, krok_hrdina);

            hrdina.telo = new PictureBox
            {
                Parent = pozadie,
                Size = new Size(160, 185),
                Location = new Point(240, 450),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Properties.Resources.ja_removebg,
                BackColor = Color.Transparent
            };
            Controls.Add(hrdina.telo);

            //padouch
            padouch = new Padouch(hrdina, padouch_zivot, krok_padouch);

            padouch.telo = new PictureBox
            {
                Parent = pozadie,
                Size = new Size(160, 185),
                Location = new Point(600, 450),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Properties.Resources.bubak1_removebg,
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
                napis_nad_levelom = new PictureBox
                {
                    Parent = pozadie,
                    Size = new Size(320, 180),
                    Location = new Point(340, 45),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Properties.Resources.image,
                    BackColor = Color.Transparent
                };
                Controls.Add(napis_nad_levelom);

                tlacitko_new_game = new Button
                {

                    Size = new Size(300, 60),
                    Location = new Point(350, 268),
                    Text = "New Game",
                    Font = new System.Drawing.Font("Carta Magna Line", 16F)

                };
                Controls.Add(tlacitko_new_game);
                tlacitko_new_game.Click += new EventHandler(this.tlacitko_nova_hra_Click);

                tlacitko_how_to_play = new Button
                {
                    Size = new Size(300, 60),
                    Location = new Point(350, 341),
                    Text = "How to play",
                    Font = new System.Drawing.Font("Carta Magna Line", 16F)
                };
                Controls.Add(tlacitko_how_to_play);
                tlacitko_how_to_play.Click += new EventHandler(this.tlacitko_how_to_play_Click);
                //button_VysokeSkore.Click += new EventHandler(this.button_VysokeSkore_Click);

                tlacitko_kredity = new Button
                {
                    Size = new Size(300, 60),
                    Location = new Point(350, 414),
                    Text = "Credits",
                    Font = new System.Drawing.Font("Carta Magna Line", 16F)
                };
                Controls.Add(tlacitko_kredity);
                tlacitko_kredity.Click += new EventHandler(this.tlacitko_kredity_Click);

                pozadie_menu = new PictureBox
                {
                    Size = new Size(1000, 700),

                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Properties.Resources.gif1,
                    Location = new Point(0, 0),
                };

                pozadie = pozadie_menu;
                Controls.Add(pozadie_menu);


                x_how_to_play = new Button
                {
                    Text = "X",
                    Visible = false,
                    Size = new Size(40,40),
                    Location = new Point(text_ku_how_to_play.Location.X + text_ku_how_to_play.Width - 40,text_ku_how_to_play.Location.Y),
                };
                Controls.Add(x_how_to_play);
                x_how_to_play.Click += new EventHandler(x_how_to_play_click);

                

            }
            menu = new HlavneMenu(this.napis_nad_levelom, this.tlacitko_new_game, this.tlacitko_how_to_play, this.tlacitko_kredity, this.pozadie_menu);

            level = new Level(1, hrdina, padouch, pozadie, napis_nad_levelom);

            padouch.telo.Parent = pozadie;
            napis_nad_levelom.Parent = pozadie;
            hrdina.telo.Parent = pozadie;

            box_krokvzad.SendToBack();
            box_krokvpred.SendToBack();
            box_mec.SendToBack();
            box_pitie.SendToBack();
            hp_hrdina.SendToBack();
            hp_padouch.SendToBack();

            //levelup
            smrtys = new PictureBox
            {
                Parent = pozadie,
                Size = new Size(320, 180),
                Location = new Point(340, 45),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Properties.Resources.image,
                BackColor = Color.Transparent
            };
            Controls.Add(smrtys);
            smrtys.Visible = false;

            zvysne_xp = new Label
            {
                Size = new Size(140, 100),
                Location = new Point(800, 230),
                Parent = pozadie,
                Text = "Each upgrade costs 1 xp:\n__ xp left",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12),
            };
            Controls.Add(zvysne_xp);

            //options
            {
                moznost_1 = new Button
                {
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = "+1 Potion (+5 HP)",
                    Size = new Size(140, 40),
                    Location = new Point(800, 370)
                };
                Controls.Add(moznost_1);
                moznost_1.Click += new EventHandler(this.moznost_1_Click);

                moznost_2 = new Button
                {
                    Text = "+3 attack",
                    Size = new Size(140, 40),
                    Location = new Point(800, 420)
                };
                Controls.Add(moznost_2);
                moznost_2.Click += new EventHandler(this.moznost_2_Click);

                moznost_3 = new Button
                {
                    Text = "+7 HP",
                    Size = new Size(140, 40),
                    Location = new Point(800, 470)
                };
                Controls.Add(moznost_3);
                moznost_3.Click += new EventHandler(this.moznost_3_Click);

                moznost_4 = new Button
                {
                    Text = "+2 defense",
                    Size = new Size(140, 40),
                    Location = new Point(800, 520)
                };
                Controls.Add(moznost_4);
                moznost_4.Click += new EventHandler(this.moznost_4_Click);
            }
            moznosti = new Moznosti(moznost_1, moznost_2, moznost_3, moznost_4);

            //staty
            {
                atribut_1 = new Label
                {
                    Size = new Size(150, 50),
                    Location = new Point(500, 370),
                    Text = "  Potions :               __",
                    TextAlign = ContentAlignment.MiddleLeft
                };
                Controls.Add(atribut_1);

                atribut_2 = new Label
                {
                    Size = new Size(150, 50),
                    Location = new Point(500, 420),
                    Text = "  ATTACK :             __",
                    TextAlign = ContentAlignment.MiddleLeft
                };
                Controls.Add(atribut_2);

                atribut_3 = new Label
                {
                    Size = new Size(150, 50),
                    Location = new Point(500, 470),
                    Text = "  HP :                      __",
                    TextAlign = ContentAlignment.MiddleLeft
                };
                Controls.Add(atribut_3);

                atribut_4 = new Label
                {
                    Size = new Size(150, 50),
                    Location = new Point(500, 520),
                    Text = "  DEFENSE :          __",
                    TextAlign = ContentAlignment.MiddleLeft
                };
                Controls.Add(atribut_4);

            }
            atributky = new Atributy(atribut_1, atribut_2, atribut_3, atribut_4);

            levelup = new LevelUp(zvysne_xp, moznosti, hrdina, atributky, pozadie, napis_nad_levelom);
            levelup.zmizni();

            levelup.text_levelup.Parent = levelup.pozadie;

            konfety = new PictureBox
            {
                Size = new Size(1000, 700),
                Image = Properties.Resources.konfety,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Parent = pozadie
            };
            konfety.SendToBack();
            konfety.Visible = false;

            nahodne = new Random();

            InitializeComponent();

            x_credits = new Button
            {
                Size = new Size(30, 30),
                Text = "X",
                Location = new Point(titulky.Location.X + titulky.Width, titulky.Location.Y),
                Visible = false
            };
            Controls.Add(x_credits);
            x_credits.BringToFront();
            
            x_credits.Click += new EventHandler(x_credits_click);
        }

        internal Timer hrdina_timer_krok_vpred;
        internal Timer hrdina_timer_krok_vzad;
        internal Timer padouch_timer_krok_vpred;
        internal Timer padouch_timer_krok_vzad;

        internal Timer dopredny_utok;
        internal Timer spatny_utok;
        internal Button hudba;

        internal int i;
        internal Button x_how_to_play;
        internal Button x_credits;

        internal Boxy boxy_akcii;
        internal TimerKrok krok_hrdina;
        internal TimerKrok krok_padouch;
        internal Zivot hrdina_zivot;
        internal Zivot padouch_zivot;
        internal Moznosti moznosti;
        internal Atributy atributky;


        //deklaracie
        internal Hrdina hrdina;
        internal ProgressBar hp_hrdina;

        internal PictureBox box_krokvpred;
        internal PictureBox box_krokvzad;
        internal PictureBox box_mec;
        internal PictureBox box_pitie;

        internal Label ukaz_hp_hrdina;
        internal Random nahodne;
        internal System.Media.SoundPlayer sp;

        internal Padouch padouch;
        internal ProgressBar hp_padouch;
        internal Label ukaz_hp_padouch;

        internal HlavneMenu menu;
        internal Level level;
        internal PictureBox pozadie;
        internal PictureBox napis_nad_levelom;
        internal PictureBox smrtys;
        internal PictureBox konfety;

        internal LevelUp levelup;
        internal Label zvysne_xp;
        internal Button moznost_1;
        internal Button moznost_2;
        internal Button moznost_3;
        internal Button moznost_4;
        internal Label atribut_1;
        internal Label atribut_2;
        internal Label atribut_3;
        internal Label atribut_4;
        internal Label text_ku_how_to_play;       

        private void tlacitko_kredity_Click(object sender, EventArgs e)
        {

            tlacitko_new_game.Visible = false;
            tlacitko_how_to_play.Visible = false;
            tlacitko_kredity.Visible = false;
            titulky.Visible = true;
            titulky.BringToFront();
            x_credits.Visible = true;
            x_credits.BringToFront();
        }

        private void nazov_hry_Click(object sender, EventArgs e)
        {
            pozadie_menu.BringToFront();
            tlacitko_new_game.BringToFront();
            tlacitko_new_game.Visible = true;
            tlacitko_how_to_play.BringToFront();
            tlacitko_how_to_play.Visible = true;
            tlacitko_kredity.BringToFront();
            tlacitko_kredity.Visible = true;
            napis_nad_levelom.BringToFront();
        }

        private void tlacitko_how_to_play_Click(object sender, EventArgs e)
        {
            tlacitko_how_to_play.Visible = false;
            tlacitko_kredity.Visible = false;
            text_ku_how_to_play.Visible = true;
            titulky.Visible = false;
            x_how_to_play.Visible = true;
            x_how_to_play.BringToFront();
        }

        private void tlacitko_nova_hra_Click(object sender, EventArgs e)
        {
            text_ku_how_to_play.Visible = false;
            titulky.Visible = false;
            menu.zmizni_menu();
            level.nastav_nazov(1);
            level.vygeneruj_pozadie();
            level.hrdina.nastav_vychodziu_poziciu();
            level.padouch.nastav_vychodziu_poziciu();
            level.hrdina.zisti_vzdialenost();
            level.hrdina.odmizni_akcie();
            level.hrdina.vytvor_zakladneho_hrdinu();
            level.padouch.vygeneruj_nepriatela(1);
            level.padouch.vygeneruj_telo();
            level.padouch.hpbar.Value = level.padouch.hpbar.Maximum;
            tlacitko_new_game.Visible = false;
            level.padouch.vyhra = false;
            x_how_to_play.Visible = false;
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
            hrdina.ukaz_hp.Update();
            
            if (hrdina.vyhra == true) { if (hrdina.level > 5) vyhral_si(); else { Console.WriteLine(hrdina.level); hrdina.zmizni_akcie(); levelup.ukaz_sa(); aktualizuj_levelup(hrdina.level); } }
            else rozhyb_padoucha();
        }

        private void box_pitie_Click(object sender, EventArgs e)
        {
            if (hrdina.pocet_elixirov > 0)
            {
                hrdina.pocet_elixirov -= 1;

                if (hrdina.hpbar.Value + 5 <= hrdina.hpbar.Maximum)
                {
                    hrdina.zivot += 5;
                    hrdina.hpbar.Value += 5;
                } 
                else hrdina.hpbar.Value = hrdina.hpbar.Maximum;
            }
            else hrdina.urob_pohyb_neschopnosti();
            rozhyb_padoucha();
        }

        private void moznost_1_Click(object sender, EventArgs e)
        {
            if (levelup.xp_teraz > 0)
            {
                levelup.xp_teraz -= 1;
                levelup.hrdina.pocet_elixirov += 1;
                levelup.aktualizuj_veci();
            }
            if (levelup.xp_teraz == 0)
            {
                levelup.zmizni();
                level.nastav_nazov(hrdina.level);
                level.zrob_novy_level();
            }
        }

        private void moznost_2_Click(object sender, EventArgs e)
        {
            if (levelup.xp_teraz > 0)
            {
                levelup.xp_teraz -= 1;
                levelup.hrdina.utok += 3;
                levelup.aktualizuj_veci();
            }
            if (levelup.xp_teraz == 0)
            {
                levelup.zmizni();
                level.zrob_novy_level();
            }
        }

        private void moznost_3_Click(object sender, EventArgs e)
        {
            if (levelup.xp_teraz > 0)
            {
                levelup.xp_teraz -= 1;
                levelup.hrdina.max_zivot += 7;
                levelup.hrdina.hpbar.Maximum = levelup.hrdina.max_zivot;
                levelup.aktualizuj_veci();
            }
            if (levelup.xp_teraz == 0)
            {
                levelup.zmizni();
                level.zrob_novy_level();
            }
        }

        private void moznost_4_Click(object sender, EventArgs e)
        {
            if (levelup.xp_teraz > 0)
            {
                levelup.xp_teraz -= 1;
                levelup.hrdina.obrana += 2;
                levelup.aktualizuj_veci();
            }
            if (levelup.xp_teraz == 0)
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
                hrdina.tah_nepriatela();
                padouch.ukaz_hp.Text = padouch.hpbar.Value.ToString();
                padouch.ukaz_hp.Update();
                if (padouch.vyhra == true)
                {
                    koniec_hry();
                }
            }
        }

        private void vyhral_si()
        {
            hrdina.nepriatel.telo.Visible = false;
            hrdina.nepriatel.hpbar.Visible = false;
            hrdina.nepriatel.ukaz_hp.Visible = false;
            konfety.BringToFront();
            konfety.Visible = true;
            hrdina.zmizni_akcie();
            hrdina.hpbar.Visible = false;
            hrdina.ukaz_hp.Visible = false;
            hrdina.telo.BringToFront();
            napis_nad_levelom.BringToFront();
            napis_nad_levelom.Image = Properties.Resources.vyhrys;
        }

        private void koniec_hry()
        {
            napis_nad_levelom.Visible = true;
            napis_nad_levelom.Image = Properties.Resources.smrt;
            tlacitko_new_game.Visible = true;
            napis_nad_levelom.Parent = pozadie;
            napis_nad_levelom.BackColor = Color.Transparent;
            hrdina.zmizni_akcie();
            hrdina.vytvor_zakladneho_hrdinu();
            hrdina.level = 1;
            padouch.vygeneruj_nepriatela(1);
            padouch.vygeneruj_telo();
            hrdina.pocet_elixirov = 0;
            tlacitko_new_game.BringToFront();

        }

        private void aktualizuj_levelup(int obtiaznost)
        {
            levelup.aktualizuj_veci();
            levelup.xp_teraz = hrdina.xp[obtiaznost - 1];
            levelup.zvysne_xp.Text = levelup.xp_teraz.ToString();
            levelup.aktualizuj_veci();
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
                padouch.krok_vpred_t.Stop();
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
                padouch.krok_vzad_t.Stop();
                
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
                hrdina.krok_vpred_t.Stop();
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
                hrdina.krok_vzad_t.Stop();
                hrdina.krok_vzad_t.Enabled = false;
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
            hrdina.ukaz_hp.Visible = false;
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

        private void x_how_to_play_click(object sender, EventArgs e)
        {
            text_ku_how_to_play.Visible = false;
            x_how_to_play.Visible = false;
        }

        private void x_credits_click(object sender, EventArgs e)
        {
            titulky.Visible = false;
            tlacitko_kredity.Visible = true;
            x_credits.Visible = false;
        }
    }
}


