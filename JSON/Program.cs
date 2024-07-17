using Newtonsoft.Json;
internal class Program
{
    private static void Main(string[] args)
    {
        string pathjson = @"test1.json";/*
        string pathcsv = @"test.csv";
        dynamic json = JsonConvert.DeserializeObject(File.ReadAllText(pathjson))!;

        File.Delete(pathcsv);
        File.AppendAllText(pathcsv, "Nome,Cognome,Anno,Via,Citta\n");
        for (int i = 0; i < json.Count; i++)
        {
            Console.WriteLine($"-----{json[i].Nome} {json[i].Cognome}-----\nNato il {json[i].Nato.Giorno}/{json[i].Nato.Mese}/{json[i].Nato.Anno}");
            Console.WriteLine($"{json[i].Indirizzo.Via} {json[i].Indirizzo.Civico}\n{json[i].Indirizzo.CAP} {json[i].Indirizzo.Citta}");
            File.AppendAllText(pathcsv, $"{json[i].Nome},{json[i].Cognome},{json[i].Nato.Anno},{json[i].Indirizzo.Via} {json[i].Indirizzo.Civico},{json[i].Indirizzo.Citta}\n");
        }*/
        File.Delete(pathjson);
        File.AppendAllText(pathjson, "[\n");

        while (true)
        {
            string nome = Console.ReadLine()!;
            string prezzo = Console.ReadLine()!;
            if (nome == "" || prezzo == "") break;
            File.AppendAllText(pathjson, JsonConvert.SerializeObject(new { nome, prezzo }) + ",\n");
        }
        string file = File.ReadAllText(pathjson);
        //file = file.Remove(file.Length - 2, 1);
        File.WriteAllText(pathjson, file.Remove(file.Length - 2, 1));
        File.AppendAllText(pathjson, "]");
    }
}