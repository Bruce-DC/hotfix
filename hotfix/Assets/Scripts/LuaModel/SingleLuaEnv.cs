using UnityEngine;
using XLua;

public class SingleLuaEnv : MonoBehaviour
{
    private static LuaEnv _luaEnv;

    private static object lockObject = new object();

    public static LuaEnv LuaEnv
    {
        get
        {
            lock (lockObject)
            {
                if (_luaEnv == null)
                    _luaEnv = new LuaEnv();

                return _luaEnv;
            }
        }
    }
}
