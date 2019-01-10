using System;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Data;
namespace WindowsFormsApp1
{
    public class MySQL
    {
        protected string m_table, m_where, m_field = "*", m_limit, m_group, m_order, m_having, m_alias, m_prefix, m_comment, m_distinct;
        protected bool m_fetchSql = false;
        public string LastSql = ""; //最后生成的SQL

        protected ArrayList m_join = new ArrayList(), m_union = new ArrayList();
        protected Hashtable m_data = new Hashtable();

        public Int64 AffectCount { get; protected set; }
        public Int64 RecordCount { get; protected set; }
        public Int64 FieldCount { get; protected set; }

        public string ConnectionString;

        public MySqlConnection Connection;
        public MySqlCommand Command;
        public string Exception;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="table"></param>
        /// <param name="prefix"></param>
        public MySQL(string table, string prefix = "")
        {
            this.m_table = table;
            this.m_prefix = prefix;
        }


        /// <summary>
        /// 置表名
        /// </summary>
        /// <param name="table"></param>
        /// <param name="alias">default null</param>
        /// <returns>DbModel</returns>
        public MySQL Table(String table, String alias = null)
        {
            this.m_table = table;
            if (alias != null)
            {
                this.m_alias = " AS " + alias;
            }
            return this;
        }


        /// <summary>
        /// 置选取字段   
        /// </summary>
        /// <param name="field"></param>
        /// <returns>DbModel</returns>
        public MySQL Field(String field = "*")
        {
            this.m_field = field;
            return this;
        }


        /// <summary>
        /// 设置表别名
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public MySQL Alias(String alias)
        {
            this.m_alias = " AS " + alias;
            return this;
        }



        /// <summary>
        /// 查询条件
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public MySQL Where(String where)
        {
            this.m_where = where;
            return this;
        }

        /// <summary>
        /// 排序方法
        /// </summary>
        /// <param name="order">如 user_id [desc/asc]</param>
        /// <returns></returns>
        public MySQL Order(String order)
        {
            this.m_order = " ORDER BY " + order;
            return this;
        }

        /// <summary>
        /// 设置表名前缀， 对所有表有效。如果前缀是“table_”那么需要加前缀的表前后加两个下划线“__user__”，就会得到“table_user”
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public MySQL Prefix(String prefix)
        {
            this.m_prefix = prefix;
            return this;
        }

        /// <summary>
        /// 选取部分数据
        /// </summary>
        /// <param name="start">开始位置，默认为第一条, 如果留空参数2则直接"LIMIT start"</param>
        /// <param name="num">选取数量， 默认为0</param>
        /// <returns></returns>
        public MySQL Limit(int start = 0, int num = 0)
        {
            if (num == 0)
            {
                this.m_limit = " LIMIT " + Convert.ToString(start);
            }
            else
            {
                this.m_limit = " LIMIT " + Convert.ToString(start) + ", " + Convert.ToString(num);
            }
            return this;
        }

        /// <summary>
        /// 分页，本方法等同limit
        /// </summary>
        /// <param name="page">第N页</param>
        /// <param name="showNum">每页显示数量</param>
        /// <returns></returns>
        public MySQL Page(int page = 1, int showNum = 1000)
        {
            this.Limit((page - 1) * showNum, showNum);
            return this;
        }

        /// <summary>
        /// 分组条件（相当于where），配合group使用（group by）
        /// </summary>
        /// <param name="having"></param>
        /// <returns></returns>
        public MySQL Having(String having)
        {
            this.m_having = " HAVING " + having;
            return this;
        }

        /// <summary>
        /// 分组
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public MySQL Group(String group)
        {
            this.m_group = " GROUP BY " + group;
            return this;
        }

        /// <summary>
        /// 连接多条SQL(多条SQL查询结果合并)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="all">是否保留全部, 默认false (union / union all)</param>
        /// <param name="clear">是否清空</param>
        /// <returns></returns>
        public MySQL Union(string sql, bool all = false, bool clear = false)
        {
            if (clear)
            {
                this.m_union.Clear();
            }
            this.m_union.Add((all == true ? "union all " : "union ") + sql);
            return this;
        }

