using NUnit.Framework;
using Busztarsasag;

namespace BuszTeszt;

[TestFixture]
public class BuszTesztek
{
    [Test]
    public void Busz_Letrehozas_Sikeres()
    {
        Busz busz = new Busz("ABC-123", 40);

        Assert.That(busz.Rendszam, Is.EqualTo("ABC-123"));
        Assert.That(busz.Ferohely, Is.EqualTo(40));
        Assert.That(busz.AktualisUtasok, Is.EqualTo(0));
        Assert.That(busz.OsszesSzallitottUtas, Is.EqualTo(0));
    }

    [Test]
    public void Busz_Letrehozas_ErvenytelenAdatok_KiveteltDob()
    {
        Assert.That(() => new Busz("ABC-123", 0), Throws.TypeOf<ArgumentException>());
        Assert.That(() => new Busz("ABC-123", -15), Throws.TypeOf<ArgumentException>());
        Assert.That(() => new Busz("", 30), Throws.TypeOf<ArgumentException>());
        Assert.That(() => new Busz("   ", 30), Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void Busz_Megallo_MindenkiFelfer_NincsLentMaradt()
    {
        Busz busz = new Busz("ABC-123", 50);

        int lentMaradt = busz.Megallo(0, 20);

        Assert.That(lentMaradt, Is.EqualTo(0));
        Assert.That(busz.AktualisUtasok, Is.EqualTo(20));
        Assert.That(busz.OsszesSzallitottUtas, Is.EqualTo(20));
    }

    [Test]
    public void Busz_Megallo_KevesebbSzabadHely_BuszMegtelikEsLentMaradnak()
    {
        Busz busz = new Busz("ABC-123", 30);

        int lentMaradt = busz.Megallo(0, 35);

        Assert.That(lentMaradt, Is.EqualTo(5));
        Assert.That(busz.AktualisUtasok, Is.EqualTo(30));
        Assert.That(busz.OsszesSzallitottUtas, Is.EqualTo(30));
    }

    [Test]
    public void Busz_Megallo_Leszallas_CsokkentiAzUtasokSzamat()
    {
        Busz busz = new Busz("ABC-123", 40);
        busz.Megallo(0, 25);

        int lentMaradt = busz.Megallo(10, 0);

        Assert.That(lentMaradt, Is.EqualTo(0));
        Assert.That(busz.AktualisUtasok, Is.EqualTo(15));
        Assert.That(busz.OsszesSzallitottUtas, Is.EqualTo(25));
    }

    [Test]
    public void Busz_Megallo_ErvenytelenAdatok_KiveteltDob()
    {
        Busz busz = new Busz("ABC-123", 30);
        busz.Megallo(0, 5);

        Assert.That(() => busz.Megallo(8, 0), Throws.TypeOf<InvalidOperationException>());
        Assert.That(() => busz.Megallo(-2, 5), Throws.TypeOf<ArgumentException>());
        Assert.That(() => busz.Megallo(0, -5), Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void Busz_Megallo_EloszorLeszallnakMajdFelszallnak()
    {
        Busz busz = new Busz("ABC-123", 20);
        busz.Megallo(0, 18);

        int lentMaradt = busz.Megallo(8, 12);

        Assert.That(lentMaradt, Is.EqualTo(2));
        Assert.That(busz.AktualisUtasok, Is.EqualTo(20));
        Assert.That(busz.OsszesSzallitottUtas, Is.EqualTo(28));
    }

    [Test]
    public void Busz_TobbMegalloUtan_OsszesUtasHelyes()
    {
        Busz busz = new Busz("ABC-123", 50);

        busz.Megallo(0, 15);
        busz.Megallo(5, 10);
        busz.Megallo(10, 8);

        Assert.That(busz.AktualisUtasok, Is.EqualTo(18));
        Assert.That(busz.OsszesSzallitottUtas, Is.EqualTo(33));
    }

    [Test]
    public void Flotta_BuszHozzaadasa_Mukodik()
    {
        Buszflotta flotta = new Buszflotta();
        Busz busz = new Busz("ABC-123", 30);

        flotta.BuszHozzaadasa(busz);

        Assert.That(flotta.Buszok.Count, Is.EqualTo(1));
        Assert.That(flotta.BuszKeresese("ABC-123"), Is.EqualTo(busz));
    }

    [Test]
    public void Flotta_Hibakezeles_KiveteltDob()
    {
        Buszflotta flotta = new Buszflotta();
        flotta.BuszHozzaadasa(new Busz("ABC-123", 30));

        Assert.That(() => flotta.BuszHozzaadasa(new Busz("ABC-123", 50)), Throws.TypeOf<ArgumentException>());
        Assert.That(() => flotta.BuszKeresese("NINCS-1"), Throws.TypeOf<KeyNotFoundException>());
    }

    [Test]
    public void Flotta_MegalloEsemeny_MukodikEsLentMaradtatAdVissza()
    {
        Buszflotta flotta = new Buszflotta();
        flotta.BuszHozzaadasa(new Busz("ABC-123", 25));

        int lentMaradt = flotta.MegalloEsemeny("ABC-123", "Főtér", 0, 30);

        Assert.That(lentMaradt, Is.EqualTo(5));
        Assert.That(flotta.GetMegallobanFelszalltUtasok("Főtér"), Is.EqualTo(25));
    }

    [Test]
    public void Flotta_MegalloStatisztikak_Lekerdezese()
    {
        Buszflotta flotta = new Buszflotta();
        flotta.BuszHozzaadasa(new Busz("ABC-123", 50));
        flotta.BuszHozzaadasa(new Busz("XYZ-789", 50));

        flotta.MegalloEsemeny("ABC-123", "Főtér", 0, 15);
        flotta.MegalloEsemeny("XYZ-789", "Főtér", 0, 20);
        flotta.MegalloEsemeny("ABC-123", "Iskola", 12, 5);

        Assert.That(flotta.GetMegallobanFelszalltUtasok("Főtér"), Is.EqualTo(35));
        Assert.That(flotta.GetMegallobanLeszalltUtasok("Iskola"), Is.EqualTo(12));
    }

    [Test]
    public void Flotta_BuszOsszesSzallitottUtasa_Lekerdezese()
    {
        Buszflotta flotta = new Buszflotta();
        flotta.BuszHozzaadasa(new Busz("ABC-123", 40));

        flotta.MegalloEsemeny("ABC-123", "M1", 0, 20);
        flotta.MegalloEsemeny("ABC-123", "M2", 5, 10);

        int osszes = flotta.GetBuszOsszesUtasa("ABC-123");

        Assert.That(osszes, Is.EqualTo(30));
    }

    [Test]
    public void Flotta_NapVegiAdatokTorlese_NullazMindent()
    {
        Buszflotta flotta = new Buszflotta();
        Busz busz = new Busz("ABC-123", 40);
        flotta.BuszHozzaadasa(busz);

        flotta.MegalloEsemeny("ABC-123", "Főtér", 0, 25);
        flotta.MegalloEsemeny("ABC-123", "Kórház", 10, 5);

        flotta.NapVegiAdatokTorlese();

        Assert.That(flotta.GetMegallobanFelszalltUtasok("Főtér"), Is.EqualTo(0));
        Assert.That(flotta.GetMegallobanLeszalltUtasok("Kórház"), Is.EqualTo(0));
        Assert.That(flotta.GetBuszOsszesUtasa("ABC-123"), Is.EqualTo(0));
        Assert.That(busz.AktualisUtasok, Is.EqualTo(0));
    }
}
