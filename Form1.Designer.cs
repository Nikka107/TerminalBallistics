namespace Terminal_Ballistics
{
    partial class FMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMIAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.FLPButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBody = new System.Windows.Forms.Button();
            this.btnObstruct = new System.Windows.Forms.Button();
            this.btnInCond = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnPlot = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.lbBody = new System.Windows.Forms.Label();
            this.lbObstacle = new System.Windows.Forms.Label();
            this.lbIC = new System.Windows.Forms.Label();
            this.lbResults = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.picBoxTickBody = new System.Windows.Forms.PictureBox();
            this.picBoxTickObstacle = new System.Windows.Forms.PictureBox();
            this.picBoxTickIC = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.FLPButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTickBody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTickObstacle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTickIC)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIHelp,
            this.toolStripMenuItem1,
            this.TSMIAbout});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // TSMIHelp
            // 
            this.TSMIHelp.Name = "TSMIHelp";
            this.TSMIHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.TSMIHelp.Size = new System.Drawing.Size(240, 22);
            this.TSMIHelp.Text = "Руководство пользователя";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(237, 6);
            // 
            // TSMIAbout
            // 
            this.TSMIAbout.Name = "TSMIAbout";
            this.TSMIAbout.Size = new System.Drawing.Size(240, 22);
            this.TSMIAbout.Text = "О программе";
            this.TSMIAbout.Click += new System.EventHandler(this.TSMIAbout_Click);
            // 
            // FLPButtons
            // 
            this.FLPButtons.Controls.Add(this.btnBody);
            this.FLPButtons.Controls.Add(this.btnObstruct);
            this.FLPButtons.Controls.Add(this.btnInCond);
            this.FLPButtons.Controls.Add(this.btnRun);
            this.FLPButtons.Controls.Add(this.btnPlot);
            this.FLPButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLPButtons.Location = new System.Drawing.Point(0, 24);
            this.FLPButtons.Name = "FLPButtons";
            this.FLPButtons.Size = new System.Drawing.Size(107, 416);
            this.FLPButtons.TabIndex = 1;
            // 
            // btnBody
            // 
            this.btnBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBody.Location = new System.Drawing.Point(3, 3);
            this.btnBody.Name = "btnBody";
            this.btnBody.Size = new System.Drawing.Size(100, 45);
            this.btnBody.TabIndex = 0;
            this.btnBody.Text = "Тело";
            this.btnBody.UseVisualStyleBackColor = true;
            this.btnBody.Click += new System.EventHandler(this.btnBody_Click);
            // 
            // btnObstruct
            // 
            this.btnObstruct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnObstruct.Location = new System.Drawing.Point(3, 54);
            this.btnObstruct.Name = "btnObstruct";
            this.btnObstruct.Size = new System.Drawing.Size(100, 45);
            this.btnObstruct.TabIndex = 1;
            this.btnObstruct.Text = "Преграда";
            this.btnObstruct.UseVisualStyleBackColor = true;
            this.btnObstruct.Click += new System.EventHandler(this.btnObstruct_Click);
            // 
            // btnInCond
            // 
            this.btnInCond.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInCond.Location = new System.Drawing.Point(3, 105);
            this.btnInCond.Name = "btnInCond";
            this.btnInCond.Size = new System.Drawing.Size(100, 45);
            this.btnInCond.TabIndex = 2;
            this.btnInCond.Text = "Начальные условия";
            this.btnInCond.UseVisualStyleBackColor = true;
            this.btnInCond.Click += new System.EventHandler(this.btnInCond_Click);
            // 
            // btnRun
            // 
            this.btnRun.Enabled = false;
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRun.Location = new System.Drawing.Point(3, 156);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 45);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Запуск";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnPlot
            // 
            this.btnPlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlot.Location = new System.Drawing.Point(3, 207);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(100, 45);
            this.btnPlot.TabIndex = 3;
            this.btnPlot.Text = "Графики";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.Location = new System.Drawing.Point(0, 446);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(784, 90);
            this.rtbLog.TabIndex = 2;
            this.rtbLog.Text = "";
            // 
            // lbBody
            // 
            this.lbBody.AutoSize = true;
            this.lbBody.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBody.Location = new System.Drawing.Point(143, 42);
            this.lbBody.Name = "lbBody";
            this.lbBody.Size = new System.Drawing.Size(147, 16);
            this.lbBody.TabIndex = 3;
            this.lbBody.Text = "Информация о теле.";
            // 
            // lbObstacle
            // 
            this.lbObstacle.AutoSize = true;
            this.lbObstacle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbObstacle.Location = new System.Drawing.Point(143, 93);
            this.lbObstacle.Name = "lbObstacle";
            this.lbObstacle.Size = new System.Drawing.Size(177, 16);
            this.lbObstacle.TabIndex = 6;
            this.lbObstacle.Text = "Информация о преграде.";
            // 
            // lbIC
            // 
            this.lbIC.AutoSize = true;
            this.lbIC.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbIC.Location = new System.Drawing.Point(143, 144);
            this.lbIC.Name = "lbIC";
            this.lbIC.Size = new System.Drawing.Size(194, 16);
            this.lbIC.TabIndex = 7;
            this.lbIC.Text = "Вектор начальных условий: ";
            // 
            // lbResults
            // 
            this.lbResults.AutoSize = true;
            this.lbResults.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbResults.Location = new System.Drawing.Point(113, 246);
            this.lbResults.Name = "lbResults";
            this.lbResults.Size = new System.Drawing.Size(196, 16);
            this.lbResults.TabIndex = 8;
            this.lbResults.Text = "Информация о результатах.";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // picBoxTickBody
            // 
            this.picBoxTickBody.Image = ((System.Drawing.Image)(resources.GetObject("picBoxTickBody.Image")));
            this.picBoxTickBody.InitialImage = null;
            this.picBoxTickBody.Location = new System.Drawing.Point(113, 37);
            this.picBoxTickBody.Name = "picBoxTickBody";
            this.picBoxTickBody.Size = new System.Drawing.Size(24, 27);
            this.picBoxTickBody.TabIndex = 39;
            this.picBoxTickBody.TabStop = false;
            // 
            // picBoxTickObstacle
            // 
            this.picBoxTickObstacle.Image = ((System.Drawing.Image)(resources.GetObject("picBoxTickObstacle.Image")));
            this.picBoxTickObstacle.InitialImage = null;
            this.picBoxTickObstacle.Location = new System.Drawing.Point(113, 87);
            this.picBoxTickObstacle.Name = "picBoxTickObstacle";
            this.picBoxTickObstacle.Size = new System.Drawing.Size(24, 27);
            this.picBoxTickObstacle.TabIndex = 40;
            this.picBoxTickObstacle.TabStop = false;
            // 
            // picBoxTickIC
            // 
            this.picBoxTickIC.Image = ((System.Drawing.Image)(resources.GetObject("picBoxTickIC.Image")));
            this.picBoxTickIC.InitialImage = null;
            this.picBoxTickIC.Location = new System.Drawing.Point(113, 137);
            this.picBoxTickIC.Name = "picBoxTickIC";
            this.picBoxTickIC.Size = new System.Drawing.Size(24, 27);
            this.picBoxTickIC.TabIndex = 41;
            this.picBoxTickIC.TabStop = false;
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.picBoxTickIC);
            this.Controls.Add(this.picBoxTickObstacle);
            this.Controls.Add(this.picBoxTickBody);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbResults);
            this.Controls.Add(this.lbIC);
            this.Controls.Add(this.lbObstacle);
            this.Controls.Add(this.lbBody);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.FLPButtons);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FMain";
            this.Text = "Terminal Ballistics";
            this.Activated += new System.EventHandler(this.FMain_Activated);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.FLPButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTickBody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTickObstacle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTickIC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMIHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TSMIAbout;
        private System.Windows.Forms.FlowLayoutPanel FLPButtons;
        private System.Windows.Forms.Button btnBody;
        private System.Windows.Forms.Button btnObstruct;
        private System.Windows.Forms.Button btnInCond;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label lbBody;
        private System.Windows.Forms.Label lbObstacle;
        private System.Windows.Forms.Label lbIC;
        private System.Windows.Forms.Label lbResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox picBoxTickBody;
        private System.Windows.Forms.PictureBox picBoxTickObstacle;
        private System.Windows.Forms.PictureBox picBoxTickIC;
    }
}

