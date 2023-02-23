using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="XDocument"/> type.</para>
/// </summary>
/// <seealso cref="XDocument"/>
public static class XDocumentAssertions
{
  /// <summary>
  ///   <para>Asserts that a given XML document is empty (contains no child nodes).</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="document">XML document to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="document"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty(this IAssertion assertion, XDocument document, string error = null) => document is not null ? assertion.Empty(document.Nodes(), error) : throw new ArgumentNullException(nameof(document));

  /// <summary>
  ///   <para>Asserts that a given XML document has a root element with a specified name.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="document">XML document to inspect.</param>
  /// <param name="name">Asserted expanded element name.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="document"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Name(this IAssertion assertion, XDocument document, XName name, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (document is null) throw new ArgumentNullException(nameof(document));

    return assertion.True(document.Root?.Name == name, error);
  }
}