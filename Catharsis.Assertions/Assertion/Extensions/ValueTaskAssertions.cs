namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="ValueTask"/>
public static class ValueTaskAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <seealso cref="Successful{T}(IAssertion, ValueTask{T}, string)"/>
  public static IAssertion Successful(this IAssertion assertion, ValueTask task, string message = null) => assertion.True(task.IsCompletedSuccessfully, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <seealso cref="Unsuccessful{T}(IAssertion, ValueTask{T}, string)"/>
  public static IAssertion Unsuccessful(this IAssertion assertion, ValueTask task, string message = null) => assertion.True(task.IsFaulted, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <seealso cref="Canceled{T}(IAssertion, ValueTask{T}, string)"/>
  public static IAssertion Canceled(this IAssertion assertion, ValueTask task, string message = null) => assertion.True(task.IsCanceled, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <seealso cref="Completed{T}(IAssertion, ValueTask{T}, string)"/>
  public static IAssertion Completed(this IAssertion assertion, ValueTask task, string message = null) => assertion.True(task.IsCompleted, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <seealso cref="Successful(IAssertion, ValueTask, string)"/>
  public static IAssertion Successful<T>(this IAssertion assertion, ValueTask<T> task, string message = null) => assertion.True(task.IsCompletedSuccessfully, message);
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <seealso cref="Unsuccessful(IAssertion, ValueTask, string)"/>
  public static IAssertion Unsuccessful<T>(this IAssertion assertion, ValueTask<T> task, string message = null) => assertion.True(task.IsFaulted, message);
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <seealso cref="Canceled(IAssertion, ValueTask, string)"/>
  public static IAssertion Canceled<T>(this IAssertion assertion, ValueTask<T> task, string message = null) => assertion.True(task.IsCanceled, message);
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="task"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <seealso cref="Completed(IAssertion, ValueTask, string)"/>
  public static IAssertion Completed<T>(this IAssertion assertion, ValueTask<T> task, string message = null) => assertion.True(task.IsCompleted, message);
}