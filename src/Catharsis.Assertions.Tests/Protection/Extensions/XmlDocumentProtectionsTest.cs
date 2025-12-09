using System.Xml;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlDocumentProtections"/>.</para>
/// </summary>
/// <seealso cref="XmlDocumentProtections"/>
public sealed class XmlDocumentProtectionsTest : Test
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

      Test(true, new XmlDocument().With(document => document.With(document.CreateElement("root"))));
      Test(false, new XmlDocument());
    }

    return;

    static void Test(bool result, XmlDocument document)
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