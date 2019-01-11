using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OracleDBTest
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Oracle 連線字串
            string conn_str = "DATA SOURCE=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SID = xe)));PERSIST SECURITY INFO=True;USER ID=HR;PASSWORD=dakong;";
            string SQL_cmd = "select * from countries";
            //建立連線
            using (OracleConnection conn = new OracleConnection(conn_str))
            {
                //如果是關閉狀態，則打開連線
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //建立指令
                using (OracleCommand cmd = new OracleCommand(SQL_cmd, conn))
                {
                    OracleDataAdapter DataAdapter = new OracleDataAdapter();
                    DataAdapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    DataAdapter.Fill(ds);
                }
            }
        }
    }
}