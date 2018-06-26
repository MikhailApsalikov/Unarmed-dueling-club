using System;
using System.Collections.Generic;
using System.Linq;

namespace DeejayEntertainment.UnarmedDuallingClub.Configuration
{
	[Serializable]
	public class GameBalanceConstants
	{
		public List<CharacterConstants> CharacterConstantses { get; set; } = new List<CharacterConstants>();

		public List<AbilityConstants> AbilityConstantses { get; set; } = new List<AbilityConstants>();

		public CharacterConstants GetCharacterByName(string name)
		{
			return CharacterConstantses.First(c => c.Name == name);
		}

		public AbilityConstants GetAbilityByName(string name)
		{
			return AbilityConstantses.First(c => c.Name == name);
		}

		/// <summary>
		/// на сколько снижает физический урон 1 единица брони
		/// </summary>
		public Double ArmorReduction { get; set; }

		/// <summary>
		/// базовый урон нижнего удара рукой
		/// </summary>
		public int LowHandBaseDamage { get; set; }

		/// <summary>
		/// базовый урон верхнего удара рукой
		/// </summary>
		public int HighHandBaseDamage { get; set; }

		/// <summary>
		/// базовый урон нижнего удара ногой
		/// </summary>
		public int LowKickBaseDamage { get; set; }

		/// <summary>
		/// базовый урон верхнего удара ногой
		/// </summary>
		public int HighKickBaseDamage { get; set; }

		/// <summary>
		/// базовый уронбазовый урон апперкота
		/// </summary>
		public int UppercutBaseDamage { get; set; }

		/// <summary>
		/// базовый урон удара с разворота
		/// </summary>
		public int PowerKickBaseDamage { get; set; }

		/// <summary>
		///  максимальная дистанция рывка
		/// </summary>
		public int ChargeMaxDistance { get; set; }

		/// <summary>
		/// Скорость рывка
		/// </summary>
		public int ChargeSpeed { get; set; }

		/// <summary>
		/// Скорость ходьбы
		/// </summary>
		public int MoveSpeed { get; set; }

		/// <summary>
		/// задержка после удара
		/// </summary>
		public int LatencyAfterHit { get; set; }

		/// <summary>
		/// задержка после промаха
		/// </summary>
		public int LatencyAfterMiss { get; set; }

		/// <summary>
		/// базовый урон Удара Танка
		/// </summary>
		public int TankStrikeBaseDamage { get; set; }

		/// <summary>
		/// базовый урон Удара по земле
		/// </summary>
		public int EarthStrikeBaseDamage { get; set; }

		/// <summary>
		/// базовая длительность оглушения после Удара по земле
		/// </summary>
		public int EarthStrikeStunDuration { get; set; }

		/// <summary>
		/// базовая длительность сайленса после Удара по земле
		/// </summary>
		public int EarthStrikeSilenceDuration { get; set; }

		/// <summary>
		/// базовая длительность оглушения после рывка Танка
		/// </summary>
		public int TankChargeStunDuration { get; set; }

		/// <summary>
		/// базовая длительность отражения
		/// </summary>
		public int ReflectBaseDuration { get; set; }

		/// <summary>
		/// базовый урон мощного удара Fury
		/// </summary>
		public int PowerfulFuryBaseDamage { get; set; }

		/// <summary>
		/// базовое время Оглушения Fury
		/// </summary>
		public int FuryStunDuration { get; set; }

		/// <summary>
		/// базовый урон способности Оглушение Fury
		/// </summary>
		public int FuryStunBaseDamage { get; set; }

		/// <summary>
		/// время Неуязвимости
		/// </summary>
		public int BubbleDuration { get; set; }

		/// <summary>
		/// время снятия блока
		/// </summary>
		public int BlockBanDuration { get; set; }

		/// <summary>
		/// базовое лечение
		/// </summary>
		public int BaseHeal { get; set; }

		/// <summary>
		/// дополнительное (максимум) лечение
		/// </summary>
		public int AdditionalHear { get; set; }

		/// <summary>
		/// время циклона
		/// </summary>
		public int CycloneDuration { get; set; }

		/// <summary>
		/// урон от подката
		/// </summary>
		public int ChargeHealerDamage { get; set; }

		/// <summary>
		/// снижение урона от шадоуформы до...
		/// </summary>
		public double ShadowFormDamageCoefficient { get; set; }

		/// <summary>
		/// урон внезапного удара
		/// </summary>
		public int BaseAmblushDamage { get; set; }

