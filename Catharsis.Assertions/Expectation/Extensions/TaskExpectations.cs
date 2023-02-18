﻿namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for tasks types.</para>
/// </summary>
/// <seealso cref="Task"/>
/// <seealso cref="Task{TResult}"/>
public static class TaskExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Successful{T}(IExpectation{Task{T}})"/>
  public static IExpectation<Task> Successful(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCompletedSuccessfully);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Unsuccessful{T}(IExpectation{Task{T}})"/>
  public static IExpectation<Task> Unsuccessful(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expected(task => task.IsFaulted);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Canceled{T}(IExpectation{Task{T}})"/>
  public static IExpectation<Task> Canceled(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCanceled);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Completed{T}(IExpectation{Task{T}})"/>
  public static IExpectation<Task> Completed(this IExpectation<Task> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCompleted);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="exception"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Task<T>> Exception<T>(this IExpectation<Task<T>> expectation, AggregateException exception) => expectation.HaveSubject().And().Expected(task => Equals(task.Exception, exception));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Successful(IExpectation{Task})"/>
  public static IExpectation<Task<T>> Successful<T>(this IExpectation<Task<T>> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCompletedSuccessfully);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Unsuccessful(IExpectation{Task})"/>
  public static IExpectation<Task<T>> Unsuccessful<T>(this IExpectation<Task<T>> expectation) => expectation.HaveSubject().And().Expected(task => task.IsFaulted);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Canceled(IExpectation{Task})"/>
  public static IExpectation<Task<T>> Canceled<T>(this IExpectation<Task<T>> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCanceled);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Completed(IExpectation{Task})"/>
  public static IExpectation<Task<T>> Completed<T>(this IExpectation<Task<T>> expectation) => expectation.HaveSubject().And().Expected(task => task.IsCompleted);
}