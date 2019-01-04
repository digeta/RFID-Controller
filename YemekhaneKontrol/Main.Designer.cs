namespace YemekhaneKontrol
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabHarcama = new System.Windows.Forms.TabPage();
            this.lblStats = new System.Windows.Forms.Label();
            this.lblTarih = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grupGecisler = new System.Windows.Forms.GroupBox();
            this.gridGecisler = new System.Windows.Forms.DataGridView();
            this.colGecisId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKartId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdSoyad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTarife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBakiyeEski = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBakiyeHarcanan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBakiyeKalan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabOkutma = new System.Windows.Forms.TabPage();
            this.tabSistem = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridThreadList = new System.Windows.Forms.DataGridView();
            this.colThreadId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThreadName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThreadIntent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThreadStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTableId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtGecisler = new System.Windows.Forms.RichTextBox();
            this.txtLogger = new System.Windows.Forms.RichTextBox();
            this.grupTurnike = new System.Windows.Forms.GroupBox();
            this.gridTurnikeler = new System.Windows.Forms.DataGridView();
            this.colHarNokId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTurnikeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTurnikeAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCihazTip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDurum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGecisSay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTopGecisSay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOnOff = new System.Windows.Forms.DataGridViewButtonColumn();
            this.sysLog = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabHarcama.SuspendLayout();
            this.grupGecisler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGecisler)).BeginInit();
            this.tabSistem.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridThreadList)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grupTurnike.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnikeler)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabHarcama);
            this.tabControl1.Controls.Add(this.tabOkutma);
            this.tabControl1.Controls.Add(this.tabSistem);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(0, 231);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1384, 540);
            this.tabControl1.TabIndex = 9;
            // 
            // tabHarcama
            // 
            this.tabHarcama.Controls.Add(this.lblStats);
            this.tabHarcama.Controls.Add(this.lblTarih);
            this.tabHarcama.Controls.Add(this.label1);
            this.tabHarcama.Controls.Add(this.grupGecisler);
            this.tabHarcama.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabHarcama.Location = new System.Drawing.Point(4, 25);
            this.tabHarcama.Name = "tabHarcama";
            this.tabHarcama.Padding = new System.Windows.Forms.Padding(3);
            this.tabHarcama.Size = new System.Drawing.Size(1376, 511);
            this.tabHarcama.TabIndex = 0;
            this.tabHarcama.Text = "Harcamalar (Geçiş yapılmış)";
            this.tabHarcama.UseVisualStyleBackColor = true;
            // 
            // lblStats
            // 
            this.lblStats.Location = new System.Drawing.Point(1237, 489);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(131, 16);
            this.lblStats.TabIndex = 9;
            this.lblStats.Text = "---";
            this.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Location = new System.Drawing.Point(71, 489);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(23, 16);
            this.lblTarih.TabIndex = 7;
            this.lblTarih.Text = "---";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tarih : ";
            // 
            // grupGecisler
            // 
            this.grupGecisler.Controls.Add(this.gridGecisler);
            this.grupGecisler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grupGecisler.Location = new System.Drawing.Point(6, 6);
            this.grupGecisler.Name = "grupGecisler";
            this.grupGecisler.Size = new System.Drawing.Size(1362, 475);
            this.grupGecisler.TabIndex = 5;
            this.grupGecisler.TabStop = false;
            this.grupGecisler.Text = "Geçişler";
            // 
            // gridGecisler
            // 
            this.gridGecisler.AllowUserToAddRows = false;
            this.gridGecisler.AllowUserToDeleteRows = false;
            this.gridGecisler.ColumnHeadersHeight = 30;
            this.gridGecisler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridGecisler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGecisId,
            this.colKartId,
            this.colAdSoyad,
            this.colTarife,
            this.dataGridViewTextBoxColumn4,
            this.colBakiyeEski,
            this.colBakiyeHarcanan,
            this.colBakiyeKalan,
            this.colTarih});
            this.gridGecisler.GridColor = System.Drawing.Color.Silver;
            this.gridGecisler.Location = new System.Drawing.Point(6, 19);
            this.gridGecisler.MultiSelect = false;
            this.gridGecisler.Name = "gridGecisler";
            this.gridGecisler.ReadOnly = true;
            this.gridGecisler.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridGecisler.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridGecisler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGecisler.Size = new System.Drawing.Size(1348, 446);
            this.gridGecisler.TabIndex = 1;
            // 
            // colGecisId
            // 
            this.colGecisId.DataPropertyName = "ROWID";
            this.colGecisId.HeaderText = "Sayı";
            this.colGecisId.Name = "colGecisId";
            this.colGecisId.ReadOnly = true;
            this.colGecisId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colGecisId.Width = 80;
            // 
            // colKartId
            // 
            this.colKartId.DataPropertyName = "KART_ID";
            this.colKartId.HeaderText = "Kart No";
            this.colKartId.MaxInputLength = 13;
            this.colKartId.Name = "colKartId";
            this.colKartId.ReadOnly = true;
            this.colKartId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colKartId.Width = 130;
            // 
            // colAdSoyad
            // 
            this.colAdSoyad.DataPropertyName = "ADSOYAD";
            this.colAdSoyad.HeaderText = "Ad Soyad";
            this.colAdSoyad.MaxInputLength = 15;
            this.colAdSoyad.Name = "colAdSoyad";
            this.colAdSoyad.ReadOnly = true;
            this.colAdSoyad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAdSoyad.Width = 170;
            // 
            // colTarife
            // 
            this.colTarife.DataPropertyName = "TARIFE";
            this.colTarife.HeaderText = "Tarife";
            this.colTarife.Name = "colTarife";
            this.colTarife.ReadOnly = true;
            this.colTarife.Width = 170;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TURNIKE_NO";
            this.dataGridViewTextBoxColumn4.HeaderText = "Turnike";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 10;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // colBakiyeEski
            // 
            this.colBakiyeEski.DataPropertyName = "BAKIYE_ONCEKI";
            this.colBakiyeEski.HeaderText = "Eski Bakiye";
            this.colBakiyeEski.MaxInputLength = 10;
            this.colBakiyeEski.Name = "colBakiyeEski";
            this.colBakiyeEski.ReadOnly = true;
            this.colBakiyeEski.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colBakiyeEski.Width = 170;
            // 
            // colBakiyeHarcanan
            // 
            this.colBakiyeHarcanan.DataPropertyName = "BAKIYE_HARCANAN";
            this.colBakiyeHarcanan.HeaderText = "Düşülen Ücret";
            this.colBakiyeHarcanan.Name = "colBakiyeHarcanan";
            this.colBakiyeHarcanan.ReadOnly = true;
            this.colBakiyeHarcanan.Width = 160;
            // 
            // colBakiyeKalan
            // 
            this.colBakiyeKalan.DataPropertyName = "BAKIYE_KALAN";
            this.colBakiyeKalan.HeaderText = "Kalan Bakiye";
            this.colBakiyeKalan.Name = "colBakiyeKalan";
            this.colBakiyeKalan.ReadOnly = true;
            this.colBakiyeKalan.Width = 150;
            // 
            // colTarih
            // 
            this.colTarih.DataPropertyName = "TARIH";
            this.colTarih.HeaderText = "Tarih";
            this.colTarih.Name = "colTarih";
            this.colTarih.ReadOnly = true;
            this.colTarih.Width = 140;
            // 
            // tabOkutma
            // 
            this.tabOkutma.Location = new System.Drawing.Point(4, 25);
            this.tabOkutma.Name = "tabOkutma";
            this.tabOkutma.Padding = new System.Windows.Forms.Padding(3);
            this.tabOkutma.Size = new System.Drawing.Size(1376, 511);
            this.tabOkutma.TabIndex = 1;
            this.tabOkutma.Text = "Kart Okutmalar (Geçiş yapılmamış)";
            this.tabOkutma.UseVisualStyleBackColor = true;
            // 
            // tabSistem
            // 
            this.tabSistem.Controls.Add(this.groupBox1);
            this.tabSistem.Location = new System.Drawing.Point(4, 25);
            this.tabSistem.Name = "tabSistem";
            this.tabSistem.Size = new System.Drawing.Size(1376, 511);
            this.tabSistem.TabIndex = 2;
            this.tabSistem.Text = "Sistem Günlüğü";
            this.tabSistem.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sysLog);
            this.groupBox1.Controls.Add(this.gridThreadList);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1362, 500);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // gridThreadList
            // 
            this.gridThreadList.AllowUserToAddRows = false;
            this.gridThreadList.AllowUserToDeleteRows = false;
            this.gridThreadList.AllowUserToResizeColumns = false;
            this.gridThreadList.AllowUserToResizeRows = false;
            this.gridThreadList.ColumnHeadersHeight = 30;
            this.gridThreadList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridThreadList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colThreadId,
            this.colThreadName,
            this.colThread,
            this.colThreadIntent,
            this.colThreadStatus,
            this.colTableId});
            this.gridThreadList.GridColor = System.Drawing.Color.Silver;
            this.gridThreadList.Location = new System.Drawing.Point(1281, 326);
            this.gridThreadList.MultiSelect = false;
            this.gridThreadList.Name = "gridThreadList";
            this.gridThreadList.ReadOnly = true;
            this.gridThreadList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridThreadList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridThreadList.ShowCellErrors = false;
            this.gridThreadList.ShowCellToolTips = false;
            this.gridThreadList.ShowEditingIcon = false;
            this.gridThreadList.ShowRowErrors = false;
            this.gridThreadList.Size = new System.Drawing.Size(59, 168);
            this.gridThreadList.TabIndex = 2;
            this.gridThreadList.Visible = false;
            // 
            // colThreadId
            // 
            this.colThreadId.DataPropertyName = "ThreadId";
            this.colThreadId.HeaderText = "Thread Id";
            this.colThreadId.Name = "colThreadId";
            this.colThreadId.ReadOnly = true;
            // 
            // colThreadName
            // 
            this.colThreadName.DataPropertyName = "ThreadName";
            this.colThreadName.HeaderText = "Thread Name";
            this.colThreadName.Name = "colThreadName";
            this.colThreadName.ReadOnly = true;
            this.colThreadName.Width = 150;
            // 
            // colThread
            // 
            this.colThread.DataPropertyName = "Thread";
            this.colThread.HeaderText = "Thread";
            this.colThread.Name = "colThread";
            this.colThread.ReadOnly = true;
            // 
            // colThreadIntent
            // 
            this.colThreadIntent.DataPropertyName = "ThreadIntent";
            this.colThreadIntent.HeaderText = "Thread Intent";
            this.colThreadIntent.Name = "colThreadIntent";
            this.colThreadIntent.ReadOnly = true;
            this.colThreadIntent.Width = 120;
            // 
            // colThreadStatus
            // 
            this.colThreadStatus.DataPropertyName = "ThreadStatus";
            this.colThreadStatus.HeaderText = "Thread Status";
            this.colThreadStatus.Name = "colThreadStatus";
            this.colThreadStatus.ReadOnly = true;
            this.colThreadStatus.Width = 120;
            // 
            // colTableId
            // 
            this.colTableId.DataPropertyName = "TableId";
            this.colTableId.HeaderText = "Table Id";
            this.colTableId.Name = "colTableId";
            this.colTableId.ReadOnly = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1384, 228);
            this.tabControl2.TabIndex = 10;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtGecisler);
            this.tabPage3.Controls.Add(this.txtLogger);
            this.tabPage3.Controls.Add(this.grupTurnike);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1376, 202);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtGecisler
            // 
            this.txtGecisler.BackColor = System.Drawing.Color.White;
            this.txtGecisler.Location = new System.Drawing.Point(1108, 8);
            this.txtGecisler.Name = "txtGecisler";
            this.txtGecisler.ReadOnly = true;
            this.txtGecisler.Size = new System.Drawing.Size(260, 188);
            this.txtGecisler.TabIndex = 11;
            this.txtGecisler.Text = "";
            // 
            // txtLogger
            // 
            this.txtLogger.BackColor = System.Drawing.Color.White;
            this.txtLogger.Location = new System.Drawing.Point(820, 8);
            this.txtLogger.Name = "txtLogger";
            this.txtLogger.ReadOnly = true;
            this.txtLogger.Size = new System.Drawing.Size(282, 188);
            this.txtLogger.TabIndex = 10;
            this.txtLogger.Text = "";
            // 
            // grupTurnike
            // 
            this.grupTurnike.Controls.Add(this.gridTurnikeler);
            this.grupTurnike.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grupTurnike.Location = new System.Drawing.Point(6, 3);
            this.grupTurnike.Name = "grupTurnike";
            this.grupTurnike.Size = new System.Drawing.Size(808, 194);
            this.grupTurnike.TabIndex = 9;
            this.grupTurnike.TabStop = false;
            this.grupTurnike.Text = "Cihazlar";
            // 
            // gridTurnikeler
            // 
            this.gridTurnikeler.AllowUserToAddRows = false;
            this.gridTurnikeler.AllowUserToDeleteRows = false;
            this.gridTurnikeler.AllowUserToResizeColumns = false;
            this.gridTurnikeler.AllowUserToResizeRows = false;
            this.gridTurnikeler.ColumnHeadersHeight = 30;
            this.gridTurnikeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridTurnikeler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHarNokId,
            this.colTurnikeNo,
            this.colTurnikeAd,
            this.colip,
            this.colCihazTip,
            this.colDurum,
            this.colGecisSay,
            this.colTopGecisSay,
            this.colOnOff});
            this.gridTurnikeler.GridColor = System.Drawing.Color.Silver;
            this.gridTurnikeler.Location = new System.Drawing.Point(6, 19);
            this.gridTurnikeler.MultiSelect = false;
            this.gridTurnikeler.Name = "gridTurnikeler";
            this.gridTurnikeler.ReadOnly = true;
            this.gridTurnikeler.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridTurnikeler.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTurnikeler.ShowCellErrors = false;
            this.gridTurnikeler.ShowCellToolTips = false;
            this.gridTurnikeler.ShowEditingIcon = false;
            this.gridTurnikeler.ShowRowErrors = false;
            this.gridTurnikeler.Size = new System.Drawing.Size(796, 168);
            this.gridTurnikeler.TabIndex = 1;
            this.gridTurnikeler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTurnikeler_CellContentClick);
            // 
            // colHarNokId
            // 
            this.colHarNokId.DataPropertyName = "ID";
            this.colHarNokId.HeaderText = "ID";
            this.colHarNokId.Name = "colHarNokId";
            this.colHarNokId.ReadOnly = true;
            this.colHarNokId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colHarNokId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHarNokId.Visible = false;
            // 
            // colTurnikeNo
            // 
            this.colTurnikeNo.DataPropertyName = "TURNIKE_NO";
            this.colTurnikeNo.HeaderText = "No";
            this.colTurnikeNo.MaxInputLength = 13;
            this.colTurnikeNo.Name = "colTurnikeNo";
            this.colTurnikeNo.ReadOnly = true;
            this.colTurnikeNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTurnikeNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTurnikeNo.Width = 50;
            // 
            // colTurnikeAd
            // 
            this.colTurnikeAd.DataPropertyName = "ACIKLAMA";
            this.colTurnikeAd.HeaderText = "Turnike";
            this.colTurnikeAd.Name = "colTurnikeAd";
            this.colTurnikeAd.ReadOnly = true;
            this.colTurnikeAd.Width = 150;
            // 
            // colip
            // 
            this.colip.DataPropertyName = "IP";
            this.colip.HeaderText = "IP";
            this.colip.MaxInputLength = 15;
            this.colip.Name = "colip";
            this.colip.ReadOnly = true;
            this.colip.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colip.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colip.Width = 120;
            // 
            // colCihazTip
            // 
            this.colCihazTip.DataPropertyName = "CIHAZTIP";
            this.colCihazTip.HeaderText = "Cihaz Tür";
            this.colCihazTip.MaxInputLength = 10;
            this.colCihazTip.Name = "colCihazTip";
            this.colCihazTip.ReadOnly = true;
            this.colCihazTip.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCihazTip.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCihazTip.Width = 90;
            // 
            // colDurum
            // 
            this.colDurum.HeaderText = "Durum";
            this.colDurum.Name = "colDurum";
            this.colDurum.ReadOnly = true;
            this.colDurum.Width = 70;
            // 
            // colGecisSay
            // 
            this.colGecisSay.DataPropertyName = "GECIS_SAY";
            this.colGecisSay.HeaderText = "Geçiş";
            this.colGecisSay.MaxInputLength = 10;
            this.colGecisSay.Name = "colGecisSay";
            this.colGecisSay.ReadOnly = true;
            this.colGecisSay.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colGecisSay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colGecisSay.Width = 70;
            // 
            // colTopGecisSay
            // 
            this.colTopGecisSay.DataPropertyName = "TOPGECIS_SAY";
            this.colTopGecisSay.HeaderText = "Top. Geçiş";
            this.colTopGecisSay.Name = "colTopGecisSay";
            this.colTopGecisSay.ReadOnly = true;
            this.colTopGecisSay.Width = 90;
            // 
            // colOnOff
            // 
            this.colOnOff.DataPropertyName = "AKTIF";
            this.colOnOff.HeaderText = "Aktif / Pasif";
            this.colOnOff.Name = "colOnOff";
            this.colOnOff.ReadOnly = true;
            this.colOnOff.Width = 110;
            // 
            // sysLog
            // 
            this.sysLog.BackColor = System.Drawing.Color.White;
            this.sysLog.Location = new System.Drawing.Point(6, 21);
            this.sysLog.Name = "sysLog";
            this.sysLog.ReadOnly = true;
            this.sysLog.Size = new System.Drawing.Size(558, 186);
            this.sysLog.TabIndex = 11;
            this.sysLog.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 771);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabHarcama.ResumeLayout(false);
            this.tabHarcama.PerformLayout();
            this.grupGecisler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridGecisler)).EndInit();
            this.tabSistem.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridThreadList)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.grupTurnike.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnikeler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHarcama;
        private System.Windows.Forms.GroupBox grupGecisler;
        private System.Windows.Forms.DataGridView gridGecisler;
        private System.Windows.Forms.TabPage tabOkutma;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox txtGecisler;
        private System.Windows.Forms.RichTextBox txtLogger;
        private System.Windows.Forms.GroupBox grupTurnike;
        private System.Windows.Forms.DataGridView gridTurnikeler;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabSistem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridThreadList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThread;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadIntent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTableId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGecisId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKartId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdSoyad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTarife;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBakiyeEski;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBakiyeHarcanan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBakiyeKalan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTarih;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHarNokId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurnikeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurnikeAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colip;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCihazTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDurum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGecisSay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTopGecisSay;
        private System.Windows.Forms.DataGridViewButtonColumn colOnOff;
        private System.Windows.Forms.RichTextBox sysLog;
    }
}