		/// <summary>
		///  базовая длительность контроля от Ошеломления
		/// </summary>
		public int BaseSapDuration { get; set; }

		/// <summary>
		///  базовый урон за тик Ошеломления
		/// </summary>
		public int BaseBleedDamage { get; set; }

		/// <summary>
		///  базовое время ослепления
		/// </summary>
		public int BaseBlindDuration { get; set; }

		/// <summary>
		///  время уменьшения кулдаунов удачным рывком для Бурстера
		/// </summary>
		public int BursterCooldownReduction { get; set; }

		/// <summary>
		///  время Ярости Бурстера
		/// </summary>
		public int BaseEnrageDuration { get; set; }

		/// <summary>
		///  процентное увеличение урона во время Ярости Бурстера
		/// </summary>
		public int BaseEnrageDamageIncrease { get; set; }

		/// <summary>
		/// время Вихря
		/// </summary>
		public int BaseStormDuration { get; set; }

		/// <summary>
		///  урон от 1 тика вихря
		/// </summary>
		public int BaseStormDamage { get; set; }

		/// <summary>
		/// шанс при каждом ударе вылететь из вихря
		/// </summary>
		public double StormInterruptChance { get; set; }

		/// <summary>
		/// время оглушения от камня
		/// </summary>
		public int BaseStoneDuration { get; set; }

		/// <summary>
		/// урон от камня
		/// </summary>
		public int BaseStoneDamage { get; set; }

		/// <summary>
		/// время Кровожадности
		/// </summary>
		public int BaseBloodlustDuration { get; set; }

		/// <summary>
		/// процентное увеличение урона во время Кровожадности
		/// </summary>
		public int BaseBloodlustDamageIncrease { get; set; }

		/// <summary>
		/// базовый урон энергетического шара
		/// </summary>
		public int EnergyBoldDamage { get; set; }

		/// <summary>
		/// увеличение урона, если обьект типа "ракета" попал в цель, удовлетворяющую определенному условию
		/// </summary>
		public double BigDamageMissileModifier { get; set; }

		/// <summary>
		/// длительность заморозок фрост-мага
		/// </summary>
		public double FreezeDuration { get; set; }

		/// <summary>
		/// урон ледяной стрелы
		/// </summary>
		public int FrostBoltDamage { get; set; }

		/// <summary>
		/// урон, поглощаемый ледяным щитом до диспелла
		/// </summary>
		public int IceShieldAbsorbDamage { get; set; }

		/// <summary>
		/// время действия ледяного щита
		/// </summary>
		public int IceShieldTime { get; set; }

		/// <summary>
		/// длительность заморозки темного мага
		/// </summary>
		public int ShadowFreezeDuration { get; set; }

		/// <summary>
		/// время Ледяной Ярости
		/// </summary>
		public int FrostEnrageDuration { get; set; }

		/// <summary>
		/// процентное увеличение урона во время Ледяной Ярости
		/// </summary>
		public int FrostEnrageDamageIncrease { get; set; }

		/// <summary>
		/// базовая длительность Огненного Шока
		/// </summary>
		public int FireShockDuration { get; set; }

		/// <summary>
		/// дополнительная длительность Огненного Шока за 1 стак Ожога
		/// </summary>
		public int FireShockAdditionalDuration { get; set; }

		/// <summary>
		/// урон от Огненного Шара за 1 недостающий до 10 стак Ожога
		/// </summary>
		public int FileShockStackDamage { get; set; }

		/// <summary>
		/// количество урона, поглощаемое огненным щитом
		/// </summary>
		public int FireShieldAbsorbDamage { get; set; }

		/// <summary>
		/// шанс получить стак при атаке мага
		/// </summary>
		public double ChanceToScorchByAttack { get; set; }

		/// <summary>
		/// базовый урон за 1 стак Вампиризма
		/// </summary>
		public int BaseCurseLowDamage { get; set; }

		/// <summary>
		/// базовое лечение за 1 стак Вампиризма
		/// </summary>
		public int BaseCurseLowHeal { get; set; }

		/// <summary>
		/// длительность Проклятия
		/// </summary>
		public int CurseHighDuration { get; set; }

		/// <summary>
		/// урон Проклятия
		/// </summary>
		public int CurseHighDamage { get; set; }

		/// <summary>
		/// длительность темного ослепления
		/// </summary>
		public int ShadowBlindDuration { get; set; }

		/// <summary>
		/// минимальное кд на способности\прыжки\ect
		/// </summary>
		public int GlobalCooldown { get; set; }
	}
}
