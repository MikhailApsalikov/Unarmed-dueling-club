using DeejayEntertainment.UnarmedDuallingClub.Assets;
using DeejayEntertainment.UnarmedDuallingClub.Configuration;
using DeejayEntertainment.UnarmedDuallingClub.GameCore.Entities;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Interfaces;
using DeejayEntertainment.UnarmedDuallingClub.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
		private GameBalanceConstants gameBalanceConstants = GameBalanceConfigurationManager.Configuration;

		public CharacterDescriptionMenu(AssetManager assetManager, SoundManager soundManager)
		{
			this.soundManager = soundManager;
			InitCharacterList(assetManager);
		}

		private void InitCharacterList(AssetManager assetManager)
		{
			characters = new List<ICharacterState>();
			characters.Add(new CharacterState(assetManager, "Fury")
			{
				CharacterDescription = Resources.CharacterDescriptions.Fury,
				StatsDescription = CompileStats("Fury", Resources.StatsDescriptions.Dmitry, Resources.StatsDescriptions.Stamina),
				AbilitiesDescription = CompileFuryAbilities()
			});

			characters.Add(new CharacterState(assetManager, "FrostMage")
			{
				CharacterDescription = "sadasdsadasd1"
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

		private string CompileStats(string name, string model, string mainStat)
		{
			return string.Format(Resources.StatsDescriptions.Template,
				model,
				mainStat,
				gameBalanceConstants.GetCharacterByName(name).MaxHp,
				gameBalanceConstants.GetCharacterByName(name).Armor,
				gameBalanceConstants.GetCharacterByName(name).CritChance);
		}

		private string CompileFuryAbilities()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Resources.AbilitiesDescription.AbilitiesTitle);
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 1, gameBalanceConstants.GetAbilityByName("PowerfulFury").DisplayName, string.Format(Resources.AbilitiesDescription.PowerfulFury, gameBalanceConstants.PowerfulFuryBaseDamage), gameBalanceConstants.GetAbilityByName("PowerfulFury").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 2, gameBalanceConstants.GetAbilityByName("StunFury").DisplayName, string.Format(Resources.AbilitiesDescription.StunFury, gameBalanceConstants.FuryStunDuration / 10.0, gameBalanceConstants.FuryStunBaseDamage), gameBalanceConstants.GetAbilityByName("StunFury").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 3, gameBalanceConstants.GetAbilityByName("Bubble").DisplayName, string.Format(Resources.AbilitiesDescription.Bubble, gameBalanceConstants.BubbleDuration / 10.0), gameBalanceConstants.GetAbilityByName("Bubble").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.BlockBan, gameBalanceConstants.BlockBanDuration / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.RageAura);
			return sb.ToString();
		}
	}
}
