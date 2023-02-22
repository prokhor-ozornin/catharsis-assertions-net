namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="ValueTask"/> type.</para>
/// </summary>
/// <seealso cref="ValueTask"/>
/// <seealso cref="ValueTask{TResult}"/>
public static class ValueTaskAssertions
{
  /// <summary>
  ///   <para>Asserts that a given task completed successfully.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Successful{T}(IAssertion, ValueTask{T}, string)"/>
  public static IAssertion Successful(this IAssertion assertion, ValueTask task, string error = null) => assertion.True(task.IsCompletedSuccessfully, error);

  /// <summary>
  ///   <para>Asserts that a given task completed unsuccessfully due to unhandled exception.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Unsuccessful{T}(IAssertion, ValueTask{T}, string)"/>
  public static IAssertion Unsuccessful(this IAssertion assertion, ValueTask task, string error = null) => assertion.True(task.IsFaulted, error);

  /// <summary>
  ///   <para>Asserts that a given task failed to complete due to being cancelled.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Canceled{T}(IAssertion, ValueTask{T}, string)"/>
  public static IAssertion Canceled(this IAssertion assertion, ValueTask task, string error = null) => assertion.True(task.IsCanceled, error);

  /// <summary>
  ///   <para>Asserts that a given task completed, whether successfully or not.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Completed{T}(IAssertion, ValueTask{T}, string)"/>
  public static IAssertion Completed(this IAssertion assertion, ValueTask task, string error = null) => assertion.True(task.IsCompleted, error);

  /// <summary>
  ///   <para>Asserts that a given task completed successfully.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Successful(IAssertion, ValueTask, string)"/>
  public static IAssertion Successful<T>(this IAssertion assertion, ValueTask<T> task, string error = null) => assertion.True(task.IsCompletedSuccessfully, error);

  /// <summary>
  ///   <para>Asserts that a given task completed unsuccessfully due to unhandled exception.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Unsuccessful(IAssertion, ValueTask, string)"/>
  public static IAssertion Unsuccessful<T>(this IAssertion assertion, ValueTask<T> task, string error = null) => assertion.True(task.IsFaulted, error);

  /// <summary>
  ///   <para>Asserts that a given task failed to complete due to being cancelled.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Canceled(IAssertion, ValueTask, string)"/>
  public static IAssertion Canceled<T>(this IAssertion assertion, ValueTask<T> task, string error = null) => assertion.True(task.IsCanceled, error);

  /// <summary>
  ///   <para>Asserts that a given task completed, whether successfully or not.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Completed(IAssertion, ValueTask, string)"/>
  public static IAssertion Completed<T>(this IAssertion assertion, ValueTask<T> task, string error = null) => assertion.True(task.IsCompleted, error);
}