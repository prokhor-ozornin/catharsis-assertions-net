using AutoFixture;
using System.Xml.Linq;
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

      Validate(true, new XDocument());
      Validate(false, new XDocument(new XElement("root")));
    }

    return;

    static void Validate(bool result, XDocument document) => document.Expect().Empty().Should().BeOfType<Expectation<XDocument>>().Which.Result.Should().Be(result);
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

      Validate(true, new XDocument(), null);
      Validate(true, new XDocument(new XElement("root")), "root");
      Validate(false, new XDocument(new XElement("root")), Fixture.Create<string>());
    }

    return;

    static void Validate(bool result, XDocument document, XName name) => document.Expect().Name(name).Should().BeOfType<Expectation<XDocument>>().Which.Result.Should().Be(result);
  }
}