using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace veil
{
    class ByteEncryption
    {
        
        //http://crypto.stackexchange.com/questions/1507/can-i-determine-if-a-user-has-the-wrong-symmetric-encryption-key
        //public SymmetricAlgorithm alg;
        public byte[] salt;
        public byte[] iv;
        public byte[] key;

        public enum SymmetricAlgorithmType
        {
            //.NET Supported
            AES, 
            DES, 
            RC2,
            Rijndael,
            TripleDES,
            //Crypto.NET http://sourceforge.net/projects/cryptodotnet/
            Blowfish,
            Mars,
            Serpent,
            Twofish
        }

        private const int ITERATIONS = 10000;
        private const string VALIDATION_PHRASE = "123456789012345";
        private const int SALT_SIZE = 16;

        public ByteEncryption()
        {
        
        }

        public byte[] Encrypt(SymmetricAlgorithmType type, string password, byte[] plaintext)
        {
            if ((password == null) || (password.Length == 0)) throw new ArgumentNullException("Password is null or empty");
            if ((plaintext == null) || (plaintext.Length == 0)) throw new ArgumentNullException("Plain text is null or empty");

            // encrypt using a random salt
            return EncryptionType(type, password, GenerateRandomByteArray(SALT_SIZE), plaintext);
        }

        public byte[] Decrypt(SymmetricAlgorithmType type, string password, byte[] ciphertext)
        {
            if ((password == null) || (password.Length == 0)) throw new ArgumentNullException("Password is null or empty");
            if ((ciphertext == null) || (ciphertext.Length == 0)) throw new ArgumentNullException("Cipher text is null or empty");

            return DecryptionType(type, password, ciphertext);
        }

        private byte[] DecryptionType(SymmetricAlgorithmType type, string password, byte[] ciphertext)
        {
            switch (type)
            {
                //.NET
                case SymmetricAlgorithmType.AES:
                    using (AesManaged alg = new AesManaged()) return DecryptionSetup(alg, password, ciphertext);

                case SymmetricAlgorithmType.DES:
                    using (DESCryptoServiceProvider alg = new DESCryptoServiceProvider()) return DecryptionSetup(alg, password, ciphertext);

                case SymmetricAlgorithmType.RC2:
                    using (RC2CryptoServiceProvider alg = new RC2CryptoServiceProvider()) return DecryptionSetup(alg, password, ciphertext);

                case SymmetricAlgorithmType.Rijndael:
                    using (RijndaelManaged alg = new RijndaelManaged()) return DecryptionSetup(alg, password, ciphertext);

                case SymmetricAlgorithmType.TripleDES:
                    using (TripleDESCryptoServiceProvider alg = new TripleDESCryptoServiceProvider()) return DecryptionSetup(alg, password, ciphertext);

                //Crypto.Net
                case SymmetricAlgorithmType.Mars:
                    using (CryptoNet.Mars alg = new CryptoNet.Mars()) return DecryptionSetup(alg, password, ciphertext);

                case SymmetricAlgorithmType.Serpent:
                    using (CryptoNet.Serpent alg = new CryptoNet.Serpent()) return DecryptionSetup(alg, password, ciphertext);

                case SymmetricAlgorithmType.Twofish:
                    using (CryptoNet.Twofish alg = new CryptoNet.Twofish()) return DecryptionSetup(alg, password, ciphertext);

                case SymmetricAlgorithmType.Blowfish:
                    using (CryptoNet.Blowfish alg = new CryptoNet.Blowfish()) return DecryptionSetup(alg, password, ciphertext);

                default:
                    throw new NotImplementedException("This algorithm has not been implemented");
            }
        }

        private byte[] DecryptionSetup(SymmetricAlgorithm alg,  string password, byte[] ciphertext)
        {
            // [validation] [salt] [iv] [data]
            byte[] validation = new byte[VALIDATION_PHRASE.Length+1];
            this.salt = new byte[SALT_SIZE];
            this.iv = new byte[alg.LegalBlockSizes[0].MinSize / 8];
            // fetch the validation phrase, salt and iv from the ciphertext
            Array.Copy(ciphertext, 0, validation, 0, validation.Length);
            Array.Copy(ciphertext, validation.Length, this.salt, 0, SALT_SIZE);
            Array.Copy(ciphertext, validation.Length+SALT_SIZE, this.iv, 0, this.iv.Length);
            // generate the key from the password, salt, and key size
            alg.Key = GenerateKey(password, alg.KeySize, ITERATIONS, this.salt);
            alg.IV = this.iv;
            this.key = alg.Key;
            //System.Windows.Forms.MessageBox.Show("Key " + BitConverter.ToString(alg.Key) + "  IV " + BitConverter.ToString(alg.IV) + "  salt " + BitConverter.ToString(salt));
            // generate the validation with the key to check for the correct key
            byte[] validationTest = EncryptBytes(alg, Encoding.ASCII.GetBytes(VALIDATION_PHRASE));
            if (!ByteArraysEqual(validation, validationTest)) throw new ArgumentException("Password is incorrect");
            byte[] data = new byte[ciphertext.Length - this.salt.Length - this.iv.Length - validation.Length];
            Array.Copy(ciphertext, this.salt.Length + this.iv.Length + validation.Length, data, 0, data.Length);

            return DecryptBytes(alg, data);
        }



        private byte[] EncryptionType(SymmetricAlgorithmType type, string password, byte[] salt, byte[] plaintext)
        {
            switch (type)
            {
                case SymmetricAlgorithmType.AES:
                    using (AesManaged alg = new AesManaged()) return EncryptionSetup(alg, password, salt, plaintext);

                case SymmetricAlgorithmType.DES:
                    using (DESCryptoServiceProvider alg = new DESCryptoServiceProvider()) return EncryptionSetup(alg, password, salt, plaintext);

                case SymmetricAlgorithmType.RC2:
                    using (RC2CryptoServiceProvider alg = new RC2CryptoServiceProvider()) return EncryptionSetup(alg, password, salt, plaintext);

                case SymmetricAlgorithmType.Rijndael:
                    using (RijndaelManaged alg = new RijndaelManaged()) return EncryptionSetup(alg, password, salt, plaintext);

                case SymmetricAlgorithmType.TripleDES:
                    using (TripleDESCryptoServiceProvider alg = new TripleDESCryptoServiceProvider()) return EncryptionSetup(alg, password, salt, plaintext);

                //Crypto.Net
                case SymmetricAlgorithmType.Mars:
                    using (CryptoNet.Mars alg = new CryptoNet.Mars()) return EncryptionSetup(alg, password, salt, plaintext);

                case SymmetricAlgorithmType.Serpent:
                    using (CryptoNet.Serpent alg = new CryptoNet.Serpent()) return EncryptionSetup(alg, password, salt, plaintext);

                case SymmetricAlgorithmType.Twofish:
                    using (CryptoNet.Twofish alg = new CryptoNet.Twofish()) return EncryptionSetup(alg, password, salt, plaintext);

                case SymmetricAlgorithmType.Blowfish:
                    using (CryptoNet.Blowfish alg = new CryptoNet.Blowfish()) return EncryptionSetup(alg, password, salt, plaintext);

                default:
                    throw new NotImplementedException("This algorithm has not been implemented");
            }
        }

        private byte[] EncryptionSetup(SymmetricAlgorithm alg, string password, byte[] salt, byte[] plaintext)
        {
            // generate the key from the password, salt, and key size
            alg.Key = GenerateKey(password, alg.KeySize, ITERATIONS, salt);
            // generate the iv
            alg.GenerateIV();
            this.key = alg.Key;
            this.salt = salt;
            this.iv = alg.IV;
            // generate the key validation byte array
            byte[] validation = EncryptBytes(alg, Encoding.ASCII.GetBytes(VALIDATION_PHRASE));
            List<byte> list = new List<byte>();
            list.AddRange(validation);
            list.AddRange(this.salt);
            list.AddRange(this.iv);
            list.AddRange(EncryptBytes(alg, plaintext));
            // return [validation] [salt] [iv] [data]
            return list.ToArray();
        }

        private static byte[] GenerateKey(string password, int keySize, int iterations, byte[] salt)
        {
            // Minimum recommended number of iterations of PBKDF2 is 1000
            if (iterations < 1000)
            {
                iterations = 1000;
            }
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, iterations);
            return key.GetBytes(keySize / 8);
        }

        private static byte[] GenerateRandomByteArray(int size)
        {
            // Minimum salt size is 8
            if (size < 8)
            {
                size = 8;
            }
            byte[] bArray = new byte[size];
            RNGCryptoServiceProvider rcsp = new RNGCryptoServiceProvider();
            rcsp.GetBytes(bArray);
            return bArray;
        }





        private static byte[] EncryptBytes(SymmetricAlgorithm alg, byte[] plaintext)
        {
            // validation
            if ((plaintext == null) || (plaintext.Length == 0)) throw new ArgumentNullException("Cipher text is null or empty");
            if (alg == null) throw new ArgumentNullException("Symmetric algorithm is not initialized");
            if ((alg.Key == null) || alg.Key.Length == 0) throw new ArgumentNullException("Key is null or empty");
            if ((alg.IV == null) || alg.IV.Length == 0) throw new ArgumentNullException("IV is null or empty");

            using (MemoryStream stream = new MemoryStream())
            using (ICryptoTransform encryptor = alg.CreateEncryptor())
            using (CryptoStream encrypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
            {
                encrypt.Write(plaintext, 0, plaintext.Length);
                encrypt.FlushFinalBlock();
                return stream.ToArray();
            }
        }

        private static byte[] DecryptBytes(SymmetricAlgorithm alg, byte[] ciphertext)
        {
            // validation
            if ((ciphertext == null) || (ciphertext.Length == 0)) throw new ArgumentNullException("Cipher text is null or empty");
            if (alg == null) throw new ArgumentNullException("Symmetric algorithm is not initialized");
            if ((alg.Key == null) || alg.Key.Length == 0) throw new ArgumentNullException("Key is null or empty");
            if ((alg.IV == null) || alg.IV.Length == 0) throw new ArgumentNullException("IV is null or empty");

            using (MemoryStream stream = new MemoryStream())
            using (ICryptoTransform decryptor = alg.CreateDecryptor())
            using (CryptoStream decrypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Write))
            {
                decrypt.Write(ciphertext, 0, ciphertext.Length);
                decrypt.FlushFinalBlock();
                return stream.ToArray();
            }
        }



        public bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            // determine if two byte arrays are equal
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }













        private static byte[] encryptBytesToBytes_AES(byte[] plainText, byte[] key, byte[] iv)
        {
            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("Key");

            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;


                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        /*using (BinaryWriter bwEncrypt = new BinaryWriter(csEncrypt))
                        {
                            bwEncrypt.Write(plainText);
                        }*/
                        csEncrypt.Write(plainText, 0, plainText.Length);
                        csEncrypt.FlushFinalBlock();
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }

        private static byte[] decryptBytesToBytes_AES(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments. 
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("Key");

            byte[] decrypted;
            // Create an Aes object 
            // with the specified key and IV. 
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption. 
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                    {
                        csDecrypt.Write(cipherText, 0, cipherText.Length);
                        csDecrypt.FlushFinalBlock();
                        decrypted = msDecrypt.ToArray();
                        /*using (BinaryReader brDecrypt = new BinaryReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream and place them in a byte array
                            decrypted = brDecrypt.ReadAllBytes();
                        }*/
                    }
                }

            }
            return decrypted;
        }
    }
    static class BinaryReaderExtension
    {
        public static byte[] ReadAllBytes(this BinaryReader reader)
        {
            // BinaryReader.ReadAllBytes like StreamReader.ReadAllBytes
            const int bufferSize = 4096;
            using (var ms = new MemoryStream())
            {
                byte[] buffer = new byte[bufferSize];
                int count;
                while ((count = reader.Read(buffer, 0, buffer.Length)) != 0) ms.Write(buffer, 0, count);
                return ms.ToArray();
            }

        }
    }
    
}
