namespace Urhajok;

public class Urparancsnoksag
{
    public List<Urhajó> Hajók { get; } = [];
    public List<LegénységiTag> SzabadLegénység { get; } = [];

    private readonly Dictionary<LegénységiTag, Urhajó> _hozzárendelések = [];

    public void HajóHozzáad(Urhajó hajo) => Hajók.Add(hajo);

    public void LegénységiTagHozzáad(LegénységiTag tag) => SzabadLegénység.Add(tag);

    public void LegénységHozzárendel(LegénységiTag tag, Urhajó hajo)
    {
        if (hajo.Legénység.Count >= hajo.Ferohely)
            throw new InvalidOperationException("Nincs szabad hely a hajón.");
        if (!SzabadLegénység.Contains(tag))
            throw new InvalidOperationException("A tag nem szabad.");

        SzabadLegénység.Remove(tag);
        hajo.Legénység.Add(tag);
        _hozzárendelések[tag] = hajo;
    }

    public void LegénységVissza(LegénységiTag tag)
    {
        if (!_hozzárendelések.TryGetValue(tag, out var hajo))
            throw new InvalidOperationException("A tag nincs hozzárendelve.");

        hajo.Legénység.Remove(tag);
        _hozzárendelések.Remove(tag);
        SzabadLegénység.Add(tag);
    }

    public Urhajó? TagHajója(LegénységiTag tag)
        => _hozzárendelések.GetValueOrDefault(tag);
}
