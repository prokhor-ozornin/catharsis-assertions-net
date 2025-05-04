using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ThreadExpectations"/>.</para>
/// </summary>
public sealed class ThreadExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ThreadExpectations.State(IExpectation{Thread}, ThreadState)"/> method.</para>
  /// </summary>
  [Fact]
  public void State_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ThreadExpectations.State(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Thread) null).Expect().State(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Thread.CurrentThread.With(thread => Validate(true, thread, thread.ThreadState));
      Validate(false, Thread.CurrentThread, ThreadState.Unstarted);
    }

    return;

    static void Validate(bool result, Thread thread, ThreadState state) => thread.Expect().State(state).Should().BeOfType<Expectation<Thread>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ThreadExpectations.Priority(IExpectation{Thread}, ThreadPriority)"/> method.</para>
  /// </summary>
  [Fact]
  public void Priority_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ThreadExpectations.Priority(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Thread) null).Expect().Priority(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Thread.CurrentThread.With(thread => Validate(true, thread, thread.Priority));
      Validate(false, Thread.CurrentThread, ThreadPriority.Highest);
    }

    return;

    static void Validate(bool result, Thread thread, ThreadPriority priority) => thread.Expect().Priority(priority).Should().BeOfType<Expectation<Thread>>().Which.Result.Should().Be(result);
  }
}