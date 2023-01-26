using System.Xml;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlNodeExpectations"/>.</para>
/// </summary>
public sealed class XmlNodeExpectationsTest : UnitTest
{
  private XmlNode Node { get; } = new XmlDocument().CreateElement("root");

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeExpectations.Empty(IExpectation{XmlNode})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => XmlNodeExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XmlNode) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeExpectations.Name(IExpectation{XmlNode}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    AssertionExtensions.Should(() => XmlNodeExpectations.Name(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XmlNode) null).Expect().Name("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Node.Expect().Name(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeExpectations.InnerText(IExpectation{XmlNode}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InnerText_Method()
  {
    AssertionExtensions.Should(() => XmlNodeExpectations.InnerText(null, "text")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XmlNode) null).Expect().InnerText("text")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Node.Expect().InnerText(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeExpectations.InnerXml(IExpectation{XmlNode}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InnerXml_Method()
  {
    AssertionExtensions.Should(() => XmlNodeExpectations.InnerXml(null, "text")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XmlNode) null).Expect().InnerXml("text")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Node.Expect().InnerXml(null)).ThrowExactly<ArgumentNullException>().WithParameterName("xml");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeExpectations.OuterXml(IExpectation{XmlNode}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void OuterXml_Method()
  {
    AssertionExtensions.Should(() => XmlNodeExpectations.OuterXml(null, "text")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XmlNode) null).Expect().OuterXml("text")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Node.Expect().OuterXml(null)).ThrowExactly<ArgumentNullException>().WithParameterName("xml");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeExpectations.Value(IExpectation{XmlNode}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    AssertionExtensions.Should(() => XmlNodeExpectations.Value(null, "value")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XmlNode) null).Expect().Value("value")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Node.Expect().Value(null)).ThrowExactly<ArgumentNullException>().WithParameterName("value");

    throw new NotImplementedException();
  }
}