using UnityEngine;



public class HeaderTest : MonoBehaviour {
    
    [Header("Test 1")]
    [SerializeField] private int _test1;

    [Header("Test 2")]
    [SerializeField] private int _test2;

    [Header("Test 3", "Red", "Yellow", 24, TextAnchor.MiddleCenter, FontStyle.Bold)]
    [SerializeField] private int _test3;

    [Header("Test 4", "Black", "Green", 64, TextAnchor.MiddleRight, FontStyle.Bold)]
    [SerializeField] private int _test4;


}
