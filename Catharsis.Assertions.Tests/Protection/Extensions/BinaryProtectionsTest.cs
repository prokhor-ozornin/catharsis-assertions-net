using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="BinaryProtections"/>.</para>
/// </summary>
public sealed class BinaryProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="BinaryProtections.Empty(IProtection, BinaryReader, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_BinaryReader_Method()
  {
    Stream.Null.ToBinaryReader().TryFinallyDispose(reader => AssertionExtensions.Should(() => BinaryProtections.Empty(null, reader)).ThrowExactly<ArgumentNullException>().WithParameterName("protection"));
    AssertionExtensions.Should(() => Protect.From.Empty((BinaryReader) null, "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");

    Stream.Null.ToBinaryReader().TryFinallyDispose(reader => AssertionExtensions.Should(() => Protect.From.Empty(reader, "error")).ThrowExactly<ArgumentException>().WithMessage("error"));
    RandomStream.ToBinaryReader().TryFinallyDispose(reader => Protect.From.Empty(reader).Should().NotBeNull().And.BeSameAs(reader));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BinaryProtections.Empty(IProtection, BinaryWriter, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_BinaryWriter_Method()
  {
    Stream.Null.ToBinaryWriter().TryFinallyDispose(writer => AssertionExtensions.Should(() => BinaryProtections.Empty(null, writer)).ThrowExactly<ArgumentNullException>().WithParameterName("protection"));
    AssertionExtensions.Should(() => Protect.From.Empty((BinaryWriter) null, "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");

    Stream.Null.ToBinaryWriter().TryFinallyDispose(writer => AssertionExtensions.Should(() => Protect.From.Empty(writer, "error")).ThrowExactly<ArgumentException>().WithMessage("error"));
    RandomStream.ToBinaryWriter().TryFinallyDispose(writer => Protect.From.Empty(writer).Should().NotBeNull().And.BeSameAs(writer));
  }
}