using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private string m_cafeName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Awake()
    {
        m_cafeName = MenuManager.Instance.cafeName;
        Load();
        
    }

    [System.Serializable]
    class SaveData
    {
        public string cafeName;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.cafeName = m_cafeName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            m_cafeName = data.cafeName;
        }
    }
    
}
