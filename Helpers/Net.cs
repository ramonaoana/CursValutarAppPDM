using CursValutarApp.Models;
using System.Net.Http.Json;
using System.Xml;
using System.Xml.Serialization;

namespace CursValutarApp.Helpers
{
    public class Net
    {
        static string URL_BNR = "https://bnr.ro/nbrfxrates.xml";
        static string URL_CRYPTO = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=eur&ids=bitcoin%2Cethereum%2Cdogecoin%2Ctether";
        static Cube GetCursBNR()
        {
            Cube cube;
            XmlSerializer serializer=new XmlSerializer(typeof(Cube));
            using (XmlReader reader = XmlReader.Create(URL_BNR))
            {
                
                reader.ReadToDescendant("Cube");
                cube = serializer.Deserialize(reader) as Cube;
            }
            return cube;
        }

        static async Task<List<Curs>> GetCrypto()
        {
            List<Curs> listaCurs;


            using (HttpClient client = new HttpClient())
            {
                listaCurs = await client.GetFromJsonAsync<List<Curs>>(URL_CRYPTO);
            }
                

            return listaCurs;
        }

        public static async Task<List<Curs>> GetAllRates()
        {
            List<Curs> listaCurs = new List<Curs>();
            Cube cube=GetCursBNR(); 

            foreach(Curs curs in cube.ListaCurs)
            {
                curs.Date = cube.date;
                curs.IsCrypto = false;
            }
            listaCurs.AddRange(cube.ListaCurs);

            //TODO: DE CONVERTIT VALOAREA LA RON DIN EURO
            listaCurs.AddRange(await GetCrypto());


            return listaCurs;
        }
    }
}
