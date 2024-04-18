using System.Xml.Linq;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XAttributeAssertions.Name(null, Attribute, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => XAttributeAssertions.Name(Assert.To, null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("attribute");
      AssertionExtensions.Should(() => Assert.To.Name(Attribute, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");
    }

    return;

    static void Validate(bool result, XAttribute attribute, XName name)
    {
      if (result)
      {
        Assert.To.Name(attribute, name).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Name(attribute, name, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XAttributeAssertions.Value(IAssertion, XAttribute, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XAttributeAssertions.Value(null, Attribute, "value")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => XAttributeAssertions.Value(Assert.To, null, "value")).ThrowExactly<ArgumentNullException>().WithParameterName("attribute");
      AssertionExtensions.Should(() => Assert.To.Value(Attribute, null)).ThrowExactly<ArgumentNullException>().WithParameterName("value");
    }

    return;

    static void Validate(bool result, XAttribute attribute, string value)
    {
      if (result)
      {
        Assert.To.Name(attribute, value).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Name(attribute, value, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}