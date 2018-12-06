using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
	public int maxHitPoints = 100;
	private int currentHealth;
	
	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHitPoints;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(currentHealth <= 0)
		{
			Die();	
		}
	}
	
	//The character has been hurt by something so apply the damage.
	public void ApplyDamage(int amount)
	{
		currentHealth -= amount;
	}
	
	private void Die()
	{
		Destroy(gameObject);
	}
}
