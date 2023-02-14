using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="XmlNode"/>
public static class XmlNodeExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<XmlNode> Empty(this IExpectation<XmlNode> expectation) => expectation.HaveSubject().And().Expected(node => !node.HasChildNodes);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="name"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<XmlNode> Name(this IExpectation<XmlNode> expectation, string name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(node => node.Name == name);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="text"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<XmlNode> InnerText(this IExpectation<XmlNode> expectation, string text) => expectation.HaveSubject().And().ThrowIfNull(text, nameof(text)).And().Expected(node => node.InnerText == text);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="xml"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="OuterXml(IExpectation{XmlNode}, string)"/>
  public static IExpectation<XmlNode> InnerXml(this IExpectation<XmlNode> expectation, string xml) => expectation.HaveSubject().And().ThrowIfNull(xml, nameof(xml)).And().Expected(node => node.InnerXml == xml);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="xml"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="InnerXml(IExpectation{XmlNode}, string)"/>
  public static IExpectation<XmlNode> OuterXml(this IExpectation<XmlNode> expectation, string xml) => expectation.HaveSubject().And().ThrowIfNull(xml, nameof(xml)).And().Expected(node => node.OuterXml == xml);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="value"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<XmlNode> Value(this IExpectation<XmlNode> expectation, string value) => expectation.HaveSubject().And().Expected(node => node.Value == value);
}