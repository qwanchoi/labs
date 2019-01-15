using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyFilter : MonoBehaviour {

    public List<Transform> myList;
    public Transform a;
    public Transform b;
    public Transform c;

    void Start () {
        OverlabFiltedAdd(ref myList, ref a);
        
        myList.Add(a);
        myList.Add(a);
        myList.Add(a);

        TransformsNameViwer(myList);
    }

    private void OverlabFiltedAdd<T>(ref List<T> _list, ref T _value)
    {
        foreach (var v in _list)
        {
            if ( _value.Equals( v ) )
            {
                return;
            }
        }
        _list.Add(_value);
    }

    private void TransformsNameViwer(List<Transform> _list)
    {
        string temp = "";
        foreach(Transform v in _list)
        {
            temp = temp+v.name+"/";
        }

        print(temp);
    }


}
