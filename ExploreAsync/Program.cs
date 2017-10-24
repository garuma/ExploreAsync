using System;
using System.Threading.Tasks;

namespace ExploreAsync
{
	class MainClass
	{
		public static async Task Main (string[] args)
		{
			Console.WriteLine ("Hello");
			await Task.Delay (1000);
			Console.WriteLine ("World");
		}
	}
}
