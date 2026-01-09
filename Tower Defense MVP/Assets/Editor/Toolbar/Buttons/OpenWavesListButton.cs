using UnityEditor;
using UnityEngine;

namespace JGM.Editor
{
    public static class OpenWavesListButton
    {
        private const string WavesListPath = "Assets/Settings/Waves/Waves List.asset";

        [ToolbarButton(IconName = "VerticalLayoutGroup Icon", Tooltip = "Open Waves List", Order = -200)]
        public static void OnButtonClick()
        {
            var wavesList = AssetDatabase.LoadAssetAtPath<Object>(WavesListPath);

            if (wavesList == null)
            {
                Debug.LogError($"Waves List asset not found at path: {WavesListPath}");
                return;
            }

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = wavesList;
            EditorGUIUtility.PingObject(wavesList);
        }
    }
}