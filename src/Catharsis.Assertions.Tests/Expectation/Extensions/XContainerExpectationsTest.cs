using System.Xml.Linq;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XContainerExpectations"/>.</para>
/// </summary>
public sealed class XContainerExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XContainerExpectations.Element(IExpectation{XContainer}, XName)"/> method.</para>
  /// </summary>
  [Fact]
  public void Element_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XContainerExpectations.Element(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XContainer) null).Expect().Element("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => new XDocument().Expect().Element(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

      new XDocument(new XElement("parent", new XElement("child"))).With(container =>
      {
        Validate(true, container, "parent");
        Validate(false, container, "child");
      });
    }

    return;

    static void Validate(bool result, XContainer container, XName name) => container.Expect().Element(name).Should().BeOfType<Expectation<XContainer>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XContainerExpectations.Empty(IExpectation{XContainer})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XContainerExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XContainer) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, new XDocument());
      Validate(false, new XDocument(new XElement("root")));
    }

    return;

    static void Validate(bool result, XContainer container) => container.Expect().Empty().Should().BeOfType<Expectation<XContainer>>().Which.Result.Should().Be(result);
  }
}