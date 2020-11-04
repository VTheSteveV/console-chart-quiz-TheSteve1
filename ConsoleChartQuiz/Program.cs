using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Linq;

namespace console_chart_quiz_TheSteve1
{
	class Program
	{
		static void Main(string[] args)
		{
			//Github test
			string[] colomns = Console.ReadLine().Split('\t');
			int animalcolomn = Array.IndexOf(colomns, args[0]);
			int attackcolomn = Array.IndexOf(colomns, args[1]);
			int nrlines = int.Parse(args[2]);
			string line;
			List<(string animal, int attacks)> animalattacks = new List<(string, int)>();
			
			while (( line = Console.ReadLine()) != null)
			{
				colomns = line.Split('\t');
				bool added = false;
				for (int i = 0; i < animalattacks.Count; i++)
				{
					if (animalattacks[i].animal.Equals(colomns[animalcolomn]))
					{
						animalattacks[i] = (animalattacks[i].animal, animalattacks[i].attacks + int.Parse(colomns[attackcolomn]));
						added = true;
					}
				}
				if (!added) animalattacks.Add((colomns[animalcolomn], int.Parse(colomns[attackcolomn])));
			}

			int maxAnimalattacks = 40;
			animalattacks.ForEach(x =>{
				if (maxAnimalattacks < x.attacks) maxAnimalattacks = x.attacks;
			});
			animalattacks = (from v in animalattacks
							 orderby v.attacks
							 select v).ToList();
			animalattacks.Reverse();
			int c = 0;

			foreach(var animalattack in animalattacks)
			{
				if (c == nrlines) break;
				Console.Write($"{animalattack.animal,45}|");
				Console.BackgroundColor = ConsoleColor.Cyan;
				int tiles = (int) Math.Ceiling((double)animalattack.attacks * 100 / maxAnimalattacks);
				for(int i= 0; i < tiles;i++)Console.Write(' ');
				Console.WriteLine();
				Console.BackgroundColor = ConsoleColor.Black;
				c++;
			}
		}
	}
}
