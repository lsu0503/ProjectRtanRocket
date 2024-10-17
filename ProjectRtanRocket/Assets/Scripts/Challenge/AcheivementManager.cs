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
        if (challengeAchivedOrder >= achievements.Length) return;

        if (height >= achievements[challengeAchivedOrder].threshold)
        {
            achievementView.UnlockAchievement(challengeAchivedOrder);
            challengeAchivedOrder++;
        }
    }
}