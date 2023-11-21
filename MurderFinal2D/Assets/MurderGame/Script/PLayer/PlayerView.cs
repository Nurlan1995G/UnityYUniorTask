using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Health Health {get; private set;}

    private void Awake()
    {
        Health = new Health();
    }

    public void ApplyDamage(int damage) => Health.TakeDamage(damage);
}
