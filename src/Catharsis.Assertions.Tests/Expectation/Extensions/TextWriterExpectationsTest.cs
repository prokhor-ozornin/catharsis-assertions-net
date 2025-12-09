using System.Globalization;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TextWriterExpectations"/>.</para>
/// </summary>
/// <seealso cref="TextWriterExpectations"/>
public sealed class TextWriterExpectationsTest : Test
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

      Stream.Null.ToStreamWriter().With(writer => Test(true, writer, writer.FormatProvider));
      Test(false, Stream.Null.ToStreamWriter(), null); 
    }

    return;

    static void Test(bool result, TextWriter writer, IFormatProvider format)
    {
      using (writer)
      {
        writer.Expect().Format(format).Should().BeOfType<Expectation<TextWriter>>().Which.Result.Should().Be(result);
      }
    }
  }
}