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

		public bool DeleteItem(Creature item)
		{
			throw new NotImplementedException();
		}

		public Creature ReadItem()
		{
			throw new NotImplementedException();
		}

		public bool UpdateItem(Creature item)
		{
			throw new NotImplementedException();
		}
	}
}
