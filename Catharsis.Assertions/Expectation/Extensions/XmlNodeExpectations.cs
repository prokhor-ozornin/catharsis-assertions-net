using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="XmlNode"/> type.</para>
/// </summary>
/// <seealso cref="XmlNode"/>
public static class XmlNodeExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="XmlNode"/> is empty, meaning it contains no child nodes.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<XmlNode> Empty(this IExpectation<XmlNode> expectation) => expectation.HaveSubject().And().Expected(node => !node.HasChildNodes);

  /// <summary>
  ///   <para>Expects that the given <see cref="XmlNode"/> has a specified name.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="name">Expected node name.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="name"/> is <see langword="null"/>.</exception>
  public static IExpectation<XmlNode> Name(this IExpectation<XmlNode> expectation, string name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(node => node.Name == name);

  /// <summary>
  ///   <para>Expects that the given <see cref="XmlNode"/> has a specified inner text.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="text">Expected inner text.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="text"/> is <see langword="null"/>.</exception>
  public static IExpectation<XmlNode> InnerText(this IExpectation<XmlNode> expectation, string text) => expectation.HaveSubject().And().ThrowIfNull(text, nameof(text)).And().Expected(node => node.InnerText == text);

  /// <summary>
  ///   <para>Expects that the given <see cref="XmlNode"/> has a specified inner XML markup.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="xml">Expected XML markup.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="xml"/> is <see langword="null"/>.</exception>
  /// <seealso cref="OuterXml(IExpectation{XmlNode}, string)"/>
  public static IExpectation<XmlNode> InnerXml(this IExpectation<XmlNode> expectation, string xml) => expectation.HaveSubject().And().ThrowIfNull(xml, nameof(xml)).And().Expected(node => node.InnerXml == xml);

  /// <summary>
  ///   <para>Expects that the given <see cref="XmlNode"/> has a specified outer XML markup.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="xml">Expected XML markup.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="xml"/> is <see langword="null"/>.</exception>
  /// <seealso cref="InnerXml(IExpectation{XmlNode}, string)"/>
  public static IExpectation<XmlNode> OuterXml(this IExpectation<XmlNode> expectation, string xml) => expectation.HaveSubject().And().ThrowIfNull(xml, nameof(xml)).And().Expected(node => node.OuterXml == xml);

  /// <summary>
  ///   <para>Expects that the given <see cref="XmlNode"/> has a specified value.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="value">Expected node value.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<XmlNode> Value(this IExpectation<XmlNode> expectation, string value) => expectation.HaveSubject().And().Expected(node => node.Value == value);
}