using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para></para>
/// </summary>
public abstract class UnitTest : IDisposable
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  protected FileInfo RandomFile => new Random().FilePath().ToFile();

  /// <summary>
  ///   <para></para>
  /// </summary>
  protected DirectoryInfo RandomDirectory => new Random().DirectoryPath().ToDirectory();

  /// <summary>
  ///   <para></para>
  /// </summary>
  public virtual void Dispose()
  {
  }
}