        /// <summary>
        /// 关联多个表
        /// </summary>
        /// <param name="join">例：LEFT JOIN __user__ on 1 = 1</param>
        /// <param name="clear">是否清除原先的join</param>
        /// <returns></returns>
        public MySQL Join(String join, bool clear = false)
        {
            if (clear)
            {
                this.m_join.Clear();
            }
            this.m_join.Add(join);
            return this;
        }

        /// <summary>
        /// 注释
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public MySQL Comment(string text)
        {
            this.m_comment = " /* " + text + " */ ";
            return this;
        }

        /// <summary>
        /// 唯一
        /// </summary>
        /// <param name="distinct"></param>
        /// <returns></returns>
        public MySQL Distinct(bool distinct)
        {
            this.m_distinct = (distinct == false ? "" : "DISTINCT ");
            return this;
        }

        /// <summary>
        /// 获取SQL, 如果为True.   Select/Add/Save/Del 将返回SQL语句, 并且不执行
        /// </summary>
        /// <param name="fetch"></param>
        /// <returns></returns>
        public MySQL FetchSql(bool fetch)
        {
            this.m_fetchSql = fetch;
            return this;
        }

        /// <summary>
        /// 绑定字段
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        public MySQL Data(string field, object value)
        {
            string temp = "";
            if (value == null)
            {
                temp = "null";
            }
            else
            {
                switch (value.GetType().Name)
                {
                    case "String":
                        temp = "'" + this.FilterSQL(value.ToString()) + "'";
                        break;
                    case "DateTime":
                        temp = "'" + value.ToString() + "'";
                        break;

                    default:
                        temp = value.ToString();
                        break;
                }
            }

            //如果存在:删除
            if (this.m_data.ContainsKey(field))
            {
                this.m_data.Remove(field);
                this.m_data.Add(field, temp);
                return this;
            }

            //新增

            this.m_data.Add(field, temp);


            return this;
        }

        /// <summary>
        /// 过滤SQL
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string FilterSQL(string value)
        {
            value.Replace("/", "\\/").Replace("\"", "\\\"").Replace("'", "\\'");
            return value;
        }

        /// <summary>
        /// 重置所有字段信息
        /// </summary>
        protected void Clear()
        {
            this.m_field = "*";
            this.m_join.Clear();
            this.m_union.Clear();
            this.m_data.Clear();
            this.m_group = this.m_having = this.m_order = this.m_where = this.m_distinct = this.m_order = this.m_limit = this.LastSql = this.m_comment = "";
        }

