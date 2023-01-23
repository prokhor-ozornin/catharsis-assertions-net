using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class StreamWriterExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="encoding"></param>
  /// <returns></returns>
  public static IExpectation<StreamWriter> Encoding(this IExpectation<StreamWriter> expectation, Encoding encoding) => expectation.HaveSubject().And().Expect(writer => writer.Encoding.Equals(encoding));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="format"></param>
  /// <returns></returns>
  public static IExpectation<StreamWriter> Format(this IExpectation<StreamWriter> expectation, IFormatProvider format) => expectation.HaveSubject().And().Expect(writer => writer.FormatProvider.Equals(format));
}