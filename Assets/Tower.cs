using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    public int DMG = 1;
    public float fireRate = 5;

    

    public List<Enemy> targets = new List<Enemy>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    }
}
