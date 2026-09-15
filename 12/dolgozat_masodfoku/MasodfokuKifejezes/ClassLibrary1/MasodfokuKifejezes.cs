namespace ClassLibrary1
{
    public class MasodfokuKifejezes
    {
        public double a {get; init;}
        public double b {get; init;}
        public double c {get; init;}
        public MasodfokuKifejezes(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double Diszkriminans()
        {
            return b * b - 4 * a * c;
        }
        public override string ToString()
        {
            char elojelB = b >= 0 ? '+' : '-';
            char elojelC = c >= 0 ? '+' : '-';
            return $"{a}x^2 {elojelB} {b}x {elojelC} {c}";
        }
        public static MasodfokuKifejezes operator +(MasodfokuKifejezes m1, MasodfokuKifejezes m2)
        {
            return new MasodfokuKifejezes(m1.a + m2.a, m1.b + m2.b, m1.c + m2.c);
        }
        public static MasodfokuKifejezes operator -(MasodfokuKifejezes m1, MasodfokuKifejezes m2)
        {
            return new MasodfokuKifejezes(m1.a - m2.a, m1.b - m2.b, m1.c - m2.c);
        }
        public static bool operator ==(MasodfokuKifejezes m1, MasodfokuKifejezes m2)
        {
            double aranyA = m1.a / m2.a;
            double aranyB = m1.b / m2.b;
            double aranyC = m1.c / m2.c;

            if (aranyA == aranyB && aranyA == aranyC)
                return true;
            else
                return false;
        }

        public static bool operator !=(MasodfokuKifejezes k1, MasodfokuKifejezes k2)
        {
            return !(k1 == k2);
        }
    }
}

