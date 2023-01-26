﻿using System.Xml;

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
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<XmlNode> Empty(this IExpectation<XmlNode> expectation) => expectation.HaveSubject().And().Expected(node => !node.HasChildNodes);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="name"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<XmlNode> Name(this IExpectation<XmlNode> expectation, string name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(node => node.Name == name);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="text"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<XmlNode> InnerText(this IExpectation<XmlNode> expectation, string text) => expectation.HaveSubject().And().ThrowIfNull(text, nameof(text)).And().Expected(node => node.InnerText == text);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="xml"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="OuterXml(IExpectation{XmlNode}, string)"/>
  public static IExpectation<XmlNode> InnerXml(this IExpectation<XmlNode> expectation, string xml) => expectation.HaveSubject().And().ThrowIfNull(xml, nameof(xml)).And().Expected(node => node.InnerXml == xml);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="xml"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="InnerXml(IExpectation{XmlNode}, string)"/>
  public static IExpectation<XmlNode> OuterXml(this IExpectation<XmlNode> expectation, string xml) => expectation.HaveSubject().And().ThrowIfNull(xml, nameof(xml)).And().Expected(node => node.OuterXml == xml);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="value"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<XmlNode> Value(this IExpectation<XmlNode> expectation, string value) => expectation.HaveSubject().And().ThrowIfNull(value, nameof(value)).And().Expected(node => node.Value == value);
}