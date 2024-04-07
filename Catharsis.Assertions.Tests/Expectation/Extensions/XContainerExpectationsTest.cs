using System.Xml.Linq;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XContainerExpectations"/>.</para>
/// </summary>
public sealed class XContainerExpectationsTest : UnitTest
{
  private XContainer Container { get; } = new XDocument();

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
    AssertionExtensions.Should(() => Container.Expect().Element(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    Container.Expect().Element(Attributes.RandomString()).Result.Should().BeFalse();

    Container.With(container =>
    {
      var root = new XElement("parent");
      root.Add(new XElement("child"));
      container.Add(root);

      container.Expect().Element("parent").Result.Should().BeTrue();
      container.Expect().Element("child").Result.Should().BeFalse();
    });
    }

    return;

    static void Validate()
    {

    }
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

      Container.Expect().Empty().Result.Should().BeTrue();

      Container.With(container =>
      {
        container.Add(new XElement("root"));
        container.Expect().Empty().Result.Should().BeFalse();
      });
    }

    return;

    static void Validate()
    {

    }
  }
}