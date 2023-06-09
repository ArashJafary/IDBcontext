﻿
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace testIDBcon.Model
{
    public static class  Extension
    {
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName]);
                }
            }
            return obj;
        }




        public  static List<T> Exqut<T>(this IDbConnection Connection,string SqlCom,params object[] Input )
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = SqlCom;
            cmd.Connection = (SqlConnection)Connection;
             for(int i=0;i<Input.Length;i++)
            {
                cmd.Parameters.AddWithValue("Input"+(i+1),Input[i]);
            }
            SqlDataAdapter Adapter = new SqlDataAdapter();  
            DataTable Data = new DataTable();
            Adapter.SelectCommand= cmd;
            Adapter.Fill(Data);
            var resualt = new List<T>();
            resualt = Extension.ConvertDataTable<T>(Data);
            return resualt;
        }


        public  static T ExqutSingelOrDefault<T>(this IDbConnection Connection,string SqlCom,params object[] Input )
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = SqlCom;
            cmd.Connection = (SqlConnection)Connection;
            for(int i=0;i<Input.Length;i++)
            {
                cmd.Parameters.AddWithValue(nameof(Input)+(i+1),Input[i]);
            }
            SqlDataAdapter Adapter = new SqlDataAdapter();  
            DataTable Data = new DataTable();
            Adapter.SelectCommand= cmd;
            Adapter.Fill(Data);
           var  resualt = GetItem<T>(Data.Rows[0]);
            return resualt;
        }
    }
}
