using System.Xml;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlNodeProtections"/>.</para>
/// </summary>
public sealed class XmlNodeProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeProtections.Empty(IProtection, XmlNode, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_XmlNode_Method()
  {
    AssertionExtensions.Should(() => XmlNodeProtections.Empty(null, new XmlDocument().CreateElement("element"))).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((XmlNode) null)).ThrowExactly<ArgumentNullException>().WithParameterName("node");

    var document = new XmlDocument();

    AssertionExtensions.Should(() => Protect.From.Empty(document.CreateElement("root"), "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    document.CreateElement("root").With(node =>
    {
      node.AppendChild(document.CreateElement("element"));
      Protect.From.Empty(node).Should().NotBeNull().And.BeSameAs(node);
    });
  }
}