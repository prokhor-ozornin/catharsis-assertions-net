using System.Diagnostics;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class ProcessExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Process> Exited(this IExpectation<Process> expectation) => expectation.HaveSubject().And().Expected(process => process.HasExited);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="code"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Process> ExitCode(this IExpectation<Process> expectation, int code) => expectation.HaveSubject().And().Expected(process => process.ExitCode == code);
}