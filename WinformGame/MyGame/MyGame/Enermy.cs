using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Enermy
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public Number MaxHp { get; set; }

        public Number Hp { get; set; }
      
        public Number Damage { get; set; }
        public int Block{ get; set; }
        public int Crit{ get; set; }

        public int AtRate { get; set; }//攻速

        public Number GiveExp { get; set; }

        public Number GiveGold { get; set; }
        public static double NxtDouble(Random random, double miniDouble, double maxiDouble)
        {
            if (random != null)
            {
                return random.NextDouble() * (maxiDouble - miniDouble) + miniDouble;
            }
            else
            {
                return 0.0d;
            }
        }
        public static Enermy Product(int deep)//生成怪物
        {
            int unit=deep/100;//每100层进一个单位
            int hh=deep%100;
            Random r = new Random(DateTime.Now.Millisecond);
            int num = r.Next(0, 100);
            string name="敌人";
            string level;
            Number rhp;
            Number rdam;
            int rblo;
            int rcri;
            int ratrate;
            Number rexp;
            Number rgold;
            double gl = deep*1.0 / 999;
            if(num>=90)//10%Boss怪
            {
                hh += 5;
                level = "首领";
                rblo = r.Next((int)(30 * gl), (int)(51 * gl));
                rcri = r.Next((int)(30 * gl), (int)(51 * gl));
            }
            else if(num>=70)//20%精英怪
            {
                hh += 2;
                level = "精英";
                rblo = r.Next((int)(20 * gl), (int)(51 * gl));
                rcri = r.Next((int)(20 * gl), (int)(51 * gl));
            }
            else//70%普通怪
            {
                level = "普通";
                rblo = r.Next(0, (int)(21 * gl));
                rcri = r.Next(0, (int)(21 * gl));
            }
            rhp = new Number(NxtDouble(r, hh * 50, (hh + 1) * 50), unit);
            rdam = new Number(NxtDouble(r, hh * 10, (hh + 1) * 10), unit);   
            ratrate = r.Next(3000, 5000);
            rexp = new Number(NxtDouble(r, hh * 100, (hh + 1) * 100), unit);
            rgold = new Number(NxtDouble(r, hh * 100, (hh + 1) * 100), unit);
            return new Enermy(name, level, rhp, rdam, rblo, rcri, ratrate, rexp, rgold);
        }
        public Enermy(string name, string level, Number hp, Number dam, int block, int crit, int atrate, Number exp, Number gold)
        {
            this.Level = level;
            this.Name = name;
            this.MaxHp = new Number(hp.num,hp.uindex);
            this.Hp = new Number(hp.num, hp.uindex);
            this.Damage = dam;
            this.Block = block;
            this.Crit = crit;
            this.AtRate = atrate;
            this.GiveExp = exp;
            this.GiveGold = gold;
        }
    }
}
