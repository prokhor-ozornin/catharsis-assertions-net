using System.Xml;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class XmlNodeExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<XmlNode> Empty(this IExpectation<XmlNode> expectation) => expectation.HaveSubject().And().Expect(node => !node.HasChildNodes);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="name"></param>
  /// <returns></returns>
  public static IExpectation<XmlNode> Name(this IExpectation<XmlNode> expectation, string name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expect(node => node.Name == name);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="text"></param>
  /// <returns></returns>
  public static IExpectation<XmlNode> InnerText(this IExpectation<XmlNode> expectation, string text) => expectation.HaveSubject().And().ThrowIfNull(text, nameof(text)).And().Expect(node => node.InnerText == text);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="xml"></param>
  /// <returns></returns>
  public static IExpectation<XmlNode> InnerXml(this IExpectation<XmlNode> expectation, string xml) => expectation.HaveSubject().And().ThrowIfNull(xml, nameof(xml)).And().Expect(node => node.InnerXml == xml);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="xml"></param>
  /// <returns></returns>
  public static IExpectation<XmlNode> OuterXml(this IExpectation<XmlNode> expectation, string xml) => expectation.HaveSubject().And().ThrowIfNull(xml, nameof(xml)).And().Expect(node => node.OuterXml == xml);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="value"></param>
  /// <returns></returns>
  public static IExpectation<XmlNode> Value(this IExpectation<XmlNode> expectation, string value) => expectation.HaveSubject().And().ThrowIfNull(value, nameof(value)).And().Expect(node => node.Value == value);
}