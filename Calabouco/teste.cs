using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

using static Labirinto.Mapa;

namespace Labirinto
{
    public partial class Teste : Form
    {
        int[,] MapaXY = new int[1000, 1000];
        Bitmap[] Heroi = new Bitmap[4];
        Bitmap Trilha;
        Bitmap Parede;
        Bitmap Item;
        Bitmap MapaConstruido;
        SoundPlayer som;

        int xatualtela = 0;
        int yatualtela = 0;
        int pose = 0;
        int xperso = 0;
        int yperso = 0;

        public Teste()
        {
            InitializeComponent();
        }

        private void Teste_Load(object sender, EventArgs e)
        {
            Trilha = new Bitmap(Application.StartupPath + @"\Resources\Sprites\" + "Trilha.png");
            Parede = new Bitmap(Application.StartupPath + @"\Resources\Sprites\" + "Parede.png");
            Item = new Bitmap(Application.StartupPath + @"\Resources\Sprites\" + "Item.png");
            MapaConstruido = new Bitmap(960, 900);
            som = new SoundPlayer(Application.StartupPath + @"\Resources\Sounds\" + "notify.wav");

            for (int i = 0; i < 4; i++)
            {
                Heroi[i] = new Bitmap(Application.StartupPath + @"\Resources\Sprites\" + "Heroi" + i + ".png");
                Heroi[i].MakeTransparent(Color.Yellow);
            }

            int nivel = 1;
            string[] mapaTXT;
            using (var leitor = new StreamReader(string.Concat(Application.StartupPath + @"\Resources\Mapas\", "Nivel_", nivel.ToString().PadLeft(2, '0'), ".txt")))
            {
                int x = 0, y = 0;
                do
                {
                    mapaTXT = leitor.ReadLine().Trim().Split(',');
                    foreach (string item in mapaTXT)
                    {
                        if (Convert.ToInt32(item) == (int)LegendaMapa.Heroi)
                        {
                            xperso = y;
                            yperso = x;
                        }
                        MapaXY[y, x] = Convert.ToInt32(item);
                        y++;
                    }
                    x++;
                    y = 0;
                } while (!leitor.EndOfStream);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var gfx = Graphics.FromImage(MapaConstruido);
            int tijolo;

            for (int linha = 0; linha < 62; linha++)
            {
                for (int coluna = 0; coluna < 56; coluna++)
                {
                    tijolo = MapaXY[xatualtela + linha, yatualtela + coluna];
                    if (tijolo == 00) { gfx.DrawImage(Trilha, linha * 25, coluna * 25); }
                    if (tijolo == 10) { gfx.DrawImage(Parede, linha * 25, coluna * 25); }                    
                    if (tijolo == 02) { gfx.DrawImage(Item, linha * 25, coluna * 25); }
                }
            }

            gfx.DrawImage(Heroi[pose], (xperso - xatualtela) * 25, (yperso - yatualtela) * 25);

            var gfx2 = CreateGraphics();
            gfx2.DrawImageUnscaled(MapaConstruido, 0, 12);

            if (xperso > 11 * (xperso / 11) && xperso <= 11 + (11 * (xperso / 11)))
            {
                xatualtela = 11 * (xperso / 11);
                if (xatualtela > 0) { xatualtela -= 1; }
            }
            if (yperso > 8 * (yperso / 8) && yperso <= 8 + (8 * (yperso / 8)))
            {
                yatualtela = 8 * (yperso / 8);
                if (yatualtela > 0) { yatualtela -= 1; }
            }

            if (MapaXY[xperso, yperso] == 02)
            {
                som.Play();
                MapaXY[xperso, yperso] = 00;
            }
        }

        private void Teste_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right: if (MapaXY[xperso + 1, yperso] != (int)LegendaMapa.Parede) { xperso++; pose = 1; } break;
                case Keys.Down: if (MapaXY[xperso, yperso + 1] != (int)LegendaMapa.Parede) { yperso++; pose = 2; } break;
                case Keys.Left: if (xperso > 0) { if (MapaXY[xperso - 1, yperso] != (int)LegendaMapa.Parede) { xperso--; pose = 0; } } break;
                case Keys.Up: if (yperso > 0) { if (MapaXY[xperso, yperso - 1] != (int)LegendaMapa.Parede) { yperso--; pose = 3; } } break;
            }
        }
    }
}
