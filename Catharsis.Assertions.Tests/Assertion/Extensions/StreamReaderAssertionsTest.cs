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
  ///   <para>Performs testing of <see cref="StreamReaderAssertions.Encoding(IAssertion, StreamReader, Encoding, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Encoding_Method()
  {
    AssertionExtensions.Should(() => StreamReaderAssertions.Encoding(null, Reader, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => StreamReaderAssertions.Encoding(Assert.To, null, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

    RandomStream.ToStreamReader().TryFinallyDispose(reader =>
    {
      AssertionExtensions.Should(() => Assert.To.Encoding(reader, null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Encoding(reader, reader.CurrentEncoding).Should().NotBeNull().And.BeSameAs(Assert.To);
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamReaderAssertions.End(IAssertion, StreamReader, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void End_Method()
  {
    AssertionExtensions.Should(() => StreamReaderAssertions.End(null, Reader)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.End((StreamReader) null)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");
    
    Stream.Null.ToStreamReader().TryFinallyDispose(reader => Assert.To.End(reader).Should().NotBeNull().And.BeSameAs(Assert.To));

    RandomStream.ToStreamReader().TryFinallyDispose(reader =>
    {
      AssertionExtensions.Should(() => Assert.To.End(reader, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      reader.ReadToEnd();
      Assert.To.End(reader).Should().NotBeNull().And.BeSameAs(Assert.To);
    });
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose()
  {
    base.Dispose();
    Reader.Dispose();
  }
}