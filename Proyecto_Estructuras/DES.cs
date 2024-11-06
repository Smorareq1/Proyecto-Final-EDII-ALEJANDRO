using System;
using System.Security.Cryptography;
using System.Text;

namespace Proyecto_Estructuras
{
    internal class DES
    {
        // Tabla de bits de paridad para la llave
        private static readonly int[] ParityDropTable =
        {
            57, 49, 41, 33, 25, 17, 9,
            1, 58, 50, 42, 34, 26, 18,
            10, 2, 59, 51, 43, 35, 27,
            19, 11, 3, 60, 52, 44, 36,
            63, 55, 47, 39, 31, 23, 15,
            7, 62, 54, 46, 38, 30, 22,
            14, 6, 61, 53, 45, 37, 29,
            21, 13, 5, 28, 20, 12, 4
        };

        // Tabla de desplazamiento para la llave
        private static readonly int[] ShiftTable =
        {
            1, 1, 2, 2, 2, 2, 2, 2,
            1, 2, 2, 2, 2, 2, 2, 1
        };

        // Tabla de compresión de la llave generada
        private static readonly int[] KeyCompressionTable =
        {
            14, 17, 11, 24, 1, 5,
            3, 28, 15, 6, 21, 10,
            23, 19, 12, 4, 26, 8,
            16, 7, 27, 20, 13, 2,
            41, 52, 31, 37, 47, 55,
            30, 40, 51, 45, 33, 48,
            44, 49, 39, 56, 34, 53,
            46, 42, 50, 36, 29, 32
        };

        // Tabla de permutación inicial
        private static readonly int[] InitialPermutationTable =
        {
            58, 50, 42, 34, 26, 18, 10, 2,
            60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6,
            64, 56, 48, 40, 32, 24, 16, 8,
            57, 49, 41, 33, 25, 17, 9, 1,
            59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5,
            63, 55, 47, 39, 31, 23, 15, 7
        };

        // Tabla de permutación expandida
        private static readonly int[] ExpansionPermutationTable =
        {
            32, 1, 2, 3, 4, 5,
            4, 5, 6, 7, 8, 9,
            8, 9, 10, 11, 12, 13,
            12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21,
            20, 21, 22, 23, 24, 25,
            24, 25, 26, 27, 28, 29,
            28, 29, 30, 31, 32, 1
        };

        // Tabla S-Box para sustitución
        private static readonly int[][,] SBoxTable =
        {
            new int[,] {
                { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 },
                { 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8 },
                { 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 },
                { 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 }
            },
            new int[,] {
             { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 },
             { 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 },
             { 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 },
             { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 }
            },
            new int[,] {
             { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 },
             { 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1 },
             { 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 },
             { 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 }
            },
            new int[,] {
             { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 },
             { 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 },
             { 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 },
             { 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 }
            },
            new int[,] {
             { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 },
             { 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6 },
             { 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 },
             { 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 }
            },
            new int[,] {
             { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 },
             { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 },
             { 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 },
             { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 }
            },
            new int[,] {
             { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 },
             { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 },
             { 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 },
             { 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 }
            },
            new int[,] {
             { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 },
             { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 },
             { 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8 },
             { 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 }
            }
        };

        // Tabla P-Box para permutación final
        private static readonly int[] PBoxPermutationTable =
        {
            16, 7, 20, 21, 29, 12, 28, 17,
            1, 15, 23, 26, 5, 18, 31, 10,
            2, 8, 24, 14, 32, 27, 3, 9,
            19, 13, 30, 6, 22, 11, 4, 25
        };

