using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TextReaderExpectations"/>.</para>
/// </summary>
public sealed class TextReaderExpectationsTest : UnitTest
{
  private TextReader Reader { get; } = new StringReader(string.Empty);

  /// <summary>
  ///   <para>Performs testing of <see cref="TextReaderExpectations.End(IExpectation{TextReader})"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    AssertionExtensions.Should(() => TextReaderExpectations.End(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((TextReader) null).Expect().End()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    Reader.Dispose();
  }
}