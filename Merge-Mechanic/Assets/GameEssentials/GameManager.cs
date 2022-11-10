using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject[] _balls;
    // 0-Red 1-Green 2-Blue

    [Header("Effects")]
    [SerializeField] private ParticleSystem _createBallEffect;

    // Custom Methods
    public void CreateNewBall(int ballIndex, Vector3 spawnPosition)
    {
        // Don't create a new effect, just replace it
        _createBallEffect.transform.position = spawnPosition;
        _createBallEffect.Play();

        Debug.Log("CreateNewBall() called");
        Debug.Log("-" + spawnPosition);

        // Create new ball
        Instantiate(_balls[ballIndex], spawnPosition, Quaternion.identity);
    }
}
