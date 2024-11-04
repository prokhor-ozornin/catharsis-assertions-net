using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      Stream.Null.ToBinaryReader().TryFinallyDispose(reader => AssertionExtensions.Should(() => BinaryReaderProtections.Empty(null, reader)).ThrowExactly<ArgumentNullException>().WithParameterName("protection"));
      AssertionExtensions.Should(() => Protect.From.Empty((BinaryReader) null)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

      Validate(true, Attributes.RandomStream().ToBinaryReader());
      Validate(false, Stream.Null.ToBinaryReader());
    }

    return;

    static void Validate(bool result, BinaryReader reader)
    {
      using (reader)
      {
        if (result)
        {
          Protect.From.Empty(reader).Should().BeOfType<BinaryReader>().And.BeSameAs(reader);
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.Empty(reader, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      }
    }
  }
}