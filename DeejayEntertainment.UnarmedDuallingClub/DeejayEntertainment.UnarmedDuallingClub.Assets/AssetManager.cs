using DeejayEntertainment.UnarmedDuallingClub.Common.Enums;
using DeejayEntertainment.UnarmedDuallingClub.UI.GameCoreUi;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace DeejayEntertainment.UnarmedDuallingClub.Assets
{
	public class AssetManager
	{
		private readonly string basePath;
		private readonly Dictionary<string, Image> cache = new Dictionary<string, Image>();
		private const string charactersFolderPath = "resources\\characters\\";
		public Image DefaultAsset { get; }

		public AssetManager(string basePath)
		{
			this.basePath = basePath;
			this.DefaultAsset = GetImageByPath("resources\\NUI.gif");
		}

		public Image GetImageByPath(string path)
		{
			if (cache.ContainsKey(path))
			{
				return cache[path];
			}
			Image result = Image.FromFile(Path.Combine(basePath, path));
			cache[path] = result;
			return result;
		}

		public List<Image> GetPlayerAnimation(string characterName, Pose pose, bool isInversed = false)
		{
			switch (pose)
			{
				case Pose.Win:
					return new List<Image>() {
						GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.WinStance))
					};
				case Pose.Main:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.MainStanceInversed1)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.MainStanceInversed2)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.MainStance1)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.MainStance2)),
						};

				case Pose.Move:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Move1Inversed)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Move2Inversed)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Move3Inversed)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Move4Inversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Move1)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Move2)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Move3)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Move4)),
						};
				case Pose.Jump:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Jump1Inversed)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Jump2Inversed)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Jump3Inversed)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Jump4Inversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Jump1)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Jump2)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Jump3)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.Jump4)),
						};
				case Pose.LowHand:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.LowHandInversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.LowHand)),
						};
				case Pose.HighHand:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.HighHandInversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.HighHand)),
						};
				case Pose.LowKick:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.LowKickInversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.LowKick)),
						};
				case Pose.HighKick:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.HighKickInversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.HighKick)),
						};
				case Pose.Block:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.BlockInversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.BlockPic)),
						};
				case Pose.Charge:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.ChargeInversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.ChargePic)),
						};
				case Pose.Uppercut:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.UppercutInversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.UppercutPic)),
						};
				case Pose.PowerfulKick:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.PowerfulKickInversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.PowerfulKickPic)),
						};
				case Pose.Down:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.DownInversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.DownPic)),
						};
				case Pose.DamageReceiving:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.GainInversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.GainPic)),
						};
				case Pose.Death:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.DeathInversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.DeathPic)),
						};
				case Pose.Stunned:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.StunInversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.StunPic)),
						};
				case Pose.CastUp:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.CastUpInversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.CastUpPic)),
						};
				case Pose.CastForward:
					if (isInversed)
					{
						return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.CastForwardInversed)),
						};
					}
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.CastForwardPic)),
						};
				case Pose.Storm:
					return new List<Image>() {
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.StormStance1)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.StormStance2)),
							GetImageByPath(CalculateAnimationPath(characterName, PlayerAssets.StormStance3)),
						};
				default:
					return new List<Image>() { DefaultAsset };
			}
		}

		private string CalculateAnimationPath(string characterName, string fileName)
		{
			return charactersFolderPath + characterName + fileName;
		}
	}
}
