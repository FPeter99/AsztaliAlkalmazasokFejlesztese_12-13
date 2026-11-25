using AktivaloKod_Lib;

namespace ActivatetionCodeValidator_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("J123-GGGG-CCCC")]
        [TestCase("JRT3-G5G7-C13L")]
        [TestCase("J123-GCaa-aaaa")]
        [TestCase("J123GCaaaaaa")]
        public void PassTeszt(string code)
        {
            ActivatetionCodeValidator a = new ActivatetionCodeValidator();
            bool m = a.CheckCodeValidity(code);
            Assert.That(m, Is.True);
        }

        [TestCase("JJJJ-GGGG-CCCC")] // ninics szam
        [TestCase("AAAA-BBBB-CG12")] // ninics J
        [TestCase("AAAA-BBB1-JJGC")] // ninics nem pont egy J
        [TestCase("J123-GCaa-aaaá")] // á-t tartalmaz
        [TestCase("-J123GCaa-aaaa")] // - rossz helyen
        [TestCase("aaaa-JGCaa-aaaa")] // - nincs szám
        public void PassTesztFail(string code)
        {
            ActivatetionCodeValidator a = new ActivatetionCodeValidator();
            bool m = a.CheckCodeValidity(code);
            Assert.That(m, Is.False);
        }
    }
}
