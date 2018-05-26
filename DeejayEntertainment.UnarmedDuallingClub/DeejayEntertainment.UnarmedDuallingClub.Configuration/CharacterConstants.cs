using System;

namespace DeejayEntertainment.UnarmedDuallingClub.Configuration
{
	[Serializable]
	public class CharacterConstants
	{
		public int MaxHp { get; set; }
		public int Armor { get; set; }
		public int CritChance { get; set; }
		public string Name { get; set; }
		public int Id { get; set; }
		public int ChargeCooldown { get; set; }
	}
}
