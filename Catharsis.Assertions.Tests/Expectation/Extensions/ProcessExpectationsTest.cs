using System.Diagnostics;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ProcessExpectations"/>.</para>
/// </summary>
public sealed class ProcessExpectationsTest : UnitTest
{
  private Process ShellProcess { get; } = "cmd.exe".ToProcess();

  /// <summary>
  ///   <para>Performs testing of <see cref="ProcessExpectations.Exited(IExpectation{Process})"/> method.</para>
  /// </summary>
  [Fact]
  public void Exited_Method()
  {
    AssertionExtensions.Should(() => ProcessExpectations.Exited(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Process) null).Expect().Exited()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Process.GetCurrentProcess().Expect().Exited().Result.Should().BeFalse();

    ShellProcess.With(process =>
    {
      process.TryFinallyKill(process => process.Start());
      process.Expect().Exited().Result.Should().BeTrue();
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ProcessExpectations.ExitCode(IExpectation{Process}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void ExitCode_Method()
  {
    AssertionExtensions.Should(() => ProcessExpectations.ExitCode(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Process) null).Expect().ExitCode(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    AssertionExtensions.Should(() => Process.GetCurrentProcess().Expect().ExitCode(0)).ThrowExactly<InvalidOperationException>();

    ShellProcess.With(process =>
    {
      process.TryFinallyKill(process => process.Start());
      process.Expect().ExitCode(0).Result.Should().BeFalse();
      process.Expect().ExitCode(process.ExitCode).Result.Should().BeTrue();
    });
  }
}