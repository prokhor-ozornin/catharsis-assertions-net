namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class TaskAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="exception"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Exception(this IAssertion assertion, Task task, AggregateException exception, string message = null) => task is not null ? assertion.Equal(task.Exception, exception, message) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Successful(this IAssertion assertion, Task task, string message = null) => task is not null ? assertion.True(task.IsCompletedSuccessfully, message) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Unsuccessful(this IAssertion assertion, Task task, string message = null) => task is not null ? assertion.True(task.IsFaulted, message) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Canceled(this IAssertion assertion, Task task, string message = null) => task is not null ? assertion.True(task.IsCanceled, message) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Completed(this IAssertion assertion, Task task, string message = null) => task is not null ? assertion.True(task.IsCompleted, message) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="exception"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Exception<T>(this IAssertion assertion, Task<T> task, AggregateException exception, string message = null) => task is not null ? assertion.Equal(task.Exception, exception, message) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Successful<T>(this IAssertion assertion, Task<T> task, string message = null) => task is not null ? assertion.True(task.IsCompletedSuccessfully, message) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Unsuccessful<T>(this IAssertion assertion, Task<T> task, string message = null) => task is not null ? assertion.True(task.IsFaulted, message) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Canceled<T>(this IAssertion assertion, Task<T> task, string message = null) => task is not null ? assertion.True(task.IsCanceled, message) : throw new ArgumentNullException(nameof(task));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Completed<T>(this IAssertion assertion, Task<T> task, string message = null) => task is not null ? assertion.True(task.IsCompleted, message) : throw new ArgumentNullException(nameof(task));
}