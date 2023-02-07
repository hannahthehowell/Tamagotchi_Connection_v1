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
            this.ResetButton = new System.Windows.Forms.Button();
            this.MenuButton = new System.Windows.Forms.Button();
            this.ColorMenuPanel = new System.Windows.Forms.Panel();
            this.ShellLabel = new System.Windows.Forms.Label();
            this.ShellUpButton = new System.Windows.Forms.Button();
            this.ShellDownButton = new System.Windows.Forms.Button();
            this.DesignLabel = new System.Windows.Forms.Label();
            this.DesignUpButton = new System.Windows.Forms.Button();
            this.DesignDownButton = new System.Windows.Forms.Button();
            this.CrackLabel = new System.Windows.Forms.Label();
            this.CrackUpButton = new System.Windows.Forms.Button();
            this.CrackDownButton = new System.Windows.Forms.Button();
            this.LogoLabel = new System.Windows.Forms.Label();
            this.LogoUpButton = new System.Windows.Forms.Button();
            this.LogoDownButton = new System.Windows.Forms.Button();
            this.ABCLabel = new System.Windows.Forms.Label();
            this.ABCUpButton = new System.Windows.Forms.Button();
            this.ABCDownButton = new System.Windows.Forms.Button();
            this.ColorMenuButton = new System.Windows.Forms.Button();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Crack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Design)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_Outline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Frame)).BeginInit();
            this.MenuPanel.SuspendLayout();
            this.ColorMenuPanel.SuspendLayout();
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
            this.MenuPanel.BackColor = System.Drawing.Color.LightGray;
            this.MenuPanel.Controls.Add(this.PauseButton);
            this.MenuPanel.Controls.Add(this.SoundButton);
            this.MenuPanel.Controls.Add(this.ResetButton);
            this.MenuPanel.Controls.Add(this.MenuButton);
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.MaximumSize = new System.Drawing.Size(85, 176);
            this.MenuPanel.MinimumSize = new System.Drawing.Size(85, 23);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(85, 23);
            this.MenuPanel.TabIndex = 7;
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(3, 29);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(78, 32);
            this.PauseButton.TabIndex = 1;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButtonClicked);
            // 
            // SoundButton
            // 
            this.SoundButton.Location = new System.Drawing.Point(3, 67);
            this.SoundButton.Name = "SoundButton";
            this.SoundButton.Size = new System.Drawing.Size(78, 48);
            this.SoundButton.TabIndex = 1;
            this.SoundButton.Text = "Turn Sound On/Off";
            this.SoundButton.UseVisualStyleBackColor = true;
            this.SoundButton.Click += new System.EventHandler(this.SoundButtonClicked);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(3, 121);
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
            this.MenuButton.Size = new System.Drawing.Size(85, 23);
            this.MenuButton.TabIndex = 0;
            this.MenuButton.Text = "Menu";
            this.MenuButton.UseVisualStyleBackColor = false;
            this.MenuButton.Click += new System.EventHandler(this.ToggleMenuOpen);
            // 
            // ColorMenuPanel
            // 
            this.ColorMenuPanel.BackColor = System.Drawing.Color.LightGray;
            this.ColorMenuPanel.Controls.Add(this.ShellUpButton);
            this.ColorMenuPanel.Controls.Add(this.ShellDownButton);
            this.ColorMenuPanel.Controls.Add(this.ShellLabel);
            this.ColorMenuPanel.Controls.Add(this.DesignUpButton);
            this.ColorMenuPanel.Controls.Add(this.DesignDownButton);
            this.ColorMenuPanel.Controls.Add(this.DesignLabel);
            this.ColorMenuPanel.Controls.Add(this.CrackUpButton);
            this.ColorMenuPanel.Controls.Add(this.CrackDownButton);
            this.ColorMenuPanel.Controls.Add(this.CrackLabel);
            this.ColorMenuPanel.Controls.Add(this.LogoUpButton);
            this.ColorMenuPanel.Controls.Add(this.LogoDownButton);
            this.ColorMenuPanel.Controls.Add(this.LogoLabel);
            this.ColorMenuPanel.Controls.Add(this.ABCUpButton);
            this.ColorMenuPanel.Controls.Add(this.ABCDownButton);
            this.ColorMenuPanel.Controls.Add(this.ABCLabel);
            this.ColorMenuPanel.Controls.Add(this.ColorMenuButton);
            this.ColorMenuPanel.Location = new System.Drawing.Point(164, 0);
            this.ColorMenuPanel.MaximumSize = new System.Drawing.Size(85, 151);
            this.ColorMenuPanel.MinimumSize = new System.Drawing.Size(85, 23);
            this.ColorMenuPanel.Name = "ColorMenuPanel";
            this.ColorMenuPanel.Size = new System.Drawing.Size(85, 23);
            this.ColorMenuPanel.TabIndex = 7;
            // 
            // ShellDownButton
            // 
            this.ShellDownButton.Location = new System.Drawing.Point(4, 27);
            this.ShellDownButton.Name = "ShellDownButton";
            this.ShellDownButton.Size = new System.Drawing.Size(17, 20);
            this.ShellDownButton.TabIndex = 1;
            this.ShellDownButton.Text = "<";
            this.ShellDownButton.UseVisualStyleBackColor = true;
            this.ShellDownButton.Click += new System.EventHandler(this.ShellDownButtonClicked);
            // 
            // ShellLabel
            // 
            this.ShellLabel.Location = new System.Drawing.Point(22, 30);
            this.ShellLabel.Name = "ShellLabel";
            this.ShellLabel.Text = "Shell";
            // 
            // ShellUpButton
            // 
            this.ShellUpButton.Location = new System.Drawing.Point(65, 27);
            this.ShellUpButton.Name = "ShellUpButton";
            this.ShellUpButton.Size = new System.Drawing.Size(17, 20);
            this.ShellUpButton.TabIndex = 1;
            this.ShellUpButton.Text = ">";
            this.ShellUpButton.UseVisualStyleBackColor = true;
            this.ShellUpButton.Click += new System.EventHandler(this.ShellUpButtonClicked);

            // 
            // DesignDownButton
            // 
            this.DesignDownButton.Location = new System.Drawing.Point(4, 52);
            this.DesignDownButton.Name = "DesignDownButton";
            this.DesignDownButton.Size = new System.Drawing.Size(17, 20);
            this.DesignDownButton.TabIndex = 1;
            this.DesignDownButton.Text = "<";
            this.DesignDownButton.UseVisualStyleBackColor = true;
            this.DesignDownButton.Click += new System.EventHandler(this.DesignDownButtonClicked);
            // 
            // DesignLabel
            // 
            this.DesignLabel.Location = new System.Drawing.Point(22, 55);
            this.DesignLabel.Name = "DesignLabel";
            this.DesignLabel.Text = "Design";
            // 
            // DesignUpButton
            // 
            this.DesignUpButton.Location = new System.Drawing.Point(65, 52);
            this.DesignUpButton.Name = "DesignUpButton";
            this.DesignUpButton.Size = new System.Drawing.Size(17, 20);
            this.DesignUpButton.TabIndex = 1;
            this.DesignUpButton.Text = ">";
            this.DesignUpButton.UseVisualStyleBackColor = true;
            this.DesignUpButton.Click += new System.EventHandler(this.DesignUpButtonClicked);

            // 
            // CrackDownButton
            // 
            this.CrackDownButton.Location = new System.Drawing.Point(4, 77);
            this.CrackDownButton.Name = "CrackDownButton";
            this.CrackDownButton.Size = new System.Drawing.Size(17, 20);
            this.CrackDownButton.TabIndex = 1;
            this.CrackDownButton.Text = "<";
            this.CrackDownButton.UseVisualStyleBackColor = true;
            this.CrackDownButton.Click += new System.EventHandler(this.CrackDownButtonClicked);
            // 
            // CrackLabel
            // 
            this.CrackLabel.Location = new System.Drawing.Point(22, 80);
            this.CrackLabel.Name = "CrackLabel";
            this.CrackLabel.Text = "Crack";
            // 
            // CrackUpButton
            // 
            this.CrackUpButton.Location = new System.Drawing.Point(65, 77);
            this.CrackUpButton.Name = "CrackUpButton";
            this.CrackUpButton.Size = new System.Drawing.Size(17, 20);
            this.CrackUpButton.TabIndex = 1;
            this.CrackUpButton.Text = ">";
            this.CrackUpButton.UseVisualStyleBackColor = true;
            this.CrackUpButton.Click += new System.EventHandler(this.CrackUpButtonClicked);

            // 
            // LogoDownButton
            // 
            this.LogoDownButton.Location = new System.Drawing.Point(4, 102);
            this.LogoDownButton.Name = "LogoDownButton";
            this.LogoDownButton.Size = new System.Drawing.Size(17, 20);
            this.LogoDownButton.TabIndex = 1;
            this.LogoDownButton.Text = "<";
            this.LogoDownButton.UseVisualStyleBackColor = true;
            this.LogoDownButton.Click += new System.EventHandler(this.LogoDownButtonClicked);
            // 
            // LogoLabel
            // 
            this.LogoLabel.Location = new System.Drawing.Point(22, 105);
            this.LogoLabel.Name = "LogoLabel";
            this.LogoLabel.Text = "Logo";
            // 
            // LogoUpButton
            // 
            this.LogoUpButton.Location = new System.Drawing.Point(65, 102);
            this.LogoUpButton.Name = "LogoUpButton";
            this.LogoUpButton.Size = new System.Drawing.Size(17, 20);
            this.LogoUpButton.TabIndex = 1;
            this.LogoUpButton.Text = ">";
            this.LogoUpButton.UseVisualStyleBackColor = true;
            this.LogoUpButton.Click += new System.EventHandler(this.LogoUpButtonClicked);

            // 
            // ABCDownButton
            // 
            this.ABCDownButton.Location = new System.Drawing.Point(4, 127);
            this.ABCDownButton.Name = "ABCDownButton";
            this.ABCDownButton.Size = new System.Drawing.Size(17, 20);
            this.ABCDownButton.TabIndex = 1;
            this.ABCDownButton.Text = "<";
            this.ABCDownButton.UseVisualStyleBackColor = true;
            this.ABCDownButton.Click += new System.EventHandler(this.ABCDownButtonClicked);
            // 
            // ABCLabel
            // 
            this.ABCLabel.Location = new System.Drawing.Point(22, 130);
            this.ABCLabel.Name = "ABCLabel";
            this.ABCLabel.Text = "Button";
            // 
            // ABCUpButton
            // 
            this.ABCUpButton.Location = new System.Drawing.Point(65, 127);
            this.ABCUpButton.Name = "ABCUpButton";
            this.ABCUpButton.Size = new System.Drawing.Size(17, 20);
            this.ABCUpButton.TabIndex = 1;
            this.ABCUpButton.Text = ">";
            this.ABCUpButton.UseVisualStyleBackColor = true;
            this.ABCUpButton.Click += new System.EventHandler(this.ABCUpButtonClicked);

            // 
            // ColorMenuButton
            // 
            this.ColorMenuButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ColorMenuButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ColorMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColorMenuButton.Location = new System.Drawing.Point(175, 0);
            this.ColorMenuButton.Name = "ColorMenuButton";
            this.ColorMenuButton.Size = new System.Drawing.Size(85, 23);
            this.ColorMenuButton.TabIndex = 0;
            this.ColorMenuButton.Text = "Colors";
            this.ColorMenuButton.UseVisualStyleBackColor = false;
            this.ColorMenuButton.Click += new System.EventHandler(this.ToggleColorMenuOpen);
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
            this.Controls.Add(this.ColorMenuPanel);
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
            this.ColorMenuPanel.ResumeLayout(false);
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
        private Button ResetButton;
        private Button MenuButton;
        private Button PauseButton;
        private Button SoundButton;
        private Panel ColorMenuPanel;
        private Label ShellLabel;
        private Button ShellUpButton;
        private Button ShellDownButton;
        private Label DesignLabel;
        private Button DesignUpButton;
        private Button DesignDownButton;
        private Label CrackLabel;
        private Button CrackUpButton;
        private Button CrackDownButton;
        private Label LogoLabel;
        private Button LogoUpButton;
        private Button LogoDownButton;
        private Label ABCLabel;
        private Button ABCUpButton;
        private Button ABCDownButton;
        private Button ColorMenuButton;
        private System.Windows.Forms.Timer GameTimer;
    }
}