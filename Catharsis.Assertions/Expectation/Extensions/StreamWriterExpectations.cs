using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="StreamWriter"/>
public static class StreamWriterExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="encoding"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<StreamWriter> Encoding(this IExpectation<StreamWriter> expectation, Encoding encoding) => expectation.HaveSubject().And().Expected(writer => writer.Encoding.Equals(encoding));
}