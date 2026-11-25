using Urhajok;
using Xunit;

namespace UrhajokTests;

public class UrhajokTests
{

    static UrhajóTípus FelderitőTípus() => new("felderítő", "leírás",
        [new Szakertelem("navigáció", 2)]);

    static UrhajóOsztály FelfedezoOsztaly() => new("felfedező");

    static Urhajó UjHajo(int ferohely = 5) =>
        new("Kutató 11", FelderitőTípus(), FelfedezoOsztaly(), 2024, ferohely);

    static LegénységiTag UjTag(string nev, int navigacio = 0) =>
        new(nev, "magyar", new DateOnly(2000, 1, 1), "férfi",
            navigacio > 0 ? [new Szakertelem("navigáció", navigacio)] : []);



    [Fact]
    public void Osztaly_UresNevvel_Kivételt_Dob()
    {
        Assert.Throws<ArgumentException>(() => new UrhajóOsztály(""));
    }

    [Fact]
    public void Osztaly_ErvenyesNev_Letrejon()
    {
        var o = new UrhajóOsztály("felfedező");
        Assert.Equal("felfedező", o.Nev);
    }


    [Fact]
    public void Indithato_UresLegénységgel_Hamis()
    {
        Assert.False(UjHajo().Indithato);
    }

    [Fact]
    public void Indithato_NincsElvártSzakértelem_Igaz()
    {
        var hajo = new Urhajó("X", new UrhajóTípus("x", "x"), FelfedezoOsztaly(), 2020, 3);
        Assert.True(hajo.Indithato);
    }

    [Fact]
    public void Indithato_EgyenloSzinttel_Hamis()
    {
        var hajo = UjHajo();
        hajo.Legénység.Add(UjTag("A", 2));
        Assert.False(hajo.Indithato);
    }

    [Fact]
    public void Indithato_TöbbTagOsszegeMeghaladja_Igaz()
    {
        var hajo = UjHajo();
        hajo.Legénység.Add(UjTag("A", 2));
        hajo.Legénység.Add(UjTag("B", 1));
        Assert.True(hajo.Indithato);
    }

    [Fact]
    public void Indithato_EgyTagMeghaladja_Igaz()
    {
        var hajo = UjHajo();
        hajo.Legénység.Add(UjTag("A", 3));
        Assert.True(hajo.Indithato);
    }


    [Fact]
    public void SzakertelmSzintje_LetezoSzakertelem_HelyellenSzintet_Ad()
    {
        var tag = new LegénységiTag("X", "magyar", new DateOnly(2000, 1, 1), "nő",
            [new Szakertelem("navigáció", 3)]);
        Assert.Equal(3, tag.SzakertelmSzintje("navigáció"));
    }

    [Fact]
    public void SzakertelmSzintje_NemLetezo_NullVissza()
    {
        var tag = UjTag("X", 2);
        Assert.Equal(0, tag.SzakertelmSzintje("mérnöki"));
    }

    [Fact]
    public void SzakertelmSzintje_NagybetűsNem_SzamitEnset()
    {
        var tag = UjTag("X", 2);
        Assert.Equal(2, tag.SzakertelmSzintje("NAVIGÁCIÓ"));
    }


    [Fact]
    public void Hozzárendel_SzabadTagEsHajo_Sikeres()
    {
        var pk = new Urparancsnoksag();
        var hajo = UjHajo();
        var tag = UjTag("Anna");
        pk.HajóHozzáad(hajo);
        pk.LegénységiTagHozzáad(tag);
        pk.LegénységHozzárendel(tag, hajo);

        Assert.Contains(tag, hajo.Legénység);
        Assert.DoesNotContain(tag, pk.SzabadLegénység);
    }

    [Fact]
    public void Hozzárendel_NemSzabadTag_Kivételt_Dob()
    {
        var pk = new Urparancsnoksag();
        var hajo = UjHajo();
        pk.HajóHozzáad(hajo);
        var tag = UjTag("Anna");
        Assert.Throws<InvalidOperationException>(() => pk.LegénységHozzárendel(tag, hajo));
    }

