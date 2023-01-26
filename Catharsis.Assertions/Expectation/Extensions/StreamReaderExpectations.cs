using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class StreamReaderExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="encoding"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<StreamReader> Encoding(this IExpectation<StreamReader> expectation, Encoding encoding) => expectation.HaveSubject().And().Expected(reader => reader.CurrentEncoding.Equals(encoding));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<StreamReader> End(this IExpectation<StreamReader> expectation) => expectation.HaveSubject().And().Expected(reader => reader.EndOfStream);
}