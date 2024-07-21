namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="ICollection{T}"/> types.</para>
/// </summary>
/// <seealso cref="ICollection{T}"/>
public static class ICollectionAssertions
{
  /// <summary>
  ///   <para>This function asserts that the given <see cref="ICollection{T}"/> has a specified number of elements.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the collection.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="collection">Collection to inspect.</param>
  /// <param name="count">Asserted number of elements.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="collection"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Count<T>(this IAssertion assertion, ICollection<T> collection, int count, string error = null) => collection is not null ? assertion.True(collection.Count == count, error) : throw new ArgumentNullException(nameof(collection));

  /// <summary>
  ///   <para>This function asserts that the given <see cref="ICollection{T}"/> is empty, meaning it contains no elements.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the collection.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="collection">Collection to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="collection"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty<T>(this IAssertion assertion, ICollection<T> collection, string error = null) => assertion.Count(collection, 0, error);

  /// <summary>
  ///   <para>This function asserts that the given <see cref="ICollection{T}"/> is read-only.</para>
  /// </summary>
  /// <typeparam name="T">The type of elements in the collection.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="collection">Collection to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="collection"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ReadOnly<T>(this IAssertion assertion, ICollection<T> collection, string error = null) => collection is not null ? assertion.True(collection.IsReadOnly, error) : throw new ArgumentNullException(nameof(collection));
}