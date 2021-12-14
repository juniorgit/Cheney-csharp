using System;

public class Carta : IComparable<Carta>
{
    // letras constantes para valores especiais
    public const int AS = 1;
    public const int J = 11;
    public const int Q = 12;
    public const int K = 13;

    // em ordem de valor
    public const int Ouros = 1;
    public const int Espadas = 2;
    public const int Copas = 3;
    public const int Paus = 4;

    public int Naipe;
    public int Valor;

    public Carta(int naipe, int valor)
    {
        this.Naipe = naipe;
        this.Valor = valor;
    }

    public int CompareTo(Carta outra)
    {
        if (outra == null) return 1;
        if (this.IsMaiorQue(outra)) return 1;
        if (this.IsMenorQue(outra)) return -1;
        return 0;
    }

    public bool IsMaiorQue(Carta outra)
    {
        if (this.Valor == outra.Valor)
            return this.Naipe > outra.Naipe;
        else
            return this.Valor > outra.Valor;
    }

    public bool IsMenorQue(Carta outra)
    {
        return !IsMaiorQue(outra);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Carta))
            return false;

        Carta c = (Carta)obj;
        return (Naipe == c.Naipe && Valor == c.Valor);
    }

    public override string ToString()
    {
        string naipe = string.Empty;
        string valor;

        switch (Naipe)
        {
            case Carta.Copas:
                naipe = "copas";
                break;
            case Carta.Paus:
                naipe = "paus";
                break;
            case Carta.Espadas:
                naipe = "espadas";
                break;
            case Carta.Ouros:
                naipe = "ouros";
                break;
        }

        switch (Valor)
        {
            case Carta.J:
                valor = "J";
                break;
            case Carta.Q:
                valor = "Q";
                break;
            case Carta.K:
                valor = "K";
                break;
            case Carta.AS:
                valor = "As";
                break;
            default:
                valor = Valor.ToString();
                break;
        }

        return valor + " de " + naipe;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}