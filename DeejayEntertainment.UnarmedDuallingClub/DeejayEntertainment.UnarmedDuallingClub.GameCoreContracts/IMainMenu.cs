using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Entities;
using System.Collections.Generic;

namespace DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts
{
	public interface IMainMenu
    {
		IEnumerable<MenuOption> Options { get; }
		int Select();
		void Down();
		void Up();
	}
}
