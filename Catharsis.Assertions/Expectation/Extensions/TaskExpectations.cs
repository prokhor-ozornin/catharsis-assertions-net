namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for tasks types.</para>
/// </summary>
/// <seealso cref="Task"/>
/// <seealso cref="Task{TResult}"/>
public static class TaskExpectations
{
  /// <summary>
  ///   <para>Expects that a given task completed successfully.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Successful{T}(IExpectation{Task{T}})"/>
  public static IExpectation<Task> Successful(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCompletedSuccessfully);

  /// <summary>
  ///   <para>Expects that a given task completed unsuccessfully due to unhandled exception.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Unsuccessful{T}(IExpectation{Task{T}})"/>
  public static IExpectation<Task> Unsuccessful(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expected(task => task.IsFaulted);

  /// <summary>
  ///   <para>Expects that a given task failed to complete due to being cancelled.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Canceled{T}(IExpectation{Task{T}})"/>
  public static IExpectation<Task> Canceled(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCanceled);

  /// <summary>
  ///   <para>Expects that a given task completed, whether successfully or not.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Completed{T}(IExpectation{Task{T}})"/>
  public static IExpectation<Task> Completed(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCompleted);

  /// <summary>
  ///   <para>Expects that a given task ended prematurely due to specified exception.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="exception">Expected exception that caused the task to be aborted, or <see langword="null"/> if the task completed successfully or has not yet thrown exceptions.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Task<T>> Exception<T>(this IExpectation<Task<T>> expectation, AggregateException exception) => expectation.HaveSubject().And().Expected(task => Equals(task.Exception, exception));

  /// <summary>
  ///   <para>Expects that a given task completed successfully.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Successful(IExpectation{Task})"/>
  public static IExpectation<Task<T>> Successful<T>(this IExpectation<Task<T>> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCompletedSuccessfully);

  /// <summary>
  ///   <para>Expects that a given task completed unsuccessfully due to unhandled exception.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Unsuccessful(IExpectation{Task})"/>
  public static IExpectation<Task<T>> Unsuccessful<T>(this IExpectation<Task<T>> expectation) => expectation.HaveSubject().And().Expected(task => task.IsFaulted);

  /// <summary>
  ///   <para>Expects that a given task failed to complete due to being cancelled.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Canceled(IExpectation{Task})"/>
  public static IExpectation<Task<T>> Canceled<T>(this IExpectation<Task<T>> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCanceled);

  /// <summary>
  ///   <para>Expects that a given task completed, whether successfully or not.</para>
  /// </summary>
  /// <typeparam name="T">Type of task result.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Completed(IExpectation{Task})"/>
  public static IExpectation<Task<T>> Completed<T>(this IExpectation<Task<T>> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCompleted);
}