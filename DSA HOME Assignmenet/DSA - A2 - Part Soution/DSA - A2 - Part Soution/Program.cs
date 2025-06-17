using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DSA___A2___Part_Soution
{
	internal class Program
	{
		static void Main(string[] args)
		{
			TestPRNGCorrectness();

			TestPRNGIntractability();

			Console.WriteLine("Tests completed. Press any key to exit...");
			Console.ReadKey();
		}

		static void TestPRNGCorrectness()
		{
			SplitMix64 prng = new SplitMix64((ulong)DateTime.Now.Ticks);
			List<ulong> numbers = new List<ulong>();

			for (int i = 0; i < 100; i++)
			{
				numbers.Add(prng.Next(1, 1000));
			}

			bool allInRange = numbers.All(n => n >= 1 && n <= 1000);
			Console.WriteLine($"All numbers in range 1-1000: {allInRange}");

			bool isAscending = IsSorted(numbers, true);
			Console.WriteLine($"Numbers are sorted in ascending order: {isAscending}");

			bool isDescending = IsSorted(numbers, false);
			Console.WriteLine($"Numbers are sorted in descending order: {isDescending}");
		}

		static bool IsSorted(List<ulong> list, bool ascending)
		{
			for (int i = 0; i < list.Count - 1; i++)
			{
				if (ascending)
				{
					if (list[i] > list[i + 1])
						return false;
				}
				else
				{
					if (list[i] < list[i + 1])
						return false;
				}
			}
			return true;
		}

		static void TestPRNGIntractability()
		{
			SplitMix64 prng = new SplitMix64((ulong)DateTime.Now.Ticks);
			int[] testSizes = { 1000, 10000, 100000, 1000000 };
			List<double> timings = new List<double>();

			foreach (int size in testSizes)
			{
				Stopwatch sw = Stopwatch.StartNew();

				for (int i = 0; i < size; i++)
				{
					prng.Next(1, 1000);
				}

				sw.Stop();
				double elapsedMs = sw.Elapsed.TotalMilliseconds;
				timings.Add(elapsedMs);

				Console.WriteLine($"Generated {size} numbers in {elapsedMs} ms");
			}

			Console.WriteLine("\nData for Log-Log Graph:");
			Console.WriteLine("Size\tTime(ms)");
			for (int i = 0; i < testSizes.Length; i++)
			{
				Console.WriteLine($"{testSizes[i]}\t{timings[i]}");
			}
		}
	}
}