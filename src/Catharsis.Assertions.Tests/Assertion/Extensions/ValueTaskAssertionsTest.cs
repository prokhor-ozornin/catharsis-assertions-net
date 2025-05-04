using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ValueTaskAssertions"/>.</para>
/// </summary>
public sealed class ValueTaskAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskAssertions.Successful(IAssertion, ValueTask, string)"/></description></item>
  ///     <item><description><see cref="ValueTaskAssertions.Successful{T}(IAssertion, ValueTask{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Successful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Successful(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Validate(true, ValueTask.CompletedTask);
      Validate(false, ValueTask.FromCanceled(new CancellationToken(true)));
      Validate(false, ValueTask.FromException(new Exception()));

      static void Validate(bool result, ValueTask task)
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

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Successful<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Validate(true, ValueTask.FromResult<object>(null));
      Validate(false, ValueTask.FromCanceled<object>(new CancellationToken(true)));
      Validate(false, ValueTask.FromException<object>(new Exception()));

      static void Validate<T>(bool result, ValueTask<T> task)
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

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskAssertions.Unsuccessful(IAssertion, ValueTask, string)"/></description></item>
  ///     <item><description><see cref="ValueTaskAssertions.Unsuccessful{T}(IAssertion, ValueTask{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Unsuccessful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Unsuccessful(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Validate(true, ValueTask.FromException(new Exception()));
      Validate(false, ValueTask.CompletedTask);
      Validate(false, ValueTask.FromCanceled(new CancellationToken(true)));

      static void Validate(bool result, ValueTask task)
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

    using (new AssertionScope())
    {
      Validate(true, ValueTask.FromException<object>(new Exception()));
      Validate(false, ValueTask.FromResult<object>(null));
      Validate(false, ValueTask.FromCanceled<object>(new CancellationToken(true)));

      static void Validate<T>(bool result, ValueTask<T> task)
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

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskAssertions.Canceled(IAssertion, ValueTask, string)"/></description></item>
  ///     <item><description><see cref="ValueTaskAssertions.Canceled{T}(IAssertion, ValueTask{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Canceled_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Canceled(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Validate(true, ValueTask.FromCanceled(new CancellationToken(true)));
      Validate(false, ValueTask.CompletedTask);
      Validate(false, ValueTask.FromException(new Exception()));

      static void Validate(bool result, ValueTask task)
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

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Canceled<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Validate(true, ValueTask.FromCanceled<object>(new CancellationToken(true)));
      Validate(false, ValueTask.FromResult<object>(null));
      Validate(false, ValueTask.FromException<object>(new Exception()));

      static void Validate<T>(bool result, ValueTask<T> task)
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

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="ValueTaskAssertions.Completed(IAssertion, ValueTask, string)"/></description></item>
  ///     <item><description><see cref="ValueTaskAssertions.Completed{T}(IAssertion, ValueTask{T}, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Completed_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Completed(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Validate(true, ValueTask.CompletedTask);
      Validate(true, ValueTask.FromCanceled(new CancellationToken(true)));
      Validate(true, ValueTask.FromException(new Exception()));

      static void Validate(bool result, ValueTask task)
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

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ValueTaskAssertions.Completed<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

      Validate(true, ValueTask.FromResult<object>(null));
      Validate(true, ValueTask.FromCanceled<object>(new CancellationToken(true)));
      Validate(true, ValueTask.FromException<object>(new Exception()));

      static void Validate<T>(bool result, ValueTask<T> task)
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