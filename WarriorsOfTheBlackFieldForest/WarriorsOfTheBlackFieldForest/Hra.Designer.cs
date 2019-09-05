﻿namespace WarriorsOfTheBlackFieldForest
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
            ((System.ComponentModel.ISupportInitialize)(this.pozadie_menu)).BeginInit();
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
            this.titulky.AutoSize = true;
            this.titulky.BackColor = System.Drawing.Color.Transparent;
            this.titulky.Font = new System.Drawing.Font("Mistral", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titulky.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.titulky.Location = new System.Drawing.Point(280, 414);
            this.titulky.Name = "titulky";
            this.titulky.Size = new System.Drawing.Size(419, 96);
            this.titulky.TabIndex = 6;
            this.titulky.Text = "Created by Katarína Dančejová\r\nMusic Composed by janetusim";
            this.titulky.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.titulky.Visible = false;
            // 
            // button_Credits
            // 
            this.tlacitko_kredity.Font = new System.Drawing.Font("Carta Magna Line", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlacitko_kredity.Location = new System.Drawing.Point(350, 414);
            this.tlacitko_kredity.Name = "button_Credits";
            this.tlacitko_kredity.Size = new System.Drawing.Size(300, 60);
            this.tlacitko_kredity.TabIndex = 4;
            this.tlacitko_kredity.Text = "Credits";
            this.tlacitko_kredity.UseVisualStyleBackColor = true;
            this.tlacitko_kredity.Visible = false;
            this.tlacitko_kredity.Click += new System.EventHandler(this.tlacitko_kredity_Click);
            // 
            // button_How_to_play
            // 
            this.tlacitko_how_to_play.Font = new System.Drawing.Font("Carta Magna Line", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlacitko_how_to_play.Location = new System.Drawing.Point(350, 341);
            this.tlacitko_how_to_play.Name = "button_How_to_play";
            this.tlacitko_how_to_play.Size = new System.Drawing.Size(300, 60);
            this.tlacitko_how_to_play.TabIndex = 3;
            this.tlacitko_how_to_play.Text = "High Score";
            this.tlacitko_how_to_play.UseVisualStyleBackColor = true;
            this.tlacitko_how_to_play.Visible = false;
            // 
            // button_NovaHra
            // 
            this.tlacitko_new_game.Font = new System.Drawing.Font("Carta Magna Line", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlacitko_new_game.Location = new System.Drawing.Point(350, 268);
            this.tlacitko_new_game.Name = "button_NovaHra";
            this.tlacitko_new_game.Size = new System.Drawing.Size(300, 60);
            this.tlacitko_new_game.TabIndex = 2;
            this.tlacitko_new_game.Text = "New Game";
            this.tlacitko_new_game.UseVisualStyleBackColor = true;
            this.tlacitko_new_game.Visible = false;
            this.tlacitko_new_game.Click += new System.EventHandler(this.tlacitko_nova_hra_Click);
            // 
            // Hra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
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
    }
}

