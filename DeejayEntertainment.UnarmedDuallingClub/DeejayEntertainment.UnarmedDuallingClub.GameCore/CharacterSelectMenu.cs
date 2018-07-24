using System.Collections.Generic;
using DeejayEntertainment.UnarmedDuallingClub.Assets;
using DeejayEntertainment.UnarmedDuallingClub.Common.Enums;
using DeejayEntertainment.UnarmedDuallingClub.Configuration;
using DeejayEntertainment.UnarmedDuallingClub.GameCore.Entities;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Interfaces;
using DeejayEntertainment.UnarmedDuallingClub.Sound;

namespace DeejayEntertainment.UnarmedDuallingClub.GameCore
{
	public class CharacterSelectMenu : ICharacterSelectMenu
	{
		private readonly SoundManager soundManager;
		private GameBalanceConstants gameBalanceConstants = ConfigurationManager.GameBalanceConfiguration;
		public List<ICharacterState> Characters { get; private set; }

		public int Selection { get; private set; }

		public CharacterSelectMenu(AssetManager assetManager, SoundManager soundManager, bool isSecond = false)
		{
			this.soundManager = soundManager;
			InitCharacterList(assetManager, isSecond);
			if (isSecond)
			{
				Selection = Characters.Count - 1;
			}
		}

		private void InitCharacterList(AssetManager assetManager, bool isSecond)
		{
			Characters = new List<ICharacterState>
			{
				new CharacterState(assetManager, "Tank", isSecond),
				new CharacterState(assetManager, "Fury", isSecond),
				new CharacterState(assetManager, "Healer", isSecond),
				new CharacterState(assetManager, "Stealther", isSecond),
				new CharacterState(assetManager, "Burster", isSecond),
				new CharacterState(assetManager, "Combinator", isSecond),
				new CharacterState(assetManager, "FrostMage", isSecond),
				new CharacterState(assetManager, "FireMage", isSecond),
				new CharacterState(assetManager, "Warlock", isSecond)
			};
		}

		public ICharacterState CurrentCharacter => Characters[Selection];
		public void Next()
		{
			if (Selected)
			{
				return;
			}

			Selection++;
			if (Selection >= Characters.Count)
			{
				Selection = 0;
			}
			soundManager.PlaySound(Sounds.MainMenuChange);
		}

		public void Previous()
		{
			if (Selected)
			{
				return;
			}

			Selection--;
			if (Selection < 0)
			{
				Selection = Characters.Count - 1;
			}
			soundManager.PlaySound(Sounds.MainMenuChange);
		}

		public void Select()
		{
			Selected = true;
			(CurrentCharacter as CharacterState).Pose = Pose.Win;
		}

		public bool Selected { get; private set; }
	}
}
