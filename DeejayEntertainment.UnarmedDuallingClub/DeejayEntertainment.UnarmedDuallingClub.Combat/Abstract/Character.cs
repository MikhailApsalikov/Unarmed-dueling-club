using DeejayEntertainment.UnarmedDuallingClub.Common.Enums;
using DeejayEntertainment.UnarmedDuallingClub.Configuration;
using System;

namespace DeejayEntertainment.UnarmedDuallingClub.Combat.Abstract
{
	public abstract class Character
	{
		/// <summary>
		/// имя персонажа
		/// </summary>
		public abstract string Name { get; }

		/// <summary>
		/// максимальные ХП
		/// </summary>
		public int MaxHp { get; protected set; }

		/// <summary>
		/// текущие ХП
		/// </summary>
		public int CurrentHp { get; private set; }

		/// <summary>
		/// броня
		/// </summary>
		public int Armor { get; protected set; }

		public Pose Pose { get; private set; }

		/// <summary>
		/// коэффициент снижения урона от брони
		/// </summary>
		public double ArmorDamageReduction
		{
			get
			{
				return 1.0 - (Armor * ConfigurationManager.GameBalanceConfiguration.ArmorReduction 
					/ (1 + Armor * ConfigurationManager.GameBalanceConfiguration.ArmorReduction));
			}
		}

		public int CritChance { get; protected set; }

		public void DealMagicalDamage(int damage)
		{
			throw new NotImplementedException();
		}

		public void DealPhysicalDamage(int damage)
		{
			throw new NotImplementedException();
		}
	}
}
