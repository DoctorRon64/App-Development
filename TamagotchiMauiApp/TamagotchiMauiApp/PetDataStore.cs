using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace TamagotchiMauiApp
{
    class PetDataStore : IDataStore<Creature>
    {
        public Task<Creature> ReadItem()
        {
            string currentString = Preferences.Get("MyPet", "");
            Creature item = JsonConvert.DeserializeObject<Creature>(currentString);
            return Task.FromResult(item);
        }

        public Task<bool> CreateItem(Creature item)
        {
            if (Preferences.ContainsKey("MyPet"))
            {
                return Task.FromResult(false);
            }
			string serializedItem = JsonConvert.SerializeObject(new Creature());
			Preferences.Set("MyPet", serializedItem);
            return Task.FromResult(Preferences.ContainsKey("MyPet"));
		}

        public Task<bool> DeleteItem(Creature item)
        {
            if (Preferences.ContainsKey("MyPet"))
            {
                Preferences.Remove("MyPet");
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> UpdateItem(Creature item)
        {
            if (Preferences.ContainsKey("MyPet"))
            {
                string serializedItem = JsonConvert.SerializeObject(item);
                Preferences.Set("MyPet", serializedItem);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
