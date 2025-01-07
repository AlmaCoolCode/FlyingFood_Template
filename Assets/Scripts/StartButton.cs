using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private string SceneToLoad;
    public void ButtonPressed()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
 }