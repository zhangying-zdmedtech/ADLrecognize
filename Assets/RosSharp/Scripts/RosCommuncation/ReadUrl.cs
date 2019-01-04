using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadUrl : Singleton<ReadUrl> {
	String line;
	public  string Read()
    {
        try
        {   // Open the text file using a stream reader.
			using (StreamReader sr = new StreamReader("/opt/zdmedtech/app/configFile/config/System.cfg"))
            {
                // Read the stream to a string, and write the string to the console.
                line = sr.ReadToEnd();
            }
        }
        catch (Exception e)
        {
			Write.Log("Url读取失败");
			Write.Log("Url失败信息："+e.Message);
        }
        string[] strArray = line.Split('\n');//用换行来取
        foreach (string str in strArray)//遍力数组
        {
            string[] proArray = str.Split('=');//根据=号来拆分文本里面的数据
            string name = proArray[0].Trim();//名称
            if (name=="host")
            {
				name = proArray[1].Trim();//名称
				Write.Log("Url: "+name);
				return name;
            }
        }
		return null;
    }   
}
