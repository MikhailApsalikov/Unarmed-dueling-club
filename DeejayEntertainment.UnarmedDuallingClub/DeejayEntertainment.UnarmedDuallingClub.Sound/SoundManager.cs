using DeejayEntertainment.UnarmedDuallingClub.Sound.Constants;
using System;
using System.Media;
using System.Windows.Media;

namespace DeejayEntertainment.UnarmedDuallingClub.Sound
{
	public class SoundManager : IDisposable
	{
		private FileNames FileNames { get; }

		public SoundPlayer Player { get; set; }

		public SoundManager(string baseSoundPath, string baseMusicPath)
		{
			FileNames = new FileNames(baseSoundPath, baseMusicPath);
		}

		public void PlaySound(Sounds sound)
		{
			var fileName = FileNames.GetSoundFileName(sound);
			MediaPlayer player = new MediaPlayer();
			player.Open(new Uri(fileName));
			player.Play();
		}

		public void SetBackgroundMusic(Music music)
		{
			var fileName = FileNames.GetMusicFileName(music);
			StopBackgroundMusic();
			Player = new SoundPlayer(fileName);
			Player.PlayLooping();
		}

		public void StopBackgroundMusic()
		{
			Player?.Stop();
			Player = null;
		}

		public void Dispose()
		{
			this.StopBackgroundMusic();
		}
	}
}
