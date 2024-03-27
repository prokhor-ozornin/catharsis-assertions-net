using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IExpectationExtensions"/>.</para>
/// </summary>
public sealed class IExpectationExtensionsTest : UnitTest
{
  private IExpectation<object> Expectation { get; } = new Expectation<object>(null);

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.Expected{T}(IExpectation{T}, Predicate{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Expected_Method()
  {
    AssertionExtensions.Should(() => IExpectationExtensions.Expected<object>(null, _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => Expectation.Expected(null)).ThrowExactly<ArgumentNullException>().WithParameterName("result");

    new Expectation<object>(null).Expected(_ => true).Result.Should().BeTrue();
    new Expectation<object>(null).Expected(_ => false).Result.Should().BeFalse();
    new Expectation<object>(null).Not().Expected(_ => true).Result.Should().BeFalse();
    new Expectation<object>(null).Not().Expected(_ => false).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.HaveSubject{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void HaveSubject_Method()
  {
    AssertionExtensions.Should(() => IExpectationExtensions.HaveSubject<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    AssertionExtensions.Should(() => new Expectation<object>(null).HaveSubject()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    new Expectation<object>(new object()).HaveSubject().Result.Should().BeTrue();
    new Expectation<object>(new object()).Not().HaveSubject().Result.Should().BeFalse();
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
      AssertionExtensions.Should(() => Expectation.ThrowIfFalse((Exception) null)).ThrowExactly<ArgumentNullException>().WithParameterName("exception");

      AssertionExtensions.Should(() => new Expectation<object>(null).Expect(_ => false).ThrowIfFalse(new Exception("error"))).ThrowExactly<Exception>().WithMessage("error");
      new Expectation<object>(null).With(expectation => expectation.ThrowIfFalse(new Exception()).Should().BeOfType<Expectation<object>>().And.BeSameAs(expectation));
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IExpectationExtensions.ThrowIfFalse<object>(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => new Expectation<object>(null).Expect(_ => false).ThrowIfFalse("message")).ThrowExactly<InvalidOperationException>().WithMessage("message");

      AssertionExtensions.Should(() => new Expectation<object>(null).Expect(_ => false).ThrowIfFalse("error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      new Expectation<object>(null).With(expectation => expectation.ThrowIfFalse("error").Should().BeOfType<Expectation<object>>().And.BeSameAs(expectation));
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.ThrowIfNull{T}(IExpectation{T}, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ThrowIfNull_Method()
  {
    AssertionExtensions.Should(() => IExpectationExtensions.ThrowIfNull<object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => Expectation.ThrowIfNull(null)).ThrowExactly<ArgumentNullException>().WithParameterName("instance");
    AssertionExtensions.Should(() => Expectation.ThrowIfNull(null, "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");

    new Expectation<object>(null).With(expectation => expectation.ThrowIfNull(new object()).Should().BeOfType<Expectation<object>>().And.BeSameAs(expectation));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.To{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void To_Method()
  {
    ((IExpectation<object>) null).To().Should().BeNull();
    Expectation.To().Should().BeOfType<Expectation<object>>().And.BeSameAs(Expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.And{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void And_Method()
  {
    ((IExpectation<object>) null).And().Should().BeNull();
    Expectation.And().Should().BeOfType<Expectation<object>>().And.BeSameAs(Expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.Be{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Be_Method()
  {
    ((IExpectation<object>) null).Be().Should().BeNull();
    Expectation.Be().Should().BeOfType<Expectation<object>>().And.BeSameAs(Expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.Having{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Having_Method()
  {
    ((IExpectation<object>) null).Having().Should().BeNull();
    Expectation.Having().Should().BeOfType<Expectation<object>>().And.BeSameAs(Expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.With{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void With_Method()
  {
    ((IExpectation<object>) null).With().Should().BeNull();
    Expectation.With().Should().BeOfType<Expectation<object>>().And.BeSameAs(Expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.Of{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Of_Method()
  {
    ((IExpectation<object>) null).Of().Should().BeNull();
    Expectation.Of().Should().BeOfType<Expectation<object>>().And.BeSameAs(Expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.At{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void At_Method()
  {
    ((IExpectation<object>) null).At().Should().BeNull();
    Expectation.At().Should().BeOfType<Expectation<object>>().And.BeSameAs(Expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.On{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void On_Method()
  {
    ((IExpectation<object>) null).On().Should().BeNull();
    Expectation.On().Should().BeOfType<Expectation<object>>().And.BeSameAs(Expectation);
  }
}