namespace VedettAllat.Model
{
    public class VedettAllat67 : IVedettAllat67
    {
        readonly List<VedettAllat> _67 = new List<VedettAllat>();

        public VedettAllat67()
        {
            _67 = File.ReadAllLines("vedett.csv").Skip(1).Select(x => VedettAllat.CreateCSV(x)).ToList()!;
        }

        public int AddAnimal()
        {
            throw new NotImplementedException();
        }

        public void DeleteAnimal(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VedettAllat> GetAll()
        {
            return _67;
        }

        public IEnumerable<VedettAllat> GetByCat(string cat)
        {
            throw new NotImplementedException();
        }

        public VedettAllat? GetById(int id)
        {
            return _67.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<VedettAllat> GetByYear(int year)
        {
            return _67.Where(x => x.Ev == year).ToList();
        }

        public IEnumerable<string> GetCat()
        {
            return _67.Select(x => x.Kategoria);
        }

        public bool UpdateAnimal(int id)
        {
            throw new NotImplementedException();
        }

    }
}
