using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    public int DMG = 1;
    public float fireRate = 300;

    public List<Bullet> bullets = new List<Bullet>();
    private float shotTimer;
    

    public List<Enemy> targets = new List<Enemy>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        shotTimer = fireRate;
        foreach (Bullet bullet in this.transform)
        {
            if (!bullet.CompareTag("Bullet")) continue;
            Debug.Log("added" + bullet);
            bullets.Add(bullet.GetComponent<Bullet>());
            bullet.gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;
        if (targets.Any() && shotTimer <=0)
        {
            shotTimer = fireRate;
            fire();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enemy enterd range");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            targets.Add(collision.gameObject.GetComponent<Enemy>());
            Debug.Log($"added {collision} to targets");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("enemy left range");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            targets.Remove(collision.gameObject.GetComponent<Enemy>());
            Debug.Log($"removed {collision} to targets");
        }
    }

    public void fire()
    {
        Debug.Log("shooting");
        for(int i = 0; i< bullets.Count; i++)
        {
            if (!bullets[i].gameObject.activeInHierarchy)
            {
                bullets[i].transform.position = transform.position;
                bullets[i].gameObject.SetActive(true);
                bullets[i].shoot(targets[0],DMG);
                
                break;
            }
        }
    }
}
