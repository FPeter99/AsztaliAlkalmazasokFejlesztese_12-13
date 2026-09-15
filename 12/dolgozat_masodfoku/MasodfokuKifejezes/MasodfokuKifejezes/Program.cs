using ClassLibrary1;

Console.WriteLine("A*X^2 + B*X + C");

Console.WriteLine("");

Console.WriteLine("első másodfokú:");
Console.WriteLine("'A' együttható: ");
double m1A = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("'B' együttható: ");
double m1B = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("'C' együttható: ");
double m1C = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("");

Console.WriteLine("második másodfokú:");
Console.WriteLine("'A' együttható: ");
double m2A = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("'B' együttható: ");
double m2B = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("'C' együttható: ");
double m2C = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("");

Console.Write("Első:");
MasodfokuKifejezes masodfoku1 = new MasodfokuKifejezes(m1A, m1B, m1C);
Console.WriteLine(masodfoku1.ToString());
Console.WriteLine($"D = {masodfoku1.Diszkriminans()}");

Console.Write("Máspdik:");
MasodfokuKifejezes masodfoku2 = new MasodfokuKifejezes(m2A, m2B, m2C);
Console.WriteLine(masodfoku2.ToString());
Console.WriteLine($"D = {masodfoku2.Diszkriminans()}");

Console.WriteLine("");

Console.WriteLine("Összeg:");
Console.WriteLine((masodfoku1 + masodfoku2).ToString());

Console.WriteLine("Különbség:");
Console.WriteLine((masodfoku1 - masodfoku2).ToString());

Console.WriteLine("egyenlőek-e?");
if (masodfoku1 == masodfoku2)
    Console.WriteLine("igen");
else
    Console.WriteLine("nem");