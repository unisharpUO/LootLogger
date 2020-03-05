namespace LootLogger
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.cboxShields = new System.Windows.Forms.CheckBox();
            this.cboxWeapons = new System.Windows.Forms.CheckBox();
            this.lblMissedItems = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTypesToLog = new System.Windows.Forms.Label();
            this.txtMissingItems = new System.Windows.Forms.TextBox();
            this.btnRemoveDupes = new System.Windows.Forms.Button();
            this.cboxJewelry = new System.Windows.Forms.CheckBox();
            this.cboxArmor = new System.Windows.Forms.CheckBox();
            this.btnSearchAll = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtLootList = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tabFetch = new System.Windows.Forms.TabPage();
            this.cboxFetchShield = new System.Windows.Forms.CheckBox();
            this.cboxFetchWeapon = new System.Windows.Forms.CheckBox();
            this.cboxFetchJewelry = new System.Windows.Forms.CheckBox();
            this.cboxFetchArmor = new System.Windows.Forms.CheckBox();
            this.btnFetch = new System.Windows.Forms.Button();
            this.lblItemID = new System.Windows.Forms.Label();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.gboxSQLConnection = new System.Windows.Forms.GroupBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.lblSQLNote = new System.Windows.Forms.Label();
            this.lblSQLDatabaseName = new System.Windows.Forms.Label();
            this.txtSQLDatabaseName = new System.Windows.Forms.TextBox();
            this.lblSQLPassword = new System.Windows.Forms.Label();
            this.lblSQLUsername = new System.Windows.Forms.Label();
            this.txtSQLPassword = new System.Windows.Forms.TextBox();
            this.txtSQLUsername = new System.Windows.Forms.TextBox();
            this.lblSQLAddress = new System.Windows.Forms.Label();
            this.txtSQLAddress = new System.Windows.Forms.TextBox();
            this.cboxLogToSQL = new System.Windows.Forms.CheckBox();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.btnDebug = new System.Windows.Forms.Button();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.workerSearch = new System.ComponentModel.BackgroundWorker();
            this.workerFetch = new System.ComponentModel.BackgroundWorker();
            this.workerDebug = new System.ComponentModel.BackgroundWorker();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.tabFetch.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.gboxSQLConnection.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabSearch);
            this.tabControl1.Controls.Add(this.tabFetch);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabDebug);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(682, 679);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.btnExport);
            this.tabSearch.Controls.Add(this.cboxShields);
            this.tabSearch.Controls.Add(this.cboxWeapons);
            this.tabSearch.Controls.Add(this.lblMissedItems);
            this.tabSearch.Controls.Add(this.lblStatus);
            this.tabSearch.Controls.Add(this.lblTypesToLog);
            this.tabSearch.Controls.Add(this.txtMissingItems);
            this.tabSearch.Controls.Add(this.btnRemoveDupes);
            this.tabSearch.Controls.Add(this.cboxJewelry);
            this.tabSearch.Controls.Add(this.cboxArmor);
            this.tabSearch.Controls.Add(this.btnSearchAll);
            this.tabSearch.Controls.Add(this.btnClearList);
            this.tabSearch.Controls.Add(this.btnLoad);
            this.tabSearch.Controls.Add(this.btnSave);
            this.tabSearch.Controls.Add(this.txtLootList);
            this.tabSearch.Controls.Add(this.btnSearch);
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(674, 653);
            this.tabSearch.TabIndex = 0;
            this.tabSearch.Text = "Search";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // cboxShields
            // 
            this.cboxShields.AutoSize = true;
            this.cboxShields.Location = new System.Drawing.Point(21, 613);
            this.cboxShields.Name = "cboxShields";
            this.cboxShields.Size = new System.Drawing.Size(60, 17);
            this.cboxShields.TabIndex = 12;
            this.cboxShields.Text = "Shields";
            this.cboxShields.UseVisualStyleBackColor = true;
            // 
            // cboxWeapons
            // 
            this.cboxWeapons.AutoSize = true;
            this.cboxWeapons.Location = new System.Drawing.Point(21, 590);
            this.cboxWeapons.Name = "cboxWeapons";
            this.cboxWeapons.Size = new System.Drawing.Size(72, 17);
            this.cboxWeapons.TabIndex = 11;
            this.cboxWeapons.Text = "Weapons";
            this.cboxWeapons.UseVisualStyleBackColor = true;
            // 
            // lblMissedItems
            // 
            this.lblMissedItems.AutoSize = true;
            this.lblMissedItems.Location = new System.Drawing.Point(5, 8);
            this.lblMissedItems.Name = "lblMissedItems";
            this.lblMissedItems.Size = new System.Drawing.Size(71, 13);
            this.lblMissedItems.TabIndex = 10;
            this.lblMissedItems.Text = "Missed Items:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(8, 371);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status:";
            // 
            // lblTypesToLog
            // 
            this.lblTypesToLog.AutoSize = true;
            this.lblTypesToLog.Location = new System.Drawing.Point(6, 526);
            this.lblTypesToLog.Name = "lblTypesToLog";
            this.lblTypesToLog.Size = new System.Drawing.Size(68, 13);
            this.lblTypesToLog.TabIndex = 8;
            this.lblTypesToLog.Text = "Types to log:";
            // 
            // txtMissingItems
            // 
            this.txtMissingItems.Location = new System.Drawing.Point(3, 24);
            this.txtMissingItems.Multiline = true;
            this.txtMissingItems.Name = "txtMissingItems";
            this.txtMissingItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMissingItems.Size = new System.Drawing.Size(656, 339);
            this.txtMissingItems.TabIndex = 7;
            // 
            // btnRemoveDupes
            // 
            this.btnRemoveDupes.Location = new System.Drawing.Point(475, 515);
            this.btnRemoveDupes.Name = "btnRemoveDupes";
            this.btnRemoveDupes.Size = new System.Drawing.Size(103, 23);
            this.btnRemoveDupes.TabIndex = 1;
            this.btnRemoveDupes.Text = "Remove Dupes";
            this.btnRemoveDupes.UseVisualStyleBackColor = true;
            this.btnRemoveDupes.Click += new System.EventHandler(this.btnRemoveDupes_Click);
            // 
            // cboxJewelry
            // 
            this.cboxJewelry.AutoSize = true;
            this.cboxJewelry.Location = new System.Drawing.Point(21, 567);
            this.cboxJewelry.Name = "cboxJewelry";
            this.cboxJewelry.Size = new System.Drawing.Size(61, 17);
            this.cboxJewelry.TabIndex = 5;
            this.cboxJewelry.Text = "Jewelry";
            this.cboxJewelry.UseVisualStyleBackColor = true;
            // 
            // cboxArmor
            // 
            this.cboxArmor.AutoSize = true;
            this.cboxArmor.Location = new System.Drawing.Point(21, 544);
            this.cboxArmor.Name = "cboxArmor";
            this.cboxArmor.Size = new System.Drawing.Size(53, 17);
            this.cboxArmor.TabIndex = 4;
            this.cboxArmor.Text = "Armor";
            this.cboxArmor.UseVisualStyleBackColor = true;
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.Location = new System.Drawing.Point(536, 590);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(123, 23);
            this.btnSearchAll.TabIndex = 1;
            this.btnSearchAll.Text = "Search All Containers";
            this.btnSearchAll.UseVisualStyleBackColor = true;
            this.btnSearchAll.Click += new System.EventHandler(this.btnSearchAll_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(584, 515);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(75, 23);
            this.btnClearList.TabIndex = 1;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(249, 515);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load Log";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(168, 515);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Log";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtLootList
            // 
            this.txtLootList.Location = new System.Drawing.Point(8, 387);
            this.txtLootList.Multiline = true;
            this.txtLootList.Name = "txtLootList";
            this.txtLootList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLootList.Size = new System.Drawing.Size(651, 122);
            this.txtLootList.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(536, 618);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(123, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search Container";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tabFetch
            // 
            this.tabFetch.Controls.Add(this.cboxFetchShield);
            this.tabFetch.Controls.Add(this.cboxFetchWeapon);
            this.tabFetch.Controls.Add(this.cboxFetchJewelry);
            this.tabFetch.Controls.Add(this.cboxFetchArmor);
            this.tabFetch.Controls.Add(this.btnFetch);
            this.tabFetch.Controls.Add(this.lblItemID);
            this.tabFetch.Controls.Add(this.txtItemID);
            this.tabFetch.Location = new System.Drawing.Point(4, 22);
            this.tabFetch.Name = "tabFetch";
            this.tabFetch.Size = new System.Drawing.Size(674, 653);
            this.tabFetch.TabIndex = 2;
            this.tabFetch.Text = "Fetch";
            this.tabFetch.UseVisualStyleBackColor = true;
            // 
            // cboxFetchShield
            // 
            this.cboxFetchShield.AutoSize = true;
            this.cboxFetchShield.Location = new System.Drawing.Point(110, 61);
            this.cboxFetchShield.Name = "cboxFetchShield";
            this.cboxFetchShield.Size = new System.Drawing.Size(55, 17);
            this.cboxFetchShield.TabIndex = 8;
            this.cboxFetchShield.Text = "Shield";
            this.cboxFetchShield.UseVisualStyleBackColor = true;
            // 
            // cboxFetchWeapon
            // 
            this.cboxFetchWeapon.AutoSize = true;
            this.cboxFetchWeapon.Location = new System.Drawing.Point(110, 37);
            this.cboxFetchWeapon.Name = "cboxFetchWeapon";
            this.cboxFetchWeapon.Size = new System.Drawing.Size(67, 17);
            this.cboxFetchWeapon.TabIndex = 7;
            this.cboxFetchWeapon.Text = "Weapon";
            this.cboxFetchWeapon.UseVisualStyleBackColor = true;
            // 
            // cboxFetchJewelry
            // 
            this.cboxFetchJewelry.AutoSize = true;
            this.cboxFetchJewelry.Location = new System.Drawing.Point(33, 61);
            this.cboxFetchJewelry.Name = "cboxFetchJewelry";
            this.cboxFetchJewelry.Size = new System.Drawing.Size(61, 17);
            this.cboxFetchJewelry.TabIndex = 6;
            this.cboxFetchJewelry.Text = "Jewelry";
            this.cboxFetchJewelry.UseVisualStyleBackColor = true;
            // 
            // cboxFetchArmor
            // 
            this.cboxFetchArmor.AutoSize = true;
            this.cboxFetchArmor.Location = new System.Drawing.Point(33, 37);
            this.cboxFetchArmor.Name = "cboxFetchArmor";
            this.cboxFetchArmor.Size = new System.Drawing.Size(53, 17);
            this.cboxFetchArmor.TabIndex = 5;
            this.cboxFetchArmor.Text = "Armor";
            this.cboxFetchArmor.UseVisualStyleBackColor = true;
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(55, 84);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(75, 23);
            this.btnFetch.TabIndex = 4;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(8, 14);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(41, 13);
            this.lblItemID.TabIndex = 3;
            this.lblItemID.Text = "Item ID";
            // 
            // txtItemID
            // 
            this.txtItemID.Location = new System.Drawing.Point(55, 11);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(133, 20);
            this.txtItemID.TabIndex = 1;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.gboxSQLConnection);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(674, 653);
            this.tabSettings.TabIndex = 4;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // gboxSQLConnection
            // 
            this.gboxSQLConnection.Controls.Add(this.btnTestConnection);
            this.gboxSQLConnection.Controls.Add(this.lblSQLNote);
            this.gboxSQLConnection.Controls.Add(this.lblSQLDatabaseName);
            this.gboxSQLConnection.Controls.Add(this.txtSQLDatabaseName);
            this.gboxSQLConnection.Controls.Add(this.lblSQLPassword);
            this.gboxSQLConnection.Controls.Add(this.lblSQLUsername);
            this.gboxSQLConnection.Controls.Add(this.txtSQLPassword);
            this.gboxSQLConnection.Controls.Add(this.txtSQLUsername);
            this.gboxSQLConnection.Controls.Add(this.lblSQLAddress);
            this.gboxSQLConnection.Controls.Add(this.txtSQLAddress);
            this.gboxSQLConnection.Controls.Add(this.cboxLogToSQL);
            this.gboxSQLConnection.Location = new System.Drawing.Point(8, 8);
            this.gboxSQLConnection.Name = "gboxSQLConnection";
            this.gboxSQLConnection.Size = new System.Drawing.Size(377, 167);
            this.gboxSQLConnection.TabIndex = 0;
            this.gboxSQLConnection.TabStop = false;
            this.gboxSQLConnection.Text = "SQL Connection";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(234, 97);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(123, 23);
            this.btnTestConnection.TabIndex = 1;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // lblSQLNote
            // 
            this.lblSQLNote.AutoSize = true;
            this.lblSQLNote.Location = new System.Drawing.Point(39, 135);
            this.lblSQLNote.Name = "lblSQLNote";
            this.lblSQLNote.Size = new System.Drawing.Size(291, 13);
            this.lblSQLNote.TabIndex = 9;
            this.lblSQLNote.Text = "*Note: These settings are stored in an unencrypted XML file!";
            // 
            // lblSQLDatabaseName
            // 
            this.lblSQLDatabaseName.AutoSize = true;
            this.lblSQLDatabaseName.Location = new System.Drawing.Point(8, 100);
            this.lblSQLDatabaseName.Name = "lblSQLDatabaseName";
            this.lblSQLDatabaseName.Size = new System.Drawing.Size(87, 13);
            this.lblSQLDatabaseName.TabIndex = 8;
            this.lblSQLDatabaseName.Text = "Database Name:";
            // 
            // txtSQLDatabaseName
            // 
            this.txtSQLDatabaseName.Location = new System.Drawing.Point(101, 97);
            this.txtSQLDatabaseName.Name = "txtSQLDatabaseName";
            this.txtSQLDatabaseName.Size = new System.Drawing.Size(100, 20);
            this.txtSQLDatabaseName.TabIndex = 7;
            // 
            // lblSQLPassword
            // 
            this.lblSQLPassword.AutoSize = true;
            this.lblSQLPassword.Location = new System.Drawing.Point(39, 74);
            this.lblSQLPassword.Name = "lblSQLPassword";
            this.lblSQLPassword.Size = new System.Drawing.Size(56, 13);
            this.lblSQLPassword.TabIndex = 6;
            this.lblSQLPassword.Text = "Password:";
            // 
            // lblSQLUsername
            // 
            this.lblSQLUsername.AutoSize = true;
            this.lblSQLUsername.Location = new System.Drawing.Point(37, 48);
            this.lblSQLUsername.Name = "lblSQLUsername";
            this.lblSQLUsername.Size = new System.Drawing.Size(58, 13);
            this.lblSQLUsername.TabIndex = 5;
            this.lblSQLUsername.Text = "Username:";
            // 
            // txtSQLPassword
            // 
            this.txtSQLPassword.Location = new System.Drawing.Point(101, 71);
            this.txtSQLPassword.Name = "txtSQLPassword";
            this.txtSQLPassword.Size = new System.Drawing.Size(100, 20);
            this.txtSQLPassword.TabIndex = 4;
            // 
            // txtSQLUsername
            // 
            this.txtSQLUsername.Location = new System.Drawing.Point(101, 45);
            this.txtSQLUsername.Name = "txtSQLUsername";
            this.txtSQLUsername.Size = new System.Drawing.Size(100, 20);
            this.txtSQLUsername.TabIndex = 3;
            // 
            // lblSQLAddress
            // 
            this.lblSQLAddress.AutoSize = true;
            this.lblSQLAddress.Location = new System.Drawing.Point(47, 22);
            this.lblSQLAddress.Name = "lblSQLAddress";
            this.lblSQLAddress.Size = new System.Drawing.Size(48, 13);
            this.lblSQLAddress.TabIndex = 2;
            this.lblSQLAddress.Text = "Address:";
            // 
            // txtSQLAddress
            // 
            this.txtSQLAddress.Location = new System.Drawing.Point(101, 19);
            this.txtSQLAddress.Name = "txtSQLAddress";
            this.txtSQLAddress.Size = new System.Drawing.Size(100, 20);
            this.txtSQLAddress.TabIndex = 1;
            // 
            // cboxLogToSQL
            // 
            this.cboxLogToSQL.AutoSize = true;
            this.cboxLogToSQL.Location = new System.Drawing.Point(258, 61);
            this.cboxLogToSQL.Name = "cboxLogToSQL";
            this.cboxLogToSQL.Size = new System.Drawing.Size(84, 17);
            this.cboxLogToSQL.TabIndex = 0;
            this.cboxLogToSQL.Text = "Log To SQL";
            this.cboxLogToSQL.UseVisualStyleBackColor = true;
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.btnDebug);
            this.tabDebug.Controls.Add(this.txtDebug);
            this.tabDebug.Location = new System.Drawing.Point(4, 22);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Size = new System.Drawing.Size(674, 653);
            this.tabDebug.TabIndex = 5;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(596, 627);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 1;
            this.btnDebug.Text = "Go";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // txtDebug
            // 
            this.txtDebug.Location = new System.Drawing.Point(3, 3);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebug.Size = new System.Drawing.Size(668, 574);
            this.txtDebug.TabIndex = 0;
            // 
            // workerSearch
            // 
            this.workerSearch.WorkerReportsProgress = true;
            this.workerSearch.WorkerSupportsCancellation = true;
            this.workerSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerSearch_DoWork);
            this.workerSearch.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerSearch_ProgressChanged);
            this.workerSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerSearch_RunWorkerCompleted);
            // 
            // workerFetch
            // 
            this.workerFetch.WorkerReportsProgress = true;
            this.workerFetch.WorkerSupportsCancellation = true;
            this.workerFetch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerFetch_DoWork);
            this.workerFetch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerFetch_RunWorkerCompleted);
            // 
            // workerDebug
            // 
            this.workerDebug.WorkerReportsProgress = true;
            this.workerDebug.WorkerSupportsCancellation = true;
            this.workerDebug.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerDebug_DoWork);
            this.workerDebug.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerDebug_ProgressChanged);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(168, 607);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(156, 23);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Export for Web";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 691);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "(unisharp) LootLogger v0.0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.tabFetch.ResumeLayout(false);
            this.tabFetch.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.gboxSQLConnection.ResumeLayout(false);
            this.gboxSQLConnection.PerformLayout();
            this.tabDebug.ResumeLayout(false);
            this.tabDebug.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtLootList;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.ComponentModel.BackgroundWorker workerSearch;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnSearchAll;
        private System.Windows.Forms.CheckBox cboxJewelry;
        private System.Windows.Forms.CheckBox cboxArmor;
        private System.Windows.Forms.Button btnRemoveDupes;
        private System.Windows.Forms.TabPage tabFetch;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.TextBox txtItemID;
        private System.ComponentModel.BackgroundWorker workerFetch;
        private System.Windows.Forms.TextBox txtMissingItems;
        private System.Windows.Forms.Label lblTypesToLog;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Label lblMissedItems;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox gboxSQLConnection;
        private System.Windows.Forms.Label lblSQLNote;
        private System.Windows.Forms.Label lblSQLDatabaseName;
        private System.Windows.Forms.TextBox txtSQLDatabaseName;
        private System.Windows.Forms.Label lblSQLPassword;
        private System.Windows.Forms.Label lblSQLUsername;
        private System.Windows.Forms.TextBox txtSQLPassword;
        private System.Windows.Forms.TextBox txtSQLUsername;
        private System.Windows.Forms.Label lblSQLAddress;
        private System.Windows.Forms.TextBox txtSQLAddress;
        private System.Windows.Forms.CheckBox cboxLogToSQL;
        private System.Windows.Forms.CheckBox cboxWeapons;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.CheckBox cboxShields;
        private System.Windows.Forms.CheckBox cboxFetchShield;
        private System.Windows.Forms.CheckBox cboxFetchWeapon;
        private System.Windows.Forms.CheckBox cboxFetchJewelry;
        private System.Windows.Forms.CheckBox cboxFetchArmor;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.TextBox txtDebug;
        private System.ComponentModel.BackgroundWorker workerDebug;
        private System.Windows.Forms.Button btnExport;
    }
}

