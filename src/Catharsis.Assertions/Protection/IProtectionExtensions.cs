namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of extension methods for the <see cref="IProtection"/> interface.</para>
/// </summary>
/// <seealso cref="IProtection"/>
public static class IProtectionExtensions
{
  /// <summary>
  ///   <para>"Helper" method for building lexically diverse protection sentences that returns a back reference to a given protection.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  public static IProtection And(this IProtection protection) => protection;

  /// <summary>
  ///   <para>"Helper" method for building lexically diverse protection sentences that returns a back reference to a given protection.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  public static IProtection Being(this IProtection protection) => protection;

  /// <summary>
  ///   <para>"Helper" method for building lexically diverse protection sentences that returns a back reference to a given protection.</para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
  public static IProtection Having(this IProtection protection) => protection;
}