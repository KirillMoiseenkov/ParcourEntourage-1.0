using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTester : MonoBehaviour
{
    public Data data_shadow;
    public Data.point point = new Data.point();
    public MyDir myDir = new MyDir();
    private void Awake()
    {
      //  myDir.InitKV();
        point.x = 1;point.y = 2;point.z = 3;
        data_shadow = new Data(@"\Profile\", "shadow.dat");
        if (data_shadow.IsExist()) data_shadow.RewriteShadow();
        data_shadow.shadow = data_shadow.ReadShadow();
        myDir.Push_Element_MyDir(point,"keke");
        data_shadow.shadow.ListOfShadow = myDir.kv;
        data_shadow.RewriteShadow();
        data_shadow.shadow = data_shadow.ReadShadow();
        myDir.kv = data_shadow.shadow.ListOfShadow;
        print(myDir.Return_Value_MyDir());
    }
}
