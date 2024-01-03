using System.Xml.Linq;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XAttributeExpectations"/>.</para>
/// </summary>
public sealed class XAttributeExpectationsTest : UnitTest
{
  private XAttribute Attribute { get; } = new("name", "value");

  /// <summary>
  ///   <para>Performs testing of <see cref="XAttributeExpectations.Name(IExpectation{XAttribute}, XName)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    AssertionExtensions.Should(() => XAttributeExpectations.Name(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XAttribute) null).Expect().Name("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Attribute.Expect().Name(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    Attribute.Expect().Name(Attributes.RandomString()).Result.Should().BeFalse();
    Attribute.Expect().Name(Attribute.Name).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XAttributeExpectations.Value(IExpectation{XAttribute}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    AssertionExtensions.Should(() => XAttributeExpectations.Value(null, "value")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XAttribute) null).Expect().Value("value")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Attribute.Expect().Value(null)).ThrowExactly<ArgumentNullException>().WithParameterName("value");

    Attribute.Expect().Value(Attributes.RandomString()).Result.Should().BeFalse();
    Attribute.Expect().Value(Attribute.Value).Result.Should().BeTrue();
  }
}