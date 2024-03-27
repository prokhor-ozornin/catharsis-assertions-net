using System.Text;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamWriterAssertions"/>.</para>
/// </summary>
public sealed class StreamWriterAssertionsTest : UnitTest
{
  private StreamWriter Writer { get; } = Stream.Null.ToStreamWriter();

  /// <summary>
  ///   <para>Performs testing of <see cref="StreamWriterAssertions.Encoding(IAssertion, StreamWriter, Encoding, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Encoding_Method()
  {
    AssertionExtensions.Should(() => StreamWriterAssertions.Encoding(null, Writer, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => StreamWriterAssertions.Encoding(Assert.To, null, Encoding.Default)).ThrowExactly<ArgumentNullException>().WithParameterName("writer");

    Attributes.RandomStream().ToStreamWriter().TryFinallyDispose(writer =>
    {
      AssertionExtensions.Should(() => Assert.To.Encoding(writer, null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Encoding(writer, writer.Encoding).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    });
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose()
  {
    base.Dispose();
    Writer.Dispose();
  }
}