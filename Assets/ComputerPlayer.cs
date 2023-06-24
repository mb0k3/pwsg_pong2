using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayer : MonoBehaviour
{
    public Rigidbody2D ball;
    public float speed = 40f; 
    protected Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (this.ball.velocity.x > 0f)
        {
            if (this.ball.position.y > this.transform.position.y)
            {
                rb2D.AddForce(Vector3.up * this.speed);
            }
            else if (this.ball.position.y < this.transform.position.y)
            {
                rb2D.AddForce(Vector3.down* this.speed);
            }
        }
        else
        {
            if (this.transform.position.y > 0f)
            {
               // player.Shoot();
                rb2D.AddForce(Vector3.down * this.speed); }
            else if (this.transform.position.y < 0f)
            {
                rb2D.AddForce(Vector3.up * this.speed);
            }
            }
        }
}
