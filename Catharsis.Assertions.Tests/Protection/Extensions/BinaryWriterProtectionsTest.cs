using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="BinaryWriterProtections"/>.</para>
/// </summary>
public sealed class BinaryWriterProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="BinaryWriterProtections.Empty(IProtection, BinaryWriter, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    Stream.Null.ToBinaryWriter().TryFinallyDispose(writer => AssertionExtensions.Should(() => BinaryWriterProtections.Empty(null, writer)).ThrowExactly<ArgumentNullException>().WithParameterName("protection"));
    AssertionExtensions.Should(() => Protect.From.Empty((BinaryWriter) null)).ThrowExactly<ArgumentNullException>().WithParameterName("writer");

    Stream.Null.ToBinaryWriter().TryFinallyDispose(writer => AssertionExtensions.Should(() => Protect.From.Empty(writer, "error")).ThrowExactly<ArgumentException>().WithMessage("error"));
    Attributes.RandomStream().ToBinaryWriter().TryFinallyDispose(writer => Protect.From.Empty(writer).Should().BeOfType<BinaryWriter>().And.BeSameAs(writer));
  }
}