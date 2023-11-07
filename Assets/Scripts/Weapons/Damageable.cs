using UnityEngine;
using UnityEngine.Events; 

public class Damageable : MonoBehaviour
{
    [SerializeField] private int hp = 100;
    [SerializeField] private int maxHP = 100;
    [SerializeField] private UnityEvent<int, int> OnHPUpdated;
    

    public void TakeDamages(int _damages)
    {
        hp -= _damages; 
        OnHPUpdated?.Invoke(hp, maxHP);
        if (hp <= 0) Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
