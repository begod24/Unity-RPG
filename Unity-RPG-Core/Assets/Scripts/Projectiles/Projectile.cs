using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 5f;

    private float timer;

    private void OnEnable()
    {
        timer = 0f;
    }

    private void Update()
    {
        Move();

        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            gameObject.SetActive(false); 
        }
    }

    protected abstract void Move();
}
