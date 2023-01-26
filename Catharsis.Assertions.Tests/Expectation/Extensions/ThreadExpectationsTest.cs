using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ThreadExpectations"/>.</para>
/// </summary>
public sealed class ThreadExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ThreadExpectations.State(IExpectation{Thread}, ThreadState)"/> method.</para>
  /// </summary>
  [Fact]
  public void State_Method()
  {
    AssertionExtensions.Should(() => ThreadExpectations.State(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Thread) null).Expect().State(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ThreadExpectations.Priority(IExpectation{Thread}, ThreadPriority)"/> method.</para>
  /// </summary>
  [Fact]
  public void Priority_Method()
  {
    AssertionExtensions.Should(() => ThreadExpectations.Priority(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Thread) null).Expect().Priority(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }
}