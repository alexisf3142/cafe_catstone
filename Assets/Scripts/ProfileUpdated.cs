using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileUpdated : MonoBehaviour
{
    public GameObject Happy;

    public GameObject Surprised;

    public GameObject Normal;

    //public GameObject TextBox;

    public Text text;

    public Button TextBox;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Normal.SetActive(true);
        Surprised.SetActive(false);
        TextBox.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        text.text = "Welcome to the Cafe! Let's start the day!";
        StartCoroutine(waiter());


    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(10);
        text.gameObject.SetActive(false);
        TextBox.gameObject.SetActive(false);
        Normal.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeSurprised()
    {
        
    }
    
}
