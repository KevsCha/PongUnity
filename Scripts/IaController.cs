using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IaController : MonoBehaviour
{
    public GameObject ball;
    public float vel;
    float dir;
    [SerializeField] Vector3 pos;
    Rigidbody2D rb;

    private void Awake()
    {
        pos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        dir = transform.position.y > ball.transform.position.y ? -1 : 1;
        rb.velocity = new Vector2(rb.velocity.x, dir * vel);
    }
    public void ResetIa() 
    {
        transform.position = pos;
        rb.velocity = Vector2.zero;
    }
    public void StopIa()
    {
        rb.velocity = Vector2.zero;
		transform.position = pos;
    }
}
