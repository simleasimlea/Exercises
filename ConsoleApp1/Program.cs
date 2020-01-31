using System;

namespace ModularExample
{
	class Program
	{
		static void Main(string[] args)
		{
			string[,] product = {
									{"Snickers", "Almond Joy", "Reeses"},
									{"Skittles", "Starburst", "Jolly Ranchers"},
									{"Juicy Fruit", "Winter Fresh", "Big Red"}
								};

			double[,] cost = {
								{1.80, 1.50, 1.45},
								{1.30, 1.45, 1.20},
								{1.10, 1.15, 1.10}
							};
			ConsoleKey sentinel;

			double priceAccum = 0;
			int row, column;
			//welcome message

			//welcome();
			welcome();
			//Create a welcome message
			//Console.WriteLine("Welcome, to simple Vending Machine");
			//Console.WriteLine("Press any key to add a product or press the 'X' key to exit the vending machine and receive total");
			sentinel = getPrimer(); // Called or invoked
			while (sentinel != ConsoleKey.X)
			{
				//clear console
				Console.Clear();

				//Create a Module to display products

				DisplayProducts(); //calling the display products method
								   //three ways:
								   //could change the scope
								   //pass it in as an argument
								   //define local version

				//Console.WriteLine($"\t 0 \t\t 1  \t\t 2");
				//for (var i = 0; i < product.GetLength(0); i++)
				//{
				//	Console.Write($"{i} \t");
				//	for (var x = 0; x < product.GetLength(1); x++)
				//	{
				//		Console.Write($"{product[i, x]} \t");
				//	}
				//	Console.WriteLine("");
				//}
				row = GetRowSelection();
				//Create a Module //second modularization at end
				//Console.WriteLine("Please enter the row of the product you would like to enter");
				//row = Convert.ToInt32(Console.ReadLine());

				row = checkInput(row);

				//Create a module that defensively program //third modularization at end
				//while ((row < 0) || (row > 3))
				//{
				//	Console.WriteLine("Invalid row entry, please enter a number between 0 and 2");
				//	row = Convert.ToInt32(Console.ReadLine());
				//}

				//Create a Module to get column
				column = getColumnSelection();
				column = checkInput(column); //left off here

				//Console.WriteLine("Please enter the column of the product you would like to enter");
				//column = Convert.ToInt32(Console.ReadLine());

				//Create a module that defensively program
				//while ((column < 0) || (column > 3))
				//{
				//	Console.WriteLine("Invalid column entry, please enter a number between 0 and 2");
				//	column = Convert.ToInt32(Console.ReadLine());
				//}


				//Create a module that output selection and accumulates the price
				//Console.WriteLine($"You have selected {product[row, column]} for {cost[row, column].ToString("c")}");
				//priceAccum += cost[row, column];
				priceAccum = accumPrice(product, cost, row, column, priceAccum);

				//module that ask for sentinel value
				//Console.WriteLine("Press any key to add a product or press the 'X' key to exit the vending machine and recieve total");
				sentinel = getPrimer();

				outputTotal(priceAccum);
			}
		} //end of main

		public static void welcome()
		{
			Console.WriteLine("Welcome, to simple Vending Machine");
		}

		//get primer
		public static ConsoleKey getPrimer()
		{
			//ConsoleKey sentinal;

			Console.WriteLine("Press any key to add a product or press the 'X' key to exit the vending machine and receive total");
			ConsoleKey sentinel = Console.ReadKey().Key;
			return sentinel;
		}

		//Create a module that will output total
		//Console.WriteLine("Based on your selections, you owe {0}", priceAccum.ToString("c"));
		//outputTotal(priceAccum);






		//display products
		public static void DisplayProducts()
		{
			string[,] product = {
									{"Snickers", "Almond Joy", "Reeses"},
									{"Skittles", "Starburst", "Jolly Ranchers"},
									{"Juicy Fruit", "Winter Fresh", "Big Red"}
								};
			Console.WriteLine($"\t 0 \t\t 1  \t\t 2");
			for (var i = 0; i < product.GetLength(0); i++)
			{
				Console.Write($"{i} \t");
				for (var x = 0; x < product.GetLength(1); x++)
				{
					Console.Write($"{product[i, x]} \t");
				}
				Console.WriteLine("");
			}

		}

		public static int GetRowSelection()

		{
			int row;
			Console.WriteLine("Please enter the row of the product you would like to enter");
			row = Convert.ToInt32(Console.ReadLine());
			return row;
		}

		private static int checkInput(int x)
		{
			while ((x < 0) || (x > 2))
			{
				Console.WriteLine("Invalid row entry, please enter a number between 0 and 2");
				x = Convert.ToInt32(Console.ReadLine());
			}
			return x;
		}

		public static int getColumnSelection()
		{
			int column;
			Console.WriteLine("Please enter the column of the product you would like to enter");
			column = Convert.ToInt32(Console.ReadLine());

			return column;
		}

		public static double accumPrice(string[,] prod, double[,] cost, int r, int c, double priceAccum)
		{
			//Create a module that output selection and accumulates the price
			Console.WriteLine($"You have selected {prod[r, c]} for {cost[r, c].ToString("c")}");
			priceAccum += cost[r, c];

			return priceAccum;
		}

		public static void outputTotal(double priceAccum)
		{
			Console.WriteLine("Based on your selections, you owe {0}", priceAccum.ToString("c"));

		}

	}
}

