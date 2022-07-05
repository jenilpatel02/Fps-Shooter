using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{

    public GameObject player;
    public Animator enemyAnimator;
    public float health = 100f;
    public float deducthealth = 20f;
    public NavMeshAgent navigation;
    public GameObject goon;
    public AudioSource audioSource;
    public AudioClip[] enemysound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        navigation = GetComponent<NavMeshAgent>();

      
    }

    
    
  

    // Update is called once per frame
    void Update()
    {
        //run towards player
        GetComponent<NavMeshAgent>().destination = player.transform.position;

        //enemy running animation
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            enemyAnimator.SetBool("isRunning", true);
        }
        else
        {
            enemyAnimator.SetBool("isRunning", false);
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
            Destroy(gameObject, 10f);
            Destroy(GetComponent<NavMeshAgent>());
            Destroy(GetComponent<EnemyManager>());
            Destroy(GetComponent<CapsuleCollider>());
        }
    }
}
