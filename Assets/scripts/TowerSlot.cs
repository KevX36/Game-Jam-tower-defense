using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class TowerSlot : MonoBehaviour
{

    
    //set basic tower to 0, fast to 1, strong to 2, and bomb to 3
    public Tower[] towers = new Tower[4];

    public TextMeshProUGUI[] shopButtonText = new TextMeshProUGUI[4];

    public TextMeshProUGUI upgardeButtonText;

    public TextMeshProUGUI sellButtonText;
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
        shopButtonText[0].text = $"archer ({towers[0].cost})";
        shopButtonText[1].text = $"Bolt ({towers[1].cost})";
        shopButtonText[2].text = $"Balasita ({towers[2].cost})";
        shopButtonText[3].text = $"Mage ({towers[3].cost})";
    }
    

    public void UpdatePriceText()
    {
        sellButtonText.text = $"Sell: {(int)Mathf.Round((currentTower.cost * towerLevel) / 2)}";
        upgardeButtonText.text = $"Upgrade: {currentTower.cost * towerLevel}";
    }

    public void BuyBasicTower()
    {
        Debug.Log("tried to buy basic tower");
        currentTower = towers[0];
        ActiveTower();
    }

    public void BuyFastTower()
    {
        Debug.Log("tried to buy fast tower");
        currentTower = towers[1];
        ActiveTower();
    }
    public void BuyStrongTower()
    {
        Debug.Log("tried to buy strong tower");
        currentTower = towers[2];
        ActiveTower();
    }
    public void BuyAoETower()
    {
        Debug.Log("tried to buy AoE tower");
        currentTower = towers[3];
        ActiveTower();
    }

    public void ActiveTower()
    {
        if(currentTower.cost <= gameManager.Gold)
        {
            
            Debug.Log("bought tower");
            gameManager.Gold -= currentTower.cost;
            gameManager.UpdateGold();
            currentTower.gameObject.SetActive(true);
            UpdatePriceText();
            SwapMenu();
        }
        else
        {
            Debug.Log("not enough gold");
            currentTower = null;
        }
        
    }

    public void SellTower()
    {
        Debug.Log("tried to sell tower");
        gameManager.Gold += (int)Mathf.Round((currentTower.cost * towerLevel) / 2);
        
        currentTower = null;
        gameManager.UpdateGold();
        towerLevel = 1;
        
        SwapMenu();
        for (int i = 0; i < towers.Length; i++)
        {
            towers[i].DMG=defualtPower[i];
            towers[i].fireRate=defualtFireRate[i];
            towers[i].bulletSpeed=defualtShotSpeed[i];
            towers[i].gameObject.SetActive(false);
        }
    }

    public void UpgradeTower()
    {
        Debug.Log("tried to upgrade tower");
        if (gameManager.Gold >= currentTower.cost * towerLevel)
        {
            gameManager.Gold -= currentTower.cost * towerLevel;
            Debug.Log("bought upgrade");
            currentTower.upgrade();
            gameManager.UpdateGold();
            towerLevel += 1;
            UpdatePriceText();
        }
        else
        {
            Debug.Log("could not afford upgrade");
        }
    }
    public void SwapMenu()
    {
        if (!towerBought)
        {
            buyMenu.gameObject.SetActive(false);
            sellAndUpgradeMenu.gameObject.SetActive(true);
            towerBought = true;
        }
        else
        {
            sellAndUpgradeMenu.gameObject.SetActive(false);
            buyMenu.gameObject.SetActive(true);
            towerBought = false;
        }
        
    }
    public void CloseMenus()
    {
        sellAndUpgradeMenu.gameObject.SetActive(false);
        buyMenu.gameObject.SetActive(false);
        
    }


}
