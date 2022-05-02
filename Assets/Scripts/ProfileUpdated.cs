using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileUpdated : MonoBehaviour
{
    public GameObject Profile;
    public SpriteRenderer SpriteRenderer;

    public Sprite Happy;
    public Sprite Surprised;
    public Sprite Normal;
    public Sprite Content;
    public Sprite Sad;
    
    //public GameObject TextBox;

    public Text text;

    public Button TextBox;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer.sprite = Happy;
        TextBox.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        text.text = "Welcome to the Cafe! Let's start the day!";
        StartCoroutine(waiter());
        
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(5);
        text.gameObject.SetActive(false);
        TextBox.gameObject.SetActive(false);
        SpriteRenderer.sprite = Normal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void CoffeeSpilledReaction()
    {
        SpriteRenderer.sprite = Surprised;
        TextBox.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        text.text = "Oh no! A spill! Make sure to clean it up!";
        StartCoroutine(waiter());
    }

    public void AlmostEndOfDay()
    {
        SpriteRenderer.sprite = Content;
        TextBox.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        text.text = "Almost closing time! Let's finish up!";
        StartCoroutine(waiter());
    }

    public void EndOfDay()
    {
        SpriteRenderer.sprite = Sad;
        TextBox.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        text.text = "I'm so tired, but good job today!";
        StartCoroutine(waiter());
    }
    
}
