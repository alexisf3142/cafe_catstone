using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        items.Add("Save 1");
        items.Add("Save 2");

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
        Debug.Log(selctedItem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
