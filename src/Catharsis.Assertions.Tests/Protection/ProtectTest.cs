using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Protect"/>.</para>
/// </summary>
/// <seealso cref="Protect"/>
public sealed class ProtectTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Protect.From"/> property.</para>
  /// </summary>
  [Fact]
  public void From_Property() => Protect.From.Should().BeOfType<Protection>().And.BeSameAs(Protect.From);
}