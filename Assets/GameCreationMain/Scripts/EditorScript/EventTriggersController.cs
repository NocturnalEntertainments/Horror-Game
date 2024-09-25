using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventTriggers))]
public class EventTriggersController : Editor
{
    #region SerializedProperty
    SerializedProperty usesGameManager;
    SerializedProperty functionHasTimer;
    SerializedProperty FunctionDelay;
    SerializedProperty FunctionDuration;    
    SerializedProperty TriggerEnter;    
    SerializedProperty TriggerExit;    
    SerializedProperty MouseEnter;          
    SerializedProperty MouseExits;  
    SerializedProperty triggerType; // Ensure this property is declared
    #endregion 

    private void OnEnable()
    {
        // Find and assign all serialized properties
        usesGameManager = serializedObject.FindProperty("usesGameManager");
        functionHasTimer = serializedObject.FindProperty("functionHasTimer"); 
        FunctionDelay = serializedObject.FindProperty("FunctionDelay");     
        FunctionDuration = serializedObject.FindProperty("FunctionDuration");       
        TriggerEnter = serializedObject.FindProperty("TriggerEnter");       
        TriggerExit = serializedObject.FindProperty("TriggerExit");         
        MouseEnter = serializedObject.FindProperty("MouseEnter");                 
        MouseExits = serializedObject.FindProperty("MouseExits");  
        triggerType = serializedObject.FindProperty("triggerType"); // Make sure this property is initialized
    }    

    public override void OnInspectorGUI()
    {
        // Access the target EventTriggers script
        EventTriggers _eventTriggers = (EventTriggers)target;

        serializedObject.Update();

        // Draw the trigger type selector
        EditorGUILayout.PropertyField(triggerType);        

        // Show fields based on the selected trigger type
        switch (_eventTriggers.triggerType)
        {

            case TriggerType.ShowAllTypes:             
                EditorGUILayout.PropertyField(usesGameManager);

                // Show FunctionDelay and FunctionDuration only if functionHasTimer is true
                EditorGUILayout.LabelField("This Only Works for TriggerEnter", EditorStyles.boldLabel);                
                EditorGUILayout.PropertyField(functionHasTimer);
                if (functionHasTimer.boolValue) 
                {                 
                    EditorGUILayout.PropertyField(FunctionDelay);
                    EditorGUILayout.PropertyField(FunctionDuration);
                }
            
                EditorGUILayout.PropertyField(TriggerEnter);   
                EditorGUILayout.PropertyField(TriggerExit);    
                EditorGUILayout.PropertyField(MouseEnter);  
                EditorGUILayout.PropertyField(MouseExits);                                                              
                break; 

            case TriggerType.ShowPlayerEntersType:                 
                EditorGUILayout.PropertyField(usesGameManager);

                // Show FunctionDelay and FunctionDuration only if functionHasTimer is true
                EditorGUILayout.LabelField("This Only Works for TriggerEnter", EditorStyles.boldLabel);                    
                EditorGUILayout.PropertyField(functionHasTimer);
                if (functionHasTimer.boolValue) 
                {
                    EditorGUILayout.PropertyField(FunctionDelay);
                    EditorGUILayout.PropertyField(FunctionDuration);
                }

                EditorGUILayout.PropertyField(TriggerEnter);                   
                break;

            case TriggerType.ShowPlayerExitsType:
                EditorGUILayout.PropertyField(TriggerExit); 
                break;        

            case TriggerType.ShowPlayerLooksAtType:
                EditorGUILayout.PropertyField(MouseEnter); 
                break;       

            case TriggerType.ShowPlayerStopsLookingType:
                EditorGUILayout.PropertyField(MouseExits); 
                break;                   

            // Add additional case statements here if you have more types

            default:
                Debug.LogWarning("Unknown Trigger Type selected.");
                break;
        }

        // Apply modified properties to the serialized object
        serializedObject.ApplyModifiedProperties();
    }    
}
