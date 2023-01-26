using System.Xml.Linq;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XDocumentExpectations"/>.</para>
/// </summary>
public sealed class XDocumentExpectationsTest : UnitTest
{
  private XDocument Document { get; } = new();

  /// <summary>
  ///   <para>Performs testing of <see cref="XDocumentExpectations.Empty(IExpectation{XDocument})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => XDocumentExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XDocument) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XDocumentExpectations.Name(IExpectation{XDocument}, XName)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    AssertionExtensions.Should(() => XDocumentExpectations.Name(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XDocument) null).Expect().Name("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Document.Expect().Name(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    throw new NotImplementedException();
  }
}