        // Tabla de permutación final
        private static readonly int[] FinalPermutationTable =
        {
            40, 8, 48, 16, 56, 24, 64, 32,
            39, 7, 47, 15, 55, 23, 63, 31,
            38, 6, 46, 14, 54, 22, 62, 30,
            37, 5, 45, 13, 53, 21, 61, 29,
            36, 4, 44, 12, 52, 20, 60, 28,
            35, 3, 43, 11, 51, 19, 59, 27,
            34, 2, 42, 10, 50, 18, 58, 26,
            33, 1, 41, 9, 49, 17, 57, 25
        };
        private static byte[] DESProcess(byte[] inputData, byte[] encryptionKey, bool isAscending)
        {
            byte[] processedData = new byte[inputData.Length];
            int blockCount = inputData.Length / 8; 
            byte[][] roundKeys = GenerateKeys(encryptionKey, isAscending); 
            byte[] blockBuffer = new byte[8]; 
            byte[] leftHalf = new byte[4]; 
            byte[] rightHalf = new byte[4]; 
            byte[] expandedRightHalf; 
            byte[] substitutedRightHalf = new byte[4]; 
            byte[] tempRightHalf; 

            
            for (int blockNum = 0; blockNum < blockCount; blockNum++)
            {
                
                Array.Copy(inputData, blockNum * 8, blockBuffer, 0, 8);
                blockBuffer = Permute(blockBuffer, InitialPermutationTable);

                
                for (int round = 0; round < 16; round++)
                {
                    
                    Buffer.BlockCopy(blockBuffer, 0, leftHalf, 0, 4);
                    Buffer.BlockCopy(blockBuffer, 4, rightHalf, 0, 4);

                    
                    expandedRightHalf = Permute(rightHalf, ExpansionPermutationTable);

                    
                    expandedRightHalf = XOR(expandedRightHalf, roundKeys[round]);

                    
                    for (int section = 0; section < 8; section++)
                    {
                       
                        int row = (GetBitAt(expandedRightHalf, section * 6) << 1) | GetBitAt(expandedRightHalf, section * 6 + 5);
                        int column = 0;
                        for (int bitIndex = 0; bitIndex < 4; bitIndex++)
                        {
                            column |= GetBitAt(expandedRightHalf, section * 6 + bitIndex + 1) << (3 - bitIndex);
                        }

                        int sBoxValue = SBoxTable[section][row, column];
                        for (int bitIndex = 0; bitIndex < 4; bitIndex++)
                        {
                            SetBitAt(substitutedRightHalf, section * 4 + bitIndex, (sBoxValue >> (3 - bitIndex)) & 1);
                        }
                    }

                    substitutedRightHalf = Permute(substitutedRightHalf, PBoxPermutationTable);

                    tempRightHalf = XOR(leftHalf, substitutedRightHalf);

                    if (round != 15)
                    {
                        Buffer.BlockCopy(rightHalf, 0, blockBuffer, 0, 4);
                        Buffer.BlockCopy(tempRightHalf, 0, blockBuffer, 4, 4);
                    }
                    else
                    {
                        Buffer.BlockCopy(tempRightHalf, 0, blockBuffer, 0, 4);
                        Buffer.BlockCopy(rightHalf, 0, blockBuffer, 4, 4);
                    }
                }

                blockBuffer = Permute(blockBuffer, FinalPermutationTable);
                Buffer.BlockCopy(blockBuffer, 0, processedData, blockNum * 8, 8);
            }

            return processedData;
        }
        public static byte[] Encrypt(byte[] data, byte[] key, bool addPadding = true)
        {
            if (key.Length != 8)
            {
                throw new ArgumentException("Key length must be 8 bytes");
            }

            if (addPadding)
            {
                data = AddPkcs7Padding(data, 8);
            }

            return DESProcess(data, key, true);
        }
        public static byte[] Decrypt(byte[] data, byte[] key, bool removePadding = true)
        {
            if (key.Length != 8)
            {
                throw new ArgumentException("Key length must be 8 bytes");
            }

            // Ensure data length is a multiple of 8 bytes
            if (data.Length % 8 != 0)
            {
                throw new ArgumentException("Data length must be multiple of 8 bytes");
            }

            // Process data for decryption
            var result = DESProcess(data, key, false);
            if (removePadding)
            {
                result = RemovePkcs7Padding(result); 
            }

            return result; 
        }
        private static byte[][] GenerateKeys(byte[] initialKey, bool isAscending = true)
        {
            byte[][] roundKeys = new byte[16][]; 
            byte[] permutedKey = Permute(initialKey, ParityDropTable); 
            for (int round = 0; round < 16; round++)
            {
                byte[] leftHalf = SelectBits(permutedKey, 0, 28);
                byte[] rightHalf = SelectBits(permutedKey, 28, 28);

                leftHalf = LeftShift(leftHalf, 28, ShiftTable[round]);
                rightHalf = LeftShift(rightHalf, 28, ShiftTable[round]);

                byte[] combinedKey = JoinKey(leftHalf, rightHalf);
                roundKeys[round] = Permute(combinedKey, KeyCompressionTable);
                permutedKey = combinedKey; 
            }

            if (!isAscending)
            {
                Array.Reverse(roundKeys); 
            }

            return roundKeys;
        }
        private static byte[] Permute(byte[] source, int[] table)
        {
            int length = (table.Length - 1) / 8 + 1; 
            byte[] result = new byte[length];
            for (int i = 0; i < table.Length; i++)
            {
                SetBitAt(result, i, GetBitAt(source, table[i] - 1)); 
            }
            return result;
        }
        private static byte[] LeftShift(byte[] data, int len, int shift)
        {
            byte[] outer = new byte[(len - 1) / 8 + 1]; 
            for (int i = 0; i < len; i++)
            {
                int val = GetBitAt(data, (i + shift) % len); 
                SetBitAt(outer, i, val);
            }

            return outer; 
        }
        private static byte[] XOR(byte[] first, byte[] second)
        {
            byte[] result = new byte[first.Length]; 
            for (int i = 0; i < first.Length; i++)
            {
                result[i] = (byte)(first[i] ^ second[i]); 
            }

            return result;  
        }
        private static int GetBitAt(byte[] data, int position)
        {
            int posByte = position / 8; 
            int posBit = position % 8;
            return data[posByte] >> (7 - posBit) & 1; 
        }
        private static void SetBitAt(byte[] data, int position, int value)
        {
            int posByte = position / 8;
            int posBit = position % 8;          
            if (value == 1)
                data[posByte] |= (byte)(1 << (7 - posBit)); 
            else
                data[posByte] &= (byte)~(1 << (7 - posBit)); 
        }
        private static byte[] SelectBits(byte[] source, int start, int count)
        {
            byte[] result = new byte[(count - 1) / 8 + 1]; 
            for (int i = 0; i < count; i++)
            {
                SetBitAt(result, i, GetBitAt(source, start + i)); 
            }

            return result; 
        }
        private static byte[] JoinKey(byte[] leftHalf, byte[] rightHalf)
        {
            byte[] result = new byte[7]; 
            for (int i = 0; i < 3; i++)
            {
                result[i] = leftHalf[i];
            }
            for (int i = 0; i < 4; i++)
            {
                int val = GetBitAt(leftHalf, 24 + i); 
                SetBitAt(result, 24 + i, val);
            }
            for (int i = 0; i < 28; i++)
            {
                int val = GetBitAt(rightHalf, i);
                SetBitAt(result, 28 + i, val);
            }
            return result;
        }
        public static byte[] AddPkcs7Padding(byte[] data, int blockSize)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Data cannot be null");
            }

