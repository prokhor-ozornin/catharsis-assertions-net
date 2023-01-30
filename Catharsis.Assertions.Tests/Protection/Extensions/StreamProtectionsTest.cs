using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StreamProtections"/>.</para>
/// </summary>
public sealed class StreamProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StreamProtections.Empty{TStream}(IProtection, TStream, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => StreamProtections.Empty(null, Stream.Null)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((Stream) null, "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");

    throw new NotImplementedException();
  }
}