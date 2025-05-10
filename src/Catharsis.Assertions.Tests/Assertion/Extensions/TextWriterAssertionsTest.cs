using Catharsis.Extensions;
using System.Globalization;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TextWriterAssertions"/>.</para>
/// </summary>
public sealed class TextWriterAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TextWriterAssertions.Format(IAssertion, TextWriter, IFormatProvider, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Format_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TextWriterAssertions.Format(null, new StringWriter(), CultureInfo.CurrentCulture)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => ((TextWriter) null).Expect().Format(CultureInfo.CurrentCulture)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Stream.Null.ToStreamWriter().With(writer => Test(true, writer, writer.FormatProvider));
      Test(false, Stream.Null.ToStreamWriter(), null);
    }

    return;

    static void Test(bool result, TextWriter writer, IFormatProvider format)
    {
      using (writer)
      {
        if (result)
        {
          Assert.To.Format(writer, format).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Format(writer, format, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }
}