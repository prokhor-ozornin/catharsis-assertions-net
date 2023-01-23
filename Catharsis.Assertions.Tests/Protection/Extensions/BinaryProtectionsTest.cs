using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="BinaryProtections"/>.</para>
/// </summary>
public sealed class BinaryProtectionsTest : UnitTest
{
  private BinaryReader BinaryReader { get; } = Stream.Null.ToBinaryReader();
  private BinaryWriter BinaryWriter { get; } = Stream.Null.ToBinaryWriter();

  /// <summary>
  ///   <para>Performs testing of <see cref="BinaryProtections.Empty(IProtection, System.IO.BinaryReader, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_BinaryReader_Method()
  {
    AssertionExtensions.Should(() => BinaryProtections.Empty(null, BinaryReader)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((BinaryReader) null)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BinaryProtections.Empty(IProtection, System.IO.BinaryWriter, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_BinaryWriter_Method()
  {
    AssertionExtensions.Should(() => BinaryProtections.Empty(null, BinaryWriter)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((BinaryWriter) null)).ThrowExactly<ArgumentNullException>().WithParameterName("writer");

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    BinaryReader.Dispose();
    BinaryWriter.Dispose();
  }
}