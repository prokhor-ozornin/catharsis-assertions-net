using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TimeOnlyExpectations"/>.</para>
/// </summary>
public sealed class TimeOnlyExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Hour(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    void Validate(TimeOnly time)
    {
      time.Expect().Hour(int.MinValue).Result.Should().BeFalse();
      time.Expect().Hour(time.Hour).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyExpectations.Hour(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly(), DateTime.UtcNow.ToTimeOnly() }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Minute(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    void Validate(TimeOnly time)
    {
      time.Expect().Minute(int.MinValue).Result.Should().BeFalse();
      time.Expect().Minute(time.Minute).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyExpectations.Minute(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly(), DateTime.UtcNow.ToTimeOnly() }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Second(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    void Validate(TimeOnly time)
    {
      time.Expect().Second(int.MinValue).Result.Should().BeFalse();
      time.Expect().Second(time.Second).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyExpectations.Second(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly(), DateTime.UtcNow.ToTimeOnly() }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Millisecond(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    void Validate(TimeOnly time)
    {
      time.Expect().Millisecond(int.MinValue).Result.Should().BeFalse();
      time.Expect().Millisecond(time.Millisecond).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyExpectations.Millisecond(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly(), DateTime.UtcNow.ToTimeOnly() }.ForEach(Validate);
    }
  }
}