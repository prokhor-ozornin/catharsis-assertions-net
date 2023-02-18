using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="StreamWriter"/> type.</para>
/// </summary>
/// <seealso cref="StreamWriter"/>
public static class StreamWriterExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="encoding"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<StreamWriter> Encoding(this IExpectation<StreamWriter> expectation, Encoding encoding) => expectation.HaveSubject().And().Expected(writer => writer.Encoding.Equals(encoding));
}