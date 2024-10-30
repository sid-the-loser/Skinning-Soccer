using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostDetection : MonoBehaviour
{
    [SerializeField] private int whoWins = 1;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Sid/Scenes/Ending");
    }
}
