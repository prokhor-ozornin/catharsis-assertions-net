namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="Thread"/> type.</para>
/// </summary>
/// <seealso cref="Thread"/>
public static class ThreadExpectations
{
  /// <summary>
  ///   <para>Expects that a given thread is in a specified state.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="state">Expected thread state.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Thread> State(this IExpectation<Thread> expectation, ThreadState state) => expectation.HaveSubject().And().Expected(thread => thread.ThreadState == state);

  /// <summary>
  ///   <para>Expects that a given thread has a specified scheduling priority.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="priority">Expected thread scheduling priority.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Thread> Priority(this IExpectation<Thread> expectation, ThreadPriority priority) => expectation.HaveSubject().And().Expected(thread => thread.Priority == priority);
}