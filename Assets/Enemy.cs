using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public GameManager gameManager;
    public Rigidbody2D rb;

    public int speed = 2;
    public int HP = 10;

    public int power = 1;

    public Collider2D col;

    public List<Vector2> path = new List<Vector2>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform childTransform in gameManager.enemyPath.transform)
        {
            if (!childTransform.CompareTag("point")) continue;
            Debug.Log("added" + childTransform);
            path.Add(childTransform.position);

        }
        



        if (path.Count == 0) return;
        this.transform.position = path[0];

        if (path.Count > 1)
        {
            StartCoroutine(Move());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            Debug.Log(this + "died");

            Destroy(this.gameObject);
        }
    }

    IEnumerator Move()
    {
        for (int i = 1; i < path.Count; i++)
        {
            while (Vector2.Distance(rb.position, path[i]) > 0.9f)
            {
                Vector2 move = Vector2.MoveTowards(rb.position, path[i], speed * Time.fixedDeltaTime);
                Debug.Log("Moving towards" + path[i]);
                rb.MovePosition(move);



                yield return null;
            }
        }
        Debug.Log(this + "attacked the town");
        gameManager.TownHealth -= power;
        Destroy(this.gameObject);
    }

    
}
