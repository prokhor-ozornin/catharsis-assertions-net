using Catharsis.Commons;
using Xunit;
using FluentAssertions;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Expectation{T}"/>.</para>
/// </summary>
public sealed class ExpectationTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  [Fact]
  public void Constructors()
  {
    new Expectation<object>(null).With(expectation =>
    {
      expectation.GetFieldValue<object>("subject").Should().BeNull();
      expectation.GetFieldValue<bool>("state").Should().BeTrue();
    });

    new Expectation<string>(string.Empty).With(expectation =>
    {
      expectation.GetFieldValue<string>("subject").Should().BeEmpty();
      expectation.GetFieldValue<bool>("state").Should().BeTrue();
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Expectation{T}.Not()"/> method.</para>
  /// </summary>
  [Fact]
  public void Not_Method()
  {
    var expectation = new Expectation<object>(null);

    expectation.GetFieldValue<bool>("state").Should().BeTrue();
    expectation.Not().Should().BeOfType<Expectation<object>>().And.BeSameAs(expectation);
    expectation.GetFieldValue<bool>("state").Should().BeFalse();
    expectation.Not().Should().BeOfType<Expectation<object>>().And.BeSameAs(expectation);
    expectation.GetFieldValue<bool>("state").Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Expectation{T}.Expect(Predicate{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Expect_Method()
  {
    AssertionExtensions.Should(() => new Expectation<object>(null).Expect(null)).ThrowExactly<ArgumentNullException>().WithParameterName("result");

    new Expectation<object>(null).Expect(subject => subject is null).Result.Should().BeTrue();
    new Expectation<object>(null).Expect(subject => subject is not null).Result.Should().BeFalse();
    new Expectation<object>(null).Not().Expect(subject => subject is null).Result.Should().BeFalse();
    new Expectation<object>(null).Not().Expect(subject => subject is not null).Result.Should().BeTrue();
  }
}