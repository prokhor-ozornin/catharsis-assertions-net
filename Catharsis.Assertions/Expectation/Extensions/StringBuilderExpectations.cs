using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class StringBuilderExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="length"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<StringBuilder> Length(this IExpectation<StringBuilder> expectation, int length) => expectation.HaveSubject().And().Expected(builder => builder.Length == length);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<StringBuilder> Empty(this IExpectation<StringBuilder> expectation) => expectation.Length(0);
}