namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of extension methods for the <see cref="IProtection"/> interface.</para>
/// </summary>
/// <seealso cref="IProtection"/>
public static class IProtectionExtensions
{
  /// <param name="protection">Protection to perform.</param>
  extension(IProtection protection)
  {
    /// <summary>
    ///   <para>"Helper" method for building lexically diverse protection sentences that returns a back reference to a given protection.</para>
    /// </summary>
    /// <value>Back self-reference to the given <paramref name="protection"/>.</value>
    public IProtection And => protection;

    /// <summary>
    ///   <para>"Helper" method for building lexically diverse protection sentences that returns a back reference to a given protection.</para>
    /// </summary>
    /// <value>Back self-reference to the given <paramref name="protection"/>.</value>
    public IProtection Being => protection;

    /// <summary>
    ///   <para>"Helper" method for building lexically diverse protection sentences that returns a back reference to a given protection.</para>
    /// </summary>
    /// <value>Back self-reference to the given <paramref name="protection"/>.</value>
    public IProtection Having => protection;
  }
}