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
		public ICharacterState CurrentCharacter => characters[Selection];

		private List<ICharacterState> characters;
		private int Selection { get; set; }
		private SoundManager soundManager;
		private GameBalanceConstants gameBalanceConstants = ConfigurationManager.GameBalanceConfiguration;

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
			characters.Add(new CharacterState(assetManager, "Stealther")
			{
				CharacterDescription = Resources.CharacterDescriptions.Stealther,
				StatsDescription = CompileStats("Stealther", Resources.StatsDescriptions.Sergey, Resources.StatsDescriptions.Agility),
				AbilitiesDescription = CompileStealtherAbilities()
			});
			characters.Add(new CharacterState(assetManager, "Burster")
			{
				CharacterDescription = Resources.CharacterDescriptions.Burster,
				StatsDescription = CompileStats("Burster", Resources.StatsDescriptions.Sergey, Resources.StatsDescriptions.Agility),
				AbilitiesDescription = CompileBursterAbilities()
			});
			characters.Add(new CharacterState(assetManager, "Combinator")
			{
				CharacterDescription = Resources.CharacterDescriptions.Combinator,
				StatsDescription = CompileStats("Combinator", Resources.StatsDescriptions.Mikhail, Resources.StatsDescriptions.Agility),
				AbilitiesDescription = CompileCombinatorAbilities()
			});
			characters.Add(new CharacterState(assetManager, "FrostMage")
			{
				CharacterDescription = Resources.CharacterDescriptions.FrostMage,
				StatsDescription = CompileStats("FrostMage", Resources.StatsDescriptions.Dan, Resources.StatsDescriptions.Intellegence),
				AbilitiesDescription = CompileFrostMageAbilities()
			});
			characters.Add(new CharacterState(assetManager, "FireMage")
			{
				CharacterDescription = Resources.CharacterDescriptions.FireMage,
				StatsDescription = CompileStats("FireMage", Resources.StatsDescriptions.Dan, Resources.StatsDescriptions.Intellegence),
				AbilitiesDescription = CompileFireMageAbilities()
			});
			characters.Add(new CharacterState(assetManager, "Warlock")
			{
				CharacterDescription = Resources.CharacterDescriptions.Warlock,
				StatsDescription = CompileStats("Warlock", Resources.StatsDescriptions.Dan, Resources.StatsDescriptions.Intellegence),
				AbilitiesDescription = CompileWarlockAbilities()
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

		private string CompileStealtherAbilities()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Resources.AbilitiesDescription.AbilitiesTitle);
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 1, gameBalanceConstants.GetAbilityByName("Stealth").DisplayName, string.Format(Resources.AbilitiesDescription.Stealth), gameBalanceConstants.GetAbilityByName("Stealth").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 2, gameBalanceConstants.GetAbilityByName("Bleed").DisplayName, string.Format(Resources.AbilitiesDescription.Bleed, gameBalanceConstants.BaseBleedStunDuration / 10.0, gameBalanceConstants.BaseBleedDamage, gameBalanceConstants.BleedPeriod / 10.0, gameBalanceConstants.BleedDuration / 10.0), gameBalanceConstants.GetAbilityByName("Bleed").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 3, gameBalanceConstants.GetAbilityByName("Blind").DisplayName, string.Format(Resources.AbilitiesDescription.Blind, gameBalanceConstants.BaseBlindDuration / 10.0), gameBalanceConstants.GetAbilityByName("Blind").Cooldown / 10.0);
			return sb.ToString();
		}

		private string CompileBursterAbilities()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Resources.AbilitiesDescription.AbilitiesTitle);
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 1, gameBalanceConstants.GetAbilityByName("DeathGrip").DisplayName, string.Format(Resources.AbilitiesDescription.DeathGrip), gameBalanceConstants.GetAbilityByName("DeathGrip").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 2, gameBalanceConstants.GetAbilityByName("Enrage").DisplayName, string.Format(Resources.AbilitiesDescription.Enrage, gameBalanceConstants.BaseEnrageDamageIncrease, gameBalanceConstants.BaseEnrageDuration / 10.0), gameBalanceConstants.GetAbilityByName("Enrage").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 3, gameBalanceConstants.GetAbilityByName("Storm").DisplayName, string.Format(Resources.AbilitiesDescription.Storm, gameBalanceConstants.BaseStormDamage, gameBalanceConstants.BaseStormInterval / 10.0, gameBalanceConstants.BaseStormDuration / 10.0), gameBalanceConstants.GetAbilityByName("Storm").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.ReduceCdBurster, gameBalanceConstants.BursterCooldownReduction / 10.0);
			return sb.ToString();
		}

		private string CompileCombinatorAbilities()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Resources.AbilitiesDescription.AbilitiesTitle);
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 1, gameBalanceConstants.GetAbilityByName("Stone").DisplayName, string.Format(Resources.AbilitiesDescription.Stone, gameBalanceConstants.BaseStoneDamage, gameBalanceConstants.BaseStoneDuration / 10.0), gameBalanceConstants.GetAbilityByName("Stone").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 2, gameBalanceConstants.GetAbilityByName("BloodLast").DisplayName, string.Format(Resources.AbilitiesDescription.BloodLast, gameBalanceConstants.BaseBloodlustDamageIncrease, gameBalanceConstants.BaseBloodlustDuration / 10.0), gameBalanceConstants.GetAbilityByName("BloodLast").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 3, gameBalanceConstants.GetAbilityByName("EnergyBolt").DisplayName, string.Format(Resources.AbilitiesDescription.EnergyBolt, gameBalanceConstants.EnergyBoltDamage, gameBalanceConstants.BigDamageMissileModifier, gameBalanceConstants.BaseStormDuration / 10.0), gameBalanceConstants.GetAbilityByName("EnergyBolt").Cooldown / 10.0);
			return sb.ToString();
		}

		private string CompileFrostMageAbilities()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Resources.AbilitiesDescription.AbilitiesTitle);
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 1, gameBalanceConstants.GetAbilityByName("Freeze").DisplayName, string.Format(Resources.AbilitiesDescription.Freeze, gameBalanceConstants.FreezeDuration / 10.0), gameBalanceConstants.GetAbilityByName("Freeze").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 2, gameBalanceConstants.GetAbilityByName("FrostBolt").DisplayName, string.Format(Resources.AbilitiesDescription.FrostBolt, gameBalanceConstants.FrostBoltDamage, gameBalanceConstants.BigDamageMissileModifier), gameBalanceConstants.GetAbilityByName("FrostBolt").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 3, gameBalanceConstants.GetAbilityByName("IceShield").DisplayName, string.Format(Resources.AbilitiesDescription.IceShield, gameBalanceConstants.IceShieldAbsorbDamage, gameBalanceConstants.FreezeDuration / 10.0, gameBalanceConstants.IceShieldTime / 10.0), gameBalanceConstants.GetAbilityByName("IceShield").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.FrostEnrage, gameBalanceConstants.FrostEnrageDamageIncrease, gameBalanceConstants.FrostEnrageDuration / 10.0);
			return sb.ToString();
		}

		private string CompileFireMageAbilities()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Resources.AbilitiesDescription.AbilitiesTitle);
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 1, gameBalanceConstants.GetAbilityByName("FireShock").DisplayName, string.Format(Resources.AbilitiesDescription.FireShock), gameBalanceConstants.GetAbilityByName("FireShock").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 2, gameBalanceConstants.GetAbilityByName("Fireball").DisplayName, string.Format(Resources.AbilitiesDescription.Fireball, gameBalanceConstants.FileballStackDamage * 10), gameBalanceConstants.GetAbilityByName("Fireball").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 3, gameBalanceConstants.GetAbilityByName("Armageddon").DisplayName, string.Format(Resources.AbilitiesDescription.Armageddon, gameBalanceConstants.ArmageddonMaxDamage), gameBalanceConstants.GetAbilityByName("Armageddon").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.FireShield, gameBalanceConstants.FireShieldAbsorbDamage);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.FireBlood, gameBalanceConstants.ChanceToScorchByAttack * 100);
			return sb.ToString();
		}

		private string CompileWarlockAbilities()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Resources.AbilitiesDescription.AbilitiesTitle);
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 1, gameBalanceConstants.GetAbilityByName("ShadowFreeze").DisplayName, string.Format(Resources.AbilitiesDescription.ShadowFreeze, gameBalanceConstants.ShadowFreezeDuration / 10.0), gameBalanceConstants.GetAbilityByName("ShadowFreeze").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 2, gameBalanceConstants.GetAbilityByName("CurseLow").DisplayName, string.Format(Resources.AbilitiesDescription.CurseLow, gameBalanceConstants.BaseCurseLowDamage, gameBalanceConstants.BaseCurseLowHeal), gameBalanceConstants.GetAbilityByName("CurseLow").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.Template, 3, gameBalanceConstants.GetAbilityByName("CurseHigh").DisplayName, string.Format(Resources.AbilitiesDescription.CurseHigh, gameBalanceConstants.CurseHighDamage, gameBalanceConstants.CurseHighDuration / 10.0), gameBalanceConstants.GetAbilityByName("CurseHigh").Cooldown / 10.0);
			sb.AppendLine();
			sb.AppendFormat(Resources.AbilitiesDescription.BlindShadow, gameBalanceConstants.ShadowBlindDuration / 10.0);
			return sb.ToString();
		}
	}
}
