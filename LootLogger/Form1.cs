using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using MoreLinq;
using ScriptSDK;
using StealthAPI;
using ScriptSDK.Attributes;
using ScriptSDK.Engines;
using ScriptSDK.Items;
using ScriptSDK.Mobiles;
using XScript.Items;
using XScript.Scripts.unisharpUO;
using XScript.Enumerations;

namespace LootLogger
{
    public partial class Form1 : Form
    {
        #region Vars
        private string FetchItemType;
        private bool CantReach;
        private List<Jewelry> JewelryList = new List<Jewelry>();
        private List<Armor> ArmorList = new List<Armor>();
        private List<Weapon> WeaponsList = new List<Weapon>();
        private List<Shield> ShieldList = new List<Shield>();
        private List<Item> MissingItems = new List<Item>();
        private string JewelryFilePath, ArmorFilePath, WeaponFilePath, ShieldFilePath, ScriptsPath;
        private string JewelryExportPath, ArmorExportPath, WeaponExportPath, ShieldExportPath;
        private List<Item> Containers = new List<Item>();
        private List<uint> ContainersSearched = new List<uint>();
        private bool Multisearch = false, LoggingJewelry = false, LoggingArmor = false, LoggingWeapons = false,
            LoggingShields = false;
        private uint FetchItem;
        #endregion

        #region Form
        public Form1()
        {
            InitializeComponent();

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment ad =
                    System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                this.Text = String.Format("Loot Logger - {0}", ad.CurrentVersion);


                if (Stealth.Client.GetConnectedStatus() == false)
                    MessageBox.Show("Please connect a profile in Stealth and try again.");
            }

            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Stealth");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Stealth\\LootLogger");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Stealth\\LootLogger\\Export");

            string _myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ScriptsPath = _myDocuments + "\\Stealth\\LootLogger";

            ArmorFilePath = ScriptsPath + "\\armor.xml";
            JewelryFilePath = ScriptsPath + "\\jewelry.xml";
            WeaponFilePath = ScriptsPath + "\\weapons.xml";
            ShieldFilePath = ScriptsPath + "\\shields.xml";

            ArmorExportPath = ScriptsPath + "\\Export\\armor.xml";
            JewelryExportPath = ScriptsPath + "\\Export\\jewelry.xml";
            WeaponExportPath = ScriptsPath + "\\Export\\weapons.xml";
            ShieldExportPath = ScriptsPath + "\\Export\\shields.xml";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion
        
