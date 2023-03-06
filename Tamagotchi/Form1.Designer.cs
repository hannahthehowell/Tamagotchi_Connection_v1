using Tamagotchi.CustomComponents;

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
            this.components = new System.ComponentModel.Container();
            this.Crack = new Tamagotchi.CustomComponents.TransparentPictureBox();
            this.Shell = new Tamagotchi.CustomComponents.TransparentPictureBox();
            this.Design = new Tamagotchi.CustomComponents.TransparentPictureBox();
            this.Logo_Outline = new Tamagotchi.CustomComponents.TransparentPictureBox();
            this.Screen = new Tamagotchi.CustomComponents.TransparentPictureBox();
            this.Frame = new Tamagotchi.CustomComponents.TransparentPictureBox();
            this.buttonA = new Tamagotchi.CustomComponents.ButtonEllipse();
            this.buttonB = new Tamagotchi.CustomComponents.ButtonEllipse();
            this.buttonC = new Tamagotchi.CustomComponents.ButtonEllipse();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.PauseButton = new System.Windows.Forms.Button();
            this.SoundButton = new System.Windows.Forms.Button();
            this.ExportSaveButton = new System.Windows.Forms.Button();
            this.ImportSaveButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.MenuButton = new System.Windows.Forms.Button();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Crack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Design)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_Outline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame)).BeginInit();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Crack
            // 
            this.Crack.BackColor = System.Drawing.Color.Transparent;
            this.Crack.Image = global::Tamagotchi.Properties.Resources.Crack_Purple;
            this.Crack.Location = new System.Drawing.Point(37, 67);
            this.Crack.Name = "Crack";
            this.Crack.Size = new System.Drawing.Size(175, 169);
            this.Crack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
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
            this.Shell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Shell.TabIndex = 2;
            this.Shell.TabStop = false;
            // 
            // Design
            // 
            this.Design.BackColor = System.Drawing.Color.Transparent;
            this.Design.Image = global::Tamagotchi.Properties.Resources.Design_Spots_Purple;
            this.Design.Location = new System.Drawing.Point(21, 53);
            this.Design.Name = "Design";
            this.Design.Size = new System.Drawing.Size(212, 194);
            this.Design.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Design.TabIndex = 3;
            this.Design.TabStop = false;
            // 
            // Logo_Outline
            // 
            this.Logo_Outline.BackColor = System.Drawing.Color.Transparent;
            this.Logo_Outline.Image = global::Tamagotchi.Properties.Resources.Logo_Outline_Purple;
            this.Logo_Outline.Location = new System.Drawing.Point(66, 30);
            this.Logo_Outline.Name = "Logo_Outline";
            this.Logo_Outline.Size = new System.Drawing.Size(121, 34);
            this.Logo_Outline.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Logo_Outline.TabIndex = 5;
            this.Logo_Outline.TabStop = false;
            // 
            // Screen
            // 
            this.Screen.BackColor = System.Drawing.Color.LightGray;
            this.Screen.Location = new System.Drawing.Point(77, 107);
            this.Screen.Name = "Screen";
            this.Screen.Size = new System.Drawing.Size(96, 90);
            this.Screen.TabIndex = 7;
            this.Screen.TabStop = false;
            this.Screen.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateScreenGraphics);
            // 
            // Frame
            // 
            this.Frame.BackColor = System.Drawing.Color.Transparent;
            this.Frame.Image = global::Tamagotchi.Properties.Resources.Base_Frame;
            this.Frame.Location = new System.Drawing.Point(0, 0);
            this.Frame.Name = "Frame";
            this.Frame.Size = new System.Drawing.Size(249, 293);
            this.Frame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Frame.TabIndex = 6;
            this.Frame.TabStop = false;
            // 
            // buttonA
            // 
            this.buttonA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(81)))), ((int)(((byte)(160)))));
            this.buttonA.FlatAppearance.BorderSize = 0;
            this.buttonA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonA.ForeColor = System.Drawing.Color.Transparent;
            this.buttonA.Location = new System.Drawing.Point(75, 243);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(17, 17);
            this.buttonA.TabIndex = 0;
            this.buttonA.UseVisualStyleBackColor = false;
            this.buttonA.Click += new System.EventHandler(this.AButtonClicked);
            // 
            // buttonB
            // 
            this.buttonB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(81)))), ((int)(((byte)(160)))));
            this.buttonB.FlatAppearance.BorderSize = 0;
            this.buttonB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonB.ForeColor = System.Drawing.Color.Black;
            this.buttonB.Location = new System.Drawing.Point(116, 253);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(17, 17);
            this.buttonB.TabIndex = 0;
            this.buttonB.UseVisualStyleBackColor = false;
            this.buttonB.Click += new System.EventHandler(this.BButtonClicked);
            // 
            // buttonC
            // 
            this.buttonC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(81)))), ((int)(((byte)(160)))));
            this.buttonC.FlatAppearance.BorderSize = 0;
            this.buttonC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonC.ForeColor = System.Drawing.Color.Black;
            this.buttonC.Location = new System.Drawing.Point(156, 243);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(17, 17);
            this.buttonC.TabIndex = 0;
            this.buttonC.UseVisualStyleBackColor = false;
            this.buttonC.Click += new System.EventHandler(this.CButtonClicked);
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MenuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuPanel.Controls.Add(this.PauseButton);
            this.MenuPanel.Controls.Add(this.SoundButton);
            this.MenuPanel.Controls.Add(this.ExportSaveButton);
            this.MenuPanel.Controls.Add(this.ImportSaveButton);
            this.MenuPanel.Controls.Add(this.SoundButton);
            this.MenuPanel.Controls.Add(this.ResetButton);
            this.MenuPanel.Controls.Add(this.MenuButton);
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.MaximumSize = new System.Drawing.Size(86, 293);
            this.MenuPanel.MinimumSize = new System.Drawing.Size(86, 25);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(85, 23);
            this.MenuPanel.TabIndex = 7;
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(3, 28);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(78, 32);
            this.PauseButton.TabIndex = 1;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButtonClicked);
            // 
            // SoundButton
            // 
            this.SoundButton.Location = new System.Drawing.Point(3, 65);
            this.SoundButton.Name = "SoundButton";
            this.SoundButton.Size = new System.Drawing.Size(78, 48);
            this.SoundButton.TabIndex = 1;
            this.SoundButton.Text = "Turn Sound On/Off";
            this.SoundButton.UseVisualStyleBackColor = true;
            this.SoundButton.Click += new System.EventHandler(this.SoundButtonClicked);
            // 
            // ExportSaveButton
            // 
            this.ExportSaveButton.Location = new System.Drawing.Point(3, 118);
            this.ExportSaveButton.Name = "ExportSaveButton";
            this.ExportSaveButton.Size = new System.Drawing.Size(78, 48);
            this.ExportSaveButton.TabIndex = 1;
            this.ExportSaveButton.Text = "Export/Save Tamagotchi";
            this.ExportSaveButton.UseVisualStyleBackColor = true;
            this.ExportSaveButton.Click += new System.EventHandler(this.ExportButtonClicked);
            // 
            // ImportSaveButton
            // 
            this.ImportSaveButton.Location = new System.Drawing.Point(3, 171);
            this.ImportSaveButton.Name = "ImportSaveButton";
            this.ImportSaveButton.Size = new System.Drawing.Size(78, 48);
            this.ImportSaveButton.TabIndex = 1;
            this.ImportSaveButton.Text = "Import Tamagotchi";
            this.ImportSaveButton.UseVisualStyleBackColor = true;
            this.ImportSaveButton.Click += new System.EventHandler(this.ImportButtonClicked);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(3, 224);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(78, 48);
            this.ResetButton.TabIndex = 1;
            this.ResetButton.Text = "Reset Tamagotchi";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButtonClicked);
            // 
            // MenuButton
            // 
            this.MenuButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MenuButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButton.Location = new System.Drawing.Point(0, 0);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(86, 23);
            this.MenuButton.TabIndex = 0;
            this.MenuButton.Text = "Menu";
            this.MenuButton.UseVisualStyleBackColor = false;
            this.MenuButton.Click += new System.EventHandler(this.ToggleMenuOpen);
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new System.EventHandler(this.GameTick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(249, 293);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.buttonC);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.buttonA);
            this.Controls.Add(this.Screen);
            this.Controls.Add(this.Frame);
            this.Controls.Add(this.Logo_Outline);
            this.Controls.Add(this.Design);
            this.Controls.Add(this.Shell);
            this.Controls.Add(this.Crack);
            this.Name = "Form1";
            this.Text = "Tamagotchi Connection v1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Crack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Design)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_Outline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame)).EndInit();
            this.MenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonEllipse buttonA;
        private ButtonEllipse buttonB;
        private ButtonEllipse buttonC;
        private TransparentPictureBox Crack;
        private TransparentPictureBox Shell;
        private TransparentPictureBox Design;
        private TransparentPictureBox Logo_Outline;
        private TransparentPictureBox Frame;
        private TransparentPictureBox Screen;
        private Panel MenuPanel;
        private Button MenuButton;
        private Button PauseButton;
        private Button SoundButton;
        private Button ExportSaveButton;
        private Button ImportSaveButton;
        private Button ResetButton;
        private System.Windows.Forms.Timer GameTimer;
    }
}