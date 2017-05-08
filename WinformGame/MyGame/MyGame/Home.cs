using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public partial class Home : UserControl
    {
        Enermy enermy;
        public Home()
        {
            InitializeComponent();
            
        }
        private void InitPlayer()
        {
            lbHp.Text = Player.MaxHp.Text;
            lbMp.Text = Player.MaxMp.Text;
            lbHR.Text = Player.HpRecovery.Text;
            lbMR.Text = Player.MpRecovery.Text;
            lbDm.Text = Player.Damage.Text;
            lbBl.Text = Player.Block + "%";
            lbGoG.Text = Player.GoldGet + "%";
            lbEqG.Text = Player.EquipGet + "%";
            lbCri.Text = Player.Crit + "%";
            lbGold.Text = Player.Gold.Text;
            lbEquip.Text = Player.Equipment.Text;
            proExp.Value = int.Parse((Player.Exp / Player.MaxExp).ToString());
            timerP.Interval = Player.AtRate;
            proHp.Value = 1000;
            proMp.Value = 1000;
            lbGHp.Text = Player.MoneyMaxHp.Text;
            lbGMp.Text = Player.MoneyMaxMp.Text;
            lbGHR.Text = Player.MoneyHpRecovery.Text;
            lbGMR.Text = Player.MoneyMpRecovery.Text;
            lbGDm.Text = Player.MoneyDamage.Text;
            lbGBl.Text = Player.MoneyBlock.Text;
            lbGGoG.Text = Player.MoneyGoldGet.Text;
            lbGEqG.Text = Player.MoneyEquipGet.Text;
            lbGCri.Text = Player.MoneyCrit.Text;
            timerP.Start();
        }
        private void ProductEnermy()
        {
            enermy = Enermy.Product(int.Parse(tbDeep.Text.ToString()));
            lbEHp.Text = enermy.Hp.Num + enermy.Hp.Unit;
            lbEDm.Text = enermy.Damage.Num + enermy.Damage.Unit;
            lbEBl.Text = enermy.Block + "%";
            lbECri.Text = enermy.Crit+ "%";
            lbEName.Text = enermy.Name;
            lbELevel.Text = enermy.Level;
            timerE.Interval = enermy.AtRate;
            tbMessage.Text += enermy.Name + "出现了!\r\n";
            proEHp.Value = 1000;
            timerE.Start();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            InitPlayer();
            ProductEnermy();
        }

        private void btnAddDeep_Click(object sender, EventArgs e)
        {
            int deep = int.Parse(tbDeep.Text);
            if (deep < 999) 
                deep++;
            tbDeep.Text = deep.ToString();
        }

        private void btnCutDeep_Click(object sender, EventArgs e)
        {
            int deep = int.Parse(tbDeep.Text);
            if (deep >1)
                deep--;
            tbDeep.Text = deep.ToString();
        }

        private void tbDeep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void timerP_Tick(object sender, EventArgs e)
        {
           tbMessage.AppendText(Player.Attack(ref enermy));
            if(enermy.Hp<=0)
            {
                tbMessage.AppendText(enermy.Name + "被击败了!\r\n");
                proEHp.Value = 0;
                timerE.Stop();
                timerP.Stop();
                Player.Gold = Player.Gold + enermy.GiveGold*(1.0 * Player.GoldGet / 100);//获得金钱
                lbGold.Text = Player.Gold.Text;//更新金钱显示
                Player.GetExp(enermy.GiveExp);//获得经验
                 proExp.Value = Player.Exp / Player.MaxExp;//更新经验显示
                lbSp.Text = Player.Sp.ToString();//更新技能点显示
                Player.Hp = new Number(Player.MaxHp.num,Player.MaxHp.uindex);
                Player.Mp = new Number(Player.MaxMp.num, Player.MaxMp.uindex);
                proHp.Value = 1000;
                proMp.Value = 1000;
                ProductEnermy();//再生产敌人
                timerP.Start();
                return;
            }
            proEHp.Value = enermy.Hp / enermy.MaxHp;
            lbEHp.Text = enermy.Hp.Num + enermy.Hp.Unit ;
        }

        private void timerE_Tick(object sender, EventArgs e)
        {
            tbMessage.AppendText(Player.BeAttacked(enermy));
            if (Player.Hp <= 0)
            {
                proHp.Value = 0;
                timerP.Stop();
                timerE.Stop();
                if (MessageBox.Show("你死了！(损失10%经验和30%黄金)", "提示", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Player.Exp *=0.9;//扣经验
                    Player.Gold *= 0.7;//扣黄金
                    proExp.Value = Player.Exp / Player.MaxExp;//更新经验显示
                    lbGold.Text = Player.Gold.Text;
                    Player.Hp = new Number(Player.MaxHp.num, Player.MaxHp.uindex);
                    Player.Mp = new Number(Player.MaxMp.num, Player.MaxMp.uindex);
                    proHp.Value = 1000;
                    proMp.Value = 1000;
                    ProductEnermy();
                    timerP.Start();
                    return;
                }
            }
            proHp.Value = Player.Hp / Player.MaxHp;
        }

        #region AddBtn
        private void btnAddHp_Click(object sender, EventArgs e)
        {
            if (Player.Gold >= Player.MoneyMaxHp)
            {
                Player.AddMaxHp();
                lbHp.Text = Player.MaxHp.Text;
                lbGHp.Text = Player.MoneyMaxHp.Text;
                lbGold.Text = Player.Gold.Text;
            }
        }

        private void btnAddMp_Click(object sender, EventArgs e)
        {
            if (Player.Gold >= Player.MoneyMaxMp)
            {
                Player.AddMaxMp();
                lbMp.Text = Player.MaxMp.Text;
                lbGMp.Text = Player.MoneyMaxMp.Text;
                lbGold.Text = Player.Gold.Text;
            }
        }

        private void btnAddHR_Click(object sender, EventArgs e)
        {
            if (Player.Gold >= Player.MoneyHpRecovery)
            {
                Player.AddHpRecovery();
                lbHR.Text = Player.HpRecovery.Text;
                lbGHR.Text = Player.MoneyHpRecovery.Text;
                lbGold.Text = Player.Gold.Text;
            }
        }

        private void btnAddMR_Click(object sender, EventArgs e)
        {
            if (Player.Gold >= Player.MoneyMpRecovery)
            {
                Player.AddMpRecovery();
                lbMR.Text = Player.MpRecovery.Text;
                lbGMR.Text = Player.MoneyMpRecovery.Text;
                lbGold.Text = Player.Gold.Text;
            }
        }

        private void btnAddDm_Click(object sender, EventArgs e)
        {
            if (Player.Gold >= Player.MoneyDamage)
            {
                Player.AddDamage();
                lbDm.Text = Player.Damage.Text;
                lbGDm.Text = Player.MoneyDamage.Text;
                lbGold.Text = Player.Gold.Text;
            }
        }

        private void btnAddBl_Click(object sender, EventArgs e)
        {
            if (Player.Gold >= Player.MoneyBlock)
            {
                if (Player.AddBlock())
                {
                    lbBl.Text = Player.Block + "%";
                    lbGBl.Text = Player.MoneyBlock.Text;
                    lbGold.Text = Player.Gold.Text;
                }
                else
                {
                    btnAddBl.Enabled = false;
                    lbGBl.Text = "Max";
                }
            }
        }

        private void btnAddGoG_Click(object sender, EventArgs e)
        {
            if (Player.Gold >= Player.MoneyGoldGet)
            {
                Player.AddGoldGet();
                lbGoG.Text = Player.GoldGet + "%";
                lbGGoG.Text = Player.MoneyGoldGet.Text;
                lbGold.Text = Player.Gold.Text;
            }
        }

        private void btnAddEqG_Click(object sender, EventArgs e)
        {
            if (Player.Gold >= Player.MoneyEquipGet)
            {
                if (Player.AddEquipGet())
                {
                    lbEqG.Text = Player.EquipGet + "%";
                    lbGEqG.Text = Player.MoneyEquipGet.Text;
                    lbGold.Text = Player.Gold.Text;
                }
                else
                {
                    btnAddEqG.Enabled = false;
                    lbGEqG.Text = "Max";
                }
            }
        }

        private void btnAddCri_Click(object sender, EventArgs e)
        {
            if (Player.Gold >= Player.MoneyCrit)
            {
                if (Player.AddCrit())
                {
                    lbCri.Text = Player.Crit + "%";
                    lbGCri.Text = Player.MoneyCrit.Text;
                    lbGold.Text = Player.Gold.Text;
                }
                else
                {
                    btnAddCri.Enabled = false;
                    lbGCri.Text = "Max";
                }
            }
        }

    }
}

        #endregion