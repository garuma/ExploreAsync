using System;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace FancyTask
{
	public class FancyTaskAsyncMethodBuilder
	{
		AsyncTaskMethodBuilder builder = AsyncTaskMethodBuilder.Create (); 

		public static FancyTaskAsyncMethodBuilder Create () => new FancyTaskAsyncMethodBuilder ();

		public void Start<TStateMachine> (ref TStateMachine stateMachine)
			where TStateMachine : IAsyncStateMachine
		{
			// Simply start the state machine which will execute our code
			stateMachine.MoveNext ();
		}

		public FancyTask Task => new FancyTask (builder.Task);

		public void SetResult () => builder.SetResult ();
		public void SetException (Exception ex) => builder.SetException (ex);
		public void SetStateMachine (IAsyncStateMachine stateMachine) => builder.SetStateMachine (stateMachine);

		public void AwaitOnCompleted<TAwaiter, TStateMachine> (ref TAwaiter awaiter, ref TStateMachine stateMachine)
			where TAwaiter : INotifyCompletion
			where TStateMachine : IAsyncStateMachine
		{
			builder.AwaitOnCompleted (ref awaiter, ref stateMachine);
		}

		public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine> (ref TAwaiter awaiter, ref TStateMachine stateMachine)
			where TAwaiter : ICriticalNotifyCompletion
			where TStateMachine : IAsyncStateMachine
		{
			builder.AwaitUnsafeOnCompleted (ref awaiter, ref stateMachine);
		}
	}
}
