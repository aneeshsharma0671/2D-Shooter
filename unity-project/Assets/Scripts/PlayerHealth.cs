// This script handles detecting collisions with traps and telling the Game Manager
// when the player dies

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	//public GameObject deathVFXPrefab;	//The visual effects for player death

	bool isAlive = true;				//Stores the player's "alive" state
	int trapsLayer;                     //The layer the traps are on
	int enemyLayer;
	[SerializeField]
	int playerHealth;


	void Start()
	{
		//Get the integer representation of the "Traps" layer
		trapsLayer = LayerMask.NameToLayer("Traps");
		enemyLayer = LayerMask.NameToLayer("Enemy");
	}

    private void Update()
    {
		if (playerHealth <= 0)
		{
			if (isAlive)
			{
				isAlive = false;
				GameManager.PlayerDied();
			}
		}
    }

	public void TakeDamage(int damage)
	{
		playerHealth -= damage;
		Debug.Log("Player got touch damage");
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		//If the collided object isn't on the Traps layer OR if the player isn't currently
		//alive, exit. This is more efficient than string comparisons using Tags
		if (collision.gameObject.layer != trapsLayer || !isAlive)
			return;

		//Trap was hit, so set the player's alive state to false
		isAlive = false;

		//Instantiate the death particle effects prefab at player's location
		//Instantiate(deathVFXPrefab, transform.position, transform.rotation);

		//Disable player game object
		gameObject.SetActive(false);

		//Tell the Game Manager that the player died and tell the Audio Manager to play
		//the death audio
		GameManager.PlayerDied();
		//AudioManager.PlayDeathAudio();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.layer != enemyLayer || !isAlive)
			return;

		TakeDamage(collision.gameObject.GetComponentInParent<EnemyLifeBehaviour>().touchDamage);
	}
}
