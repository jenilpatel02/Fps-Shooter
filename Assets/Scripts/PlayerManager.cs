using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour {
    public float health = 100;
    public TextMeshProUGUI healthNum;
    public screenchanger screenManager;
    public GameObject playerCamera;
    public CanvasGroup hurtPanel;
    private float shakeTime;
    private float shakeDuration;
    private Quaternion playerCameraOriginalRotation;

    public float timeBetweenTwoAttacks;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        playerCameraOriginalRotation = playerCamera.transform.localRotation;
        timeBetweenTwoAttacks = 2;
    }

    // Update is called once per frame
    void Update() 
    {
        
        if(hurtPanel.alpha > 0) 
        {
            hurtPanel.alpha -= Time.deltaTime;
        }
        if (shakeTime < shakeDuration) 
        {
            shakeTime += Time.deltaTime;
            CameraShake();
        } 
        else if(playerCamera.transform.localRotation != playerCameraOriginalRotation)
        {
            playerCamera.transform.localRotation = playerCameraOriginalRotation;
        }
    }

    /*public void Hit(float damage)
    {
        health -= damage;
        // healthNum.text = health.ToString() + " Health ";
        if (health <= 0)
        {
            screenManager.EndGame();
        }
        else
        {
            shakeTime = 0;
            shakeDuration = .2f;
            hurtPanel.alpha = .7f;
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<EnemyManager>()!=null)
        {
            
        }
    }

    public void DeductHealth(int amount)
    {
        timeBetweenTwoAttacks -= Time.deltaTime;
        if(timeBetweenTwoAttacks<=0)
        {
            health -= 10f;
            healthNum.text = "HP:" +health.ToString();
            timeBetweenTwoAttacks = 3;
            if (health <= 0)
            {
                screenManager.EndGame();
            }
            else
            {
                shakeTime = 0;
                shakeDuration = .2f;
                hurtPanel.alpha = .7f;
            }
        }
    }

    public void CameraShake() 
    {
        playerCamera.transform.localRotation = Quaternion.Euler(Random.Range(-2, 2), 0, 0);
    }
}
