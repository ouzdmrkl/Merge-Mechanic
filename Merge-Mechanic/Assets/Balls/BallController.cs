using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private GameManager gameManager;

    // Ball index for spawning new ball
    [SerializeField] private int _ballIndex;

    // For preventing spawn 2 balls at once
    public bool _canCallCreateNewBall;

    // Default Methods
    void Awake()
    {
        // Get GameManager at beginning
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>(); 

        _canCallCreateNewBall= true;
    }

    BallController _collidedBall;

    void OnCollisionEnter(Collision collision)
    {
        // If ball didn't collide with ball, act nothing
        if (!collision.gameObject.CompareTag("Ball"))
        {
            return;
        }

        _collidedBall = collision.gameObject.GetComponent<BallController>();

        if (_collidedBall.GetBallIndex() == this._ballIndex)
        {
            // Prevent spawning 2 balls
            collision.gameObject.GetComponent<BallController>()._canCallCreateNewBall= false;

            if (_canCallCreateNewBall)
            {
                gameManager.CreateNewBall(_ballIndex, collision.contacts[0].point);
            }

            // Destroy balls
            Destroy(this.gameObject);
        }
    }

    // Custom Methods

    public int GetBallIndex()
    {
        return _ballIndex;
    }
}
