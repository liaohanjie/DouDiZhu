using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

public class Md5Util  {

	public static byte[] md5(byte[] bytes)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] output = md5.ComputeHash(bytes);
        return output;
    }
    /// <summary>
    /// 把一个字节数组进行md5加密，然后再转化为长度为32的十六进制字符串。
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string md5ToString(byte[] bytes)
    {
        MD5 md5 = MD5.Create();
       
        byte[] hash = md5.ComputeHash(bytes);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("x2"));//大  "X2",小"x2"    
        }
        return sb.ToString();
    }
}
