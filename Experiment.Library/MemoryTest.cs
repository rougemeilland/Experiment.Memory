using System;
using System.Runtime.CompilerServices;
using System.Buffers.Binary;

namespace Experiment.Library
{
    public static class MemoryTest
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static Int16 ToInt16LE(ReadOnlySpan<Byte> array)
        {
            if (array.Length < sizeof(Int16))
                throw new ArgumentOutOfRangeException(nameof(array), "Not enough bytes in the array to read Int16.");

            unsafe
            {
                fixed (Byte* p = array)
                {
                    return ToUnmanagedTypeCore<Int16>(ref *p, true);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static Int16 ToInt16BE(ReadOnlySpan<Byte> array)
        {
            if (array.Length < sizeof(Int16))
                throw new ArgumentOutOfRangeException(nameof(array), "Not enough bytes in the array to read Int16.");

            unsafe
            {
                fixed (Byte* p = array)
                {
                    return ToUnmanagedTypeCore<Int16>(ref *p, true);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0049:名前を単純化します", Justification = "<保留中>")]
        public static Int128 ToInt128LE(ReadOnlySpan<Byte> array)
        {
            if (array.Length < 16)
                throw new ArgumentOutOfRangeException(nameof(array), "Not enough bytes in the array to read Int16.");

            unsafe
            {
                fixed (Byte* p = array)
                {
                    return ToUnmanagedTypeCore<Int16>(ref *p, true);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static Int128 ToInt128BE(ReadOnlySpan<Byte> array)
        {
            if (array.Length < 16)
                throw new ArgumentOutOfRangeException(nameof(array), "Not enough bytes in the array to read Int16.");

            unsafe
            {
                fixed (Byte* p = array)
                {
                    return ToUnmanagedTypeCore<Int16>(ref *p, true);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private static unsafe VALUE_T ToUnmanagedTypeCore<VALUE_T>(Byte* buffer, Boolean convertFromLittleEndian)
            where VALUE_T : unmanaged
        {
            if (BitConverter.IsLittleEndian == convertFromLittleEndian)
                return Unsafe.Read<VALUE_T>(buffer);
            VALUE_T value;
            Unsafe.CopyBlockUnaligned(&value, buffer, (UInt32)sizeof(VALUE_T));
            BinaryPrimitives.ReverseEndianness(new Span<VALUE_T>(ref value));
            return value;
        }

        private static unsafe void ReverseByteArray<VALUE_T>(VALUE_T* value)
            where VALUE_T : unmanaged
        {
            var p = (byte*)&value;
            if (typeof(VALUE_T) == typeof(sbyte))
            {
            }
            else if (typeof(VALUE_T) == typeof(byte))
            {
            
            short
                    ushort
                    }
            int
                uint
                long
                Int128
                UInt128
            ulong
                float
                double
                decimal




            :
                    break;
                case 2:
                    BinaryPrimitives.ReverseEndianness<VALUE_T>(ref *value);
                    (p[1], p[0]) = (p[0], p[1]);
                    break;
                case 4:
                    (p[3], p[0]) = (p[0], p[3]);
                    (p[2], p[1]) = (p[1], p[2]);
                    break;
                case 8:
                    (p[7], p[0]) = (p[0], p[7]);
                    (p[6], p[1]) = (p[1], p[6]);
                    (p[5], p[2]) = (p[2], p[5]);
                    (p[4], p[3]) = (p[3], p[4]);
                    break;
                case 16:
                    (p[7], p[0]) = (p[0], p[7]);
                    (p[6], p[1]) = (p[1], p[6]);
                    (p[5], p[2]) = (p[2], p[5]);
                    (p[4], p[3]) = (p[3], p[4]);
                    (p[7], p[4]) = (p[4], p[7]);
                    (p[6], p[5]) = (p[5], p[6]);
                    (p[5], p[6]) = (p[6], p[5]);
                    (p[4], p[7]) = (p[7], p[4]);
                    break;
                default:
                    throw new NotSupportedException($"Unsupported size of VALUE_T: {sizeof(VALUE_T)} bytes.");
            }
        }
    }
}
