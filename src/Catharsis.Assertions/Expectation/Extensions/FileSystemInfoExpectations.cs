namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="FileSystemInfo"/> type.</para>
/// </summary>
/// <seealso cref="FileSystemInfo"/>
public static class FileSystemInfoExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<FileSystemInfo> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="FileSystemInfo"/> exists.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<FileSystemInfo> Exist() => expectation.HaveSubject().And().Expected(info => info.Exists);

    /// <summary>
    ///   <para>Expects that the given <see cref="FileSystemInfo"/> has a specific attribute.</para>
    /// </summary>
    /// <param name="attribute">Expected attribute.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<FileSystemInfo> Attribute(FileAttributes attribute) => expectation.HaveSubject().And().Expected(info => (info.Attributes & attribute) == attribute);
  }
}