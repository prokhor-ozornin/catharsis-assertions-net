using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="XmlNode"/>
public static class XmlNodeAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="node"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Empty(this IAssertion assertion, XmlNode node, string message = null) => node is not null ? assertion.False(node.HasChildNodes, message) : throw new ArgumentNullException(nameof(node));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="node"></param>
  /// <param name="name"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Name(this IAssertion assertion, XmlNode node, string name, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (node is null) throw new ArgumentNullException(nameof(node));
    if (name is null) throw new ArgumentNullException(nameof(name));

    return assertion.True(node.Name == name, message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="node"></param>
  /// <param name="text"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion InnerText(this IAssertion assertion, XmlNode node, string text, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (node is null) throw new ArgumentNullException(nameof(node));
    if (text is null) throw new ArgumentNullException(nameof(text));

    return assertion.True(node.InnerText == text, message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="node"></param>
  /// <param name="xml"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="OuterXml(IAssertion, XmlNode, string, string)"/>
  public static IAssertion InnerXml(this IAssertion assertion, XmlNode node, string xml, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (node is null) throw new ArgumentNullException(nameof(node));
    if (xml is null) throw new ArgumentNullException(nameof(xml));

    return assertion.True(node.InnerXml == xml, message);
  }
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="node"></param>
  /// <param name="xml"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="InnerXml(IAssertion, XmlNode, string, string)"/>
  public static IAssertion OuterXml(this IAssertion assertion, XmlNode node, string xml, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (node is null) throw new ArgumentNullException(nameof(node));
    if (xml is null) throw new ArgumentNullException(nameof(xml));

    return assertion.True(node.OuterXml == xml, message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="node"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Value(this IAssertion assertion, XmlNode node, string value, string message = null) => node is not null ? assertion.True(node.Value == value, message) : throw new ArgumentNullException(nameof(node));
}