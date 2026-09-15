using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameManager gameManager;
    public Rigidbody rb;

    public int speed = 3;

    public Collider col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move()
    {
        for (int i = 1; i < gameManager.enemyPath.Count; i++)
        {
            Vector3 move = Vector3.MoveTowards(rb.position, gameManager.enemyPath[i].position, speed * Time.fixedDeltaTime);
            Debug.Log("Moving");
            rb.MovePosition(move);



            yield return null;
        }
    }
}
