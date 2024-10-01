using OfficeOpenXml;
using OfficeOpenXml.Table;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExcelComparator
{
    internal class ExcelCompare
    {
        List<string> SummaryErrors;
        List<string> SummaryChanges;
        string FolderPath;
        string File1Name;
        string File2Name;

        public ExcelCompare()
        {
            // Ensure license for EPPlus is agreed upon
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void CompareExcelFileSet(List<string> file1Paths, List<string> file2Paths, string folderPath)
        {
            FolderPath = folderPath;

            // Compare file sets
            for (int i = 0; i < file1Paths.Count; i++)
            {
                string file1Path = file1Paths[i];
                string file2Path = file2Paths[i];

                File1Name = Path.GetFileName(file1Path);
                File2Name = Path.GetFileName(file2Path);

                var outfileName = File2Name.Replace(".xlsx", "_compared.xlsx");

                var outputFilePath = Path.Combine(FolderPath, outfileName);

                CompareExcelFiles(file1Path, file2Path, outputFilePath);
            }
        }

        private void CompareExcelFiles(string file1Path, string file2Path, string outputFilePath)
        {
            SummaryErrors = new List<string>();
            SummaryChanges = new List<string>();

            // Load the two workbooks
            using (ExcelPackage package1 = new ExcelPackage(new FileInfo(file1Path)))
            using (ExcelPackage package2 = new ExcelPackage(new FileInfo(file2Path)))
            using (ExcelPackage outputPackage = new ExcelPackage(new FileInfo(file2Path)))
            {
                ExcelWorkbook workbook1 = package1.Workbook;
                ExcelWorkbook workbook2 = package2.Workbook;
                ExcelWorkbook outputWorkbook = outputPackage.Workbook;

                if (outputWorkbook.Worksheets.Count > 0)
                {
                    // Add unique tables from worksheet1 and worksheet2
                    var worksheetNames = new List<string>();
                    worksheetNames.AddRange(workbook1.Worksheets.Select(t => t.Name));
                    worksheetNames.AddRange(workbook2.Worksheets.Select(t => t.Name));
                    worksheetNames = worksheetNames.Distinct().ToList();

                    foreach (var worksheetName in worksheetNames)
                    {
                        ExcelWorksheet outputWorksheet = outputWorkbook.Worksheets[worksheetName];
                        ExcelWorksheet worksheet1 = workbook1.Worksheets[worksheetName];
                        ExcelWorksheet worksheet2 = workbook2.Worksheets[worksheetName];

                        if (worksheet1 == null)
                        {
                            // worksheet1 of file1 does not exist
                            SummaryErrors.Add($"[Worksheet Does Not Exist] Worksheet: {worksheetName}, does not exist in File: {File1Name}");
                            continue;
                        }

                        if (worksheet2 == null)
                        {
                            // worksheet2 of file2 does not exist
                            SummaryErrors.Add($"[Worksheet Does Not Exist] Worksheet: {worksheetName} does not exist in File: {File2Name}");
                            continue;
                        }


                        if (outputWorksheet.Hidden == eWorkSheetHidden.Visible)
                        {
                            CompareExcelWorksheets(worksheet1, worksheet2, outputWorksheet);
                        }
                    }

                    // Save the output file
                    outputPackage.SaveAs(new FileInfo(outputFilePath));

                    var summaryfileName = File2Name.Replace(".xlsx", "_log.txt");
                    var summaryFilePath = Path.Combine(FolderPath, summaryfileName);

                    // Combine the summary errors and changes
                    var SummaryLog = new List<string>();

                    SummaryLog.Add($"Summary Change Log");

                    if (SummaryChanges.Count == 0)
                    {
                        SummaryChanges.Add("No changes found");
                    }

                    SummaryLog.AddRange(SummaryChanges);

                    if (SummaryErrors.Count > 0)
                    {
                        // Add a line break
                        SummaryLog.Add("");
                        SummaryLog.Add("");

                        SummaryLog.Add($"Summary Error Log");
                        SummaryLog.AddRange(SummaryErrors);
                    }

                    File.WriteAllLines(summaryFilePath, SummaryLog);
                }

            }

        }

        private void CompareExcelWorksheets(ExcelWorksheet worksheet1, ExcelWorksheet worksheet2, ExcelWorksheet outputWorksheet)
        {
            if (worksheet1 != null && worksheet2 != null)
            {
                // Add unique tables from worksheet1 and worksheet2
                var tables = new List<string>();
                tables.AddRange(worksheet1.Tables.Select(t => t.Name));
                tables.AddRange(worksheet2.Tables.Select(t => t.Name));
                tables = tables.Distinct().ToList();

                foreach (var tableName in tables)
                {
                    ExcelTable outputTable = outputWorksheet.Tables[tableName];
                    ExcelTable table1 = worksheet1.Tables[tableName];
                    ExcelTable table2 = worksheet2.Tables[tableName];

                    if (table1 == null)
                    {
                        // table1 in worksheet1 of file1 does not exist
                        SummaryErrors.Add($"[Table Does Not Exist] Table: {tableName}, of Worksheet: {worksheet1.Name}, does not exist in File: {File1Name}");
                        continue;
                    }

                    if (table2 == null)
                    {
                        // table2 in worksheet2 of file2 does not exist
                        SummaryErrors.Add($"[Table Does Not Exist] Table: {tableName}, of Worksheet: {worksheet2.Name}, does not exist in File: {File2Name}");
                        continue;
                    }

                    CompareExcelTables(table1, table2, outputTable);

                }
            }

        }

        private void CompareExcelTables(ExcelTable table1, ExcelTable table2, ExcelTable outputTable)
        {
            if (table1 != null && table2 != null)
            {
                int i2 = table2.Address.Start.Row - 1;

                for (int i = table1.Address.Start.Row; i <= table1.Address.End.Row; i++)
                {
                    i2++;

                    int j2 = table2.Address.Start.Column - 1;

                    for (int j = table1.Address.Start.Column; j <= table1.Address.End.Column; j++)
                    {
                        j2++;

                        var cell1 = table1.WorkSheet.Cells[i, j];
                        var cell2 = table2.WorkSheet.Cells[i2, j2];

                        var outputCell = outputTable.WorkSheet.Cells[i2, j2];

                        if (cell1.Value == null)
                        {
                            // cell1 in table1 in worksheet of file1 does not exist
                            SummaryErrors.Add($"[Value Does Not Exist] Value in Cell: {cell1.Address}, of Table: {table1.Name}, in Worksheet: {table1.WorkSheet.Name} does not exist in File: {File1Name}");
                            continue;
                        }

                        if (cell2.Value == null)
                        {
                            // cell2 in table2 in worksheet of file2 does not exist
                            SummaryErrors.Add($"[Value Does Not Exist] Value in Cell: {cell2.Address}, of Table: {table2.Name}, in Worksheet: {table2.WorkSheet.Name}, does not exist in File: {File2Name}");
                            continue;
                        }

                        if (!cell1.Value.Equals(cell2.Value))
                        {
                            // value in cell1 is different from value in cell2 in table in worksheet
                            SummaryChanges.Add($"[Value Changed] Value in Cell: {cell1.Address}, of Table: {table1.Name}, in Worksheet: {table1.WorkSheet.Name} is different from value in Cell: {cell2.Address}, of Table: {table2.Name}, in Worksheet: {table2.WorkSheet.Name}");
                            outputCell.Value = cell2.Value;
                            outputCell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            outputCell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Tomato);
                        }
                    }
                }
            }
        }

    }
}