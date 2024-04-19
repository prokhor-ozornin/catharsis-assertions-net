using System.Text;
using System.Xml.Linq;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XElementExpectations"/>.</para>
/// </summary>
public sealed class XElementExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XElementExpectations.Attribute(IExpectation{XElement}, XName, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XElementExpectations.Attribute(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XElement) null).Expect().Attribute("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => new XElement("root").Expect().Attribute(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

      Validate(false, new XElement("root"), string.Empty);

      new XElement("root").With(element =>
      {
        Encoding.GetEncodings().ForEach(encoding =>
        {
          element.SetAttributeValue("encoding", encoding.Name);

          Validate(true, element, "encoding");
          Validate(true, element, "encoding", encoding.Name);
          Validate(false, element, "encoding", string.Empty);
        });
      });
    }

    return;

    static void Validate(bool result, XElement element, XName name, string value = null) => element.Expect().Attribute(name, value).Should().BeOfType<Expectation<XElement>>().Which.Result.Should().Be(result);
  }
}