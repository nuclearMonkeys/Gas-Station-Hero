using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private LineRenderer lineRenderer;

    public bool isGoingToCounter = true;
    public bool isLeavingStore = false;
    public bool isServed = false;

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
            return;
        }
        rb.velocity = direction * speed;
    }

    void MoveToPlayer() 
    {
        direction = -transform.up.normalized;
        // transform.right = -transform.up.normalized;
    }
}
