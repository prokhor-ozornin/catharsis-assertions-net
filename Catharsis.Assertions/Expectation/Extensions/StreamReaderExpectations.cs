using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="StreamReader"/> type.</para>
/// </summary>
/// <seealso cref="StreamReader"/>
public static class StreamReaderExpectations
{
  /// <summary>
  ///   <para>Expects that a given <see cref="StreamReader"/> uses a specified character encoding.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="encoding">Expected text character encoding.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<StreamReader> Encoding(this IExpectation<StreamReader> expectation, Encoding encoding) => expectation.HaveSubject().And().Expected(reader => reader.CurrentEncoding.Equals(encoding));

  /// <summary>
  ///   <para>Expects that a given <see cref="StreamReader"/> has reached the end of the underlying stream.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<StreamReader> End(this IExpectation<StreamReader> expectation) => expectation.HaveSubject().And().Expected(reader => reader.EndOfStream);
}