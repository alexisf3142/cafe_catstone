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

    public GameObject MainManager;
    
    //public GameObject TextBox;

    public Text text;

    public Button TextBox;
    
    public Text csText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.GetComponent<MainManager>().GetDay() > 1)
        {
            SpriteRenderer.sprite = Happy;
            TextBox.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            text.text = "A brand new day! Let's work hard!";
            StartCoroutine(waiter());

        }
        else
        {
            SpriteRenderer.sprite = Happy;
            TextBox.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            text.text = "Welcome to the Cafe! Let's start the day!";
            StartCoroutine(waiter()); 
        }
        
        
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
    
    public void NewCustomer()
    {
        SpriteRenderer.sprite = Happy;
        TextBox.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        text.text = "A customer! Coffee coming right up!";
        StartCoroutine(waiter());
    }

    public void UpdateCoffeeCount(int count)
    {
        csText.text = count.ToString();
    }
    
}
