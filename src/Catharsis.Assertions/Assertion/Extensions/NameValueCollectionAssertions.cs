using System.Collections.Specialized;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="NameValueCollection"/> type.</para>
/// </summary>
/// <seealso cref="NameValueCollection"/>
public static class NameValueCollectionAssertions
{
  /// <param name="assertion">Assertion to validate.</param>
  extension(IAssertion assertion)
  {
    /// <summary>
    ///   <para>Asserts that the given <see cref="NameValueCollection"/> has a specified number of elements.</para>
    /// </summary>
    /// <param name="collection">Collection to inspect.</param>
    /// <param name="count">Asserted number of elements.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="collection"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Count(NameValueCollection collection, int count, string error = null) => collection is not null ? assertion.True(collection.Count == count, error) : throw new ArgumentNullException(nameof(collection));

    /// <summary>
    ///   <para>Asserts that the given <see cref="NameValueCollection"/> is empty, meaning it contains no elements.</para>
    /// </summary>
    /// <param name="collection">Collection to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="collection"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Empty(NameValueCollection collection, string error = null) => assertion.Count(collection, 0, error);
  }
}