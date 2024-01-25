using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 5;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        

        int randValue = UnityEngine.Random.Range(0, 10);

        if(randValue < 3)
        {
            GameObject target = GameObject.Find("Player");

            dir = target.transform.position - transform.position;

            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
