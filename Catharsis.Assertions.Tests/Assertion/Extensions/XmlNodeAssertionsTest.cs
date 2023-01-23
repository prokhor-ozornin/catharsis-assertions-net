using System.Xml;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlNodeAssertions"/>.</para>
/// </summary>
public sealed class XmlNodeAssertionsTest : UnitTest
{
  private XmlNode Node { get; } = new XmlDocument().CreateElement("root");

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.Empty(IAssertion, System.Xml.XmlNode, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => XmlNodeAssertions.Empty(null, Node)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => XmlNodeAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("node");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.Name(IAssertion, System.Xml.XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    AssertionExtensions.Should(() => XmlNodeAssertions.Name(null, Node, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Name(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
    AssertionExtensions.Should(() => Assert.To.Name(Node, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.InnerText(IAssertion, System.Xml.XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InnerText_Method()
  {
    AssertionExtensions.Should(() => XmlNodeAssertions.InnerText(null, Node, "text")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.InnerText(null, "text")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
    AssertionExtensions.Should(() => Assert.To.InnerText(Node, null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.InnerXml(IAssertion, System.Xml.XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InnerXml_Method()
  {
    AssertionExtensions.Should(() => XmlNodeAssertions.InnerXml(null, Node, "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.InnerXml(null, "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
    AssertionExtensions.Should(() => Assert.To.InnerXml(Node, null)).ThrowExactly<ArgumentNullException>().WithParameterName("xml");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.OuterXml(IAssertion, System.Xml.XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void OuterXml_Method()
  {
    AssertionExtensions.Should(() => XmlNodeAssertions.OuterXml(null, Node, "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.OuterXml(null, "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
    AssertionExtensions.Should(() => Assert.To.OuterXml(Node, null)).ThrowExactly<ArgumentNullException>().WithParameterName("xml");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.Value(IAssertion, System.Xml.XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    AssertionExtensions.Should(() => XmlNodeAssertions.Value(null, Node, null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Value(Node, null)).ThrowExactly<ArgumentNullException>().WithParameterName("node");

    throw new NotImplementedException();
  }
}