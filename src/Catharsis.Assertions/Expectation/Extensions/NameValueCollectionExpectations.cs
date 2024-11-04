using System.Collections.Specialized;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="NameValueCollection"/> type.</para>
/// </summary>
/// <seealso cref="NameValueCollection"/>
public static class NameValueCollectionExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="NameValueCollection"/> has a specified number of elements.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="count">Expected number of elements.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<NameValueCollection> Count(this IExpectation<NameValueCollection> expectation, int count) => expectation.HaveSubject().And().Expected(collection => collection.Count == count);

  /// <summary>
  ///   <para>Expects that the given <see cref="NameValueCollection"/> is empty, meaning it contains no elements.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<NameValueCollection> Empty(this IExpectation<NameValueCollection> expectation) => expectation.Count(0);
}