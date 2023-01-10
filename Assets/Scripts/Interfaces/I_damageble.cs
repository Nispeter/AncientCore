using UnityEngine;

public interface I_damageble
{
    public float Health{ set ; get ; }

    public void TakeDamage(float damage);

    public void OnHit(float damage, Vector2 knockBack);

    public void OnHit(float damage);
}