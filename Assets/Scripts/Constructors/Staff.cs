using UnityEngine;
using System.Collections;

public class Staff {

	public int staffID;
	public string staffName;
	public int staffTillID;
	public bool staffServing;
	public float staffEnergy;
	public bool staffActive;

	public Staff(int newID, string newName)
	{
		staffID = newID;
		staffName = newName;
		staffTillID = -1;
		staffServing = false;
		staffEnergy = 100;
		staffActive = false;
	}
	
}
