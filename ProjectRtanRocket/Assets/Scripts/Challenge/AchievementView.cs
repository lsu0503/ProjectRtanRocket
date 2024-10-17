using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementView : MonoBehaviour
{
    [SerializeField] private GameObject achievementSlotPrefab;  // 업적 슬롯 프리팹
    private Dictionary<int, AchievementSlot> achievementSlots = new();

    // 개인 추가 사항
    [SerializeField] private Transform contentTransform;
    private int challengeAchivedOrder = 0;

    public void CreateAchievementSlots(AchievementSO[] achievements)
    {
        // achievement 데이터에 따라 슬롯을 생성함
        for (int i = 0; i < achievements.Length; i++)
        {
            GameObject tempObj = Instantiate(achievementSlotPrefab, contentTransform);
            AchievementSlot tempSlot = tempObj.GetComponent<AchievementSlot>();
            tempSlot.Init(achievements[i]);
            achievementSlots.Add(i, tempSlot);
        }
    }

    // 기존 코드와의 호환성을 위해서 인수의 이름을 임의로 변경하였습니다.
    public void UnlockAchievement(int order)
    {
        // UI 반영 로직
        achievementSlots[order].MarkAsChecked();
    }
}