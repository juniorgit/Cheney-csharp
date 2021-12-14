using System;
using System.Collections.Generic;
using System.Text;

public class Baralho
{
    List<Carta> deck;
    private static Random rng = new Random();

    public Baralho()
    {
        deck = new List<Carta>();

        // preenche o deck com todas as cartas possíveis
        for (int naipe = Carta.Ouros; naipe <= Carta.Paus; naipe++)
        {
            for (int valor = Carta.AS; valor <= Carta.K; valor++)
            {
                Carta carta = new Carta(naipe, valor);
                deck.Add(carta);
            }
        }
    }

    public Carta GetCarta(int i)
    {
        return deck[i];
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (Carta c in deck)
        {
            sb.Append(c);
            sb.Append("\n");
        }

        return sb.ToString();
    }

    // mistura o baralho randomicamente
    public void Misturar()
    {
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Carta value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }
    }
}