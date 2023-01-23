using System.Diagnostics;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ProcessAssertions"/>.</para>
/// </summary>
public sealed class ProcessAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ProcessAssertions.Exited(IAssertion, Process, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Exited_Method()
  {
    AssertionExtensions.Should(() => ProcessAssertions.Exited(null, Process.GetCurrentProcess())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Exited(null)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ProcessAssertions.ExitCode(IAssertion, Process, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ExitCode_Method()
  {
    AssertionExtensions.Should(() => ProcessAssertions.ExitCode(null, Process.GetCurrentProcess(), default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ExitCode(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }
}