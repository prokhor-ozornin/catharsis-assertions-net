using System.Xml;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeProtections.Empty(null, new XmlDocument())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Empty((XmlDocument) null)).ThrowExactly<ArgumentNullException>().WithParameterName("document");

      Validate(true, new XmlDocument().With(document => document.With(document.CreateElement("root"))));
      Validate(false, new XmlDocument());
    }

    return;

    static void Validate(bool result, XmlDocument document)
    {
      if (result)
      {
        Protect.From.Empty(document).Should().BeOfType<XmlDocument>().And.BeSameAs(document);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Empty(document, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }
}