using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TaskAssertions"/>.</para>
/// </summary>
public sealed class TaskAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskAssertions.Status(IAssertion, Task, TaskStatus, string)"/></description></item>
  ///     <item><description><see cref="TaskAssertions.Status{T}(IAssertion, Task{T}, TaskStatus, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Status_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Status(null, Task.CompletedTask, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => TaskAssertions.Status(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      Validate(true, Task.CompletedTask, TaskStatus.RanToCompletion);
      Validate(false, Task.FromCanceled(default), TaskStatus.RanToCompletion);
      Validate(false, Task.FromException(new Exception()), TaskStatus.RanToCompletion);

      static void Validate(bool result, Task task, TaskStatus status)
      {
        using (task)
        {
          if (result)
          {
            Assert.To.Status(task, status).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
          }
          else
          {
            AssertionExtensions.Should(() => Assert.To.Status(task, status, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
          }
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Status(null, Task.FromResult<object>(null), default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Status<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      Validate(true, Task.FromResult<object>(null), TaskStatus.RanToCompletion);
      Validate(false, Task.FromCanceled<object>(new CancellationToken(true)), TaskStatus.RanToCompletion);
      Validate(false, Task.FromException<object>(new Exception()), TaskStatus.RanToCompletion);

      static void Validate<T>(bool result, Task<T> task, TaskStatus status)
      {
        using (task)
        {
          if (result)
          {
            Assert.To.Status(task, status).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
          }
          else
          {
            AssertionExtensions.Should(() => Assert.To.Status(task, status, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
          }
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskAssertions.Successful(IAssertion, Task, string)"/></description></item>
  ///     <item><description><see cref="TaskAssertions.Successful{T}(IAssertion, Task{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Successful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Successful(null, Task.CompletedTask)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => TaskAssertions.Successful(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      Validate(true, Task.CompletedTask);
      Validate(false, Task.FromCanceled(new CancellationToken(true)));
      Validate(false, Task.FromException(new Exception()));

      static void Validate(bool result, Task task)
      {
        using (task)
        {
          if (result)
          {
            Assert.To.Successful(task).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
          }
          else
          {
            AssertionExtensions.Should(() => Assert.To.Successful(task, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
          }
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Successful(null, Task.FromResult<object>(null))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Successful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      Validate(true, Task.FromResult<object>(null));
      Validate(false, Task.FromCanceled<object>(new CancellationToken(true)));
      Validate(false, Task.FromException<object>(new Exception()));

      static void Validate<T>(bool result, Task<T> task)
      {
        using (task)
        {
          if (result)
          {
            Assert.To.Successful(task).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
          }
          else
          {
            AssertionExtensions.Should(() => Assert.To.Successful(task, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
          }
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskAssertions.Unsuccessful(IAssertion, Task, string)"/></description></item>
  ///     <item><description><see cref="TaskAssertions.Unsuccessful{T}(IAssertion, Task{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Unsuccessful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Unsuccessful(null, Task.CompletedTask)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Unsuccessful(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      Validate(true, Task.FromException(new Exception()));
      Validate(false, Task.CompletedTask);
      Validate(false, Task.FromCanceled(new CancellationToken(true)));

      static void Validate(bool result, Task task)
      {
        using (task)
        {
          if (result)
          {
            Assert.To.Unsuccessful(task).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
          }
          else
          {
            AssertionExtensions.Should(() => Assert.To.Unsuccessful(task, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
          }
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Unsuccessful(null, Task.FromResult<object>(null))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Unsuccessful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      Validate(true, Task.FromException<object>(new Exception()));
      Validate(false, Task.FromResult<object>(null));
      Validate(false, Task.FromCanceled<object>(new CancellationToken(true)));

      static void Validate<T>(bool result, Task<T> task)
      {
        using (task)
        {
          if (result)
          {
            Assert.To.Unsuccessful(task).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
          }
          else
          {
            AssertionExtensions.Should(() => Assert.To.Unsuccessful(task, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
          }
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskAssertions.Canceled(IAssertion, Task, string)"/></description></item>
  ///     <item><description><see cref="TaskAssertions.Canceled{T}(IAssertion, Task{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Canceled_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Canceled(null, Task.CompletedTask)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Canceled(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      Validate(true, Task.FromCanceled(new CancellationToken(true)));
      Validate(false, Task.CompletedTask);
      Validate(false, Task.FromException(new Exception()));

      static void Validate(bool result, Task task)
      {
        using (task)
        {
          if (result)
          {
            Assert.To.Canceled(task).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
          }
          else
          {
            AssertionExtensions.Should(() => Assert.To.Canceled(task, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
          }
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Canceled(null, Task.FromResult<object>(null))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Canceled<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      Validate(false, Task.FromResult<object>(null));
      Validate(true, Task.FromCanceled<object>(new CancellationToken(true)));
      Validate(false, Task.FromException<object>(new Exception()));

      static void Validate<T>(bool result, Task<T> task)
      {
        using (task)
        {
          if (result)
          {
            Assert.To.Canceled(task).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
          }
          else
          {
            AssertionExtensions.Should(() => Assert.To.Canceled(task, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
          }
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskAssertions.Completed(IAssertion, Task, string)"/></description></item>
  ///     <item><description><see cref="TaskAssertions.Completed{T}(IAssertion, Task{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Completed_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Completed(null, Task.CompletedTask)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Completed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      Validate(true, Task.CompletedTask);
      Validate(true, Task.FromCanceled(new CancellationToken(true)));
      Validate(true, Task.FromException(new Exception()));

      static void Validate(bool result, Task task)
      {
        using (task)
        {
          if (result)
          {
            Assert.To.Completed(task).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
          }
          else
          {
            AssertionExtensions.Should(() => Assert.To.Completed(task, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
          }
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskAssertions.Completed(null, Task.FromResult<object>(null))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Completed<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("task");

      Validate(true, Task.FromResult<object>(null));
      Validate(true, Task.FromCanceled<object>(new CancellationToken(true)));
      Validate(true, Task.FromException<object>(new Exception()));

      static void Validate<T>(bool result, Task<T> task)
      {
        using (task)
        {
          if (result)
          {
            Assert.To.Completed(task).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
          }
          else
          {
            AssertionExtensions.Should(() => Assert.To.Completed(task, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
          }
        }
      }
    }
  }
}