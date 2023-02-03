using System.Xml;
using System.Xml.Linq;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlProtections"/>.</para>
/// </summary>
public sealed class XmlProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XmlProtections.Empty(IProtection, XmlDocument, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_XmlDocument_Method()
  {
    AssertionExtensions.Should(() => XmlProtections.Empty(null, new XmlDocument())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((XmlDocument) null)).ThrowExactly<ArgumentNullException>().WithParameterName("document");

    AssertionExtensions.Should(() => Protect.From.Empty(new XmlDocument(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    
    new XmlDocument().With(document =>
    {
      document.AppendChild(document.CreateElement("root"));
      Protect.From.Empty(document).Should().NotBeNull().And.BeSameAs(document);
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlProtections.Empty(IProtection, XmlNode, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_XmlNode_Method()
  {
    AssertionExtensions.Should(() => XmlProtections.Empty(null, new XmlDocument().CreateElement("element"))).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((XmlNode) null)).ThrowExactly<ArgumentNullException>().WithParameterName("node");

    var document = new XmlDocument();

    AssertionExtensions.Should(() => Protect.From.Empty(document.CreateElement("root"), "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    document.CreateElement("root").With(node =>
    {
      node.AppendChild(document.CreateElement("element"));
      Protect.From.Empty(node).Should().NotBeNull().And.BeSameAs(node);
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlProtections.Empty(IProtection, XDocument, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_XDocument_Method()
  {
    AssertionExtensions.Should(() => XmlProtections.Empty(null, new XDocument())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((XDocument) null)).ThrowExactly<ArgumentNullException>().WithParameterName("document");

    AssertionExtensions.Should(() => Protect.From.Empty(new XDocument(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    
    new XDocument().With(document =>
    {
      document.Add(new XElement("root"));
      Protect.From.Empty(document).Should().NotBeNull().And.BeSameAs(document);
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlProtections.Empty(IProtection, XContainer, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_XContainer_Method()
  {
    AssertionExtensions.Should(() => XmlProtections.Empty(null, new XElement("element"))).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((XContainer) null)).ThrowExactly<ArgumentNullException>().WithParameterName("container");

    AssertionExtensions.Should(() => Protect.From.Empty((XContainer) new XDocument(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    
    new XDocument().With(document =>
    {
      document.Add(new XElement("root"));
      Protect.From.Empty((XContainer) document).Should().NotBeNull().And.BeSameAs(document);
    });
  }
}