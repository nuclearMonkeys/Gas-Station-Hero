using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private LineRenderer lineRenderer;

    public string path;

    private bool isGoingToCounter = true;
    private bool isOnCounter = false;
    private bool isLeavingStore = false;
    private bool isServed = false;
    private bool dialogueLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();

        RaycastHit2D counterhit = Physics2D.Raycast(transform.position, direction, 1.5f, 1 << LayerManager.COUNTER);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position - new Vector3(0, 1.5f, 0));
        if(counterhit)
        {
            isGoingToCounter = false;
            rb.velocity = Vector3.zero;
            CounterEnter();

        if (isOnCounter && Input.GetKeyDown(KeyCode.C)) 
        {
            RunDialogue();
        }
            return;
        }



        rb.velocity = direction * speed;
    }

    private void CounterEnter() 
    {
        isOnCounter = true;
    }

    private void CounterExit() 
    {
        isOnCounter = false;
    }

    private void RunDialogue() 
    {
        if (isOnCounter && !dialogueLoaded) 
        {
            
            dialogueLoaded = DialogueManager.instance.loadDialogue(path);
        }
        if (dialogueLoaded)
            dialogueLoaded = DialogueManager.instance.printLine();
    }  

    void MoveToPlayer() 
    {
        direction = -transform.up.normalized;
        // transform.right = -transform.up.normalized;
    }
}
