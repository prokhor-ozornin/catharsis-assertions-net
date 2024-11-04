namespace Catharsis.Assertions;

/// <summary>
///   <para>Protection factory class for the creation of protections.</para>
/// </summary>
public static class Protect
{
  /// <summary>
  ///   <para>Instance of protection object.</para>
  /// </summary>
  public static IProtection From { get; } = new Protection();
}