using System;
using System.Xml.Serialization;
using XScript.Items;

namespace LootLogger
{

    public class Armor
    {
        #region Vars
        private uint _id;
        private uint _containerId;
        private string _itemName;
        private int _rating;
        private string _skillBonuses;
        private sbyte _physicalResist;
        private sbyte _fireResist;
        private sbyte _coldResist;
        private sbyte _poisonResist;
        private sbyte _energyResist;
        private int _totalResist;

        private sbyte _damageEater;
        private sbyte _kineticEater;
        private sbyte _fireEater;
        private sbyte _coldEater;
        private sbyte _poisonEater;
        private sbyte _energyEater;

        private sbyte _str;
        private sbyte _intel;
        private sbyte _dex;
        private sbyte _hp;
        private sbyte _mana;
        private sbyte _stam;
        private int _totalStat;

        private sbyte _hpRegen;
        private sbyte _manaRegen;
        private sbyte _stamRegen;

        private sbyte _lmc;
        private sbyte _lrc;
        private sbyte _castingFocus;

        private sbyte _di;
        private sbyte _ssi;
        private sbyte _sdi;
        private sbyte _fc;
        private sbyte _fcr;
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
        public int Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }
        public string SkillBonuses
        {
            get { return _skillBonuses; }
            set { _skillBonuses = value; }
        }
        public sbyte PhysicalResist
        {
            get { return _physicalResist; }
            set { _physicalResist = value; }
        }
        public sbyte FireResist
        {
            get { return _fireResist; }
            set { _fireResist = value; }
        }
        public sbyte ColdResist
        {
            get { return _coldResist; }
            set { _coldResist = value; }
        }
        public sbyte PoisonResist
        {
            get { return _poisonResist; }
            set { _poisonResist = value; }
        }
        public sbyte EnergyResist
        {
            get { return _energyResist; }
            set { _energyResist = value; }
        }
        public int TotalResist
        {
            get { return _totalResist; }
            set { _totalResist = value; }
        }

