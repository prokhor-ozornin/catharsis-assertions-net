using Catharsis.Extensions;
using System.Globalization;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TextWriterExpectations"/>.</para>
/// </summary>
public sealed class TextWriterExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TextWriterExpectations.Format(IExpectation{TextWriter}, IFormatProvider)"/> method.</para>
  /// </summary>
  [Fact]
  public void Format_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TextWriterExpectations.Format(null, CultureInfo.CurrentCulture)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((TextWriter) null).Expect().Format(CultureInfo.CurrentCulture)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      
      Attributes.RandomStream().ToStreamWriter().TryFinallyDispose(writer =>
      {
        writer.Expect().Format(null).Result.Should().BeFalse();
        writer.Expect().Format(writer.FormatProvider).Result.Should().BeTrue();
      });
    }
    return;

    static void Validate(bool result, TextWriter writer, IFormatProvider format)
    {
      using (writer)
      {
        writer.Expect().Format(format).Should().BeOfType<Expectation<TextWriter>>().Which.Result.Should().Be(result);
      }
    }
  }
}