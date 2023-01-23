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
  public static IExpectation<StringBuilder> Length(this IExpectation<StringBuilder> expectation, int length) => expectation.HaveSubject().And().Expect(builder => builder.Length == length);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<StringBuilder> Empty(this IExpectation<StringBuilder> expectation) => expectation.Length(0);
}