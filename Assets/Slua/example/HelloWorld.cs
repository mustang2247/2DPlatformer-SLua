﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SLua;
using System;
using LuaInterface;

[CustomLuaClass]
public struct foostruct
{
	public float x, y, z,w;
	public int mode;
}

[CustomLuaClass]
public class FloatEvent : UnityEngine.Events.UnityEvent<float>
{
	public FloatEvent() { }
}

[CustomLuaClass]
public class ListViewEvent : UnityEngine.Events.UnityEvent<int,string> {
	
}

[CustomLuaClass]
public class SLuaTest : MonoBehaviour {
	public FloatEvent intevent;
}

[CustomLuaClass]
public class XXList : List<int> { }

[CustomLuaClass]
abstract public class AbsClass {

	// this constructor should not been exported for test
	public AbsClass() {
	}

	public int x;
}


public class Ref
{
    int mDepth;
    public int depth
    {
        get
        {
            return mDepth;
        }
        set {
            mDepth = value;
        }
    }
}

[CustomLuaClass]
public class HelloWorld
{
	public UnityEngine.Events.UnityAction someAct;
	static public void say()
	{
		Debug.Log("hello world");
	}

	static public byte[] bytes()
	{
		return new byte[] { 51, 52, 53, 53 };
	}

	static public void int16Array(Int16[] array) {
		foreach(Int16 i in array) {
			Debug.Log("output int16 "+i);
		}
	}

	static public Vector3[] vectors()
	{
		return new Vector3[] { Vector3.one, Vector3.zero, Vector3.up };
	}

	static public void nullf(int? a=null) {
		if (a == null)
			Debug.Log("null");
		else
			Debug.Log(a);
	}

	public IEnumerator y()
	{
		WWW www = new WWW("http://news.163.com");
		yield return www;
		Debug.Log("yield good");
	}


	public Dictionary<string, GameObject> foo()
	{
		return new Dictionary<string, GameObject>();
	}

	public Dictionary<string, GameObject>[] foos()
	{
		return new Dictionary<string, GameObject>[]{};
	}

	public int gos(Dictionary<string, GameObject>[] x)
	{
		return x.Length;
	}

	public Dictionary<GameObject, string> too()
	{
		return new Dictionary<GameObject, string>();
	}

	public List<GameObject> getList()
	{
		return new List<GameObject> { new GameObject("1"), new GameObject("2") };
	}

	static public void setv(LuaTable t)
	{
		foreach (LuaTable.TablePair pair in t)
		{
			Debug.Log(string.Format("foreach LuaTable {0}-{1}", pair.key, pair.value));
			break;
		}

		var iter = t.GetEnumerator();
		while(iter.MoveNext()) {
			var pair = iter.Current;
			Debug.Log(string.Format("foreach LuaTable {0}-{1}", pair.key, pair.value));
			break;
		}
		iter.Dispose();

	}

	static public LuaTable getv()
	{
		LuaTable t = new LuaTable(LuaState.main);
		t["name"] = "xiaoming";
		t[1] = "a";
		t[2] = "b";

		t["xxx"] = new LuaTable(LuaState.main);
		((LuaTable)t["xxx"])["yyy"] = 1;
		return t;
	}


	static public void ofunc(Type t)
	{
		Debug.Log(t.Name);
	}

	static public void ofunc(GameObject go)
	{
		Debug.Log(go.name);
	}





	// this function exported, but get error to call
	// generic function not support
	public void generic<T>()
	{
		Debug.Log(typeof(T).Name);
	}

	public void perf()
	{
		UnityEngine.Profiling.Profiler.BeginSample("create 1000000 vector3/cs");
		for (int n = 0; n < 1000000; n++)
		{
			Vector3 v = new Vector3(n, n, n);
			v.Normalize();
		}
		UnityEngine.Profiling.Profiler.EndSample();
	}

	static public void testvec3(Vector3 v)
	{
		Debug.Log(string.Format("vec3 {0},{1},{2}", v.x, v.y, v.z));
	}

	static public void testset(GameObject go)
	{
		Transform t = go.transform;
		for (int i = 0; i < 200000; i++)
		{
			t.position = t.position;
		}
	}

	static public void test2(GameObject go)
	{
		Vector3 v = Vector3.one;
		for (int i = 0; i < 200000; i++)
		{
			v.Normalize();
		}
	}

	static public void test3(GameObject go)
	{
		Vector3 v = Vector3.one;
		for (int i = 0; i < 200000; i++)
		{
			v = Vector3.Normalize(v);
		}
	}

	static public void test4(GameObject go)
	{
		Vector3 v = Vector3.one;
		Transform t = go.transform;
		for (int i = 0; i < 200000; i++)
		{
			t.position = v;
		}
	}

	static public Vector3 test5(GameObject go)
	{
		Vector3 v = Vector3.zero;
		for (int i = 0; i < 200000; i++)
		{
			v = new Vector3(i, i, i);
		}
		return v;
	}

	// test variant number for arguments passed in
	static public void func6(string str, params object[] args)
	{
		Debug.Log(str);
		for (int n = 0; n < args.Length; n++)
		{
			Debug.Log(args[n]);
		}
	}

	LuaFunction f;
	public void func7(LuaFunction func)
	{
		f = func;
		f.call();
	}

	public void func7(int a)
	{
		Debug.Log(a);
	}

	[DoNotToLua]
	static public void dontexport()
	{

	}

	[DoNotToLua]
	public int a;

	[DoNotToLua]
	public int A
	{
		get
		{
			return a;
		}
	}

	internal int b;
}
