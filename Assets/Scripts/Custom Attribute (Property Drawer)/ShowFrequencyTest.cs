using UnityEngine;



public class ShowFrequencyTest : MonoBehaviour {
    
    [SerializeField, ShowFrequency] private int _freqInt;
    [SerializeField, ShowFrequency] private float _freqFloat;
    [SerializeField, ShowFrequency] private double _freqDouble;
    [SerializeField, ShowFrequency] private long _freqLong;
    [SerializeField, ShowFrequency(false)] private float _freqNoUnit;
    [SerializeField] private int _noFreq;
    [SerializeField, ShowFrequency] private string _string;


}
