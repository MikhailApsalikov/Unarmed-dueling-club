using DeejayEntertainment.UnarmedDuallingClub.Assets;
using DeejayEntertainment.UnarmedDuallingClub.Configuration;
using DeejayEntertainment.UnarmedDuallingClub.GameCore.Entities;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Interfaces;
using DeejayEntertainment.UnarmedDuallingClub.Sound;
using System.Collections.Generic;
using System.Linq;

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
				Documentation = new List<string>()
				{
					"Вы видите перед собой храброго воина, который своим ви-",
					"дом вселяет страх в своих врагов. После того, как он прибли-",
					"жается к врагу, тот забывает как блокировать атаки. Воин спо-",
					"собен собирать всю свою силу и ярость, чтобы нанести сокру-",
					"шительный удар по врагу, либо оглушить его. В минуту опасно-",
					"сти он обращается к силам Света и защищает себя непробива-",
					"емым щитом.",
					"",
					"Модель персонажа - Милёхин Дмитрий Основная характеристка - Выносливость",
					$"Максимальное здоровье - {gameBalanceConstants.GetCharacterByName("Fury").MaxHp} Броня - {gameBalanceConstants.GetCharacterByName("Fury").Armor}",
					$"Вероятность критического удара - {gameBalanceConstants.GetCharacterByName("Fury").CritChance}%",
					"Способности:",
					$"1) {gameBalanceConstants.GetAbilityByName("PowerfulFury").DisplayName}. Собирает всю свою ярость и наносит врагу {gameBalanceConstants.PowerfulFuryBaseDamage}  ед. физического",
					$" урона. Перезарядка {gameBalanceConstants.GetAbilityByName("PowerfulFury").Cooldown / 10.0}  сек.",
					$"2) {gameBalanceConstants.GetAbilityByName("StunFury").DisplayName}. Атака, оглушающая противника на {gameBalanceConstants.FuryStunDuration / 10.0} сек. и наносящая {gameBalanceConstants.FuryStunBaseDamage} ед. ",
					$" физического урона. Перезарядка {gameBalanceConstants.GetAbilityByName("StunFury").Cooldown / 10.0}  сек.",
					$"3) {gameBalanceConstants.GetAbilityByName("Bubble").DisplayName}. Герой получает неуязвимость на {gameBalanceConstants.BubbleDuration / 10.0} сек. Перезарядка {gameBalanceConstants.GetAbilityByName("Bubble").Cooldown / 10.0}  сек.",
					"4) Пробивание брони(пассивная). После рывка враг не может использовать блок в",
					$" течение {gameBalanceConstants.BlockBanDuration / 10.0} сек.",
					"5) Яростная аура(пассивная). Все лечение, используемое на поле боя с героем умень-",
					"шается на 80%"
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
