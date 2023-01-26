using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="XmlDocument"/>
public static class XmlDocumentAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="document"></param>
  /// <param name="name"></param>
  /// <param name="uri"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Element(this IAssertion assertion, XmlDocument document, string name, string uri = null, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (document is null) throw new ArgumentNullException(nameof(document));
    if (name is null) throw new ArgumentNullException(nameof(name));

    var elements = uri is not null ? document.GetElementsByTagName(name, uri) : document.GetElementsByTagName(name);

    return assertion.Greater(elements.Count, 0, message);
  }
}