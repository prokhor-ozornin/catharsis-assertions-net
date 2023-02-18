using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="BinaryReaderProtections"/>.</para>
/// </summary>
public sealed class BinaryReaderProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="BinaryReaderProtections.Empty(IProtection, BinaryReader, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    Stream.Null.ToBinaryReader().TryFinallyDispose(reader => AssertionExtensions.Should(() => BinaryReaderProtections.Empty(null, reader)).ThrowExactly<ArgumentNullException>().WithParameterName("protection"));
    AssertionExtensions.Should(() => Protect.From.Empty((BinaryReader) null)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

    Stream.Null.ToBinaryReader().TryFinallyDispose(reader => AssertionExtensions.Should(() => Protect.From.Empty(reader, "error")).ThrowExactly<ArgumentException>().WithMessage("error"));
    RandomStream.ToBinaryReader().TryFinallyDispose(reader => Protect.From.Empty(reader).Should().NotBeNull().And.BeSameAs(reader));
  }
}