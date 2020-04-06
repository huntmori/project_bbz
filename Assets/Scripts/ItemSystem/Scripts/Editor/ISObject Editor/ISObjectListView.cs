using UnityEngine;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        Vector2 _scrollPos = Vector2.zero;
        int _listViewWidth = 200;

        void ListView()
        {
            _scrollPos = GUILayout.BeginScrollView(_scrollPos,"Box", GUILayout.ExpandHeight(true),GUILayout.Width(_listViewWidth));

            GUILayout.Label("ListView");

            GUILayout.EndScrollView();
        }
    }
}
