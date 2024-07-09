using System.Collections.Specialized;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="NameValueCollection"/> type.</para>
/// </summary>
/// <seealso cref="NameValueCollection"/>
public static class NameValueCollectionExpectations
{
  /// <summary>
  ///   <para>Expects that a given collection contains a specified number of elements.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="count">Expected elements count.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<NameValueCollection> Count(this IExpectation<NameValueCollection> expectation, int count) => expectation.HaveSubject().And().Expected(collection => collection.Count == count);

  /// <summary>
  ///   <para>This function asserts that the given collection is empty (contains no elements).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<NameValueCollection> Empty(this IExpectation<NameValueCollection> expectation) => expectation.Count(0);
}