using Teasdobozok_Lib;

Filterek FilterBeolvasas()
{
    string[] sorok = File.ReadLines("Input\\filterek.txt").Skip(1).ToArray();

    List<Filter> filterekLista = new List<Filter>();

    foreach (var s in sorok)
    {
        string[] elem = s.Split(';');
        Filter f = new Filter(elem[0], elem[1], Convert.ToInt32(elem[2]));
        filterekLista.Add(f);
    }

    return new Filterek(filterekLista);
}

List<TeasDoboz> DobozBeolvasas(Filterek filterek)
{
    List<TeasDoboz> dobozok = new List<TeasDoboz>();
    List<string> hibak = new List<string>();

    foreach (var sor in File.ReadLines("Input\\dobozok.txt").Skip(1))
    {
        try
        {
            var doboz = new DobozFactory(sor, filterek).Doboz;
            dobozok.Add(doboz);
        }
        catch (HibasAzonositoException ex)
        {
            string hibaUzenet = $"{ex.Message} ({sor})";
            hibak.Add(hibaUzenet);
        }
    }

    if (hibak.Count > 0)
    {
        File.WriteAllLines("hibalista.txt", hibak);
    }

    return dobozok;
}

Filterek filterek = FilterBeolvasas();
List<TeasDoboz> teasDobozok = DobozBeolvasas(filterek);


Console.WriteLine("Elérhető gyógynövény filterek:");

foreach (var filter in filterek.GyogynovenyFilterek()) 
{
    Console.WriteLine(filter);
}
Console.WriteLine("");
Console.WriteLine("Elkészített teásdobozok:");
foreach (var doboz in teasDobozok) 
{
    Console.WriteLine(doboz);
}