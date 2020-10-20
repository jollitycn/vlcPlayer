using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Data;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;

namespace JieXi.Common
{
    public class NPOIHelper
    {
        /// <summary>
        /// 导出列名
        /// </summary>
         
     //   public static System.Collections.SortedList  ListColumnsName;

        public static String[] Keys = null;
        public static String[] Values = null; 
        public static List<CellType> CellValues = null;
        public static List<CellType> BottomCellValues = null;
        public static int hsRowCount =0;
        public static int bottomHsRowCount = 0;
        public static int dtSourceRows = 0;
        //   protected static int firstRow=0;
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param> 
        public static void ExportExcel(DataTable dtSource, string filePath)
        {
            if ((Keys == null || Keys.Length == 0) || (Values == null || Values.Length == 0))
                throw (new Exception("请对ListColumnsName设置要导出的列明！"));

            dtSourceRows = dtSource.Rows.Count;
            HSSFWorkbook excelWorkbook = CreateExcelFile();
            InsertRow(dtSource, excelWorkbook);

         

            SaveExcelFile(excelWorkbook, filePath);
            hsRowCount = 0;
            CellValues = null;
            BottomCellValues = null;
            bottomHsRowCount = 0;
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filePath"></param>
        public static void ExportExcel(DataTable dtSource, Stream excelStream)
        {
            if ((Keys == null || Keys.Length == 0) || (Values == null || Values.Length == 0))
                throw (new Exception("请对ListColumnsName设置要导出的列明！"));
            dtSourceRows= dtSource.Rows.Count;
            HSSFWorkbook excelWorkbook = CreateExcelFile();
             
            InsertRow(dtSource, excelWorkbook);
            SaveExcelFile(excelWorkbook, excelStream);
        }
        /// <summary>
        /// 保存Excel文件
        /// </summary>
        /// <param name="excelWorkBook"></param>
        /// <param name="filePath"></param>
        protected static void SaveExcelFile(HSSFWorkbook excelWorkBook, string filePath)
        {
            FileStream file = null;
            try
            {
                file = new FileStream(filePath, FileMode.Create);
                excelWorkBook.Write(file);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        /// <summary>
        /// 保存Excel文件
        /// </summary>
        /// <param name="excelWorkBook"></param>
        /// <param name="filePath"></param>
        protected static void SaveExcelFile(HSSFWorkbook excelWorkBook, Stream excelStream)
        {
            try
            {
                excelWorkBook.Write(excelStream);
            }
            finally
            {

            }
        }
        /// <summary>
        /// 创建Excel文件
        /// </summary>
        /// <param name="filePath"></param>
        protected static HSSFWorkbook CreateExcelFile()
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            return hssfworkbook;
        }

        /// <summary>
        /// 创建excel表头
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="excelSheet"></param>
        /// 

        protected static void CreateHeader(HSSFSheet excelSheet, HSSFWorkbook workbook)
        {

            
            //sheet.addMergedRegion(new CellRangeAddress(2, 2, 1, 0));

            int cellIndex = 0;
           /* if (hsRowList != null && hsRowList.Count > 0)
            {
                cellIndex = hsRowList.Count;
            }*/
               //创建表头前说明备注
            if (hsRowCount  > 0) {
                for (int i=0;i< hsRowCount; i++)
                {
                    HSSFRow createRow = (HSSFRow)excelSheet.CreateRow(i);
                    //  HSSFCellStyle cellStyle = wb.createCellStyle();
                     
                    if (CellValues != null)
                    {
                        int curHeaderCellIndex=0;
                           int firstindex = 0;
                        for (int j = 0; j < CellValues.Count; j++)
                        {
                           
                            if (CellValues[j].RowIndex == i)
                            {

                                excelSheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(i, i, firstindex, firstindex + CellValues[j].CellMergeNum-1));
                                firstindex += CellValues[j].CellMergeNum;

                                // if (CellValues[j].CellMergeIndex == 0)
                                //  {
                                //

                                HSSFCell   iCell = (HSSFCell)createRow.CreateCell(curHeaderCellIndex);
                              
                        

                                 
                                iCell.SetCellValue(CellValues[j].CellName);

                                if (CellValues[j].Title)
                                {
                                    HSSFCellStyle cellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                                    HSSFFont font1 = (HSSFFont)workbook.CreateFont();
                                    font1.FontName = "宋体";
                                    font1.FontHeightInPoints = 18;
                                    font1.IsBold = true; 
                                    cellStyle.Alignment = HorizontalAlignment.Center;

                                    

                                    cellStyle.SetFont(font1);
                                    iCell.CellStyle = cellStyle;
                                }
                                
                                 
                                curHeaderCellIndex++;
                                
                               if (CellValues[j].CellMergeNum > 1)
                                {
                                    for (int k = 1; k < CellValues[j].CellMergeNum ; k++)
                                    {
                                      //  if (CellValues[j].CellMergeIndex == k) {
                                          //  createRow.CreateCell(curHeaderCellIndex).SetCellValue(CellValues[j].CellName);
                                       // }
                                       // else
                                       // {
                                           createRow.CreateCell(curHeaderCellIndex); 
                                      //  }

                                        curHeaderCellIndex++;
                                    }

                                }

                            }

                        }
                    }
                }
            }
            //建立第一行，表示表头
                HSSFRow newRow = (HSSFRow)excelSheet.CreateRow(hsRowCount);
            //循环导出列
            foreach (var value in Values)
            {
                HSSFCell newCell = (HSSFCell)newRow.CreateCell(cellIndex);
                
                newCell.SetCellValue(value);

                HSSFCellStyle cellStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                cellStyle.Alignment = HorizontalAlignment.Center;

                cellStyle.BorderBottom = BorderStyle.Thin;
                cellStyle.BorderLeft = BorderStyle.Thin;
                cellStyle.BorderRight = BorderStyle.Thin;
                cellStyle.BorderTop = BorderStyle.Thin;

                HSSFFont font1 = (HSSFFont)workbook.CreateFont();
                font1.FontName = "宋体"; 
                font1.IsBold = true; 
                cellStyle.Alignment = HorizontalAlignment.Center;
                cellStyle.SetFont(font1);
                newCell.CellStyle = cellStyle;
                cellIndex++;
            }


      




        }
        /// <summary>
        /// 总记录包括表头，底部 必须小于10000行内可使用该方法 
        /// </summary>
        /// <param name="excelSheet"></param>
        protected static void CreateBottom(HSSFSheet excelSheet, HSSFWorkbook excelWorkbook)
        {
            int StartIndex = hsRowCount + 1 + dtSourceRows;

          

            if (bottomHsRowCount > 0)
            {
                for (int i = 0; i < bottomHsRowCount; i++)
                {
                    HSSFRow createRow = (HSSFRow)excelSheet.CreateRow((i+StartIndex+1));
                    //excelSheet.AutoSizeColumn()
                     if (BottomCellValues != null)
                      {
                          int curHeaderCellIndex = 0;
                          int firstindex = 0;
                          for (int j = 0; j < BottomCellValues.Count; j++)
                          {

                            if (BottomCellValues[j].RowIndex == (i+ StartIndex))
                            {

                                excelSheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(i, i, firstindex, firstindex + BottomCellValues[j].CellMergeNum - 1));
                                firstindex += BottomCellValues[j].CellMergeNum;


                                // if (CellValues[j].CellMergeIndex == 0)
                                //  {

                                HSSFCell iCell = (HSSFCell)createRow.CreateCell(curHeaderCellIndex);




                                iCell.SetCellValue(BottomCellValues[j].CellName);

                                //  createRow.CreateCell(curHeaderCellIndex).SetCellValue(BottomCellValues[j].CellName);

                                if (BottomCellValues[i].IsCollect)
                                {
                                   
                                        HSSFCellStyle cellStyle = (HSSFCellStyle)excelWorkbook.CreateCellStyle();
                                        HSSFFont font1 = (HSSFFont)excelWorkbook.CreateFont();
                                        font1.FontName = "宋体";
                                      //  font1.FontHeightInPoints = 18;
                                        font1.IsBold = true;
                                      //  cellStyle.Alignment = HorizontalAlignment.Center;



                                        cellStyle.SetFont(font1);
                                        iCell.CellStyle = cellStyle;
                                  
                                }
                              
                                //  }
                                //  else
                                // {
                                //   createRow.CreateCell(curHeaderCellIndex);
                                //  }
                                curHeaderCellIndex++;

                                if (BottomCellValues[j].CellMergeNum > 1)
                                {
                                    for (int k = 1; k < BottomCellValues[j].CellMergeNum; k++)
                                    {
                                        //  if (CellValues[j].CellMergeIndex == k) {
                                        //  createRow.CreateCell(curHeaderCellIndex).SetCellValue(CellValues[j].CellName);
                                        // }
                                        // else
                                        // {
                                        createRow.CreateCell(curHeaderCellIndex);
                                        //  }

                                        curHeaderCellIndex++;
                                    }

                                }
                              /*  else
                                {
                                    throw (new Exception("BottomCellValues[j].CellMergeNum=！" + BottomCellValues[j].CellMergeNum + "& i=" + i));
                                }*/

                            }
                            

                          }
                      }
                }
            }
        }
            /// <summary>
            /// 插入数据行
            /// </summary>
            protected static void InsertRow(DataTable dtSource, HSSFWorkbook excelWorkbook)
        {
            int rowCount = hsRowCount;
            int sheetCount = 1;
            /*  if (hsRowCount > 0)
              {
                  sheetCount = hsRowCount + 1;
              }*/

          

            HSSFSheet newsheet = null;



            //循环数据源导出数据集
            newsheet = (HSSFSheet)excelWorkbook.CreateSheet("Sheet" + sheetCount);
            CreateHeader(newsheet, excelWorkbook);

           

            if (dtSource != null)
            {
                foreach (DataRow dr in dtSource.Rows)
                {
                    rowCount++;
                    //超出10000条数据 创建新的工作簿
                    if (rowCount == 10000)
                    {
                        rowCount = 1;
                        sheetCount++;
                        newsheet = (HSSFSheet)excelWorkbook.CreateSheet("Sheet" + sheetCount);
                        CreateHeader(newsheet, excelWorkbook);
                    }

                    HSSFRow newRow = (HSSFRow)newsheet.CreateRow(rowCount);
                    InsertCell(dtSource, dr, newRow, newsheet, excelWorkbook);
                }
            }
            CreateBottom(newsheet, excelWorkbook);

           /* for (int i = 0; i < dtSource.Columns.Count; i++)
            {
                newsheet.AutoSizeColumn(i);
            }*/

        }
        /// <summary>
        /// 导出数据行
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="drSource"></param>
        /// <param name="currentExcelRow"></param>
        /// <param name="excelSheet"></param>
        /// <param name="excelWorkBook"></param>
        protected static void InsertCell(DataTable dtSource, DataRow drSource, HSSFRow currentExcelRow, HSSFSheet excelSheet, HSSFWorkbook excelWorkBook)
        {
            for (int cellIndex = 0; cellIndex < Keys.Length; cellIndex++)
            {
                //列名称
                string columnsName = Keys[cellIndex];//ListColumnsName.GetKey(cellIndex).ToString();
                HSSFCell newCell = null;
                System.Type rowType = drSource[columnsName].GetType();
                string drValue = drSource[columnsName].ToString().Trim();
                switch (rowType.ToString())
                {
                    case "System.String"://字符串类型
                        drValue = drValue.Replace("&", "&");
                        drValue = drValue.Replace(">", ">");
                        drValue = drValue.Replace("<", "<");
                        newCell = (HSSFCell)currentExcelRow.CreateCell(cellIndex);

                     //   currentExcelRow.GetCell(cellIndex).CellStyle = style3;
                        newCell.SetCellValue(drValue);
                        break;
                    case "System.DateTime"://日期类型
                        DateTime dateV;
                        DateTime.TryParse(drValue, out dateV);
                        newCell = (HSSFCell)currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(dateV);

                        //格式化显示
                        HSSFCellStyle cellStyle = (HSSFCellStyle)excelWorkBook.CreateCellStyle();
                        HSSFDataFormat format = (HSSFDataFormat)excelWorkBook.CreateDataFormat();
                        cellStyle.DataFormat = format.GetFormat("yyyy-mm-dd hh:mm:ss");
                        newCell.CellStyle = cellStyle;

                        break;
                    case "System.Boolean"://布尔型
                        bool boolV = false;
                        bool.TryParse(drValue, out boolV);
                        newCell = (HSSFCell)currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue(boolV);
                        break;
                    case "System.Int16"://整型
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Byte":
                        int intV = 0;
                        int.TryParse(drValue, out intV);
                        newCell = (HSSFCell)currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                        newCell.SetCellValue(intV);
                        break;
                    case "System.Decimal"://浮点型
                    case "System.Double":
                        double doubV = 0;
                        double.TryParse(drValue, out doubV);
                        newCell = (HSSFCell)currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                        newCell.SetCellValue(doubV);
                        break;
                    case "System.DBNull"://空值处理
                        newCell = (HSSFCell)currentExcelRow.CreateCell(cellIndex);
                        newCell.SetCellValue("");
                        break;
                    default:
                        throw (new Exception(rowType.ToString() + "：类型数据无法处理!"));
                }
            }
        }
        
