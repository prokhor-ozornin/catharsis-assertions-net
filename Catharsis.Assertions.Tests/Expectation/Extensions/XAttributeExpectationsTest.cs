using System.Xml.Linq;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XAttributeExpectations"/>.</para>
/// </summary>
public sealed class XAttributeExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XAttributeExpectations.Name(IExpectation{XAttribute}, XName)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XAttributeExpectations.Name(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XAttribute) null).Expect().Name("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => new XAttribute("name", "value").Expect().Name(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

      Validate(true, new XAttribute("name", "value"), "name");
      Validate(false, new XAttribute("name", "value"), string.Empty);
    }

    return;

    static void Validate(bool result, XAttribute attribute, XName name) => attribute.Expect().Name(name).Should().BeOfType<Expectation<XAttribute>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XAttributeExpectations.Value(IExpectation{XAttribute}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XAttributeExpectations.Value(null, "value")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XAttribute) null).Expect().Value("value")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => new XAttribute("name", "value").Expect().Value(null)).ThrowExactly<ArgumentNullException>().WithParameterName("value");

      Validate(true, new XAttribute("name", "value"), "value");
      Validate(false, new XAttribute("name", "value"), string.Empty);
    }

    return;

    static void Validate(bool result, XAttribute attribute, string value) => attribute.Expect().Value(value).Should().BeOfType<Expectation<XAttribute>>().Which.Result.Should().Be(result);
  }
}