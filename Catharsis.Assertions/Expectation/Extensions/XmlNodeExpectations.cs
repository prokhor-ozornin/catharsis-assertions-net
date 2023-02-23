using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="XmlNode"/> type.</para>
/// </summary>
/// <seealso cref="XmlNode"/>
public static class XmlNodeExpectations
{
  /// <summary>
  ///   <para>Expects that a specified XML node is empty (contains no child nodes).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<XmlNode> Empty(this IExpectation<XmlNode> expectation) => expectation.HaveSubject().And().Expected(node => !node.HasChildNodes);

  /// <summary>
  ///   <para>Expects that a given XML node has a specified name.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="name">Expected qualified node name.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<XmlNode> Name(this IExpectation<XmlNode> expectation, string name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(node => node.Name == name);

  /// <summary>
  ///   <para>Expects that a given XML node has a specified inner text.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="text">Expected concatenated value of the node and all its children.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="text"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<XmlNode> InnerText(this IExpectation<XmlNode> expectation, string text) => expectation.HaveSubject().And().ThrowIfNull(text, nameof(text)).And().Expected(node => node.InnerText == text);

  /// <summary>
  ///   <para>Expects that a given XML node has a specified inner XML markup.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="xml">Expected concatenated XML markup of all child nodes.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="xml"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="OuterXml(IExpectation{XmlNode}, string)"/>
  public static IExpectation<XmlNode> InnerXml(this IExpectation<XmlNode> expectation, string xml) => expectation.HaveSubject().And().ThrowIfNull(xml, nameof(xml)).And().Expected(node => node.InnerXml == xml);

  /// <summary>
  ///   <para>Expects that a given XML node has a specified outer XML markup.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="xml">Expected concatenated XML markup of the node and all its children.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="xml"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="InnerXml(IExpectation{XmlNode}, string)"/>
  public static IExpectation<XmlNode> OuterXml(this IExpectation<XmlNode> expectation, string xml) => expectation.HaveSubject().And().ThrowIfNull(xml, nameof(xml)).And().Expected(node => node.OuterXml == xml);

  /// <summary>
  ///   <para>Expects that a given XML node has a specified value.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="value">Expected node value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<XmlNode> Value(this IExpectation<XmlNode> expectation, string value) => expectation.HaveSubject().And().Expected(node => node.Value == value);
}