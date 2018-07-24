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
			characters.Add(new CharacterState(assetManager, "Tank")
			{
				CharacterDescription = Resources.CharacterDescriptions.Tank,
				StatsDescription = CompileStats("Tank", Resources.StatsDescriptions.Dmitry, Resources.StatsDescriptions.Stamina),
				AbilitiesDescription = CompileTankAbilities()
			});
			characters.Add(new CharacterState(assetManager, "Fury")
			{
				CharacterDescription = Resources.CharacterDescriptions.Fury,
				StatsDescription = CompileStats("Fury", Resources.StatsDescriptions.Dmitry, Resources.StatsDescriptions.Stamina),
				AbilitiesDescription = CompileFuryAbilities()
			});
			characters.Add(new CharacterState(assetManager, "Healer")
			{
				CharacterDescription = Resources.CharacterDescriptions.Healer,
				StatsDescription = CompileStats("Healer", Resources.StatsDescriptions.Mikhail, Resources.StatsDescriptions.Stamina),
				AbilitiesDescription = CompileHealerAbilities()
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

		private string CompileTankAbilities()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Resources.AbilitiesDescription.AbilitiesTitle);
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 1, gameBalanceConstants.GetAbilityByName("TankStrike").DisplayName, string.Format(Resources.AbilitiesDescription.TankStrike, gameBalanceConstants.TankStrikeBaseDamage), gameBalanceConstants.GetAbilityByName("TankStrike").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 2, gameBalanceConstants.GetAbilityByName("EarthStrike").DisplayName, string.Format(Resources.AbilitiesDescription.EarthStrike, gameBalanceConstants.EarthStrikeBaseDamage, gameBalanceConstants.EarthStrikeStunDuration / 10.0, gameBalanceConstants.EarthStrikeSilenceDuration / 10.0), gameBalanceConstants.GetAbilityByName("EarthStrike").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 3, gameBalanceConstants.GetAbilityByName("Reflection").DisplayName, string.Format(Resources.AbilitiesDescription.Reflection, gameBalanceConstants.ReflectBaseDuration / 10.0), gameBalanceConstants.GetAbilityByName("Reflection").Cooldown / 10.0);
			return sb.ToString();
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

		private string CompileHealerAbilities()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Resources.AbilitiesDescription.AbilitiesTitle);
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 1, gameBalanceConstants.GetAbilityByName("Heal").DisplayName, string.Format(Resources.AbilitiesDescription.Heal, gameBalanceConstants.HealMinimum, gameBalanceConstants.HealMaximum), gameBalanceConstants.GetAbilityByName("Heal").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 2, gameBalanceConstants.GetAbilityByName("Cyclone").DisplayName, string.Format(Resources.AbilitiesDescription.Cyclone, gameBalanceConstants.CycloneDuration / 10.0), gameBalanceConstants.GetAbilityByName("Cyclone").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 3, gameBalanceConstants.GetAbilityByName("ShadowForm").DisplayName, string.Format(Resources.AbilitiesDescription.ShadowForm, Math.Round((gameBalanceConstants.ShadowFormOutcomingDamageCoefficient - 1) * 100), Math.Round((1 - gameBalanceConstants.ShadowFormIncomingDamageCoefficient) * 100)), gameBalanceConstants.GetAbilityByName("ShadowForm").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Smite, gameBalanceConstants.SmiteDamageCoefficient * 100);
			return sb.ToString();
		}
	}
}
