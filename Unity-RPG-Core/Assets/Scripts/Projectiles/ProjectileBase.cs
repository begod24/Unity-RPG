using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected float lifeTime = 5f;
    private float timer;

    private void OnEnable() { timer=0f; }
    private void Update()
    {
        Move();
        if((timer+=Time.deltaTime)>=lifeTime)
            gameObject.SetActive(false);
    }
    protected abstract void Move();
}