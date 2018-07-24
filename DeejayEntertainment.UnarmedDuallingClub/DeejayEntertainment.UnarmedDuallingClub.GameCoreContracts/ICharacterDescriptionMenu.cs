using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Interfaces;

namespace DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts
{
	public interface ICharacterDescriptionMenu
	{
		ICharacterState CurrentCharacter { get; }
		void Next();
		void Previous();
	}
}
