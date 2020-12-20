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

        //C#获取Lua中的全局Table--映射到接口--建议使用！
        //IPerson person = SingleLuaEnv.LuaEnv.Global.Get<IPerson>("person");
        //Debug.Log(string.Format("{0};{1};{2}.", person.age, person.name, person.man));

        //C#获取Lua中的全局Table--映射到Dictionary或List
        //Dictionary映射有键的值，List映射没有键的值
        //Dictionary<string, object> dic = SingleLuaEnv.LuaEnv.Global.Get<Dictionary<string, object>>("person");
        //foreach(string key in dic.Keys)
        //{
        //    Debug.Log(key+":"+dic[key]);
        //}
        //List<object> list = SingleLuaEnv.LuaEnv.Global.Get<List<object>>("person");
        //foreach(object o in list)
        //{
        //    Debug.Log(o);
        //}

        //C#获取Lua中的全局Table--通过LuaTable
        //LuaTable luaTable = SingleLuaEnv.LuaEnv.Global.Get<LuaTable>("person");
        //print(luaTable.Get<string>("name"));

        //C#通过delegate访问Lua中的function
        Run run = SingleLuaEnv.LuaEnv.Global.Get<Run>("Run");
        run();
        Fly fly = SingleLuaEnv.LuaEnv.Global.Get<Fly>("Fly");
        fly(false);
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

    delegate void Run();

    delegate void Fly(bool isCan);

    byte[] loader(ref string fileName)
    {
        filePath = Application.streamingAssetsPath + "/" + fileName + ".lua.txt";

        if (string.IsNullOrEmpty(fileName) || !File.Exists(filePath))
            return null;

        return File.ReadAllBytes(filePath);
    }

    void OnDestroy()
    {
        SingleLuaEnv.LuaEnv.Dispose();
    }
}
