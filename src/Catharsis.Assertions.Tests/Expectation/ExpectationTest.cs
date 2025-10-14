using Xunit;
using FluentAssertions;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Expectation{T}"/>.</para>
/// </summary>
/// <seealso cref="Expectation{T}"/>
public sealed class ExpectationTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  [Fact]
  public void Constructors()
  {
    typeof(Expectation<object>).Should().BeDerivedFrom<object>().And.Implement<IExpectation<object>>();

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
    using (new AssertionScope())
    {
      Test(true, new Expectation<object>(null).Not());
      Test(false, new Expectation<object>(null));
    }

    return;

    static void Test<T>(bool result, IExpectation<T> expectation)
    {
      expectation.Not().Should().BeOfType<Expectation<T>>().And.BeSameAs(expectation);
      expectation.GetFieldValue<bool>("state").Should().Be(result);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Expectation{T}.Expect(Predicate{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Expect_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => new Expectation<object>(null).Expect(null)).ThrowExactly<ArgumentNullException>().WithParameterName("result");

      new Expectation<object>(null).Expect(subject => subject is null).Result.Should().BeTrue();
      new Expectation<object>(null).Expect(subject => subject is not null).Result.Should().BeFalse();
      new Expectation<object>(null).Not().Expect(subject => subject is null).Result.Should().BeFalse();
      new Expectation<object>(null).Not().Expect(subject => subject is not null).Result.Should().BeTrue();
    }

    return;

    static void Test()
    {

    }
  }
}