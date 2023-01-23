using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class XDocumentAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="document"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion Empty(this IAssertion assertion, XDocument document, string message = null) => document is not null ? assertion.Empty(document.Nodes(), message) : throw new ArgumentNullException(nameof(document));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="document"></param>
  /// <param name="name"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Name(this IAssertion assertion, XDocument document, XName name, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (document is null) throw new ArgumentNullException(nameof(document));
    if (name is null) throw new ArgumentNullException(nameof(name));

    return assertion.True(document.Root?.Name == name, message);
  }
}