using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExcelComparator
{
    public partial class Form1 : Form
    {
        #region -----   Declarations  -----

        private List<string> fileSet1;
        private List<string> fileSet2;

        #endregion

        #region -----   Constructor  -----

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region -----   UI  -----

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if old files are added
                if (fileSet1 == null || fileSet1.Count == 0)
                {
                    MessageBox.Show("Please add old files to compare.", "Unable to Compare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if new files are added
                if (fileSet2 == null || fileSet2.Count == 0)
                {
                    MessageBox.Show("Please add new files to compare.", "Unable to Compare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if files are equal
                if (fileSet1.Count != fileSet2.Count)
                {
                    MessageBox.Show("Please add an equal number of old and new files to compare.", "Unable to Compare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // If folder does not exist, select folder
                if (!Directory.Exists(textBoxFolder.Text))
                {
                    buttonSelectFolder_Click(sender, e);
                }

                // If folder exists, compare files
                if (Directory.Exists(textBoxFolder.Text))
                {
                    ExcelCompare excelComparator = new ExcelCompare();
                    excelComparator.CompareExcelFileSet(fileSet1, fileSet2, textBoxFolder.Text);

                    MessageBox.Show("Files are compared successfully", "Comparison Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonAdd1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
                    openFileDialog.Title = "Select Excel Files";
                    openFileDialog.Multiselect = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileSet1 = AddToFilesList(fileSet1, openFileDialog.FileNames.ToList());
                        UpdateList1();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
                    openFileDialog.Title = "Select Excel Files";
                    openFileDialog.Multiselect = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileSet2 = AddToFilesList(fileSet2, openFileDialog.FileNames.ToList());
                        UpdateList2();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                // Select folder to save the result
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.Description = "Select Folder to Save Result";
                    folderBrowserDialog.ShowNewFolderButton = true;

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        textBoxFolder.Text = folderBrowserDialog.SelectedPath;
                        textBoxFolder.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemove1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndices.Count > 0 && fileSet1 != null)
                {
                    int selectedIndex = listBox1.SelectedIndex;
                    var reverseIndices = listBox1.SelectedIndices.Cast<int>().OrderByDescending(i => i).ToList();

                    foreach (int sIdx in reverseIndices)
                    {
                        fileSet1.RemoveAt(sIdx);
                    }

                    UpdateList1();
                    listBox1.SelectedIndex = fileSet1.Count > selectedIndex ? selectedIndex : fileSet1.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemove2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox2.SelectedIndices.Count > 0 && fileSet2 != null)
                {
                    int selectedIndex = listBox2.SelectedIndex;
                    var reverseIndices = listBox2.SelectedIndices.Cast<int>().OrderByDescending(i => i).ToList();

                    foreach (int sIdx in reverseIndices)
                    {
                        fileSet2.RemoveAt(sIdx);
                    }

                    UpdateList2();
                    listBox2.SelectedIndex = fileSet2.Count > selectedIndex ? selectedIndex : fileSet2.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUp1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndices.Count > 0 && fileSet1 != null)
                {
                    var selectedIndices = listBox1.SelectedIndices.Cast<int>().ToList();

                    // Get control index
                    int controlIndex = GetControlIndex(selectedIndices);

                    // Update fileset
                    fileSet1 = UpdateFileSet(fileSet1, selectedIndices, controlIndex);

                    // Update list
                    UpdateList1();

                    int startIndex = selectedIndices[0] - 1;
                    startIndex = startIndex < 0 ? 0 : startIndex;

                    // Set selected list
                    SetSelectedList1(startIndex, selectedIndices.Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDown1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndices.Count > 0 && fileSet1 != null)
                {
                    // Clone selected indices using cast
                    var selectedIndices = listBox1.SelectedIndices.Cast<int>().ToList();

                    // Reverse order of selected indices
                    var reverseIndices = GetReversedIndices(fileSet1, selectedIndices);

                    // Get control index
                    int controlIndex = GetControlIndex(reverseIndices);

                    // Reverse order of fileset
                    fileSet1.Reverse();

                    // Update fileset
                    fileSet1 = UpdateFileSet(fileSet1, reverseIndices, controlIndex);

                    // Unreverse order of fileset
                    fileSet1.Reverse();

                    // Update list
                    UpdateList1();

                    int startIndex = selectedIndices.Last() + 1;
                    startIndex = startIndex >= fileSet1.Count ? fileSet1.Count - 1 : startIndex;

                    // Set selected list
                    SetSelectedList1(startIndex, reverseIndices.Count, -1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUp2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox2.SelectedIndices.Count > 0 && fileSet2 != null)
                {
                    var selectedIndices = listBox2.SelectedIndices.Cast<int>().ToList();

                    // Get control index
                    int controlIndex = GetControlIndex(selectedIndices);

                    // Update fileset
                    fileSet2 = UpdateFileSet(fileSet2, selectedIndices, controlIndex);

                    // Update list
                    UpdateList2();

                    int startIndex = selectedIndices[0] - 1;
                    startIndex = startIndex < 0 ? 0 : startIndex;

                    // Set selected list
                    SetSelectedList2(startIndex, selectedIndices.Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDown2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox2.SelectedIndices.Count > 0 && fileSet2 != null)
                {
                    // Clone selected indices using cast
                    var selectedIndices = listBox2.SelectedIndices.Cast<int>().ToList();

                    // Reverse order of selected indices
                    var reverseIndices = GetReversedIndices(fileSet2, selectedIndices);

                    // Get control index
                    int controlIndex = GetControlIndex(reverseIndices);

                    // Reverse order of fileset
                    fileSet2.Reverse();

                    // Update fileset
                    fileSet2 = UpdateFileSet(fileSet2, reverseIndices, controlIndex);

                    // Unreverse order of fileset
                    fileSet2.Reverse();

                    // Update list
                    UpdateList2();

                    int startIndex = selectedIndices.Last() + 1;
                    startIndex = startIndex >= fileSet2.Count ? fileSet2.Count - 1 : startIndex;

                    // Set selected list
                    SetSelectedList2(startIndex, reverseIndices.Count, -1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region -----   Events  -----

        private void Form1_Resize(object sender, EventArgs e)
        {
            int margin = 21;
            int clientWidth = ClientSize.Width - margin;

            groupBox1.Width = clientWidth / 2 - margin;
            groupBox2.Width = clientWidth / 2 - margin;

            groupBox2.Location = new System.Drawing.Point(groupBox1.Right + margin, groupBox2.Location.Y);
        }

        #endregion

        #region -----   Functionality  -----

        private List<string> AddToFilesList(List<string> existingFileNames, List<string> openFileNames)
        {
            if (existingFileNames == null)
            {
                existingFileNames = new List<string>();
            }

            foreach (var fileName in openFileNames)
            {
                if (!existingFileNames.Contains(fileName))
                {
                    existingFileNames.Add(fileName);
                }
            }

            return existingFileNames;

        }

        private void UpdateList1()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = fileSet1;
        }

        private void UpdateList2()
        {
            listBox2.DataSource = null;
            listBox2.DataSource = fileSet2;
        }

        private void SetSelectedList1(int startIndex, int selectedIndicesCount, int sign = 1)
        {
            listBox1.ClearSelected();

            for (int i = 0; i < selectedIndicesCount; i++)
            {
                listBox1.SetSelected(startIndex + i * sign, true);
            }
        }

        private void SetSelectedList2(int startIndex, int selectedIndicesCount, int sign = 1)
        {
            listBox2.ClearSelected();

            for (int i = 0; i < selectedIndicesCount; i++)
            {
                listBox2.SetSelected(startIndex + i * sign, true);
            }
        }

        private List<string> MoveFileUp(List<string> files, int selectedIndex, int controlIndex)
        {
            var newListFiles = new List<string>();
            newListFiles.AddRange(files);

            while (selectedIndex - 1 > controlIndex)
            {
                string temp = newListFiles[selectedIndex];
                newListFiles[selectedIndex] = newListFiles[selectedIndex - 1];
                newListFiles[selectedIndex - 1] = temp;
                selectedIndex--;
            }

            return newListFiles;
        }

        private int GetControlIndex(List<int> selectedIndices)
        {
            int selectedIndex = selectedIndices[0];
            int countIndices = selectedIndices.Count;

            int controlIndex;

            if (selectedIndex == 0)
            {
                int idx = 0;
                controlIndex = selectedIndices[idx + 1];

                while (controlIndex - selectedIndices[idx] == 1)
                {
                    idx++;

                    if (idx + 1 == countIndices)
                    {
                        break;
                    }

                    controlIndex = selectedIndices[idx + 1];

                }

                controlIndex = selectedIndices[idx];
            }
            else
            {
                controlIndex = selectedIndex - 2;
            }

            return controlIndex;
        }

        private List<string> UpdateFileSet(List<string> fileSet, List<int> selectedIndices, int controlIndex)
        {
            for (int i = 0; i < selectedIndices.Count; i++)
            {
                int sIdx = selectedIndices[i];

                if (sIdx > controlIndex)
                {
                    fileSet = MoveFileUp(fileSet, sIdx, controlIndex);
                    controlIndex++;
                }
            }

            return fileSet;
        }

        private List<int> GetReversedIndices(List<string> fileSet, List<int> selectedIndices)
        {
            var reverseIndices = new List<int>();

            foreach (int idx in selectedIndices)
            {
                reverseIndices.Add(fileSet.Count - 1 - idx);
            }

            reverseIndices.Reverse();

            return reverseIndices;
        }

        #endregion
    }
}
