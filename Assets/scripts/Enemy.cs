using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //gold gained when defeating enemy
    public int goldDropped = 3;

    public GameManager gameManager;
    public Rigidbody2D rb;

    //set on for debugging, set off for game
    public bool active = false;
    //movement speed
    public int speed = 2;
    //health
    public int HP = 10;
    //damage done if tower in reached
    public int power = 1;

    

    public List<Vector2> path = new List<Vector2>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform childTransform in gameManager.enemyPath.transform)
        {
            if (!childTransform.CompareTag("point")) continue;
            //Debug.Log("added" + childTransform);
            path.Add(childTransform.position);

        }
        
        if (active)
        {
            Go();
        }
        else
        {
            this.gameObject.SetActive(false);
        }

        
    }

    public void TakeDamage(int DMG)
    {
        HP -= DMG;
        Debug.Log("got hit");
    }
    // Update is called once per frame
    void Update()
    {
        //check if alive
        if(HP <= 0)
        {
            Debug.Log(this + "died");
            gameManager.Gold += goldDropped;
            gameManager.UpdateGold();
            Destroy(this.gameObject);
        }
    }

    public void Go()
    {

        if (path.Count == 0) return;
        this.transform.position = path[0];
        active = true;
        if (path.Count > 1)
        {
            if(gameManager.currentWave != 1)
            {
                speed += (gameManager.currentWave) / 2;
                HP += (int)Mathf.Round((gameManager.currentWave - 1) * 1.5f);
                goldDropped = (goldDropped * gameManager.currentWave) / 2;
            }
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        for (int i = 1; i < path.Count; i++)
        {
            while (Vector2.Distance(rb.position, path[i]) > 0.9f)
            {
                Vector2 move = Vector2.MoveTowards(rb.position, path[i], speed * Time.fixedDeltaTime);
                //Debug.Log("Moving towards" + path[i]);
                rb.MovePosition(move);



                yield return null;
            }
        }
        Debug.Log(this + "attacked the town");
        gameManager.TownHealth -= power;
        gameManager.UpdateHealth();
        Destroy(this.gameObject);
    }

    
}
