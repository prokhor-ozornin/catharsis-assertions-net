using System.Security.Cryptography;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="SymmetricAlgorithm"/>
public static class SymmetricAlgorithmAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="algorithm"></param>
  /// <param name="size"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion BlockSize(this IAssertion assertion, SymmetricAlgorithm algorithm, int size, string error = null) => algorithm is not null ? assertion.True(algorithm.BlockSize == size, error) : throw new ArgumentNullException(nameof(algorithm));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="algorithm"></param>
  /// <param name="size"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion KeySize(this IAssertion assertion, SymmetricAlgorithm algorithm, int size, string error = null) => algorithm is not null ? assertion.True(algorithm.KeySize == size, error) : throw new ArgumentNullException(nameof(algorithm));
}