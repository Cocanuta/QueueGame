using UnityEngine;
using System.Collections;

public class Customer {

	public int customerID;
	public string customerName;
	public int customerItems;
	public bool customerDone;
	public Vector3 customerTarget;
	public int customerTargetTill;
	public int customerPlaceInLine;

	public Customer(int newID, string newName, int newItems, Vector3 newTarget, int newTargetTill, int newPlaceInLine)
	{
		customerID = newID;
		customerName = newName;
		customerItems = newItems;
		customerDone = false;
		customerTarget = newTarget;
		customerTargetTill = newTargetTill;
		customerPlaceInLine = newPlaceInLine;
	}

}
