﻿namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="ValueTask"/> type.</para>
/// </summary>
/// <seealso cref="ValueTask"/>
/// <seealso cref="ValueTask{TResult}"/>
public static class ValueTaskExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Successful{T}(IExpectation{ValueTask{T}})"/>
  public static IExpectation<ValueTask> Successful(this IExpectation<ValueTask> expectation) => expectation.Expected(task => task.IsCompletedSuccessfully);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Unsuccessful{T}(IExpectation{ValueTask{T}})"/>
  public static IExpectation<ValueTask> Unsuccessful(this IExpectation<ValueTask> expectation) => expectation.Expected(task => task.IsFaulted);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Canceled{T}(IExpectation{ValueTask{T}})"/>
  public static IExpectation<ValueTask> Canceled(this IExpectation<ValueTask> expectation) => expectation.Expected(task => task.IsCanceled);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Completed{T}(IExpectation{ValueTask{T}})"/>
  public static IExpectation<ValueTask> Completed(this IExpectation<ValueTask> expectation) => expectation.Expected(task => task.IsCompleted);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Successful(IExpectation{ValueTask})"/>
  public static IExpectation<ValueTask<T>> Successful<T>(this IExpectation<ValueTask<T>> expectation) => expectation.Expected(task => task.IsCompletedSuccessfully);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Unsuccessful(IExpectation{ValueTask})"/>
  public static IExpectation<ValueTask<T>> Unsuccessful<T>(this IExpectation<ValueTask<T>> expectation) => expectation.Expected(task => task.IsFaulted);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Canceled(IExpectation{ValueTask})"/>
  public static IExpectation<ValueTask<T>> Canceled<T>(this IExpectation<ValueTask<T>> expectation) => expectation.Expected(task => task.IsCanceled);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Completed(IExpectation{ValueTask})"/>
  public static IExpectation<ValueTask<T>> Completed<T>(this IExpectation<ValueTask<T>> expectation) => expectation.Expected(task => task.IsCompleted);
}