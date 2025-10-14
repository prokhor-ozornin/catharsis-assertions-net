using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ValueTaskExpectations"/>.</para>
/// </summary>
/// <seealso cref="ValueTaskExpectations"/>
public sealed class ValueTaskExpectationsTest : Test
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

      Test(true, ValueTask.CompletedTask);
      Test(false, ValueTask.FromCanceled(new CancellationToken(true)));
      Test(false, ValueTask.FromException(new Exception()));

      static void Test(bool result, ValueTask task) => task.Expect().Successful().Should().BeOfType<Expectation<ValueTask>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Successful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Test(true, ValueTask.FromResult<object>(null));
      Test(false, ValueTask.FromCanceled<object>(new CancellationToken(true)));
      Test(false, ValueTask.FromException<object>(new Exception()));

      static void Test<T>(bool result, ValueTask<T> task) => task.Expect().Successful().Should().BeOfType<Expectation<ValueTask<T>>>().Which.Result.Should().Be(result);
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

      Test(true, ValueTask.FromException(new Exception()));
      Test(false, ValueTask.CompletedTask);
      Test(false, ValueTask.FromCanceled(new CancellationToken(true)));

      static void Test(bool result, ValueTask task) => task.Expect().Unsuccessful().Should().BeOfType<Expectation<ValueTask>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Unsuccessful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Test(true, ValueTask.FromException<object>(new Exception()));
      Test(false, ValueTask.FromResult<object>(null));
      Test(false, ValueTask.FromCanceled<object>(new CancellationToken(true)));

      static void Test<T>(bool result, ValueTask<T> task) => task.Expect().Unsuccessful().Should().BeOfType<Expectation<ValueTask<T>>>().Which.Result.Should().Be(result);
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

      Test(true, ValueTask.FromCanceled(new CancellationToken(true)));
      Test(false, ValueTask.CompletedTask);
      Test(false, ValueTask.FromException(new Exception()));

      static void Test(bool result, ValueTask task) => task.Expect().Canceled().Should().BeOfType<Expectation<ValueTask>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Canceled<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Test(true, ValueTask.FromCanceled<object>(new CancellationToken(true)));
      Test(false, ValueTask.FromResult<object>(null));
      Test(false, ValueTask.FromException<object>(new Exception()));

      static void Test<T>(bool result, ValueTask<T> task) => task.Expect().Canceled().Should().BeOfType<Expectation<ValueTask<T>>>().Which.Result.Should().Be(result);
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

      Test(true, ValueTask.CompletedTask);
      Test(true, ValueTask.FromCanceled(new CancellationToken(true)));
      Test(true, ValueTask.FromException(new Exception()));

      static void Test(bool result, ValueTask task) => task.Expect().Completed().Should().BeOfType<Expectation<ValueTask>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskExpectations.Completed<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Test(true, ValueTask.FromResult<object>(null));
      Test(true, ValueTask.FromCanceled<object>(new CancellationToken(true)));
      Test(true, ValueTask.FromException<object>(new Exception()));

      static void Test<T>(bool result, ValueTask<T> task) => task.Expect().Completed().Should().BeOfType<Expectation<ValueTask<T>>>().Which.Result.Should().Be(result);
    }
  }
}