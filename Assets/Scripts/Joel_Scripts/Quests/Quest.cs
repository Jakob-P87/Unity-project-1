using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest {

    [SerializeField]
    public string m_questName;
    [SerializeField]
    public string m_questDesc;
    [SerializeField]
    public string m_questTask;

    [SerializeField]
    public int m_task1;
    [SerializeField]
    public int m_taskMax1;

    [SerializeField]
    public int m_questReward;

    [SerializeField]
    public bool m_completed;

    public bool m_questDelivered = false;

    public int m_quest_ID;

    public CharacterType m_mobType;
    public CharacterType m_questGiver;

    public bool PendingTurnIn()
    {
        if (m_completed && !m_questDelivered)
            return true;
        return false;
    }

    //Standard Kill/Gather 1 type of object
    //string questName, string questDesc, string questTask, int task1, int taskMax1, bool completed, int questReward
    public Quest(string questName, string questDesc, string questTask, int task1, int taskMax1, bool completed, int questReward, int quest_ID, CharacterType mobType, CharacterType questGiver)
    {

        m_questName = questName;
        m_questDesc = questDesc;
        m_questTask = questTask;

        m_task1 = task1;
        m_taskMax1 = taskMax1;

        m_questReward = questReward;

        m_completed = completed;

        m_quest_ID = quest_ID;

        m_mobType = mobType;
        m_questGiver = questGiver;
    }

    public Quest()
    {
        //empty
    }

}
