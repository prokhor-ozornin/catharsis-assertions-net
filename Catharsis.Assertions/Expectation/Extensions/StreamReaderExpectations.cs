using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="StreamReader"/> type.</para>
/// </summary>
/// <seealso cref="StreamReader"/>
public static class StreamReaderExpectations
{
  /// <summary>
  ///   <para>Expects that a given stream reader uses a specified character encoding.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="encoding">Text character encoding.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<StreamReader> Encoding(this IExpectation<StreamReader> expectation, Encoding encoding) => expectation.HaveSubject().And().Expected(reader => reader.CurrentEncoding.Equals(encoding));

  /// <summary>
  ///   <para>Expects that a given stream reader has reached the end of the underlying stream.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<StreamReader> End(this IExpectation<StreamReader> expectation) => expectation.HaveSubject().And().Expected(reader => reader.EndOfStream);
}