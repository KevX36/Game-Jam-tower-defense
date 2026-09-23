using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI goldAmount;
    public TextMeshProUGUI HealthLeft;
    public TextMeshProUGUI WaveText;
    //holds the path enemies take
    public GameObject enemyPath;
    //towns health
    public int TownHealth = 10;
    //current cash
    public int Gold = 10;
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

    public float wavePause = 3;

    public bool debuging = false;

    IEnumerator wave1()
    {
        currentWave = 1;
        updateWave();
        for (int i = 0; i < wave1enemies.Count; i++)
        {
            wave1enemies[i].gameObject.SetActive(true);
            wave1enemies[i].Go();


            yield return new WaitForSecondsRealtime(waveSpeed1);
        }

        yield return new WaitForSecondsRealtime(wavePause);
        StartCoroutine(wave2());
    }
    IEnumerator wave2()
    {
        currentWave = 2;
        updateWave();
        for (int i = 0; i < wave2enemies.Count; i++)
        {
            wave2enemies[i].gameObject.SetActive(true);
            wave2enemies[i].Go();


            yield return new WaitForSecondsRealtime(waveSpeed1);
        }

        yield return new WaitForSecondsRealtime(wavePause);
        StartCoroutine(wave3());
    }
    IEnumerator wave3()
    {
        currentWave = 3;
        updateWave();
        for (int i = 0; i < wave3enemies.Count; i++)
        {
            wave3enemies[i].gameObject.SetActive(true);
            wave3enemies[i].Go();


            yield return new WaitForSecondsRealtime(waveSpeed3);
        }

        yield return new WaitForSecondsRealtime(wavePause);
        StartCoroutine(wave4());
    }
    IEnumerator wave4()
    {

        currentWave = 4;
        updateWave();
        for (int i = 0; i < wave4enemies.Count; i++)
        {
            wave4enemies[i].gameObject.SetActive(true);
            wave4enemies[i].Go();


            yield return new WaitForSecondsRealtime(waveSpeed4);
        }

        yield return new WaitForSecondsRealtime(wavePause);
        StartCoroutine(wave5());
    }
    IEnumerator wave5()
    {
        currentWave = 5;
        updateWave();
        for (int i = 0; i < wave5enemies.Count; i++)
        {
            wave5enemies[i].gameObject.SetActive(true);
            wave5enemies[i].Go();


            yield return new WaitForSecondsRealtime(waveSpeed5);
        }

        yield return new WaitForSecondsRealtime(wavePause);
    }

    public void UpdateGold()
    {
        goldAmount.text = $"Gold: {Gold}";
    }

    public void UpdateHealth()
    {
        HealthLeft.text = $"Town Health: {TownHealth}";
    }
    public void updateWave()
    {
        WaveText.text = $"Wave: {currentWave}";
    }

    private void Start()
    {
        UpdateGold();
        UpdateHealth();
        if (!debuging)
        {
            StartCoroutine(wave1());
        }
    }
    public void Win()
    {

    }
    public void Lose()
    {
        StopAllCoroutines();
    }
    public Enemy boss;
    private void Update()
    {
        if(TownHealth <= 0)
        {
            Lose();
        }
        if(boss.HP <= 0)
        {
            Win();
        }
    }

}
