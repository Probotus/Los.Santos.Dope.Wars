using System.Diagnostics.CodeAnalysis;
using System.IO.Compression;
using System.Text;

namespace LSDW.Domain.Extensions;

/// <summary>
/// The byte extensions class.
/// </summary>
[ExcludeFromCodeCoverage]
public static class ByteExtensions
{
	/// <summary>
	/// Compresses the provided byte array and returns the compressed byte array.
	/// </summary>
	/// <param name="inputBuffer">The byte array to compress.</param>
	/// <param name="compressionLevel">The compression level to use.</param>
	/// <returns>The compressed byte array.</returns>
	public static byte[] Compress(this byte[] inputBuffer, CompressionLevel compressionLevel = CompressionLevel.Optimal)
	{
		byte[] outputBuffer;

		using (MemoryStream uncompressedStream = new(inputBuffer))
		{
			using MemoryStream compressedStream = new();
			using (DeflateStream compressorStream = new(compressedStream, compressionLevel, true))
				uncompressedStream.CopyTo(compressorStream);
			outputBuffer = compressedStream.ToArray();
		}

		return outputBuffer;
	}

	/// <summary>
	/// Decompresses the provided byte array and returns the decompressed byte array.
	/// </summary>
	/// <param name="inputBuffer">The byte array to decompress.</param>
	/// <returns>The decompressed byte array.</returns>
	public static byte[] Decompress(this byte[] inputBuffer)
	{
		byte[] outputBuffer;

		MemoryStream compressedStream = new(inputBuffer);
		using (DeflateStream decompressorStream = new(compressedStream, CompressionMode.Decompress))
		{
			using MemoryStream decompressedStream = new();
			decompressorStream.CopyTo(decompressedStream);
			outputBuffer = decompressedStream.ToArray();
		}

		return outputBuffer;
	}

	/// <summary>
	/// Returns all the bytes in the specified byte array decoded into a string.
	/// </summary>
	/// <remarks>
	/// If <paramref name="encoding"/> is not provided, <see cref="Encoding.UTF8"/> is used.
	/// </remarks>
	/// <param name="inputBuffer">The byte array containing the sequence of bytes to decode.</param>
	/// <param name="encoding">The character encoding to use.</param>
	/// <returns>A string that contains the results of decoding the specified sequence of bytes.</returns>
	public static string GetString(this byte[] inputBuffer, Encoding? encoding = null)
	{
		encoding ??= Encoding.UTF8;
		return encoding.GetString(inputBuffer);
	}
}
