using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class StringExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="length"></param>
  /// <returns></returns>
  public static IExpectation<string> Length(this IExpectation<string> expectation, int length) => expectation.HaveSubject().And().Expect(text => text.Length == length);
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<string> Empty(this IExpectation<string> expectation) => expectation.Length(0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<string> UpperCased(this IExpectation<string> expectation) => expectation.HaveSubject().And().Expect(text => text.All(char.IsUpper));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<string> LowerCased(this IExpectation<string> expectation) => expectation.HaveSubject().And().Expect(text => text.All(char.IsLower));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="prefix"></param>
  /// <param name="comparison"></param>
  /// <returns></returns>
  public static IExpectation<string> StartWith(this IExpectation<string> expectation, string prefix, StringComparison? comparison = null) => expectation.HaveSubject().And().ThrowIfNull(prefix, nameof(prefix)).And().Expect(text => text.StartsWith(prefix, comparison.GetValueOrDefault()));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="postfix"></param>
  /// <param name="comparison"></param>
  /// <returns></returns>
  public static IExpectation<string> EndWith(this IExpectation<string> expectation, string postfix, StringComparison? comparison = null) => expectation.HaveSubject().And().ThrowIfNull(postfix, nameof(postfix)).And().Expect(text => text.EndsWith(postfix, comparison.GetValueOrDefault()));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="regex"></param>
  /// <returns></returns>
  public static IExpectation<string> Match(this IExpectation<string> expectation, Regex regex) => expectation.HaveSubject().And().ThrowIfNull(regex, nameof(regex)).And().Expect(regex.IsMatch);
}