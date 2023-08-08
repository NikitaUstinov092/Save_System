using System.Text;

public class EncryptionHelper
{
    private string encryptionKey = "secretKey"; // Простой ключ для примера
    public byte[] Encrypt(string plainText)
    {
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey);

        byte[] encryptedBytes = new byte[plainTextBytes.Length];
        for (int i = 0; i < plainTextBytes.Length; i++)
        {
            encryptedBytes[i] = (byte)(plainTextBytes[i] ^ keyBytes[i % keyBytes.Length]);
        }

        return encryptedBytes;
    }

    public string Decrypt(byte[] cipherTextBytes)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey);

        byte[] decryptedBytes = new byte[cipherTextBytes.Length];
        for (int i = 0; i < cipherTextBytes.Length; i++)
        {
            decryptedBytes[i] = (byte)(cipherTextBytes[i] ^ keyBytes[i % keyBytes.Length]);
        }

        string decryptedText = Encoding.UTF8.GetString(decryptedBytes);
        return decryptedText;
    }

}


