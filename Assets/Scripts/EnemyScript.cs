
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float Health = 50f;

    public void takedamage(float amount)
    {
        Health -= amount;
        if(Health <= 0f)
        {
            Dead();
        }
    }
    void Dead()
    {
        Destroy(gameObject);
    }
}
