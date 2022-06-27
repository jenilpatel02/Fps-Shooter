
using UnityEngine;

public class AimScript : MonoBehaviour
{
    public float Damage = 10f;
    public float Range = 100f;

    public Camera aimcam;
    public float shootingrate = 15f;
    public ParticleSystem frontflash;
    public GameObject ImpactEffect;
    public float ImpactForce;

    private float nexttimeforshoot = 0f;

    void aim()
    {
        frontflash.Play();
        RaycastHit hit;
        if (Physics.Raycast(aimcam.transform.position, aimcam.transform.forward, out hit, Range))
        {
            Debug.Log(hit.transform.name);

            EnemyScript aim = hit.transform.GetComponent<EnemyScript>();
            if (aim != null)
            {
                aim.takedamage(Damage);
            }
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }
           GameObject impactgo = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactgo, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire1")&& Time.time >= nexttimeforshoot)
        {
            nexttimeforshoot = Time.time + 1f / shootingrate;
            aim();
        }
    }
}
