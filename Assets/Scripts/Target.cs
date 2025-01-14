using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform spawnPointHolder;
    private List<Transform> allSpawns = new List<Transform>();
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private GameObject appearEffect;
    private int score;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highscoreText;
    private Transform lastSpawn;

    private void Awake() 
    {
        foreach (Transform spawnPoint in spawnPointHolder)
        {
            allSpawns.Add(spawnPoint);
        }
        score = 0;
    }
    private void Start()
    {
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    private void OnCollisionEnter(Collision other) 
    {
        Respawn();
        
    }

    private void Respawn()
    {
        score++;
        if (PlayerPrefs.GetInt("Highscore") < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
        Instantiate(hitEffect, transform.position, transform.rotation);
        if (lastSpawn != null) 
        {
            allSpawns.Remove(lastSpawn);
        }
        Transform randomSpawn = allSpawns[Random.Range(0, allSpawns.Count)];
        if (lastSpawn != null)
        {
           allSpawns.Add(lastSpawn);
        }
        lastSpawn = randomSpawn;
        transform.SetPositionAndRotation(randomSpawn.position, randomSpawn.rotation);
        Instantiate(appearEffect, transform.position, transform.rotation);
    }
}
