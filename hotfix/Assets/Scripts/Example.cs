using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class Example : MonoBehaviour
{
    LuaEnv _luaEnv;

    // Start is called before the first frame update
    void Start()
    {
        _luaEnv = new LuaEnv();
        _luaEnv.DoString("print'Hello XLua!'");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        _luaEnv.Dispose();    
    }
}
