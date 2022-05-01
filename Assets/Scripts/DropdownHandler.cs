using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DropdownHandler : MonoBehaviour
{
    private string selctedItem;
    // Start is called before the first frame update
    void Start()
    {
        selctedItem = "Choose Save";
        var dropdown = transform.GetComponent<Dropdown>();
        dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add("Choose Save");
        string path = Application.dataPath + Path.AltDirectorySeparatorChar;
        var files = System.IO.Directory.GetFiles(path);
        foreach (string file in files)
        {
            //Do work on the files here
            if (file.EndsWith("SaveData.json"))
            {
                string tempString = file.Remove(0, path.Length);
                string extraData = "SaveData.json";
                string cafeName = tempString.Remove(tempString.IndexOf(extraData));
                items.Add(cafeName); 
            }
        }

        foreach (var item in items)
        {
            dropdown.options.Add(new Dropdown.OptionData() {text = item});
        }
        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }

    void DropdownItemSelected(Dropdown dropdown)
    {
        //do something with the dropdown here
        int index = dropdown.value;

        selctedItem = dropdown.options[index].text;
        //Debug.Log(selctedItem);
    }

    public string getSelectedSave()
    {
        return selctedItem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
