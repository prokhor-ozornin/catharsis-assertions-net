using Catharsis.Extensions;
using System.Globalization;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TextWriterAssertions"/>.</para>
/// </summary>
public sealed class TextWriterAssertionsTest : UnitTest
{
  private TextWriter Writer { get; } = new StringWriter();

  /// <summary>
  ///   <para>Performs testing of <see cref="TextWriterAssertions.Format(IAssertion, TextWriter, IFormatProvider, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Format_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TextWriterAssertions.Format(null, Writer, CultureInfo.CurrentCulture)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => ((TextWriter) null).Expect().Format(CultureInfo.CurrentCulture)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      
      Attributes.RandomStream().ToStreamWriter().TryFinallyDispose(writer =>
      {
        AssertionExtensions.Should(() => Assert.To.Format(writer, null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        Assert.To.Format(writer, writer.FormatProvider).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      });
    }

    return;

    static void Validate(bool result, TextWriter writer, IFormatProvider format)
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

  public override void Dispose()
  {
    base.Dispose();
    Writer.Dispose();
  }
}