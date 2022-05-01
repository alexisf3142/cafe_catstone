using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catMoving : MonoBehaviour
{
    private Stack<Vector3> movingStack = new Stack<Vector3>();
    private Vector3 targetPos;
    public float speed = 1.0f;
    public Animator animator;
    public GameObject player;
    public AudioSource audioSource;
    public AudioClip CatSound1;
    public AudioClip CatSound2;
    public AudioClip CatSound3;
    public AudioClip CatSound4;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void setPlayer(GameObject player)
    {
        this.player = player;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            tryCatNoise();
        }
    }

    private void tryCatNoise()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 1.5f)
        {
            int chooseSound = Random.Range(0, 4);
            if (chooseSound == 0)
            {
                audioSource.clip = CatSound1;
                audioSource.Play();
            }
            if (chooseSound == 1)
            {
                audioSource.clip = CatSound2;
                audioSource.Play();
            }
            if (chooseSound == 2)
            {
                audioSource.clip = CatSound3;
                audioSource.Play();
            }
            if (chooseSound == 3)
            {
                audioSource.clip = CatSound4;
                audioSource.Play();
            }
        }
    }

    void updateAnimations()
    {
        if (transform.position == this.targetPos)
        {
            animator.SetFloat("horizontal", 0);
            animator.SetFloat("vertical", 0);
            animator.SetFloat("speed", 0);
        }
        else
        {
            Vector3 dir = (targetPos - this.transform.position).normalized;
            animator.SetFloat("horizontal", dir.x);
            animator.SetFloat("vertical", dir.y);
            animator.SetFloat("speed", 1);
        }
    }
    
    private void FixedUpdate()
    {
        if (this.movingStack.Count != 0)
        {
            if (transform.position == this.movingStack.Peek())
            {
                movingStack.Pop();
                if (this.movingStack.Count != 0)
                {
                    targetPos = this.movingStack.Peek();  
                }
            }   
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        updateAnimations();
    }
    
    
    /* What do: Moves customer to a point
     * Input: a Vector3 position
     * Output: Void
     */
    public void setTargetPos (Vector3 target)
    {
        this.targetPos = target;
    }
    
    /* What do: Moves customer through a list of points
     * Input: A list of points for the customer to move through in-order
     * Output: Void
     */
    public void setTargetPosStack (List<Vector3> targetList)
    {
        /*for (int i = targetList.Count-1; i > 0; i++)
        {
            movingStack.Push(targetList[i]);
        }*/

        for (int i = 0; i < targetList.Count; i++)
        {
            movingStack.Push(targetList[i]);
        }

        targetPos = this.movingStack.Peek();

    }
}
