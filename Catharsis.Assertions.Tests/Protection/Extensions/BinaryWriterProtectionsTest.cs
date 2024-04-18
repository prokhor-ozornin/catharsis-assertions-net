using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      Stream.Null.ToBinaryWriter().TryFinallyDispose(writer => AssertionExtensions.Should(() => BinaryWriterProtections.Empty(null, writer)).ThrowExactly<ArgumentNullException>().WithParameterName("protection"));
      AssertionExtensions.Should(() => Protect.From.Empty((BinaryWriter) null)).ThrowExactly<ArgumentNullException>().WithParameterName("writer");

      Validate(true, Attributes.RandomStream().ToBinaryWriter());
      Validate(false, Stream.Null.ToBinaryWriter());
    }

    return;

    static void Validate(bool result, BinaryWriter writer)
    {
      using (writer)
      {
        if (result)
        {
          Protect.From.Empty(writer).Should().BeOfType<BinaryWriter>().And.BeSameAs(writer);
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.Empty(writer, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      }
    }
  }
}