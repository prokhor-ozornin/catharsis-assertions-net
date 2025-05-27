using System.Xml.Linq;
using Catharsis.Fixture;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XDocumentExpectations"/>.</para>
/// </summary>
public sealed class XDocumentExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XDocumentExpectations.Empty(IExpectation{XDocument})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XDocumentExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XDocument) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, new XDocument());
      Test(false, new XDocument(new XElement("root")));
    }

    return;

    static void Test(bool result, XDocument document) => document.Expect().Empty().Should().BeOfType<Expectation<XDocument>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XDocumentExpectations.Name(IExpectation{XDocument}, XName)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XDocumentExpectations.Name(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XDocument) null).Expect().Name("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, new XDocument(), null);
      Test(true, new XDocument(new XElement("root")), "root");
      Test(false, new XDocument(new XElement("root")), Fixture<string>.Create());
    }

    return;

    static void Test(bool result, XDocument document, XName name) => document.Expect().Name(name).Should().BeOfType<Expectation<XDocument>>().Which.Result.Should().Be(result);
  }
}