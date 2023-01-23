namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class StreamExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="length"></param>
  /// <returns></returns>
  public static IExpectation<Stream> Length(this IExpectation<Stream> expectation, long length) => expectation.HaveSubject().And().Expect(stream => stream.Length == length);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="position"></param>
  /// <returns></returns>
  public static IExpectation<Stream> Position(this IExpectation<Stream> expectation, long position) => expectation.HaveSubject().And().Expect(stream => stream.Position == position);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Stream> Empty(this IExpectation<Stream> expectation) => expectation.Length(0);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Stream> Readable(this IExpectation<Stream> expectation) => expectation.HaveSubject().And().Expect(stream => stream.CanRead);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Stream> Writable(this IExpectation<Stream> expectation) => expectation.HaveSubject().And().Expect(stream => stream.CanWrite);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Stream> Seekable(this IExpectation<Stream> expectation) => expectation.HaveSubject().And().Expect(stream => stream.CanSeek);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Stream> ReadOnly(this IExpectation<Stream> expectation) => expectation.HaveSubject().And().Expect(stream => stream.CanRead && !stream.CanWrite);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Stream> WriteOnly(this IExpectation<Stream> expectation) => expectation.HaveSubject().And().Expect(stream => stream.CanWrite && !stream.CanRead);
}