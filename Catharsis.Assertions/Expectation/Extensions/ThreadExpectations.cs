namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class ThreadExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="state"></param>
  /// <returns></returns>
  public static IExpectation<Thread> State(this IExpectation<Thread> expectation, ThreadState state) => expectation.HaveSubject().And().Expect(thread => thread.ThreadState == state);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="priority"></param>
  /// <returns></returns>
  public static IExpectation<Thread> Priority(this IExpectation<Thread> expectation, ThreadPriority priority) => expectation.HaveSubject().And().Expect(thread => thread.Priority == priority);
}