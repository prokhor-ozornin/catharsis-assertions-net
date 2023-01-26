using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

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
    AssertionExtensions.Should(() => Expectation.Expected(null)).ThrowExactly<ArgumentNullException>().WithParameterName("predicate");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.HaveSubject{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void HaveSubject_Method()
  {
    AssertionExtensions.Should(() => IExpectationExtensions.HaveSubject<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    throw new NotImplementedException();
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

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IExpectationExtensions.ThrowIfFalse<object>(null, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => Expectation.ThrowIfFalse("message")).ThrowExactly<InvalidOperationException>().WithMessage("message");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.ThrowIfNull{T}(IExpectation{T}, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ThrowIfNull_Method()
  {
    AssertionExtensions.Should(() => IExpectationExtensions.ThrowIfNull<object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => Expectation.ThrowIfNull(null)).ThrowExactly<ArgumentNullException>().WithParameterName("instance");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.To{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void To_Method()
  {
    ((IExpectation<object>) null).To().Should().BeNull();
    Expectation.To().Should().NotBeNull().And.BeSameAs(Expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.And{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void And_Method()
  {
    ((IExpectation<object>) null).And().Should().BeNull();
    Expectation.And().Should().NotBeNull().And.BeSameAs(Expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.Be{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Be_Method()
  {
    ((IExpectation<object>) null).Be().Should().BeNull();
    Expectation.Be().Should().NotBeNull().And.BeSameAs(Expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.Having{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Having_Method()
  {
    ((IExpectation<object>) null).Having().Should().BeNull();
    Expectation.Having().Should().NotBeNull().And.BeSameAs(Expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.With{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void With_Method()
  {
    ((IExpectation<object>) null).With().Should().BeNull();
    Expectation.With().Should().NotBeNull().And.BeSameAs(Expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.Of{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Of_Method()
  {
    ((IExpectation<object>) null).Of().Should().BeNull();
    Expectation.Of().Should().NotBeNull().And.BeSameAs(Expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.At{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void At_Method()
  {
    ((IExpectation<object>) null).At().Should().BeNull();
    Expectation.At().Should().NotBeNull().And.BeSameAs(Expectation);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IExpectationExtensions.On{T}(IExpectation{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void On_Method()
  {
    ((IExpectation<object>) null).On().Should().BeNull();
    Expectation.On().Should().NotBeNull().And.BeSameAs(Expectation);
  }
}