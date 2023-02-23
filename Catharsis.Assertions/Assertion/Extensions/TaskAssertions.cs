namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for tasks types.</para>
/// </summary>
/// <seealso cref="Task"/>
/// <seealso cref="Task{TResult}"/>
public static class TaskAssertions
{
  /// <summary>
  ///   <para>Asserts that a given task has a specified status.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="status">Asserted task status.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="task"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Status(this IAssertion assertion, Task task, TaskStatus status, string error = null) => task is not null ? assertion.True(task.Status == status, error) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para>Asserts that a given task completed successfully.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="task"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Successful{T}(IAssertion, Task{T}, string)"/>
  public static IAssertion Successful(this IAssertion assertion, Task task, string error = null) => task is not null ? assertion.True(task.IsCompletedSuccessfully, error) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para>Asserts that a given task completed unsuccessfully due to unhandled exception.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="task"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Unsuccessful{T}(IAssertion, Task{T}, string)"/>
  public static IAssertion Unsuccessful(this IAssertion assertion, Task task, string error = null) => task is not null ? assertion.True(task.IsFaulted, error) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para>Asserts that a given task failed to complete due to being cancelled.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="task"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Canceled{T}(IAssertion, Task{T}, string)"/>
  public static IAssertion Canceled(this IAssertion assertion, Task task, string error = null) => task is not null ? assertion.True(task.IsCanceled, error) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para>Asserts that a given task completed, whether successfully or not.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="task"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Completed{T}(IAssertion, Task{T}, string)"/>
  public static IAssertion Completed(this IAssertion assertion, Task task, string error = null) => task is not null ? assertion.True(task.IsCompleted, error) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para>Asserts that a given task ended prematurely due to specified exception.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="exception">Asserted exception that caused the task to be aborted, or <see langword="null"/> if the task completed successfully or has not yet thrown exceptions.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="task"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Exception<T>(this IAssertion assertion, Task<T> task, AggregateException exception, string error = null) => task is not null ? assertion.Equal(task.Exception, exception, error) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para>Asserts that a given task has a specified status.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="status">Asserted task status.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="task"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Status<T>(this IAssertion assertion, Task<T> task, TaskStatus status, string error = null) => task is not null ? assertion.True(task.Status == status, error) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para>Asserts that a given task completed successfully.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="task"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Successful(IAssertion, Task, string)"/>
  public static IAssertion Successful<T>(this IAssertion assertion, Task<T> task, string error = null) => task is not null ? assertion.True(task.IsCompletedSuccessfully, error) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para>Asserts that a given task completed unsuccessfully due to unhandled exception.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="task"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Unsuccessful(IAssertion, Task, string)"/>
  public static IAssertion Unsuccessful<T>(this IAssertion assertion, Task<T> task, string error = null) => task is not null ? assertion.True(task.IsFaulted, error) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para>Asserts that a given task failed to complete due to being cancelled.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="task"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Canceled(IAssertion, Task, string)"/>
  public static IAssertion Canceled<T>(this IAssertion assertion, Task<T> task, string error = null) => task is not null ? assertion.True(task.IsCanceled, error) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para>Asserts that a given task completed, whether successfully or not.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="task">Task to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="task"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Completed(IAssertion, Task, string)"/>
  public static IAssertion Completed<T>(this IAssertion assertion, Task<T> task, string error = null) => task is not null ? assertion.True(task.IsCompleted, error) : throw new ArgumentNullException(nameof(task));
}