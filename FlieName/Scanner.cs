using System;
using System.Collections.Generic;
using System.IO;

namespace FileNameScanner
{
    public class Scanner
    {
        /// <summary>
        /// 取得目錄底下所有指定副檔名的檔案名稱(不包含副檔名)
        /// </summary>
        /// <param name="path">目標路徑</param>
        /// <param name="extension">目標副檔名</param>
        /// <returns></returns>
        public static List<string> GetFileNameByFilenameExtension(string path, string extension)
        {
            List<string> result = new List<string>();
            try
            {
                //取得當前目錄檔案
                foreach (string name in Directory.GetFiles(path))
                {
                    var nameSplit = name.Split(".");
                    var realName = "";

                    if (nameSplit[nameSplit.Length - 1] == extension)
                    {
                        //檔名重組
                        for (int i = 0; i < nameSplit.Length - 1; i++)
                        {
                            if (i == 0)
                                realName += nameSplit[i];
                            else
                                realName += "." + nameSplit[i];
                        }

                        result.Add(realName);
                    }
                }

                //取得當前根目錄檔案
                foreach (string d in Directory.GetDirectories(path))
                {
                    result.AddRange(GetFileNameByFilenameExtension(d, extension));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return result;
        }
    }
}
