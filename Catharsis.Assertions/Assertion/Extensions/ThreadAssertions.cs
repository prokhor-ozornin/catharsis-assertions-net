namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class ThreadAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="thread"></param>
  /// <param name="state"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion State(this IAssertion assertion, Thread thread, ThreadState state, string message = null) => thread is not null ? assertion.True(thread.ThreadState == state, message) : throw new ArgumentNullException(nameof(thread));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="thread"></param>
  /// <param name="priority"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Priority(this IAssertion assertion, Thread thread, ThreadPriority priority, string message = null) => thread is not null ? assertion.True(thread.Priority == priority, message) : throw new ArgumentNullException(nameof(thread));
}