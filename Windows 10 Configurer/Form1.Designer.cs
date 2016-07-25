namespace Windows_10_Configurer
{
    partial class Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OptionsList = new System.Windows.Forms.CheckedListBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.ReinstallButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Windows 10 Configurer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(334, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "By William Venner (@ven_ner)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OptionsList
            // 
            this.OptionsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.OptionsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OptionsList.ForeColor = System.Drawing.Color.White;
            this.OptionsList.FormattingEnabled = true;
            this.OptionsList.Items.AddRange(new object[] {
            "Install Windows Photo Viewer"});
            this.OptionsList.Location = new System.Drawing.Point(12, 100);
            this.OptionsList.Name = "OptionsList";
            this.OptionsList.Size = new System.Drawing.Size(310, 255);
            this.OptionsList.TabIndex = 2;
            this.OptionsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OptionsList_ItemCheck);
            this.OptionsList.Click += new System.EventHandler(this.OptionsList_Click);
            // 
            // GoButton
            // 
            this.GoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GoButton.BackColor = System.Drawing.Color.Green;
            this.GoButton.Enabled = false;
            this.GoButton.FlatAppearance.BorderSize = 0;
            this.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoButton.ForeColor = System.Drawing.Color.White;
            this.GoButton.Location = new System.Drawing.Point(12, 419);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(310, 30);
            this.GoButton.TabIndex = 3;
            this.GoButton.Text = "Go";
            this.GoButton.UseVisualStyleBackColor = false;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // ReinstallButton
            // 
            this.ReinstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ReinstallButton.BackColor = System.Drawing.Color.Green;
            this.ReinstallButton.FlatAppearance.BorderSize = 0;
            this.ReinstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReinstallButton.ForeColor = System.Drawing.Color.White;
            this.ReinstallButton.Location = new System.Drawing.Point(12, 372);
            this.ReinstallButton.Name = "ReinstallButton";
            this.ReinstallButton.Size = new System.Drawing.Size(310, 30);
            this.ReinstallButton.TabIndex = 4;
            this.ReinstallButton.Text = "Reinstall all apps";
            this.ReinstallButton.UseVisualStyleBackColor = false;
            this.ReinstallButton.Click += new System.EventHandler(this.ReinstallButton_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(334, 461);
            this.Controls.Add(this.ReinstallButton);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.OptionsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 500);
            this.MinimumSize = new System.Drawing.Size(350, 500);
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows 10 Configurer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox OptionsList;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Button ReinstallButton;
    }
}

