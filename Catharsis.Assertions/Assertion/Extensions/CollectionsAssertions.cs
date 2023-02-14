using System.Collections.Specialized;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for collections types.</para>
/// </summary>
/// <seealso cref="ICollection{T}"/>
/// <seealso cref="NameValueCollection"/>
public static class CollectionsAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="collection"></param>
  /// <param name="count"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Count(IAssertion, NameValueCollection, int, string)"/>
  public static IAssertion Count<T>(this IAssertion assertion, ICollection<T> collection, int count, string error = null) => collection is not null ? assertion.True(collection.Count == count, error) : throw new ArgumentNullException(nameof(collection));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="collection"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Empty(IAssertion, NameValueCollection, string)"/>
  public static IAssertion Empty<T>(this IAssertion assertion, ICollection<T> collection, string error = null) => assertion.Count(collection, 0, error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="collection"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ReadOnly<T>(this IAssertion assertion, ICollection<T> collection, string error = null) => collection is not null ? assertion.True(collection.IsReadOnly, error) : throw new ArgumentNullException(nameof(collection));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="collection"></param>
  /// <param name="count"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Count{T}(IAssertion, ICollection{T}, int, string)"/>
  public static IAssertion Count(this IAssertion assertion, NameValueCollection collection, int count, string error = null) => collection is not null ? assertion.True(collection.Count == count, error) : throw new ArgumentNullException(nameof(collection));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="collection"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Empty{T}(IAssertion, ICollection{T}, string)"/>
  public static IAssertion Empty(this IAssertion assertion, NameValueCollection collection, string error = null) => assertion.Count(collection, 0, error);
}