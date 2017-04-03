using UnityEngine;
using System.Collections;
using System.Text;
public class StringUtil {
    /// <summary>
    /// 把字符串转为bytes
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
	public static byte[] getBytes(string value)
    {
        byte[] bytes = UTF8Encoding.Default.GetBytes(value);
        return bytes;
    }


    public static string bytesToString(byte[] bytes)
    {
        string result = UTF8Encoding.Default.GetString(bytes);
        return result;
    }

}
