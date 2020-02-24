using UnityEngine;

//클래스는 변수와 함수가 있다.
//인터페이스는 변수가 없고 함수만 있다.
public interface IDamageable
{
    void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal);
}
