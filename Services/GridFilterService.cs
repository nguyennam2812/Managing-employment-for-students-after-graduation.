using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using QuanLySinhVien.Dialogs;

namespace QuanLySinhVien.Services
{
    public class GridFilterService<T> where T : class
    {
        private DataGridView _grid;
        private List<T> _originalData;
        private ContextMenuStrip _contextMenu;
        private int _currentColumnIndex = -1;
        private Dictionary<string, string> _columnFilters = new Dictionary<string, string>(); // ColumnDataPropertyName -> FilterValue

        public GridFilterService(DataGridView grid)
        {
            _grid = grid;
            _grid.ColumnHeaderMouseClick += Grid_ColumnHeaderMouseClick;
            InitializeContextMenu();
        }

        public void SetData(List<T> data)
        {
            _originalData = data;
            
            // Disable default sorting to handle click ourselves
            foreach (DataGridViewColumn col in _grid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }

            ApplyFiltersAndSort(); 
        }

        private void InitializeContextMenu()
        {
            _contextMenu = new ContextMenuStrip();
            
            var sortAscItem = new ToolStripMenuItem("Sắp xếp A-Z (Tăng dần)");
            sortAscItem.Click += SortAsc_Click;
            _contextMenu.Items.Add(sortAscItem);

            var sortDescItem = new ToolStripMenuItem("Sắp xếp Z-A (Giảm dần)");
            sortDescItem.Click += SortDesc_Click;
            _contextMenu.Items.Add(sortDescItem);

            _contextMenu.Items.Add(new ToolStripSeparator());

            var filterItem = new ToolStripMenuItem("Lọc theo giá trị...");
            filterItem.Click += Filter_Click;
            _contextMenu.Items.Add(filterItem);

            var clearFilterItem = new ToolStripMenuItem("Bỏ lọc cột này");
            clearFilterItem.Click += ClearFilter_Click;
            _contextMenu.Items.Add(clearFilterItem);

            var clearAllFiltersItem = new ToolStripMenuItem("Bỏ lọc tất cả");
            clearAllFiltersItem.Click += ClearAllFilters_Click;
            _contextMenu.Items.Add(clearAllFiltersItem);
        }

        private void Grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Handle both Left and Right click to show menu
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                _currentColumnIndex = e.ColumnIndex;
                if (_currentColumnIndex >= 0)
                {
                    _contextMenu.Show(Cursor.Position);
                }
            }
        }

        private void SortAsc_Click(object sender, EventArgs e)
        {
            Sort(false);
        }

        private void SortDesc_Click(object sender, EventArgs e)
        {
            Sort(true);
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            if (_currentColumnIndex < 0) return;
            var col = _grid.Columns[_currentColumnIndex];
            var propName = col.DataPropertyName;
            
            if (string.IsNullOrEmpty(propName))
            {
                MessageBox.Show("Cột này không hỗ trợ lọc (không có DataPropertyName).");
                return;
            }

            string currentVal = _columnFilters.ContainsKey(propName) ? _columnFilters[propName] : "";
            string input = InputBox.Show($"Nhập giá trị lọc cho cột '{col.HeaderText}':", "Lọc dữ liệu", currentVal);
            
            if (input != null) // User clicked OK (even if empty, treat as clear or empty filter?)
            {
                // If empty input, maybe remove filter? Or filter for empty? 
                // Typically "Filter..." implies "Contains". If empty, maybe remove.
                if (string.IsNullOrWhiteSpace(input))
                {
                    if (_columnFilters.ContainsKey(propName)) 
                        _columnFilters.Remove(propName);
                }
                else
                {
                    _columnFilters[propName] = input;
                }
                ApplyFiltersAndSort();
            }
        }

        private void ClearFilter_Click(object sender, EventArgs e)
        {
            if (_currentColumnIndex < 0) return;
            var col = _grid.Columns[_currentColumnIndex];
            var propName = col.DataPropertyName;

            if (!string.IsNullOrEmpty(propName) && _columnFilters.ContainsKey(propName))
            {
                _columnFilters.Remove(propName);
                ApplyFiltersAndSort();
            }
        }

        private void ClearAllFilters_Click(object sender, EventArgs e)
        {
            _columnFilters.Clear();
            ApplyFiltersAndSort();
        }

        private void ApplyFiltersAndSort()
        {
            if (_originalData == null) return;

            IEnumerable<T> query = _originalData;

            // 1. Apply Filters
            foreach (var kvp in _columnFilters)
            {
                var propName = kvp.Key;
                var filterValue = kvp.Value.ToLower();

                query = query.Where(item =>
                {
                    var prop = typeof(T).GetProperty(propName);
                    if (prop == null) return true; // Property not found, ignore

                    var val = prop.GetValue(item);
                    return val != null && val.ToString().ToLower().Contains(filterValue);
                });
            }

            // 2. Sort? (Basic sorting is usually handled by DataGridView if datasource is BindingList, 
            // but for List<T>, we might need to re-order logic.
            // However, the standard behavior for List<T> bound to grid is... no auto sort.
            // If user clicked Sort from context menu, we should apply sort here too?
            // To simplify, let's just make the "Sort" context menu do a one-time sort.
            
            // Re-assign data
            _grid.DataSource = query.ToList();
            
            // Visual feedback? Update column headers to show filter icon?
            // Complex for standard DGV. Let's just rely on result.
            // Optional: change header text
            foreach (DataGridViewColumn col in _grid.Columns)
            {
                if (!string.IsNullOrEmpty(col.DataPropertyName) && _columnFilters.ContainsKey(col.DataPropertyName))
                {
                    if (!col.HeaderText.EndsWith(" (*)"))
                        col.HeaderText += " (*)";
                }
                else
                {
                    if (col.HeaderText.EndsWith(" (*)"))
                        col.HeaderText = col.HeaderText.Substring(0, col.HeaderText.Length - 4);
                }
            }
        }

        private void Sort(bool descending)
        {
            if (_currentColumnIndex < 0 || _grid.DataSource == null) return;
            var col = _grid.Columns[_currentColumnIndex];
            var propName = col.DataPropertyName;
            if (string.IsNullOrEmpty(propName)) return;

            var list = _grid.DataSource as List<T>;
            if (list == null) return; // Should be List<T>

            if (descending)
            {
                list = list.OrderByDescending(x => GetPropValue(x, propName)).ToList();
            }
            else
            {
                list = list.OrderBy(x => GetPropValue(x, propName)).ToList();
            }
            _grid.DataSource = list;
        }

        private object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName)?.GetValue(src, null);
        }
    }
}
