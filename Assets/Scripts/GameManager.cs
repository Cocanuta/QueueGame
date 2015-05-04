using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public List<Till> tills = new List<Till>();
	public List<Staff> employees = new List<Staff>();
	public List<Customer> customers = new List<Customer>();

	public GameObject customerPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//GENERAL UTILITIES------------------------------------------------------------------

	public int GetNewID<inputType>(List<inputType> list)
	{
		int id = 0;
		if(list.Count >= 0)
		{
			id = list.Count + 1;
		}
		return id;
	}

	public void Error(int errorID)
	{
		string errorString = "";
		switch(errorID)
		{
		case 0:
			errorString = "Error: No 'Till' found.";
			break;
		case 1:
			errorString = "Error: No Staff attached to Till.";
			break;
		case 2:
			errorString = "Error: Till occupied.";
			break;
		case 3:
			errorString = "Error: No 'Staff' found.";
			break;
		}
		Debug.Log (errorString);
	}

	//TILL FUNCTIONS---------------------------------------------------------------------

	public void AddTill()
	{
		int id = GetNewID (tills);
		Vector3 position = new Vector3 (id, 0, 0);
		tills.Add (new Till (id,position));
	}

	public Till GetTillFromID(int id)
	{
		foreach (Till t in tills) {
			if(t.tillID == id)
			{
				return t;
			}
		}
		Error (0);
		return null;
	}
	public bool CheckTillOccupied(Till till)
	{
		if(till.tillStaffID != -1)
		{
			return true;
		}
		return false;
	}

	public void RemoveStaffFromTill(Till till)
	{
		if(till.tillStaffID != -1)
		{
			foreach(Staff s in employees)
			{
				if(s.staffID == till.tillStaffID)
				{
					if(s.staffTillID == till.tillID)
					{
						s.staffTillID = -1;
						till.tillStaffID = -1;
					}
				}
			}
		}
		else
		{
			Error (1);
		}

	}

	public Till GetRandomTill()
	{
		return tills[Random.Range (0, tills.Count)];
	}

	public int GetEndOfQueue(Till till)
	{
		int end = 0;
		foreach(Customer c in customers)
		{
			if(c.customerTargetTill == till.tillID)
			{
				if(c.customerPlaceInLine >= end)
				{
					end = c.customerPlaceInLine + 1;
				}
			}
		}
		return end;
	}
	
	//STAFF FUNCTIONS--------------------------------------------------------------------

	public void AddStaff(string name)
	{
		int id = GetNewID (employees);

		employees.Add (new Staff (id, name));
	}

	public Till GetStaffFromID(int id)
	{
		foreach(Till t in tills)
		{
			if(t.tillID == id)
			{
				return t;
			}
		}
		Error (3);
		return null;
	}

	public bool CheckStaffOnTill(Staff staff)
	{
		if(staff.staffTillID != -1)
		{
			return true;
		}
		return false;
	}

	public void AddStaffToTill(Staff staff, Till till)
	{
		if(!CheckTillOccupied(till))
		{
			if(!CheckStaffOnTill(staff))
			{
				staff.staffTillID = till.tillID;
				till.tillStaffID = staff.staffID;
			}
		}
		else
		{
			Error (2);
		}
	}

	public void AddEnergy(Staff staff)
	{
		if(staff.staffEnergy < 100)
		{
			staff.staffEnergy += 0.2f;
		}
	}

	public void SubtractEnergy(Staff staff)
	{
		if(staff.staffEnergy > 0)
		{
			staff.staffEnergy -= 0.2f;
		}
	}

	public void SetMaxEnergy(Staff staff)
	{
		staff.staffEnergy = 100f;
	}

	//CUSTOMER FUNCTIONS------------------------------------------------------------------

	public void SpawnCustomer()
	{
		int id = GetNewID (customers);
		string name = "test";
		Till randomTill = GetRandomTill ();
		Vector3 target = randomTill.tillPosition;
		int placeInLine = GetEndOfQueue (randomTill);
		customers.Add (new Customer (id, name, 5, target, randomTill.tillID, placeInLine));
	}
	
}
