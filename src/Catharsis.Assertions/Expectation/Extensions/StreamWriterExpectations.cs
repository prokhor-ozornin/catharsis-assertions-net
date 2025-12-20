using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="StreamWriter"/> type.</para>
/// </summary>
/// <seealso cref="StreamWriter"/>
public static class StreamWriterExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<StreamWriter> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="StreamWriter"/> uses a specified <see cref="Encoding"/>.</para>
    /// </summary>
    /// <param name="encoding">Expected character encoding.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<StreamWriter> Encoding(Encoding encoding) => expectation.HaveSubject().And().Expected(writer => writer.Encoding.Equals(encoding));
  }
}