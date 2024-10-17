using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    private int currentThresholdIndex;

    [SerializeField] private AchievementSO[] achievements;
    [SerializeField] private AchievementView achievementView;

    // 개인 추가 내용
    [SerializeField] private RocketMovementC movementC;
    private float[] challengeList = new float[] { 100.0f, 200.0f, 500.0f, 800.0f, 1200.0f, 2000.0f};
    private int challengeAchivedOrder = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        achievementView.CreateAchievementSlots(achievements);  // UI 생성

        // 개인 추가 내용
        RocketMovementC.OnHighScoreChanged += CheckAchievement;
    }

    // 최고 높이를 달성했을 때 업적 달성 판단, 이벤트 기반으로 설계할 것
    private void CheckAchievement(float height)
    {
        if (challengeAchivedOrder >= challengeList.Length) return;

        if (height >= challengeList[challengeAchivedOrder])
        {
            Debug.Log($"You Leached {(int)challengeList[challengeAchivedOrder]}m!");
            challengeAchivedOrder++;
        }
    }
}