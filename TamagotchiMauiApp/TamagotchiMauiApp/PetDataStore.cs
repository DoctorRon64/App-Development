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
        public Creature ReadItem()
        {
            string currentString = Preferences.Get("MyPet", "");
            Creature item = JsonConvert.DeserializeObject<Creature>(currentString);
            return item;
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

        public bool DeleteItem(Creature item)
        {
            if (Preferences.ContainsKey("MyPet"))
            {
                Preferences.Remove("MyPet");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateItem(Creature item)
        {
            if (Preferences.ContainsKey("MyPet"))
            {
                string serializedItem = JsonConvert.SerializeObject(item);
                Preferences.Set("MyPet", serializedItem);
                return true;
            } else
            {
                return false;
            }
        }
    }
}
