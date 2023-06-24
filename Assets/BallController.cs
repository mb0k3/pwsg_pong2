using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed = 10f;
    public Vector3 vel;

    public ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); // Droga operacja, najlepiej na void Start() daæ
        rb2D.velocity = GenerateRandomVelocity(true) * speed;
        vel = rb2D.velocity;
    }

    private void ResetAndSendBallInRandomDirection()
    {
        rb2D.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        rb2D.velocity = GenerateRandomVelocity(true) * speed;
        vel = rb2D.velocity;
    }

    private Vector3 GenerateRandomVelocity(bool shouldReturnNormalized)
    {
        Vector3 velocity = new Vector3();
        velocity.x = Random.Range(-1f, 1f);
        velocity.y = Random.value < .5f ? Random.Range(-1f, -.5f) : Random.Range(.5f, 1f);

        return shouldReturnNormalized ? velocity.normalized : velocity;

        /* to samo co:
         if (shouldReturnNormalized)
        {
            return velocity.normalized;
        }

        return velocity;*/

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 newVelocity = vel;
        newVelocity += new Vector3(Random.Range(-0.5f, 3f), Random.Range(-0.5f, 3f));
        rb2D.velocity = Vector3.Reflect(newVelocity, collision.contacts[0].normal);
        vel = rb2D.velocity;
    }
    //scoring system
    /*private int player1Score;
    private int player2Score;*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            scoreManager.IncrementLeftPlayerScore();
            print("Left Player +1");
        }

        if (transform.position.x < 0)
        {
            scoreManager.IncrementRightPlayerScore();
            print("Right Player +1");
        }
            

        ResetAndSendBallInRandomDirection();
    }

}

