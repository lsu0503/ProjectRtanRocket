using System;
using UnityEngine;

public class EnergySystemC : MonoBehaviour
{
    public event Action<float> OnEnergyChanged;
    public float MaxFuel { get; private set; } = 10f;
    public float Fuel { get; private set; } = 10f;
    
    public bool UseEnergy(float amount)
    {
        if (Fuel < amount) return false;
        Fuel -= amount;
        return true;
    }

    private void Update()
    {
        Fuel += Time.deltaTime;

        // 개인 추가 코드 [시작]
        if (Fuel > MaxFuel)
            Fuel = MaxFuel;
        // 개인 추가 코드 [종료]

        OnEnergyChanged?.Invoke(Fuel);
    }
}