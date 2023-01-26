using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ProcessExpectations"/>.</para>
/// </summary>
public sealed class ProcessExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ProcessExpectations.Exited(IExpectation{Process})"/> method.</para>
  /// </summary>
  [Fact]
  public void Exited_Method()
  {
    AssertionExtensions.Should(() => ProcessExpectations.Exited(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Process) null).Expect().Exited()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ProcessExpectations.ExitCode(IExpectation{Process}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void ExitCode_Method()
  {
    AssertionExtensions.Should(() => ProcessExpectations.ExitCode(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Process) null).Expect().ExitCode(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }
}