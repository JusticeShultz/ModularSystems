using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Modular implementation of an advanced loot drop system to allow the 
/// user to have more control over what items drop as well as the rate.
/// </summary>
public class LootDropSystem : MonoBehaviour
{
    [HideInInspector] public string Notes = "";

    //Inspector stuff
    public bool DisplayInputs = false;
    [HideInInspector] public bool DisplayNotes = false;
    [HideInInspector] public bool DisplayItemDrops = false;

    public float Common_MinDropValue;
    public float Common_MaxDropValue;
    [ReadOnlyField] public float CommonRate = 0;
    public float Uncommon_MinDropValue;
    public float Uncommon_MaxDropValue;
    [ReadOnlyField] public float UncommonRate = 0;
    public float Rare_MinDropValue;
    public float Rare_MaxDropValue;
    [ReadOnlyField] public float RareRate = 0;
    public float UltraRare_MinDropValue;
    public float UltraRare_MaxDropValue;
    [ReadOnlyField] public float UltraRareRate = 0;
    public float Legendary_MinDropValue;
    public float Legendary_MaxDropValue;
    [ReadOnlyField] public float LegendaryRate = 0;
    public float Champion_MinDropValue;
    public float Champion_MaxDropValue;
    [ReadOnlyField] public float ChampionRate = 0;
    public float Mythic_MinDropValue;
    public float Mythic_MaxDropValue;
    [ReadOnlyField] public float MythicRate = 0;

    public GameObject[] Commons;
    public GameObject[] Uncommons;
    public GameObject[] Rares;
    public GameObject[] UltraRares;
    public GameObject[] Legendaries;
    public GameObject[] Champions;
    public GameObject[] Mythics;

    public Vector3 SpawnOffset;
    public Vector3 SpawnRotationOffset;

    void OnDrawGizmos()
    {
        CommonRate = Common_MinDropValue / Common_MaxDropValue * 100;
        UncommonRate = Uncommon_MinDropValue / Uncommon_MaxDropValue * 100;
        RareRate = Rare_MinDropValue / Rare_MaxDropValue * 100;
        UltraRareRate = UltraRare_MinDropValue / UltraRare_MaxDropValue * 100;
        LegendaryRate = Legendary_MinDropValue / Legendary_MaxDropValue * 100;
        ChampionRate = Champion_MinDropValue / Champion_MaxDropValue * 100;
        MythicRate = Mythic_MinDropValue / Mythic_MaxDropValue * 100;
    }

    public void Drop()
    {
        float common_chance = Random.Range(0, Common_MaxDropValue);
        float uncommon_chance = Random.Range(0, Uncommon_MaxDropValue);
        float rare_chance = Random.Range(0, Rare_MaxDropValue);
        float ultrarare_chance = Random.Range(0, UltraRare_MaxDropValue);
        float legendary_chance = Random.Range(0, Legendary_MaxDropValue);
        float champion_chance = Random.Range(0, Champion_MaxDropValue);
        float mythic_chance = Random.Range(0, Mythic_MaxDropValue);

        if (common_chance <= Common_MinDropValue && Commons.Length > 0)
            Instantiate(Commons[Random.Range(0, Commons.Length)], transform.position + SpawnOffset, Quaternion.Euler(transform.rotation.eulerAngles + SpawnRotationOffset));
        if (uncommon_chance <= Uncommon_MinDropValue && Uncommons.Length > 0)
            Instantiate(Uncommons[Random.Range(0, Uncommons.Length)], transform.position + SpawnOffset, Quaternion.Euler(transform.rotation.eulerAngles + SpawnRotationOffset));
        if (rare_chance <= Rare_MinDropValue && Rares.Length > 0)
            Instantiate(Rares[Random.Range(0, Rares.Length)], transform.position + SpawnOffset, Quaternion.Euler(transform.rotation.eulerAngles + SpawnRotationOffset));
        if (ultrarare_chance <= UltraRare_MinDropValue && UltraRares.Length > 0)
            Instantiate(UltraRares[Random.Range(0, UltraRares.Length)], transform.position + SpawnOffset, Quaternion.Euler(transform.rotation.eulerAngles + SpawnRotationOffset));
        if (legendary_chance <= Legendary_MinDropValue && Legendaries.Length > 0)
            Instantiate(Legendaries[Random.Range(0, Legendaries.Length)], transform.position + SpawnOffset, Quaternion.Euler(transform.rotation.eulerAngles + SpawnRotationOffset));
        if (champion_chance <= Champion_MinDropValue && Champions.Length > 0)
            Instantiate(Champions[Random.Range(0, Champions.Length)], transform.position + SpawnOffset, Quaternion.Euler(transform.rotation.eulerAngles + SpawnRotationOffset));
        if (mythic_chance <= Mythic_MinDropValue && Mythics.Length > 0)
            Instantiate(Mythics[Random.Range(0, Mythics.Length)], transform.position + SpawnOffset, Quaternion.Euler(transform.rotation.eulerAngles + SpawnRotationOffset));
    }

