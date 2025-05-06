using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    [SerializeField] private float lifeTime = 5f;

    protected virtual void OnEnable()
    {
        Invoke(nameof(Disable), lifeTime);
    }

    protected virtual void Update()
    {
        Move();
    }

    protected abstract void Move();

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}