        public sbyte DamageEater
        {
            get { return _damageEater; }
            set { _damageEater = value; }
        }
        public sbyte KineticEater
        {
            get { return _kineticEater; }
            set { _kineticEater = value; }
        }
        public sbyte FireEater
        {
            get { return _fireEater; }
            set { _fireEater = value; }
        }
        public sbyte ColdEater
        {
            get { return _coldEater; }
            set { _coldEater = value; }
        }
        public sbyte PoisonEater
        {
            get { return _poisonEater; }
            set { _poisonEater = value; }
        }
        public sbyte EnergyEater
        {
            get { return _energyEater; }
            set { _energyEater = value; }
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
        public int TotalStat
        {
            get { return _totalStat; }
            set { _totalStat = value; }
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
        public sbyte CastingFocus
        {
            get { return _castingFocus; }
            set { _castingFocus = value; }
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
        public sbyte FCR
        {
            get { return _fcr; }
            set { _fcr = value; }
        }
        public sbyte SDI
        {
            get { return _sdi; }
            set { _sdi = value; }
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
        public Armor()
        {
        }

        public Armor(BaseArmor Item, uint ContainerID)
        {
            Item.UpdateLocalizedProperties();
            Item.UpdateTextProperties();

            //General
            Rating = 0;
            ID = Item.Serial.Value;
            this.ContainerID = ContainerID;
            ItemName = Item.Tooltip.Split('|')[0].Replace("'", "");
            CastingFocus = (sbyte)Item.Attributes.CastingFocus;
            DI = (sbyte)Item.Attributes.WeaponDamage;
            SSI = (sbyte)Item.Attributes.WeaponSpeed;
            FC = (sbyte)Item.Attributes.CastSpeed;
            FCR = (sbyte)Item.Attributes.CastRecovery;
            SDI = (sbyte)Item.Attributes.SpellDamage;
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
            PhysicalResist = (sbyte)Item.Resistances.Physical;
            FireResist = (sbyte)Item.Resistances.Fire;
            ColdResist = (sbyte)Item.Resistances.Cold;
            PoisonResist = (sbyte)Item.Resistances.Poison;
            EnergyResist = (sbyte)Item.Resistances.Energy;
            DamageEater = (sbyte)Item.AbsorptionAttributes.DamageEater;
            KineticEater = (sbyte)Item.AbsorptionAttributes.KineticEater;
            FireEater = (sbyte)Item.AbsorptionAttributes.FireEater;
            ColdEater = (sbyte)Item.AbsorptionAttributes.ColdEater;
            PoisonEater = (sbyte)Item.AbsorptionAttributes.PoisonEater;
            EnergyEater = (sbyte)Item.AbsorptionAttributes.EnergyEater;
            TotalStat = STR + INTEL + DEX + HP + Mana + Stam;
            TotalResist = PhysicalResist +
                FireResist +
                ColdResist +
                PoisonResist +
                EnergyResist;
            Added = DateTime.Now;

            //Skill Bonuses
            SkillBonuses = "";

            ItemSkillName _skill1 = (ItemSkillName)Item.SkillBonuses.Skill_1_Name;
            ItemSkillName _skill2 = (ItemSkillName)Item.SkillBonuses.Skill_2_Name;
            ItemSkillName _skill3 = (ItemSkillName)Item.SkillBonuses.Skill_3_Name;
            ItemSkillName _skill4 = (ItemSkillName)Item.SkillBonuses.Skill_4_Name;
            ItemSkillName _skill5 = (ItemSkillName)Item.SkillBonuses.Skill_5_Name;

            string[][] _skillBonusesString = new string[][]
            {
                new string[] { Item.SkillBonuses.Skill_1_Value.ToString(), _skill1.ToString() },
                new string[] { Item.SkillBonuses.Skill_2_Value.ToString(), _skill2.ToString() },
                new string[] { Item.SkillBonuses.Skill_3_Value.ToString(), _skill3.ToString() },
                new string[] { Item.SkillBonuses.Skill_4_Value.ToString(), _skill4.ToString() },
                new string[] { Item.SkillBonuses.Skill_5_Value.ToString(), _skill5.ToString() },

            };
            int _totalSkill = 0;

            foreach (string[] _s in _skillBonusesString)
            {
                
                if (_s[1].Equals("Invalid"))
                    continue;
                else
                {
                    SkillBonuses = SkillBonuses + _s[0] + ' ' + _s[1];
                    _totalSkill += Int32.Parse(_s[0]);
                }
                    
            }

            SkillBonuses = SkillBonuses.Replace('_', ' ');


            //item rating
            Rating = (TotalResist / 4) + (TotalResist / 10);
            if (RPD > 0)
                Rating += (RPD / 5);
            if (DI >= 0)
                Rating += (DI / 5) + (DI / 10);
            if (HCI > 0)
                Rating += (HCI / 2) + (HCI / 3);
            if (DCI > 0)
                Rating += (DCI / 2) + (DCI / 3);
            if (HPRegen > 0)
                Rating += (HPRegen * 4);
            if (ManaRegen > 0)
                Rating += (ManaRegen * 4);
            if (StamRegen > 0)
                Rating += (StamRegen * 3);
            if (LRC > 0)
                Rating += (LRC / 2) + (LRC / 3);
            if (LMC > 0)
                Rating += (LMC / 2) + (LMC / 3);
            if (INTEL > 0)
                Rating += (INTEL / 2) + (INTEL / 3);
            if (DEX > 0)
                Rating += (DEX / 2) + (DEX / 3);
            if (STR > 0)
                Rating += (STR / 2) + (STR / 3);
            if (HP > 0)
                Rating += (HP / 2) + (HP / 3);
            if (Stam > 0)
                Rating += (Stam / 2) + (Stam / 3);
            if (Mana > 0)
                Rating += (Mana / 2) + (Mana / 3);
            int _totalEater = DamageEater +
                KineticEater +
                FireEater +
                ColdEater +
                PoisonEater +
                EnergyEater;
            if (_totalEater > 0)
                Rating += (_totalEater / 2) + (_totalEater / 5);
            if (_totalSkill > 0)
                Rating += (_totalSkill / 2);
            if (FC > 0)
                Rating += (FC * 6);
            if (FCR > 0)
                Rating += (FCR * 6);
            if (CastingFocus > 0)
                Rating += (CastingFocus / 3) + (CastingFocus / 10);
            if (SSI > 0)
                Rating += (SSI / 3) + (SSI / 10);
            if (SDI > 0)
                Rating += (SDI / 2);
            if (Luck > 0)
                Rating += (Luck / 11) + (Luck / 15);
            if (EnhancePotions > 0)
                Rating += (EnhancePotions / 6);


        }
        #endregion
    }
}
