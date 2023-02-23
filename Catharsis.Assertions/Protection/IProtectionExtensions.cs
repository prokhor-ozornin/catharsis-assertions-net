namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of extension methods for <see cref="IProtection"/> interface.</para>
/// </summary>
/// <seealso cref="IProtection"/>
public static class IProtectionExtensions
{
  /// <summary>
  ///   <para>Helper method for building lexically diverse protection sentences that returns a back reference to a given protection.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  public static IProtection And(this IProtection protection) => protection;

  /// <summary>
  ///   <para>Helper method for building lexically diverse protection sentences that returns a back reference to a given protection.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  public static IProtection Being(this IProtection protection) => protection;

  /// <summary>
  ///   <para>Helper method for building lexically diverse protection sentences that returns a back reference to a given protection.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  public static IProtection Having(this IProtection protection) => protection;
}