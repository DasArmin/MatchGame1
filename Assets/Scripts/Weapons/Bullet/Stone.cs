﻿using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour
{
    //Rigidbody of the Gameobject
    [SerializeField] private Rigidbody2D rbStone;
    //Sprite of this bullet
    [SerializeField] private SpriteRenderer sprite;
    //Speed of the bullet
    [SerializeField] private float speed;
    //Amout of damage that the bullet will deal
    [SerializeField] private int damage;
    //Amount of Knockback the bullet will give
    [SerializeField] private float knockback;
    private bool isRight;
    private bool isLeft;

    //Sets the place the player is facing
    public void ShootLeft()
    {
        isLeft = true;
        sprite.flipX = true;
        SoundManager.PlayAudioClip(AudioData.stone);
    }

    //Sets the place the player is facing
    public void ShootRight()
    {
        isRight = true;
        SoundManager.PlayAudioClip(AudioData.stone);
    }

    void FixedUpdate()
    {
        if (isRight)
            rbStone.velocity = new Vector2(speed, rbStone.velocity.y);
        else if (isLeft)
            rbStone.velocity = new Vector2(-speed, rbStone.velocity.y);
    }

    void Hit(GameObject player)
    {
        //Finds the health script of the hit player 
        HealthPlayer healthPlayer = player.GetComponent<HealthPlayer>();
        healthPlayer.ChangeHealth(damage, true);
        //Give the player knockback
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        Rigidbody2D rbPlayer = player.GetComponent<Rigidbody2D>();
        Vector2 currPosition = (rbStone.position - rbPlayer.position).normalized;
        float xPos = currPosition.x * knockback;
        playerMovement.ApplyKnockback(xPos);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject != null)
        {
            if (coll.gameObject.CompareTag(GameTags.player))
            {
                Hit(coll.gameObject);
                isRight = false;
                isLeft = false;
                Destroy(this.gameObject);
            }

            else
                gameObject.AddComponent<Fade>();
        }
    }
}