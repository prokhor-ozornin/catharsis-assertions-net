using System.Xml;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeAssertions.Empty(null, Node)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => XmlNodeAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("node");

      Node.With(node =>
      {
        node.AppendChild(Node.OwnerDocument.CreateElement("element"));
        AssertionExtensions.Should(() => Assert.To.Empty(Node, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      });
    }

    return;

    static void Validate(bool result, XmlNode node)
    {
      if (result)
      {
        Assert.To.Empty(node, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Empty(node, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.Name(IAssertion, XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeAssertions.Name(null, Node, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Name(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
      AssertionExtensions.Should(() => Assert.To.Name(Node, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");
    }

    return;

    static void Validate(bool result, XmlNode node, string name)
    {
      if (result)
      {
        Assert.To.Name(node, name).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Name(node, name, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.InnerText(IAssertion, XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InnerText_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeAssertions.InnerText(null, Node, "text")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.InnerText(null, "text")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
      AssertionExtensions.Should(() => Assert.To.InnerText(Node, null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");
    }

    return;

    static void Validate(bool result, XmlNode node, string text)
    {
      if (result)
      {
        Assert.To.InnerText(node, text).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.InnerText(node, text, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.InnerXml(IAssertion, XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InnerXml_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeAssertions.InnerXml(null, Node, "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.InnerXml(null, "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
      AssertionExtensions.Should(() => Assert.To.InnerXml(Node, null)).ThrowExactly<ArgumentNullException>().WithParameterName("xml");
    }

    return;

    static void Validate(bool result, XmlNode node, string xml)
    {
      if (result)
      {
        Assert.To.InnerXml(node, xml).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.InnerXml(node, xml, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.OuterXml(IAssertion, XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void OuterXml_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeAssertions.OuterXml(null, Node, "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.OuterXml(null, "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
      AssertionExtensions.Should(() => Assert.To.OuterXml(Node, null)).ThrowExactly<ArgumentNullException>().WithParameterName("xml");
    }

    return;

    static void Validate(bool result, XmlNode node, string xml)
    {
      if (result)
      {
        Assert.To.OuterXml(node, xml).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.OuterXml(node, xml, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.Value(IAssertion, XmlNode, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeAssertions.Value(null, Node, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Value((XmlNode) null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("node");
    }

    return;

    static void Validate(bool result, XmlNode node, string value)
    {
      if (result)
      {
        Assert.To.Value(node, value).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Value(node, value, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}