        /// <summary>
        /// Excel格式化为DataTable
        /// </summary>
        /// <param name="hssfworkbook"></param>
        /// <param name="sheetIndex"></param>
        /// <returns></returns>
        public static DataTable FormatToDatatable(HSSFWorkbook hssfworkbook, int sheetIndex)
        {
            DataTable dtPL = new DataTable();
            
            HSSFSheet sheet = (HSSFSheet)hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
           
            int rowIndex = 0;
            /*if (hsRowList != null && hsRowList.Count > 0)
            {
                rowIndex = hsRowList.Count;
            }*/
            while (rows.MoveNext())
            {
                HSSFRow row = (HSSFRow)rows.Current;

                if (rowIndex == 0)
                {
                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        //首行作为datatable的表头
                        HSSFCell cell = (HSSFCell)row.GetCell(i);
                        if (cell != null)
                        {
                            object obj = GetCellText(cell);
                            if (obj.ToString().Trim().Length == 0)
                            {
                                dtPL.Columns.Add("col" + i.ToString());
                            }
                            else
                            {
                                dtPL.Columns.Add(obj.ToString().Trim());
                            }
                        }
                    }
                }
                else
                {
                    DataRow dr = dtPL.NewRow();
                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        HSSFCell cell = (HSSFCell)row.GetCell(i);

                        if (dr.Table.Columns.Count > i)
                        {
                            if (cell == null)
                            {
                                dr[i] = null;
                            }
                            else
                            {
                                dr[i] = GetCellText(cell);
                            }
                        }

                    }
                    dtPL.Rows.Add(dr);
                }
                //递增变量
                rowIndex++;
            }
            return dtPL;
        }
        private static object GetCellText(HSSFCell cell)
        {
            object obj = new object();
            switch (cell.CellType)
            {
                case NPOI.SS.UserModel.CellType.Formula:
                    if (cell.CachedFormulaResultType == NPOI.SS.UserModel.CellType.Numeric)
                    {
                        obj = cell.NumericCellValue;
                    }
                    else if (cell.CachedFormulaResultType == NPOI.SS.UserModel.CellType.String)
                    {
                        obj = cell.RichStringCellValue;
                    }
                    else if (cell.CachedFormulaResultType == NPOI.SS.UserModel.CellType.Boolean)
                    {
                        obj = cell.BooleanCellValue;
                    }
                    else if (cell.CachedFormulaResultType == NPOI.SS.UserModel.CellType.Error)
                    {
                        obj = cell.ErrorCellValue;
                    }
                    else
                    {
                        obj = cell.ToString();
                    }
                    break;
                default:
                    obj = cell.ToString();
                    break;

            }

            return obj;
        }
        public static bool IsFileInUse(string fileName)
        {
            bool inUse = true;

            System.IO.FileStream fs = null;
            try
            {

                fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read,

                System.IO.FileShare.None);

                inUse = false;
            }
            catch
            {

            }
            finally
            {
                if (fs != null)

                    fs.Close();
            }
            return inUse;//true表示正在使用,false没有使用
        }
        public static DataTable FormatToDatatable(string filePath, int sheetIndex)
        {
            HSSFWorkbook hssfworkbook = null;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                 hssfworkbook = new HSSFWorkbook(file);
                


            }
            return FormatToDatatable(hssfworkbook, sheetIndex);
        }
        public static DataTable FormatToDatatable(string filePath, string sheetName)
        {
            HSSFWorkbook hssfworkbook = null;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            int sheetCount = hssfworkbook.Workbook.NumSheets;

            int sheetIndex = -1;
            for (int i = sheetCount; i < sheetCount; i++)
            {
                if (hssfworkbook.GetSheetName(i) == sheetName.Trim())
                {
                    sheetIndex = i;
                }
            }
            if (sheetIndex > 0)
            {
                return FormatToDatatable(hssfworkbook, sheetIndex);
            }
            else
            {
                return new DataTable();
            }
        }
        public static DataSet FormatToDatatable(string filePath)
        {
            HSSFWorkbook hssfworkbook = null;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            int sheetCount = hssfworkbook.Workbook.NumSheets;

            DataSet ds = new DataSet();
            for (int i = sheetCount; i < sheetCount; i++)
            {
                DataTable dt = FormatToDatatable(hssfworkbook, i);
                ds.Tables.Add(dt);
            }
            return ds;
        }
    }
    //排序实现接口 不进行排序 根据添加顺序导出
    public class NoSort : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            return -1;
        }
    }
    public class CellType
    {
        public string CellName;
        public int CellMergeNum;
        public int RowIndex;
        public bool Title=false;
        public bool IsCollect = false;


    }
  /*  public class ButtonType
    { 
        public string CellName;
        public int CellMergeNum;
        public int RowIndex;
    }*/
}
