using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

/// <summary>
///   <para>Tests set for class <see cref="ValueTaskExpectations"/>.</para>
/// </summary>
public sealed class ValueTaskExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskExpectations.Successful(IExpectation{ValueTask})"/></description></item>
  ///     <item><description><see cref="ValueTaskExpectations.Successful{T}(IExpectation{ValueTask{T}})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Successful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Successful(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Successful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskExpectations.Unsuccessful(IExpectation{ValueTask})"/></description></item>
  ///     <item><description><see cref="ValueTaskExpectations.Unsuccessful{T}(IExpectation{ValueTask{T}})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Unsuccessful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Unsuccessful(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Unsuccessful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskExpectations.Canceled(IExpectation{ValueTask})"/></description></item>
  ///     <item><description><see cref="ValueTaskExpectations.Canceled{T}(IExpectation{ValueTask{T}})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Canceled_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Canceled(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Canceled<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskExpectations.Completed(IExpectation{ValueTask})"/></description></item>
  ///     <item><description><see cref="ValueTaskExpectations.Completed{T}(IExpectation{ValueTask{T}})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Completed_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Completed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Completed<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

    }

    throw new NotImplementedException();
  }
}