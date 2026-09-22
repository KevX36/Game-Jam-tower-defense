using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    //set basic tower to 0, fast to 1, strong to 2, and bomb to 3
    public Tower[] towers = new Tower[4];

    private int[] defualtPower = new int[4];

    private float[] defualtFireRate = new float[4];

    private int[] defualtShotSpeed = new int[4];

    private void Start()
    {
        for(int i=0;i < towers.Length; i++)
        {
            defualtPower[i] = towers[i].DMG;
            defualtFireRate[i] = towers[i].fireRate;
            defualtShotSpeed[i] = towers[i].bulletSpeed;
        }
    }
}
