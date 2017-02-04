/**
 * The lua mono data bridge class.
 * 挂接在游戏对象上来为其提供数据，提供了 int，float，string 三种数据类型
 * @filename  YwLuaMonoDataBridge.cs
 * @copyright Copyright (c) 2015 Yaukey/yaukeywang/WangYaoqi (yaukeywang@gmail.com) all rights reserved.
 * @license   The MIT License (MIT)
 * @author    Yaukey
 * @date      2016-03-17
 */

using UnityEngine;
using System.Collections;

// The lua mono data bridge class.
[RequireComponent(typeof(YwLuaMonoBehaviour))]
public class YwLuaMonoDataBridge : MonoBehaviour
{
    // The int data array.
    public int[] m_integers = null;

    // The float data array.
    public float[] m_floats = null;

    // The string data array.
    public string[] m_strings = null;
}
