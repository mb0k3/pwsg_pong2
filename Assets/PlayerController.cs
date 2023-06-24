using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode shootKey;
    public KeyCode shiedlKey;

    [SerializeField] private GameObject bulletPrefab;
    public Transform firingPoint;
    [Range(0.1f, 2f)]
    public float fireRate = 0.5f;
    private float fireTimer;

    public float cooldownTime = 20;
    private float nextFireTime = 10;

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
            if (Input.GetKeyDown(shiedlKey))
            {
                print("shield used, cooldown started");
                Shield();
                nextFireTime= Time.time + cooldownTime;
            }
        }
    }
    private void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
    private void Shield()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}
