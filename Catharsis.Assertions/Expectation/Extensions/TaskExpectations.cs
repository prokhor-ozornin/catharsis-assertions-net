namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="Task"/>
public static class TaskExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Successful{T}(IExpectation{Task{T}})"/>
  public static IExpectation<Task> Successful(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCompletedSuccessfully);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Unsuccessful{T}(IExpectation{Task{T}})"/>
  public static IExpectation<Task> Unsuccessful(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expected(task => task.IsFaulted);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Canceled{T}(IExpectation{Task{T}})"/>
  public static IExpectation<Task> Canceled(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCanceled);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Completed{T}(IExpectation{Task{T}})"/>
  public static IExpectation<Task> Completed(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCompleted);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <param name="exception"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Exception(IExpectation{Task}, AggregateException)"/>
  public static IExpectation<Task<T>> Exception<T>(this IExpectation<Task<T>> expectation, AggregateException exception) => expectation.HaveSubject().And().Expected(task => Equals(task.Exception, exception));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Successful(IExpectation{Task})"/>
  public static IExpectation<Task<T>> Successful<T>(this IExpectation<Task<T>> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCompletedSuccessfully);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Unsuccessful(IExpectation{Task})"/>
  public static IExpectation<Task<T>> Unsuccessful<T>(this IExpectation<Task<T>> expectation) => expectation.HaveSubject().And().Expected(task => task.IsFaulted);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Canceled(IExpectation{Task})"/>
  public static IExpectation<Task<T>> Canceled<T>(this IExpectation<Task<T>> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCanceled);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Completed(IExpectation{Task})"/>
  public static IExpectation<Task<T>> Completed<T>(this IExpectation<Task<T>> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCompleted);
}