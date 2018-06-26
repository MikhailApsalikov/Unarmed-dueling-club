﻿using DeejayEntertainment.UnarmedDuallingClub.Assets;
using DeejayEntertainment.UnarmedDuallingClub.Common.Constants;
using DeejayEntertainment.UnarmedDuallingClub.Common.Enums;
using DeejayEntertainment.UnarmedDuallingClub.GameCoreContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DeejayEntertainment.UnarmedDuallingClub.GameCore.Entities
{
	public class CharacterState : ICharacterState
	{
		private AssetManager assetManager;
		private Pose pose;
		private DateTime setTime;
		private int animationFramesCount = 1;
		private List<Image> frames = new List<Image>();

		public CharacterState(AssetManager assetManager, string playerName)
		{
			this.PlayerName = playerName;
			this.assetManager = assetManager;
			this.Pose = Pose.Main;
		}

		public Pose Pose
		{
			get
			{
				return pose;
			}
			set
			{
				setTime = DateTime.Now;
				frames = SetAnimationFrames(value);
				animationFramesCount = frames.Count;
				pose = value;
			}
		}

		public string PlayerName { get; private set; }
		public int AnimationSpeed { get; set; } = Timeouts.PlayerAnimationFrame;

		private List<Image> SetAnimationFrames(Pose pose)
		{
			return assetManager.GetPlayerAnimation(PlayerName, pose);
		}

		public Image Image {
			get
			{
				int frameNumber = ((int)DateTime.Now.Subtract(setTime).TotalMilliseconds / AnimationSpeed) % animationFramesCount;
				return frames[frameNumber];
			}
		}

		public List<string> Documentation { get; set; }
	}
}