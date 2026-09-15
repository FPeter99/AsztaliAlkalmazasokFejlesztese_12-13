using ClassLibrary1;
using System.Text.Json;
using System.Threading.Tasks;

Alma alma;

string fajlNev = "alma.json";

try
{
    alma = JsonSerializer.Deserialize<Alma>(File.ReadAllText(fajlNev))!;
}
catch
{
    alma = new Alma();
}


bool kilepes = false;
Parallel.Invoke(
    () =>
    {
        while (!kilepes && alma.EletbenVan)
        {
            alma.Kor();
            Console.Clear();
            Console.WriteLine(alma.ToString());
            Thread.Sleep(100);
        }

        if (alma.EletbenVan)
        {
            Alma szimulacio = null;
            File.WriteAllText(fajlNev,
                JsonSerializer.Serialize<Alma>((szimulacio as Alma)!));
        }
        else
        {
            if (File.Exists(fajlNev))
            {
                File.Delete(fajlNev);
            }
        }

    },

    () =>
    {
        Console.ReadLine();
        kilepes = true;
    }
);
    