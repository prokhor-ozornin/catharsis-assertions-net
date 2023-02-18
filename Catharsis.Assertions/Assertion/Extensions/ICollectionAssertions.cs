namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="ICollection{T}"/> types.</para>
/// </summary>
/// <seealso cref="ICollection{T}"/>
public static class ICollectionAssertions
{
  /// <summary>
  ///   <para>Asserts that a given collection contains a specified number of elements.</para>
  /// </summary>
  /// <typeparam name="T">Type of elements inside the collection.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="collection">Collection to inspect.</param>
  /// <param name="count">Expected amount of elements.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="collection"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Count<T>(this IAssertion assertion, ICollection<T> collection, int count, string error = null) => collection is not null ? assertion.True(collection.Count == count, error) : throw new ArgumentNullException(nameof(collection));

  /// <summary>
  ///   <para>Asserts that a given collection is empty (contains no elements).</para>
  /// </summary>
  /// <typeparam name="T">Type of elements inside the collection.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="collection">Collection to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="collection"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty<T>(this IAssertion assertion, ICollection<T> collection, string error = null) => assertion.Count(collection, 0, error);

  /// <summary>
  ///   <para>Asserts that a given collection is read-only (does not allow modifications).</para>
  /// </summary>
  /// <typeparam name="T">Type of elements inside the collection.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="collection">Collection to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="collection"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ReadOnly<T>(this IAssertion assertion, ICollection<T> collection, string error = null) => collection is not null ? assertion.True(collection.IsReadOnly, error) : throw new ArgumentNullException(nameof(collection));
}