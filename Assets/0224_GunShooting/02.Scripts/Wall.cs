using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IDamageable
{
    float hp = 100;

    public void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        hp -= damage;

        if (hp <= 0f)
        {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
    
}
