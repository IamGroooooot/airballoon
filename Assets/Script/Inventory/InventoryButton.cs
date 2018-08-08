﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//인벤토리 패널 컨트롤과 버튼 클릭 가능한지 설정
public class InventoryButton : MonoBehaviour {
	GameObject inventoryPanel;
    public GameObject SkillTouch1;
    public GameObject SkillTouch2;
    public GameObject SkillTouch3;



    void Start(){
		inventoryPanel = GameObject.Find ("Inventory_Panel");

	}

	public void OnInvButtonClicked(){
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            SkillTouch1.GetComponent<Image>().raycastTarget = false;
            SkillTouch2.GetComponent<Image>().raycastTarget = false;
            SkillTouch3.GetComponent<Image>().raycastTarget = false;

        }
        else
        {
            inventoryPanel.SetActive(false);
            SkillTouch1.GetComponent<Image>().raycastTarget = true;
            SkillTouch2.GetComponent<Image>().raycastTarget = true;
            SkillTouch3.GetComponent<Image>().raycastTarget = true;
        }

	}

}
