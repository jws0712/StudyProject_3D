using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    public GameObject explosionFactory;
    // Start is called before the first frame update
    void OnEnable()
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
        ScoreManager.Instance.Score++;

        GameObject explosion = Instantiate(explosionFactory);

        explosion.transform.position = transform.position;

        if (collision.gameObject.name.Contains("Bullet"))
        {
            collision.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

            player.bulletObjectPool.Add(collision.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }

        gameObject.SetActive(false);

        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>();

        manager.enemyObjectPool.Add(gameObject);
    }
}
