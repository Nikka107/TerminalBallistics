namespace Terminal_Ballistics
{
    partial class FrmObstacle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObstacle));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbObsA = new System.Windows.Forms.TextBox();
            this.tbObsB = new System.Windows.Forms.TextBox();
            this.tbObsC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbObsMu = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbObsh = new System.Windows.Forms.TextBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьПреградуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьИзБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьФайлПреградыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьВБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbObstacle = new System.Windows.Forms.ListBox();
            this.gbStressEquasions = new System.Windows.Forms.GroupBox();
            this.picBoxTickObstacle = new System.Windows.Forms.PictureBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbPart = new System.Windows.Forms.Label();
            this.tbObsD = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.bnNewLayer = new System.Windows.Forms.Button();
            this.gbPhysChars = new System.Windows.Forms.GroupBox();
            this.btnCoeffCount = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbAlpha = new System.Windows.Forms.TextBox();
            this.tbMuv = new System.Windows.Forms.TextBox();
            this.tbY0 = new System.Windows.Forms.TextBox();
            this.tbG = new System.Windows.Forms.TextBox();
            this.tbRo = new System.Windows.Forms.TextBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.tbObsFullH = new System.Windows.Forms.TextBox();
            this.lbObsFullH = new System.Windows.Forms.Label();
            this.chartObstacle = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            this.gbStressEquasions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTickObstacle)).BeginInit();
            this.gbPhysChars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartObstacle)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tbObsA
            // 
            this.tbObsA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbObsA.Location = new System.Drawing.Point(202, 80);
            this.tbObsA.Name = "tbObsA";
            this.tbObsA.Size = new System.Drawing.Size(75, 20);
            this.tbObsA.TabIndex = 3;
            this.tbObsA.Text = "469,0";
            this.tbObsA.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbObsA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbObsA_KeyPress);
            this.tbObsA.Leave += new System.EventHandler(this.tbObsA_Leave);
            // 
            // tbObsB
            // 
            this.tbObsB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbObsB.Location = new System.Drawing.Point(282, 80);
            this.tbObsB.Name = "tbObsB";
            this.tbObsB.Size = new System.Drawing.Size(75, 20);
            this.tbObsB.TabIndex = 4;
            this.tbObsB.Text = "0,0";
            this.tbObsB.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbObsB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbObsA_KeyPress);
            this.tbObsB.Leave += new System.EventHandler(this.tbObsB_Leave);
            // 
            // tbObsC
            // 
            this.tbObsC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbObsC.BackColor = System.Drawing.SystemColors.Window;
            this.tbObsC.Location = new System.Drawing.Point(362, 80);
            this.tbObsC.Name = "tbObsC";
            this.tbObsC.Size = new System.Drawing.Size(75, 20);
            this.tbObsC.TabIndex = 5;
            this.tbObsC.Text = "3430000,0";
            this.tbObsC.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbObsC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbObsA_KeyPress);
            this.tbObsC.Leave += new System.EventHandler(this.tbObsC_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(202, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "A, кг/м3:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(279, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "B, Па*с/м:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(359, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "C, Па:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(519, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "μ:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tbObsMu
            // 
            this.tbObsMu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbObsMu.Location = new System.Drawing.Point(522, 80);
            this.tbObsMu.Name = "tbObsMu";
            this.tbObsMu.Size = new System.Drawing.Size(75, 20);
            this.tbObsMu.TabIndex = 7;
            this.tbObsMu.Text = "0,2";
            this.tbObsMu.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbObsMu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbObsA_KeyPress);
            this.tbObsMu.Leave += new System.EventHandler(this.tbObsMu_Leave);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(520, 20);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 27);
            this.btnAccept.TabIndex = 9;
            this.btnAccept.Text = "Принять";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(600, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "h, м:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tbObsh
            // 
            this.tbObsh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbObsh.Location = new System.Drawing.Point(600, 80);
            this.tbObsh.Name = "tbObsh";
            this.tbObsh.Size = new System.Drawing.Size(75, 20);
            this.tbObsh.TabIndex = 8;
            this.tbObsh.Text = "10,0";
            this.tbObsh.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbObsh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbObsA_KeyPress);
            this.tbObsh.Leave += new System.EventHandler(this.tbObsh_Leave);
            this.tbObsh.Validating += new System.ComponentModel.CancelEventHandler(this.tbObsh_Validating);
            this.tbObsh.Validated += new System.EventHandler(this.tbObsh_Validated);
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.Enabled = false;
            this.btnDone.Location = new System.Drawing.Point(600, 20);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 27);
            this.btnDone.TabIndex = 0;
            this.btnDone.Text = "Готово";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnColse_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(864, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьПреградуToolStripMenuItem,
            this.загрузитьИзБДToolStripMenuItem,
            this.toolStripMenuItem1,
            this.сохранитьФайлПреградыToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.сохранитьВБДToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьПреградуToolStripMenuItem
            // 
            this.загрузитьПреградуToolStripMenuItem.Name = "загрузитьПреградуToolStripMenuItem";
            this.загрузитьПреградуToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.загрузитьПреградуToolStripMenuItem.Text = "Загрузить преграду...";
            // 
            // загрузитьИзБДToolStripMenuItem
            // 
            this.загрузитьИзБДToolStripMenuItem.Name = "загрузитьИзБДToolStripMenuItem";
            this.загрузитьИзБДToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.загрузитьИзБДToolStripMenuItem.Text = "Импортировать из БД...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(217, 6);
            // 
            // сохранитьФайлПреградыToolStripMenuItem
            // 
            this.сохранитьФайлПреградыToolStripMenuItem.Name = "сохранитьФайлПреградыToolStripMenuItem";
            this.сохранитьФайлПреградыToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.сохранитьФайлПреградыToolStripMenuItem.Text = "Сохранить файл преграды";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            // 
            // сохранитьВБДToolStripMenuItem
            // 
            this.сохранитьВБДToolStripMenuItem.Name = "сохранитьВБДToolStripMenuItem";
            this.сохранитьВБДToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.сохранитьВБДToolStripMenuItem.Text = "Экспортировать в БД...";
            // 
            // lbObstacle
            // 
            this.lbObstacle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbObstacle.FormattingEnabled = true;
            this.lbObstacle.Location = new System.Drawing.Point(689, 247);
            this.lbObstacle.Name = "lbObstacle";
            this.lbObstacle.Size = new System.Drawing.Size(175, 290);
            this.lbObstacle.TabIndex = 22;
            this.lbObstacle.SelectedIndexChanged += new System.EventHandler(this.lbObstacle_SelectedIndexChanged);
            // 
            // gbStressEquasions
            // 
            this.gbStressEquasions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStressEquasions.Controls.Add(this.picBoxTickObstacle);
            this.gbStressEquasions.Controls.Add(this.tbName);
            this.gbStressEquasions.Controls.Add(this.lbPart);
            this.gbStressEquasions.Controls.Add(this.tbObsD);
            this.gbStressEquasions.Controls.Add(this.lbID);
            this.gbStressEquasions.Controls.Add(this.tbID);
            this.gbStressEquasions.Controls.Add(this.label8);
            this.gbStressEquasions.Controls.Add(this.btnRemove);
            this.gbStressEquasions.Controls.Add(this.label1);
            this.gbStressEquasions.Controls.Add(this.tbObsA);
            this.gbStressEquasions.Controls.Add(this.tbObsB);
            this.gbStressEquasions.Controls.Add(this.btnDone);
            this.gbStressEquasions.Controls.Add(this.btnAccept);
            this.gbStressEquasions.Controls.Add(this.tbObsh);
            this.gbStressEquasions.Controls.Add(this.bnNewLayer);
            this.gbStressEquasions.Controls.Add(this.tbObsC);
            this.gbStressEquasions.Controls.Add(this.label5);
            this.gbStressEquasions.Controls.Add(this.label2);
            this.gbStressEquasions.Controls.Add(this.label3);
            this.gbStressEquasions.Controls.Add(this.label4);
            this.gbStressEquasions.Controls.Add(this.tbObsMu);
            this.gbStressEquasions.Location = new System.Drawing.Point(1, 245);
            this.gbStressEquasions.Name = "gbStressEquasions";
            this.gbStressEquasions.Size = new System.Drawing.Size(680, 110);
            this.gbStressEquasions.TabIndex = 0;
            this.gbStressEquasions.TabStop = false;
            this.gbStressEquasions.Text = "Коэффициенты в уравнениях напряжений и толщина слоя преграды";
            // 
            // picBoxTickObstacle
            // 
            this.picBoxTickObstacle.Image = ((System.Drawing.Image)(resources.GetObject("picBoxTickObstacle.Image")));
            this.picBoxTickObstacle.InitialImage = null;
            this.picBoxTickObstacle.Location = new System.Drawing.Point(170, 20);
            this.picBoxTickObstacle.Name = "picBoxTickObstacle";
            this.picBoxTickObstacle.Size = new System.Drawing.Size(24, 27);
            this.picBoxTickObstacle.TabIndex = 37;
            this.picBoxTickObstacle.TabStop = false;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(90, 80);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(75, 20);
            this.tbName.TabIndex = 2;
            this.tbName.Text = "Грунт";
            this.tbName.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbName.Validating += new System.ComponentModel.CancelEventHandler(this.tbName_Validating);
            this.tbName.Validated += new System.EventHandler(this.tbName_Validated);
            // 
            // lbPart
            // 
            this.lbPart.AutoSize = true;
            this.lbPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPart.Location = new System.Drawing.Point(87, 60);
            this.lbPart.Name = "lbPart";
            this.lbPart.Size = new System.Drawing.Size(86, 13);
            this.lbPart.TabIndex = 35;
            this.lbPart.Text = "Наименование:";
            // 
            // tbObsD
            // 
            this.tbObsD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbObsD.Location = new System.Drawing.Point(442, 80);
            this.tbObsD.Name = "tbObsD";
            this.tbObsD.Size = new System.Drawing.Size(75, 20);
            this.tbObsD.TabIndex = 6;
            this.tbObsD.Text = "0,0";
            this.tbObsD.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbObsD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbObsA_KeyPress);
            this.tbObsD.Leave += new System.EventHandler(this.tbObsD_Leave);
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbID.ForeColor = System.Drawing.Color.Blue;
            this.lbID.Location = new System.Drawing.Point(10, 60);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(21, 13);
            this.lbID.TabIndex = 34;
            this.lbID.Text = "ID:";
            this.lbID.Click += new System.EventHandler(this.lbID_Click);
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(10, 80);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(75, 20);
            this.tbID.TabIndex = 1;
            this.tbID.Text = "1";
            this.tbID.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbID_KeyPress);
            this.tbID.Leave += new System.EventHandler(this.tbID_Leave);
            this.tbID.Validating += new System.ComponentModel.CancelEventHandler(this.tbID_Validating);
            this.tbID.Validated += new System.EventHandler(this.tbID_Validated);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(439, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "D:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemove.Location = new System.Drawing.Point(440, 20);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 27);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // bnNewLayer
            // 
            this.bnNewLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bnNewLayer.Location = new System.Drawing.Point(10, 20);
            this.bnNewLayer.Name = "bnNewLayer";
            this.bnNewLayer.Size = new System.Drawing.Size(155, 27);
            this.bnNewLayer.TabIndex = 0;
            this.bnNewLayer.Text = "Добавить новый слой";
            this.bnNewLayer.UseVisualStyleBackColor = true;
            this.bnNewLayer.Click += new System.EventHandler(this.bnNewLayer_Click);
            // 
            // gbPhysChars
            // 
            this.gbPhysChars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPhysChars.Controls.Add(this.btnCoeffCount);
            this.gbPhysChars.Controls.Add(this.label6);
            this.gbPhysChars.Controls.Add(this.label7);
            this.gbPhysChars.Controls.Add(this.label9);
            this.gbPhysChars.Controls.Add(this.label10);
            this.gbPhysChars.Controls.Add(this.label11);
            this.gbPhysChars.Controls.Add(this.tbAlpha);
            this.gbPhysChars.Controls.Add(this.tbMuv);
            this.gbPhysChars.Controls.Add(this.tbY0);
            this.gbPhysChars.Controls.Add(this.tbG);
            this.gbPhysChars.Controls.Add(this.tbRo);
            this.gbPhysChars.Location = new System.Drawing.Point(1, 360);
            this.gbPhysChars.Name = "gbPhysChars";
            this.gbPhysChars.Size = new System.Drawing.Size(680, 80);
            this.gbPhysChars.TabIndex = 10;
            this.gbPhysChars.TabStop = false;
            this.gbPhysChars.Text = "Вычисление коэффициентов по физико-механическим характеристикам преграды";
            // 
            // btnCoeffCount
            // 
            this.btnCoeffCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCoeffCount.Location = new System.Drawing.Point(522, 39);
            this.btnCoeffCount.Name = "btnCoeffCount";
            this.btnCoeffCount.Size = new System.Drawing.Size(153, 27);
            this.btnCoeffCount.TabIndex = 15;
            this.btnCoeffCount.Text = "Подобрать коэффициенты";
            this.btnCoeffCount.UseVisualStyleBackColor = true;
            this.btnCoeffCount.Click += new System.EventHandler(this.btnRecount_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(247, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "μв:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(10, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "ρ, кг/м3:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(87, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "G, МПа:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(167, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Y0, МПа:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(327, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "α:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // tbAlpha
            // 
            this.tbAlpha.Location = new System.Drawing.Point(330, 46);
            this.tbAlpha.Name = "tbAlpha";
            this.tbAlpha.Size = new System.Drawing.Size(75, 20);
            this.tbAlpha.TabIndex = 14;
            this.tbAlpha.Text = "0,0";
            this.tbAlpha.TextChanged += new System.EventHandler(this.tbRo_TextChanged);
            this.tbAlpha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbObsA_KeyPress);
            this.tbAlpha.Leave += new System.EventHandler(this.tbAlpha_Leave);
            // 
            // tbMuv
            // 
            this.tbMuv.Location = new System.Drawing.Point(250, 46);
            this.tbMuv.Name = "tbMuv";
            this.tbMuv.Size = new System.Drawing.Size(75, 20);
            this.tbMuv.TabIndex = 13;
            this.tbMuv.Text = "0,0";
            this.tbMuv.TextChanged += new System.EventHandler(this.tbRo_TextChanged);
            this.tbMuv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbObsA_KeyPress);
            this.tbMuv.Leave += new System.EventHandler(this.tbMuv_Leave);
            // 
            // tbY0
            // 
            this.tbY0.Location = new System.Drawing.Point(170, 46);
            this.tbY0.Name = "tbY0";
            this.tbY0.Size = new System.Drawing.Size(75, 20);
            this.tbY0.TabIndex = 12;
            this.tbY0.Text = "0,0";
            this.tbY0.TextChanged += new System.EventHandler(this.tbRo_TextChanged);
            this.tbY0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbObsA_KeyPress);
            this.tbY0.Leave += new System.EventHandler(this.tbY0_Leave);
            // 
            // tbG
            // 
            this.tbG.Location = new System.Drawing.Point(90, 46);
            this.tbG.Name = "tbG";
            this.tbG.Size = new System.Drawing.Size(75, 20);
            this.tbG.TabIndex = 11;
            this.tbG.Text = "0,0";
            this.tbG.TextChanged += new System.EventHandler(this.tbRo_TextChanged);
            this.tbG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbObsA_KeyPress);
            this.tbG.Leave += new System.EventHandler(this.tbG_Leave);
            // 
            // tbRo
            // 
            this.tbRo.Location = new System.Drawing.Point(10, 46);
            this.tbRo.Name = "tbRo";
            this.tbRo.Size = new System.Drawing.Size(75, 20);
            this.tbRo.TabIndex = 10;
            this.tbRo.Text = "0,0";
            this.tbRo.TextChanged += new System.EventHandler(this.tbRo_TextChanged);
            this.tbRo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbObsA_KeyPress);
            this.tbRo.Leave += new System.EventHandler(this.tbRo_Leave);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Location = new System.Drawing.Point(0, 540);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(864, 22);
            this.StatusStrip.TabIndex = 26;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // tbObsFullH
            // 
            this.tbObsFullH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbObsFullH.Location = new System.Drawing.Point(11, 468);
            this.tbObsFullH.Name = "tbObsFullH";
            this.tbObsFullH.ReadOnly = true;
            this.tbObsFullH.Size = new System.Drawing.Size(75, 20);
            this.tbObsFullH.TabIndex = 28;
            this.tbObsFullH.Text = "0";
            // 
            // lbObsFullH
            // 
            this.lbObsFullH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbObsFullH.AutoSize = true;
            this.lbObsFullH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbObsFullH.ForeColor = System.Drawing.Color.Blue;
            this.lbObsFullH.Location = new System.Drawing.Point(10, 446);
            this.lbObsFullH.Name = "lbObsFullH";
            this.lbObsFullH.Size = new System.Drawing.Size(32, 13);
            this.lbObsFullH.TabIndex = 27;
            this.lbObsFullH.Text = "H, м:";
            this.lbObsFullH.Click += new System.EventHandler(this.lbObsFullH_Click);
            // 
            // chartObstacle
            // 
            this.chartObstacle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartObstacle.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartObstacle.Legends.Add(legend1);
            this.chartObstacle.Location = new System.Drawing.Point(1, 27);
            this.chartObstacle.Name = "chartObstacle";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series1.Legend = "Legend1";
            series1.Name = "Преграда";
            this.chartObstacle.Series.Add(series1);
            this.chartObstacle.Size = new System.Drawing.Size(863, 212);
            this.chartObstacle.TabIndex = 29;
            this.chartObstacle.Text = "chart1";
            // 
            // FrmObstacle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 562);
            this.Controls.Add(this.chartObstacle);
            this.Controls.Add(this.tbObsFullH);
            this.Controls.Add(this.lbObsFullH);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.gbPhysChars);
            this.Controls.Add(this.gbStressEquasions);
            this.Controls.Add(this.lbObstacle);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "FrmObstacle";
            this.Text = "FrmObstacle";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbStressEquasions.ResumeLayout(false);
            this.gbStressEquasions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTickObstacle)).EndInit();
            this.gbPhysChars.ResumeLayout(false);
            this.gbPhysChars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartObstacle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tbObsA;
        private System.Windows.Forms.TextBox tbObsB;
        private System.Windows.Forms.TextBox tbObsC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbObsMu;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbObsh;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьПреградуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьФайлПреградыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьВБДToolStripMenuItem;
        private System.Windows.Forms.ListBox lbObstacle;
        private System.Windows.Forms.GroupBox gbStressEquasions;
        private System.Windows.Forms.GroupBox gbPhysChars;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button bnNewLayer;
        private System.Windows.Forms.TextBox tbObsD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbAlpha;
        private System.Windows.Forms.TextBox tbMuv;
        private System.Windows.Forms.TextBox tbY0;
        private System.Windows.Forms.TextBox tbG;
        private System.Windows.Forms.TextBox tbRo;
        private System.Windows.Forms.Button btnCoeffCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbPart;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.TextBox tbObsFullH;
        private System.Windows.Forms.Label lbObsFullH;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartObstacle;
        private System.Windows.Forms.PictureBox picBoxTickObstacle;
    }
}