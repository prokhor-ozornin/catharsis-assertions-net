using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TimeOnlyExpectations"/>.</para>
/// </summary>
/// <seealso cref="TimeOnlyExpectations"/>
public sealed class TimeOnlyExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Hour(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyExpectations.Hour(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly() }.ForEach(time =>
      {
        Test(true, time, time.Hour);
        Test(false, time, int.MinValue);
      });
    }

    return;

    static void Test(bool result, TimeOnly time, int hour) => time.Expect().Hour(hour).Should().BeOfType<Expectation<TimeOnly>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Minute(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyExpectations.Minute(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly() }.ForEach(time =>
      {
        Test(true, time, time.Minute);
        Test(false, time, int.MinValue);
      });
    }

    return;

    static void Test(bool result, TimeOnly time, int minute) => time.Expect().Minute(minute).Should().BeOfType<Expectation<TimeOnly>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Second(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyExpectations.Second(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly() }.ForEach(time =>
      {
        Test(true, time, time.Second);
        Test(false, time, int.MinValue);
      });
    }

    return;

    static void Test(bool result, TimeOnly time, int second) => time.Expect().Second(second).Should().BeOfType<Expectation<TimeOnly>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TimeOnlyExpectations.Millisecond(IExpectation{TimeOnly}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TimeOnlyExpectations.Millisecond(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { TimeOnly.MinValue, TimeOnly.MaxValue, DateTime.Now.ToTimeOnly() }.ForEach(time =>
      {
        Test(true, time, time.Millisecond);
        Test(false, time, int.MinValue);
      });
    }

    return;

    static void Test(bool result, TimeOnly time, int millisecond) => time.Expect().Millisecond(millisecond).Should().BeOfType<Expectation<TimeOnly>>().Which.Result.Should().Be(result);
  }
}