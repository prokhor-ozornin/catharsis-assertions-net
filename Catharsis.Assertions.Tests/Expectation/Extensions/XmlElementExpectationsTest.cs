using System.Xml;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlElementExpectations"/>.</para>
/// </summary>
public sealed class XmlElementExpectationsTest : UnitTest
{
  private XmlElement Element { get; } = new XmlDocument().CreateElement("root");

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlElementExpectations.Attribute(IExpectation{XmlElement}, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    AssertionExtensions.Should(() => XmlElementExpectations.Attribute(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XmlElement) null).Expect().Attribute("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Element.Expect().Attribute(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    Element.Expect().Attribute(Attributes.RandomString()).Result.Should().BeFalse();

    Element.With(element =>
    {
      element.SetAttribute("encoding", null);
      element.Expect().Attribute("encoding").Result.Should().BeTrue();
      element.Expect().Attribute("encoding", element.NamespaceURI).Result.Should().BeTrue();

      element.SetAttribute("encoding", "utf-8");
      element.Expect().Attribute("encoding").Result.Should().BeTrue();
      element.Expect().Attribute("encoding", element.NamespaceURI).Result.Should().BeTrue();

      element.Expect().Attribute(Attributes.RandomString()).Result.Should().BeFalse();
    });
  }
}