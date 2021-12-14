using System;
using System.Collections.Generic;

class Program
{
    static void tentarAcertar()
    {
        Cheney c = new Cheney();

        while (true)
        {
            List<Carta> lista = c.MontarParaAcertar();

            foreach (Carta carta in lista)
                Console.WriteLine(carta);

            Console.WriteLine("Pense na carta, pressione ENTER para ver se acertou");
            Console.ReadLine();
            Console.WriteLine("Essa era a carta -----> " + c.QuintaCarta);
            Console.WriteLine("Pressione ENTER para repetir ou CTRL-C para cancelar");
            Console.ReadLine();
        }
    }

    static void fazerComputadorAcertar()
    {
        Cheney c = new Cheney();

        List<Carta> lista = c.GetCincoCartas();

        foreach (Carta carta in lista)
            Console.WriteLine(carta);

        Console.WriteLine("Digite 5 numeros sem espaços de 1-5 na sequencia para fazer o computador acertar (ex: 51342) e press ENTER");
        string resposta = Console.ReadLine();

        if (resposta.Length < 5)
        {
            Console.WriteLine("FIM");
            return;
        }

        List<Carta> listaUser = new List<Carta>();

        for (int i = 0; i < 5; i++)
        {
            listaUser.Add(lista[Int32.Parse(resposta[i].ToString()) - 1]);
        }

        Console.WriteLine("-----> achei essa: " + c.TenteAdivinhar(listaUser));
        Console.ReadLine();
    }

    static void Main(string[] args)
    {
        Console.Write("1-Você tenta acertar\n2-Fazer o computador acertar\n\nDigite o número da opção e pressione ENTER: ");
        string r = Console.ReadLine();

        if (r.Equals("1"))
            tentarAcertar();

        if (r.Equals("2"))
            fazerComputadorAcertar();
    }
}