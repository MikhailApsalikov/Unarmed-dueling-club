﻿using System;

namespace DeejayEntertainment.UnarmedDuallingClub.Configuration
{
	[Serializable]
	public class AbilityConstants
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string DisplayName { get; set; }
		public int Cooldown { get; set; }
	}
}
