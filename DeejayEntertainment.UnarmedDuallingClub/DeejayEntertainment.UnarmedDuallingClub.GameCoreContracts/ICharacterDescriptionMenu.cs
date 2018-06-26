using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Interfaces;
using System.Collections.Generic;

namespace DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts
{
	public interface ICharacterDescriptionMenu
	{
		ICharacterState CurrentCharacter { get; }
		void Next();
		void Previous();
	}
}
