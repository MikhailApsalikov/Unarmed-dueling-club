using System.Collections.Generic;
using System.Linq;
using DeejayEntertainment.UnarmedDuallingClub.GameCore.Entities;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Entities;

namespace DeejayEntertainment.UnarmedDuallingClub.GameCore
{
	public class MainMenu : IMainMenu
	{
		private List<MenuOptionEntity> options = new List<MenuOptionEntity>()
		{
			new MenuOptionEntity(0, "Play"),
			new MenuOptionEntity(1, "Settings"),
			new MenuOptionEntity(2, "Characters"),
			new MenuOptionEntity(3, "About"),
			new MenuOptionEntity(4, "Exit"),
		};
		private int selected;

		public IEnumerable<MenuOption> Options
		{
			get
			{
				return options.Select(opt => new MenuOption()
				{
					Id = opt.Id,
					Name = opt.Name,
					IsSelected = opt.Id == selected
				});
			}
		}

		public MainMenu()
		{
			selected = options.First().Id;
		}

		public void Down()
		{
			selected++;
			if (selected >= options.Count)
			{
				selected = 0;
			}
		}

		public void Up()
		{
			selected--;
			if (selected < 0)
			{
				selected = options.Count - 1;
			}
		}

	}
}
