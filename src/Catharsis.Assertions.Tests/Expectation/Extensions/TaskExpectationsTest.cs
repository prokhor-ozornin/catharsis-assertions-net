using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TaskExpectations"/>.</para>
/// </summary>
public sealed class TaskExpectationsTest : Test
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

      Test(true, Task.CompletedTask, TaskStatus.RanToCompletion);
      Test(false, Task.FromCanceled(new CancellationToken(true)), TaskStatus.RanToCompletion);
      Test(false, Task.FromException(new Exception()), TaskStatus.RanToCompletion);

      static void Test(bool result, Task task, TaskStatus status)
      {
        using (task)
        {
          task.Expect().Status(status).Should().BeOfType<Expectation<Task>>().Which.Result.Should().Be(result);
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Status<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Status(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, Task.FromResult<object>(null), TaskStatus.RanToCompletion);
      Test(false, Task.FromCanceled<object>(new CancellationToken(true)), TaskStatus.RanToCompletion);
      Test(false, Task.FromException<object>(new Exception()), TaskStatus.RanToCompletion);

      static void Test<T>(bool result, Task<T> task, TaskStatus status)
      {
        using (task)
        {
          task.Expect().Status(status).Should().BeOfType<Expectation<Task<T>>>().Which.Result.Should().Be(result);
        }
      }
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

      Test(true, Task.CompletedTask);
      Test(false, Task.FromCanceled(new CancellationToken(true)));
      Test(false, Task.FromException(new Exception()));

      static void Test(bool result, Task task)
      {
        using (task)
        {
          task.Expect().Successful().Should().BeOfType<Expectation<Task>>().Which.Result.Should().Be(result);
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Successful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Successful()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, Task.FromResult<object>(null));
      Test(false, Task.FromCanceled<object>(new CancellationToken(true)));
      Test(false, Task.FromException<object>(new Exception()));

      static void Test<T>(bool result, Task<T> task)
      {
        using (task)
        {
          task.Expect().Successful().Should().BeOfType<Expectation<Task<T>>>().Which.Result.Should().Be(result);
        }
      }
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

      Test(true, Task.FromException(new Exception()));
      Test(false, Task.CompletedTask);
      Test(false, Task.FromCanceled(new CancellationToken(true)));

      static void Test(bool result, Task task)
      {
        using (task)
        {
          task.Expect().Unsuccessful().Should().BeOfType<Expectation<Task>>().Which.Result.Should().Be(result);
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Unsuccessful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Unsuccessful()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, Task.FromException<object>(new Exception()));
      Test(false, Task.FromResult<object>(null));
      Test(false, Task.FromCanceled<object>(new CancellationToken(true)));

      static void Test<T>(bool result, Task<T> task)
      {
        using (task)
        {
          task.Expect().Unsuccessful().Should().BeOfType<Expectation<Task<T>>>().Which.Result.Should().Be(result);
        }
      }
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

      Test(true, Task.FromCanceled(new CancellationToken(true)));
      Test(false, Task.CompletedTask);
      Test(false, Task.FromException(new Exception()));

      static void Test(bool result, Task task)
      {
        using (task)
        {
          task.Expect().Canceled().Should().BeOfType<Expectation<Task>>().Which.Result.Should().Be(result);
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Canceled<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Canceled()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(false, Task.FromResult<object>(null));
      Test(true, Task.FromCanceled<object>(new CancellationToken(true)));
      Test(false, Task.FromException<object>(new Exception()));

      static void Test<T>(bool result, Task<T> task)
      {
        using (task)
        {
          task.Expect().Canceled().Should().BeOfType<Expectation<Task<T>>>().Which.Result.Should().Be(result);
        }
      }
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

      Test(true, Task.CompletedTask);
      Test(true, Task.FromCanceled(new CancellationToken(true)));
      Test(true, Task.FromException(new Exception()));

      static void Test(bool result, Task task)
      {
        using (task)
        {
          task.Expect().Completed().Should().BeOfType<Expectation<Task>>().Which.Result.Should().Be(result);
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Completed<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Completed()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, Task.FromResult<object>(null));
      Test(true, Task.FromCanceled<object>(new CancellationToken(true)));
      Test(true, Task.FromException<object>(new Exception()));

      static void Test<T>(bool result, Task<T> task)
      {
        using (task)
        {
          task.Expect().Completed().Should().BeOfType<Expectation<Task<T>>>().Which.Result.Should().Be(result);
        }
      }
    }
  }
}