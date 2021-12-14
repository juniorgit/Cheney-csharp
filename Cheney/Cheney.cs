using System.Collections.Generic;
using System.Linq;

public class Cheney
{
    private Baralho baralho;

    public Carta PrimeiraCarta;
    public Carta QuintaCarta;

    private const int PMG = 1;
    private const int PGM = 2;
    private const int MPG = 3;
    private const int MGP = 4;
    private const int GPM = 5;
    private const int GMP = 6;

    public Cheney()
    {
        baralho = new Baralho();
    }

    private int GetDif()
    {
        // se a primeira carta for maior que a ultima e a diferença for até 6, OK
        if (PrimeiraCarta.Valor > QuintaCarta.Valor)
            return Carta.K - PrimeiraCarta.Valor + QuintaCarta.Valor;
        else
            return QuintaCarta.Valor - PrimeiraCarta.Valor;
    }

    // mistura o baralho e pega primeiras 5
    public List<Carta> GetCincoCartas()
    {
        baralho.Misturar();

        List<Carta> lista = new List<Carta>();
        for (int i = 0; i < 5; i++)
            lista.Add(baralho.GetCarta(i));

        return lista;
    }

    private void SepararPrimeiraEQuintaCarta(List<Carta> lista)
    {
        // primeira coisa: descobrir entre as primeiras cinco qual naipe repete
        var naipe = lista.GroupBy(x => x.Naipe)
                  .Select(g => new { g.Key, Count = g.Count() })
                  .OrderByDescending(x => x.Count)
                  .Select(g => new { g.Key }).FirstOrDefault();

        // primeio passo, a carta deve ter mesmo naipe da quinta
        PrimeiraCarta = null;
        QuintaCarta = null;

        // primeiro vamos localizar a quinta carta e a primeira
        foreach (Carta c in lista)
        {
            if (c.Naipe == naipe.Key)
            {
                if (QuintaCarta == null)
                    QuintaCarta = c;
                else
                {
                    PrimeiraCarta = c;
                    break;
                }
            }
        }
    }

    public int GetDistanciaEntreCartas(Carta primeira, Carta segunda, Carta terceira)
    {
        // PMG   
        if (primeira.IsMenorQue(segunda) && segunda.IsMenorQue(terceira) && primeira.IsMenorQue(terceira))
            return 1;

        // PGM
        if (primeira.IsMenorQue(segunda) && segunda.IsMaiorQue(terceira) && primeira.IsMenorQue(terceira))
            return 2;

        // MPG
        if (primeira.IsMaiorQue(segunda) && segunda.IsMenorQue(terceira) && primeira.IsMenorQue(terceira))
            return 3;

        // MGP
        if (primeira.IsMenorQue(segunda) && segunda.IsMaiorQue(terceira) && primeira.IsMaiorQue(terceira))
            return 4;

        // GPM
        if (primeira.IsMaiorQue(segunda) && segunda.IsMenorQue(terceira) && primeira.IsMaiorQue(terceira))
            return 5;

        // GMP -- nem precisa fazer o if, sempre será 6
        //if (primeira.IsMaiorQue(segunda) && segunda.IsMaiorQue(terceira) && primeira.IsMaiorQue(terceira))
        return 6;
    }

    public Carta TenteAdivinhar(List<Carta> listaUser)
    {
        PrimeiraCarta = listaUser[0];
        Carta SegundaCarta = listaUser[1];
        Carta TerceiraCarta = listaUser[2];
        Carta QuartaCarta = listaUser[3];
        QuintaCarta = null; // computador não sabe qual é

        // vamos usar a 2, 3, 4 para descobrir quantidade a somar
        int distancia = GetDistanciaEntreCartas(SegundaCarta, TerceiraCarta, QuartaCarta);
        int valor = PrimeiraCarta.Valor + distancia;
        if (valor > Carta.K)
            valor -= Carta.K;

        // com distancia localizamos a quinta carta
        foreach (Carta c in listaUser)
        {
            if (c.Equals(PrimeiraCarta))
                continue;

            if (c.Naipe == PrimeiraCarta.Naipe && c.Valor == valor)
            {
                QuintaCarta = c;
                break;
            }
        }

        return QuintaCarta;
    }

    public List<Carta> MontarParaAcertar()
    {
        List<Carta> lista = GetCincoCartas();
        SepararPrimeiraEQuintaCarta(lista);

        // a diferença será no máximo 6
        int dif = GetDif();

        if (dif > 6)
        {
            // faz um swap (inverte primeira e quinta)
            Carta terceira = new Carta(PrimeiraCarta.Naipe, PrimeiraCarta.Valor);
            PrimeiraCarta = QuintaCarta;
            QuintaCarta = terceira;

            // atualiza diferenca
            dif = GetDif();
        }

        // a diferenca é que vai determinar a ordem das últimas 3
        // vamos pegar a Pequena, Media e Grande 
        Carta Pequena = new Carta(999, 99);
        Carta Grande = new Carta(0, 0);

        foreach (Carta c in lista)
        {
            // primeira e quinta ignora
            if (c.Equals(PrimeiraCarta) || c.Equals(QuintaCarta))
                continue;

            if (c.Valor < Pequena.Valor)
                Pequena = c;

            if (c.Valor == Pequena.Valor)
            {
                if (c.Naipe < Pequena.Naipe)
                    Pequena = c;
            }

            if (c.Valor > Grande.Valor)
                Grande = c;

            if (c.Valor == Grande.Valor)
            {
                if (c.Naipe > Grande.Naipe)
                    Grande = c;
            }
        }

        // a média é a que sobrou
        Carta Media = new Carta(0, 0);

        foreach (Carta c in lista)
        {
            // vamos achar a carta que não é nem a primeira, quinta, menor e maior
            if (c.Equals(PrimeiraCarta) || c.Equals(QuintaCarta) || c.Equals(Pequena) || c.Equals(Grande))
                continue;

            Media = c;
            break;
        }

        // saída final
        List<Carta> retorno = new List<Carta>();
        retorno.Add(PrimeiraCarta);

        switch (dif)
        {
            case PMG:
                retorno.Add(Pequena);
                retorno.Add(Media);
                retorno.Add(Grande);
                break;
            case PGM:
                retorno.Add(Pequena);
                retorno.Add(Grande);
                retorno.Add(Media);
                break;
            case MPG:
                retorno.Add(Media);
                retorno.Add(Pequena);
                retorno.Add(Grande);
                break;
            case MGP:
                retorno.Add(Media);
                retorno.Add(Grande);
                retorno.Add(Pequena);
                break;
            case GPM:
                retorno.Add(Grande);
                retorno.Add(Pequena);
                retorno.Add(Media);
                break;
            case GMP:
                retorno.Add(Grande);
                retorno.Add(Media);
                retorno.Add(Pequena);
                break;
        }

        return retorno;
    }
}