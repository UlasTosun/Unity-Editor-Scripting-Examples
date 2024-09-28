using System.Collections.Generic;
using UnityEngine;



public class Path : MonoBehaviour {

    public enum PathType {
        Loop,
        Linear
    }



    public List<Vector3> Points = new();
    [SerializeField, HideInInspector] private PathType _pathType = PathType.Linear;
    [SerializeField, HideInInspector] private int _repeatCount = 1;



    public void ClearAll() {
        Points.Clear();
    }



}
