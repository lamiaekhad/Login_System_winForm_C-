namespace WinFormsApp1
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nom = new System.Windows.Forms.TextBox();
            this.prenom = new System.Windows.Forms.TextBox();
            this.nomutilisateur = new System.Windows.Forms.TextBox();
            this.courriel = new System.Windows.Forms.TextBox();
            this.motdepasse = new System.Windows.Forms.TextBox();
            this.confirmation = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prenom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nom d\'utilisateur";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Courriel";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(111, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mot de passe";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Confirmation";
            // 
            // nom
            // 
            this.nom.Location = new System.Drawing.Point(294, 47);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(379, 27);
            this.nom.TabIndex = 6;
            this.nom.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // prenom
            // 
            this.prenom.Location = new System.Drawing.Point(294, 97);
            this.prenom.Name = "prenom";
            this.prenom.Size = new System.Drawing.Size(379, 27);
            this.prenom.TabIndex = 7;
            this.prenom.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // nomutilisateur
            // 
            this.nomutilisateur.Location = new System.Drawing.Point(294, 148);
            this.nomutilisateur.Name = "nomutilisateur";
            this.nomutilisateur.Size = new System.Drawing.Size(379, 27);
            this.nomutilisateur.TabIndex = 8;
            // 
            // courriel
            // 
            this.courriel.Location = new System.Drawing.Point(294, 202);
            this.courriel.Name = "courriel";
            this.courriel.Size = new System.Drawing.Size(379, 27);
            this.courriel.TabIndex = 9;
            this.courriel.TextChanged += new System.EventHandler(this.courriel_TextChanged);
            // 
            // motdepasse
            // 
            this.motdepasse.Location = new System.Drawing.Point(294, 252);
            this.motdepasse.Name = "motdepasse";
            this.motdepasse.Size = new System.Drawing.Size(379, 27);
            this.motdepasse.TabIndex = 10;
            // 
            // confirmation
            // 
            this.confirmation.Location = new System.Drawing.Point(294, 303);
            this.confirmation.Name = "confirmation";
            this.confirmation.Size = new System.Drawing.Size(379, 27);
            this.confirmation.TabIndex = 11;
            this.confirmation.TextChanged += new System.EventHandler(this.confirmation_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 54);
            this.button1.TabIndex = 12;
            this.button1.Text = "Creer compte";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(579, 360);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 54);
            this.button2.TabIndex = 13;
            this.button2.Text = "Quitter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 429);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.confirmation);
            this.Controls.Add(this.motdepasse);
            this.Controls.Add(this.courriel);
            this.Controls.Add(this.nomutilisateur);
            this.Controls.Add(this.prenom);
            this.Controls.Add(this.nom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nom;
        private System.Windows.Forms.TextBox prenom;
        private System.Windows.Forms.TextBox nomutilisateur;
        private System.Windows.Forms.TextBox courriel;
        private System.Windows.Forms.TextBox motdepasse;
        private System.Windows.Forms.TextBox confirmation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}