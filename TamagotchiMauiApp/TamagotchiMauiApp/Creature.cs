using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiMauiApp
{
    public class Creature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
		public float Hunger { get; set; }
        public float Thirst { get; set; }
        public float Tired { get; set; }
        public float Boredom { get; set; }
        public float Loneliness { get; set; }
        public float Stimulated { get; set; }

		public void LowerStats(float _Amount)
		{
			Hunger = Hunger - _Amount;
			Thirst = Thirst - _Amount;
			Tired = Tired - _Amount;
			Boredom = Boredom - _Amount;
			Loneliness = Loneliness - _Amount;
			Stimulated = Stimulated - _Amount;
		}
    }
}
