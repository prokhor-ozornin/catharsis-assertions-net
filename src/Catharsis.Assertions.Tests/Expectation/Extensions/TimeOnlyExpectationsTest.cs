using Catharsis.Commons;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyExpectations.Hour(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly() }.ForEach(time =>
      {
        Validate(true, time, time.Hour);
        Validate(false, time, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeOnly time, int hour) => time.Expect().Hour(hour).Should().BeOfType<Expectation<TimeOnly>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Minute(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyExpectations.Minute(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly() }.ForEach(time =>
      {
        Validate(true, time, time.Minute);
        Validate(false, time, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeOnly time, int minute) => time.Expect().Minute(minute).Should().BeOfType<Expectation<TimeOnly>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Second(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyExpectations.Second(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly() }.ForEach(time =>
      {
        Validate(true, time, time.Second);
        Validate(false, time, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeOnly time, int second) => time.Expect().Second(second).Should().BeOfType<Expectation<TimeOnly>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Millisecond(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyExpectations.Millisecond(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly() }.ForEach(time =>
      {
        Validate(true, time, time.Millisecond);
        Validate(false, time, int.MinValue);
      });
    }

    return;

    static void Validate(bool result, TimeOnly time, int millisecond) => time.Expect().Millisecond(millisecond).Should().BeOfType<Expectation<TimeOnly>>().Which.Result.Should().Be(result);
  }
}