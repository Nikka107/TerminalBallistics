namespace Terminal_Ballistics
{
    partial class FrmBody
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBody));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnDone = new System.Windows.Forms.Button();
            this.gbMass = new System.Windows.Forms.GroupBox();
            this.picBoxTickStruct = new System.Windows.Forms.PictureBox();
            this.tbxc = new System.Windows.Forms.TextBox();
            this.tbJe = new System.Windows.Forms.TextBox();
            this.tbJp = new System.Windows.Forms.TextBox();
            this.tbm = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnStructSpecif = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tbFullLength = new System.Windows.Forms.TextBox();
            this.lbFullLength = new System.Windows.Forms.Label();
            this.gbElement = new System.Windows.Forms.GroupBox();
            this.picBoxTickBody = new System.Windows.Forms.PictureBox();
            this.tbd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lbR = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.lbd2 = new System.Windows.Forms.Label();
            this.lbd1 = new System.Windows.Forms.Label();
            this.lbPart = new System.Windows.Forms.Label();
            this.cbPart = new System.Windows.Forms.ComboBox();
            this.lbID = new System.Windows.Forms.Label();
            this.tbR = new System.Windows.Forms.TextBox();
            this.tbl = new System.Windows.Forms.TextBox();
            this.tbd2 = new System.Windows.Forms.TextBox();
            this.tbd1 = new System.Windows.Forms.TextBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnNewPart = new System.Windows.Forms.Button();
            this.lbParts = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveBody = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveBodyAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLoadBody = new System.Windows.Forms.ToolStripMenuItem();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.chartBodyDwg = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbJetEngine = new System.Windows.Forms.GroupBox();
            this.gbMass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTickStruct)).BeginInit();
            this.gbElement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTickBody)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBodyDwg)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.Enabled = false;
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDone.Location = new System.Drawing.Point(680, 20);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 27);
            this.btnDone.TabIndex = 0;
            this.btnDone.Text = "Готово";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbMass
            // 
            this.gbMass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbMass.Controls.Add(this.picBoxTickStruct);
            this.gbMass.Controls.Add(this.tbxc);
            this.gbMass.Controls.Add(this.tbJe);
            this.gbMass.Controls.Add(this.tbJp);
            this.gbMass.Controls.Add(this.tbm);
            this.gbMass.Controls.Add(this.label19);
            this.gbMass.Controls.Add(this.label16);
            this.gbMass.Controls.Add(this.btnStructSpecif);
            this.gbMass.Controls.Add(this.label17);
            this.gbMass.Controls.Add(this.label18);
            this.gbMass.Location = new System.Drawing.Point(3, 464);
            this.gbMass.Name = "gbMass";
            this.gbMass.Size = new System.Drawing.Size(410, 80);
            this.gbMass.TabIndex = 8;
            this.gbMass.TabStop = false;
            this.gbMass.Text = "Конструктивные характеристики";
            // 
            // picBoxTickStruct
            // 
            this.picBoxTickStruct.Image = ((System.Drawing.Image)(resources.GetObject("picBoxTickStruct.Image")));
            this.picBoxTickStruct.InitialImage = null;
            this.picBoxTickStruct.Location = new System.Drawing.Point(378, 12);
            this.picBoxTickStruct.Name = "picBoxTickStruct";
            this.picBoxTickStruct.Size = new System.Drawing.Size(24, 27);
            this.picBoxTickStruct.TabIndex = 37;
            this.picBoxTickStruct.TabStop = false;
            // 
            // tbxc
            // 
            this.tbxc.Location = new System.Drawing.Point(87, 46);
            this.tbxc.Name = "tbxc";
            this.tbxc.Size = new System.Drawing.Size(75, 20);
            this.tbxc.TabIndex = 10;
            this.tbxc.Text = "0,0";
            this.tbxc.TextChanged += new System.EventHandler(this.tbm_TextChanged);
            this.tbxc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbd1_KeyPress);
            this.tbxc.Leave += new System.EventHandler(this.tbxc_Leave);
            this.tbxc.Validating += new System.ComponentModel.CancelEventHandler(this.tbxc_Validating);
            this.tbxc.Validated += new System.EventHandler(this.tbxc_Validated);
            // 
            // tbJe
            // 
            this.tbJe.Location = new System.Drawing.Point(247, 46);
            this.tbJe.Name = "tbJe";
            this.tbJe.Size = new System.Drawing.Size(75, 20);
            this.tbJe.TabIndex = 12;
            this.tbJe.Text = "0,00027";
            this.tbJe.TextChanged += new System.EventHandler(this.tbm_TextChanged);
            this.tbJe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbd1_KeyPress);
            this.tbJe.Leave += new System.EventHandler(this.tbJe_Leave);
            this.tbJe.Validating += new System.ComponentModel.CancelEventHandler(this.tbJe_Validating);
            this.tbJe.Validated += new System.EventHandler(this.tbJe_Validated);
            // 
            // tbJp
            // 
            this.tbJp.Location = new System.Drawing.Point(167, 46);
            this.tbJp.Name = "tbJp";
            this.tbJp.Size = new System.Drawing.Size(75, 20);
            this.tbJp.TabIndex = 11;
            this.tbJp.Text = "0,000027";
            this.tbJp.TextChanged += new System.EventHandler(this.tbm_TextChanged);
            this.tbJp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbd1_KeyPress);
            this.tbJp.Leave += new System.EventHandler(this.tbJp_Leave);
            this.tbJp.Validating += new System.ComponentModel.CancelEventHandler(this.tbJp_Validating);
            this.tbJp.Validated += new System.EventHandler(this.tbJp_Validated);
            // 
            // tbm
            // 
            this.tbm.Location = new System.Drawing.Point(7, 46);
            this.tbm.Name = "tbm";
            this.tbm.Size = new System.Drawing.Size(75, 20);
            this.tbm.TabIndex = 9;
            this.tbm.Text = "0,4";
            this.tbm.TextChanged += new System.EventHandler(this.tbm_TextChanged);
            this.tbm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbd1_KeyPress);
            this.tbm.Leave += new System.EventHandler(this.tbm_Leave);
            this.tbm.Validating += new System.ComponentModel.CancelEventHandler(this.tbm_Validating);
            this.tbm.Validated += new System.EventHandler(this.tbm_Validated);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.ForeColor = System.Drawing.Color.Blue;
            this.label19.Location = new System.Drawing.Point(87, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 13);
            this.label19.TabIndex = 16;
            this.label19.Text = "Xc, м:";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(7, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "m, кг:";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // btnStructSpecif
            // 
            this.btnStructSpecif.Location = new System.Drawing.Point(327, 42);
            this.btnStructSpecif.Name = "btnStructSpecif";
            this.btnStructSpecif.Size = new System.Drawing.Size(75, 27);
            this.btnStructSpecif.TabIndex = 13;
            this.btnStructSpecif.Text = "Принять";
            this.btnStructSpecif.UseVisualStyleBackColor = true;
            this.btnStructSpecif.Click += new System.EventHandler(this.btnStructSpecif_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.ForeColor = System.Drawing.Color.Blue;
            this.label17.Location = new System.Drawing.Point(165, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Jp, кг/м2:";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.ForeColor = System.Drawing.Color.Blue;
            this.label18.Location = new System.Drawing.Point(244, 26);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "Jэ, кг/м2:";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // tbFullLength
            // 
            this.tbFullLength.Location = new System.Drawing.Point(88, 120);
            this.tbFullLength.Name = "tbFullLength";
            this.tbFullLength.ReadOnly = true;
            this.tbFullLength.Size = new System.Drawing.Size(75, 20);
            this.tbFullLength.TabIndex = 14;
            // 
            // lbFullLength
            // 
            this.lbFullLength.AutoSize = true;
            this.lbFullLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFullLength.ForeColor = System.Drawing.Color.Blue;
            this.lbFullLength.Location = new System.Drawing.Point(88, 100);
            this.lbFullLength.Name = "lbFullLength";
            this.lbFullLength.Size = new System.Drawing.Size(30, 13);
            this.lbFullLength.TabIndex = 17;
            this.lbFullLength.Text = "L, м:";
            this.lbFullLength.Click += new System.EventHandler(this.lbFullLength_Click);
            // 
            // gbElement
            // 
            this.gbElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbElement.Controls.Add(this.picBoxTickBody);
            this.gbElement.Controls.Add(this.tbd);
            this.gbElement.Controls.Add(this.label1);
            this.gbElement.Controls.Add(this.tbFullLength);
            this.gbElement.Controls.Add(this.btnRemove);
            this.gbElement.Controls.Add(this.lbR);
            this.gbElement.Controls.Add(this.lbFullLength);
            this.gbElement.Controls.Add(this.lbl);
            this.gbElement.Controls.Add(this.lbd2);
            this.gbElement.Controls.Add(this.btnDone);
            this.gbElement.Controls.Add(this.lbd1);
            this.gbElement.Controls.Add(this.lbPart);
            this.gbElement.Controls.Add(this.cbPart);
            this.gbElement.Controls.Add(this.lbID);
            this.gbElement.Controls.Add(this.tbR);
            this.gbElement.Controls.Add(this.tbl);
            this.gbElement.Controls.Add(this.tbd2);
            this.gbElement.Controls.Add(this.tbd1);
            this.gbElement.Controls.Add(this.tbID);
            this.gbElement.Controls.Add(this.btnAccept);
            this.gbElement.Controls.Add(this.btnNewPart);
            this.gbElement.Location = new System.Drawing.Point(3, 308);
            this.gbElement.Name = "gbElement";
            this.gbElement.Size = new System.Drawing.Size(760, 150);
            this.gbElement.TabIndex = 0;
            this.gbElement.TabStop = false;
            this.gbElement.Text = "Геометрические параметры";
            // 
            // picBoxTickBody
            // 
            this.picBoxTickBody.Image = ((System.Drawing.Image)(resources.GetObject("picBoxTickBody.Image")));
            this.picBoxTickBody.InitialImage = null;
            this.picBoxTickBody.Location = new System.Drawing.Point(167, 20);
            this.picBoxTickBody.Name = "picBoxTickBody";
            this.picBoxTickBody.Size = new System.Drawing.Size(24, 27);
            this.picBoxTickBody.TabIndex = 36;
            this.picBoxTickBody.TabStop = false;
            // 
            // tbd
            // 
            this.tbd.Location = new System.Drawing.Point(7, 120);
            this.tbd.Name = "tbd";
            this.tbd.Size = new System.Drawing.Size(75, 20);
            this.tbd.TabIndex = 34;
            this.tbd.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbd1_KeyPress);
            this.tbd.Leave += new System.EventHandler(this.tbd_Leave);
            this.tbd.Validating += new System.ComponentModel.CancelEventHandler(this.tbd_Validating);
            this.tbd.Validated += new System.EventHandler(this.tbd_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(7, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "d, м:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemove.Location = new System.Drawing.Point(520, 20);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 27);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lbR
            // 
            this.lbR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbR.AutoSize = true;
            this.lbR.Enabled = false;
            this.lbR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbR.ForeColor = System.Drawing.Color.Blue;
            this.lbR.Location = new System.Drawing.Point(677, 54);
            this.lbR.Name = "lbR";
            this.lbR.Size = new System.Drawing.Size(32, 13);
            this.lbR.TabIndex = 33;
            this.lbR.Text = "R, м:";
            this.lbR.Click += new System.EventHandler(this.lbR_Click);
            // 
            // lbl
            // 
            this.lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl.ForeColor = System.Drawing.Color.Blue;
            this.lbl.Location = new System.Drawing.Point(597, 54);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(26, 13);
            this.lbl.TabIndex = 32;
            this.lbl.Text = "l, м:";
            this.lbl.Click += new System.EventHandler(this.lbl_Click);
            // 
            // lbd2
            // 
            this.lbd2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbd2.AutoSize = true;
            this.lbd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbd2.ForeColor = System.Drawing.Color.Blue;
            this.lbd2.Location = new System.Drawing.Point(517, 54);
            this.lbd2.Name = "lbd2";
            this.lbd2.Size = new System.Drawing.Size(36, 13);
            this.lbd2.TabIndex = 31;
            this.lbd2.Text = "d2, м:";
            this.lbd2.Click += new System.EventHandler(this.lbd2_Click);
            // 
            // lbd1
            // 
            this.lbd1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbd1.AutoSize = true;
            this.lbd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbd1.ForeColor = System.Drawing.Color.Blue;
            this.lbd1.Location = new System.Drawing.Point(437, 54);
            this.lbd1.Name = "lbd1";
            this.lbd1.Size = new System.Drawing.Size(36, 13);
            this.lbd1.TabIndex = 29;
            this.lbd1.Text = "d1, м:";
            this.lbd1.Click += new System.EventHandler(this.lbd1_Click);
            // 
            // lbPart
            // 
            this.lbPart.AutoSize = true;
            this.lbPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPart.ForeColor = System.Drawing.Color.Blue;
            this.lbPart.Location = new System.Drawing.Point(87, 54);
            this.lbPart.Name = "lbPart";
            this.lbPart.Size = new System.Drawing.Size(54, 13);
            this.lbPart.TabIndex = 28;
            this.lbPart.Text = "Элемент:";
            this.lbPart.Click += new System.EventHandler(this.lbPart_Click);
            // 
            // cbPart
            // 
            this.cbPart.FormattingEnabled = true;
            this.cbPart.Items.AddRange(new object[] {
            "Конус",
            "Оживало",
            "Цилиндр"});
            this.cbPart.Location = new System.Drawing.Point(87, 74);
            this.cbPart.Name = "cbPart";
            this.cbPart.Size = new System.Drawing.Size(75, 21);
            this.cbPart.TabIndex = 2;
            this.cbPart.Text = "Конус";
            this.cbPart.SelectedIndexChanged += new System.EventHandler(this.cbPart_SelectedIndexChanged);
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbID.ForeColor = System.Drawing.Color.Blue;
            this.lbID.Location = new System.Drawing.Point(7, 54);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(21, 13);
            this.lbID.TabIndex = 22;
            this.lbID.Text = "ID:";
            this.lbID.Click += new System.EventHandler(this.lbID_Click);
            // 
            // tbR
            // 
            this.tbR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbR.Enabled = false;
            this.tbR.Location = new System.Drawing.Point(680, 74);
            this.tbR.Name = "tbR";
            this.tbR.Size = new System.Drawing.Size(75, 20);
            this.tbR.TabIndex = 6;
            this.tbR.Text = "0,0";
            this.tbR.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbd1_KeyPress);
            this.tbR.Leave += new System.EventHandler(this.tbR_Leave);
            // 
            // tbl
            // 
            this.tbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl.Location = new System.Drawing.Point(600, 74);
            this.tbl.Name = "tbl";
            this.tbl.Size = new System.Drawing.Size(75, 20);
            this.tbl.TabIndex = 5;
            this.tbl.Text = "0,0";
            this.tbl.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbd1_KeyPress);
            this.tbl.Leave += new System.EventHandler(this.tbl_Leave);
            this.tbl.Validating += new System.ComponentModel.CancelEventHandler(this.tbl_Validating);
            this.tbl.Validated += new System.EventHandler(this.tbl_Validated);
            // 
            // tbd2
            // 
            this.tbd2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbd2.Location = new System.Drawing.Point(520, 74);
            this.tbd2.Name = "tbd2";
            this.tbd2.Size = new System.Drawing.Size(75, 20);
            this.tbd2.TabIndex = 4;
            this.tbd2.Text = "0,03";
            this.tbd2.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbd2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbd1_KeyPress);
            this.tbd2.Leave += new System.EventHandler(this.tbd2_Leave);
            // 
            // tbd1
            // 
            this.tbd1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbd1.Location = new System.Drawing.Point(440, 75);
            this.tbd1.Name = "tbd1";
            this.tbd1.Size = new System.Drawing.Size(75, 20);
            this.tbd1.TabIndex = 3;
            this.tbd1.Text = "0,006";
            this.tbd1.TextChanged += new System.EventHandler(this.tbID_TextChanged);
            this.tbd1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbd1_KeyPress);
            this.tbd1.Leave += new System.EventHandler(this.tbd1_Leave);
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(7, 74);
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
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAccept.Location = new System.Drawing.Point(600, 20);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 27);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Принять";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnNewPart
            // 
            this.btnNewPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNewPart.Location = new System.Drawing.Point(7, 20);
            this.btnNewPart.Name = "btnNewPart";
            this.btnNewPart.Size = new System.Drawing.Size(155, 27);
            this.btnNewPart.TabIndex = 0;
            this.btnNewPart.Text = "Добавить новый элемент";
            this.btnNewPart.UseVisualStyleBackColor = true;
            this.btnNewPart.Click += new System.EventHandler(this.btnNewPart_Click);
            // 
            // lbParts
            // 
            this.lbParts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbParts.FormattingEnabled = true;
            this.lbParts.Location = new System.Drawing.Point(769, 313);
            this.lbParts.Name = "lbParts";
            this.lbParts.Size = new System.Drawing.Size(175, 316);
            this.lbParts.TabIndex = 9;
            this.lbParts.SelectedIndexChanged += new System.EventHandler(this.lbParts_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(944, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaveBody,
            this.tsmiSaveBodyAs,
            this.toolStripMenuItem1,
            this.tsmiLoadBody});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // tsmiSaveBody
            // 
            this.tsmiSaveBody.Name = "tsmiSaveBody";
            this.tsmiSaveBody.Size = new System.Drawing.Size(204, 22);
            this.tsmiSaveBody.Text = "Сохранить сборку";
            // 
            // tsmiSaveBodyAs
            // 
            this.tsmiSaveBodyAs.Name = "tsmiSaveBodyAs";
            this.tsmiSaveBodyAs.Size = new System.Drawing.Size(204, 22);
            this.tsmiSaveBodyAs.Text = "Сохранить сборку как...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(201, 6);
            // 
            // tsmiLoadBody
            // 
            this.tsmiLoadBody.Name = "tsmiLoadBody";
            this.tsmiLoadBody.Size = new System.Drawing.Size(204, 22);
            this.tsmiLoadBody.Text = "Загрузить сборку...";
            // 
            // ofd
            // 
            this.ofd.FileName = "ofd";
            // 
            // StatusStrip
            // 
            this.StatusStrip.Location = new System.Drawing.Point(0, 640);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(944, 22);
            this.StatusStrip.TabIndex = 27;
            // 
            // chartBodyDwg
            // 
            this.chartBodyDwg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.chartBodyDwg.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartBodyDwg.Legends.Add(legend4);
            this.chartBodyDwg.Location = new System.Drawing.Point(0, 27);
            this.chartBodyDwg.Name = "chartBodyDwg";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            series4.YValuesPerPoint = 2;
            this.chartBodyDwg.Series.Add(series4);
            this.chartBodyDwg.Size = new System.Drawing.Size(944, 275);
            this.chartBodyDwg.TabIndex = 28;
            this.chartBodyDwg.Text = "chart1";
            // 
            // gbJetEngine
            // 
            this.gbJetEngine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbJetEngine.Location = new System.Drawing.Point(2, 550);
            this.gbJetEngine.Name = "gbJetEngine";
            this.gbJetEngine.Size = new System.Drawing.Size(761, 80);
            this.gbJetEngine.TabIndex = 15;
            this.gbJetEngine.TabStop = false;
            this.gbJetEngine.Text = "Двигатель";
            // 
            // FrmBody
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 662);
            this.Controls.Add(this.chartBodyDwg);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.gbJetEngine);
            this.Controls.Add(this.lbParts);
            this.Controls.Add(this.gbElement);
            this.Controls.Add(this.gbMass);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(960, 700);
            this.Name = "FrmBody";
            this.Text = "FrmBody";
            this.gbMass.ResumeLayout(false);
            this.gbMass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTickStruct)).EndInit();
            this.gbElement.ResumeLayout(false);
            this.gbElement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxTickBody)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBodyDwg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.GroupBox gbMass;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbxc;
        private System.Windows.Forms.TextBox tbJe;
        private System.Windows.Forms.TextBox tbJp;
        private System.Windows.Forms.TextBox tbm;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox gbElement;
        private System.Windows.Forms.TextBox tbR;
        private System.Windows.Forms.TextBox tbl;
        private System.Windows.Forms.TextBox tbd2;
        private System.Windows.Forms.TextBox tbd1;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnNewPart;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.ComboBox cbPart;
        private System.Windows.Forms.Label lbPart;
        private System.Windows.Forms.Label lbR;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lbd2;
        private System.Windows.Forms.Label lbd1;
        private System.Windows.Forms.ListBox lbParts;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnStructSpecif;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveBody;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveBodyAs;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadBody;
        private System.Windows.Forms.TextBox tbFullLength;
        private System.Windows.Forms.Label lbFullLength;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBodyDwg;
        private System.Windows.Forms.GroupBox gbJetEngine;
        private System.Windows.Forms.TextBox tbd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBoxTickBody;
        private System.Windows.Forms.PictureBox picBoxTickStruct;
    }
}