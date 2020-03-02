using System;
using System.Xml.Serialization;
using XScript.Items;

namespace LootLogger
{

    public class Shield
    {
        #region Vars
        private uint _id;
        private uint _containerId;
        private string _itemName;
        private bool _brittle;
        private bool _sc;

        private sbyte _str;
        private sbyte _intel;
        private sbyte _dex;
        private sbyte _hp;
        private sbyte _mana;
        private sbyte _stam;

        private sbyte _hpRegen;
        private sbyte _manaRegen;
        private sbyte _stamRegen;
        private sbyte _lmc;
        private sbyte _lrc;

        private sbyte _di;
        private sbyte _ssi;
        private sbyte _fc;
        private sbyte _dci;
        private sbyte _hci;
        private short _luck;
        private sbyte _enhancePotions;
        private sbyte _rpd;

        private DateTime _added;
        #endregion

        #region Properties
        public uint ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public uint ContainerID
        {
            get { return _containerId; }
            set { _containerId = value; }
        }
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }
        public bool Brittle
        {
            get { return _brittle; }
            set { _brittle = value; }
        }
        public bool SC
        {
            get { return _sc; }
            set { _sc = value; }
        }
        public sbyte STR
        {
            get { return _str; }
            set { _str = value; }
        }
        public sbyte INTEL
        {
            get { return _intel; }
            set { _intel = value; }
        }
        public sbyte DEX
        {
            get { return _dex; }
            set { _dex = value; }
        }
        public sbyte HP
        {
            get { return _hp; }
            set { _hp = value; }
        }
        public sbyte Mana
        {
            get { return _mana; }
            set { _mana = value; }
        }
        public sbyte Stam
        {
            get { return _stam; }
            set { _stam = value; }
        }
        public sbyte HPRegen
        {
            get { return _hpRegen; }
            set { _hpRegen = value; }
        }
        public sbyte ManaRegen
        {
            get { return _manaRegen; }
            set { _manaRegen = value; }
        }
        public sbyte StamRegen
        {
            get { return _stamRegen; }
            set { _stamRegen = value; }
        }
        public sbyte LMC
        {
            get { return _lmc; }
            set { _lmc = value; }
        }
        public sbyte LRC
        {
            get { return _lrc; }
            set { _lrc = value; }
        }
        public sbyte DI
        {
            get { return _di; }
            set { _di = value; }
        }
        public sbyte SSI
        {
            get { return _ssi; }
            set { _ssi = value; }
        }
        public sbyte FC
        {
            get { return _fc; }
            set { _fc = value; }
        }
        public sbyte DCI
        {
            get { return _dci; }
            set { _dci = value; }
        }
        public sbyte HCI
        {
            get { return _hci; }
            set { _hci = value; }
        }
        public short Luck
        {
            get { return _luck; }
            set { _luck = value; }
        }
        public sbyte EnhancePotions
        {
            get { return _enhancePotions; }
            set { _enhancePotions = value; }
        }
        public sbyte RPD
        {
            get { return _rpd; }
            set { _rpd = value; }
        }
        [XmlIgnore]
        public DateTime Added
        {
            get { return _added; }
            set { _added = value; }
        }
        [XmlElement("Added")]
        public string DateAdded
        {
            get { return this.Added.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { this.Added = DateTime.Parse(value); }
        }
        #endregion

        #region Constructors
        public Shield()
        {
        }

        public Shield(BaseShield Item, uint ContainerID)
        {
            Item.UpdateLocalizedProperties();
            Item.UpdateTextProperties();

            //General
            ID = Item.Serial.Value;
            this.ContainerID = ContainerID;
            ItemName = Item.Tooltip.Split('|')[0];
            SC = Item.Attributes.SpellChanneling;
            DI = (sbyte)Item.Attributes.WeaponDamage;
            SSI = (sbyte)Item.Attributes.WeaponSpeed;
            FC = (sbyte)Item.Attributes.CastSpeed;
            RPD = (sbyte)Item.Attributes.ReflectPhysical;
            DCI = (sbyte)Item.Attributes.DefendChance;
            HCI = (sbyte)Item.Attributes.AttackChance;
            STR = (sbyte)Item.Attributes.BonusStr;
            DEX = (sbyte)Item.Attributes.BonusDex;
            INTEL = (sbyte)Item.Attributes.BonusInt;
            HP = (sbyte)Item.Attributes.BonusHits;
            Stam = (sbyte)Item.Attributes.BonusStam;
            Mana = (sbyte)Item.Attributes.BonusMana;
            HPRegen = (sbyte)Item.Attributes.RegenHits;
            StamRegen = (sbyte)Item.Attributes.RegenStam;
            ManaRegen = (sbyte)Item.Attributes.RegenMana;
            LMC = (sbyte)Item.Attributes.LowerManaCost;
            LRC = (sbyte)Item.Attributes.LowerRegCost;
            EnhancePotions = (sbyte)Item.Attributes.EnhancePotions;
            Luck = (short)Item.Attributes.Luck;
            Brittle = Item.Brittle;

            Added = DateTime.Now;

        }
        #endregion
    }
}
