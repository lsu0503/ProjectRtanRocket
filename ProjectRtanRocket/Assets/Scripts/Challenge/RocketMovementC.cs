using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketMovementC : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private readonly float SPEED = 10f;
    private readonly float ROTATIONSPEED = 0.02f;

    private float highScore = -1;

    public static Action<float> OnHighScoreChanged;

    // 개인 추가 작성 변수
    private float rotation = 0;
    private float angle = 0.0f;
    private readonly float FUELUSE = 1.0f;

    private EnergySystemC energySystem;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();

        //개인 추가 내용
        energySystem = GetComponent<EnergySystemC>();
    }

    private void FixedUpdate()
    {
        // 개인 추가본
        ApplyRotation();

        //기존 내용
        if (!(highScore < transform.position.y)) return;
        highScore = transform.position.y;
        OnHighScoreChanged?.Invoke(highScore);
    }

    public void ApplyMovement(float inputX)
    {
        Rotate(inputX);
    }

    public void ApplyBoost()
    {
        // [개인 추가 사항] 연료를 소비하도록 수정하였습니다.
        if (energySystem.UseEnergy(FUELUSE))
        {
            // 기존 내용
            _rb2d.AddForce(transform.up * SPEED, ForceMode2D.Impulse);
        }
    }

    private void Rotate(float inputX)
    {
        // 움직임에 따라 회전을 바꿈 -> 회전을 바꾸고 그 방향으로 발사를 해야 그쪽으로 가겠죠?
        rotation = inputX;
    }

    private void ApplyRotation()
    {
        angle += rotation * ROTATIONSPEED;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}