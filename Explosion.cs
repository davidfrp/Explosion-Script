using System;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public LayerMask DestructibleMask;
    public LayerMask ObstacleMask;
    public float BlastRadius = 5;
    public float Damage = 100;
    public AnimationCurve DamageFalloff = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));
    public float ExplosionForce;
    public GameObject[] DeathGameObjects;

    private float _curveLength;

    void Start()
    {
        _curveLength = DamageFalloff[DamageFalloff.length - 1].time;
    }

    public void Explode()
    {
        Collider[] collidersNear = Physics.OverlapSphere(transform.position, BlastRadius, DestructibleMask);
        foreach (Collider collider in collidersNear)
        {
            Transform target = collider.transform;
            Vector3 direction = (target.position - transform.position).normalized;
            
            if (!Physics.Raycast(transform.position, direction, BlastRadius, ObstacleMask))
            {
                float damageMultiplier = DamageFalloff.Evaluate(_curveLength / direction.magnitude);
                target.SendMessage("InflictDamage", Damage * damageMultiplier, SendMessageOptions.DontRequireReceiver);

                Rigidbody targetRigidbody = target.GetComponent<Rigidbody>();
                if (targetRigidbody != null)
                {
                    targetRigidbody.AddExplosionForce(ExplosionForce, transform.position, BlastRadius, 1, ForceMode.Impulse);
                }
            }
        }

        if (DeathGameObjects.Length > 0)
            Array.ForEach(DeathGameObjects, prefab => { Instantiate(prefab, transform.position, transform.rotation); });

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255, 0, 0, 0.1f);
        Gizmos.DrawSphere(transform.position, BlastRadius);
    }
}
