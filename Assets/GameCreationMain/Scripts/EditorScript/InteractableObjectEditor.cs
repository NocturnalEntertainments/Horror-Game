using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InteractableObject))]
public class InteractableObjectEditor : Editor
{
    //This is an editor for the interactable object in that way it would be easily more readable in the inspector
    #region SerializedProperty
    SerializedProperty ObjectName;
    SerializedProperty objectType;
    SerializedProperty NoteToOpen;

   
    bool NoteTypeGroup;
    #endregion 

    private void OnEnable()
    {
        //We find the properties of each variables then assign them to another variables that we can use for later
        ObjectName = serializedObject.FindProperty("ObjectName");
        objectType = serializedObject.FindProperty("objectType"); 
        NoteToOpen = serializedObject.FindProperty("NoteToOpen");                
    }

    public override void OnInspectorGUI()
    {
        //We use the interactableObject script as a target in that way we could access it's properties
        InteractableObject _interactableObject = (InteractableObject)target;

        serializedObject.Update();
        
        //This is to show these variables in the inspector
        EditorGUILayout.PropertyField(ObjectName);
        EditorGUILayout.PropertyField(objectType);

        //This so that we can show the proper serializeField when the noteType has been picked in the inspector
        if (_interactableObject.objectType == ObjectType.NoteType)
        {
            EditorGUILayout.PropertyField(NoteToOpen);
        }

        //just copy and pase the code above if we want to add more types

        serializedObject.ApplyModifiedProperties();
    }
}