    [Fact]
    public void Hozzárendel_TeleHajóra_Kivételt_Dob()
    {
        var pk = new Urparancsnoksag();
        var hajo = UjHajo(ferohely: 1);
        var tag1 = UjTag("A");
        var tag2 = UjTag("B");
        pk.HajóHozzáad(hajo);
        pk.LegénységiTagHozzáad(tag1);
        pk.LegénységiTagHozzáad(tag2);
        pk.LegénységHozzárendel(tag1, hajo);
        Assert.Throws<InvalidOperationException>(() => pk.LegénységHozzárendel(tag2, hajo));
    }


    [Fact]
    public void Visszavon_HozzárendeltTag_SzabadLesz()
    {
        var pk = new Urparancsnoksag();
        var hajo = UjHajo();
        var tag = UjTag("Béla");
        pk.HajóHozzáad(hajo);
        pk.LegénységiTagHozzáad(tag);
        pk.LegénységHozzárendel(tag, hajo);
        pk.LegénységVissza(tag);

        Assert.Contains(tag, pk.SzabadLegénység);
        Assert.DoesNotContain(tag, hajo.Legénység);
    }

    [Fact]
    public void Visszavon_NemHozzárendelt_Kivételt_Dob()
    {
        var pk = new Urparancsnoksag();
        var tag = UjTag("X");
        pk.LegénységiTagHozzáad(tag);
        Assert.Throws<InvalidOperationException>(() => pk.LegénységVissza(tag));
    }

    [Fact]
    public void TagHajója_HozzárendeltTag_NemNull()
    {
        var pk = new Urparancsnoksag();
        var hajo = UjHajo();
        var tag = UjTag("X");
        pk.HajóHozzáad(hajo);
        pk.LegénységiTagHozzáad(tag);
        pk.LegénységHozzárendel(tag, hajo);
        Assert.Equal(hajo, pk.TagHajója(tag));
    }

    [Fact]
    public void TagHajója_SzabadTag_Null()
    {
        var pk = new Urparancsnoksag();
        var tag = UjTag("X");
        Assert.Null(pk.TagHajója(tag));
    }


    [Fact]
    public void Áthelyezés_VissznasEsÚjHajóra_Sikeres()
    {
        var pk = new Urparancsnoksag();
        var h1 = UjHajo();
        var h2 = new Urhajó("Másik", FelderitőTípus(), FelfedezoOsztaly(), 2020, 5);
        var tag = UjTag("Erik");
        pk.HajóHozzáad(h1);
        pk.HajóHozzáad(h2);
        pk.LegénységiTagHozzáad(tag);

        pk.LegénységHozzárendel(tag, h1);
        pk.LegénységVissza(tag);
        pk.LegénységHozzárendel(tag, h2);

        Assert.Contains(tag, h2.Legénység);
        Assert.DoesNotContain(tag, h1.Legénység);
    }



    [Fact]
    public void PdfPélda_KutatoHajoJohnSmith()
    {
        var tipus = new UrhajóTípus("felderítő",
            "mélységi felderítő űrhajó, mélyvíri felfedezésekhez.",
            [new Szakertelem("navigáció", 2)]);
        var hajo = new Urhajó("Kutató 11", tipus, new UrhajóOsztály("felfedező"), 2024, 10);

        var john = new LegénységiTag("John Smith", "amerikai",
            new DateOnly(2001, 11, 2), "férfi",
            [new Szakertelem("diplomácia", 1), new Szakertelem("navigáció", 2)]);

        var pk = new Urparancsnoksag();
        pk.HajóHozzáad(hajo);
        pk.LegénységiTagHozzáad(john);
        pk.LegénységHozzárendel(john, hajo);

        Assert.False(hajo.Indithato);

        var extra = new LegénységiTag("Ana", "spanyol",
            new DateOnly(1995, 3, 15), "nő",
            [new Szakertelem("navigáció", 1)]);
        pk.LegénységiTagHozzáad(extra);
        pk.LegénységHozzárendel(extra, hajo);

        Assert.True(hajo.Indithato);
    }
}
