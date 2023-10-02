using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiMauiApp
{
    internal class RemoteDataStore : IDataStore<Creature>
    {
        private HttpClient httpClient = new HttpClient();
        public async Task<bool> CreateItem(Creature item)
        {
            string creatureString = JsonConvert.SerializeObject(item);
            var response = await httpClient.PostAsync("https://tamagotchi.hku.nl/api/Creatures", new StringContent(creatureString, System.Text.Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                Creature responseCreature = JsonConvert.DeserializeObject<Creature>(responseString);

                Preferences.Set("CreatureId", responseCreature.Id);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteItem(Creature item)
        {
            if (item == null)
            {
                return false;
            }

            var response = await httpClient.DeleteAsync($"https://tamagotchi.hku.nl/api/Creatures/{item.Id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<Creature> ReadItem()
        {
            var creatureId = Preferences.Get("CreatureId", default(int));

            if (creatureId != default(int))
            {
                var response = await httpClient.GetAsync($"https://tamagotchi.hku.nl/api/Creatures/{creatureId}");

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    Creature responseCreature = JsonConvert.DeserializeObject<Creature>(responseString);
                    return responseCreature;
                }
            } else { return null; }
            return null;
        }

        public async Task<bool> UpdateItem(Creature item)
        {
            string creatureString = JsonConvert.SerializeObject(item);
            var response = await httpClient.PutAsync($"https://tamagotchi.hku.nl/api/Creatures/{item.Id}", new StringContent(creatureString, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }
    }
}