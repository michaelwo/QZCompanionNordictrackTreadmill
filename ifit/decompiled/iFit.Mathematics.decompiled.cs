using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("iFit Mobile")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("iFit's Math Package")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("iFit.Mathematics")]
[assembly: AssemblyTitle("iFit.Mathematics")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace iFit.Mathematics
{
	public class Average
	{
		public double CurrentAverage { get; private set; }

		public int NumberOfSamplings { get; private set; }

		public void AddSample(double sample)
		{
			CurrentAverage = (CurrentAverage * (double)NumberOfSamplings + sample) / (double)(++NumberOfSamplings);
		}

		public void Reset()
		{
			NumberOfSamplings = 0;
			CurrentAverage = 0.0;
		}
	}
	public static class MathUtils
	{
		public static int Clamp(this int val, int A, int B)
		{
			if (A.Equals(B))
			{
				return A;
			}
			if (B < A)
			{
				A += B;
				B = A - B;
				A -= B;
			}
			if (val < A)
			{
				return A;
			}
			if (val > B)
			{
				return B;
			}
			return val;
		}

		public static float Clamp(this float val, float A, float B)
		{
			if (A.Equals(B))
			{
				return A;
			}
			if (B < A)
			{
				A += B;
				B = A - B;
				A -= B;
			}
			if (val < A)
			{
				return A;
			}
			if (val > B)
			{
				return B;
			}
			return val;
		}

		public static double Clamp(this double val, double A, double B)
		{
			if (A.Equals(B))
			{
				return A;
			}
			if (B < A)
			{
				A += B;
				B = A - B;
				A -= B;
			}
			if (val < A)
			{
				return A;
			}
			if (val > B)
			{
				return B;
			}
			return val;
		}

		public static double RadiansFromDegrees(double angleDegrees)
		{
			return Math.PI / 180.0 * angleDegrees;
		}

		public static double DegreesFromRadians(double angleRadians)
		{
			return 180.0 / Math.PI * angleRadians;
		}

		public static double Lerp(double left, double right, double ratio)
		{
			ratio = ratio.Clamp(0.0, 1.0);
			return (1.0 - ratio) * left + ratio * right;
		}

		public static int RoundToNearest(this double numToRound, double roundTo)
		{
			return (int)(Math.Round(numToRound / roundTo, MidpointRounding.AwayFromZero) * roundTo);
		}

		public static int RoundToNearest(this float numToRound, double roundTo)
		{
			return (int)(Math.Round((double)numToRound / roundTo, MidpointRounding.AwayFromZero) * roundTo);
		}

		public static int RoundToNearest(this int numToRound, double roundTo)
		{
			return (int)(Math.Round((double)numToRound / roundTo, MidpointRounding.AwayFromZero) * roundTo);
		}

		public static int ModSafe(this int x, int m)
		{
			if (m != 0)
			{
				return (x % m + m) % m;
			}
			return 0;
		}
	}
}
namespace iFit.Mathematics.Interpolation
{
	public class AdditiveDoubleInterpolator : AdditiveValueInterpolator<double>
	{
		public AdditiveDoubleInterpolator(TimeSpan updateInterval, double changeAmount, InterpolatorMode interpolatorMode = InterpolatorMode.InterpolateBothWays, double valueChangeThreshold = 1E-05, double initialValue = 0.0)
			: base(updateInterval, changeAmount, interpolatorMode, valueChangeThreshold, initialValue)
		{
		}

		protected override double AddValues(double point1, double point2)
		{
			return point1 + point2;
		}

		protected override double DistanceBetween(double point1, double point2)
		{
			return Math.Abs(point2 - point1);
		}

		protected override bool IsGreater(double point1, double point2)
		{
			return point1 > point2;
		}

		protected override double ScaleValue(double point, double scale)
		{
			return point * scale;
		}
	}
	public abstract class AdditiveValueInterpolator<TData> : ValueInterpolator<TData>
	{
		public TData ChangeAmount { get; private set; }

		protected AdditiveValueInterpolator(TimeSpan updateInterval, TData changeAmount, InterpolatorMode interpolatorMode = InterpolatorMode.InterpolateBothWays, double valueChangeThreshold = 1E-05, TData initialValue = default(TData))
			: base(updateInterval, interpolatorMode, valueChangeThreshold, initialValue)
		{
			ChangeAmount = changeAmount;
		}

		protected override TData GetNextInterpolatedValue()
		{
			bool flag = IsGreater(base.SetValue, base.CurrentInterpolatedValue);
			return AddValues(base.CurrentInterpolatedValue, flag ? ChangeAmount : ScaleValue(ChangeAmount, -1.0));
		}

		protected abstract TData AddValues(TData point1, TData point2);

		protected abstract TData ScaleValue(TData point, double scale);
	}
	public static class CoordinateInterpolation
	{
		public static InterpolatedCoordinatesResult InterpolateCoordinateList(IList<Tuple<double, double>> coordinates, int resultCount, bool startWithZeroPoint = false, CancellationToken cancellationToken = default(CancellationToken))
		{
			List<Tuple<double, double>> list = CheckAndSortTemporaryList(coordinates, resultCount);
			Tuple<double, double> tuple = list.First();
			Tuple<double, double> tuple2 = list.Last();
			if (startWithZeroPoint && tuple.Item1 > 0.01)
			{
				tuple = new Tuple<double, double>(0.0, 0.0);
				list.Insert(0, tuple);
			}
			List<Tuple<int, double>> list2 = new List<Tuple<int, double>>
			{
				new Tuple<int, double>(0, tuple.Item2)
			};
			double num = (list.Last().Item1 - list.First().Item1) / (double)(resultCount - 1);
			int num2 = -1;
			int num3 = 0;
			for (int i = 1; i < resultCount - 1; i++)
			{
				double cumulativeXDistance = num * (double)i;
				int num4 = (int)Math.Round(cumulativeXDistance);
				if (num4 == num2)
				{
					continue;
				}
				num2 = num4;
				Tuple<double, double> tuple3 = list.FirstOrDefault((Tuple<double, double> p) => p.Item1 > cumulativeXDistance);
				if (tuple3 == null)
				{
					list2.Add(new Tuple<int, double>(i, tuple2.Item2));
					return new InterpolatedCoordinatesResult(list2, num);
				}
				num3 = list.IndexOf(tuple3);
				if (num3 >= 1)
				{
					Tuple<double, double> tuple4 = list[num3 - 1];
					double num5 = tuple3.Item1 - tuple4.Item1;
					double ratio = ((cumulativeXDistance - tuple4.Item1) / num5).Clamp(0.0, 1.0);
					double item = InterpolateLinearlyBetween(tuple4, tuple3, ratio).Item2;
					list2.Add(new Tuple<int, double>(i, item));
					if (cancellationToken.IsCancellationRequested)
					{
						list.Clear();
						return InterpolatedCoordinatesResult.CancelledResult;
					}
					list = list.Skip((num3 - 2).Clamp(0, 2147483647)).ToList();
				}
			}
			list.Clear();
			list = null;
			list2.Add(new Tuple<int, double>(resultCount - 1, tuple2.Item2));
			if (cancellationToken.IsCancellationRequested)
			{
				return InterpolatedCoordinatesResult.CancelledResult;
			}
			return new InterpolatedCoordinatesResult(list2, num);
		}

		public static Tuple<double, double> InterpolateLinearlyBetween(Tuple<double, double> pointA, Tuple<double, double> pointB, double ratio)
		{
			ratio = ratio.Clamp(0.0, 1.0);
			double num = pointB.Item1 - pointA.Item1;
			double num2 = pointB.Item2 - pointA.Item2;
			double item = num * ratio + pointA.Item1;
			double item2 = num2 * ratio + pointA.Item2;
			return new Tuple<double, double>(item, item2);
		}

		private static List<Tuple<double, double>> CheckAndSortTemporaryList(IList<Tuple<double, double>> coordinates, int maxCount)
		{
			if (coordinates == null)
			{
				throw new ArgumentNullException("coordinates");
			}
			if (coordinates.Count < 2)
			{
				throw new ArgumentNullException("coordinates", "Coordinate list must have at least two values.");
			}
			if (maxCount < 2)
			{
				throw new ArgumentOutOfRangeException("maxCount", "Parameter cannot be less than 2.");
			}
			List<Tuple<double, double>> list = new List<Tuple<double, double>>(from p in coordinates.Distinct()
				orderby p.Item1
				select p);
			if (list.Count < 2)
			{
				throw new ArgumentNullException("coordinates", "Coordinate list must have at least two distinct values.");
			}
			return list;
		}
	}
	public class EasingDoubleInterpolator : EasingValueInterpolator<double>
	{
		public EasingDoubleInterpolator(TimeSpan updateInterval, double easeAmount = 2.0, InterpolatorMode interpolatorMode = InterpolatorMode.InterpolateBothWays, double valueChangeThreshold = 1E-05, double initialValue = 0.0)
			: base(updateInterval, easeAmount, interpolatorMode, valueChangeThreshold, initialValue)
		{
		}

		protected override double DistanceBetween(double point1, double point2)
		{
			return Math.Abs(point2 - point1);
		}

		protected override bool IsGreater(double point1, double point2)
		{
			return point1 > point2;
		}

		protected override double Lerp(double point1, double point2, double ratio)
		{
			return MathUtils.Lerp(point1, point2, ratio);
		}

		protected override double ScaleValue(double point, double scale)
		{
			return point * scale;
		}
	}
	public abstract class EasingValueInterpolator<TData> : ValueInterpolator<TData>
	{
		public double EaseAmount { get; private set; }

		protected EasingValueInterpolator(TimeSpan updateInterval, double easeAmount = 2.0, InterpolatorMode interpolatorMode = InterpolatorMode.InterpolateBothWays, double valueChangeThreshold = 1E-05, TData initialValue = default(TData))
			: base(updateInterval, interpolatorMode, valueChangeThreshold, initialValue)
		{
			if (easeAmount <= 1.0)
			{
				throw new ArgumentOutOfRangeException("easeAmount", "Ease amount must be greater than 1.");
			}
			EaseAmount = easeAmount;
		}

		protected override TData GetNextInterpolatedValue()
		{
			return Lerp(base.CurrentInterpolatedValue, base.SetValue, 1.0 / EaseAmount);
		}

		protected abstract TData Lerp(TData point1, TData point2, double ratio);

		protected abstract TData ScaleValue(TData point, double scale);
	}
	public class InterpolatedCoordinatesResult
	{
		public static readonly InterpolatedCoordinatesResult CancelledResult = new InterpolatedCoordinatesResult();

		public IList<Tuple<int, double>> InterpolatedCoordinateList { get; private set; }

		public double HorizontalSpaceBetweenPoints { get; private set; }

		public bool WasCancelled { get; private set; }

		private InterpolatedCoordinatesResult()
		{
			WasCancelled = true;
		}

		public InterpolatedCoordinatesResult(IList<Tuple<int, double>> interpolatedCoordinateList, double horizontalSpaceBetweenPoints)
		{
			InterpolatedCoordinateList = interpolatedCoordinateList;
			HorizontalSpaceBetweenPoints = horizontalSpaceBetweenPoints;
		}
	}
	public enum InterpolatorMode
	{
		InterpolateBothWays = 1,
		InterpolateDownward = 2,
		InterpolateUpward = 4
	}
	public abstract class ValueInterpolator<TData> : IDisposable
	{
		protected const double DefaultThreshold = 1E-05;

		public TData CurrentInterpolatedValue { get; protected set; }

		public bool Disposed { get; private set; }

		public bool Enabled { get; private set; }

		public InterpolatorMode Mode { get; set; }

		public bool Paused { get; set; }

		public TData SetValue { get; set; }

		public TimeSpan UpdateInterval { get; private set; }

		public double ValueChangeThreshold { get; set; }

		public event EventHandler<TData> InterpolatedValueChanged;

		protected ValueInterpolator(TimeSpan updateInterval, InterpolatorMode interpolatorMode = InterpolatorMode.InterpolateBothWays, double valueChangeThreshold = 1E-05, TData initialValue = default(TData))
		{
			CurrentInterpolatedValue = initialValue;
			Mode = interpolatorMode;
			SetValue = initialValue;
			UpdateInterval = updateInterval;
			ValueChangeThreshold = valueChangeThreshold;
		}

		public void Start()
		{
			if (!Enabled)
			{
				Enabled = true;
				Paused = false;
				Task.Run((Func<Task>)Looper);
			}
		}

		public void Stop()
		{
			Enabled = false;
			Paused = false;
		}

		private async Task Looper()
		{
			while (!Disposed && Enabled && !Paused)
			{
				UpdateInterpolation();
				await Task.Delay(UpdateInterval);
			}
		}

		private void UpdateInterpolation()
		{
			double num = DistanceBetween(CurrentInterpolatedValue, SetValue);
			if (num >= ValueChangeThreshold)
			{
				bool flag = IsGreater(SetValue, CurrentInterpolatedValue);
				TData val = default(TData);
				CurrentInterpolatedValue = Mode switch
				{
					InterpolatorMode.InterpolateUpward => flag ? GetNextInterpolatedValue() : SetValue, 
					InterpolatorMode.InterpolateDownward => flag ? SetValue : GetNextInterpolatedValue(), 
					_ => GetNextInterpolatedValue(), 
				};
				this.InterpolatedValueChanged?.Invoke(this, CurrentInterpolatedValue);
			}
			else if (num > 5E-324)
			{
				CurrentInterpolatedValue = SetValue;
				this.InterpolatedValueChanged?.Invoke(this, CurrentInterpolatedValue);
			}
		}

		public void Dispose()
		{
			Enabled = false;
			Paused = false;
			Disposed = true;
		}

		protected abstract TData GetNextInterpolatedValue();

		protected abstract bool IsGreater(TData point1, TData point2);

		protected abstract double DistanceBetween(TData point1, TData point2);
	}
}
