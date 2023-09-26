using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace TamagotchiMauiApp
{
    class PetDataStore : IDataStore<CreaturePet>
    {
        public CreaturePet ReadItem()
        {
            string currentString = Preferences.Get("MyPet", "");
            CreaturePet item = JsonConvert.DeserializeObject<CreaturePet>(currentString);
            return item;
        }

        public bool CreateItem(CreaturePet item)
        {
            if (Preferences.ContainsKey("MyPet"))
            {
                return false;
            }
            else
            {
                string serializedItem = JsonConvert.SerializeObject(new CreaturePet());
                Preferences.Set("MyPet", serializedItem);
                return true;
            }
        }

        public bool DeleteItem(CreaturePet item)
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

        public bool UpdateItem(CreaturePet item)
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
