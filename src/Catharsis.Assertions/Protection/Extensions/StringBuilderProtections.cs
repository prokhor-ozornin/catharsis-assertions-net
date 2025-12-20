using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of protections for the <see cref="StringBuilder"/> type.</para>
/// </summary>
/// <seealso cref="StringBuilder"/>
public static class StringBuilderProtections
{
  /// <param name="protection">Protection to perform.</param>
  extension(IProtection protection)
  {
    /// <summary>
    ///   <para>This function protects the given <see cref="StringBuilder"/> from being empty, ensuring that it contains at least one character.</para>
    /// </summary>
    /// <param name="builder">String builder to protect.</param>
    /// <param name="error">Error message for a failed <paramref name="protection"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="protection"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="protection"/> or <paramref name="builder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">If <paramref name="protection"/>'s condition was not met.</exception>
    public StringBuilder Empty(StringBuilder builder, string error = null)
    {
      if (protection is null) throw new ArgumentNullException(nameof(protection));
      if (builder is null) throw new ArgumentNullException(nameof(builder));

      protection.Truth(builder.Length == 0, error);

      return builder;
    }
  }
}