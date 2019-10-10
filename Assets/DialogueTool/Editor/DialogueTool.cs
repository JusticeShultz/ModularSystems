using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RPGDialogueSystem
{
    public class DialogueTool : EditorWindow
    {
        [SerializeField] public Object scriptableChatData;
        private Vector2 scrollPos = new Vector2(0, 0);

        [MenuItem("Window/Dialogue/Configure")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(DialogueTool));
        }

        void OnGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

            bool allHasScript = true;

            foreach (GameObject gObject in Selection.gameObjects)
            {
                if (!gObject.GetComponent<DialogueManager>())
                {
                    allHasScript = false;
                }
            }

            if (!allHasScript || Selection.gameObjects.Length <= 0)
            {
                GUILayout.Label("A Dialogue Manager component must be on your", EditorStyles.largeLabel);
                GUILayout.Label("selected object[s].", EditorStyles.largeLabel);

                if (GUILayout.Button("Add Dialogue Manager Component[s]"))
                {
                    if (Selection.gameObjects.Length <= 0)
                    {
                        Debug.LogError("[Dialogue Configuration Error] You must have something selected in order to add the Dialogue Manager component.");
                    }
                    else
                    {
                        foreach (GameObject gObject in Selection.gameObjects)
                        {
                            if (!gObject.GetComponent<DialogueManager>())
                            {
                                Debug.Log("[Dialogue Configuration] Dialogue Manager component added to " + gObject.name);
                                Undo.AddComponent<DialogueManager>(gObject);
                            }
                        }
                    }
                }
            }
            else
            {
                if (!scriptableChatData || scriptableChatData.GetType().Name != "ChatData")
                {
                    GUILayout.Label("Set the below field to a valid ChatData object.", EditorStyles.largeLabel);

                    scriptableChatData = EditorGUILayout.ObjectField(scriptableChatData, typeof(ChatData), true);

                    GUILayout.Space(30);
                    GUILayout.Label("To make a ChatData object, go to:", EditorStyles.largeLabel);
                    GUILayout.Label("Assets > Dialogue > Create Script", EditorStyles.largeLabel);
                }
                else
                {
                    EditorGUI.BeginChangeCheck();

                    scriptableChatData = EditorGUILayout.ObjectField(scriptableChatData, typeof(ChatData), true);

                    EditorGUI.BeginChangeCheck();

                    GUILayout.Space(5);

                    if (GUILayout.Button("Add new dialogue field"))
                    {
                        ((ChatData)scriptableChatData).Chats.Add("");
                        ((ChatData)scriptableChatData).Names.Add("");

                        EditorUtility.SetDirty(scriptableChatData);
                    }

                    if (!scriptableChatData || scriptableChatData.GetType().Name != "ChatData") return;
                    else for (int i = 0; i < ((ChatData)scriptableChatData).Names.Count; i++)
                        {
                            if (!scriptableChatData || scriptableChatData.GetType().Name != "ChatData") return;

                            GUILayout.Label("Chat Box #" + (i + 1), EditorStyles.largeLabel);

                            GUILayout.BeginHorizontal();

                            ((ChatData)scriptableChatData).Names[i] = GUILayout.TextField(((ChatData)scriptableChatData).Names[i]);

                            GUIStyle style = new GUIStyle();
                            style.stretchWidth = false;
                            style.fixedWidth = 35;

                            if (GUILayout.Button("X", style))
                            {
                                ((ChatData)scriptableChatData).Chats.Remove(((ChatData)scriptableChatData).Chats[i]);
                                ((ChatData)scriptableChatData).Names.Remove(((ChatData)scriptableChatData).Names[i]);
                                EditorUtility.SetDirty(scriptableChatData);
                                return;
                            }

                            GUILayout.EndHorizontal();
                            GUILayout.BeginVertical();

                            ((ChatData)scriptableChatData).Chats[i] = GUILayout.TextArea(((ChatData)scriptableChatData).Chats[i]);

                            GUILayout.EndVertical();
                        }

                    if (GUILayout.Button("Configure Dialogue Manager"))
                    {
                        foreach (GameObject gObject in Selection.gameObjects)
                        {
                            try
                            {
                                DialogueManager manager = gObject.GetComponent<DialogueManager>();

                                Undo.RecordObject(manager, "Configured settings");
                                manager.Names = ((ChatData)scriptableChatData).Names;
                                manager.Chats = ((ChatData)scriptableChatData).Chats;
                            }
                            catch
                            {
                                Debug.Log("Something went wrong, please try again!");
                            }
                        }
                    }

                    if (EditorGUI.EndChangeCheck())
                    {
                        Undo.RecordObject(scriptableChatData, "Modified values on the scr obj");
                        
                    }
                }
            }

            EditorGUILayout.EndScrollView();
        }
    }
}