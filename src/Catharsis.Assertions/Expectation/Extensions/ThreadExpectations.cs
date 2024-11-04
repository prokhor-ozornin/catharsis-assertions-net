namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="Thread"/> type.</para>
/// </summary>
/// <seealso cref="Thread"/>
public static class ThreadExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="Thread"/> is in the specified state.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="state">Expected thread state.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<Thread> State(this IExpectation<Thread> expectation, ThreadState state) => expectation.HaveSubject().And().Expected(thread => thread.ThreadState == state);

  /// <summary>
  ///   <para>Expects that the given <see cref="Thread"/> has a specified scheduling priority.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="priority">Expected thread priority.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<Thread> Priority(this IExpectation<Thread> expectation, ThreadPriority priority) => expectation.HaveSubject().And().Expected(thread => thread.Priority == priority);
}