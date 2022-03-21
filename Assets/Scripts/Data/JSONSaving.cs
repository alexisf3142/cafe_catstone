using System.IO;
using UnityEngine;

public class JSONSaving : MonoBehaviour
{
    
    private PlayerData playerData;

    private string path = "";
    private string persistentPath = "";
    
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayerData();
        SetPaths();
    }

    private void CreatePlayerData()
    {
        playerData = new PlayerData("Rachy", 5.6, 6);
    }

    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadData();
        }
    }

    public void SaveData()
    {
        string savePath = path;
        Debug.Log("Saving Data " + savePath);
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public void LoadData()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(data.ToString());
    }
}
