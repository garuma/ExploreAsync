using System;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace FancyTask
{
	[AsyncMethodBuilder (typeof (FancyTaskAsyncMethodBuilder))]
	public struct FancyTask
	{
		public Task InnerTask { get; }

		public FancyTask (Task task)
		{
			InnerTask = task;
		}

		public TaskAwaiter GetAwaiter() => InnerTask.GetAwaiter();
	}
}
