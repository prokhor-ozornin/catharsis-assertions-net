using System.Diagnostics;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ProcessExpectations.Exited(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Process) null).Expect().Exited()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, ShellProcess.Run(TimeSpan.Zero));
      Validate(false, Process.GetCurrentProcess());
    }

    return;

    static void Validate(bool result, Process process) => process.Expect().Exited().Should().BeOfType<Expectation<Process>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ProcessExpectations.ExitCode(IExpectation{Process}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void ExitCode_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ProcessExpectations.ExitCode(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Process) null).Expect().ExitCode(0)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      AssertionExtensions.Should(() => Process.GetCurrentProcess().Expect().ExitCode(0)).ThrowExactly<InvalidOperationException>();

      Validate(true, ShellProcess, ShellProcess.Run(TimeSpan.Zero).ExitCode);
      Validate(false, ShellProcess, 0);
    }

    return;

    static void Validate(bool result, Process process, int code) => process.Expect().ExitCode(code).Should().BeOfType<Expectation<Process>>().Which.Result.Should().Be(result);
  }
}