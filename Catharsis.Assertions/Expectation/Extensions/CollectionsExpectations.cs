using System.Collections.Specialized;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="ICollection{T}"/>
/// <seealso cref="NameValueCollection"/>
public static class CollectionsExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="count"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Count(IExpectation{NameValueCollection}, int)"/>
  public static IExpectation<ICollection<T>> Count<T>(this IExpectation<ICollection<T>> expectation, int count) => expectation.HaveSubject().And().Expected(collection => collection.Count == count);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Empty(IExpectation{NameValueCollection})"/>
  public static IExpectation<ICollection<T>> Empty<T>(this IExpectation<ICollection<T>> expectation) => expectation.Count(0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T">Type of expectation's subject.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<ICollection<T>> ReadOnly<T>(this IExpectation<ICollection<T>> expectation) => expectation.HaveSubject().And().Expected(collection => collection.IsReadOnly);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="count"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Count{T}(IExpectation{ICollection{T}}, int)"/>
  public static IExpectation<NameValueCollection> Count(this IExpectation<NameValueCollection> expectation, int count) => expectation.HaveSubject().And().Expected(collection => collection.Count == count);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Empty{T}(IExpectation{ICollection{T}})"/>
  public static IExpectation<NameValueCollection> Empty(this IExpectation<NameValueCollection> expectation) => expectation.Count(0);
}