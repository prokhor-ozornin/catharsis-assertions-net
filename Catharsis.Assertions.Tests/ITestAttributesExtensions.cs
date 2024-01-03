using Catharsis.Commons;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

public static class ITestAttributesExtensions
{
  public static IEnumerable<object> EmptySequence(this ITestAttributes attributes) => attributes is not null ? attributes.Retrieve(nameof(EmptySequence), Enumerable.Empty<object>()) : throw new ArgumentNullException(nameof(attributes));

  public static IEnumerable<object> RandomSequence(this ITestAttributes attributes) => attributes is not null ? attributes.Retrieve(nameof(RandomSequence), attributes.Random().ObjectSequence(byte.MaxValue, typeof(object)).ToArray()) : throw new ArgumentNullException(nameof(attributes));

  public static string RandomString(this ITestAttributes attributes) => attributes is not null ? attributes.Retrieve(nameof(RandomString), attributes.Random().Letters(byte.MaxValue)) : throw new ArgumentNullException(nameof(attributes));

  public static Stream RandomStream(this ITestAttributes attributes) => attributes is not null ? attributes.Retrieve(nameof(RandomStream), attributes.Random().MemoryStream(short.MaxValue)) : throw new ArgumentNullException(nameof(attributes));

  public static TempFile TempFile(this ITestAttributes attributes) => attributes is not null ? attributes.Retrieve(nameof(TempFile), new TempFile(attributes.Random().BinaryFile(short.MaxValue))) : throw new ArgumentNullException(nameof(attributes));

  public static TempDirectory TempDirectory(this ITestAttributes attributes) => attributes is not null ? attributes.Retrieve(nameof(TempDirectory), new TempDirectory(attributes.Random().Directory())) : throw new ArgumentNullException(nameof(attributes));
}