        #region Search Tab
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoggingArmor = cboxArmor.Checked;
            LoggingJewelry = cboxJewelry.Checked;
            LoggingWeapons = cboxWeapons.Checked;
            LoggingShields = cboxShields.Checked;
            Multisearch = false;
            workerSearch.RunWorkerAsync();
        }
        private void btnSearchAll_Click(object sender, EventArgs e)
        {

            LoggingArmor = cboxArmor.Checked;
            LoggingJewelry = cboxJewelry.Checked;
            LoggingWeapons = cboxWeapons.Checked;
            LoggingShields = cboxShields.Checked;
            Multisearch = true;
            workerSearch.RunWorkerAsync();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFiles();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {

            try
            {
                XmlSerializer _armorDeserializer = new XmlSerializer(typeof(List<Armor>));
                TextReader _armorReader = new StreamReader(ArmorFilePath);
                object armorObj = _armorDeserializer.Deserialize(_armorReader);
                ArmorList = (List<Armor>)armorObj;
                _armorReader.Close();
                txtLootList.AppendLine("Armor loaded!");

                XmlSerializer _jewelryDeserializer = new XmlSerializer(typeof(List<Jewelry>));
                TextReader _jewelryReader = new StreamReader(JewelryFilePath);
                object jewelryObj = _jewelryDeserializer.Deserialize(_jewelryReader);
                JewelryList = (List<Jewelry>)jewelryObj;
                _jewelryReader.Close();
                txtLootList.AppendLine("Jewelry loaded!");

                XmlSerializer _weaponsDesarialized = new XmlSerializer(typeof(List<Weapon>));
                TextReader _weaponsReader = new StreamReader(WeaponFilePath);
                object weaponObj = _weaponsDesarialized.Deserialize(_weaponsReader);
                WeaponsList = (List<Weapon>)weaponObj;
                _weaponsReader.Close();
                txtLootList.AppendLine("Weapons loaded!");

                XmlSerializer _shieldDeserializer = new XmlSerializer(typeof(List<Shield>));
                TextReader _shieldReader = new StreamReader(ShieldFilePath);
                object shieldObj = _shieldDeserializer.Deserialize(_shieldReader);
                ShieldList = (List<Shield>)shieldObj;
                _shieldReader.Close();
                txtLootList.AppendLine("Shields loaded!");

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }
        }
        private void btnClearList_Click(object sender, EventArgs e)
        {
            ArmorList = new List<Armor>();
            JewelryList = new List<Jewelry>();
            WeaponsList = new List<Weapon>();
            ShieldList = new List<Shield>();
        }
        private void btnRemoveDupes_Click(object sender, EventArgs e)
        {
            txtLootList.AppendLine(ArmorList.Count().ToString() + " armor items before.");
            txtLootList.AppendLine(JewelryList.Count().ToString() + " jewelry items before.");
            txtLootList.AppendLine(WeaponsList.Count().ToString() + " weapon items before.");
            txtLootList.AppendLine(ShieldList.Count().ToString() + " shield items before.");

            ArmorList = ArmorList.DistinctBy(x => x.ID).ToList();
            JewelryList = JewelryList.DistinctBy(x => x.ID).ToList();
            WeaponsList = WeaponsList.DistinctBy(x => x.ID).ToList();
            ShieldList = ShieldList.DistinctBy(x => x.ID).ToList();

            txtLootList.AppendLine(ArmorList.Count().ToString() + " armor items after.");
            txtLootList.AppendLine(JewelryList.Count().ToString() + " jewelry items after.");
            txtLootList.AppendLine(WeaponsList.Count().ToString() + " weapon items after.");
            txtLootList.AppendLine(ShieldList.Count().ToString() + " weapon items after.");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportFiles();
        }
        private void workerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Scanner.Initialize();

                Scanner.Range = 20;
                Scanner.VerticalRange = 0;

                //start the stopwatch for searching
                Stopwatch _loggerWatch = new Stopwatch();
                Stopwatch _moverWatch = new Stopwatch();
                _loggerWatch.Start();
                _moverWatch.Start();

                if (Multisearch == true)
                {

                    //Stealth.Client.ClilocSpeech += onClilocSpeech;

                    FindContainers();

                    foreach (Item _item in Containers)
                    {
                        workerSearch.ReportProgress(0, "moving to next container...");
                        _moverWatch.Restart();

                        while (_item.Distance > 1)
                        {
                            if (_moverWatch.Elapsed.Seconds > 15)
                                break;

                            workerSearch.ReportProgress(0, "trying to move...");
                            var _movingHelper = MovingHelper.GetMovingHelper();
                            _movingHelper.newMoveXY((ushort)_item.Location.X, (ushort)_item.Location.Y, true, 1, false);

                            Thread.Sleep(250);
                        }

                        SearchContainer(_item);
                        FindContainers();
                    }


                    Stealth.Client.ClilocSpeech -= onClilocSpeech;
                }
                else
                {
                    Item _result = RequestTarget();
                    Item _container = new Item(new Serial(_result.Serial.Value));
                    SearchContainer(_container);
                }

                _loggerWatch.Stop();
                
                workerSearch.ReportProgress(0, "Finished searching!");
                workerSearch.ReportProgress(0, "Took: " + _loggerWatch.Elapsed);

                workerSearch.CancelAsync();
            }
            catch (Exception x)
            {
                workerSearch.ReportProgress(0, "Exception Message: " + x.Message.ToString());
                workerSearch.ReportProgress(0, "Exception Stack Trace: " + x.StackTrace.ToString());
                workerSearch.ReportProgress(0, "Exception Source: " + x.Source.ToString());
                workerSearch.CancelAsync();
            }
        }
        private void workerSearch_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            txtLootList.AppendLine(e.UserState.ToString());
        }
        private void workerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                SaveFiles();

                if (MissingItems.Count > 0)
                {
                    txtLootList.AppendLine(MissingItems.Count + " missing items found!");
                    foreach (Item _item in MissingItems)
                    {
                        _item.UpdateTextProperties();
                        txtMissingItems.AppendLine(_item.Serial.Value + ' ' + _item.Tooltip);
                    }
                }
                else
                    txtMissingItems.AppendLine("No missing items found!");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }

        }
        #endregion
        
        #region Fetch Tab
        private void btnFetch_Click(object sender, EventArgs e)
        {
            FetchItem = Convert.ToUInt32(txtItemID.Text);
            if (cboxFetchArmor.Checked)
                FetchItemType = "Armor";
            else if (cboxFetchJewelry.Checked)
                FetchItemType = "Jewelry";
            else if (cboxFetchWeapon.Checked)
                FetchItemType = "Weapon";
            else if (cboxFetchShield.Checked)
                FetchItemType = "Shield";
            else
            {
                MessageBox.Show("Select item type!");
                return;
            }

            workerFetch.RunWorkerAsync();

        }
        private void workerFetch_DoWork(object sender, DoWorkEventArgs e)
        {
            PlayerMobile _self = PlayerMobile.GetPlayer();
            var _fetchItem = new Item(new Serial(FetchItem));
            var _fetchContainer = new Item(new Serial(FetchItem));

            if (FetchItemType == "Armor")
                _fetchContainer = new Item(new Serial(ArmorList.Where(x => x.ID == FetchItem).First().ContainerID));
            else if (FetchItemType == "Jewelry")
                _fetchContainer = new Item(new Serial(JewelryList.Where(x => x.ID == FetchItem).First().ContainerID));
            else if (FetchItemType == "Weapon")
                _fetchContainer = new Item(new Serial(WeaponsList.Where(x => x.ID == FetchItem).First().ContainerID));
            else if (FetchItemType == "Shield")
                _fetchContainer = new Item(new Serial(ShieldList.Where(x => x.ID == FetchItem).First().ContainerID));


            var _moveHelper = MovingHelper.GetMovingHelper();

            while (_fetchContainer.Distance > 1)
            {
                _moveHelper.newMoveXY((ushort)_fetchContainer.Location.X, (ushort)_fetchContainer.Location.Y, true, 1, false);
            }

            _fetchContainer.DoubleClick();

            Thread.Sleep(1500);

            List<uint> _findList = new List<uint>();
            List<Item> _container = new List<Item>();
            Stealth.Client.FindTypeEx(0xFFFF, 0xFFFF, _fetchContainer.Serial.Value, false);
            if (!(Stealth.Client.GetFindCount() == 0))
                _findList = Stealth.Client.GetFindList();

            foreach (uint _item in _findList)
            {
                _container.Add(new Item(new Serial(_item)));
            }

            foreach (Item _i in _container)
            {
                if (_i.Serial.Value == FetchItem)
                    MessageBox.Show("true");

            }
            Stealth.Client.MoveItem(_fetchItem.Serial.Value, 1, _self.Backpack.Serial.Value, 0, 0, 0);

            workerFetch.CancelAsync();

        }
        private void workerFetch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        #endregion

        #region Settings Tab
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string _connectionString = null;
            SqlConnection _cnn;

            _connectionString = "Data Source=" + txtSQLAddress + ",3306;" +
                "Network Library=DBMSSOCN;" +
                "Initial Catalog=" + txtSQLDatabaseName + ';' +
                "User ID=" + txtSQLUsername + ';' +
                "Password=" + txtSQLPassword + ';';
            _cnn = new SqlConnection(_connectionString);
            try
            {
                _cnn.Open();
                MessageBox.Show("Conection Open!");
                _cnn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }
        }

        #endregion

        #region Debug Tab
        private void btnDebug_Click(object sender, EventArgs e)
        {
            workerDebug.RunWorkerAsync();
        }
        private void workerDebug_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                Scanner.Initialize();

                Scanner.Range = 20;
                Scanner.VerticalRange = 0;

                //start the stopwatch for searching
                Stopwatch _loggerWatch = new Stopwatch();
                Stopwatch _moverWatch = new Stopwatch();
                _loggerWatch.Start();
                _moverWatch.Start();

                Item _result = RequestTarget();
                Item _container = new Item(new Serial(_result.Serial.Value));

                workerDebug.ReportProgress(0, "Starting search...");
                LocateGear.Find(_container, new List<string> { "Armor", "Weapon", "Shield", "Jewel" });


                foreach (BaseArmor _armor in LocateGear.ArmorList)
                {
                    _armor.UpdateLocalizedProperties();

                    if (_armor.Cursed || _armor.Antique)
                        continue;

                    if (_armor.LootValue.Equals(LootValue.LegendaryArtifact) || _armor.LootValue.Equals(LootValue.MajorArtifact))
                        workerDebug.ReportProgress(0, _armor.Serial.Value.ToString() +  "Legendary/Major Armor");
                    else if (!(_armor.MaterialType.Equals(ArmorMaterialType.Bone) || _armor.MaterialType.Equals(ArmorMaterialType.Studded)))
                        if (_armor.Attributes.LowerManaCost >= 8 && _armor.Attributes.BonusHits >= 5)
                            workerDebug.ReportProgress(0, _armor.Serial.Value.ToString() + "HP Studded/Bone");
                        else if (_armor.Attributes.BonusStam == 10)
                            workerDebug.ReportProgress(0, _armor.Serial.Value.ToString() +  "Stam Studded/Bone");
                }

                foreach (BaseWeapon _weapon in LocateGear.WeaponList)
                {
                    _weapon.UpdateLocalizedProperties();

                    if (_weapon.Cursed || _weapon.Antique)
                        continue;

                    if (_weapon.WeaponAttributes.SplinteringWeapon >= 20)
                        workerDebug.ReportProgress(0, _weapon.Serial.Value.ToString() + "Splintering Weapon");
                    else if (_weapon.LootValue.Equals(LootValue.LegendaryArtifact) || _weapon.LootValue.Equals(LootValue.MajorArtifact))
                        if (_weapon.Attributes.CastSpeed == 0 && _weapon.Attributes.SpellChanneling)
                            workerDebug.ReportProgress(0, _weapon.Serial.Value.ToString() + "Mage Weapon");
                        else if (_weapon.Attributes.WeaponSpeed >= 30)
                            workerDebug.ReportProgress(0, _weapon.Serial.Value.ToString() + "Warrior Weapon");
                }

                foreach (BaseShield _shield in LocateGear.ShieldList)
                {
                    _shield.UpdateLocalizedProperties();

                    if (_shield.Cursed || _shield.Antique)
                        continue;

                    if (!(_shield.LootValue.Equals(LootValue.LegendaryArtifact) || _shield.LootValue.Equals(LootValue.MajorArtifact)))
                        continue;

                    if (_shield.Attributes.CastSpeed == 0 && _shield.Attributes.SpellChanneling)
                        workerDebug.ReportProgress(0, _shield.Serial.Value.ToString() + "Mage Shield");
                    else if (_shield.Attributes.WeaponSpeed >= 5 && _shield.Attributes.WeaponDamage >= 5)
                        workerDebug.ReportProgress(0, _shield.Serial.Value.ToString() + "Warrior Shield");
                }

                foreach (BaseJewel _jewel in LocateGear.JewelList)
                {

                    _jewel.UpdateLocalizedProperties();

                    if (_jewel.Cursed || _jewel.Antique)
                        continue;

                    if (_jewel.LootValue.Equals(LootValue.LegendaryArtifact) || _jewel.LootValue.Equals(LootValue.MajorArtifact))
                        workerDebug.ReportProgress(0, _jewel.Serial.Value.ToString() + "Legendary/Major Jewel");
                    else if (_jewel.Attributes.WeaponSpeed >= 5
                        && _jewel.Attributes.WeaponDamage >= 5
                        && _jewel.Attributes.AttackChance >= 15)
                        workerDebug.ReportProgress(0, _jewel.Serial.Value.ToString() + "Dexer Jewel");
                }

                _loggerWatch.Stop();

                workerDebug.ReportProgress(0, "Finished searching!");
                workerDebug.ReportProgress(0, "Took: " + _loggerWatch.Elapsed);

                workerDebug.CancelAsync();
            }
            catch (Exception x)
            {
                workerDebug.ReportProgress(0, "Exception Message: " + x.Message.ToString());
                workerDebug.ReportProgress(0, "Exception Stack Trace: " + x.StackTrace.ToString());
                workerDebug.ReportProgress(0, "Exception Source: " + x.Source.ToString());
                workerDebug.CancelAsync();
            }
        }
        private void workerDebug_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            txtDebug.AppendLine(e.UserState.ToString());

        }
        #endregion

        #region Methods
        private void ExportFiles()
        {

            try
            {
                string _startA = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>";
                File.WriteAllText(ArmorExportPath, _startA);
                using (StreamWriter sw = File.AppendText(ArmorExportPath))
                {
                    sw.WriteLine("<armors>");
                }

                using (StreamWriter sw = File.AppendText(ArmorExportPath))
                {
                    foreach (Armor _a in ArmorList)
                    {
                        string _line = "";
                        int _i = 0;
                        int _len = _a.GetType().GetProperties().Count();

                        foreach (var property in _a.GetType().GetProperties())
                        {
                            ++_i;

                            if (_i == 1)
                                _line += "<armor ";

                            _line += property.Name + "=\"" + property.GetValue(_a, null) + "\" ";


                            if (_i == _len)
                                _line += "/>";
                        }

                        sw.WriteLine(_line);
                    }
                    sw.WriteLine("</armors>");
                }


                string _startJ = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>";
                File.WriteAllText(JewelryExportPath, _startJ);
                using (StreamWriter sw = File.AppendText(JewelryExportPath))
                {
                    sw.WriteLine("<jewelry>");
                }

                using (StreamWriter sw = File.AppendText(JewelryExportPath))
                {
                    foreach (Jewelry _a in JewelryList)
                    {
                        string _line = "";
                        int _i = 0;
                        int _len = _a.GetType().GetProperties().Count();

                        foreach (var property in _a.GetType().GetProperties())
                        {
                            ++_i;

                            if (_i == 1)
                                _line += "<jewel ";

                            _line += property.Name + "=\"" + property.GetValue(_a, null) + "\" ";


                            if (_i == _len)
                                _line += "/>";
                        }

                        sw.WriteLine(_line);
                    }
                    sw.WriteLine("</jewelry>");
                }


                string _startS = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>";
                File.WriteAllText(ShieldExportPath, _startS);
                using (StreamWriter sw = File.AppendText(ShieldExportPath))
                {
                    sw.WriteLine("<shields>");
                }

                using (StreamWriter sw = File.AppendText(ShieldExportPath))
                {
                    foreach (Shield _a in ShieldList)
                    {
                        string _line = "";
                        int _i = 0;
                        int _len = _a.GetType().GetProperties().Count();

                        foreach (var property in _a.GetType().GetProperties())
                        {
                            ++_i;

                            if (_i == 1)
                                _line += "<shield ";

                            _line += property.Name + "=\"" + property.GetValue(_a, null) + "\" ";

                            if (_i == _len)
                                _line += "/>";
                        }
                        sw.WriteLine(_line);
                    }
                    sw.WriteLine("</shields>");
                }


                string _startW = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>";
                File.WriteAllText(WeaponExportPath, _startW);
                using (StreamWriter sw = File.AppendText(WeaponExportPath))
                {
                    sw.WriteLine("<weapons>");
                }

                using (StreamWriter sw = File.AppendText(WeaponExportPath))
                {
                    foreach (Weapon _a in WeaponsList)
                    {
                        string _line = "";
                        int _i = 0;
                        int _len = _a.GetType().GetProperties().Count();

                        foreach (var property in _a.GetType().GetProperties())
                        {
                            ++_i;

                            if (_i == 1)
                                _line += "<weapon ";

                            _line += property.Name + "=\"" + property.GetValue(_a, null) + "\" ";


                            if (_i == _len)
                                _line += "/>";
                        }

                        sw.WriteLine(_line);
                    }
                    sw.WriteLine("</weapons>");
                }
            }
            catch (Exception x)
            {
                txtLootList.AppendLine("Exception Message: " + x.Message.ToString());
                txtLootList.AppendLine("Exception Stack Trace: " + x.StackTrace.ToString());
                txtLootList.AppendLine("Exception Source: " + x.InnerException.Message.ToString());
            }
        }
        private void CreateXMLFile(string Filename, string Node)
        {
            XmlDocument _doc = new XmlDocument();
            XmlNode _docNode = _doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            _doc.AppendChild(_docNode);
            XmlNode _rootNode = _doc.CreateElement(Node);
            _doc.AppendChild(_rootNode);
            StreamWriter _outStream = File.CreateText(Filename);
            _doc.Save(_outStream);
            _outStream.Close();
        }
        private void SaveFiles()
        {
            try
            {

                if (!File.Exists(ArmorFilePath))
                    CreateXMLFile(ArmorFilePath, "ArrayOfArmor");

                txtLootList.AppendLine("Saving armor...");
                
                XmlSerializer _armorSerializer = new XmlSerializer(typeof(List<Armor>));

                using (TextWriter _writer = new StreamWriter(ArmorFilePath))
                {
                    _armorSerializer.Serialize(_writer, ArmorList);
                }
                
                if (ArmorList.Count() > 1000)
                {
                    int _count = ArmorList.Count() / 1000;
                    int _remainder = ArmorList.Count() % 1000;
                    int _totalFiles;
                    if (_remainder > 0)
                    {
                        _totalFiles = _count + 1;
                    }
                    else
                        _totalFiles = _count;

                    for (int i = 0; i < _totalFiles; i++)
                    {
                        List<Armor> _splitList = new List<Armor>();
                        if (_remainder > 0 && i == (_totalFiles - 1))
                            _splitList = ArmorList.GetRange(i * 1000, _remainder);
                        else
                            _splitList = ArmorList.GetRange(i * 1000, 1000);

                        using (TextWriter _writer = new StreamWriter(ScriptsPath + "\\armor" + i.ToString() + ".xml"))
                        {
                            _armorSerializer.Serialize(_writer, _splitList);
                        }
                    }
                }
                txtLootList.AppendLine("Armor saved!");
                
                if (!File.Exists(JewelryFilePath))
                    CreateXMLFile(JewelryFilePath, "ArrayOfJewelry");

                txtLootList.AppendLine("Saving jewelry...");

                XmlSerializer _jewelrySerializer = new XmlSerializer(typeof(List<Jewelry>));

                using (TextWriter _writer = new StreamWriter(JewelryFilePath))
                {
                    _jewelrySerializer.Serialize(_writer, JewelryList);
                }

                if (JewelryList.Count() > 1000)
                {
                    int _count = JewelryList.Count() / 1000;
                    int _remainder = JewelryList.Count() % 1000;
                    int _totalFiles;
                    if (_remainder > 0)
                    {
                        _totalFiles = _count + 1;
                    }
                    else
                        _totalFiles = _count;

                    for (int i = 0; i < _totalFiles; i++)
                    {
                        List<Jewelry> _splitList = new List<Jewelry>();
                        if (_remainder > 0 && i == (_totalFiles - 1))
                            _splitList = JewelryList.GetRange(i * 1000, _remainder);
                        else
                            _splitList = JewelryList.GetRange(i * 1000, 1000);

                        using (TextWriter _writer = new StreamWriter(ScriptsPath + "\\jewelry" + i.ToString() + ".xml"))
                        {
                            _jewelrySerializer.Serialize(_writer, _splitList);
                        }
                    }
                }
                txtLootList.AppendLine("Jewelry saved!");


                if (!File.Exists(WeaponFilePath))
                    CreateXMLFile(WeaponFilePath, "ArrayOfWeapon");

                txtLootList.AppendLine("Saving weapons...");

                XmlSerializer _weaponSerializer = new XmlSerializer(typeof(List<Weapon>));

                using (TextWriter _writer = new StreamWriter(WeaponFilePath))
                {
                    _weaponSerializer.Serialize(_writer, WeaponsList);
                }

                if (WeaponsList.Count() > 1000)
                {
                    int _count = WeaponsList.Count() / 1000;
                    int _remainder = WeaponsList.Count() % 1000;
                    int _totalFiles;
                    if (_remainder > 0)
                    {
                        _totalFiles = _count + 1;
                    }
                    else
                        _totalFiles = _count;

                    for (int i = 0; i < _totalFiles; i++)
                    {
                        List<Weapon> _splitList = new List<Weapon>();
                        if (_remainder > 0 && i == (_totalFiles - 1))
                            _splitList = WeaponsList.GetRange(i * 1000, _remainder);
                        else
                            _splitList = WeaponsList.GetRange(i * 1000, 1000);

                        using (TextWriter _writer = new StreamWriter(ScriptsPath + "\\weapon" + i.ToString() + ".xml"))
                        {
                            _weaponSerializer.Serialize(_writer, _splitList);
                        }
                    }
                }
                txtLootList.AppendLine("Weapons saved!");

                if (!File.Exists(ShieldFilePath))
                    CreateXMLFile(ShieldFilePath, "ArrayOfShield");

                txtLootList.AppendLine("Saving shields...");

                XmlSerializer _shieldSerializer = new XmlSerializer(typeof(List<Shield>));

                using (TextWriter _writer = new StreamWriter(ShieldFilePath))
                {
                    _shieldSerializer.Serialize(_writer, ShieldList);
                }

                if (ShieldList.Count() > 1000)
                {
                    int _count = ShieldList.Count() / 1000;
                    int _remainder = ShieldList.Count() % 1000;
                    int _totalFiles;
                    if (_remainder > 0)
                    {
                        _totalFiles = _count + 1;
                    }
                    else
                        _totalFiles = _count;

                    for (int i = 0; i < _totalFiles; i++)
                    {
                        List<Shield> _splitList = new List<Shield>();
                        if (_remainder > 0 && i == (_totalFiles - 1))
                            _splitList = ShieldList.GetRange(i * 1000, _remainder);
                        else
                            _splitList = ShieldList.GetRange(i * 1000, 1000);

                        using (TextWriter _writer = new StreamWriter(ScriptsPath + "\\shields" + i.ToString() + ".xml"))
                        {
                            _shieldSerializer.Serialize(_writer, _splitList);
                        }
                    }
                }
                txtLootList.AppendLine("Shields saved!");

            }
            catch (Exception x)
            {
                txtLootList.AppendLine("Exception Message: " + x.Message.ToString());
                txtLootList.AppendLine("Exception Stack Trace: " + x.StackTrace.ToString());
                txtLootList.AppendLine("Exception Source: " + x.InnerException.Message.ToString());
            }
        }
        private void onClilocSpeech(object sender, ClilocSpeechEventArgs e)
        {
            switch (e.Text)
            {
                case "I can't reach that.":
                    CantReach = true;
                    break;

                default:
                    break;
            }
        }
        private void SearchContainer(Item Container)
        {

            CantReach = false;
            Container.DoubleClick();

            Thread.Sleep(250);

            if (CantReach)
                return;


            List<Item> _container = new List<Item>();
            List<uint> _findList = new List<uint>();

            Stealth.Client.FindTypeEx(0xFFFF, 0xFFFF, Container.Serial.Value, false);
            if (!(Stealth.Client.GetFindCount() == 0))
                _findList = Stealth.Client.GetFindList();

            foreach (uint _item in _findList)
            {
                _container.Add(new Item(new Serial(_item)));
            }

            workerSearch.ReportProgress(0, _container.Count() + " items found...");

            if (_container.Count == 0)
                return;

            List<uint> _firstList = new List<uint>();

            foreach (Item _item in _container)
            {
                _firstList.Add(_item.Serial.Value);
            }


            List<Item> _resultsList = new List<Item>();
            List<uint> _secondList = new List<uint>();

            List<string> _types = new List<string>();

            if (LoggingArmor)
                _types.Add("Armor");
            if (LoggingJewelry)
                _types.Add("Jewel");
            if (LoggingWeapons)
                _types.Add("Weapon");
            if (LoggingShields)
                _types.Add("Shield");

            LocateGear.Find(Container, _types);

            if (LoggingArmor)
                foreach (BaseArmor _armor in LocateGear.ArmorList)
                {
                    _secondList.Add(_armor.Serial.Value);
                    ArmorList.Add(new Armor(_armor, Container.Serial.Value));
                }
            if (LoggingJewelry)
                foreach (BaseJewel _jewel in LocateGear.JewelList)
                {
                    _secondList.Add(_jewel.Serial.Value);
                    JewelryList.Add(new Jewelry(_jewel, Container.Serial.Value));
                }
            if (LoggingWeapons)
                foreach (BaseWeapon _weapon in LocateGear.WeaponList)
                {
                    _secondList.Add(_weapon.Serial.Value);
                    WeaponsList.Add(new Weapon(_weapon, Container.Serial.Value));
                }
            if (LoggingShields)
                foreach (BaseShield _shield in LocateGear.ShieldList)
                {
                    _secondList.Add(_shield.Serial.Value);
                    ShieldList.Add(new Shield(_shield, Container.Serial.Value));
                }
            
            workerSearch.ReportProgress(0, "Checking for missed items...");
            List<uint> _missingItems = _firstList.Except(_secondList).ToList();
            
            foreach (uint _missingID in _missingItems)
            {
                Item _tempItem = new Item(new Serial(_missingID));
                MissingItems.Add(_tempItem);
            }

            ArmorList = ArmorList.DistinctBy(x => x.ID).ToList();
            JewelryList = JewelryList.DistinctBy(x => x.ID).ToList();
            WeaponsList = WeaponsList.DistinctBy(x => x.ID).ToList();
            ShieldList = ShieldList.DistinctBy(x => x.ID).ToList();

            ContainersSearched.Add(Container.Serial.Value);
            Scanner.Ignore(Container.Serial);
            //Stealth.Client.CloseClientUIWindow(UIWindowType.Container, Container.Serial.Value);


            workerSearch.ReportProgress(0, "Total Armor: " + ArmorList.Count().ToString());
            workerSearch.ReportProgress(0, "Total Jewelry: " + JewelryList.Count().ToString());
            workerSearch.ReportProgress(0, "Total Weapons: " + WeaponsList.Count().ToString());
            workerSearch.ReportProgress(0, "Total Shields: " + ShieldList.Count().ToString());


        }
        private void FindContainers()
        {
            try
            {
                Containers = Item.Find(typeof(BaseContainer), 0x0, true).OrderBy(x => x.Distance).ToList();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }

        }
        private static Item RequestTarget(uint TimeoutMS = 0)
        {
            Stealth.Client.ClientRequestObjectTarget();
            Stopwatch timer = new Stopwatch();


            timer.Start();
            while (Stealth.Client.ClientTargetResponsePresent() == false)
            {
                if (TimeoutMS != 0 && timer.ElapsedMilliseconds >= TimeoutMS)
                    return default(Item);
            }

            return new Item(new Serial(Stealth.Client.ClientTargetResponse().ID));
        }
        #endregion
    }
}
