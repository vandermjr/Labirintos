using System;

namespace Labirinto
{
    public class Heroi
    {
        public TeclasAtalho atualDirecional, proximaDirecional;                     //Direção <, >, ^, v
        public (int X, int Y) HeroiXY = (0, 0);                                     //Coordenada atual do Heroi no mapa

        public Heroi() { }
        public void MoverHeroi(TeclasAtalho direcao)
        {
            switch (direcao)
            {
                case TeclasAtalho.PRESS_RIGHT: //ok
                    if (GameManager.Mapa.MapaXY[HeroiXY.X + 1, HeroiXY.Y] != Convert.ToInt32(Mapa.LegendaMapa.Parede))
                    {
                        HeroiXY.X++;
                    }
                    break;
                case TeclasAtalho.PRESS_DOWN: //ok
                    if (GameManager.Mapa.MapaXY[HeroiXY.X, HeroiXY.Y + 1] != Convert.ToInt32(Mapa.LegendaMapa.Parede))
                    {
                        HeroiXY.Y++;
                    }
                    break;
                case TeclasAtalho.PRESS_LEFT: //ok
                    if (HeroiXY.X > 0)
                    {
                        if (GameManager.Mapa.MapaXY[HeroiXY.X - 1, HeroiXY.Y] != Convert.ToInt32(Mapa.LegendaMapa.Parede))
                        {
                            HeroiXY.X--;
                        }
                    }
                    break;
                case TeclasAtalho.PRESS_UP: //ok
                    if (HeroiXY.Y > 0)
                    {
                        if (GameManager.Mapa.MapaXY[HeroiXY.X, HeroiXY.Y - 1] != Convert.ToInt32(Mapa.LegendaMapa.Parede))
                        {
                            HeroiXY.Y--;
                        }
                    }
                    break;
            }
        }
    }
}
