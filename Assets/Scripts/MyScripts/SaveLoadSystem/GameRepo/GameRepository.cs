using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public sealed class GameRepository : IGameRepository
{
    private string _filePath = Path.Combine(Application.dataPath, "SavedData", "savedData.json");

    private Dictionary<Type, object> _gameState = new();

    public void SaveState()
    {
        string json = JsonConvert.SerializeObject(_gameState);

        var EncryptionHelper = new EncryptionHelper();
        byte[] encryptedBytes = EncryptionHelper.Encrypt(json);

        File.WriteAllBytes(_filePath, encryptedBytes);
        
        Debug.Log("Файл сохранён");
        _gameState.Clear();
    }

    public void LoadState()
    {
        if (File.Exists(_filePath))
        {
            byte[] encryptedData = File.ReadAllBytes(_filePath);

            var EncryptionHelper = new EncryptionHelper();
            string decryptedJson = EncryptionHelper.Decrypt(encryptedData);

            _gameState = JsonConvert.DeserializeObject<Dictionary<Type, object>>(decryptedJson);

            if (_gameState != null)
                Debug.Log("Файл загружен. Количество записей: " + _gameState.Count);
            else
                Debug.LogError("Ошибка десериализации JSON");        
        }
        else
            Debug.LogError("Файл не найден");
    }

    public T GetData<T>()
    {
        var key = typeof(T);
        if (_gameState.TryGetValue(key, out var value))
        {
            var serializedData = JsonConvert.SerializeObject(value);
            return JsonConvert.DeserializeObject<T>(serializedData);
        }

        return default;
    }

    public bool TryGetData<T>(out T value)
    {
        var key = typeof(T);

        if (_gameState.TryGetValue(key, out var serializedData))
        {
            var serializedJson = JsonConvert.SerializeObject(serializedData);
            value = JsonConvert.DeserializeObject<T>(serializedJson);
            return true;
        }

        value = default;
        return false;
    }

    public void SetData<T>(T value)    
    {
        var key = typeof(T);
        _gameState[key] = value;         
    }
}

