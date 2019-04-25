using System;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace UnityEngine.Tilemaps
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Animated Tile", menuName = "Tiles/Animated Tile")]
    public class AnimatedTile : TileBase
    {
        public Sprite[] Sprites;
        public float m_MinSpeed = 1f;
        public float m_MaxSpeed = 1f;
        public float StartTime;
        public Tile.ColliderType Collider;

        public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
        {
            tileData.transform = Matrix4x4.identity;
            tileData.color = Color.white;
            if (Sprites != null && Sprites.Length > 0)
            {
                tileData.sprite = Sprites[Sprites.Length - 1];
                tileData.colliderType = Collider;
            }
        }

        public override bool GetTileAnimationData(Vector3Int location, ITilemap tileMap, ref TileAnimationData tileAnimationData)
        {
            if (Sprites.Length > 0)
            {
                tileAnimationData.animatedSprites = Sprites;
                tileAnimationData.animationSpeed = Random.Range(m_MinSpeed, m_MaxSpeed);
                tileAnimationData.animationStartTime = StartTime;
                return true;
            }
            return false;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(AnimatedTile))]
    public class AnimatedTileEditor : Editor
    {
        private AnimatedTile tile { get { return (target as AnimatedTile); } }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            int count = EditorGUILayout.DelayedIntField("Number of Animated Sprites", tile.Sprites != null ? tile.Sprites.Length : 0);
            if (count < 0)
                count = 0;

            if (tile.Sprites == null || tile.Sprites.Length != count)
            {
                Array.Resize<Sprite>(ref tile.Sprites, count);
            }

            if (count == 0)
                return;

            EditorGUILayout.LabelField("Place sprites shown based on the order of animation.");
            EditorGUILayout.Space();

            for (int i = 0; i < count; i++)
            {
                tile.Sprites[i] = (Sprite)EditorGUILayout.ObjectField("Sprite " + (i + 1), tile.Sprites[i], typeof(Sprite), false, null);
            }

            float minSpeed = EditorGUILayout.FloatField("Minimum Speed", tile.m_MinSpeed);
            float maxSpeed = EditorGUILayout.FloatField("Maximum Speed", tile.m_MaxSpeed);
            if (minSpeed < 0.0f)
                minSpeed = 0.0f;

            if (maxSpeed < 0.0f)
                maxSpeed = 0.0f;

            if (maxSpeed < minSpeed)
                maxSpeed = minSpeed;

            tile.m_MinSpeed = minSpeed;
            tile.m_MaxSpeed = maxSpeed;

            tile.StartTime = EditorGUILayout.FloatField("Start Time", tile.StartTime);
            tile.Collider = (Tile.ColliderType)EditorGUILayout.EnumPopup("Collider Type", tile.Collider);
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(tile);
        }
    }
#endif
}