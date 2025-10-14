using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamProtections"/>.</para>
/// </summary>
/// <seealso cref="StreamProtections"/>
public sealed class StreamProtectionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StreamProtections.Empty{TStream}(IProtection, TStream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StreamProtections.Empty(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Empty((Stream) null)).ThrowExactly<ArgumentNullException>().WithParameterName("stream");

      Test(true, RandomStream);
      Test(false, Stream.Null);
    }

    return;

    static void Test(bool result, Stream stream)
    {
      using (stream)
      {
        if (result)
        {
          Protect.From.Empty(stream).Should().BeAssignableTo<Stream>().And.BeSameAs(stream);
        }
        else
        {
          AssertionExtensions.Should(() => Protect.From.Empty(stream, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
        }
      }
    }
  }
}