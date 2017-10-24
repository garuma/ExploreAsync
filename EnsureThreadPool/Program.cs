using System;
using System.Threading;
using System.Threading.Tasks;

namespace EnsureThreadPool
{
	class MainClass
	{
		public static async Task Main (string[] args)
		{
			int CurrentThreadId () => Thread.CurrentThread.ManagedThreadId;

			Console.WriteLine ($"I'm on thread {CurrentThreadId ()}");

			await ThreadPoolHelper.EnsureOnThreadPool ();
			Console.WriteLine ($"I'm on thread {CurrentThreadId ()}");

			await ThreadPoolHelper.EnsureOnThreadPool ();
			Console.WriteLine ($"I'm on thread {CurrentThreadId ()}");
		}
	}
}
