using System.Collections.Generic;
using AssetImage = System.Drawing.Image;

namespace DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Interfaces
{
	public interface ICharacterState
	{
		AssetImage Image { get; }
		List<string> Documentation { get; }
		string PlayerName { get; }
	}
}
