namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class ValueTaskAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion Successful(this IAssertion assertion, ValueTask task, string message = null) => assertion.True(task.IsCompletedSuccessfully, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion Unsuccessful(this IAssertion assertion, ValueTask task, string message = null) => assertion.True(task.IsFaulted, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion Canceled(this IAssertion assertion, ValueTask task, string message = null) => assertion.True(task.IsCanceled, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion Completed(this IAssertion assertion, ValueTask task, string message = null) => assertion.True(task.IsCompleted, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion Successful<T>(this IAssertion assertion, ValueTask<T> task, string message = null) => assertion.True(task.IsCompletedSuccessfully, message);
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion Unsuccessful<T>(this IAssertion assertion, ValueTask task, string message = null) => assertion.True(task.IsFaulted, message);
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion Canceled<T>(this IAssertion assertion, ValueTask task, string message = null) => assertion.True(task.IsCanceled, message);
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion Completed<T>(this IAssertion assertion, ValueTask task, string message = null) => assertion.True(task.IsCompleted, message);
}