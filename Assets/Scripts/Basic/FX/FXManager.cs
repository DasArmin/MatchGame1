﻿using UnityEngine;
using System.Collections;

public class FXManager : MonoBehaviour {


    // Bool
    [SerializeField]
    private bool _playAtStart;
    // Bool

    // GameObject
    [SerializeField]
    private GameObject[] _FXObj;
    // GameObject

    // int
    [SerializeField]
    private int _customFXPlay;
    // int
    
    /*
     * FX INDEX
     * 0 = Smoke
     * 1 = Explosion
     */

	void Start () 
    {
        if (_playAtStart)
          Instantiate(_FXObj[_customFXPlay], transform.position, Quaternion.identity);
	}
	
	public void PlayFX(int fx, Vector2 fxposition)
    {
       GameObject fxobject = Instantiate(_FXObj[fx], fxposition, Quaternion.identity) as GameObject;
    }
}
