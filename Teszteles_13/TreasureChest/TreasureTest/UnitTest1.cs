using TreasureChest;

namespace TreasureTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ha_lakatolva_van_nem_nyilik()
        {
            Chest c = new Chest("c", 67);
            c.IsLocked = true;
            Assert.That(c.Open(), Is.EqualTo(false));
        }

        [Test]
        public void ha_csukva_van_kinyilik()
        {
            Chest c = new Chest("c", 67);
            c.UnLock();
            Assert.That(c.Open(), Is.EqualTo(true));
        }

        [Test]
        public void ha_nyitva_van_nem_nyilik()
        {
            Chest c = new Chest("c", 67);
            c.UnLock();
            c.Open();
            Assert.That(c.Open(), Is.EqualTo(false));
        }

        [Test]
        public void ha_csukva_van_nem_zarul()
        {
            Chest c = new Chest("c", 67);
            c.UnLock();
            Assert.That(c.Close(), Is.EqualTo(false));
        }

        [Test]
        public void nem_helyezi_bele_ha_nincs_eleg_hely()
        {
            Chest c = new Chest("c", 10);
            Treasure t = new Treasure("t1", 11);
            c.UnLock();
            c.Open();
            Assert.That(c.Store(t), Is.EqualTo(false));
        }

        [Test]
        public void nem_helyezi_bele_ha_csukva_van()
        {
            Chest c = new Chest("c", 10);
            Treasure t = new Treasure("t1", 5);
            c.UnLock();
            Assert.That(c.Store(t), Is.EqualTo(false));
        }

        [Test]
        public void ha_nyitva_van_nem_lakatolodik()
        {
            Chest c = new Chest("c", 10);
            Treasure t = new Treasure("t1", 5);
            c.UnLock();
            c.Open();
            Assert.That(c.Lock(), Is.EqualTo(false));
        }


        [Test]
        public void beleteszi_ha_minden_stimmel()
        {
            Chest c = new Chest("c", 10);
            Treasure t = new Treasure("t1", 5);
            c.IsLocked = false;
            c.IsOpen = true;
            Assert.That(c.Store(t), Is.EqualTo(true));
        }

        [Test]
        public void lock_nem_zarja_be_ha_mar_zarva_van()
        {
            Chest c = new Chest("c", 10);

            Assert.That(c.Lock(), Is.EqualTo(false));
        }

        [Test]
        public void nem_nyitja_ha_nyitva_van()
        {
            Chest c = new Chest("c", 10);
            c.UnLock();
            Assert.That(c.Open(), Is.EqualTo(true));
        }

        [Test]
        public void nem_nyitja_ha_lakatolva_van()
        {
            Chest c = new Chest("c", 10);
            Assert.That(c.Open(), Is.EqualTo(false));
        }

        [Test]
        public void utolso_kivetele()
        {
            Chest c = new Chest("c", 10);
            c.UnLock();
            c.Open();
            c.Store(new Treasure("alma", 1));
            Treasure korte = new Treasure("korte", 1);
            c.Store(korte);
            c.Store(new Treasure("banan", 1));

            c.TakeOutLast();
            Assert.That(c.TakeOutLast().Name, Is.EqualTo(korte.Name));
        }
        [Test]
        public void nem_helyezi_bele_ha_nincs_nyitva()
        {
            Chest c = new Chest("c", 10);
            c.UnLock();
            
            Assert.That(c.Store(new Treasure("alma", 1)), Is.EqualTo(false));
        }
        [Test]
        public void nem_nyitja_ha_zarva_van()
        {
            Chest c = new Chest("c", 10);

            Assert.That(c.Open(), Is.EqualTo(false));
        }


        [Test]
        public void negativ_Volumeu_chest_nem_lehet()
        {
            Chest c = new Chest("c", -10);

            Assert.That(c.Volume, Is.Not.EqualTo(-10));
        }

        [Test]
        public void negativ_Volumeu_treasure_lehet()
        {
            Treasure t = new Treasure("c", -10);

            Assert.That(t.Volume, Is.Not.EqualTo(-10));
        }

        [Test]
        public void kiveszi_ha_zarva_van_nev_alapjan()
        {
            Chest c = new Chest("c", 67);
            c.UnLock();
            c.Open();
            c.Store(new Treasure("alma", 13));
            Assert.That(c.TakeOut("alma").Name, Is.EqualTo("alma"));
        }

        [Test]
        public void egyet_vesz_ki_ha_kettonek_ugyan_az_a_neve()
        {
            Chest c = new Chest("c", 67);
            c.UnLock();
            c.Open();
            c.Store(new Treasure("alma", 13));
            c.Store(new Treasure("alma", 13));
            c.TakeOut("alma");
            Assert.That(c.TakeOut("alma").Name, Is.EqualTo("alma"));
        }

        [Test]
        public void elso_kincset_veszi_ki_ha_tobb_ugyanolyan_nevu_van()
        {
            Chest c = new Chest("c", 67);
            c.UnLock();
            c.Open();
            Treasure elsoKard = new Treasure("kard", 5);
            Treasure pajzs = new Treasure("pajzs", 2);
            Treasure masodikKard = new Treasure("kard", 10);
            c.Store(elsoKard);
            c.Store(pajzs);
            c.Store(masodikKard);

            Treasure? kivett = c.TakeOut("kard");
            Assert.That(kivett, Is.EqualTo(elsoKard));
        }
    }
}