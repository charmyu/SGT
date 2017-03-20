using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Web.Http;

namespace Power.Controllers
{
    public class HistoricalDataController : ApiController
    {
        Power.BLL.HistoricalData BLL = new BLL.HistoricalData();

        /// <summary>
        /// 获取历史曲线数据
        /// </summary>
        /// <param name="devID"></param>
        /// <param name="paramID"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        public string GetLineData(string devID, string paramID, string tm, string date, string fun)
        {
            string sdate = "";
            string sfun = "";
            string btm = "";
            string etm = "";
            if (date == "day")
            {
                sdate = "HH";
                btm = tm + " 00:00:00";
                etm = tm + " 23:59:59";
            }
            else
            {
                sdate = "DD";
                DateTime t = Convert.ToDateTime(tm);
                btm = t.Year.ToString("D2") + "-" + t.Month.ToString("D2") + "-01 00:00:00";
                if (t.Month + 1 > 12)
                {
                    etm = (t.Year + 1).ToString() + "-01-01 00:00:00";
                }
                else
                {
                    etm = t.Year.ToString() + "-" + (t.Month + 1).ToString("D2") + "-01 00:00:00";
                }
            }
            if (fun == "min")
            {
                sfun = "MIN";
            }
            else if (fun == "max")
            {
                sfun = "MAX";
            }
            else
            {
                sfun = "AVG";
            }
            DataSet ds = BLL.GetLineDataByDeviceID(string.Format(" hd.DeviceID='{0}' and hd.ParameterID='{1}' and hd.ParameterName >'{2}' and hd.ParameterName<'{3}' and p.usertype<={4}", devID, paramID, btm, etm, CurrentUser.UserTypeID), sdate, sfun);

            if (ds.Tables.Count > 0)
            {
                return ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }
            else
            {
                return "{'Rows':[]}";
            }
        }


        /// <summary>
        /// 获取历史列表数据
        /// </summary>
        /// <param name="devID"></param>
        /// <param name="tm"></param>
        /// <param name="date"></param>
        /// <param name="fun"></param>
        /// <returns></returns>
        public string GetDataTalble(string devID, string tm, string date, string fun, string NO)
        {
            string sdate = "";
            string sfun = "";
            string btm = "";
            string etm = "";
            if (date == "day")
            {
                sdate = "HH";
                btm = tm + " 00:00:00";
                etm = tm + " 23:59:59";
            }
            else
            {
                sdate = "DD";
                DateTime t = Convert.ToDateTime(tm);
                btm = t.Year.ToString("D2") + "-" + t.Month.ToString("D2") + "-01 00:00:00";
                if (t.Month + 1 > 12)
                {
                    etm = (t.Year + 1).ToString() + "-01-01 00:00:00";
                }
                else
                {
                    etm = t.Year.ToString() + "-" + (t.Month + 1).ToString("D2") + "-01 00:00:00";
                }
            }
            if (fun == "min")
            {
                sfun = "MIN";
            }
            else if (fun == "max")
            {
                sfun = "MAX";
            }
            else
            {
                sfun = "AVG";
            }
            //DataSet ds = BLL.GetDataTableByDeviceID(string.Format(" hd.DeviceID='{0}' and hd.ParameterID='{1}' and hd.ParameterName >'{2}' and hd.ParameterName<'{3}' and p.usertype<={4}", devID, paramID, tm + " 00:00:00", tm + " 23:59:59", CurrentUser.UserTypeID), sdate, sfun);
            DataSet ds = BLL.GetDataTableByDeviceID(string.Format(" hd.DeviceID='{0}' and hd.ParameterName >'{1}' and hd.ParameterName<'{2}' and p.usertype<={3} and p.SenderID='{4}'", devID, btm, etm, CurrentUser.UserTypeID, NO), sdate, sfun);
            if (ds.Tables.Count > 0)
            {
                return ListToJson.DataTableToJson("Rows", ds.Tables[0]);
            }
            else
            {
                return "{'Rows':[]}";
            }
        }

