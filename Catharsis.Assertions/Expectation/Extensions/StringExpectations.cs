using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="string"/> type.</para>
/// </summary>
/// <seealso cref="string"/>
public static class StringExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="string"/> has the specified length.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="length">Expected string length.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<string> Length(this IExpectation<string> expectation, int length) => expectation.HaveSubject().And().Expected(text => text.Length == length);

  /// <summary>
  ///   <para>Expects that the given <see cref="string"/> is empty, meaning it contains no characters.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<string> Empty(this IExpectation<string> expectation) => expectation.Length(0);

  /// <summary>
  ///   <para>Expects that the given <see cref="string"/> is either <see langword="null"/>, empty, or consists only of white-space characters.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<string> WhiteSpace(this IExpectation<string> expectation) => expectation.HaveSubject().And().Expected(string.IsNullOrWhiteSpace);

  /// <summary>
  ///   <para>Expects that the given <see cref="string"/> consists only of upper-cased characters.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  /// <seealso cref="LowerCased(IExpectation{string})"/>
  public static IExpectation<string> UpperCased(this IExpectation<string> expectation) => expectation.HaveSubject().And().Expected(text => text.All(char.IsUpper));

  /// <summary>
  ///   <para>Expects that the given <see cref="string"/> consists only of lower-cased characters.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  /// <seealso cref="UpperCased(IExpectation{string})"/>
  public static IExpectation<string> LowerCased(this IExpectation<string> expectation) => expectation.HaveSubject().And().Expected(text => text.All(char.IsLower));

  /// <summary>
  ///   <para>Expects that the given <see cref="string"/> begins with a specified prefix substring.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="prefix">Expected string prefix.</param>
  /// <param name="comparison">Strings comparison rules.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="prefix"/> is <see langword="null"/>.</exception>
  /// <seealso cref="EndWith(IExpectation{string}, string, StringComparison?)"/>
  public static IExpectation<string> StartWith(this IExpectation<string> expectation, string prefix, StringComparison? comparison = null) => expectation.HaveSubject().And().ThrowIfNull(prefix, nameof(prefix)).And().Expected(text => text.StartsWith(prefix, comparison.GetValueOrDefault()));

  /// <summary>
  ///   <para>Expects that the given <see cref="string"/> ends with a specified postfix substring.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="postfix">Ending string postfix.</param>
  /// <param name="comparison">Strings comparison options.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="postfix"/> is <see langword="null"/>.</exception>
  /// <seealso cref="StartWith(IExpectation{string}, string, StringComparison?)"/>
  public static IExpectation<string> EndWith(this IExpectation<string> expectation, string postfix, StringComparison? comparison = null) => expectation.HaveSubject().And().ThrowIfNull(postfix, nameof(postfix)).And().Expected(text => text.EndsWith(postfix, comparison.GetValueOrDefault()));

  /// <summary>
  ///   <para>Expects that the given <see cref="string"/> matches the specified regular expression.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="regex">Regular expression to match.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="regex"/> is <see langword="null"/>.</exception>
  public static IExpectation<string> Match(this IExpectation<string> expectation, Regex regex) => expectation.HaveSubject().And().ThrowIfNull(regex, nameof(regex)).And().Expected(regex.IsMatch);
}