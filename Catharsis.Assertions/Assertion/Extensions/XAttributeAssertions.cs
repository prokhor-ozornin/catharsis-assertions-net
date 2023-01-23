using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class XAttributeAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="attribute"></param>
  /// <param name="name"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Name(this IAssertion assertion, XAttribute attribute, XName name, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (attribute is null) throw new ArgumentNullException(nameof(attribute));
    if (name is null) throw new ArgumentNullException(nameof(name));

    return assertion.True(attribute.Name == name, message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="attribute"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Value(this IAssertion assertion, XAttribute attribute, string value, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (attribute is null) throw new ArgumentNullException(nameof(attribute));
    if (value is null) throw new ArgumentNullException(nameof(value));

    return assertion.True(attribute.Value == value, message);
  }
}