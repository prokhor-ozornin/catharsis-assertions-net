namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="Thread"/>
public static class ThreadExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="state"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Thread> State(this IExpectation<Thread> expectation, ThreadState state) => expectation.HaveSubject().And().Expected(thread => thread.ThreadState == state);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="priority"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Thread> Priority(this IExpectation<Thread> expectation, ThreadPriority priority) => expectation.HaveSubject().And().Expected(thread => thread.Priority == priority);
}