        /// <summary>
        /// 导出曲线至EXCEL
        /// </summary>
        /// <returns></returns>
        public bool ExportLine(string devID, string paramID, string tm, string date, string fun)
        {
            try
            {
                string sdate = "";
                string sfun = "";
                string btm = "";
                string etm = "";
                if (date == "day")
                {
                    sdate = "HH";
                    btm = tm + " 00:00:00";
                    etm = tm + " 23:59:59";
                }
                else
                {
                    sdate = "DD";
                    DateTime t = Convert.ToDateTime(tm);
                    btm = t.Year.ToString("D2") + "-" + t.Month.ToString("D2") + "-01 00:00:00";
                    if (t.Month + 1 > 12)
                    {
                        etm = (t.Year + 1).ToString() + "-01-01 00:00:00";
                    }
                    else
                    {
                        etm = t.Year.ToString() + "-" + (t.Month + 1).ToString("D2") + "-01 00:00:00";
                    }
                }
                if (fun == "min")
                {
                    sfun = "MIN";
                }
                else if (fun == "max")
                {
                    sfun = "MAX";
                }
                else
                {
                    sfun = "AVG";
                }
                DataSet ds = BLL.GetLineDataByDeviceID(string.Format(" hd.DeviceID='{0}' and hd.ParameterID='{1}' and hd.ParameterName >'{2}' and hd.ParameterName<'{3}' and p.usertype<={4}", devID, paramID, btm, etm, CurrentUser.UserTypeID), sdate, sfun);
                if (ds.Tables.Count > 0)
                {
                    DataTable dataTable = ds.Tables[0];
                    int rowNumber = dataTable.Rows.Count;
                    int columnNumber = dataTable.Columns.Count;
                    if (rowNumber == 0)
                    {
                        return false;
                    }
                    //导出数据
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook xBk = excel.Workbooks.Add(true);

                    //横排填充数据
                    for (int c = 0; c < columnNumber; c++)
                    {
                        for (int j = 0; j < rowNumber; j++)
                        {
                            excel.Cells[c + 1, j + 1] = dataTable.Rows[j].ItemArray[c];
                        }
                    }
                    string fileName = @"C:\Line.xlsx";
                    if (!File.Exists(fileName))
                    {
                        CreateExcel(fileName);
                    }
                    xBk.SaveCopyAs(fileName);
                    return true;
                }
            }
            catch { return false; }
            return false;
        }

        /// <summary>
        /// 导出数据至EXCEL
        /// </summary>
        /// <returns></returns>
        public bool ExportData(string devID, string tm, string date, string fun, string NO)
        {
            try
            {
                string sdate = "";
                string sfun = "";
                string btm = "";
                string etm = "";
                if (date == "day")
                {
                    sdate = "HH";
                    btm = tm + " 00:00:00";
                    etm = tm + " 23:59:59";
                }
                else
                {
                    sdate = "DD";
                    DateTime t = Convert.ToDateTime(tm);
                    btm = t.Year.ToString("D2") + "-" + t.Month.ToString("D2") + "-01 00:00:00";
                    if (t.Month + 1 > 12)
                    {
                        etm = (t.Year + 1).ToString() + "-01-01 00:00:00";
                    }
                    else
                    {
                        etm = t.Year.ToString() + "-" + (t.Month + 1).ToString("D2") + "-01 00:00:00";
                    }
                }
                if (fun == "min")
                {
                    sfun = "MIN";
                }
                else if (fun == "max")
                {
                    sfun = "MAX";
                }
                else
                {
                    sfun = "AVG";
                }
                DataSet ds = BLL.GetDataTableByDeviceID(string.Format(" hd.DeviceID='{0}' and hd.ParameterName >'{1}' and hd.ParameterName<'{2}' and p.usertype<={3} and p.SenderID='{4}'", devID, btm, etm, CurrentUser.UserTypeID, NO), sdate, sfun);
                if (ds.Tables.Count > 0)
                {
                    DataTable dataTable = ds.Tables[0];
                    int rowNumber = dataTable.Rows.Count;
                    int columnNumber = dataTable.Columns.Count;
                    if (rowNumber == 0)
                    {
                        return false;
                    }
                    //导出数据
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook xBk = excel.Workbooks.Add(true);

                    //横排填充数据
                    for (int c = 0; c < columnNumber; c++)
                    {
                        for (int j = 0; j < rowNumber; j++)
                        {
                            excel.Cells[c + 1, 1] = dataTable.Columns[c].Caption;
                            excel.Cells[c + 1, j + 2] = dataTable.Rows[j].ItemArray[c];
                        }
                    }
                    string fileName = @"C:\Data.xlsx";
                    if (!File.Exists(fileName))
                    {
                        CreateExcel(fileName);
                    }
                    xBk.SaveCopyAs(fileName);
                    return true;
                }
            }
            catch { return false; }
            return false;
        }

        public void CreateExcel(string fileName)
        {
            try
            {
                Object missing = Missing.Value;
                Microsoft.Office.Interop.Excel.Application m_objExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks m_objWorkBooks = m_objExcel.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook m_objWorkBook = m_objWorkBooks.Add(true);
                Microsoft.Office.Interop.Excel.Sheets m_objWorkSheets = m_objWorkBook.Sheets; ;
                Microsoft.Office.Interop.Excel.Worksheet m_objWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)m_objWorkSheets[1];
                m_objWorkBook.SaveAs(fileName, missing, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                missing, missing, missing, missing, missing);
                m_objWorkBook.Close(false, missing, missing);
                m_objExcel.Quit();
            }
            catch { }
        }
    }
}