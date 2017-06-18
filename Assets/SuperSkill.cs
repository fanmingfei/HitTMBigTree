﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SuperSkill : MonoBehaviour {

	public GameObject prefab;
	public int minBlood = 100;
	private bool isTriggerHuge;


	private int initalDamage;
	private float initalBetwwenAttack;
	private GameObject initalPrefab;

	void Start () {
		initalDamage = GetComponent<EnemyAttack> ().attackDamage;
		initalBetwwenAttack = GetComponent<EnemyAttack> ().timeBetweenAttacks;
		initalPrefab = GetComponent<triggerProjectile> ().hitEffect;
	}
	
	void Update () {

		if(gameObject.name == "Enemy_Necro" && GetComponent<EnemyBattle>().HP < minBlood && isTriggerHuge != true)
		{
			isTriggerHuge = true;
			gameObject.transform.DOScale (new Vector3 (1.8f, 1.8f, 1.8f), 2).SetEase(Ease.InQuad);
			GetComponent<EnemyAttack>().attackDamage = initalDamage * 2 / 3;
			GetComponent<EnemyAttack>().timeBetweenAttacks = initalBetwwenAttack * 3 / 2;
			GetComponent<triggerProjectile> ().hitEffect = prefab;
			Invoke ("ReSetSkill", 10f);
		}
	}

	void ReSetSkill()
	{
		gameObject.transform.DOScale (new Vector3 (1.3f, 1.3f, 1.3f), 1).SetEase(Ease.OutQuad);
		GetComponent<EnemyAttack>().attackDamage = initalDamage;
		GetComponent<EnemyAttack>().timeBetweenAttacks = initalBetwwenAttack;
		GetComponent<triggerProjectile> ().hitEffect = initalPrefab;
	}
}