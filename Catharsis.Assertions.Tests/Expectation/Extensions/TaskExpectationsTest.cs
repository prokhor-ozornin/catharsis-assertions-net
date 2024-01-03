using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TaskExpectations"/>.</para>
/// </summary>
public sealed class TaskExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskExpectations.Status(IExpectation{Task}, TaskStatus)"/></description></item>
  ///     <item><description><see cref="TaskExpectations.Status{T}(IExpectation{Task{T}}, TaskStatus)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Status_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Status(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task) null).Expect().Status(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Task.CompletedTask.Expect().Status(TaskStatus.RanToCompletion).Result.Should().BeTrue();
      Task.FromCanceled(new CancellationToken(true)).Expect().Status(TaskStatus.RanToCompletion).Result.Should().BeFalse();
      Task.FromException(new Exception()).Expect().Status(TaskStatus.RanToCompletion).Result.Should().BeFalse();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Status<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Status(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Task.FromResult<object>(null).Expect().Status(TaskStatus.RanToCompletion).Result.Should().BeTrue();
      Task.FromCanceled<object>(new CancellationToken(true)).Expect().Status(TaskStatus.RanToCompletion).Result.Should().BeFalse();
      Task.FromException<object>(new Exception()).Expect().Status(TaskStatus.RanToCompletion).Result.Should().BeFalse();
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskExpectations.Successful(IExpectation{Task})"/></description></item>
  ///     <item><description><see cref="TaskExpectations.Successful{T}(IExpectation{Task{T}})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Successful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Successful(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task) null).Expect().Successful()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Task.CompletedTask.Expect().Successful().Result.Should().BeTrue();
      Task.FromCanceled(new CancellationToken(true)).Expect().Successful().Result.Should().BeFalse();
      Task.FromException(new Exception()).Expect().Successful().Result.Should().BeFalse();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Successful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Successful()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Task.FromResult<object>(null).Expect().Successful().Result.Should().BeTrue();
      Task.FromCanceled<object>(new CancellationToken(true)).Expect().Successful().Result.Should().BeFalse();
      Task.FromException<object>(new Exception()).Expect().Successful().Result.Should().BeFalse();
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskExpectations.Unsuccessful(IExpectation{Task})"/></description></item>
  ///     <item><description><see cref="TaskExpectations.Unsuccessful{T}(IExpectation{Task{T}})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Unsuccessful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Unsuccessful(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task) null).Expect().Unsuccessful()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Task.CompletedTask.Expect().Unsuccessful().Result.Should().BeFalse();
      Task.FromCanceled(new CancellationToken(true)).Expect().Unsuccessful().Result.Should().BeFalse();
      Task.FromException(new Exception()).Expect().Unsuccessful().Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Unsuccessful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Unsuccessful()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Task.FromResult<object>(null).Expect().Unsuccessful().Result.Should().BeFalse();
      Task.FromCanceled<object>(new CancellationToken(true)).Expect().Unsuccessful().Result.Should().BeFalse();
      Task.FromException<object>(new Exception()).Expect().Unsuccessful().Result.Should().BeTrue();
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskExpectations.Canceled(IExpectation{Task})"/></description></item>
  ///     <item><description><see cref="TaskExpectations.Canceled{T}(IExpectation{Task{T}})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Canceled_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Canceled(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task) null).Expect().Canceled()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Task.CompletedTask.Expect().Canceled().Result.Should().BeFalse();
      Task.FromCanceled(new CancellationToken(true)).Expect().Canceled().Result.Should().BeTrue();
      Task.FromException(new Exception()).Expect().Canceled().Result.Should().BeFalse();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Canceled<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Canceled()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Task.FromResult<object>(null).Expect().Canceled().Result.Should().BeFalse();
      Task.FromCanceled<object>(new CancellationToken(true)).Expect().Canceled().Result.Should().BeTrue();
      Task.FromException<object>(new Exception()).Expect().Canceled().Result.Should().BeFalse();
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskExpectations.Completed(IExpectation{Task})"/></description></item>
  ///     <item><description><see cref="TaskExpectations.Completed{T}(IExpectation{Task{T}})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Completed_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Completed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task) null).Expect().Completed()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Task.CompletedTask.Expect().Completed().Result.Should().BeTrue();
      Task.FromCanceled(new CancellationToken(true)).Expect().Completed().Result.Should().BeTrue();
      Task.FromException(new Exception()).Expect().Completed().Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Completed<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Completed()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Task.FromResult<object>(null).Expect().Completed().Result.Should().BeTrue();
      Task.FromCanceled<object>(new CancellationToken(true)).Expect().Completed().Result.Should().BeTrue();
      Task.FromException<object>(new Exception()).Expect().Completed().Result.Should().BeTrue();
    }
  }
}