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

		bool IDataStore<CreaturePet>.CreateItem(CreaturePet item)
		{
			throw new NotImplementedException();
		}

		bool IDataStore<CreaturePet>.DeleteItem(CreaturePet item)
		{
			throw new NotImplementedException();
		}

		bool IDataStore<CreaturePet>.UpdateItem(CreaturePet item)
		{
			throw new NotImplementedException();
		}
	}
}
