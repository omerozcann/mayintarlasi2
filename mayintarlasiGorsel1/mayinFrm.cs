using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mayintarlasiGorsel1
{
    public partial class mayinFrm : Form
    {
        int[,]oyunAlani=new int[10,10];
        Button[,]butonlar=new Button[10,10];
        public mayinFrm()
        {
            InitializeComponent();
        }

        public void mayinDose()
        {
            Random r=new Random();
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    oyunAlani[i, j] = 0;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                oyunAlani[r.Next(10), r.Next(10)] = 1;
            }
        }
        private void baslat_Click(object sender, EventArgs e)
        {
            butonlariSil();
            mayinDose();
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {                    
                    Button b = new Button();
                    b.Parent = groupBox1;// this deyimi mayinFrm formunu gösterir
                    b.Width = 20; // butonun genişliği
                    b.Height = 20;//butonun yüksekliği
                    b.Left =5+20 * i;// butonun yataydaki konumu
                    b.Top =15+20*j;//butonun dikeydeki konumu
                    b.Text = "";
                    b.Name = i+"-"+j;
                    b.Click += oyunbtn_Click;// üretilen butona tıklanınca merhababtn_click olayını çağır
                    butonlar[i,j] = b;
                }
            }   
            
        }

        public void butonlariSil()
        {
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (butonlar[i, j] != null)
                    {
                        butonlar[i, j].Dispose();
                    }
                }
            }
        }
        public void mayinlariGoster()
        {
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (oyunAlani[i,j]==1)
                    {
                        butonlar[i, j].BackgroundImage = Image.FromFile("mayin.png");
                        butonlar[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
        }
        public int mayinSay(int x,int y)
        {
            int mayinSayisi = 0;
            if (x < 9)
            {
                if (oyunAlani[x + 1, y] == 1)
                {
                    mayinSayisi++;
                }
            }
            if (x < 9 && y < 9)
            {
                if (oyunAlani[x + 1, y + 1] == 1)
                {
                    mayinSayisi++;
                }
            }
            if (y < 9)
            {
                if (oyunAlani[x, y + 1] == 1)
                {
                    mayinSayisi++;
                }
            }
            if (x > 0 && y < 9)
            {
                if (oyunAlani[x - 1, y + 1] == 1)
                {
                    mayinSayisi++;
                }
            }
            if (x > 0)
            {
                if (oyunAlani[x - 1, y] == 1)
                {
                    mayinSayisi++;
                }
            }
            if (x > 0 && y > 0)
            {
                if (oyunAlani[x - 1, y - 1] == 1)
                {
                    mayinSayisi++;
                }
            }
            if (y > 0)
            {
                if (oyunAlani[x, y - 1] == 1)
                {
                    mayinSayisi++;
                }
            }
            if (x < 9 && y > 0)
            {
                if (oyunAlani[x + 1, y - 1] == 1)
                {
                    mayinSayisi++;
                }
            }
            return mayinSayisi;
        }
        private void oyunbtn_Click(object sender, EventArgs e)
        {
            Button b=(Button)sender;
            String[] d = b.Name.Split('-');
            int x = int.Parse(d[0]);
            int y = int.Parse(d[1]);
            if (oyunAlani[x,y]==1)
            {
                mayinlariGoster();
            }
            else
            {
                b.BackColor= Color.White;
                if (oyunAlani[x+1,y]!=1&&x<9)
                {
                    butonlar[x + 1, y].Text = mayinSay(x + 1, y).ToString();
                }
                if (oyunAlani[x + 1, y + 1] != 1 && x < 9 && y < 9)
                {
                    butonlar[x + 1, y + 1].Text = mayinSay(x + 1, y + 1).ToString();
                }
                if (oyunAlani[x, y + 1] != 1 && y < 9)
                {
                    butonlar[x, y + 1].Text = mayinSay(x + 1, y).ToString();
                }
                if (oyunAlani[x - 1, y + 1] != 1 && x > 0 && y < 9)
                {
                    butonlar[x - 1, y + 1].Text = mayinSay(x + 1, y).ToString();
                }
                if (oyunAlani[x - 1, y] != 1 && x > 0)
                {
                    butonlar[x - 1, y].Text = mayinSay(x + 1, y).ToString();
                }
                if (oyunAlani[x - 1, y - 1] != 1 && x > 0 && y > 0)
                {
                    butonlar[x - 1, y - 1].Text = mayinSay(x + 1, y).ToString();
                }
                if (oyunAlani[x, y - 1] != 1 && y > 0)
                {
                    butonlar[x, y - 1].Text = mayinSay(x + 1, y).ToString();
                }
                if (oyunAlani[x + 1, y-1] != 1 && x < 9&&y>0)
                {
                    butonlar[x + 1, y - 1].Text = mayinSay(x + 1, y).ToString();
                }
            }
        }
    }
}
