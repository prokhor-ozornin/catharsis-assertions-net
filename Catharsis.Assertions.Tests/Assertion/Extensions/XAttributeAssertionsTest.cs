using System.Xml.Linq;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XAttributeAssertions"/>.</para>
/// </summary>
public sealed class XAttributeAssertionsTest : UnitTest
{
  private XAttribute Attribute { get; } = new("name", "value");

  /// <summary>
  ///   <para>Performs testing of <see cref="XAttributeAssertions.Name(IAssertion, XAttribute, XName, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    AssertionExtensions.Should(() => XAttributeAssertions.Name(null, Attribute, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => XAttributeAssertions.Name(Assert.To, null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("attribute");
    AssertionExtensions.Should(() => Assert.To.Name(Attribute, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    AssertionExtensions.Should(() => Assert.To.Name(Attribute, RandomString, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Name(Attribute, Attribute.Name).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XAttributeAssertions.Value(IAssertion, XAttribute, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    AssertionExtensions.Should(() => XAttributeAssertions.Value(null, Attribute, "value")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => XAttributeAssertions.Value(Assert.To, null, "value")).ThrowExactly<ArgumentNullException>().WithParameterName("attribute");
    AssertionExtensions.Should(() => Assert.To.Value(Attribute, null)).ThrowExactly<ArgumentNullException>().WithParameterName("value");

    AssertionExtensions.Should(() => Assert.To.Name(Attribute, RandomString, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Name(Attribute, Attribute.Name).Should().NotBeNull().And.BeSameAs(Assert.To);
  }
}