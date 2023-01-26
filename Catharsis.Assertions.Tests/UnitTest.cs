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
  protected static Random Randomizer { get; } = new();

  /// <summary>
  ///   <para></para>
  /// </summary>
  protected string RandomString { get; } = Randomizer.Letters(byte.MaxValue);

  /// <summary>
  ///   <para></para>
  /// </summary>
  protected Stream RandomStream { get; } = Randomizer.MemoryStream(short.MaxValue);

  /// <summary>
  ///   <para></para>
  /// </summary>
  protected FileInfo RandomFile { get; } = Randomizer.BinaryFile(short.MaxValue);

  /// <summary>
  ///   <para></para>
  /// </summary>
  protected DirectoryInfo RandomDirectory { get; } = Randomizer.Directory();

  /// <summary>
  ///   <para></para>
  /// </summary>
  public virtual void Dispose()
  {
    RandomFile.With(file => file.IsReadOnly = false).Delete();
    RandomDirectory.Delete();
    RandomStream.Dispose();
  }
}