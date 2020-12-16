using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;

public class Example : MonoBehaviour
{
    string filePath;

    string code;

    // Start is called before the first frame update
    void Start()
    {
        SingleLuaEnv.LuaEnv.AddLoader(loader);

        //SingleLuaEnv.LuaEnv.DoString("require 'helloworld'");

        SingleLuaEnv.LuaEnv.DoString("require 'CSharpCallLua'");

        //C#访获取Lua中的全局变量
        //int age = SingleLuaEnv.LuaEnv.Global.Get<int>("age");
        //Debug.Log(age);
        //string name = SingleLuaEnv.LuaEnv.Global.Get<string>("name");
        //Debug.Log(name);
        //bool isMan = SingleLuaEnv.LuaEnv.Global.Get<bool>("man");
        //Debug.Log(isMan);

        //C#获取Lua中的全局Table--映射到类或结构体
        //Person person = SingleLuaEnv.LuaEnv.Global.Get<Person>("person");
        //Debug.Log(string.Format("{0};{1};{2}.",person.age,person.name,person.man));

        //C#获取Lua中的全局Table--映射到接口
        IPerson person = SingleLuaEnv.LuaEnv.Global.Get<IPerson>("person");
        Debug.Log(string.Format("{0};{1};{2}.", person.age, person.name, person.man));
    }

    struct Person
    {
        public int age;
        public string name;
        public bool man;
    }

    [CSharpCallLua]
    interface IPerson
    {
        int age { get; set; }
        string name { get; set; }
        bool man { get; set; }
    }

    byte[] loader(ref string fileName)
    {
        filePath = Application.streamingAssetsPath + "/" + fileName + ".lua.txt";

        if (string.IsNullOrEmpty(fileName) || !File.Exists(filePath))
            return null;

        return File.ReadAllBytes(filePath);

        //return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(filePath));
    }

    void OnDestroy()
    {
        SingleLuaEnv.LuaEnv.Dispose();
    }
}
