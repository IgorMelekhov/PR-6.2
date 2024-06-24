using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_6
{
    public partial class Form1 : Form
    {
        int count = 0;
        public static Random random = new Random();
        
        public Form1()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = 100000000;
            timer.Tick += Timer_Tick;
            timer.Start();
            
        }
        void MyColor(Color col)
        {
            this.pictureBoxLight1.BackColor = col;
            this.pictureBoxLight2.BackColor = col;
            this.pictureBoxLight3.BackColor = col;
            this.groupBoxScreen.BackColor = col;
        }
        bool OwnersAtHome=true;
        Facade facade = new Facade();
       
        
        private void pictureBoxLight1_Click(object sender, EventArgs e)
        {
            MyColor(Color.White);
        }
        private void pictureBoxLight2_Click(object sender, EventArgs e)
        {

            MyColor(Color.Yellow);
        }
        private void pictureExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBoxLight3_Click_1(object sender, EventArgs e)
        {
            MyColor(Color.YellowGreen);
        }
        private void pictureBoxBrightnessDay_Click(object sender, EventArgs e)
        {
            if(groupBoxScreen.BackColor == Color.YellowGreen)
            {
                MyColor(Color.LightGreen);
            }
            if (groupBoxScreen.BackColor == Color.Yellow)
            {
                MyColor(Color.LightYellow);
            }
            if (groupBoxScreen.BackColor == Color.White)
            {
                MyColor(Color.LightGray);
            }
        }

        private void pictureBoxBrightnessNight_Click(object sender, EventArgs e)
        {
            if (groupBoxScreen.BackColor == Color.YellowGreen)
            {
                MyColor(Color.DarkGreen);
            }
            if (groupBoxScreen.BackColor == Color.Yellow)
            {
                MyColor(Color.Orange);
            }
            if (groupBoxScreen.BackColor == Color.White)
            {
                MyColor(Color.DarkGray);
            }
        }

        private void pictureBoxLightOff_Click(object sender, EventArgs e)
        {
            MyColor(Color.Gray);
        }

        private void pictureBoxLocked_Click(object sender, EventArgs e)
        {
            
            if (count == 0)
            {
                pictureBoxLocked.Image = Image.FromFile(".\\Pictures\\open.png"); //спросить про путь
                labelOpenClose2.Text ="открыта";
                count = 1;
               
            }
            else if (count == 1)
            {
                pictureBoxLocked.Image = Image.FromFile(".\\Pictures\\locked.png"); //спросить про путь
                labelOpenClose2.Text ="закрыта";
                count = 0;
            }

        }

        private void pictureCond_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {
                pictureCond.Image = Image.FromFile(".\\Pictures\\cold.png"); //спросить про путь
                labelCond2.Text ="включен";
                count = 1;
            }
            else if (count == 1)
            {
                pictureCond.Image = Image.FromFile(".\\Pictures\\cold off.png"); //спросить про путь
                labelCond2.Text ="выключен";
                count = 0;
            }
        }

        private void pictureWarm_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {
                pictureWarm.Image = Image.FromFile(".\\Pictures\\heating on.png"); //спросить про путь
                labelWarm2.Text = "включено";
                count = 1;
            }
            else if (count == 1)
            {
                pictureWarm.Image = Image.FromFile(".\\Pictures\\heating off.png"); //спросить про путь
                labelWarm2.Text = "выключено";
                count = 0;
            }
        }

        private void pictureHome_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {

                pictureHome.Image = Image.FromFile(".\\Pictures\\no home.png"); //спросить про путь
                labelHome2.Text = "не дома";
                count = 1;
                OwnersAtHome = false;
            }
            else if (count == 1)
            {
                pictureHome.Image = Image.FromFile(".\\Pictures\\home.png"); //спросить про путь
                labelHome2.Text = "дома";
                count = 0;
                OwnersAtHome = true;
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Reserve.Visible = false;
            if ((facade.FireAlarm() == 0)&&(facade.SecurityAlarm() == 1))
            {
                labelAlarm.Text = "Тревога, пожар !";
                groupBoxAlarm.Visible=true;
                pictureBoxAlarm.Visible = true;
                pictureBoxAlarm.Image = Image.FromFile(".\\Pictures\\fire alarm.gif");
                if (OwnersAtHome==true)
                {
                    labelOwnersAtHome.Text = "Вы горите !";
                }
                else
                {
                    labelOwnersAtHome.Text = "Ваш дом горит !";
                }
            }
            else if ((facade.FireAlarm() == 1) && (facade.SecurityAlarm() == 0))
            {
                labelAlarm.Text = "Тревога, вор !";
                groupBoxAlarm.Visible = true;
                pictureBoxAlarm.Visible = true;
                pictureBoxAlarm.Image = Image.FromFile(".\\Pictures\\peepo-police.gif");
                if (OwnersAtHome == true)
                {
                    labelOwnersAtHome.Text = "Тут вор !";
                }
                else
                {
                    labelOwnersAtHome.Text = "Дома вор !";
                }
            }
            else if ((facade.FireAlarm() == 0) && (facade.SecurityAlarm() == 0))
            {
                labelAlarm.Text = "Тревога, вор и пожар !";
                groupBoxAlarm.Visible = true;
                pictureBoxAlarm.Visible = true;
                pictureBoxAlarm.Image = Image.FromFile(".\\Pictures\\peepo-police.gif");
                if (OwnersAtHome == true)
                {
                    labelOwnersAtHome.Text = "Вор проник и ";
                    Reserve.Visible = true;
                    Reserve.Text = "поджег вас !";
                }
                else
                {
                    labelOwnersAtHome.Text = "Вор проник и ";
                    Reserve.Visible = true;
                    Reserve.Text = "поджег дом !";
                }
            }
            else
            {
                groupBoxAlarm.Visible = false;
                pictureBoxAlarm.Visible = false;
            }
        }
    }

}

