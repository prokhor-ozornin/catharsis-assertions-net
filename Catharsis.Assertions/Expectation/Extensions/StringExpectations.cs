using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="string"/> type.</para>
/// </summary>
/// <seealso cref="string"/>
public static class StringExpectations
{
  /// <summary>
  ///   <para>Expects that a given string is of specified length.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="length">String length.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<string> Length(this IExpectation<string> expectation, int length) => expectation.HaveSubject().And().Expected(text => text.Length == length);

  /// <summary>
  ///   <para>Expects that a given string is empty (contains no characters).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<string> Empty(this IExpectation<string> expectation) => expectation.Length(0);

  /// <summary>
  ///   <para>Expects that a given string is either <see langword="null"/>, empty, or consists only of white-space characters.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<string> WhiteSpace(this IExpectation<string> expectation) => expectation.HaveSubject().And().Expected(string.IsNullOrWhiteSpace);

  /// <summary>
  ///   <para>Expects that a given string consists only of upper-cased characters.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="LowerCased(IExpectation{string})"/>
  public static IExpectation<string> UpperCased(this IExpectation<string> expectation) => expectation.HaveSubject().And().Expected(text => text.All(char.IsUpper));

  /// <summary>
  ///   <para>Expects that a given string consists only of upper-cased characters.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="UpperCased(IExpectation{string})"/>
  public static IExpectation<string> LowerCased(this IExpectation<string> expectation) => expectation.HaveSubject().And().Expected(text => text.All(char.IsLower));

  /// <summary>
  ///   <para>Expects that the beginning of a given string matches the specified prefix string.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="prefix">Starting string prefix.</param>
  /// <param name="comparison">Strings comparison options.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="prefix"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="EndWith(IExpectation{string}, string, StringComparison?)"/>
  public static IExpectation<string> StartWith(this IExpectation<string> expectation, string prefix, StringComparison? comparison = null) => expectation.HaveSubject().And().ThrowIfNull(prefix, nameof(prefix)).And().Expected(text => text.StartsWith(prefix, comparison.GetValueOrDefault()));

  /// <summary>
  ///   <para>Expects that the end of a given string matches the specified postfix string.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="postfix">Ending string postfix.</param>
  /// <param name="comparison">Strings comparison options.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="postfix"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="StartWith(IExpectation{string}, string, StringComparison?)"/>
  public static IExpectation<string> EndWith(this IExpectation<string> expectation, string postfix, StringComparison? comparison = null) => expectation.HaveSubject().And().ThrowIfNull(postfix, nameof(postfix)).And().Expected(text => text.EndsWith(postfix, comparison.GetValueOrDefault()));

  /// <summary>
  ///   <para>Expects that a given string matches a specified regular expression.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="regex">Regular expression to match against.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="regex"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<string> Match(this IExpectation<string> expectation, Regex regex) => expectation.HaveSubject().And().ThrowIfNull(regex, nameof(regex)).And().Expected(regex.IsMatch);
}