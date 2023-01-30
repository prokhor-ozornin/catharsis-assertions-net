using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateTimeExpectations"/>.</para>
/// </summary>
public sealed class DateTimeExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Past(IExpectation{DateTime})"/> method.</para>
  /// </summary>
  [Fact]
  public void Past_Method()
  {
    void Validate(DateTime date)
    {
      date.AddSeconds(-1).Expect().Past().Result.Should().BeTrue();
      date.Expect().Past().Result.Should().BeTrue();
      date.AddSeconds(1).Expect().Past().Result.Should().BeFalse();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Past(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Future(IExpectation{DateTime})"/> method.</para>
  /// </summary>
  [Fact]
  public void Future_Method()
  {
    void Validate(DateTime date)
    {
      date.AddSeconds(1).Expect().Future().Result.Should().BeTrue();
      date.AddSeconds(-1).Expect().Future().Result.Should().BeFalse();
      date.Expect().Future().Result.Should().BeFalse();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Future(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.DayOfYear(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfYear_Method()
  {
    void Validate(DateTime date)
    {
      date.Expect().DayOfYear(int.MinValue).Result.Should().BeFalse();
      date.Expect().DayOfYear(date.DayOfYear).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.DayOfYear(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Year(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    void Validate(DateTime date)
    {
      date.Expect().Year(int.MinValue).Result.Should().BeFalse();
      date.Expect().Year(date.Year).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Year(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Month(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Month_Method()
  {
    void Validate(DateTime date)
    {
      date.Expect().Month(int.MinValue).Result.Should().BeFalse();
      date.Expect().Month(date.Month).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Month(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Day(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Day_Method()
  {
    void Validate(DateTime date)
    {
      date.Expect().Day(int.MinValue).Result.Should().BeFalse();
      date.Expect().Day(date.Day).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Month(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Hour(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Hour_Method()
  {
    void Validate(DateTime date)
    {
      date.Expect().Hour(int.MinValue).Result.Should().BeFalse();
      date.Expect().Hour(date.Hour).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Hour(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Minute(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Minute_Method()
  {
    void Validate(DateTime date)
    {
      date.Expect().Minute(int.MinValue).Result.Should().BeFalse();
      date.Expect().Minute(date.Minute).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Minute(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Second(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Second_Method()
  {
    void Validate(DateTime date)
    {
      date.Expect().Second(int.MinValue).Result.Should().BeFalse();
      date.Expect().Second(date.Second).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Second(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.Millisecond(IExpectation{DateTime}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Millisecond_Method()
  {
    void Validate(DateTime date)
    {
      date.Expect().Millisecond(int.MinValue).Result.Should().BeFalse();
      date.Expect().Millisecond(date.Millisecond).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => DateTimeExpectations.Millisecond(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      new[] { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.UtcNow }.ForEach(Validate);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.DayOfWeek(IExpectation{DateTime}, DayOfWeek)"/> method.</para>
  /// </summary>
  [Fact]
  public void DayOfWeek_Method()
  {
    void Validate(DateTime date)
    {
      //Enum.GetValues<DayOfWeek>().ForEach(day => )
    }

    AssertionExtensions.Should(() => DateTimeExpectations.DayOfWeek(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    DateTime.MinValue.Expect().DayOfWeek(DayOfWeek.Monday).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.LocalTime(IExpectation{DateTime})"/> method.</para>
  /// </summary>
  [Fact]
  public void LocalTime_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.LocalTime(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    DateTime.MinValue.Expect().LocalTime().Result.Should().BeFalse();
    DateTime.MaxValue.Expect().LocalTime().Result.Should().BeFalse();
    DateTime.Now.Expect().LocalTime().Result.Should().BeTrue();
    DateTime.UtcNow.Expect().LocalTime().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTimeExpectations.UtcTime(IExpectation{DateTime})"/> method.</para>
  /// </summary>
  [Fact]
  public void UtcTime_Method()
  {
    AssertionExtensions.Should(() => DateTimeExpectations.UtcTime(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    DateTime.MinValue.Expect().UtcTime().Result.Should().BeFalse();
    DateTime.MaxValue.Expect().UtcTime().Result.Should().BeFalse();
    DateTime.Now.Expect().UtcTime().Result.Should().BeFalse();
    DateTime.UtcNow.Expect().UtcTime().Result.Should().BeTrue();
  }
}