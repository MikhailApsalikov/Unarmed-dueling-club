using System.Threading;
using System.Threading.Tasks;

namespace DeejayEntertainment.UnarmedDuallingClub.Combat.Abstract
{
	public abstract class Effect
	{
		private const int MinimalInterval = 100;

		private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

		private int stacks;

		public Effect(Character character, int time = 10, bool isEndless = false)
		{
			Character = character;
			Time = time;
			IsEndless = isEndless;
			cancellationTokenSource = new CancellationTokenSource();
		}

		/// <summary>
		///     время действия в десятых долях секунды
		/// </summary>
		public int Time { get; private set; }

		public bool IsEndless { get; private set; }

		/// <summary>
		///     время между тиками для 1-го и 2-го типов бафов
		/// </summary>
		public abstract int TimeBetweenTicks { get; }

		/// <summary>
		///     полезный ли?
		/// </summary>
		public abstract bool IsPositive { get; }

		/// <summary>
		///     персонаж на которого действует
		/// </summary>
		public Character Character { get; }

		/// <summary>
		///     количество стаков
		/// </summary>
		public int Stacks
		{
			get => stacks;
			set
			{
				if (value <= 0)
				{
					Dispell();
				}
				stacks = value;
			}
		}

		/// <summary>
		///     имя бафа
		/// </summary>
		public abstract string Name { get; }

		/// <summary>
		///     нужен ли еще бафф?
		/// </summary>
		public bool IsEnabled { get; private set; }

		public async Task Start()
		{
			CancellationToken token = cancellationTokenSource.Token;
			OnStart();
			while (Time > 0 || IsEndless)
			{
				await Task.Delay(MinimalInterval, token);
				Time--;
				if (Time % TimeBetweenTicks == 0)
				{
					OnTick();
				}
			}
			OnEnd();
		}

		protected virtual void OnStart()
		{

		}

		protected virtual void OnTick()
		{

		}

		protected virtual void OnEnd()
		{

		}

		protected virtual void OnDispell()
		{

		}

		public void Dispell()
		{
			OnDispell();
			cancellationTokenSource.Cancel();
		}

		/**
		 * тип 0 - производим действия при старте, далее пока не закончится время,
		 * ждем, после окончания времени выполняем основные действия бафа
		 
		private void runType0()
		{
			onStart();
			while (enable && time > -1)
			{
				time--;
				Constants.delay(100);
			}
			execute();
		}

		/**
		 * тип 1 - производим действия при старте, далее каждые timeForDots
		 * выполняем основное действие
		 
		private void runType1()
		{
			onStart();
			while (enable)
			{
				{
					Constants.delay(timeForDots * 100);
					execute();
				}
			}
		}

		/**
		 * тип 2 - производим действия при старте, далее пока не закончится время,
		 * либо пока баф не рассеется, выполняем основные действия
		 
		private void runType2()
		{
			onStart();
			while (enable && time > -1 && !dispelled)
			{
				if (time % timeForDots == 0)
				{
					execute();
				}
				Constants.delay(100);
				time--;
			}
		}

		/**
		 * тип 3 - производим действия при старте, далее ждем, пока рассеется, затем
		 * выполняем основные действия
		 
		private void runType3()
		{
			onStart();
			while (enable && !dispelled)
			{
				Constants.delay(100);
			}
			execute();
		}

		/**
		 * тип 4 - производим действия при старте, далее ждем, пока рассеется, либо,
		 * пока закончится время затем выполняем основные действия
		 
		private void runType4()
		{
			onStart();
			while (enable && !dispelled && time > -1)
			{
				Constants.delay(100);
				time--;
			}
			if (!dispelled)
			{
				execute();
			}
		}
			/*

			*/

		public override string ToString()
		{
			string s = Name;
			if (stacks > 1)
			{
				s = $"{s} ({stacks}) ";
			}
			if (!IsEndless)
			{
				s = $"{s} {Time / 10} c.";
			}
			return s;
		}
	}
}