using System.Xml;
using Catharsis.Extensions;
using Catharsis.Fixture;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlNodeAssertions"/>.</para>
/// </summary>
/// <seealso cref="XmlNodeAssertions"/>
public sealed class XmlNodeAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeAssertions.Empty(IAssertion, XmlNode, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeAssertions.Empty(null, new XmlDocument())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => XmlNodeAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("node");

      Test(true, new XmlDocument());
      Test(false, new XmlDocument().With(document => document.With(document.CreateElement("root"))));
    }

    return;

    static void Test(bool result, XmlNode node)
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
      AssertionExtensions.Should(() => XmlNodeAssertions.Name(null, new XmlDocument(), "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Name(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
      AssertionExtensions.Should(() => Assert.To.Name(new XmlDocument(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

      new XmlDocument().CreateElement("root").With(node => Test(true, node, node.Name));
      new XmlDocument().CreateElement("root").With(node => Test(false, node, Fixture<string>.Create()));
    }

    return;

    static void Test(bool result, XmlNode node, string name)
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
      AssertionExtensions.Should(() => XmlNodeAssertions.InnerText(null, new XmlDocument(), "text")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.InnerText(null, "text")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
      AssertionExtensions.Should(() => Assert.To.InnerText(new XmlDocument(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

      new XmlDocument().CreateElement("root").With(node => Test(true, node, node.InnerText));
      new XmlDocument().CreateElement("root").With(node => Test(false, node, Fixture<string>.Create()));
    }

    return;

    static void Test(bool result, XmlNode node, string text)
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
      AssertionExtensions.Should(() => XmlNodeAssertions.InnerXml(null, new XmlDocument(), "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.InnerXml(null, "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
      AssertionExtensions.Should(() => Assert.To.InnerXml(new XmlDocument(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("xml");

      new XmlDocument().CreateElement("root").With(node => Test(true, node, node.InnerXml));
      new XmlDocument().CreateElement("root").With(node => Test(false, node, Fixture<string>.Create()));
    }

    return;

    static void Test(bool result, XmlNode node, string xml)
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
      AssertionExtensions.Should(() => XmlNodeAssertions.OuterXml(null, new XmlDocument(), "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.OuterXml(null, "xml")).ThrowExactly<ArgumentNullException>().WithParameterName("node");
      AssertionExtensions.Should(() => Assert.To.OuterXml(new XmlDocument(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("xml");

      new XmlDocument().CreateElement("root").With(node => Test(true, node, node.OuterXml));
      new XmlDocument().CreateElement("root").With(node => Test(false, node, Fixture<string>.Create()));
    }

    return;

    static void Test(bool result, XmlNode node, string xml)
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
      AssertionExtensions.Should(() => XmlNodeAssertions.Value(null, new XmlDocument(), string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Value((XmlNode) null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("node");

      new XmlDocument().CreateElement("root").With(node => Test(true, node, node.Value));
      new XmlDocument().CreateElement("root").With(node => Test(false, node, Fixture<string>.Create()));
    }

    return;

    static void Test(bool result, XmlNode node, string value)
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