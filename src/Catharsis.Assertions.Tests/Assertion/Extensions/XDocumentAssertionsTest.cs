using System.Xml.Linq;
using Catharsis.Fixture;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XDocumentAssertions"/>.</para>
/// </summary>
public sealed class XDocumentAssertionsTest : Test
{
  private XDocument Document { get; } = new();

  /// <summary>
  ///   <para>Performs testing of <see cref="XDocumentAssertions.Empty(IAssertion, XDocument, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XDocumentAssertions.Empty(null, Document)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => XDocumentAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("document");

      Test(true, new XDocument());
      Test(false, new XDocument(new XElement("root")));
    }

    return;

    static void Test(bool result, XDocument document)
    {
      if (result)
      {
        Assert.To.Empty(document).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Empty(document, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XDocumentAssertions.Name(IAssertion, XDocument, XName, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XDocumentAssertions.Name(null, Document, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => XDocumentAssertions.Name(Assert.To, null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("document");

      Test(true, new XDocument(), null);
      Test(true, new XDocument(new XElement("root")), "root");
      Test(false, new XDocument(new XElement("root")), Fixture<string>.Create());
    }

    return;

    static void Test(bool result, XDocument document, XName name)
    {
      if (result)
      {
        Assert.To.Name(document, name).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Name(document, name, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}