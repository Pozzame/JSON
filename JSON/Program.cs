using Newtonsoft.Json;
internal class Program
{
    private static void Main(string[] args)
    {
        string pathjson = @"test.json";
        string pathcsv = @"test.csv";
        dynamic json = JsonConvert.DeserializeObject(File.ReadAllText(pathjson))!;
        Console.WriteLine($"-----{json[0].Nome} {json[0].Cognome}-----\nNato il {json[0].Nato.Giorno}/{json[0].Nato.Mese}/{json[0].Nato.Anno}");
        Console.WriteLine(json[0].Indirizzo.Via + " " + json[0].Indirizzo.Civico + "\n" + json[0].Indirizzo.CAP + " " + json[0].Indirizzo.Citta);

        File.AppendAllText(pathcsv, "Nome,Cognome,Anno,Via,Citta\n");
        for (int i = 0;i<json.Count;i++)
        {
            File.AppendAllText(pathcsv, $"{json[i].Nome},{json[i].Cognome},{json[i].Nato.Anno},{json[i].Indirizzo.Via} {json[i].Indirizzo.Civico},{json[i].Indirizzo.Citta}\n");
        }
    }
}