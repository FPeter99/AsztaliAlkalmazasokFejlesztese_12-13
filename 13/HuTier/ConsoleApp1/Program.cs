using HuTierLib;

// A hutier.hu nyilvános REST API-ját használjuk.
// Dokumentáció: https://hutier.hu/api-docs (kulcs nem szükséges)

const string BASE_URL = "https://hutier.hu";

Console.Write("Játékosnév (pl: K1RBE_): ");
string? username = Console.ReadLine();

const string gamemode= "vanilla";

var api = new HuTierApiHandler(BASE_URL);
using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));

string user = Uri.EscapeDataString(username);
string mode = Uri.EscapeDataString(gamemode);

Console.WriteLine($"{username} összes eredménye:\n");

//minden játékmód
HuTierApiHandler.TestsResponse? allTests =
    await api.GetAsync<HuTierApiHandler.TestsResponse>($"api/tests?username={user}", cts.Token);

if (allTests is null || allTests.tests is null) {
    Console.WriteLine("    Hiba: nem sikerült lekérni az adatokat.");
} else {
    Console.WriteLine($"Felhasználó: {username}  |  Bannolt: {allTests.banned}  |  Teljesen visszavonult: {allTests.fullRetired}");
    Console.WriteLine($"Összesen {allTests.tests.Length} játékmód eredménye:\n");

    Console.WriteLine($"{"Játékmód",-16} {"Rang",-6} {"Pont",4}  {"Össz.helyezés",14}  {"Visszavonult",12}  {"Teszter",7}");
    Console.WriteLine($"{new string('-', 65)}");

    foreach (HuTierApiHandler.TestResult t in allTests.tests) {
        bool retired = allTests.retiredByGamemode?.GetValueOrDefault(t.gamemode) ?? false;
        bool tester = allTests.testerByGamemode?.GetValueOrDefault(t.gamemode) ?? false;
        Console.WriteLine($"    {t.gamemode,-12} {t.rank,-6} {t.points,4}  {"#" + t.overall_position,14}  {retired,12}  {tester,7}");
    }
}

//egy játékmód
HuTierApiHandler.SingleTestResponse? single =
    await api.GetAsync<HuTierApiHandler.SingleTestResponse>($"api/tests?username={user}&gamemode={mode}", cts.Token);
HuTierApiHandler.TestResult? singleTest = single?.test;

if (singleTest is null) {
    Console.WriteLine($"Nem található '{gamemode}' eredmény.");
} else {
    Console.WriteLine($"\nUUID           :  {singleTest.player_uuid}");
    Console.WriteLine($"Játékmód       :  {singleTest.gamemode}");
    Console.WriteLine($"Rang           :  {singleTest.rank}");
    Console.WriteLine($"Pontszám       :  {singleTest.points}");
    Console.WriteLine($"Össz. helyezés :  #{singleTest.overall_position}");
    Console.WriteLine($"Visszavonult?  :  {singleTest.retired}");
    Console.WriteLine($"Teszter?       :  {singleTest.tester}");
    Console.WriteLine($"Létrehozva     :  {singleTest.created_at ?? "ismeretlen"}");
    Console.WriteLine($"Frissítve      :  {singleTest.updated_at ?? "ismeretlen"}");
}


if (allTests?.tests is not null)
{
    int totalPoints = allTests.tests.Sum(t => t.points);
    Console.WriteLine($"\nÖsszpontszám: {totalPoints}");
}