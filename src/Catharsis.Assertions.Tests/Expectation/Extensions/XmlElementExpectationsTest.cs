using System.Text;
using System.Xml;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlElementExpectations"/>.</para>
/// </summary>
public sealed class XmlElementExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XmlElementExpectations.Attribute(IExpectation{XmlElement}, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlElementExpectations.Attribute(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XmlElement) null).Expect().Attribute("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => new XmlDocument().CreateElement("root").Expect().Attribute(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

      new XmlDocument().CreateElement("root").With(element =>
      {
        element.SetAttribute("encoding", null);
        Validate(true, element, "encoding");
        Validate(true, element, "encoding", element.NamespaceURI);

        Encoding.GetEncodings().ForEach(encoding =>
        {
          element.SetAttribute("encoding", encoding.Name);
          Validate(true, element, "encoding");
          Validate(true, element, "encoding", element.NamespaceURI);
        });
      });

      Validate(false, new XmlDocument().CreateElement("root"), Attributes.RandomString());
    }

    return;

    static void Validate(bool result, XmlElement element, string name, string uri = null) => element.Expect().Attribute(name, uri).Should().BeOfType<Expectation<XmlElement>>().Which.Result.Should().Be(result);
  }
}