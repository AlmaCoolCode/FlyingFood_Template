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

    private void Awake() 
    {
        foreach (Transform spawnPoint in spawnPointHolder)
        {
            allSpawns.Add(spawnPoint);
        }
        score = 0;
    }

    private void OnCollisionEnter(Collision other) 
    {
        Respawn();
        
    }

    private void Respawn()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        Instantiate(hitEffect, transform.position, transform.rotation);
        Transform randomSpawn = allSpawns[Random.Range(0, allSpawns.Count)];
        transform.SetPositionAndRotation(randomSpawn.position, randomSpawn.rotation);
        Instantiate(appearEffect, transform.position, transform.rotation);
    }
}