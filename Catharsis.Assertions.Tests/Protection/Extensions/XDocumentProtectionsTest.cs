using System.Xml.Linq;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XDocumentProtections"/>.</para>
/// </summary>
public sealed class XDocumentProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XDocumentProtections.Empty(IProtection, XDocument, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_XDocument_Method()
  {
    AssertionExtensions.Should(() => XDocumentProtections.Empty(null, new XDocument())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((XDocument) null)).ThrowExactly<ArgumentNullException>().WithParameterName("document");

    AssertionExtensions.Should(() => Protect.From.Empty(new XDocument(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    
    new XDocument().With(document =>
    {
      document.Add(new XElement("root"));
      Protect.From.Empty(document).Should().NotBeNull().And.BeSameAs(document);
    });
  }
}