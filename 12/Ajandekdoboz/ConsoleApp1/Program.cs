using AjandekdobozLib;
using ConsoleApp1.ConsoleApp1;
using TermekLib;
using TermektipusLib;
using TermekTipusLib;


// ---------- itt minden terméknek saját ajándékdoboza van ----------
//ez azért jó mert a generikus osztályba lehet (igaz tkülön-külön, de) más típusú elemeket rakni
//pl: külön lista a kozmetikumoknak, DE UGYAN AZ A SABLON


// Kozmetikum doboz
var kozmetikaiDoboz = new AjandekDoboz<Kozmetikum>();
kozmetikaiDoboz.Hozzaad(new Kozmetikum("Parfüm", 6200));
kozmetikaiDoboz.Hozzaad(new Kozmetikum("Tusfürdő", 1800));
kozmetikaiDoboz.Hozzaad(new Kozmetikum("Arckrém", 3200));

Console.WriteLine(kozmetikaiDoboz);
Console.WriteLine("Tipusonkenti összérték (kozmetikum): " + kozmetikaiDoboz.TipusonkentiOsszertek("kozmetikum") + " Ft");
Console.WriteLine();


// Édesség doboz
var edessegDoboz = new AjandekDoboz<Edesseg>();
edessegDoboz.Hozzaad(new Edesseg("Csoki", 1200));
edessegDoboz.Hozzaad(new Edesseg("Nyalóka", 500));
edessegDoboz.Hozzaad(new Edesseg("Praliné", 1800));

Console.WriteLine(edessegDoboz);
Console.WriteLine("Tipusonkenti összérték (édeség): " + edessegDoboz.TipusonkentiOsszertek("édeség") + " Ft");
Console.WriteLine();


// Ital doboz
var italDoboz = new AjandekDoboz<Ital>();
italDoboz.Hozzaad(new Ital("Vörösbor", 7000));
italDoboz.Hozzaad(new Ital("Pezsgő", 5000));
italDoboz.Hozzaad(new Ital("Üdítő", 1200));

Console.WriteLine(italDoboz);
Console.WriteLine("Tipusonkenti összérték (ital): " + italDoboz.TipusonkentiOsszertek("ital") + " Ft");
Console.WriteLine();


// Húsválogatás
var husDoboz = new AjandekDoboz<Husvalogatas>();
husDoboz.Hozzaad(new Husvalogatas("Füstölt sonka", 6000));
husDoboz.Hozzaad(new Husvalogatas("Füstölt kolbász", 4500));
husDoboz.Hozzaad(new Husvalogatas("Steak", 6000));

Console.WriteLine(husDoboz);
Console.WriteLine("Tipusonkenti összérték (húsválogatás): " + husDoboz.TipusonkentiOsszertek("húsválogatás") + " Ft");
Console.WriteLine();


// eltávolítás
Console.WriteLine("Eltávolítjuk a steak-et a húsdobozból");
husDoboz.Eltavolit(new Husvalogatas("Steak", 6000));

Console.WriteLine(husDoboz);
Console.WriteLine("Összérték: " + husDoboz.Osszertek + " Ft");
Console.WriteLine();


//  ---------- itt pedig minden egy ajándékdobozban lesz ----------
//ez azért jó mert itt vegyesen vannak különböző típusú elemek

var vegyesDoboz = new AjandekDoboz<Termek>();

vegyesDoboz.Hozzaad(new Kozmetikum("Sampon", 2500));
vegyesDoboz.Hozzaad(new Edesseg("Csoki", 1200));
vegyesDoboz.Hozzaad(new Ital("Vörösbor", 7000));

Console.WriteLine(vegyesDoboz);
Console.WriteLine("Összérték a vegyesDoboz-nak: " + vegyesDoboz.Osszertek + " Ft");
