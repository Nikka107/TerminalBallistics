namespace Terminal_Ballistics
{
    partial class FrmInCond
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInCond));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbVel = new System.Windows.Forms.TextBox();
            this.tbPhi = new System.Windows.Forms.TextBox();
            this.tbDelta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAlpha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.gbIC = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbdelta0d = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbnu0d = new System.Windows.Forms.TextBox();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.tbDV = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_nx = new System.Windows.Forms.TextBox();
            this.tb_nalpha = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьНУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьНУКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.загрузитьНУToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.picBoxInitCond = new System.Windows.Forms.PictureBox();
            this.picBoxTickIC = new System.Windows.Forms.PictureBox();
            this.gbIC.SuspendLayout();
            this.gbControls.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxInitCond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTickIC)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "V0, м/с:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(487, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "φ. , 1/c:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbVel
            // 
            this.tbVel.Location = new System.Drawing.Point(10, 44);
            this.tbVel.Name = "tbVel";
            this.tbVel.Size = new System.Drawing.Size(75, 20);
            this.tbVel.TabIndex = 1;
            this.tbVel.Text = "500,0";
            this.tbVel.TextChanged += new System.EventHandler(this.tbVel_TextChanged);
            this.tbVel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVel_KeyPress);
            this.tbVel.Leave += new System.EventHandler(this.tbVel_Leave);
            this.tbVel.Validating += new System.ComponentModel.CancelEventHandler(this.tbVel_Validating);
            this.tbVel.Validated += new System.EventHandler(this.tbVel_Validated);
            // 
            // tbPhi
            // 
            this.tbPhi.Location = new System.Drawing.Point(490, 44);
            this.tbPhi.Name = "tbPhi";
            this.tbPhi.Size = new System.Drawing.Size(75, 20);
            this.tbPhi.TabIndex = 7;
            this.tbPhi.Text = "0,0";
            this.tbPhi.TextChanged += new System.EventHandler(this.tbVel_TextChanged);
            this.tbPhi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVel_KeyPress);
            this.tbPhi.Leave += new System.EventHandler(this.tbPhi_Leave);
            // 
            // tbDelta
            // 
            this.tbDelta.Location = new System.Drawing.Point(170, 44);
            this.tbDelta.Name = "tbDelta";
            this.tbDelta.Size = new System.Drawing.Size(75, 20);
            this.tbDelta.TabIndex = 3;
            this.tbDelta.Text = "0,0";
            this.tbDelta.TextChanged += new System.EventHandler(this.tbVel_TextChanged);
            this.tbDelta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVel_KeyPress);
            this.tbDelta.Leave += new System.EventHandler(this.tbDelta_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(87, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "αν, град:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbAlpha
            // 
            this.tbAlpha.Location = new System.Drawing.Point(90, 44);
            this.tbAlpha.Name = "tbAlpha";
            this.tbAlpha.Size = new System.Drawing.Size(75, 20);
            this.tbAlpha.TabIndex = 2;
            this.tbAlpha.Text = "10,0";
            this.tbAlpha.TextChanged += new System.EventHandler(this.tbVel_TextChanged);
            this.tbAlpha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVel_KeyPress);
            this.tbAlpha.Leave += new System.EventHandler(this.tbAlpha_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(167, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "δ0, град:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tbNu
            // 
            this.tbNu.Location = new System.Drawing.Point(250, 44);
            this.tbNu.Name = "tbNu";
            this.tbNu.Size = new System.Drawing.Size(75, 20);
            this.tbNu.TabIndex = 4;
            this.tbNu.Text = "0,0";
            this.tbNu.TextChanged += new System.EventHandler(this.tbVel_TextChanged);
            this.tbNu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVel_KeyPress);
            this.tbNu.Leave += new System.EventHandler(this.tbNu_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(247, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "ν0, град:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(409, 290);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 27);
            this.btnAccept.TabIndex = 9;
            this.btnAccept.Text = "Принять";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.Enabled = false;
            this.btnDone.Location = new System.Drawing.Point(490, 290);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 27);
            this.btnDone.TabIndex = 10;
            this.btnDone.Text = "Готово";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbIC
            // 
            this.gbIC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbIC.Controls.Add(this.label18);
            this.gbIC.Controls.Add(this.tbdelta0d);
            this.gbIC.Controls.Add(this.label16);
            this.gbIC.Controls.Add(this.tbnu0d);
            this.gbIC.Controls.Add(this.tbVel);
            this.gbIC.Controls.Add(this.label2);
            this.gbIC.Controls.Add(this.label1);
            this.gbIC.Controls.Add(this.tbPhi);
            this.gbIC.Controls.Add(this.tbNu);
            this.gbIC.Controls.Add(this.label4);
            this.gbIC.Controls.Add(this.label5);
            this.gbIC.Controls.Add(this.tbAlpha);
            this.gbIC.Controls.Add(this.tbDelta);
            this.gbIC.Controls.Add(this.label3);
            this.gbIC.Location = new System.Drawing.Point(0, 323);
            this.gbIC.Name = "gbIC";
            this.gbIC.Size = new System.Drawing.Size(584, 80);
            this.gbIC.TabIndex = 0;
            this.gbIC.TabStop = false;
            this.gbIC.Text = "Начальные условия";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.Color.Blue;
            this.label18.Location = new System.Drawing.Point(407, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "δ0. , 1/c:";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // tbdelta0d
            // 
            this.tbdelta0d.Location = new System.Drawing.Point(410, 44);
            this.tbdelta0d.Name = "tbdelta0d";
            this.tbdelta0d.Size = new System.Drawing.Size(75, 20);
            this.tbdelta0d.TabIndex = 6;
            this.tbdelta0d.Text = "0,0";
            this.tbdelta0d.TextChanged += new System.EventHandler(this.tbVel_TextChanged);
            this.tbdelta0d.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVel_KeyPress);
            this.tbdelta0d.Leave += new System.EventHandler(this.tbdelta0d_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(328, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "ν0. , 1/c:";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // tbnu0d
            // 
            this.tbnu0d.Location = new System.Drawing.Point(330, 44);
            this.tbnu0d.Name = "tbnu0d";
            this.tbnu0d.Size = new System.Drawing.Size(75, 20);
            this.tbnu0d.TabIndex = 5;
            this.tbnu0d.Text = "0,0";
            this.tbnu0d.TextChanged += new System.EventHandler(this.tbVel_TextChanged);
            this.tbnu0d.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVel_KeyPress);
            this.tbnu0d.Leave += new System.EventHandler(this.tbnu0d_Leave);
            // 
            // gbControls
            // 
            this.gbControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbControls.Controls.Add(this.tbDV);
            this.gbControls.Controls.Add(this.label8);
            this.gbControls.Controls.Add(this.tb_nx);
            this.gbControls.Controls.Add(this.tb_nalpha);
            this.gbControls.Controls.Add(this.label7);
            this.gbControls.Controls.Add(this.label6);
            this.gbControls.Location = new System.Drawing.Point(0, 409);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(584, 80);
            this.gbControls.TabIndex = 12;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Управляющие параметры для расчёта";
            // 
            // tbDV
            // 
            this.tbDV.Location = new System.Drawing.Point(171, 44);
            this.tbDV.Name = "tbDV";
            this.tbDV.Size = new System.Drawing.Size(75, 20);
            this.tbDV.TabIndex = 13;
            this.tbDV.Text = "0,005";
            this.tbDV.TextChanged += new System.EventHandler(this.tbVel_TextChanged);
            this.tbDV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVel_KeyPress);
            this.tbDV.Leave += new System.EventHandler(this.tbDV_Leave);
            this.tbDV.Validating += new System.ComponentModel.CancelEventHandler(this.tbDV_Validating);
            this.tbDV.Validated += new System.EventHandler(this.tbDV_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(168, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "ΔVост";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // tb_nx
            // 
            this.tb_nx.Location = new System.Drawing.Point(90, 44);
            this.tb_nx.Name = "tb_nx";
            this.tb_nx.Size = new System.Drawing.Size(75, 20);
            this.tb_nx.TabIndex = 11;
            this.tb_nx.Text = "5";
            this.tb_nx.TextChanged += new System.EventHandler(this.tbVel_TextChanged);
            this.tb_nx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nalpha_KeyPress);
            this.tb_nx.Leave += new System.EventHandler(this.tb_nx_Leave);
            this.tb_nx.Validating += new System.ComponentModel.CancelEventHandler(this.tb_nx_Validating);
            this.tb_nx.Validated += new System.EventHandler(this.tb_nx_Validated);
            // 
            // tb_nalpha
            // 
            this.tb_nalpha.Location = new System.Drawing.Point(10, 44);
            this.tb_nalpha.Name = "tb_nalpha";
            this.tb_nalpha.Size = new System.Drawing.Size(75, 20);
            this.tb_nalpha.TabIndex = 10;
            this.tb_nalpha.Text = "16";
            this.tb_nalpha.TextChanged += new System.EventHandler(this.tbVel_TextChanged);
            this.tb_nalpha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_nalpha_KeyPress);
            this.tb_nalpha.Leave += new System.EventHandler(this.tb_nalpha_Leave);
            this.tb_nalpha.Validating += new System.ComponentModel.CancelEventHandler(this.tb_nalpha_Validating);
            this.tb_nalpha.Validated += new System.EventHandler(this.tb_nalpha_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(87, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "n*dx на ГЧ";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(12, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "dα:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьНУToolStripMenuItem,
            this.сохранитьНУКакToolStripMenuItem,
            this.toolStripMenuItem1,
            this.загрузитьНУToolStripMenuItem,
            this.toolStripMenuItem2,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьНУToolStripMenuItem
            // 
            this.сохранитьНУToolStripMenuItem.Name = "сохранитьНУToolStripMenuItem";
            this.сохранитьНУToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.сохранитьНУToolStripMenuItem.Text = "Сохранить НУ";
            // 
            // сохранитьНУКакToolStripMenuItem
            // 
            this.сохранитьНУКакToolStripMenuItem.Name = "сохранитьНУКакToolStripMenuItem";
            this.сохранитьНУКакToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.сохранитьНУКакToolStripMenuItem.Text = "Сохранить НУ как...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // загрузитьНУToolStripMenuItem
            // 
            this.загрузитьНУToolStripMenuItem.Name = "загрузитьНУToolStripMenuItem";
            this.загрузитьНУToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.загрузитьНУToolStripMenuItem.Text = "Загрузить НУ";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(178, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 500);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(584, 22);
            this.statusStrip.TabIndex = 21;
            this.statusStrip.Text = "statusStrip1";
            // 
            // picBoxInitCond
            // 
            this.picBoxInitCond.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxInitCond.Image = ((System.Drawing.Image)(resources.GetObject("picBoxInitCond.Image")));
            this.picBoxInitCond.Location = new System.Drawing.Point(0, 27);
            this.picBoxInitCond.Name = "picBoxInitCond";
            this.picBoxInitCond.Size = new System.Drawing.Size(325, 290);
            this.picBoxInitCond.TabIndex = 22;
            this.picBoxInitCond.TabStop = false;
            // 
            // picBoxTickIC
            // 
            this.picBoxTickIC.Image = ((System.Drawing.Image)(resources.GetObject("picBoxTickIC.Image")));
            this.picBoxTickIC.InitialImage = null;
            this.picBoxTickIC.Location = new System.Drawing.Point(379, 290);
            this.picBoxTickIC.Name = "picBoxTickIC";
            this.picBoxTickIC.Size = new System.Drawing.Size(24, 27);
            this.picBoxTickIC.TabIndex = 38;
            this.picBoxTickIC.TabStop = false;
            // 
            // FrmInCond
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 522);
            this.Controls.Add(this.picBoxTickIC);
            this.Controls.Add(this.picBoxInitCond);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gbControls);
            this.Controls.Add(this.gbIC);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnAccept);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 560);
            this.Name = "FrmInCond";
            this.Text = "FrmInCond";
            this.gbIC.ResumeLayout(false);
            this.gbIC.PerformLayout();
            this.gbControls.ResumeLayout(false);
            this.gbControls.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxInitCond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTickIC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbVel;
        private System.Windows.Forms.TextBox tbPhi;
        private System.Windows.Forms.TextBox tbDelta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAlpha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.GroupBox gbIC;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.TextBox tb_nx;
        private System.Windows.Forms.TextBox tb_nalpha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbdelta0d;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbnu0d;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьНУToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьНУКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem загрузитьНУToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.PictureBox picBoxInitCond;
        private System.Windows.Forms.TextBox tbDV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox picBoxTickIC;
    }
}