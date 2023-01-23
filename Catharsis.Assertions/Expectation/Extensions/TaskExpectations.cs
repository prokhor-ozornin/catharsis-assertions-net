namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class TaskExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="exception"></param>
  /// <returns></returns>
  public static IExpectation<Task> Exception(this IExpectation<Task> expectation, AggregateException exception) => expectation.HaveSubject().And().Expect(task => Equals(task.Exception, exception));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Task> Successful(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expect(task => task.IsCompletedSuccessfully);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Task> Unsuccessful(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expect(task => task.IsFaulted);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Task> Canceled(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expect(task => task.IsCanceled);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Task> Completed(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expect(task => task.IsCompleted);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="exception"></param>
  /// <returns></returns>
  public static IExpectation<Task> Exception<T>(this IExpectation<Task> expectation, AggregateException exception) => expectation.HaveSubject().And().Expect(task => Equals(task.Exception, exception));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Task> Successful<T>(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expect(task => task.IsCompletedSuccessfully);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Task> Unsuccessful<T>(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expect(task => task.IsFaulted);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Task> Canceled<T>(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expect(task => task.IsCanceled);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Task> Completed<T>(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expect(task => task.IsCompleted);
}