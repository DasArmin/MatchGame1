﻿using UnityEngine;
using System.Collections;

public class PlayerSendText : MonoBehaviour {

    public delegate void ProjectileTextEventHandler(PlayerSendText player);

    public static event ProjectileTextEventHandler OnStoneDeath;
    public static event ProjectileTextEventHandler OnPillDeath;
    public static event ProjectileTextEventHandler OnShurikenDeath;
    public static event ProjectileTextEventHandler OnHadoukenDeath;
    public static event ProjectileTextEventHandler OnPizzaDeath;
    public static event ProjectileTextEventHandler OnBarrelDeath;
    public static event ProjectileTextEventHandler OnSockDeath;
    public static event ProjectileTextEventHandler OnDuckDeath;
    public static event ProjectileTextEventHandler OnBombDeath;


    [SerializeField]
    private HealthPlayer _healthPlayer;

    bool _sendText;


	void Awake()
    {
        HealthPlayer.OnNewRound += SendText;
    }

    void OnCollisionEnter2D(Collision2D projectile)
    {
        if (projectile.gameObject.tag == "Bullet")
        {
          if (projectile.gameObject.GetComponent<Stone>() != null)
          {
              if (OnStoneDeath != null)
                  OnStoneDeath(this);
          }

          else if (projectile.gameObject.GetComponent<Pill>() != null)
          {
              if (OnPillDeath != null)
                  OnPillDeath(this);
          }

          else if (projectile.gameObject.GetComponent<Shuriken>() != null)
          {
              if (OnShurikenDeath != null)
                  OnShurikenDeath(this);
          }


          else if (projectile.gameObject.GetComponent<Hadouken>() != null)
          {
              if (OnHadoukenDeath != null)
                  OnHadoukenDeath(this);
          }

          else if (projectile.gameObject.GetComponent<Pizza>() != null)
          {
              if (OnPizzaDeath != null)
                  OnPizzaDeath(this);
          }

          else if (projectile.gameObject.GetComponent<Barrel>() != null)
          {
              if (OnBarrelDeath != null)
                  OnBarrelDeath(this);
          }

          else if (projectile.gameObject.GetComponent<Sock>() != null)
          {
              if (OnSockDeath != null)
                  OnSockDeath(this);
          }

          else if (projectile.gameObject.GetComponent<Duck>() != null)
          {
              if (OnDuckDeath != null)
                  OnDuckDeath(this);
          }

        }
    }

    void SendText(HealthPlayer player)
    {
        _sendText = true;
    }
}