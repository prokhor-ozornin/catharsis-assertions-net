using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="XmlNode"/> type.</para>
/// </summary>
/// <seealso cref="XmlNode"/>
public static class XmlNodeAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="node"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="node"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty(this IAssertion assertion, XmlNode node, string error = null) => node is not null ? assertion.False(node.HasChildNodes, error) : throw new ArgumentNullException(nameof(node));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="node"></param>
  /// <param name="name"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="node"/>, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Name(this IAssertion assertion, XmlNode node, string name, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (node is null) throw new ArgumentNullException(nameof(node));
    if (name is null) throw new ArgumentNullException(nameof(name));

    return assertion.True(node.Name == name, error);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="node"></param>
  /// <param name="text"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="node"/>, or <paramref name="text"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion InnerText(this IAssertion assertion, XmlNode node, string text, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (node is null) throw new ArgumentNullException(nameof(node));
    if (text is null) throw new ArgumentNullException(nameof(text));

    return assertion.True(node.InnerText == text, error);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="node"></param>
  /// <param name="xml"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="node"/>, or <paramref name="xml"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="OuterXml(IAssertion, XmlNode, string, string)"/>
  public static IAssertion InnerXml(this IAssertion assertion, XmlNode node, string xml, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (node is null) throw new ArgumentNullException(nameof(node));
    if (xml is null) throw new ArgumentNullException(nameof(xml));

    return assertion.True(node.InnerXml == xml, error);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="node"></param>
  /// <param name="xml"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="node"/>, or <paramref name="xml"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="InnerXml(IAssertion, XmlNode, string, string)"/>
  public static IAssertion OuterXml(this IAssertion assertion, XmlNode node, string xml, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (node is null) throw new ArgumentNullException(nameof(node));
    if (xml is null) throw new ArgumentNullException(nameof(xml));

    return assertion.True(node.OuterXml == xml, error);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="node"></param>
  /// <param name="value"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="node"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Value(this IAssertion assertion, XmlNode node, string value, string error = null) => node is not null ? assertion.True(node.Value == value, error) : throw new ArgumentNullException(nameof(node));
}