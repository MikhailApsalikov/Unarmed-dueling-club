using DeejayEntertainment.UnarmedDuallingClub.Assets;
using DeejayEntertainment.UnarmedDuallingClub.GameCore.Entities;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Interfaces;
using DeejayEntertainment.UnarmedDuallingClub.Sound;
using System.Collections.Generic;

namespace DeejayEntertainment.UnarmedDuallingClub.GameCore
{
	public class CharacterDescriptionMenu : ICharacterDescriptionMenu
	{
		public ICharacterState CurrentCharacter
		{
			get
			{
				return characters[Selection];
			}
		}

		private List<ICharacterState> characters;
		private int Selection { get; set; }
		private SoundManager soundManager;

		public CharacterDescriptionMenu(AssetManager assetManager, SoundManager soundManager)
		{
			this.soundManager = soundManager;
			InitCharacterList(assetManager);
		}

		private void InitCharacterList(AssetManager assetManager)
		{
			characters = new List<ICharacterState>();
			characters.Add(new CharacterState(assetManager, "Tank")
			{
				Documentation = new List<string>()
				{
					"sadasdsadasd",
					"dsadasdasdasd"
				}
			});

			characters.Add(new CharacterState(assetManager, "FrostMage")
			{
				Documentation = new List<string>()
				{
					"sadasdsadasd1",
					"dsadasdasdasd2"
				}
			});
		}

		public void Next()
		{
			Selection++;
			if (Selection >= characters.Count)
			{
				Selection = 0;
			}
			soundManager.PlaySound(Sounds.MainMenuChange);
		}

		public void Previous()
		{
			Selection--;
			if (Selection < 0)
			{
				Selection = characters.Count - 1;
			}
			soundManager.PlaySound(Sounds.MainMenuChange);
		}
	}
}
