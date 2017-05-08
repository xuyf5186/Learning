using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    static class Player
    {
        #region prop
        public static Number MaxHp { get; set; }
        public static Number MoneyMaxHp { get; set; }
        public static Number Hp { get; set; }
        public static Number MaxMp { get; set; }
        public static Number MoneyMaxMp { get; set; }
        public static Number Mp { get; set; }
        public static Number HpRecovery { get; set; }
        public static Number MoneyHpRecovery { get; set; }
        public static Number MpRecovery { get; set; }
        public static Number MoneyMpRecovery { get; set; }
        public static Number Damage { get; set; }
        public static Number MoneyDamage { get; set; }
        public static int Block{ get; set; }
        public static Number MoneyBlock { get; set; }
        public static int GoldGet { get; set; }//金币倍率 /100
        public static Number MoneyGoldGet { get; set; }
        public static int EquipGet { get; set; }//装备爆率 /100
        public static Number MoneyEquipGet { get; set; }
        public static int Crit{ get; set; }
        public static Number MoneyCrit { get; set; }
        public static Number Gold { get; set; }
        public static Number Equipment { get; set; }
        public static int Sp { get; set; }//技能点
        public static int AtRate { get; set; }//攻速

        public static Number MaxExp { get; set; }

        public static Number Exp { get; set; }
        #endregion
        static Player()
        {
            MaxHp = new Number(200, 0);
            Hp = new Number(200, 0);
            MaxMp = new Number(50, 0);
            Mp = new Number(50, 0);
            HpRecovery = new Number(3, 0);
            MpRecovery = new Number(3, 0);
            Damage = new Number(30, 0);
            GoldGet = 100;
            EquipGet = 20;
            Gold = new Number(0, 0);
            Block = 0;
            Crit = 0;
            Sp = 0;
            Equipment = new Number(0, 0);
            AtRate = 3000;
            Exp = new Number(0,0);
            MaxExp = new Number(1, 1);
            MoneyMaxHp = new Number(200, 0);
            MoneyMaxMp = new Number(200, 0);
            MoneyHpRecovery = new Number(200, 0);
            MoneyMpRecovery = new Number(200, 0);
            MoneyDamage = new Number(200, 0);
            MoneyBlock = new Number(200, 0);
            MoneyGoldGet = new Number(200, 0);
            MoneyEquipGet = new Number(200, 0);
            MoneyCrit = new Number(200, 0);
        }

        #region Add

        public static void AddMaxHp()
        {
            Gold -= MoneyMaxHp;
            MaxHp *= 1.5;
            MoneyMaxHp *= 1.5;
        }
        public static void AddMaxMp()
        {
            Gold -= MoneyMaxMp;
            MaxMp *= 1.5;
            MoneyMaxMp *= 1.5;
        }
        public static void AddHpRecovery()
        {
            Gold -= MoneyHpRecovery;
            HpRecovery *= 1.5;
            MoneyHpRecovery *= 1.2;
        }
        public static void AddMpRecovery()
        {
            Gold -= MoneyMpRecovery;
            MpRecovery *= 1.5;
            MoneyMpRecovery *= 1.2;
        }
        public static void AddDamage()
        {
            Gold -= MoneyDamage;
            Damage *= 1.5;
            MoneyDamage *= 1.2;
        }
        public static void AddGoldGet()
        {
            Gold -= MoneyGoldGet;
            GoldGet += 20;
            MoneyGoldGet *= 2;
        }
        public static bool AddEquipGet()
        {
            Gold -= MoneyEquipGet;
            EquipGet ++;
            MoneyEquipGet *= 1.5;
            if (EquipGet == 100) return false;
            return true;
        }
        public static bool AddCrit()
        {
            Gold -= MoneyCrit;
            Crit++;
            MoneyCrit *= 1.5;
            if (Crit == 50) return false;
            return true;
        }
        public static bool AddBlock()
        {
            Gold -= MoneyBlock;
            Block++;
            MoneyBlock *= 1.5;
            if (Block == 50) return false;
            return true;
        }
        #endregion

        public static string Attack(ref Enermy e)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int rblock = r.Next(1, 101);
            if(rblock<=e.Block)
            {
                return "你的攻击被" + e.Name + "抵挡了\r\n";
            }
            int rcrit = r.Next(1, 101);
            if(rcrit<=Crit)//玩家暴击
            {
                Number dm=Damage*2;
                e.Hp = e.Hp - dm;
                return "你对" + e.Name + "造成了" + dm.Num + dm.Unit + "的暴击伤害\r\n";
            }
            e.Hp = e.Hp - Damage;
            return "你对" + e.Name + "造成了" + Damage.Num + Damage.Unit + "的伤害\r\n";
        }
        public static string BeAttacked(Enermy e)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int rblock = r.Next(1, 101);
            if (rblock <= Block)
            {
                return "你抵挡了" + e.Name + "的攻击\r\n";
            }
            int rcrit = r.Next(1, 101);
            if (rcrit <= e.Crit)
            {
                Number dm = e.Damage * 2;
                Hp = Hp - dm;
                return "你受到了" + e.Name + dm.Num + dm.Unit + "的暴击伤害\r\n";
            }
            Hp = Hp - e.Damage;
            return "你受到了" + e.Name + e.Damage.Num + e.Damage.Unit + "的伤害\r\n";
        }

        public static void GetExp(Number exp)
        {
            Exp = Exp + exp;
            while(Exp>=MaxExp)
            {
                Exp = Exp - MaxExp;
                MaxExp=MaxExp*2;
                Sp++;
            }
        }
    }
}
