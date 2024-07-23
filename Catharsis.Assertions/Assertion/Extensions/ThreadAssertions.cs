namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="Thread"/> type.</para>
/// </summary>
/// <seealso cref="Thread"/>
public static class ThreadAssertions
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="Thread"/> is in a specified state.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="thread">Thread to inspect.</param>
  /// <param name="state">Asserted thread state.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="thread"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion State(this IAssertion assertion, Thread thread, ThreadState state, string error = null) => thread is not null ? assertion.True(thread.ThreadState == state, error) : throw new ArgumentNullException(nameof(thread));

  /// <summary>
  ///   <para>Asserts that the given <see cref="Thread"/> has a specified scheduling priority.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="thread">Thread to inspect.</param>
  /// <param name="priority">Asserted thread scheduling priority.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="thread"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Priority(this IAssertion assertion, Thread thread, ThreadPriority priority, string error = null) => thread is not null ? assertion.True(thread.Priority == priority, error) : throw new ArgumentNullException(nameof(thread));
}