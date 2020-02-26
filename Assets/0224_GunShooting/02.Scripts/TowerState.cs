using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerState : MonoBehaviour, IDamageable
{
    float hp = 100;

    public void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        hp -= damage;

        if (hp <= 0f)
        {
            this.gameObject.SetActive(false);
        }
    }
}
