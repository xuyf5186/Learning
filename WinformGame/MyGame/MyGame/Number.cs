using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Number
    {
        static string[] Units = {" ","K", "M", "B", "T","Qa","Qi","Sx","Sp","Oc" };//单位
        public double num;//数字
        public string Num
        {
            get
            {
                return num.ToString("F2");
            }
        }
        public int uindex;//单位下标
        public string Unit
        {
            get
            {
                return Units[uindex];
            }
        }

        public string Text
        {
            get
            {
                return num.ToString("F2")+Units[uindex];
            }
        }
        public Number(double num,int uindex)
        {
            this.num = num;
            this.uindex = uindex;
            while (num > 1000)
            {
                num /= 1000;
                this.num = num;
                this.uindex = uindex + 1;
            }
        }

        public Number(double n)
        {
            this.num = n;
            this.uindex = 0;
            while (num > 1000)
            {
                if (this.uindex == Units.Count() - 1) break;
                num /= 1000;
                this.num = n;
                this.uindex = uindex + 1;
            }
        }
        public static bool operator >(Number n1,Number n2)
        {
            if(n1.uindex>n2.uindex)
            {
                return true;
            }
            else if(n1.uindex==n2.uindex && n1.num>n2.num)
            {
                return true;
            }
            return false;
        }
        public static bool operator >(Number n1, double n)
        {
            int index = 0;
            while (n >= 1000)
            {
                n /= 1000;
                index++;
            }
            Number n2 = new Number(n, index);
            if (n1.uindex > n2.uindex)
            {
                return true;
            }
            else if (n1.uindex == n2.uindex && n1.num > n2.num)
            {
                return true;
            }
            return false;
        }
        public static bool operator <(Number n1, Number n2)
        {
            if (n1.uindex < n2.uindex)
            {
                return true;
            }
            else if (n1.uindex == n2.uindex && n1.num < n2.num)
            {
                return true;
            }
            return false;
        }
        public static bool operator <(Number n1, double n)
        {
            int index = 0;
            while (n >= 1000)
            {
                n /= 1000;
                index++;
            }
            Number n2 = new Number(n, index);
            if (n1.uindex < n2.uindex)
            {
                return true;
            }
            else if (n1.uindex == n2.uindex && n1.num < n2.num)
            {
                return true;
            }
            return false;
        }
        public static bool operator >=(Number n1, Number n2)
        {
            if (n1.uindex > n2.uindex)
            {
                return true;
            }
            else if (n1.uindex == n2.uindex && n1.num >= n2.num)
            {
                return true;
            }
            return false;
        }
        public static bool operator >=(Number n1, double n)
        {
            int index = 0;
            while (n >= 1000)
            {
                n /= 1000;
                index++;
            }
            Number n2 = new Number(n, index);
            if (n1.uindex > n2.uindex)
            {
                return true;
            }
            else if (n1.uindex == n2.uindex && n1.num >= n2.num)
            {
                return true;
            }
            return false;
        }
        public static bool operator <=(Number n1, Number n2)
        {
            if (n1.uindex < n2.uindex)
            {
                return true;
            }
            else if (n1.uindex == n2.uindex && n1.num <= n2.num)
            {
                return true;
            }
            return false;
        }
        public static bool operator <=(Number n1, double n)
        {
            
            int index = 0;
            while(n>=1000)
            {
                n/= 1000;
                index++;
            }
            Number n2 = new Number(n,index);
            if (n1.uindex < n2.uindex)
            {
                return true;
            }
            else if (n1.uindex == n2.uindex && n1.num <= n2.num)
            {
                return true;
            }
            return false;
        }
        public static Number operator +(Number n1,Number n2)//相加
        {
            Number n =n1>=n2 ? n1 : n2;//n为大的数字
            Number l = n1 < n2 ? n1 : n2;//l为小数字
            
            if(n.uindex-l.uindex==0)//同单位
            {
                n.num += l.num;
                
            }
            else if(n.uindex-l.uindex==1)
            {
                n.num += l.num / 1000;
            }
            if (n.num >= 1000 && n.uindex<Units.Count()-1)//进位
            {
                n.uindex++;
                n.num /= 1000;
            }
            return n;//相差一个单位以上，返回大数字
        }
        public static Number operator -(Number n1, Number n2)//相减
        {
            if (n1 > n2)
            {
                if (n1.uindex - n2.uindex == 0)//同单位
                {
                    n1.num -= n2.num;
                }
                else if (n1.uindex - n2.uindex == 1)
                {
                    n1.num -= n2.num / 1000;
                }
                if (n1.num < 1 && n1.uindex != 0)//退位
                {
                    n1.uindex--;
                    n1.num *= 1000;
                }
                return n1;//相差一个单位以上，忽略不计减数
            }
            else
            {
                return new Number(0, 0);
            }
        }

        public static Number operator *(Number n, double x)//乘倍数
        {
            n.num *= x;
            while(n.num>=1000)
            {
                n.num /= 1000;
                n.uindex++;
            }
            return n;
        }

        public static int operator /(Number n1,Number n2)//除求比例(0--1000).保证n1<n2
        {
            if (n1.uindex - n2.uindex == 0)//同单位
            {
                return (int)Math.Ceiling(n1.num / n2.num*1000);
            }
            else if (n2.uindex - n1.uindex == 1)
            {
                return (int)Math.Ceiling(n1.num / n2.num);
            }
            return 0;//相差一个单位以上,几乎等于0
        }
    }
}