        /// <summary>
        /// 打开连接(连接数据库)
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        public bool Open(string ConnectionString = null)
        {
            if (ConnectionString != null)
            {
                this.ConnectionString = ConnectionString;
            }

            Connection = new MySqlConnection(this.ConnectionString);
            try
            {
                this.Connection.Open();
                this.Command = this.Connection.CreateCommand();
                return true;
            }
            catch (MySqlException e)
            {
                this.Exception = e.ToString();
                return false;
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            this.Connection.Close();
        }

        /// <summary>
        /// 执行SQL （只能执行 insert、update、delete），
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool Execute(string sql = "")
        {
            this.Command.CommandText = sql;
            this.AffectCount = this.Command.ExecuteNonQuery();

            return this.AffectCount > 0;
        }

        /// <summary>
        /// 查询第一列第一条记录
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object QueryOne(string sql)
        {
            this.Command.CommandText = sql;
            return this.Command.ExecuteScalar();
        }

        /// <summary>
        /// 查询SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable Query(string sql)
        {
            this.Command.CommandText = sql;
            MySqlDataAdapter adpter = new MySqlDataAdapter(this.Command);
            DataTable dt = new DataTable("Table");
            adpter.Fill(dt);

            this.RecordCount = dt.Rows.Count;
            this.FieldCount = dt.Columns.Count;
            return dt;
        }

        /// <summary>
        /// 查询（select）
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public object Select(string table = null, string where = null)
        {
            this.LastSql = this.GetSelectSql(table, where);
            if (this.m_fetchSql)
            {
                return this.LastSql;
            }
            else
            {
                DataTable data = this.Query(this.LastSql);
                this.Clear();
                return data;
            }
        }

        /// <summary>
        /// 新增记录（插入记录 insert）
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public object Add(string table = null)
        {
            this.LastSql = this.GetInsertSql(table);
            if (this.m_fetchSql)
            {
                return this.LastSql;
            }
            else
            {
                bool ret = this.Execute(this.LastSql);
                this.Clear();
                return ret;
            }
        }

        /// <summary>
        /// 保存记录（更新记录 update）
        /// </summary>
        /// <param name="table"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public object Save(string table = null, string where = null)
        {
            this.LastSql = this.GetUpdateSql(table, where);
            if (this.m_fetchSql)
            {
                return this.LastSql;
            }
            else
            {
                bool ret = this.Execute(this.LastSql);
                this.Clear();
                return ret;
            }
        }

        /// <summary>
        /// 删除记录 （delete）
        /// </summary>
        /// <param name="table"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public object Delete(string table = null, string where = null)
        {
            this.LastSql = this.GetDeleteSql(table, where);
            if (this.m_fetchSql)
            {
                return this.LastSql;
            }
            else
            {
                bool ret = this.Execute(this.LastSql);
                this.Clear();
                return ret;
            }
        }


        /// <summary>
        /// 获取查询记录语句
        /// </summary>
        /// <param name="table"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected string GetSelectSql(string table = null, string where = null)
        {
            table = table ?? this.m_table;
            where = " WHERE " + (where ?? this.m_where);


            /*
             * 0: 唯一
             * 1:选取字段
             * 2:表前缀
             * 3:表名
             * 4:表别称
             * 5:join
             * 6:where
             * 7:group
             * 8:having
             * 9:order
             * 10:limit
             * 11:union
             * 12:注释
             */
            this.LastSql = "SELECT {0}{1} FROM `{2}{3}`{4}{5}{6}{7}{8}{9}{10}{11}{12}";

            //join
            string join = "";
            for (int i = 0; i < this.m_join.Count; i++)
            {
                join += " " + this.m_join[i];
            }


            //union
            string union = "";
            for (int i = 0; i < this.m_union.Count; i++)
            {
                union += " " + this.m_union[i];
            }

            string sql = string.Format(this.LastSql, this.m_distinct, this.m_field, this.m_prefix, table, this.m_alias, join, where, this.m_group, this.m_having, this.m_order, this.m_limit, union, this.m_comment);
            return sql;
        }

        /// <summary>
        /// 获取插入记录语句
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        protected string GetInsertSql(string table = null)
        {
            table = table ?? this.m_table;

            string fields = "", values = "";
            foreach (string key in this.m_data.Keys)
            {
                fields += "`" + key + "`, ";
                values += this.m_data[key] + ", ";
            }

            if (fields.Length > 3)
            {
                fields = fields.Substring(0, fields.Length - 2);
                values = values.Substring(0, values.Length - 2);
            }

            string sql = string.Format("INSERT INTO `{0}{1}` ({2}) VALUES({3})", this.m_prefix, table, fields, values);
            return sql;
        }

        /// <summary>
        /// 获取更新记录语句
        /// </summary>
        /// <param name="table"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected string GetUpdateSql(string table = null, string where = null)
        {

            table = table ?? this.m_table;
            where = " WHERE " + (where ?? this.m_where);

            string data = "";
            foreach (string key in this.m_data.Keys)
            {
                data += "`" + key + "` = " + this.m_data[key] + ", ";
            }

            if (data.Length > 3)
            {
                data = data.Substring(0, data.Length - 2);
            }

            string sql = string.Format("UPDATE `{0}{1}` SET {2}{3}", this.m_prefix, table, data, where);
            return sql;
        }

        /// <summary>
        /// 获取删除记录语句
        /// </summary>
        /// <param name="table"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        protected string GetDeleteSql(string table = null, string where = null)
        {
            table = table ?? this.m_table;
            where = " WHERE " + (where ?? this.m_where);

            string sql = string.Format("DELETE FROM `{0}{1}`{2}{3}", this.m_prefix, table, where, this.m_limit);
            return sql;
        }

    }
}