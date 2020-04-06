using UnityEngine;

namespace ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        void BottomStatusBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));

            GUILayout.Label("BottomStatus");

            GUILayout.EndHorizontal();
        }
    }
}
