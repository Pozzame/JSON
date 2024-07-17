using Newtonsoft.Json;
internal class Program
{
    private static void Main(string[] args)
    {
        string pathjson = @"test.json";
        string pathcsv = @"test.csv";
        dynamic json = JsonConvert.DeserializeObject(File.ReadAllText(pathjson))!;

        File.Delete(pathcsv);
        File.AppendAllText(pathcsv, "Nome,Cognome,Anno,Via,Citta\n");
        for (int i = 0; i < json.Count; i++)
        {
            Console.WriteLine($"-----{json[i].Nome} {json[i].Cognome}-----\nNato il {json[i].Nato.Giorno}/{json[i].Nato.Mese}/{json[i].Nato.Anno}");
            Console.WriteLine($"{json[i].Indirizzo.Via} {json[i].Indirizzo.Civico}\n{json[i].Indirizzo.CAP} {json[i].Indirizzo.Citta}");
            File.AppendAllText(pathcsv, $"{json[i].Nome},{json[i].Cognome},{json[i].Nato.Anno},{json[i].Indirizzo.Via} {json[i].Indirizzo.Civico},{json[i].Indirizzo.Citta}\n");
        }
    }
}