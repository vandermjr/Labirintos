using System;
using System.Drawing;
using System.IO;

namespace Labirinto
{
    public class Mapa
    {
        public Mapa() { MapaConstruido = new Bitmap(MapaWH.W * SpriteWH.W, MapaWH.H * SpriteWH.H); }

        public void LerMapa(int nivel)
        {
            MapaXY = new int[MapaCL.Colunas, MapaCL.Linhas];
            string[] mapaTXT;
            using (var leitor = new StreamReader(string.Concat(GameManager.Caminho.MatrizMapa, "Nivel_", nivel.ToString().PadLeft(2, '0'), ".txt")))
            {
                int x = 0, y = 0;
                do
                {
                    mapaTXT = Convert.ToString(leitor.ReadLine()).Trim().Split(',');
                    foreach (string item in mapaTXT)
                    {
                        MapaXY[x, y] = Convert.ToInt32(item);
                        if (Convert.ToInt32(item) == (int)LegendaMapa.Heroi)
                        {
                            GameManager.Heroi.HeroiXY = (x, y);
                        }
                        y++;
                    }
                    x++;
                    y = 0;
                } while (!leitor.EndOfStream);
            }
        }
        public Bitmap ConstruirMapa()
        {
            using (var gfx = Graphics.FromImage(MapaConstruido))
            {
                int blocoMapaTXT;

                for (var coluna = 0; coluna < MapaCL.Colunas; coluna++)
                {
                    for (var linha = 0; linha < MapaCL.Linhas; linha++)
                    {
                        blocoMapaTXT = MapaXY[TelaAtualXY.X + coluna, TelaAtualXY.Y + linha];
                        if (blocoMapaTXT == (int)LegendaMapa.Parede)
                        {
                            gfx.DrawImage(GameManager.Caminho.Parede, linha * SpriteWH.H, coluna * SpriteWH.W);
                        }
                        else if (blocoMapaTXT == (int)LegendaMapa.Trilha)
                        {
                            gfx.DrawImage(GameManager.Caminho.Trilha, linha * SpriteWH.H, coluna * SpriteWH.W);
                        }
                        else if (blocoMapaTXT == (int)LegendaMapa.Item)
                        {
                            gfx.DrawImage(GameManager.Caminho.Item, linha * SpriteWH.H, coluna * SpriteWH.W);
                        }
                    }
                }
                gfx.DrawImage(GameManager.Caminho.Heroi, (GameManager.Heroi.HeroiXY.X - TelaAtualXY.X) * SpriteWH.W, (GameManager.Heroi.HeroiXY.Y - TelaAtualXY.Y) * SpriteWH.H);
            }
            return MapaConstruido;
        }

        public void MovimentarTela()
        {
            if (GameManager.Heroi.HeroiXY.X > 11 * (GameManager.Heroi.HeroiXY.X / 11) && GameManager.Heroi.HeroiXY.X <= 11 + (11 * (GameManager.Heroi.HeroiXY.X / 11)))
            {
                TelaAtualXY.X = 11 * (GameManager.Heroi.HeroiXY.X / 11);
                if (TelaAtualXY.X > 0) { TelaAtualXY.X -= 1; }
            }
            if (GameManager.Heroi.HeroiXY.Y > 8 * (GameManager.Heroi.HeroiXY.Y / 8) && GameManager.Heroi.HeroiXY.Y <= 8 + (8 * (GameManager.Heroi.HeroiXY.Y / 8)))
            {
                TelaAtualXY.Y = 8 * (GameManager.Heroi.HeroiXY.Y / 8);
                if (TelaAtualXY.Y > 0) { TelaAtualXY.Y -= 1; }
            }
        }
        public Bitmap MapaConstruido;
        /// <summary>Tamanho dos sprites</summary>
        public (int W, int H) SpriteWH { get => (25, 25); }

        /// <summary>Indica o tamanho do array de colunas e linhas do mapa. Cada mapa pode ter um tamanho diferente</summary>
        public (int Colunas, int Linhas) MapaCL { get => (62, 56); }

        /// <summary>Tamanho fisico do mapa</summary>
        public (int W, int H) MapaWH { get => (800, 600); }

        /// <summary>Matriz do mapa. Seus valores x e y indica posição dos objetos</summary>
        public int[,] MapaXY { get; set; }

        public (int X, int Y) TelaAtualXY;

        public enum LegendaMapa
        {
            Trilha = 0,
            Parede = 10,
            Porta = 11,
            Item = 2,
            Heroi = 3,
            Inimigo = 14,
            Chefe = 15
        }
    }
}