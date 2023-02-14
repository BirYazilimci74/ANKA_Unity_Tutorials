using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SoundController soundController;
    [SerializeField] private AnimationController animations;
    [SerializeField] private EffectManager effectManager;
    [SerializeField] private UIController uiController;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Rigidbody player;
    [SerializeField] private float jumpForce;

    bool hasCrashed = false;
    private bool canJump;

    private void Update()
    {
        if (!uiController.isStart)
        {
            return;
        }
        Jump();
        Limit();
        animations.Run();
        effectManager.ParticalsActive();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle") && !hasCrashed)
        {
            GameOver();
        }

        if (collision.collider.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            canJump = false;
        }
    }


    private void GameOver()
    {
        hasCrashed = true;
        animations.Death();
        gameManager.isGameOver = true;
        uiController.finishScreen.SetActive(true);
        effectManager.BombEffectActive();
        effectManager.ParticalsDeactive();
        soundController.PlayCrashSound();
    }
    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && !gameManager.isGameOver && canJump)
        {
            player.AddForce(0,jumpForce,0,ForceMode.Impulse);
            effectManager.ParticalsDeactive();
            animations.Jump();
            soundController.PlayJumpSound();
        }
    }

    private void Limit()
    {
        if (transform.position.y > 3.6f)
        {
            transform.Translate(Vector3.down* (transform.position.y - 3.6f));
        }
    }
}
