using System.Security;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for the <see cref="SecureString"/> type.</para>
/// </summary>
/// <seealso cref="SecureString"/>
public static class SecureStringProtections
{
  /// <param name="protection">Protection to perform.</param>
  extension(IProtection protection)
  {
    /// <summary>
    ///   <para>This function protects the given <see cref="SecureString"/> from being empty, ensuring that it contains at least one character.</para>
    /// </summary>
    /// <param name="secure">Secure string to protect.</param>
    /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="secure"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
    public SecureString Empty(SecureString secure, string error = null)
    {
      if (protection is null) throw new ArgumentNullException(nameof(protection));
      if (secure is null) throw new ArgumentNullException(nameof(secure));

      protection.Truth(secure.Length == 0, error);

      return secure;
    }
  }
}