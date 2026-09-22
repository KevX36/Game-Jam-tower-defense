using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    //set basic tower to 0, fast to 1, strong to 2, and bomb to 3
    public Tower[] towers = new Tower[4];


    private int towerLevel = 1;
    private int[] defualtPower = new int[4];

    private float[] defualtFireRate = new float[4];

    private int[] defualtShotSpeed = new int[4];

    //changes shop to go between buy and sell/upgrade mode
    public bool towerBought = false;

    public GameObject buyMenu;
    public GameObject sellAndUpgradeMenu;

    public GameManager gameManager;

    private Tower currentTower;

    private void Start()
    {
        for(int i=0;i < towers.Length; i++)
        {
            defualtPower[i] = towers[i].DMG;
            defualtFireRate[i] = towers[i].fireRate;
            defualtShotSpeed[i] = towers[i].bulletSpeed;
            towers[i].gameObject.SetActive(false);
        }
    }

    public void BuyBasicTower()
    {
        currentTower = towers[0];
        ActiveTower();
    }

    public void BuyFastTower()
    {
        currentTower = towers[1];
        ActiveTower();
    }
    public void BuyStrongTower()
    {
        currentTower = towers[2];
        ActiveTower();
    }
    public void BuyAoETower()
    {
        currentTower = towers[3];
        ActiveTower();
    }

    public void ActiveTower()
    {
        if(currentTower.cost <= gameManager.Gold)
        {
            gameManager.Gold -= currentTower.cost;
            currentTower.gameObject.SetActive(true);
            towerBought = true;
        }
    }

    public void SellTower()
    {
        gameManager.Gold += (currentTower.cost * towerLevel) / 2;
        
        currentTower = null;

        towerLevel = 1;

        for (int i = 0; i < towers.Length; i++)
        {
            towers[i].DMG=defualtPower[i];
            towers[i].fireRate=defualtFireRate[i];
            towers[i].bulletSpeed=defualtShotSpeed[i];
            towers[i].gameObject.SetActive(false);
        }
    }






}
