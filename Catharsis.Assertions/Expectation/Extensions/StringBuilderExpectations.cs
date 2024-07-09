using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="StringBuilder"/> type.</para>
/// </summary>
/// <seealso cref="StringBuilder"/>
public static class StringBuilderExpectations
{
  /// <summary>
  ///   <para>Expects that a given string builder contains a specified number of characters.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="length">Expected string builder length.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<StringBuilder> Length(this IExpectation<StringBuilder> expectation, int length) => expectation.HaveSubject().And().Expected(builder => builder.Length == length);

  /// <summary>
  ///   <para>Expects that a given string builder is empty (contains no characters).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<StringBuilder> Empty(this IExpectation<StringBuilder> expectation) => expectation.Length(0);
}