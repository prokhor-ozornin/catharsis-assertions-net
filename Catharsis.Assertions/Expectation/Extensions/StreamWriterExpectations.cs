using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="StreamWriter"/> type.</para>
/// </summary>
/// <seealso cref="StreamWriter"/>
public static class StreamWriterExpectations
{
  /// <summary>
  ///   <para>Expects that a given <see cref="StreamWriter"/> uses a specified character encoding.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="encoding">Expected text character encoding.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<StreamWriter> Encoding(this IExpectation<StreamWriter> expectation, Encoding encoding) => expectation.HaveSubject().And().Expected(writer => writer.Encoding.Equals(encoding));
}