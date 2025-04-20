using Catharsis.Commons;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para></para>
/// </summary>
public static class ITestAttributesExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="attributes"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static string RandomString(this ITestAttributes attributes) => attributes?.GetOrSet(nameof(RandomString), attributes.Random().Letters(byte.MaxValue)).To<string>() ?? throw new ArgumentNullException(nameof(attributes));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="attributes"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IEnumerable<object> RandomSequence(this ITestAttributes attributes) => attributes?.GetOrSet(nameof(RandomSequence), attributes.Random().ObjectSequence(byte.MaxValue, typeof(object)).ToArray()).To<IEnumerable<object>>() ?? throw new ArgumentNullException(nameof(attributes));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="attributes"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static Stream RandomStream(this ITestAttributes attributes) => attributes?.GetOrSet(nameof(RandomStream), attributes.Random().MemoryStream(short.MaxValue)).To<Stream>() ?? throw new ArgumentNullException(nameof(attributes));
}