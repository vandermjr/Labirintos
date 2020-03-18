using System;
using System.Media;

namespace Labirinto
{
    public class Audio
    {
        public Audio() { }

        public void Abrir(Sons sons)
        {
            if (sons == Sons.Sirene) //
            {
                Sirene.PlayLooping();
            }
            else if (sons == Sons.SuperPilula) //
            {
                SuperPilula.Play();
            }
            else //
            {
                WinApi.MciSendString("close myaudio", "", 0, IntPtr.Zero);
                WinApi.MciSendString(string.Concat("open ", Caminho.Audios, sons, ".wav", " alias myaudio"), "", 0, IntPtr.Zero);
                WinApi.MciSendString("set myaudio time format ms", "", 0, IntPtr.Zero);
                WinApi.MciSendString("status myaudio length", new string(Convert.ToChar(" "), 128), 128, IntPtr.Zero);

                Reproduzir();
            }
        }
        public void Fechar()
        {
            WinApi.MciSendString("close myaudio", "", 0, IntPtr.Zero);
        }
        public void IniciarEm(int ms)
        {
            WinApi.MciSendString(string.Concat("play myaudio from ", Convert.ToString(ms)), "", 0, IntPtr.Zero);
        }
        public void Reproduzir()
        {
            WinApi.MciSendString("play myaudio", "", 0, IntPtr.Zero);
        }

        //Declaração de variáveis
        private readonly Caminho Caminho = new Caminho();

        //Efeito de som no canal B
        public SoundPlayer SuperPilula { get => new SoundPlayer(string.Concat(Caminho.Audios, Sons.SuperPilula, ".wav")); }
        public SoundPlayer Sirene { get => new SoundPlayer(string.Concat(Caminho.Audios, Sons.Sirene, ".wav")); }

        public enum Sons
        {
            AbrirItem,
            ColetarItem,
            AbrirPorta,
            GameOver,
            HeroiMorreu,
            HeroiAtaca,
            InimigoMorreu,
            InimigoAtaca,
            ChefeMorreu,
            ChefeAtaca,
            Sirene,
            SuperPilula
        }
    }
}