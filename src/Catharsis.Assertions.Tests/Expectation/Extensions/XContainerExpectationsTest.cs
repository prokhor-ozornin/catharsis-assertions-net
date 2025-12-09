using System.Xml.Linq;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XContainerExpectations"/>.</para>
/// </summary>
/// <seealso cref="XContainerExpectations"/>
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
        Test(true, container, "parent");
        Test(false, container, "child");
      });
    }

    return;

    static void Test(bool result, XContainer container, XName name) => container.Expect().Element(name).Should().BeOfType<Expectation<XContainer>>().Which.Result.Should().Be(result);
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

      Test(true, new XDocument());
      Test(false, new XDocument(new XElement("root")));
    }

    return;

    static void Test(bool result, XContainer container) => container.Expect().Empty().Should().BeOfType<Expectation<XContainer>>().Which.Result.Should().Be(result);
  }
}