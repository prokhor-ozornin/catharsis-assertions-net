using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IExpectationExtensions"/>.</para>
/// </summary>
public sealed class IExpectationExtensionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.Expected{T}(IExpectation{T}, Predicate{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Expected_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IExpectationExtensions.Expected<object>(null, _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => new Expectation<object>(null).Expected(null)).ThrowExactly<ArgumentNullException>().WithParameterName("result");

      Validate(true, new Expectation<object>(null), _ => true);
      Validate(false, new Expectation<object>(null), _ => false);
    }

    return;

    static void Validate<T>(bool result, IExpectation<T> expectation, Predicate<T> predicate) => expectation.Expected(predicate).Should().BeSameAs(expectation).And.BeOfType<Expectation<T>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.HaveSubject{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void HaveSubject_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IExpectationExtensions.HaveSubject<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Validate(true, new Expectation<object>(new object()));
      Validate(false, new Expectation<object>(null));
    }

    return;

    static void Validate<T>(bool result, IExpectation<T> expectation)
    {
      if (result)
      {
        expectation.HaveSubject().Should().BeSameAs(expectation).And.BeOfType<Expectation<T>>().Which.Result.Should().BeTrue();
      }
      else
      {
        AssertionExtensions.Should(expectation.HaveSubject).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IExpectationExtensions.ThrowIfFalse{T}(IExpectation{T}, Exception)"/></description></item>
  ///     <item><description><see cref="IExpectationExtensions.ThrowIfFalse{T}(IExpectation{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void ThrowIfFalse_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IExpectationExtensions.ThrowIfFalse<object>(null, new Exception())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => new Expectation<object>(null).ThrowIfFalse((Exception) null)).ThrowExactly<ArgumentNullException>().WithParameterName("exception");

      Validate(true, new Expectation<object>(null).Expect(_ => true));
      Validate(false, new Expectation<object>(null).Expect(_ => false));

      static void Validate<T>(bool result, IExpectation<T> expectation)
      {
        if (result)
        {
          expectation.ThrowIfFalse(new Exception("error")).Should().BeSameAs(expectation).And.BeOfType<Expectation<T>>().Which.Result.Should().BeTrue();
        }
        else
        {
          AssertionExtensions.Should(() => expectation.ThrowIfFalse(new Exception("error"))).ThrowExactly<Exception>().WithMessage("error");
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IExpectationExtensions.ThrowIfFalse<object>(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => new Expectation<object>(null).Expect(_ => false).ThrowIfFalse("message")).ThrowExactly<InvalidOperationException>().WithMessage("message");

      Validate(true, new Expectation<object>(null).Expect(_ => true));
      Validate(false, new Expectation<object>(null).Expect(_ => false));

      static void Validate<T>(bool result, IExpectation<T> expectation)
      {
        if (result)
        {
          expectation.ThrowIfFalse().Should().BeSameAs(expectation).And.BeOfType<Expectation<T>>().Which.Result.Should().BeTrue();
        }
        else
        {
          AssertionExtensions.Should(() => expectation.ThrowIfFalse("error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.ThrowIfNull{T}(IExpectation{T}, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ThrowIfNull_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IExpectationExtensions.ThrowIfNull<object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => new Expectation<object>(null).ThrowIfNull(null)).ThrowExactly<ArgumentNullException>().WithParameterName("instance");
      AssertionExtensions.Should(() => new Expectation<object>(null).ThrowIfNull(null, "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");

      Validate(new Expectation<object>(null), new object());
    }

    return;

    static void Validate<T>(IExpectation<T> expectation, object instance) => expectation.ThrowIfNull(instance).Should().BeOfType<Expectation<T>>().And.BeSameAs(expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.To{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void To_Method()
  {
    using (new AssertionScope())
    {
      Validate(new Expectation<object>(null));
    }

    return;

    static void Validate<T>(IExpectation<T> expectation) => expectation.To().Should().BeSameAs(expectation).And.BeOfType<Expectation<T>>();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.And{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void And_Method()
  {
    using (new AssertionScope())
    {
      Validate(new Expectation<object>(null));
    }

    return;

    static void Validate<T>(IExpectation<T> expectation) => expectation.And().Should().BeSameAs(expectation).And.BeOfType<Expectation<T>>();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.Be{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Be_Method()
  {
    using (new AssertionScope())
    {
      Validate(new Expectation<object>(null));
    }

    return;

    static void Validate<T>(IExpectation<T> expectation) => expectation.Be().Should().BeSameAs(expectation).And.BeOfType<Expectation<T>>();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.Having{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Having_Method()
  {
    using (new AssertionScope())
    {
      Validate(new Expectation<object>(null));
    }

    return;

    static void Validate<T>(IExpectation<T> expectation) => expectation.Having().Should().BeSameAs(expectation).And.BeOfType<Expectation<T>>();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.With{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void With_Method()
  {
    using (new AssertionScope())
    {
      Validate(new Expectation<object>(null));
    }

    return;

    static void Validate<T>(IExpectation<T> expectation) => expectation.With().Should().BeSameAs(expectation).And.BeOfType<Expectation<T>>();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.Of{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Of_Method()
  {
    using (new AssertionScope())
    {
      Validate(new Expectation<object>(null));
    }

    return;

    static void Validate<T>(IExpectation<T> expectation) => expectation.Of().Should().BeSameAs(expectation).And.BeOfType<Expectation<T>>();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.At{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void At_Method()
  {
    using (new AssertionScope())
    {
      Validate(new Expectation<object>(null));
    }

    return;

    static void Validate<T>(IExpectation<T> expectation) => expectation.At().Should().BeSameAs(expectation).And.BeOfType<Expectation<T>>();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.On{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void On_Method()
  {
    using (new AssertionScope())
    {
      Validate(new Expectation<object>(null));
    }

    return;

    static void Validate<T>(IExpectation<T> expectation) => expectation.On().Should().BeSameAs(expectation).And.BeOfType<Expectation<T>>();
  }
}