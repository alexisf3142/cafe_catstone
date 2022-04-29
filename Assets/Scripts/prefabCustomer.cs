using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class prefabCustomer : MonoBehaviour
{
    
    private bool orderStatus;
    private int placeInLine; // add this in later
    private Vector3 targetPos;
    public Vector3 direction;
    public float speed = 1.0f;
    private List<string> orderList = new List<string>();
    private Stack<Vector3> movingStack = new Stack<Vector3>();
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.orderStatus = false;
        this.placeInLine = 0;
        generator gen = new generator();
        this.orderList = gen.genrateOrder();
        Debug.Log(string.Join(", ", orderList));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Prefab");
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

    void updateAnimations()
    {
        if (transform.position == this.targetPos)
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
        }
        else
        {
            Vector3 dir = (targetPos - this.transform.position).normalized;
            animator.SetFloat("Horizontal", dir.x);
            animator.SetFloat("Vertical", dir.y);
            animator.SetFloat("Speed", 1);
        }
    }
    public bool getOrderStatus (){
        return this.orderStatus;
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
        movingStack = new Stack<Vector3>();

        for (int i = 0; i < targetList.Count; i++)
        {
            movingStack.Push(targetList[i]);
        }

        targetPos = this.movingStack.Peek();

    }
}
