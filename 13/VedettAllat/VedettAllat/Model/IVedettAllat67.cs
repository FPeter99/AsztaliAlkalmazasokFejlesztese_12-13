namespace VedettAllat.Model
{
    public interface IVedettAllat67
    {
        public IEnumerable<VedettAllat> GetAll();
        public VedettAllat? GetById(int id);
        public IEnumerable<VedettAllat> GetByYear(int year);
        public IEnumerable<string> GetCat();
        public IEnumerable<VedettAllat> GetByCat(string cat);
        public int AddAnimal();
        public bool UpdateAnimal(int id);
        public void DeleteAnimal(int id);
    }
}
