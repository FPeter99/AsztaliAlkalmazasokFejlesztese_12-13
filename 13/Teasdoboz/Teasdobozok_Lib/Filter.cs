namespace Teasdobozok_Lib
{
    public class Filter
    {
        public string ID { get; init; }
        public string Tipus { get; init; }
        public int Ar { get; init; }

        public Filter(string ID, string Tipus, int Ar) 
        {
            this.ID = ID;
            this.Tipus = Tipus;
            this.Ar = Ar;
        }

        public bool Gyogytea() 
        {
            return ID[0] == 'z';
        }

        public override string ToString() 
        {
            return $"{Tipus} ({Ar} Ft)";
        }
    }
}
