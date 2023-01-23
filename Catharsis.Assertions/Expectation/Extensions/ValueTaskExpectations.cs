namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class ValueTaskExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<ValueTask> Successful(this IExpectation<ValueTask> expectation) => expectation.Expect(task => task.IsCompletedSuccessfully);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<ValueTask> Unsuccessful(this IExpectation<ValueTask> expectation) => expectation.Expect(task => task.IsFaulted);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<ValueTask> Canceled(this IExpectation<ValueTask> expectation) => expectation.Expect(task => task.IsCanceled);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<ValueTask> Completed(this IExpectation<ValueTask> expectation) => expectation.Expect(task => task.IsCompleted);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<ValueTask<T>> Successful<T>(this IExpectation<ValueTask<T>> expectation) => expectation.Expect(task => task.IsCompletedSuccessfully);
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<ValueTask<T>> Unsuccessful<T>(this IExpectation<ValueTask<T>> expectation) => expectation.Expect(task => task.IsFaulted);
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<ValueTask<T>> Canceled<T>(this IExpectation<ValueTask<T>> expectation) => expectation.Expect(task => task.IsCanceled);
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<ValueTask<T>> Completed<T>(this IExpectation<ValueTask<T>> expectation) => expectation.Expect(task => task.IsCompleted);
}