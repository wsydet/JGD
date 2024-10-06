using UnityEngine;

using System.IO;                //使用File.WriteAllText(path, json);创建存档文本

namespace SaveSystemTutorial
{
    public static class SaveSystem 
    {
        #region  PlayerPrefs存档
        public static void Save_By_PlayerPrefs(string key,object data)      //object data包括了所有的数据类型
        {
            var json = JsonUtility.ToJson(data);                            //将数据转换为Json对象,true转为更容易阅读的格式
            //var json = JsonUtility.ToJson(data,true);                     将数据转换为Json对象,true转为更容易阅读的格式
            Debug.Log(json);                                                //(var 后面值不固定时自适应，必须在声明时初始化)
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();                                              //将数据从内存中转移到硬盘中

        #if UNIYT_EDITOR
            Debug.Log("存档成功");      //只会在编辑器中执行，打包后不会执行
        #endif
        }

        public static string Load_By_PlayerPrefs (string key)
        {
            return PlayerPrefs.GetString(key, null);
        }
        #endregion

        #region JSON存档
        public static void Save_By_Json(string Save_File_Name, object data)
        {
            var json = JsonUtility.ToJson(data);
            var path = Path.Combine(Application.persistentDataPath, Save_File_Name);
            //平台自适应文件路径和文件名

            try//代码出错时进行debug
            {
                File.WriteAllText(path, json);//在path路径下创建存档文本，内容为json
                #if UNITY_EDITOR
                Debug.Log($"成功将存档存入{path}路径");
                #endif
            }
            catch(System.Exception exception)
            {
                #if UNITY_EDITOR
                Debug.LogError($"无法将存档存入{path}路径.n{exception}");
                #endif
            }
        }
        public static T Load_By_Json<T>(string Save_File_Name)
        {
            var path = Path.Combine(Application.persistentDataPath, Save_File_Name);

            try //代码出错时进行debug
            { 
                var json = File.ReadAllText(path);

                var data = JsonUtility.FromJson<T>(json);

                return data;
            }
            catch (System.Exception exception)
            {
                #if UNITY_EDITOR
                Debug.LogError($"无法载入存档{path}路径.n{exception}");
                #endif
                return default;
            }
        }
        #endregion

        #region 删除存档
        public static void Delete_Save_File(string Save_File_Name)
        {
            var path = Path.Combine(Application.persistentDataPath, Save_File_Name);

            try //代码出错时进行debug
            {
                 File.Delete(path);
            }
            catch (System.Exception exception)
            {
            #if UNITY_EDITOR
                Debug.LogError($"无法删除存档{path}路径.n{exception}");
            #endif 
            }
        }
        #endregion
    }
}
