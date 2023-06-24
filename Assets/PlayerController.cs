using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode shootKey;
    public KeyCode shieldKey;

    public GameObject bulletPrefab;
    public GameObject shieldPrefab;

    public Transform firingPoint;
    [Range(0.1f, 2f)]
    public float fireRate = 0.5f;
    private float fireTimer;

    public float cooldownTime = 10;
    private float nextFireTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }


    void Update()
    {
        if (Input.GetKey(upKey) && transform.position.y < 6)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }

        if (Input.GetKey(downKey) && transform.position.y > -6)
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }

        //shooting ability
        if (Input.GetKeyDown(shootKey) && fireTimer <= 0f)
        {
            Shoot(); fireTimer = fireRate;
        } else
        {
            fireTimer -= Time.deltaTime;
        }
        //shield ability
        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown(shieldKey))
            {
                print("shield used, cooldown started");
                Shield();
                nextFireTime= Time.time + cooldownTime;
            }
        }
    }
    public void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
    private void Shield()
    {
        Instantiate(shieldPrefab, firingPoint.position, firingPoint.rotation);
    }
}
