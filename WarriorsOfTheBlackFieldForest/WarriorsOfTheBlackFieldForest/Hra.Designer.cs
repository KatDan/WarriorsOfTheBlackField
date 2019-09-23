namespace WarriorsOfTheBlackFieldForest
{
    partial class Hra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hra));
            this.pozadie_menu = new System.Windows.Forms.PictureBox();
            this.zobrazenie_ujmy = new System.Windows.Forms.Timer(this.components);
            this.krok = new System.Windows.Forms.Timer(this.components);
            this.ukaz_rany = new System.Windows.Forms.Timer(this.components);
            this.titulky = new System.Windows.Forms.Label();
            this.tlacitko_kredity = new System.Windows.Forms.Button();
            this.tlacitko_how_to_play = new System.Windows.Forms.Button();
            this.tlacitko_new_game = new System.Windows.Forms.Button();
            this.panel_skore = new System.Windows.Forms.Panel();
            this.skore_hodnota_napis = new System.Windows.Forms.Label();
            this.panel_cisla = new System.Windows.Forms.Label();
            this.skore_meno_napis = new System.Windows.Forms.Label();
            this.skore_hodnota = new System.Windows.Forms.Label();
            this.skore_meno = new System.Windows.Forms.Label();
            this.x_skore = new System.Windows.Forms.Button();
            this.textBox_zadaj_meno = new System.Windows.Forms.TextBox();
            this.tlacitko_submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tlacitko_hlavne_menu = new System.Windows.Forms.Button();
            this.tlacitko_skore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pozadie_menu)).BeginInit();
            this.panel_skore.SuspendLayout();
            this.SuspendLayout();
            // 
            // pozadie_menu
            // 
            this.pozadie_menu.Image = global::WarriorsOfTheBlackFieldForest.Properties.Resources.gif5;
            this.pozadie_menu.Location = new System.Drawing.Point(0, 0);
            this.pozadie_menu.Name = "pozadie_menu";
            this.pozadie_menu.Size = new System.Drawing.Size(1000, 700);
            this.pozadie_menu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pozadie_menu.TabIndex = 0;
            this.pozadie_menu.TabStop = false;
            this.pozadie_menu.Visible = false;
            // 
            // zobrazenie_ujmy
            // 
            this.zobrazenie_ujmy.Interval = 1500;
            // 
            // krok
            // 
            this.krok.Interval = 1000;
            // 
            // ukaz_rany
            // 
            this.ukaz_rany.Interval = 1500;
            // 
            // titulky
            // 
            this.titulky.BackColor = System.Drawing.Color.Transparent;
            this.titulky.Font = new System.Drawing.Font("Mistral", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titulky.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.titulky.Location = new System.Drawing.Point(290, 475);
            this.titulky.Name = "titulky";
            this.titulky.Size = new System.Drawing.Size(420, 100);
            this.titulky.TabIndex = 6;
            this.titulky.Text = "Created by Katarína Dančejová\r\nMusic Composed by janetusim";
            this.titulky.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titulky.Visible = false;
            // 
            // tlacitko_kredity
            // 
            this.tlacitko_kredity.Font = new System.Drawing.Font("Carta Magna Line", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlacitko_kredity.Location = new System.Drawing.Point(350, 480);
            this.tlacitko_kredity.Name = "tlacitko_kredity";
            this.tlacitko_kredity.Size = new System.Drawing.Size(300, 60);
            this.tlacitko_kredity.TabIndex = 4;
            this.tlacitko_kredity.Text = "Credits";
            this.tlacitko_kredity.UseVisualStyleBackColor = true;
            this.tlacitko_kredity.Visible = false;
            this.tlacitko_kredity.Click += new System.EventHandler(this.tlacitko_kredity_Click);
            // 
            // tlacitko_how_to_play
            // 
            this.tlacitko_how_to_play.Font = new System.Drawing.Font("Carta Magna Line", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlacitko_how_to_play.Location = new System.Drawing.Point(350, 340);
            this.tlacitko_how_to_play.Name = "tlacitko_how_to_play";
            this.tlacitko_how_to_play.Size = new System.Drawing.Size(300, 60);
            this.tlacitko_how_to_play.TabIndex = 3;
            this.tlacitko_how_to_play.Text = "How to play";
            this.tlacitko_how_to_play.UseVisualStyleBackColor = true;
            this.tlacitko_how_to_play.Visible = false;
            // 
            // tlacitko_new_game
            // 
            this.tlacitko_new_game.Font = new System.Drawing.Font("Carta Magna Line", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlacitko_new_game.Location = new System.Drawing.Point(350, 270);
            this.tlacitko_new_game.Name = "tlacitko_new_game";
            this.tlacitko_new_game.Size = new System.Drawing.Size(300, 60);
            this.tlacitko_new_game.TabIndex = 2;
            this.tlacitko_new_game.Text = "New Game";
            this.tlacitko_new_game.UseVisualStyleBackColor = true;
            this.tlacitko_new_game.Visible = false;
            this.tlacitko_new_game.Click += new System.EventHandler(this.tlacitko_nova_hra_Click);
            // 
            // panel_skore
            // 
            this.panel_skore.Controls.Add(this.label1);
            this.panel_skore.Controls.Add(this.skore_hodnota_napis);
            this.panel_skore.Controls.Add(this.panel_cisla);
            this.panel_skore.Controls.Add(this.skore_meno_napis);
            this.panel_skore.Controls.Add(this.skore_hodnota);
            this.panel_skore.Controls.Add(this.skore_meno);
            this.panel_skore.Location = new System.Drawing.Point(200, 270);
            this.panel_skore.Name = "panel_skore";
            this.panel_skore.Size = new System.Drawing.Size(600, 287);
            this.panel_skore.TabIndex = 7;
            this.panel_skore.Visible = false;
            // 
            // skore_hodnota_napis
            // 
            this.skore_hodnota_napis.AutoSize = true;
            this.skore_hodnota_napis.Font = new System.Drawing.Font("Imprint MT Shadow", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.skore_hodnota_napis.Location = new System.Drawing.Point(456, 26);
            this.skore_hodnota_napis.Name = "skore_hodnota_napis";
            this.skore_hodnota_napis.Size = new System.Drawing.Size(78, 28);
            this.skore_hodnota_napis.TabIndex = 4;
            this.skore_hodnota_napis.Text = "Score";
            // 
            // panel_cisla
            // 
            this.panel_cisla.Font = new System.Drawing.Font("Imprint MT Shadow", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panel_cisla.Location = new System.Drawing.Point(14, 74);
            this.panel_cisla.Name = "panel_cisla";
            this.panel_cisla.Size = new System.Drawing.Size(45, 156);
            this.panel_cisla.TabIndex = 3;
            this.panel_cisla.Text = "1.\r\n2.\r\n3.\r\n4.\r\n5.";
            // 
            // skore_meno_napis
            // 
            this.skore_meno_napis.AutoSize = true;
            this.skore_meno_napis.Font = new System.Drawing.Font("Imprint MT Shadow", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.skore_meno_napis.Location = new System.Drawing.Point(55, 26);
            this.skore_meno_napis.Name = "skore_meno_napis";
            this.skore_meno_napis.Size = new System.Drawing.Size(80, 28);
            this.skore_meno_napis.TabIndex = 2;
            this.skore_meno_napis.Text = "Name";
            // 
            // skore_hodnota
            // 
            this.skore_hodnota.Font = new System.Drawing.Font("Imprint MT Shadow", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.skore_hodnota.Location = new System.Drawing.Point(384, 72);
            this.skore_hodnota.Name = "skore_hodnota";
            this.skore_hodnota.Size = new System.Drawing.Size(150, 140);
            this.skore_hodnota.TabIndex = 1;
            this.skore_hodnota.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // skore_meno
            // 
            this.skore_meno.Font = new System.Drawing.Font("Imprint MT Shadow", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skore_meno.Location = new System.Drawing.Point(57, 71);
            this.skore_meno.Name = "skore_meno";
            this.skore_meno.Size = new System.Drawing.Size(280, 140);
            this.skore_meno.TabIndex = 0;
            // 
            // x_skore
            // 
            this.x_skore.Location = new System.Drawing.Point(800, 270);
            this.x_skore.Name = "x_skore";
            this.x_skore.Size = new System.Drawing.Size(30, 30);
            this.x_skore.TabIndex = 8;
            this.x_skore.Text = "X";
            this.x_skore.UseVisualStyleBackColor = true;
            this.x_skore.Visible = false;
            // 
            // textBox_zadaj_meno
            // 
            this.textBox_zadaj_meno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_zadaj_meno.Location = new System.Drawing.Point(366, 573);
            this.textBox_zadaj_meno.MaximumSize = new System.Drawing.Size(200, 30);
            this.textBox_zadaj_meno.MaxLength = 10;
            this.textBox_zadaj_meno.MinimumSize = new System.Drawing.Size(200, 30);
            this.textBox_zadaj_meno.Name = "textBox_zadaj_meno";
            this.textBox_zadaj_meno.Size = new System.Drawing.Size(200, 30);
            this.textBox_zadaj_meno.TabIndex = 10;
            this.textBox_zadaj_meno.Text = "Your Name";
            this.textBox_zadaj_meno.Visible = false;
            // 
            // tlacitko_submit
            // 
            this.tlacitko_submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tlacitko_submit.Location = new System.Drawing.Point(570, 563);
            this.tlacitko_submit.Name = "tlacitko_submit";
            this.tlacitko_submit.Size = new System.Drawing.Size(121, 55);
            this.tlacitko_submit.TabIndex = 11;
            this.tlacitko_submit.Text = "Submit";
            this.tlacitko_submit.UseVisualStyleBackColor = true;
            this.tlacitko_submit.Visible = false;
            this.tlacitko_submit.Click += new System.EventHandler(this.tlacitko_submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(668, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "---------------------------------------------------------------------------------" +
    "---------------------------------------------------";
            // 
            // tlacitko_hlavne_menu
            // 
            this.tlacitko_hlavne_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tlacitko_hlavne_menu.Location = new System.Drawing.Point(700, 563);
            this.tlacitko_hlavne_menu.Name = "tlacitko_hlavne_menu";
            this.tlacitko_hlavne_menu.Size = new System.Drawing.Size(121, 55);
            this.tlacitko_hlavne_menu.TabIndex = 12;
            this.tlacitko_hlavne_menu.Text = "Main Menu";
            this.tlacitko_hlavne_menu.UseVisualStyleBackColor = true;
            this.tlacitko_hlavne_menu.Visible = false;
            this.tlacitko_hlavne_menu.Click += new System.EventHandler(this.tlacitko_hlavne_menu_Click);
            // 
            // tlacitko_skore
            // 
            this.tlacitko_skore.Font = new System.Drawing.Font("Carta Magna Line", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlacitko_skore.Location = new System.Drawing.Point(350, 410);
            this.tlacitko_skore.Name = "tlacitko_skore";
            this.tlacitko_skore.Size = new System.Drawing.Size(300, 60);
            this.tlacitko_skore.TabIndex = 9;
            this.tlacitko_skore.Text = "High score";
            this.tlacitko_skore.UseVisualStyleBackColor = true;
            this.tlacitko_skore.Visible = false;
            // 
            // Hra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.tlacitko_hlavne_menu);
            this.Controls.Add(this.tlacitko_submit);
            this.Controls.Add(this.textBox_zadaj_meno);
            this.Controls.Add(this.panel_skore);
            this.Controls.Add(this.tlacitko_skore);
            this.Controls.Add(this.x_skore);
            this.Controls.Add(this.titulky);
            this.Controls.Add(this.tlacitko_kredity);
            this.Controls.Add(this.tlacitko_how_to_play);
            this.Controls.Add(this.tlacitko_new_game);
            this.Controls.Add(this.pozadie_menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Hra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warriors of the Black Field";
            this.TransparencyKey = System.Drawing.Color.Red;
            ((System.ComponentModel.ISupportInitialize)(this.pozadie_menu)).EndInit();
            this.panel_skore.ResumeLayout(false);
            this.panel_skore.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pozadie_menu;
        private System.Windows.Forms.Timer zobrazenie_ujmy;
        private System.Windows.Forms.Timer krok;
        private System.Windows.Forms.Timer ukaz_rany;
        private System.Windows.Forms.Label titulky;
        private System.Windows.Forms.Button tlacitko_kredity;
        private System.Windows.Forms.Button tlacitko_how_to_play;
        private System.Windows.Forms.Button tlacitko_new_game;
        private System.Windows.Forms.Panel panel_skore;
        private System.Windows.Forms.Label skore_hodnota_napis;
        private System.Windows.Forms.Label panel_cisla;
        private System.Windows.Forms.Label skore_meno_napis;
        private System.Windows.Forms.Label skore_hodnota;
        private System.Windows.Forms.Label skore_meno;
        private System.Windows.Forms.Button x_skore;
        private System.Windows.Forms.TextBox textBox_zadaj_meno;
        private System.Windows.Forms.Button tlacitko_submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button tlacitko_hlavne_menu;
        private System.Windows.Forms.Button tlacitko_skore;
    }
}

