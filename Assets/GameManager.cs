using NUnit.Framework;
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
    public List<Enemy> wave1 = new List<Enemy>();
    public List<Enemy> wave2 = new List<Enemy>();
    public List<Enemy> wave3 = new List<Enemy>();
    public List<Enemy> wave4 = new List<Enemy>();
    public List<Enemy> wave5 = new List<Enemy>();



}
