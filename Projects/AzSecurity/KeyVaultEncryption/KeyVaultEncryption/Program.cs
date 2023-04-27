using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using System.Text;

string tenantId = "87349d34-316a-481c-ab12-5f5c7af3cd99"; //Directory (tenant) ID
string clientId = "9402fc42-8020-454e-a041-a11c8bf615a7"; //Application (client) ID
string clientSecret = ""; // KeyVautApp | Certificates & secrets - new

string keyVaultUrl = "https://keyvaultdpol.vault.azure.net/"; //keyvaultdpol Vault URI
string keyName = "appkey"; // keyvaultdpol | Keys

string textToEncrypt = "This a secret text";

ClientSecretCredential clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);

KeyClient keyClient = new KeyClient(new Uri(keyVaultUrl), clientSecretCredential);

var key = keyClient.GetKey(keyName);

// The CryptographyClient class is part of the Azure Key vault package
// This is used to perform cryptographic operations with Azure Key Vault keys

var cryptoClient = new CryptographyClient(key.Value.Id, clientSecretCredential);

// We first need to take the bytes of the string that needs to be converted

byte[] textToBytes = Encoding.UTF8.GetBytes(textToEncrypt);

EncryptResult result = cryptoClient.Encrypt(EncryptionAlgorithm.RsaOaep, textToBytes);

Console.WriteLine("The encrypted text");
Console.WriteLine(Convert.ToBase64String(result.Ciphertext));

// Now lets decrypt the text
// We first need to convert our Base 64 string of the Cipertext to bytes

byte[] cipherToBytes = result.Ciphertext;

DecryptResult textDecrypted = cryptoClient.Decrypt(EncryptionAlgorithm.RsaOaep, cipherToBytes);

Console.WriteLine("Decrypted text:");
Console.WriteLine(Encoding.UTF8.GetString(textDecrypted.Plaintext));

Console.ReadKey();