    public void TestDrop()
    {
        float common_chance = Random.Range(0, Common_MaxDropValue);
        float uncommon_chance = Random.Range(0, Uncommon_MaxDropValue);
        float rare_chance = Random.Range(0, Rare_MaxDropValue);
        float ultrarare_chance = Random.Range(0, UltraRare_MaxDropValue);
        float legendary_chance = Random.Range(0, Legendary_MaxDropValue);
        float champion_chance = Random.Range(0, Champion_MaxDropValue);
        float mythic_chance = Random.Range(0, Mythic_MaxDropValue);

        if (common_chance <= Common_MinDropValue)
            print("Looted a common");
        if (uncommon_chance <= Uncommon_MinDropValue)
            print("Looted a uncommon");
        if (rare_chance <= Rare_MinDropValue)
            print("Looted a rare");
        if (ultrarare_chance <= UltraRare_MinDropValue)
            print("Looted a ultra rare");
        if (legendary_chance <= Legendary_MinDropValue)
            print("Looted a legendary");
        if (champion_chance <= Champion_MinDropValue)
            print("Looted a champion");
        if (mythic_chance <= Mythic_MinDropValue)
            print("Looted a mythic");
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(LootDropSystem))]
public class LootDropSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LootDropSystem system = (LootDropSystem)target;
        EditorGUI.BeginChangeCheck();

        if (system.DisplayInputs)
        {
            system.DisplayInputs = GUILayout.Toggle(system.DisplayInputs, "Display Input Values");
            DrawDefaultInspector();

            if (GUILayout.Button("Test Drop"))
                system.TestDrop();
        }
        else
        {
            GUILayout.BeginHorizontal();
            bool DisplayInputs = GUILayout.Toggle(system.DisplayInputs, "Display Input Values");
            bool DisplayNotes = GUILayout.Toggle(system.DisplayNotes, "Display Notes");
            bool DisplayItemDrops = GUILayout.Toggle(system.DisplayItemDrops, "Display Item Drops");
            GUILayout.EndHorizontal();

            GUILayout.BeginVertical();

            string notes = system.Notes;

            if (system.DisplayNotes)
                notes = GUILayout.TextArea(system.Notes);

            GUILayout.EndVertical();

            GUILayout.Space(5);

            GUILayout.Label("Common Drop Rate: " + (system.Common_MinDropValue / system.Common_MaxDropValue * 100) + "%");
            GUILayout.Label("Uncommon Drop Rate: " + (system.Uncommon_MinDropValue / system.Uncommon_MaxDropValue * 100) + "%");
            GUILayout.Label("Rare Drop Rate: " + (system.Rare_MinDropValue / system.Rare_MaxDropValue * 100) + "%");
            GUILayout.Label("Ultra Rare Drop Rate: " + (system.UltraRare_MinDropValue / system.UltraRare_MaxDropValue * 100) + "%");
            GUILayout.Label("Legendary Drop Rate: " + (system.Legendary_MinDropValue / system.Legendary_MaxDropValue * 100) + "%");
            GUILayout.Label("Champion Drop Rate: " + (system.Champion_MinDropValue / system.Champion_MaxDropValue * 100) + "%");
            GUILayout.Label("Mythic Drop Rate: " + (system.Mythic_MinDropValue / system.Mythic_MaxDropValue * 100) + "%");

            GUILayout.Space(15);

            serializedObject.Update();

            if (DisplayItemDrops)
            {
                SerializedProperty myIterator = serializedObject.FindProperty("Commons");

                while (true)
                {
                    Rect myRect = GUILayoutUtility.GetRect(0f, 16f);

                    bool showChildren = EditorGUI.PropertyField(myRect, myIterator);

                    serializedObject.ApplyModifiedProperties();

                    if (!myIterator.NextVisible(showChildren))
                        break;
                }
            }

            if (GUILayout.Button("Test Drop"))
                system.TestDrop();

            if (GUILayout.Button("Do Drop (Playmode Only)"))
            {
                if (EditorApplication.isPlaying) system.Drop();
                else Debug.LogWarning("Tried to drop an item but you were not in playmode.");
            }

            if (GUILayout.Button("Do Drop x5(Playmode Only)"))
            {
                if (EditorApplication.isPlaying) for(int i = 0; i < 5; i++) system.Drop();
                else Debug.LogWarning("Tried to drop an item but you were not in playmode.");
            }

            if (GUILayout.Button("Do Drop x10(Playmode Only)"))
            {
                if (EditorApplication.isPlaying) for (int i = 0; i < 10; i++) system.Drop();
                else Debug.LogWarning("Tried to drop an item but you were not in playmode.");
            }

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Modified the loot drop script");
                system.DisplayInputs = DisplayInputs;
                system.DisplayNotes = DisplayNotes;
                system.Notes = notes;
                system.DisplayItemDrops = DisplayItemDrops;
            }
        }
    }
}
#endif