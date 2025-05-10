using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamReaderProtections"/>.</para>
/// </summary>
public sealed class StreamReaderProtectionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StreamReaderProtections.Empty(IProtection, StreamReader, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      Stream.Null.ToStreamReader().TryFinallyDispose(reader => AssertionExtensions.Should(() => StreamReaderProtections.Empty(null, reader)).ThrowExactly<ArgumentNullException>().WithParameterName("protection"));
      AssertionExtensions.Should(() => Protect.From.Empty((StreamReader) null)).ThrowExactly<ArgumentNullException>().WithParameterName("reader");

      Test(true, RandomStream.ToStreamReader());
      Test(false, Stream.Null.ToStreamReader());
    }

    return;

    static void Test(bool result, StreamReader reader)
    {
      using (reader)
      {
        if (result)
        {
          Protect.From.Empty(reader).Should().BeOfType<StreamReader>().And.BeSameAs(reader);
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.Empty(reader, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      }
    }
  }
}