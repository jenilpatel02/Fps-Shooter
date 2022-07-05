using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class EnemyManager : MonoBehaviour
{

    public GameObject player;
    public Animator enemyAnimator;
    public float health = 100f;
    public float deducthealth = 20f;
    public AudioSource audioSource;
    public AudioClip[] enemysound;

   
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");

    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        //enemy running animation
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 3)
        {
            enemyAnimator.SetBool("isRunning", true);
            enemyAnimator.SetBool("isAttacking", false);
        }
        else
        {
            enemyAnimator.SetBool("isRunning", false);
            enemyAnimator.SetBool("isAttacking", true);
            player.GetComponent<PlayerManager>().DeductHealth(5);
  
        }

        if (!audioSource.isPlaying)
        {
            audioSource.clip = enemysound[Random.Range(0, enemysound.Length)];
            audioSource.Play();
        }
    }
    public void Hit(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            enemyAnimator.SetTrigger("isDead");
            Destroy(gameObject, 5f);
            Destroy(GetComponent<NavMeshAgent>());
            Destroy(GetComponent<EnemyManager>());
            Destroy(GetComponent<CapsuleCollider>());
        }
    }
    
}

   