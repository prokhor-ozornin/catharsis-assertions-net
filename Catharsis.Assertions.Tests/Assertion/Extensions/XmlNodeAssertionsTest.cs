using System.Xml;
using Catharsis.Commons;
using Catharsis.Extensions;
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
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.Empty(IAssertion, XmlNode, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => XmlNodeAssertions.Empty(null, Node)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => XmlNodeAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("node");

    Assert.To.Empty(Node, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);

    Node.With(node =>
    {
      node.AppendChild(Node.OwnerDocument.CreateElement("element"));
      AssertionExtensions.Should(() => Assert.To.Empty(Node, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.Name(IAssertion, XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    AssertionExtensions.Should(() => XmlNodeAssertions.Name(null, Node, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Name(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
    AssertionExtensions.Should(() => Assert.To.Name(Node, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    AssertionExtensions.Should(() => Assert.To.Name(Node, Attributes.RandomString(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Name(Node, Node.Name).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.InnerText(IAssertion, XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InnerText_Method()
  {
    AssertionExtensions.Should(() => XmlNodeAssertions.InnerText(null, Node, "text")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.InnerText(null, "text")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
    AssertionExtensions.Should(() => Assert.To.InnerText(Node, null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

    AssertionExtensions.Should(() => Assert.To.InnerText(Node, Attributes.RandomString(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.InnerText(Node, Node.InnerText).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.InnerXml(IAssertion, XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InnerXml_Method()
  {
    AssertionExtensions.Should(() => XmlNodeAssertions.InnerXml(null, Node, "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.InnerXml(null, "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
    AssertionExtensions.Should(() => Assert.To.InnerXml(Node, null)).ThrowExactly<ArgumentNullException>().WithParameterName("xml");

    AssertionExtensions.Should(() => Assert.To.InnerXml(Node, Attributes.RandomString(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.InnerXml(Node, Node.InnerXml).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.OuterXml(IAssertion, XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void OuterXml_Method()
  {
    AssertionExtensions.Should(() => XmlNodeAssertions.OuterXml(null, Node, "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.OuterXml(null, "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
    AssertionExtensions.Should(() => Assert.To.OuterXml(Node, null)).ThrowExactly<ArgumentNullException>().WithParameterName("xml");

    AssertionExtensions.Should(() => Assert.To.OuterXml(Node, Attributes.RandomString(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.OuterXml(Node, Node.OuterXml).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.Value(IAssertion, XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    AssertionExtensions.Should(() => XmlNodeAssertions.Value(null, Node, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Value((XmlNode) null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("node");

    AssertionExtensions.Should(() => Assert.To.Value(Node, Attributes.RandomString(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Value(Node, Node.Value).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
  }
}