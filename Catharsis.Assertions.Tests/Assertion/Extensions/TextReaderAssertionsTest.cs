using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TextReaderAssertions"/>.</para>
/// </summary>
public sealed class TextReaderAssertionsTest : UnitTest
{
  private TextReader Reader { get; } = new StringReader(string.Empty);

  /// <summary>
  ///   <para>Performs testing of <see cref="TextReaderAssertions.End(IAssertion, System.IO.TextReader, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    AssertionExtensions.Should(() => TextReaderAssertions.End(null, Reader)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => TextReaderAssertions.End(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    Reader.Dispose();
  }
}