using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="string"/>
public static class StringExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="length"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<string> Length(this IExpectation<string> expectation, int length) => expectation.HaveSubject().And().Expected(text => text.Length == length);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<string> Empty(this IExpectation<string> expectation) => expectation.Length(0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<string> WhiteSpace(this IExpectation<string> expectation) => expectation.HaveSubject().And().Expected(string.IsNullOrWhiteSpace);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="LowerCased(IExpectation{string})"/>
  public static IExpectation<string> UpperCased(this IExpectation<string> expectation) => expectation.HaveSubject().And().Expected(text => text.All(char.IsUpper));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="UpperCased(IExpectation{string})"/>
  public static IExpectation<string> LowerCased(this IExpectation<string> expectation) => expectation.HaveSubject().And().Expected(text => text.All(char.IsLower));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="prefix"></param>
  /// <param name="comparison"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="EndWith(IExpectation{string}, string, StringComparison?)"/>
  public static IExpectation<string> StartWith(this IExpectation<string> expectation, string prefix, StringComparison? comparison = null) => expectation.HaveSubject().And().ThrowIfNull(prefix, nameof(prefix)).And().Expected(text => text.StartsWith(prefix, comparison.GetValueOrDefault()));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="postfix"></param>
  /// <param name="comparison"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="StartWith(IExpectation{string}, string, StringComparison?)"/>
  public static IExpectation<string> EndWith(this IExpectation<string> expectation, string postfix, StringComparison? comparison = null) => expectation.HaveSubject().And().ThrowIfNull(postfix, nameof(postfix)).And().Expected(text => text.EndsWith(postfix, comparison.GetValueOrDefault()));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="regex"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<string> Match(this IExpectation<string> expectation, Regex regex) => expectation.HaveSubject().And().ThrowIfNull(regex, nameof(regex)).And().Expected(regex.IsMatch);
}