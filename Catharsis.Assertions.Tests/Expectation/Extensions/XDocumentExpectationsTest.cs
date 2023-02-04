using System.Xml.Linq;
using Catharsis.Extensions;
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

    Document.Expect().Empty().Result.Should().BeTrue();

    Document.With(document =>
    {
      document.Add(new XElement("root"));
      document.Expect().Empty().Result.Should().BeFalse();
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XDocumentExpectations.Name(IExpectation{XDocument}, XName)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    AssertionExtensions.Should(() => XDocumentExpectations.Name(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XDocument) null).Expect().Name("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Document.Expect().Name(null).Result.Should().BeTrue();
    
    Document.With(document =>
    {
      const string name = "root";
      document.Add(new XElement(name));
      document.Expect().Name(RandomString).Result.Should().BeFalse();
      document.Expect().Name(name).Result.Should().BeTrue();
    });
  }
}