/*
InteractManager.cs - wirted by ThunderWire Games * Script for Interact Buttons, Items etc.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractManager : MonoBehaviour {
	
	public float PickupRange = 3; 
	//public string UseButton = "Use";
	
	public GameObject playerCam;
	private Ray playerAim;
	
	private bool isPressed;
	private GameObject objectInteract;

	public GameObject cHNormal;
	public GameObject cHHighlight;


	void Start () {
		//playerCam = Camera.main.gameObject;
		isPressed = false;
		objectInteract = null;
	}
	
	void Update () {
		Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;

		if (Physics.Raycast(playerAim, out hit, PickupRange))
		{
			
			if (hit.collider.tag == "ElevatorUp")
			{
				objectInteract = hit.collider.gameObject;
				CrosshairActive();

				if (Input.GetKeyDown(KeyCode.E) && !isPressed)
				{
					InteractUse("ElevatorUp");
					isPressed = true;
				}
				else if (Input.GetKeyDown(KeyCode.E) && isPressed)
				{
					isPressed = false;
				}
				
			}
			if (hit.collider.tag == "ElevatorDown")
			{
				objectInteract = hit.collider.gameObject;
				CrosshairActive();
				
				if (Input.GetKeyDown(KeyCode.E) && !isPressed)
				{
					InteractUse("ElevatorDown");
					isPressed = true;
				}
				else if (Input.GetKeyDown(KeyCode.E) && isPressed)
				{
					isPressed = false;
				}
			}
		}
		else
		{
			CrosshairNormal();
			isPressed = false;
		}
	}
	
	//private void Interact(){
		//Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		//RaycastHit hit;
		
		//if (Physics.Raycast (playerAim, out hit, PickupRange)){
			//objectInteract = hit.collider.gameObject;
			//CrosshairActive();
			//if(hit.collider.tag == "ElevatorUp"){
			//	InteractUse("ElevatorUp");
			//}
			//if(hit.collider.tag == "ElevatorDown"){
			//	InteractUse("ElevatorDown");
			//}
		//}
        //else
        //{
			//CrosshairNormal();
			//isPressed = false;
        //}
	//}
	
    private void InteractUse(string Call)
    {
		objectInteract.GetComponent<ElevatorButton>().SendCall(Call);
    }

	void CrosshairActive()
	{
		cHNormal.SetActive(false);
		cHHighlight.SetActive(true);
	}

	void CrosshairNormal()
	{
		cHNormal.SetActive(true);
		cHHighlight.SetActive(false);
	}
}
