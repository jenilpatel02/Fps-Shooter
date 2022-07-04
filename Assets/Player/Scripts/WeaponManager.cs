using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    public Camera shootpoint;
    public float gunrange = 100f;
    public float damage = 25f;
    public Animator playerAnimator;
    public ParticleSystem muzzleFlash;
    public GameObject hitParticles;

    public AudioClip gunShot;
    public AudioSource audioSource;

    
    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (playerAnimator.GetBool("isShooting")) {
            playerAnimator.SetBool("isShooting", false);
        }

        if (Input.GetButtonDown("Fire1")) {
            Shoot();

        }
    }
    
    //Shoot method
    void Shoot() {
        muzzleFlash.Play();
        audioSource.PlayOneShot(gunShot);
        playerAnimator.SetBool("isShooting", true);

        // used to damage enemy
        RaycastHit hit;

        if(Physics.Raycast(shootpoint.transform.position, shootpoint.transform.forward, out hit, gunrange)){
            Debug.Log("hit");
            if(hit.transform.tag == "Enemy")
            {
                EnemyManager enemyhealthscript = hit.transform.GetComponent<EnemyManager>();
                enemyhealthscript.health = damage;
                Instantiate(hitParticles, hit.point, Quaternion.LookRotation(hit.normal));
                Debug.Log("hitEnemy");
               
            }
            else
            {
                Debug.Log("something else");
            }
           
        }

    }
}
