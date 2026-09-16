using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //holds the path enemies take
    public GameObject enemyPath;
    //towns health
    public int TownHealth;
    //current wave
    public int currentWave = 1;
    //enemy waves
    public List<Enemy> wave1enemies = new List<Enemy>();
    public List<Enemy> wave2enemies = new List<Enemy>();
    public List<Enemy> wave3enemies = new List<Enemy>();
    public List<Enemy> wave4enemies = new List<Enemy>();
    public List<Enemy> wave5enemies = new List<Enemy>();

    //speed enemies spawn each wave
    public float waveSpeed1 = 5.0f;
    public float waveSpeed2 = 5.0f;
    public float waveSpeed3 = 5.0f;
    public float waveSpeed4 = 5.0f;
    public float waveSpeed5 = 5.0f;

    IEnumerator wave1()
    {
        while (wave1enemies.Count > 0)
        {
            for(int i = 0; i < wave1enemies.Count; i++)
            {
                wave1enemies[i].Go();


                yield return new WaitForSecondsRealtime(waveSpeed1);
            }


            
        }
    }



}
