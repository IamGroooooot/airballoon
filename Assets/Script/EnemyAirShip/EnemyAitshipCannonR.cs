﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAitshipCannonR : MonoBehaviour {


	//포탄 발사 딜레이
	public float delay = 3f;
	public int reload = 30;
	public bool CanShoot, TimerOn,FindPlayerR;
	int time;
	public float bullectRSpeed = 100f;

	//발사위치
	public Transform Fire_1;

	public Vector3 WhereToFireRC1;


	//복제할 총알 오브젝트
	public GameObject BulletRC1;

	private GameObject TempBulletRC1;

	// Use this for initialization
	void Start()
	{
		CanShoot = true;
		time = 0;
		WhereToFireRC1= new Vector3(0,0,0);

		FindPlayerR=false;
	}

	// Update is called once per frame
	void Update()
	{
		if (FindPlayerR)
		{
			Vector3 PlayerPos1;

			PlayerPos1 = FindPlayer ().transform.position;
			WhereToFireRC1 = PlayerPos1 - Fire_1.position;
		}

		if (TimerOn)
		{
			time++;
			if (time == reload)
			{
				//Debug.Log ("대포 발사1");
				Vector3 FirePos_1 = Fire_1.position;
				TempBulletRC1 = Instantiate (BulletRC1, FirePos_1, BulletRC1.transform.rotation) as GameObject;

				TempBulletRC1.GetComponent<Rigidbody> ().velocity =  WhereToFireRC1.normalized* bullectRSpeed;
			}
			else if (time == reload * 2)
			{

			}
			else if (time == reload * 3)
			{
				time = 0;
				TimerOn = false;
			}
		}
		else
		{
			FindPlayerR = false;
		}
	}

	void OnTriggerEnter(Collider CollEnter)
	{
		OnTriggerStay(CollEnter);
	}

	void OnTriggerStay(Collider other)
	{
		//발사 범위 충돌 시 발사여부 체크

		if (other.transform.tag == "Player")
		{
			FindPlayerR = true;
			//Debug.Log("발사범위 접촉");
			playerFire();
		}
	}

	public void playerFire()
	{
		if (CanShoot)
		{
			//Debug.Log("대포 발사");
			TimerOn = true;

			StartCoroutine(Fire());
		}
	}

	IEnumerator Fire()
	{
		//처음에 CanShoot을 false로 만들고(발사불가 시간)
		CanShoot = false;
		//딜레이 시간만큼 기다리게 한다 false = delay 시간동안 지속
		yield return new WaitForSeconds(delay);
		//딜레이 시간이 지나면 발사 가능
		CanShoot = true;
	}

	public GameObject FindPlayer(){
		return GameObject.FindGameObjectWithTag ("Player");
	}


}