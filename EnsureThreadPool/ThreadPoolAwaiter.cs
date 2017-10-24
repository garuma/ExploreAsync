using System;
using System.Threading;

namespace EnsureThreadPool
{
	public static class ThreadPoolHelper
	{
		public static ThreadPoolAwaitable EnsureOnThreadPool () => new ThreadPoolAwaitable ();
	}

	public struct ThreadPoolAwaitable
	{
		public ThreadPoolAwaiter GetAwaiter () => new ThreadPoolAwaiter ();
	}

	public class ThreadPoolAwaiter : System.Runtime.CompilerServices.INotifyCompletion
	{
		static bool IsOnThreadPool () => Thread.CurrentThread.IsThreadPoolThread;

		public bool IsCompleted {
			get {
				/* If we are not on the main thread we want to continue
				 * right away without context capture. Otherwise we want
				 * to schedule the continuation on a threadpool thread
				 */
				return IsOnThreadPool ();
			}
		}

		static readonly WaitCallback callback = a => ((Action)a)();

		public void OnCompleted (Action continuation)
		{
			if (IsOnThreadPool ())
				throw new InvalidOperationException ("The continuation should not have been scheduled from a thread pool thread");
			ThreadPool.QueueUserWorkItem (callback, continuation);
		}

		public void GetResult ()
		{
			// Nothing to do there
		}
	}
}
