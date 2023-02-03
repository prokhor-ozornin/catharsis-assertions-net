using System.Xml;
using System.Xml.Linq;
using FluentAssertions;
using Xunit;

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

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlProtections.Empty(IProtection, XmlNode, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_XmlNode_Method()
  {
    AssertionExtensions.Should(() => XmlProtections.Empty(null, new XmlDocument().CreateElement("element"))).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((XmlNode) null)).ThrowExactly<ArgumentNullException>().WithParameterName("node");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlProtections.Empty(IProtection, XDocument, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_XDocument_Method()
  {
    AssertionExtensions.Should(() => XmlProtections.Empty(null, new XDocument())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((XDocument) null)).ThrowExactly<ArgumentNullException>().WithParameterName("document");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlProtections.Empty(IProtection, XContainer, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_XContainer_Method()
  {
    AssertionExtensions.Should(() => XmlProtections.Empty(null, new XElement("element"))).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((XContainer) null)).ThrowExactly<ArgumentNullException>().WithParameterName("container");

    throw new NotImplementedException();
  }
}