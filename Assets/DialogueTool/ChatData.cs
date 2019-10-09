using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGDialogueSystem
{
    [CreateAssetMenu(fileName = "ChatData", menuName = "Dialogue/Create Script", order = 1)]
    [System.Serializable]
    public class ChatData : ScriptableObject
    {
        [HideInInspector] public List<string> Names = new List<string>();
        [HideInInspector] public List<string> Chats = new List<string>();
    }
}