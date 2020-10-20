using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace JieXi.Common
{
    public class CostumeRetailAnalysisDetailExporter
    {
        public  String[] Keys = null;
        public  String[] Values = null;
        public void ExportExcel(int type, String excelTempPath, String ReportFileName, string shopName, string dateStr, DataTable dtSource)
        {
            HSSFWorkbook workbook = null;
            //读取Excel模板
            using (FileStream fs = new FileStream(excelTempPath, FileMode.Open, FileAccess.Read))
            {
                workbook = new HSSFWorkbook(fs);
            }

            if (type == 0)
            {
                InsertRow(shopName, dateStr, dtSource, workbook);
            }
            else if (type == 1)
            {
                InsertRow1(shopName, dateStr, dtSource, workbook);
            }
            else if (type == 2)
            {
                InsertRow1(shopName, dateStr, dtSource, workbook);
            }
            else if (type == 3)
            {
                InsertRow3(shopName, dateStr, dtSource, workbook);
            }

            SaveExcelFile(workbook, ReportFileName);
            //table
        }

        /// <summary>
        /// 创建excel表头
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="excelSheet"></param>
        private  void CreateHeader(HSSFSheet excelSheet)
        {
            int cellIndex = 0;
            //建立第一行，表示表头
            HSSFRow newRow = (HSSFRow)excelSheet.CreateRow(0);
            //循环导出列
            foreach (var value in Values)
            {
                HSSFCell newCell = (HSSFCell)newRow.CreateCell(cellIndex);
                newCell.SetCellValue(value);
                cellIndex++;
            }
        }

        /// <summary>
        /// 插入数据行
        /// </summary>
        private void InsertRow(String shopName, String dateStr, DataTable dtSource, HSSFWorkbook excelWorkbook)
        {
            int sheetCount = 1;
            ISheet sheet = excelWorkbook.GetSheetAt(0);//表示在模板的第一个工作簿里写入
            IRow shopRow = sheet.GetRow(1);
            //遍历模板行
            IRow tableHeaderRow = sheet.GetRow(2);
            //样式行
            IRow tableStyleRow = sheet.GetRow(3);
            shopRow.Cells[2].SetCellValue(shopName);
            shopRow.Cells[6].SetCellValue(dateStr);
            int rowCount = sheet.PhysicalNumberOfRows - 1;
            int i = 0;
            foreach (DataRow dr in dtSource.Rows)
            {
                IRow newRow = null;
                if (i == 0)
                {
                    newRow = tableStyleRow;
                    i++;
                }
                else
                {
                    //  第一次使用tableStyleRow
                    rowCount++;
                    //超出10000条数据 创建新的工作簿
                    if (rowCount == 10000)
                    {
                        rowCount = 1;
                        sheetCount++;
                        sheet = (HSSFSheet)excelWorkbook.CreateSheet("Sheet" + sheetCount);
                        IRow newHeaderRow = sheet.CreateRow(0);
                        CopyRow(tableHeaderRow, newHeaderRow);
                        //  CreateHeader(newsheet);
                    }

                    // HSSFRow newRow //= (HSSFRow)sheet.CreateRow(rowCount);
                    newRow = tableStyleRow.CopyRowTo(rowCount);

                    // CopyRow(tableStyleRow, newRow);
                }
                InsertCell(dtSource, dr, newRow, sheet, excelWorkbook);
            }
            rowCount++;
            if (rowCount != 10000)
            {
                IRow newRow = tableStyleRow.CopyRowTo(rowCount);
                newRow.Cells[0].SetCellValue(String.Empty);
                newRow.Cells[1].SetCellValue(String.Empty);
                newRow.Cells[2].SetCellValue(String.Empty);
                newRow.Cells[3].SetCellValue(String.Empty);
                newRow.Cells[4].SetCellValue(String.Empty);
                newRow.Cells[5].SetCellFormula("sum(F4:F" + (rowCount) + ")");
                newRow.Cells[6].SetCellFormula("sum(G4:G" + (rowCount) + ")");
            }
        }

        /// <summary>
        /// 插入数据行
        /// </summary>
        private void InsertRow1(String shopName, String dateStr,DataTable dtSource, HSSFWorkbook excelWorkbook)
        {
            int sheetCount = 1; 


            ISheet  sheet = excelWorkbook.GetSheetAt(0);//表示在模板的第一个工作簿里写入
           // IRow headerRow = sheet.CreateRow(0);
            IRow shopRow = sheet.GetRow(1);
            //遍历模板行
            IRow tableHeaderRow = sheet.GetRow(2);
            //样式行
            IRow tableStyleRow = sheet.GetRow(3); 
            shopRow.Cells[2].SetCellValue(shopName);
            shopRow.Cells[5].SetCellValue(dateStr);


            int rowCount = sheet.PhysicalNumberOfRows-1;
            //CreateHeader(newsheet);

            int i = 0; 
            foreach (DataRow dr in dtSource.Rows)
            {
                IRow newRow = null;
                if (i == 0) {
                    newRow = tableStyleRow;
                    i++;
                } else { 
              //  第一次使用tableStyleRow
                rowCount++;
                //超出10000条数据 创建新的工作簿
                if (rowCount == 10000)
                {
                    rowCount = 1;
                    sheetCount++;
                    sheet = (HSSFSheet)excelWorkbook.CreateSheet("Sheet" + sheetCount);
                    IRow newHeaderRow = sheet.CreateRow(0); 
                    CopyRow(tableHeaderRow, newHeaderRow);
                  //  CreateHeader(newsheet);
                }

                    // HSSFRow newRow //= (HSSFRow)sheet.CreateRow(rowCount);
                    newRow = tableStyleRow.CopyRowTo(rowCount);

                    // CopyRow(tableStyleRow, newRow);
                }
                InsertCell2(dtSource, dr, newRow, sheet, excelWorkbook);
            }
            rowCount++;
            if (rowCount != 10000)
            {
                IRow newRow = tableStyleRow.CopyRowTo(rowCount);
                newRow.Cells[0].SetCellValue(String.Empty);
                newRow.Cells[1].SetCellValue(String.Empty);
                newRow.Cells[2].SetCellValue(String.Empty);
                newRow.Cells[3].SetCellValue(String.Empty);
                newRow.Cells[4].SetCellFormula("sum(E4:E"+ (rowCount)+ ")");
                newRow.Cells[5].SetCellFormula("sum(F4:F" + (rowCount) + ")");
            } 
        }




        private void InsertRow3(String shopName, String dateStr, DataTable dtSource, HSSFWorkbook excelWorkbook)
        {
            int sheetCount = 1;


            ISheet sheet = excelWorkbook.GetSheetAt(0);//表示在模板的第一个工作簿里写入
                                                       // IRow headerRow = sheet.CreateRow(0);
            IRow shopRow = sheet.GetRow(1);
            //遍历模板行
            IRow tableHeaderRow = sheet.GetRow(2);
            //样式行
            IRow tableStyleRow = sheet.GetRow(3);
            shopRow.Cells[2].SetCellValue(shopName);
            shopRow.Cells[4].SetCellValue(dateStr);


            int rowCount = sheet.PhysicalNumberOfRows - 1;
            //CreateHeader(newsheet);

            int i = 0;
            foreach (DataRow dr in dtSource.Rows)
            {
                IRow newRow = null;
                if (i == 0)
                {
                    newRow = tableStyleRow;
                    i++;
                }
                else
                {
                    //  第一次使用tableStyleRow
                    rowCount++;
                    //超出10000条数据 创建新的工作簿
                    if (rowCount == 10000)
                    {
                        rowCount = 1;
                        sheetCount++;
                        sheet = (HSSFSheet)excelWorkbook.CreateSheet("Sheet" + sheetCount);
                        IRow newHeaderRow = sheet.CreateRow(0);
                        CopyRow(tableHeaderRow, newHeaderRow);
                        //  CreateHeader(newsheet);
                    }

                    // HSSFRow newRow //= (HSSFRow)sheet.CreateRow(rowCount);
                    newRow = tableStyleRow.CopyRowTo(rowCount);

                    // CopyRow(tableStyleRow, newRow);
                }
                InsertCell3(dtSource, dr, newRow, sheet, excelWorkbook);
            }
            rowCount++;
            if (rowCount != 10000)
            {
                IRow newRow = tableStyleRow.CopyRowTo(rowCount);
                newRow.Cells[0].SetCellValue(String.Empty);
                newRow.Cells[1].SetCellValue(String.Empty);
                newRow.Cells[2].SetCellValue(String.Empty); 
                newRow.Cells[3].SetCellFormula("sum(D4:D" + (rowCount) + ")");
                newRow.Cells[4].SetCellFormula("sum(E4:E" + (rowCount) + ")");
            }
        }

        private void InsertCell3(DataTable dtSource, DataRow drSource, IRow currentExcelRow, ISheet excelSheet, HSSFWorkbook excelWorkBook)
        { ///品牌
            string drValue = drSource[Keys[0]].ToString().Trim();
            HSSFCell newCell = null;
            newCell = (HSSFCell)currentExcelRow.GetCell(0);
            newCell.SetCellValue(drValue);
            ///款号
            drValue = drSource[Keys[1]].ToString().Trim();
            newCell = (HSSFCell)currentExcelRow.GetCell(1);
            newCell.SetCellValue(drValue);
            ///商品名称
            drValue = drSource[Keys[2]].ToString().Trim();
            newCell = (HSSFCell)currentExcelRow.GetCell(2);
            newCell.SetCellValue(drValue); 
            //数量
            int intV = 0;
            drValue = drSource[Keys[3]].ToString().Trim();
            int.TryParse(drValue, out intV);
            newCell = (HSSFCell)currentExcelRow.GetCell(3);
            newCell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
            newCell.SetCellValue(intV);
            //金额
            double decV = 0;
            drValue = drSource[Keys[4]].ToString().Trim();
            double.TryParse(drValue, out decV);
            newCell = (HSSFCell)currentExcelRow.GetCell(4);
            newCell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
            newCell.SetCellValue(decV);
        }
         
       private void InsertCell2(DataTable dtSource, DataRow drSource, IRow currentExcelRow, ISheet excelSheet, HSSFWorkbook excelWorkBook)
        { ///品牌
            string drValue = drSource[Keys[0]].ToString().Trim();
            HSSFCell newCell = null;
            newCell = (HSSFCell)currentExcelRow.GetCell(0);
            newCell.SetCellValue(drValue);
            ///款号
            drValue = drSource[Keys[1]].ToString().Trim();
            newCell = (HSSFCell)currentExcelRow.GetCell(1);
            newCell.SetCellValue(drValue);
            ///商品名称
            drValue = drSource[Keys[2]].ToString().Trim();
            newCell = (HSSFCell)currentExcelRow.GetCell(2);
            newCell.SetCellValue(drValue);
            ///颜色
            drValue = drSource[Keys[3]].ToString().Trim();

            newCell = (HSSFCell)currentExcelRow.GetCell(3);
            newCell.SetCellValue(drValue);
            //数量
            int intV = 0;
            drValue = drSource[Keys[4]].ToString().Trim();
            int.TryParse(drValue, out intV);
            newCell = (HSSFCell)currentExcelRow.GetCell(4);
            newCell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
            newCell.SetCellValue(intV);
            //金额
            double decV = 0;
            drValue = drSource[Keys[5]].ToString().Trim();
            double.TryParse(drValue, out decV);
            newCell = (HSSFCell)currentExcelRow.GetCell(5);
            newCell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
            newCell.SetCellValue(decV);
        }
         

        private void InsertCell(DataTable dtSource, DataRow drSource, IRow currentExcelRow, ISheet excelSheet, HSSFWorkbook excelWorkBook)
        { ///品牌
            string drValue = drSource[Keys[0]].ToString().Trim();
            HSSFCell newCell = null;
            newCell = (HSSFCell)currentExcelRow.GetCell(0);
            newCell.SetCellValue(drValue);
            ///款号
              drValue = drSource[Keys[1]].ToString().Trim();
            newCell = (HSSFCell)currentExcelRow.GetCell(1);
            newCell.SetCellValue(drValue);
            ///商品名称
              drValue = drSource[Keys[2]].ToString().Trim();
            newCell = (HSSFCell)currentExcelRow.GetCell(2);
            newCell.SetCellValue(drValue);
            ///颜色
              drValue = drSource[Keys[3]].ToString().Trim();
           
            newCell = (HSSFCell)currentExcelRow.GetCell(3);
            newCell.SetCellValue(drValue);
            ///尺码
            drValue = drSource[Keys[4]].ToString().Trim();
             
            newCell = (HSSFCell)currentExcelRow.GetCell(4);
            newCell.SetCellValue(drValue);
            //数量
            int intV = 0;
            drValue = drSource[Keys[5]].ToString().Trim();
            int.TryParse(drValue, out intV);
            newCell = (HSSFCell)currentExcelRow.GetCell(5);
            newCell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
            newCell.SetCellValue(intV);
            //金额
            double decV = 0; 
            drValue = drSource[Keys[6]].ToString().Trim();
            double.TryParse(drValue, out decV);
            newCell = (HSSFCell)currentExcelRow.GetCell(6);
            newCell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
            newCell.SetCellValue(decV);
        }
            /// <summary>
            /// 导出数据行
            /// </summary>
            /// <param name="dtSource"></param>
            /// <param name="drSource"></param>
            /// <param name="currentExcelRow"></param>
            /// <param name="excelSheet"></param>
            /// <param name="excelWorkBook"></param>
        //    private  void InsertCell(DataTable dtSource, DataRow drSource, IRow currentExcelRow, ISheet excelSheet, HSSFWorkbook excelWorkBook)
        //{
        //    for (int cellIndex = 0; cellIndex < Keys.Length; cellIndex++)
        //    {
        //        //列名称
        //        string columnsName = Keys[cellIndex];//ListColumnsName.GetKey(cellIndex).ToString();
        //        HSSFCell newCell = null;
        //        System.Type rowType = drSource[columnsName].GetType();
        //        string drValue = drSource[columnsName].ToString().Trim();
        //        switch (rowType.ToString())
        //        {
        //            case "System.String"://字符串类型
        //                drValue = drValue.Replace("&", "&");
        //                drValue = drValue.Replace(">", ">");
        //                drValue = drValue.Replace("<", "<");
        //                newCell = (HSSFCell)currentExcelRow.GetCell(cellIndex);
        //                newCell.SetCellValue(drValue);
        //                break;
        //            case "System.DateTime"://日期类型
        //                DateTime dateV;
        //                DateTime.TryParse(drValue, out dateV);
        //                newCell = (HSSFCell)currentExcelRow.GetCell(cellIndex);
        //                newCell.SetCellValue(dateV);

        //                //格式化显示
        //                HSSFCellStyle cellStyle = (HSSFCellStyle)excelWorkBook.CreateCellStyle();
        //                HSSFDataFormat format = (HSSFDataFormat)excelWorkBook.CreateDataFormat();
        //                cellStyle.DataFormat = format.GetFormat("yyyy-mm-dd hh:mm:ss");
        //                newCell.CellStyle = cellStyle;

        //                break;
        //            case "System.Boolean"://布尔型
        //                bool boolV = false;
        //                bool.TryParse(drValue, out boolV);
        //              newCell = (HSSFCell)currentExcelRow.GetCell(cellIndex);
        //                newCell.SetCellValue(boolV);
        //                break;
        //            case "System.Int16"://整型
        //            case "System.Int32":
        //            case "System.Int64":
        //            case "System.Byte":
        //                int intV = 0;
        //                int.TryParse(drValue, out intV);
        //             newCell = (HSSFCell)currentExcelRow.GetCell(cellIndex);
        //              //  newCell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
        //                newCell.SetCellValue(intV);
        //                break;
        //            case "System.Decimal"://浮点型
        //            case "System.Double":
        //                double doubV = 0;
        //                double.TryParse(drValue, out doubV);
        //                 newCell = (HSSFCell)currentExcelRow.GetCell(cellIndex);
        //              //  newCell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
        //                newCell.SetCellValue(doubV);
        //                break;
        //            case "System.DBNull"://空值处理
        //                newCell = (HSSFCell)currentExcelRow.GetCell(cellIndex);
        //                newCell.SetCellValue("");
        //                break;
        //            default:
        //                throw (new Exception(rowType.ToString() + "：类型数据无法处理!"));
        //        }
        //    }
        //}
        private void CopyRow(IRow sourceRow, IRow newRow) {
           
            ICell oldCell = null;
            ICell newCell = null;
            for (int m = sourceRow.FirstCellNum; m < sourceRow.LastCellNum; m++)
            {
                oldCell = sourceRow.GetCell(m);
                if (oldCell == null)
                    continue;
                newCell = newRow.CreateCell(m);
                 
                newCell.CellStyle = oldCell.CellStyle;
                newCell.SetCellType(oldCell.CellType);

            }
        }

        /// <summary>
        /// 保存Excel文件
        /// </summary>
        /// <param name="excelWorkBook"></param>
        /// <param name="filePath"></param>
        private void SaveExcelFile(HSSFWorkbook excelWorkBook, string filePath)
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
    }
}
