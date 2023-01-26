using System.Security.Cryptography;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="SymmetricAlgorithm"/>
public static class SymmetricAlgorithmExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="size"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<SymmetricAlgorithm> BlockSize(this IExpectation<SymmetricAlgorithm> expectation, int size) => expectation.HaveSubject().And().Expected(algorithm => algorithm.BlockSize == size);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="size"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<SymmetricAlgorithm> KeySize(this IExpectation<SymmetricAlgorithm> expectation, int size) => expectation.HaveSubject().And().Expected(algorithm => algorithm.KeySize == size);
}