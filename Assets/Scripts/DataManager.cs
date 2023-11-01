using UnityEngine;
using System.IO;

// Globaali tiedonhallinta luokka

public static class DataManager 
{
    public static void SavePlayerDataToJSON(Player player){
        PlayerData playerData = new PlayerData(player);
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText($"{Application.persistentDataPath}/playerData.json", json);
    }

    public static PlayerData LoadPlayerDataFromJSON(){
        string json = File.ReadAllText($"{Application.persistentDataPath}/playerData.json");
        return JsonUtility.FromJson<PlayerData>(json);
    }
}
