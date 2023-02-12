using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
	public int maxHealth = 100;
	public float currentHealth;
    public Animator anim;
    public GameObject ironMan;

    public HealthBar healthBar;
    public bool isironMan;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
        	TakeDamage(10);
        }
    }

    public void TakeDamage(float damage)
    {
    	currentHealth -= damage;
        anim.SetBool("isHit", true);
        StartCoroutine(HitTime());
        if (currentHealth < 0)
        {
            anim.SetBool("isDead", true);
            StartCoroutine(DieTime());
        }
        healthBar.SetHealth(currentHealth);
    }

    IEnumerator HitTime()
    {
        yield return new WaitForSeconds(0.20f);
        anim.SetBool("isHit", false);
    }

    IEnumerator DieTime()
    {
        yield return new WaitForSeconds(0.50f);
        anim.SetBool("isHit", false);
        anim.SetBool("isDead", false);
        if (isironMan)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
