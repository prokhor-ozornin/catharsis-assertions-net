using System.Xml.Linq;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XDocumentAssertions"/>.</para>
/// </summary>
public sealed class XDocumentAssertionsTest : UnitTest
{
  private XDocument Document { get; } = new();

  /// <summary>
  ///   <para>Performs testing of <see cref="XDocumentAssertions.Empty(IAssertion, XDocument, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => XDocumentAssertions.Empty(null, Document)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => XDocumentAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("document");

    Assert.To.Empty(Document).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    
    Document.With(document =>
    {
      document.Add(new XElement("root"));
      AssertionExtensions.Should(() => Assert.To.Empty(document, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XDocumentAssertions.Name(IAssertion, XDocument, XName, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    AssertionExtensions.Should(() => XDocumentAssertions.Name(null, Document, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => XDocumentAssertions.Name(Assert.To, null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("document");

    Assert.To.Name(Document, null).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);

    Document.With(document =>
    {
      const string name = "root";
      document.Add(new XElement(name));

      AssertionExtensions.Should(() => Assert.To.Name(document, Attributes.RandomString(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Name(document, name).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    });
  }
}