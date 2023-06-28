using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private List<Weapon> _weapons;

    private Weapon _currentWeapon;
    private int _currentNumberWeapon;
    private int _currentHealth;
    private Animator _animator;

    public int Money { get;private set; }

    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int,int> HealthChanged;

    private const string Shoot = "Shoot";
    private const string Reload = "Reload";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentHealth = _health;
        ChangedWeapon(_weapons[_currentNumberWeapon]);
        _currentWeapon.Reload();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            _currentWeapon.Shoot(_shootPoint);
            _animator.Play(Shoot);
            StartCoroutine(Create());
        }
    }

    private IEnumerator Create()
    {
        yield return new WaitForSeconds(2f);
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0) 
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        _weapons.Add(weapon);
    }

    public void NextWeapon()
    {
        if (_currentNumberWeapon == _weapons.Count - 1)
            _currentNumberWeapon = 0;
        else
            _currentNumberWeapon++;

        ChangedWeapon(_weapons[_currentNumberWeapon]);
    }

    public void PreviosWeapon()
    {
        if (_currentNumberWeapon == 0)
            _currentNumberWeapon = _weapons.Count - 1;
        else
            _currentNumberWeapon--;

        ChangedWeapon(_weapons[_currentNumberWeapon]);
    }

    private void ChangedWeapon(Weapon weapon) 
    {
        _currentWeapon = weapon;
    }
}
