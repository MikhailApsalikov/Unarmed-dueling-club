using System.Collections.Generic;
using System.Linq;
using DeejayEntertainment.UnarmedDuallingClub.GameCore.Entities;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Entities;
using DeejayEntertainment.UnarmedDuallingClub.Sound;

namespace DeejayEntertainment.UnarmedDuallingClub.GameCore
{
	public class MainMenu : IMainMenu
	{
		private readonly SoundManager soundManager;
		private List<MenuOptionEntity> options = new List<MenuOptionEntity>()
		{
			new MenuOptionEntity(0, "Play"),
			new MenuOptionEntity(1, "Settings"),
			new MenuOptionEntity(2, "Characters"),
			new MenuOptionEntity(3, "About"),
			new MenuOptionEntity(4, "Exit"),
		};

		public IEnumerable<MenuOption> Options
		{
			get
			{
				return options.Select(opt => new MenuOption()
				{
					Id = opt.Id,
					Name = opt.Name,
					IsSelected = opt.Id == Selection
				});
			}
		}

		private int Selection { get; set; }

		public MainMenu(SoundManager soundManager)
		{
			Selection = options.First().Id;
			this.soundManager = soundManager;
		}

		public void Down()
		{
			Selection++;
			if (Selection >= options.Count)
			{
				Selection = 0;
			}
			soundManager.PlaySound(Sounds.MainMenuChange);
		}

		public void Up()
		{
			Selection--;
			if (Selection < 0)
			{
				Selection = options.Count - 1;
			}
			soundManager.PlaySound(Sounds.MainMenuChange);
		}

		public int Select()
		{
			soundManager.PlaySound(Sounds.MainMenuSelect);
			return Selection;
		}

	}
}
