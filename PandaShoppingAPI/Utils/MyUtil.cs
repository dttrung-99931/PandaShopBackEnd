using AutoMapper;
using PandaShoppingAPI.DataAccesses.EF;
using PandaShoppingAPI.Models;
using PandaShoppingAPI.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;

namespace PandaShoppingAPI.Utils
{
    public class MyUtil
    {
        public static IEnumerable<T> Page<T>(IQueryable<T> iQueryable, int? page_size, int? page_number)
        {
            if (page_size != null && page_number != null)
            {
                return iQueryable
                        .Skip(Convert.ToInt32(page_size) * (Convert.ToInt32(page_number) - 1))
                        .Take(Convert.ToInt32(page_size));
            }
            else return iQueryable;
        }

        internal static List<TEntity> Page<TEntity>(IQueryable<TEntity> queryable, Filter filter)
        {
            return Page(queryable, filter.pageSize, filter.pageNum).ToList();
        }

        internal static List<TListTo> MapList<TListFrom, TListTo>(
            List<TListFrom> list, 
            Func<TListFrom, TListTo> mapper)
        {
            var res = new List<TListTo>();
            list.ForEach(
                e => res.Add(mapper.Invoke(e))
            );
            return res;
        }

        public static IEnumerable<T> Page<T>(IEnumerable<T> iQueryable, int? page_size, int? page_number)
        {
            if (page_size != null && page_number != null)
            {
                return iQueryable
                        .Skip(Convert.ToInt32(page_size) * (Convert.ToInt32(page_number) - 1))
                        .Take(Convert.ToInt32(page_size));
            }
            else return iQueryable;
        }

        public static IEnumerable<T> Page<T>(List<T> iQueryable, int? page_size, int? page_number)
        {
            if (page_size != null && page_number != null)
            {
                return iQueryable
                        .Skip(Convert.ToInt32(page_size) * (Convert.ToInt32(page_number) - 1))
                        .Take(Convert.ToInt32(page_size));
            }
            else return iQueryable;
        }

        internal static string GetAppDataFilePath(string fileName)
        {
            return AppDomain.CurrentDomain.GetData("DataDirectory").ToString()
                            + "\\" + fileName;
        }

        internal static bool Contains(string str, string fill_str)
        {
            return str.Contains(fill_str);
        }

        internal static string ReadFileContent(string json_path)
        {
            StreamReader reader = new StreamReader(json_path);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }

        // return access_token that trimmed from Authorization header
        // with format "bearer access_token";
        internal static string ParseToToken(string authorization)
        {
            return authorization.Substring(7);
        }

        internal static string ToJson(object rightVerification)
        {
            return JsonConvert.SerializeObject(rightVerification);
        }

        public static void Wrap(string message, Action action)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                action();
            }
            finally
            {
                watch.Stop();
                Console.WriteLine($"{message} executed in {watch.ElapsedMilliseconds} ms");
            }
        }

        internal static void Log(string msg)
        {
            Debug.WriteLine(msg);
        }
    }
}