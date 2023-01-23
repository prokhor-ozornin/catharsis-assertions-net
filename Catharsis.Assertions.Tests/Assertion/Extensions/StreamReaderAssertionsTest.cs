using System.Text;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamReaderAssertions"/>.</para>
/// </summary>
public sealed class StreamReaderAssertionsTest : UnitTest
{
  private StreamReader Reader { get; } = Stream.Null.ToStreamReader();

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamReaderAssertions.Encoding(IAssertion, System.IO.StreamReader, Encoding, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Encoding_Method()
  {
    AssertionExtensions.Should(() => StreamReaderAssertions.Encoding(null, Reader, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => StreamReaderAssertions.Encoding(Assert.To, null, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamReaderAssertions.End(IAssertion, System.IO.StreamReader, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    AssertionExtensions.Should(() => StreamReaderAssertions.End(null, Reader)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.End(null)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    Reader.Dispose();
  }
}