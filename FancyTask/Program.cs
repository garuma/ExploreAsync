using System;
using System.Threading.Tasks;

namespace FancyTask
{
	class MainClass
	{
		public static async Task Main (string[] args)
		{
			Console.WriteLine ("Launching fanciness");
			await ForSomethingTotallyFancyToHappen ();
			Console.WriteLine ("Done");
		}

		async static FancyTask ForSomethingTotallyFancyToHappen ()
		{
			// So fancy we do nothing
		}
	}
}
