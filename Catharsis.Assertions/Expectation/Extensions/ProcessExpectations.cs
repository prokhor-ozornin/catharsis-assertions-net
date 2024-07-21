using System.Diagnostics;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="Process"/> type.</para>
/// </summary>
/// <seealso cref="Process"/>
public static class ProcessExpectations
{
  /// <summary>
  ///   <para>Expects that a given <see cref="Process"/> has been terminated.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<Process> Exited(this IExpectation<Process> expectation) => expectation.HaveSubject().And().Expected(process => process.HasExited);

  /// <summary>
  ///   <para>Expects that a given <see cref="Process"/> has set a specified exit code when it terminated.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="code">Expected process exit code.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<Process> ExitCode(this IExpectation<Process> expectation, int code) => expectation.HaveSubject().And().Expected(process => process.ExitCode == code);
}