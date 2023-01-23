using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class XElementAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="element"></param>
  /// <param name="name"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Attribute(this IAssertion assertion, XElement element, XName name, string value = null, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (element is null) throw new ArgumentNullException(nameof(element));
    if (name is null) throw new ArgumentNullException(nameof(name));
    
    var attributes = element.Attributes(name);
    var result = value is not null ? attributes.Any(attribute => attribute.Name == name && attribute.Value == value) : attributes.Any(attribute => attribute.Name == name);

    return assertion.True(result, message);
  }
}