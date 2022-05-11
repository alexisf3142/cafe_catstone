using System.IO;
using UnityEngine;


//public GameObject cupTotal;

public class JSONSaving : MonoBehaviour
{
    

    private string path = "";
    private string persistentPath = "";
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    public void SetPaths(string cafeName)
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + cafeName + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + cafeName +  "SaveData.json";
    }

    // Update is called once per frame


    public void SaveData(PlayerData playerData)
    {
        playerData.coffeeServed  = 2;
        string savePath = path;
        Debug.Log("Saving Data " + savePath);
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public PlayerData LoadData()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(data.ToString());
        return data;
    }

}