            if (blockSize <= 0)
            {
                throw new ArgumentException("Block size must be greater than zero", nameof(blockSize));
            }

            int count = data.Length;
            int paddingRemainder = count % blockSize;
            int paddingSize = blockSize - paddingRemainder;

            if (paddingSize == 0)
            {
                paddingSize = blockSize;
            }

            byte[] paddedData = new byte[data.Length + paddingSize];
            Buffer.BlockCopy(data, 0, paddedData, 0, data.Length);

            byte paddingByte = (byte)paddingSize;
            for (int i = data.Length; i < paddedData.Length; i++)
            {
                paddedData[i] = paddingByte;
            }

            return paddedData;
        }
        public static byte[] RemovePkcs7Padding(byte[] paddedByteArray)
        {
            if (paddedByteArray == null)
            {
                throw new ArgumentNullException(nameof(paddedByteArray), "Padded byte array cannot be null");
            }

            if (paddedByteArray.Length == 0)
            {
                throw new ArgumentException("Padded byte array cannot be empty", nameof(paddedByteArray));
            }

            int paddingSize = paddedByteArray[paddedByteArray.Length - 1];
            if (paddingSize < 1 || paddingSize > paddedByteArray.Length)
            {
                throw new ArgumentException("Invalid padding size.");
            }

            for (int i = paddedByteArray.Length - paddingSize; i < paddedByteArray.Length; i++)
            {
                if (paddedByteArray[i] != paddingSize)
                {
                    throw new ArgumentException("Invalid padding.");
                }
            }

            int resultLength = paddedByteArray.Length - paddingSize;
            byte[] result = new byte[resultLength];
            Buffer.BlockCopy(paddedByteArray, 0, result, 0, resultLength);

            return result;
        }

    }
}
