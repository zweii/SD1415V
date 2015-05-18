using Models;
using System;

namespace Peer
{
    public class App
    {
        public static void Main(string[] args)
        {
            MusicBox box = new MusicBox();
            box.Save("teste1.txt");
            Console.WriteLine(box);
            box.AddMusic(new Music("Teste", "aqui/aqui/teste", Format.MP3 , "Teste", "Teste", 2015));
            box.Save("teste2.txt");
            Console.WriteLine(box);
            box.AddMusic(new Music("Angels", "/SOAD/Angels", Format.MP4, "System Of A Down", "SOADAlbum", 2000));
            box.Save("teste3.txt");
            Console.WriteLine(box);
            Console.ReadLine();

            box = MusicBox.Load("teste1.txt");
            Console.WriteLine(box);
            box = MusicBox.Load("teste2.txt");
            Console.WriteLine(box);
            box = MusicBox.Load("teste3.txt");
            Console.WriteLine(box);
            Console.ReadLine();
        }
    }
}
