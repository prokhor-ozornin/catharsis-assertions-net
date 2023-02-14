namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="IProtection"/>
public static class IProtectionExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <returns></returns>
  public static IProtection And(this IProtection protection) => protection;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <returns></returns>
  public static IProtection Being(this IProtection protection) => protection;

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <returns></returns>
  public static IProtection Having(this IProtection protection) => protection;
}