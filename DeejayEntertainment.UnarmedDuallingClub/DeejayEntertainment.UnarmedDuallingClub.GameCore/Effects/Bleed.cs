using DeejayEntertainment.UnarmedDuallingClub.GameCore.Abstract;
using DeejayEntertainment.UnarmedDuallingClub.GameCore.Configuration;

namespace DeejayEntertainment.UnarmedDuallingClub.GameCore.Effects
{
	public class Bleed : Effect
	{
		public const int Id = 7;

		public Bleed(Character character, int time) : base(character, time)
		{
		}

		public override int TimeBetweenTicks { get; } = 10;
		public override bool IsPositive { get; } = false;
		public override string Name { get; } = "Кровотечение";

		protected override void OnTick()
		{
			Character.DealMagicalDamage(GameBalanceConfigurationManager.Configuration.BaseBleedDamage);
		}
	}
}
