using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="StreamReader"/> type.</para>
/// </summary>
/// <seealso cref="StreamReader"/>
public static class StreamReaderExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<StreamReader> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="StreamReader"/> uses a specified <see cref="Encoding"/>.</para>
    /// </summary>
    /// <param name="encoding">Expected character encoding.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<StreamReader> Encoding(Encoding encoding) => expectation.HaveSubject().And().Expected(reader => reader.CurrentEncoding.Equals(encoding));

    /// <summary>
    ///   <para>Expects that the given <see cref="StreamReader"/> has reached the end of its underlying <see cref="Stream"/>.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<StreamReader> End() => expectation.HaveSubject().And().Expected(reader => reader.EndOfStream);
  }
}