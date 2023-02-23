using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="XmlDocument"/> type.</para>
/// </summary>
/// <seealso cref="XmlDocument"/>
public static class XmlDocumentAssertions
{
  /// <summary>
  ///   <para>Asserts that a given XML document contains a child element with a specified name.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="document">XML document to inspect.</param>
  /// <param name="name">Asserted element name.</param>
  /// <param name="uri">Asserted element namespace URI.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="document"/>, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Element(this IAssertion assertion, XmlDocument document, string name, string uri = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (document is null) throw new ArgumentNullException(nameof(document));
    if (name is null) throw new ArgumentNullException(nameof(name));

    var elements = uri is not null ? document.GetElementsByTagName(name, uri) : document.GetElementsByTagName(name);

    return assertion.Greater(elements.Count, 0, error);
  }
}