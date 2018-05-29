using System.Collections.Generic;
using System.IO;

namespace DeejayEntertainment.UnarmedDuallingClub.Sound.Constants
{
	internal class FileNames
	{
		public string BaseSoundPath { get; }
		public string BaseMusicPath { get; }

		private Dictionary<Sounds, string> SoundFileNames { get; } = new Dictionary<Sounds, string>()
		{
			[Sounds.Amblush] = "amblush.wav",
			[Sounds.Armageddon] = "armageddon.wav",
			[Sounds.Bleed] = "bleed.wav",
			[Sounds.Blind] = "blind.wav",
			[Sounds.Bloodlast] = "bloodlast.wav",
			[Sounds.Bubble] = "bubble.wav",
			[Sounds.CharacterSelected] = "characterselected.wav",
			[Sounds.Charge] = "charge.wav",
			[Sounds.CurseHigh] = "curse(high).wav",
			[Sounds.CurseLow] = "curse(low).wav",
			[Sounds.Cyclone] = "cyclone.wav",
			[Sounds.DeathGrip] = "deathgrip.wav",
			[Sounds.EarthStrike] = "earthstrike.wav",
			[Sounds.EnergyBolt] = "energybolt.wav",
			[Sounds.Enrage] = "enrage.wav",
			[Sounds.Fireball] = "fireball.wav",
			[Sounds.FlameShock] = "flameshock.wav",
			[Sounds.Freeze] = "freeze.wav",
			[Sounds.FrostBolt] = "frostbolt.wav",
			[Sounds.FrostEnrage] = "frostenrage.wav",
			[Sounds.FrostTrap] = "frosttrap.wav",
			[Sounds.Heal] = "heal.wav",
			[Sounds.HighHand] = "highhand.wav",
			[Sounds.HighKick] = "highkick.wav",
			[Sounds.IceShield] = "iceshield.wav",
			[Sounds.Jump] = "jump.wav",
			[Sounds.LowHand] = "lowhand.wav",
			[Sounds.LowKick] = "lowkick.wav",
			[Sounds.MainMenuChange] = "mainmenuchange.wav",
			[Sounds.MainMenuSelect] = "mainmenuselect.wav",
			[Sounds.PowerfulKick] = "powerfulkick.wav",
			[Sounds.PowerkickFury] = "powerkickfury.wav",
			[Sounds.Reflect] = "reflect.wav",
			[Sounds.ShadowForm] = "shadowform.wav",
			[Sounds.Stealth] = "stealth.wav",
			[Sounds.Stone] = "stone.wav",
			[Sounds.Storm] = "storm.wav",
			[Sounds.Stun] = "stun.wav",
			[Sounds.TankStrike] = "tanksstrike.wav",
			[Sounds.Uppercut] = "uppercut.wav",
			[Sounds.Win] = "win.wav",
			[Sounds.Lose] = "lose.wav"
		};

		private Dictionary<Music, string> MusicFileNames { get; } = new Dictionary<Music, string>()
		{
			[Music.Fight1] = "pvp1.wav",
			[Music.Fight2] = "pvp2.wav",
			[Music.Fight3] = "pvp3.wav",
			[Music.MainMenuTheme] = "mainmenu.wav",
			[Music.SelectMenuTheme] = "select.wav",
			[Music.AboutMenuTheme] = "about.wav",
		};

		public FileNames(string baseSoundPath, string baseMusicPath)
		{
			BaseSoundPath = baseSoundPath;
			BaseMusicPath = baseMusicPath;
		}

		public string GetSoundFileName(Sounds sound)
		{
			return Path.Combine(BaseSoundPath, SoundFileNames[sound]);
		}

		public string GetMusicFileName(Music music)
		{
			return Path.Combine(BaseMusicPath, MusicFileNames[music]);
		}
	}
}
