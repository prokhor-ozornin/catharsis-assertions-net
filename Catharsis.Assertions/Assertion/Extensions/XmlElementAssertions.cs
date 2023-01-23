using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class XmlElementAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="element"></param>
  /// <param name="name"></param>
  /// <param name="uri"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Attribute(this IAssertion assertion, XmlElement element, string name, string uri = null, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (element is null) throw new ArgumentNullException(nameof(element));
    if (name is null) throw new ArgumentNullException(nameof(name));

    return assertion.True(element.HasAttribute(name, uri), message);
  }
}