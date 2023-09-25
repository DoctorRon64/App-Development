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
            try
            {
                string serializedItem = JsonConvert.SerializeObject(item);
                Preferences.Set("MyPet", serializedItem);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating pet: {ex.Message}");
                return false;
            }
        }

        public bool DeleteItem(CreaturePet item)
        {
            try
            {
                Preferences.Remove("MyPet");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting pet: {ex.Message}");
                return false;
            }
        }

        public bool UpdateItem(CreaturePet item)
        {
            try
            {
                string serializedItem = JsonConvert.SerializeObject(item);
                Preferences.Set("MyPet", serializedItem);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating pet: {ex.Message}");
                return false;
            }
        }
    }
}
