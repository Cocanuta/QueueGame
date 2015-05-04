using UnityEngine;
using System.Collections;

public class Till {

	public int tillID;
	public Vector3 tillPosition;
	public int tillStaffID;

	public Till(int newID, Vector3 newPosition)
	{
		tillID = newID;
		tillPosition = newPosition;
		tillStaffID = -1;
	}

}
