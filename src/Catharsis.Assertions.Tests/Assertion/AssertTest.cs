using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Assert"/>.</para>
/// </summary>
public sealed class AssertTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Assert.To"/> property.</para>
  /// </summary>
  [Fact]
  public void To_Property()
  {
    Assert.To.Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Assert.NotTo"/> property.</para>
  /// </summary>
  [Fact]
  public void NotTo_Property()
  {
    Assert.NotTo.Should().BeOfType<Assertion>().And.BeSameAs(Assert.NotTo);
  }
}