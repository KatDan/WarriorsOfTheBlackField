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

            hrdina = new Hrdina(box_krokvzad, box_krokvpred, box_mec, box_pitie, hp_hrdina, show_hp_hrdina,hrdina_timer_krok_vpred,hrdina_timer_krok_vzad,dopredny_utok);
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
            padouch = new Padouch(hrdina, hp_padouch, show_hp_padouch,padouch_timer_krok_vpred,padouch_timer_krok_vzad,spatny_utok);
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


                X = new Button
                {
                    Text = "X",
                    Visible = false,
                    Size = new Size(40,40),
                    Location = new Point(910,350),
                };
                Controls.Add(X);
                X.Click += new EventHandler(x_click);

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
        internal Button X;

        //deklaracie
        internal Hrdina hrdina;
        internal ProgressBar hp_hrdina;

        internal PictureBox box_krokvpred;
        internal PictureBox box_krokvzad;
        internal PictureBox box_mec;
        internal PictureBox box_pitie;
        internal Label show_hp_hrdina;
        internal Random rnd;
        internal System.Media.SoundPlayer sp;

        internal Padouch padouch;
        internal ProgressBar hp_padouch;
        //internal Label ujma_padouch;
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
            X.Visible = true;
            X.BringToFront();
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
            X.Visible = false;
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
                if (hrdina.zivot + 5 <= hrdina.max_zivot) hrdina.hpbar.Value += 5;
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

        private void x_click(object sender, EventArgs e)
        {
            how_to_play.Visible = false;
            X.Visible = false;
        }


    }
}


