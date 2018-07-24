using System.Collections.Generic;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Interfaces;

namespace DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts
{
	public interface ICharacterSelectMenu
	{
		ICharacterState CurrentCharacter { get; }
		List<ICharacterState> Characters { get; }
		void Next();
		void Previous();
		void Select();
		bool Selected { get; }
		int Selection { get; }
	}
}
