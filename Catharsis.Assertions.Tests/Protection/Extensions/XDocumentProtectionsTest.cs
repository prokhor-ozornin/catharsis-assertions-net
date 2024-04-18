using System.Xml.Linq;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XDocumentProtections.Empty(null, new XDocument())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Empty((XDocument) null)).ThrowExactly<ArgumentNullException>().WithParameterName("document");

      Validate(true, new XDocument().With(new XElement("root")));
      Validate(false, new XDocument());
    }

    return;

    static void Validate(bool result, XDocument document)
    {
      if (result)
      {
        Protect.From.Empty(document).Should().BeOfType<XDocument>().And.BeSameAs(document);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Empty(document, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }
}