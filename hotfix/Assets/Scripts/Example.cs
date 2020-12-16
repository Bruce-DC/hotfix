using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class Example : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SingleLuaEnv.LuaEnv.DoString("print'Hello XLua!'");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        SingleLuaEnv.LuaEnv.Dispose();    
    }
}
