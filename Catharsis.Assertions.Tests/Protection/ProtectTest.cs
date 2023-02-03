using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Protect"/>.</para>
/// </summary>
public sealed class ProtectTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Protect.From"/> property.</para>
  /// </summary>
  [Fact]
  public void From_Property()
  {
    Protect.From.Should().NotBeNull().And.BeSameAs(Protect.From).And.BeOfType<Protection>();
  }
}