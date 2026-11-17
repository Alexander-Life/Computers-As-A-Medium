using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 10;
    public GameObject enemyDeathMessageUI;

    private bool isEnemyDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword"))
        {
            enemyHealth -= 10;
        }
    }

    void Death()
    {
        if (enemyHealth <= 0 && isEnemyDead == false)
        {
            isEnemyDead = true;
            StartCoroutine(EnemyDeath());
        }

        IEnumerator EnemyDeath()
        {
            enemyDeathMessageUI.SetActive(true);
            yield return new WaitForSeconds(3f);
            enemyDeathMessageUI.SetActive(false);
            Destroy(gameObject);
        }

       

    }
}
