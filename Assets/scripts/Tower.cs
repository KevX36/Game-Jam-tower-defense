using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    //cost to buy tower
    public int cost = 5;
    //damage shots will do
    public int DMG = 1;
    //mutliper for shot speed
    public float fireRate = 3;
    //time to shot
    public float shotCoolDown = 5;
    public List<Bullet> bullets = new List<Bullet>();
    //countdown to shoot
    public float shotTimer;
    //speed of shots after fired
    public int bulletSpeed = 5;
    //only used for bomb tower
    public float blastRange = 3;
    public Collider2D fireRange;

    public List<Enemy> targets = new List<Enemy>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireRange = this.gameObject.GetComponent<Collider2D>();
        shotTimer = shotCoolDown;
        
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime*fireRate;
        if (targets.Any() && shotTimer <=0)
        {
            shotTimer = shotCoolDown;
            fire();
        }
    }
    //checks when enemies enter firing range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enemy enterd range");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            targets.Add(collision.gameObject.GetComponent<Enemy>());
            Debug.Log($"added {collision} to targets");
        }
    }
    //checks when enemies leave firing range
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("enemy left range");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            targets.Remove(collision.gameObject.GetComponent<Enemy>());
            Debug.Log($"removed {collision} to targets");
        }
    }
    //makes the tower shoot the first enemy to enter firing range
    public void fire()
    {
        
        for(int i = 0; i< bullets.Count; i++)
        {
            if (!bullets[i].gameObject.activeInHierarchy)
            {
                Debug.Log("shooting");
                bullets[i].transform.position = transform.position;
                bullets[i].gameObject.SetActive(true);
                bullets[i].shoot(targets[0],DMG,bulletSpeed, blastRange);
                
                break;
            }
        }
    }
    //boost main property of tower whenever upgrade is bought 
    public enum TowerType
    {
        basic,
        fast,
        strong,
        AoE

    }
    public TowerType towerType;
    public float UpgradeBoost;
    public void upgrade()
    {

        switch (towerType)
        {

            case TowerType.basic:

                bulletSpeed += (int)Mathf.Round(UpgradeBoost);


                break;


            case TowerType.fast:

                fireRate += UpgradeBoost;



                break;


            case TowerType.strong:

                DMG += (int)Mathf.Round(UpgradeBoost);




                break;







            case TowerType.AoE:

                blastRange += UpgradeBoost;



                break;


        }








    }
}
