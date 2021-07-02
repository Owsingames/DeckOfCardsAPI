using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeckofCardsAPI.Models
{
    public class DeckOfCardsDAL
    {
        public Deck GetDeckAPI()
        {
            string url = $@"https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";

            //this makes a request to the API using the URL
            HttpWebRequest request = WebRequest.CreateHttp(url);
            //this line sends that request to the API server
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //this line will grab the file out of the response
            StreamReader rd = new StreamReader(response.GetResponseStream());

            //make the JSON file into a string by reading the response
            string JSON = rd.ReadToEnd();

            return JsonConvert.DeserializeObject<Deck>(JSON);
        }

        public Hand GetHand(string id)
        {
            string url = $@"https://deckofcardsapi.com/api/deck/{id}/draw/?count=5";

            //this makes a request to the API using the URL
            HttpWebRequest request = WebRequest.CreateHttp(url);
            //this line sends that request to the API server
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //this line will grab the file out of the response
            StreamReader rd = new StreamReader(response.GetResponseStream());

            //make the JSON file into a string by reading the response
            string JSON = rd.ReadToEnd();

            return JsonConvert.DeserializeObject<Hand>(JSON);
        }
    }
}
