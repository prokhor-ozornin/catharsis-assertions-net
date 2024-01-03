using Catharsis.Extensions;
using System.Globalization;
using Catharsis.Commons;
using FluentAssertions;
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
    AssertionExtensions.Should(() => TextWriterExpectations.Format(null, CultureInfo.CurrentCulture)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((TextWriter) null).Expect().Format(CultureInfo.CurrentCulture)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    
    Attributes.RandomStream().ToStreamWriter().TryFinallyDispose(writer =>
    {
      writer.Expect().Format(null).Result.Should().BeFalse();
      writer.Expect().Format(writer.FormatProvider).Result.Should().BeTrue();
    });
  }
}