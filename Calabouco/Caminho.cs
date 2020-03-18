using System.Drawing;
using System.IO;

namespace Labirinto
{
    ///<summary>Representa a localização das pastas e arquivos do jogo</summary>
    public class Caminho
    {
        public Caminho() { }
        ///<summary>Representa o caminho dos sprites</summary>
        public string Sprites { get => string.Concat(Directory.GetCurrentDirectory(), @"\Resources\Sprites\"); }

        ///<summary>Sprites da construção do mapa</summary>
        public Bitmap Item { get => new Bitmap(string.Concat(Sprites, "Item.png")); }
        public Bitmap Parede { get => new Bitmap(string.Concat(Sprites, "Parede.png")); }
        public Bitmap Trilha { get => new Bitmap(string.Concat(Sprites, "Trilha.png")); }

        ///<summary>Sprites dos personagens</summary>
        public Bitmap Heroi { get => new Bitmap(string.Concat(Sprites, "Heroi.png")); }
        public Bitmap Inimigo { get => new Bitmap(string.Concat(Sprites, "Inimigo.png")); }
        public Bitmap Chefe { get => new Bitmap(string.Concat(Sprites, "Chefe.png")); }

        ///<summary>Sprites dos itens do herói</summary>
        public Bitmap Capacete { get => new Bitmap(string.Concat(Sprites, "Capacete.png")); }
        public Bitmap Armadura { get => new Bitmap(string.Concat(Sprites, "Armadura.png")); }
        public Bitmap Luvas { get => new Bitmap(string.Concat(Sprites, "Luvas.png")); }
        public Bitmap Botas { get => new Bitmap(string.Concat(Sprites, "Botas.png")); }
        public Bitmap Arma { get => new Bitmap(string.Concat(Sprites, "Arma.png")); }
        public Bitmap Escudo { get => new Bitmap(string.Concat(Sprites, "Escudo.png")); }

        ///<summary>Representa o caminho dos arquivos TXT que contém a matrix de um mapa</summary>
        public string MatrizMapa { get => string.Concat(Directory.GetCurrentDirectory(), @"\Resources\Mapas\"); }

        ///<summary>Representa o caminho dos áudios WAV</summary>
        public string Audios { get => string.Concat(Directory.GetCurrentDirectory(), @"\Resources\Audios\"); }
    }
}
