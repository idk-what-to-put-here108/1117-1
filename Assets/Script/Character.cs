using UnityEngine;

public class Character : MonoBehaviour
{
    //private variables
    [Header("Character Stats")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

   

    private bool isDead = false;

    //public props
    public float MoveSpeed
    {
        get { return moveSpeed; }
    }

    public bool IsDead
    {
        get { return isDead; }
    }

    protected int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    protected virtual void Awake()
    {
        Debug.Log("Awake in Character.CS");
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (IsDead)
        {
            return;
        }

        CurrentHealth -= amount;
        Debug.Log($"{gameObject.name} HP is now {CurrentHealth}");

        if (CurrentHealth <= 0)
        {
            Die();
        }

    }

    protected void Die()
    {
        isDead = true;
        Debug.Log($"{gameObject.name} is dead");
    }


}
