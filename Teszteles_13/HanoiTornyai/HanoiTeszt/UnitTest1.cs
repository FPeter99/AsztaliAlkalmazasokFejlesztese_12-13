using NUnit.Framework;
using HanoiTornyai;

namespace HanoiTeszt
{
    [TestFixture]
    public class HanoiLogikaTesztek
    {
        [Test]
        public void Inicializalas_HelyesKezdoAllapot()
        {
            var jatek = new Hanoi_Logika(3);

            Assert.That(jatek.A.Count, Is.EqualTo(3));
            Assert.That(jatek.B.Count, Is.EqualTo(0));
            Assert.That(jatek.C.Count, Is.EqualTo(0));
            Assert.That(jatek.n, Is.EqualTo(3));
            Assert.That(jatek.A.Peek(), Is.EqualTo(1));
            Assert.That(jatek.vesztett, Is.False);
            Assert.That(jatek.nyert, Is.False);
        }

        [Test]
        public void ErvenyesMozgatas_SikeresKorongAtrakas()
        {
            var jatek = new Hanoi_Logika(3);

            bool siker = jatek.Mozgatas("ab");

            Assert.That(siker, Is.True);
            Assert.That(jatek.A.Count, Is.EqualTo(2));
            Assert.That(jatek.B.Count, Is.EqualTo(1));
            Assert.That(jatek.B.Peek(), Is.EqualTo(1));
            Assert.That(jatek.A.Peek(), Is.EqualTo(2));
            Assert.That(jatek.vesztett, Is.False);
        }

        [Test]
        public void Mozgatas_UresRudrol_Sikertelen()
        {
            var jatek = new Hanoi_Logika(3);

            bool siker = jatek.Mozgatas("ba");

            Assert.That(siker, Is.False);
            Assert.That(jatek.A.Count, Is.EqualTo(3));
            Assert.That(jatek.B.Count, Is.EqualTo(0));
        }

        [Test]
        public void Mozgatas_ErvenytelenRudNev_Sikertelen()
        {
            var jatek = new Hanoi_Logika(3);

            bool siker = jatek.Mozgatas("ax");

            Assert.That(siker, Is.False);
            Assert.That(jatek.A.Count, Is.EqualTo(3));
        }

        [Test]
        public void Mozgatas_NagyobbKorongKisebbre_VesztestEredmenyez()
        {
            var jatek = new Hanoi_Logika(3);

            jatek.Mozgatas("ab");
            Assert.That(jatek.vesztett, Is.False);

            bool lepesSiker = jatek.Mozgatas("ab");

            Assert.That(lepesSiker, Is.True);
            Assert.That(jatek.vesztett, Is.True);
            Assert.That(jatek.B.Peek(), Is.EqualTo(2));
        }

        [Test]
        public void VesztettAllapotban_NyertE_NemNyert()
        {
            var jatek = new Hanoi_Logika(2);

            jatek.Mozgatas("ac");
            jatek.Mozgatas("ac");

            Assert.That(jatek.vesztett, Is.True);
            Assert.That(jatek.C.Count, Is.EqualTo(2));
            Assert.That(jatek.NyertE(), Is.False);
        }

        [Test]
        public void NyertE_KezdetiAllapotban_Hamis()
        {
            var jatek = new Hanoi_Logika(3);

            bool nyert = jatek.NyertE();

            Assert.That(nyert, Is.False);
        }

        [Test]
        public void NyertE_SzabalyszeruVegigjatszas_Igaz()
        {
            var jatek = new Hanoi_Logika(2);

            Assert.That(jatek.Mozgatas("ab"), Is.True);
            Assert.That(jatek.Mozgatas("ac"), Is.True);
            Assert.That(jatek.Mozgatas("bc"), Is.True);

            Assert.That(jatek.vesztett, Is.False);
            Assert.That(jatek.C.Count, Is.EqualTo(2));
            Assert.That(jatek.NyertE(), Is.True);
        }

        [Test]
        public void ToString_HelyesFormazassalMegjelenik()
        {
            var jatek = new Hanoi_Logika(3);

            string kimenet = jatek.ToString();

            Assert.That(kimenet, Is.Not.Null.And.Not.Empty);
            Assert.That(kimenet, Does.Contain("A"));
            Assert.That(kimenet, Does.Contain("B"));
            Assert.That(kimenet, Does.Contain("C"));
        }
    }
}
