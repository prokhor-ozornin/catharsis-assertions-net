using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamReaderProtections"/>.</para>
/// </summary>
public sealed class StreamReaderProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StreamReaderProtections.Empty(IProtection, StreamReader, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    Stream.Null.ToStreamReader().TryFinallyDispose(reader => AssertionExtensions.Should(() => StreamReaderProtections.Empty(null, reader)).ThrowExactly<ArgumentNullException>().WithParameterName("protection"));
    AssertionExtensions.Should(() => Protect.From.Empty((StreamReader) null)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

    Stream.Null.ToStreamReader().TryFinallyDispose(reader => AssertionExtensions.Should(() => Protect.From.Empty(reader, "error")).ThrowExactly<ArgumentException>().WithMessage("error"));
    RandomStream.ToStreamReader().TryFinallyDispose(reader => Protect.From.Empty(reader).Should().NotBeNull().And.BeSameAs(reader));
  }
}