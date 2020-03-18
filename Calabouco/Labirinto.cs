using System;
using System.Drawing;
using System.Windows.Forms;

namespace Labirinto
{
    public partial class Labirinto : Form
    {
        public Labirinto()
        {
            InitializeComponent();
            Timer1.Tick += new EventHandler(Timer1_Tick);
            Timer1.Interval = 150; Timer1.Enabled = false;
        }
        private void Calabouco_Load(object sender, EventArgs e)
        {
            GameManager.Mapa.LerMapa(1);
            Size = new Size(GameManager.Mapa.MapaWH.W, GameManager.Mapa.MapaWH.H);
            Location = new Point((Screen.PrimaryScreen.Bounds.Width - Width) / 2, (Screen.PrimaryScreen.Bounds.Height - Height) / 2);
            Timer1.Enabled = true; Timer1.Start();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Right: { GameManager.Heroi.MoverHeroi(TeclasAtalho.PRESS_RIGHT); break; }
                case Keys.Down: { GameManager.Heroi.MoverHeroi(TeclasAtalho.PRESS_DOWN); break; }
                case Keys.Left: { GameManager.Heroi.MoverHeroi(TeclasAtalho.PRESS_LEFT); break; }
                case Keys.Up: { GameManager.Heroi.MoverHeroi(TeclasAtalho.PRESS_UP); break; }
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            var gfx = CreateGraphics();
            gfx.DrawImageUnscaled(GameManager.Mapa.ConstruirMapa(), 0, 0);

            GameManager.Mapa.MovimentarTela();
        }
        private readonly Timer Timer1 = new Timer();
    }
}
