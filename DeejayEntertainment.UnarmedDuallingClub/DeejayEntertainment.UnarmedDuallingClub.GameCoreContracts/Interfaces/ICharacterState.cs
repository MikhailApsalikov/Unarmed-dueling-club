using System.Collections.Generic;
using AssetImage = System.Drawing.Image;

namespace DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Interfaces
{
	public interface ICharacterState
	{
		AssetImage Image { get; }
		AssetImage Icon { get; }
		string CharacterDescription { get; }
		string StatsDescription { get; }
		string AbilitiesDescription { get; }
		string PlayerName { get; }
	}
}
