using System;
using System.Collections.Generic;
using System.Linq;

namespace Revvy.Test
{
	class Clerk
	{
		public int Id { get; set; }

		public HashSet<int> DependsOn { get; set; }
	}

	class ClerksTask
	{
		public void Start()
		{
			var exampleSet1 = new Clerk[]
			{
				new Clerk
				{
					Id = 1,
					DependsOn = new HashSet<int> {2}
				},
				new Clerk
				{
					Id = 2,
					DependsOn = new HashSet<int> {3, 4}
				},
				new Clerk
				{
					Id = 3,
					DependsOn = new HashSet<int>(0)
				},
				new Clerk
				{
					Id = 4,
					DependsOn = new HashSet<int>(0)
				},
			};

			GetCertificates(exampleSet1);

			Console.WriteLine(String.Join(", ", exampleSet1.Select(c => c.Id)));

			var exampleSet2 = new Clerk[]
			{
				new Clerk
				{
					Id = 1,
					DependsOn = new HashSet<int> {2}
				},
				new Clerk
				{
					Id = 2,
					DependsOn = new HashSet<int> {3, 4}
				},
				new Clerk
				{
					Id = 3,
					DependsOn = new HashSet<int>(0)
				},
				new Clerk
				{
					Id = 4,
					DependsOn = new HashSet<int>(0)
				},
				new Clerk
				{
					Id = 5,
					DependsOn = new HashSet<int> { 2, 3 }
				},
			};

			GetCertificates(exampleSet2);

			Console.WriteLine(String.Join(", ", exampleSet2.Select(c => c.Id)));
		}

		static void GetCertificates(Clerk[] clerks)
		{
			// Using sort algorithm going right-to-left
			for (int edge = 0; edge < clerks.Length; edge++)
			{
				// Variable 'edge' defines the edge of sorted part
				for (int current = clerks.Length - 1; current > edge; current--)
				{
					Clerk left = clerks[current - 1],
						right = clerks[current];

					// Checking if the 'right' clerk should be visited before 'left'
					if (ShouldSwap(left, right))
					{
						// When 'left' depends on 'right' - remove 'right' from deps
						if (left.DependsOn.Contains(right.Id))
						{
							left.DependsOn.Remove(right.Id);
						}

						// Swap
						Swap(ref clerks[current - 1], ref clerks[current]);
					}
				}
			}
		}

		static bool ShouldSwap(Clerk left, Clerk right)
		{
			// We removing the deps, that's why clerk with 0 deps should be moved to the edge
			return !right.DependsOn.Contains(left.Id) && right.DependsOn.Count == 0;
		}

		static void Swap(ref Clerk left, ref Clerk right)
		{
			var temp = left;
			left = right;
			right = temp;
		}
	}
}
