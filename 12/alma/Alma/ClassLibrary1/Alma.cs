
using System.Text.Json.Serialization;

namespace ClassLibrary1
{
    public class Alma : ISzimulacio
    {
        const int KEZDO_MERET = 5;
        const int NOVEKEDES_LEPES_IDO = 2;
        readonly (int, int) NOVEKEDES_MERET = (1, 3);
        const int ERESHATAR_MERET = 80;
        const int ERES_LEPES_IDO = 5;
        readonly (int, int) ERES_SZAZALEK = (5, 10);
        const int PERC = 60;
        readonly (int, int) ROHADAS_IDO = (2 * PERC, 5 * PERC);
        const int HALAL_IDO = 5 * PERC;

        [JsonConstructor]
        public Alma(int meret, int eresSzazalek, int korokSzama, int rohasasKorSzam)
        {
            Meret = meret;
            EresSzazalek = eresSzazalek;
            KorokSzama = korokSzama;
            RohasasKorSzam = rohasasKorSzam;
        }

        public Alma()
        {
            Meret = KEZDO_MERET;
            EresSzazalek = 0;
            KorokSzama = 0;
            RohasasKorSzam = -1;
        }

        public int Meret { get; private set; }
        public int EresSzazalek { get; private set; }
        public int KorokSzama { get; private set; }
        public int RohasasKorSzam { get; private set; }

        bool Megnott => Meret >= ERESHATAR_MERET;
        bool Rohadt => KorokSzama >= RohasasKorSzam;

        [JsonIgnore]
        public bool EletbenVan => RohasasKorSzam < 0 || KorokSzama < RohasasKorSzam + HALAL_IDO;

        static int RandomIntervallum((int, int) intervallum) => Random.Shared.Next(intervallum.Item1, intervallum.Item2 + 1);

        void Novenyedes()
        {
            if (Megnott)return;
            if (KorokSzama % NOVEKEDES_LEPES_IDO == 0){ 
                Meret += RandomIntervallum(NOVEKEDES_MERET); 
            }
        }

        void Eres()
        {
            if (!Megnott) return;
            if (KorokSzama % ERES_LEPES_IDO == 0 && EresSzazalek < 100)
            {
                EresSzazalek = 100;
                RohasasKorSzam = KorokSzama + RandomIntervallum(ROHADAS_IDO);

            }
        }

        public void Kor()
        { 
            ++KorokSzama;
            Novenyedes();
            Eres();
        }

        public override string ToString()
        {
            return EresSzazalek switch
            {
                _ when !Megnott => $"Gyümölcslezdemény: {Meret} mm",
                < 100 => $"Gyümölcs: {EresSzazalek}% érett",
                _ when !Rohadt => "Érett gyümölcs",
                _ when EletbenVan => "Ez az alma megrohadt",
                _ => "Ez az alma meghalt"
            };
        }

    }


}
