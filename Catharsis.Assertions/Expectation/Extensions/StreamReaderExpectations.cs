using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="StreamReader"/>
public static class StreamReaderExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="encoding"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<StreamReader> Encoding(this IExpectation<StreamReader> expectation, Encoding encoding) => expectation.HaveSubject().And().Expected(reader => reader.CurrentEncoding.Equals(encoding));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<StreamReader> End(this IExpectation<StreamReader> expectation) => expectation.HaveSubject().And().Expected(reader => reader.EndOfStream);
}