using System;
using UnityEngine;



[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
public class ShowFrequencyAttribute : PropertyAttribute {

    public readonly bool ShowUnit;



    public ShowFrequencyAttribute(bool showUnit = true) {
        ShowUnit = showUnit;
    }

    

}
