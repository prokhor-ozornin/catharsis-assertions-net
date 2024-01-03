using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

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

      ValueTask.CompletedTask.Expect().Successful().Result.Should().BeTrue();
      ValueTask.FromCanceled(new CancellationToken(true)).Expect().Successful().Result.Should().BeFalse();
      ValueTask.FromException(new Exception()).Expect().Successful().Result.Should().BeFalse();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Successful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      ValueTask.FromResult<object>(null).Expect().Successful().Result.Should().BeTrue();
      ValueTask.FromCanceled<object>(new CancellationToken(true)).Expect().Successful().Result.Should().BeFalse();
      ValueTask.FromException<object>(new Exception()).Expect().Successful().Result.Should().BeFalse();
    }
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

      ValueTask.CompletedTask.Expect().Unsuccessful().Result.Should().BeFalse();
      ValueTask.FromCanceled(new CancellationToken(true)).Expect().Unsuccessful().Result.Should().BeFalse();
      ValueTask.FromException(new Exception()).Expect().Unsuccessful().Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Unsuccessful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      ValueTask.FromResult<object>(null).Expect().Unsuccessful().Result.Should().BeFalse();
      ValueTask.FromCanceled<object>(new CancellationToken(true)).Expect().Unsuccessful().Result.Should().BeFalse();
      ValueTask.FromException<object>(new Exception()).Expect().Unsuccessful().Result.Should().BeTrue();
    }
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

      ValueTask.CompletedTask.Expect().Canceled().Result.Should().BeFalse();
      ValueTask.FromCanceled(new CancellationToken(true)).Expect().Canceled().Result.Should().BeTrue();
      ValueTask.FromException(new Exception()).Expect().Canceled().Result.Should().BeFalse();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Canceled<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      ValueTask.FromResult<object>(null).Expect().Canceled().Result.Should().BeFalse();
      ValueTask.FromCanceled<object>(new CancellationToken(true)).Expect().Canceled().Result.Should().BeTrue();
      ValueTask.FromException<object>(new Exception()).Expect().Canceled().Result.Should().BeFalse();
    }
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

      ValueTask.CompletedTask.Expect().Completed().Result.Should().BeTrue();
      ValueTask.FromCanceled(new CancellationToken(true)).Expect().Completed().Result.Should().BeTrue();
      ValueTask.FromException(new Exception()).Expect().Completed().Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Completed<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      ValueTask.FromResult<object>(null).Expect().Completed().Result.Should().BeTrue();
      ValueTask.FromCanceled<object>(new CancellationToken(true)).Expect().Completed().Result.Should().BeTrue();
      ValueTask.FromException<object>(new Exception()).Expect().Completed().Result.Should().BeTrue();
    }
  }
}