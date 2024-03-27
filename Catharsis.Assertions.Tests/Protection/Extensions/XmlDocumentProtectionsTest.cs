using System.Xml;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlDocumentProtections"/>.</para>
/// </summary>
public sealed class XmlDocumentProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XmlDocumentProtections.Empty(IProtection, XmlDocument, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => XmlNodeProtections.Empty(null, new XmlDocument())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((XmlDocument) null)).ThrowExactly<ArgumentNullException>().WithParameterName("document");

    AssertionExtensions.Should(() => Protect.From.Empty(new XmlDocument(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    
    new XmlDocument().With(document =>
    {
      document.AppendChild(document.CreateElement("root"));
      Protect.From.Empty(document).Should().BeOfType<XmlDocument>().And.BeSameAs(document);
    });
  }
}