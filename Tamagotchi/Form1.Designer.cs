namespace Tamagotchi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonA = new Tamagotchi.ButtonEllipse();
            this.buttonB = new Tamagotchi.ButtonEllipse();
            this.buttonC = new Tamagotchi.ButtonEllipse();
            this.Crack = new Tamagotchi.TransparentPictureBox();
            this.Shell = new Tamagotchi.TransparentPictureBox();
            this.Design = new Tamagotchi.TransparentPictureBox();
            this.Buttons = new Tamagotchi.TransparentPictureBox();
            this.Screen = new Tamagotchi.TransparentPictureBox();
            this.Frame = new Tamagotchi.TransparentPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Crack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Design)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Buttons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonA
            // 
            this.buttonA.BackColor = System.Drawing.Color.Transparent;
            this.buttonA.FlatAppearance.BorderSize = 0;
            this.buttonA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonA.ForeColor = System.Drawing.Color.Black;
            this.buttonA.Location = new System.Drawing.Point(76, 243);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(16, 16);
            this.buttonA.TabIndex = 0;
            this.buttonA.UseVisualStyleBackColor = false;
            this.buttonA.Click += new System.EventHandler(this.AButtonClicked);
            // 
            // buttonB
            // 
            this.buttonB.BackColor = System.Drawing.Color.Transparent;
            this.buttonB.FlatAppearance.BorderSize = 0;
            this.buttonB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonB.ForeColor = System.Drawing.Color.Black;
            this.buttonB.Location = new System.Drawing.Point(116, 253);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(16, 16);
            this.buttonB.TabIndex = 0;
            this.buttonB.UseVisualStyleBackColor = false;
            this.buttonB.Click += new System.EventHandler(this.BButtonClicked);
            // 
            // buttonC
            // 
            this.buttonC.BackColor = System.Drawing.Color.Transparent;
            this.buttonC.FlatAppearance.BorderSize = 0;
            this.buttonC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonC.ForeColor = System.Drawing.Color.Black;
            this.buttonC.Location = new System.Drawing.Point(157, 243);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(16, 16);
            this.buttonC.TabIndex = 0;
            this.buttonC.UseVisualStyleBackColor = false;
            this.buttonC.Click += new System.EventHandler(this.CButtonClicked);
            // 
            // Crack
            // 
            this.Crack.BackColor = System.Drawing.Color.Transparent;
            this.Crack.Image = global::Tamagotchi.Properties.Resources.Crack_Purple;
            this.Crack.Location = new System.Drawing.Point(37, 67);
            this.Crack.Name = "Crack";
            this.Crack.Size = new System.Drawing.Size(175, 169);
            this.Crack.TabIndex = 1;
            this.Crack.TabStop = false;
            // 
            // Shell
            // 
            this.Shell.BackColor = System.Drawing.Color.Transparent;
            this.Shell.Image = global::Tamagotchi.Properties.Resources.Shell_Purple;
            this.Shell.Location = new System.Drawing.Point(1, 12);
            this.Shell.Name = "Shell";
            this.Shell.Size = new System.Drawing.Size(247, 280);
            this.Shell.TabIndex = 2;
            this.Shell.TabStop = false;
            // 
            // Design
            // 
            this.Design.BackColor = System.Drawing.Color.Transparent;
            this.Design.Image = global::Tamagotchi.Properties.Resources.Design_Spots;
            this.Design.Location = new System.Drawing.Point(21, 54);
            this.Design.Name = "Design";
            this.Design.Size = new System.Drawing.Size(212, 193);
            this.Design.TabIndex = 3;
            this.Design.TabStop = false;
            // 
            // Buttons
            // 
            this.Buttons.BackColor = System.Drawing.Color.Transparent;
            this.Buttons.Image = global::Tamagotchi.Properties.Resources.Buttons_Purple;
            this.Buttons.Location = new System.Drawing.Point(75, 242);
            this.Buttons.Name = "Buttons";
            this.Buttons.Size = new System.Drawing.Size(99, 29);
            this.Buttons.TabIndex = 4;
            this.Buttons.TabStop = false;
            // 
            // Screen
            // 
            this.Screen.BackColor = System.Drawing.Color.Transparent;
            this.Screen.Location = new System.Drawing.Point(77, 107);
            this.Screen.Name = "Screen";
            this.Screen.Size = new System.Drawing.Size(96, 90);
            this.Screen.TabIndex = 5;
            this.Screen.TabStop = false;
            this.Screen.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateScreenGraphics);
            // 
            // Frame
            // 
            this.Frame.BackColor = System.Drawing.Color.Transparent;
            this.Frame.Image = global::Tamagotchi.Properties.Resources.BaseFrame;
            this.Frame.Location = new System.Drawing.Point(0, 0);
            this.Frame.Name = "Frame";
            this.Frame.Size = new System.Drawing.Size(249, 293);
            this.Frame.TabIndex = 6;
            this.Frame.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(249, 293);
            this.Controls.Add(this.Frame);
            this.Controls.Add(this.Screen);
            this.Controls.Add(this.Buttons);
            this.Controls.Add(this.Design);
            this.Controls.Add(this.Shell);
            this.Controls.Add(this.Crack);
            this.Controls.Add(this.buttonC);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.buttonA);
            this.Name = "Form1";
            this.Text = "Tamagotchi Connection v1";
            ((System.ComponentModel.ISupportInitialize)(this.Crack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Design)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Buttons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonEllipse buttonA;
        private ButtonEllipse buttonB;
        private ButtonEllipse buttonC;
        private TransparentPictureBox Crack;
        private TransparentPictureBox Shell;
        private TransparentPictureBox Design;
        private TransparentPictureBox Buttons;
        private TransparentPictureBox Screen;
        private TransparentPictureBox Frame;
    }
}