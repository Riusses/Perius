using Newtonsoft.Json;

namespace Perius.Models.ViewModels
{
    public class DTParameters
    {
        [JsonProperty("draw")]
        /// <summary>
        /// Draw counter. This is used by DataTables to ensure that the Ajax returns from 
        /// server-side processing requests are drawn in sequence by DataTables 
        /// </summary>
        public int Draw { get; set; }
        [JsonProperty("start")]
        /// <summary>
        /// Paging first record indicator. This is the start point in the current data set 
        /// (0 index based - i.e. 0 is the first record)
        /// </summary>
        public int Start { get; set; }
        [JsonProperty("length")]
        /// <summary>
        /// Number of records that the table can display in the current draw. It is expected
        /// that the number of records returned will be equal to this number, unless the 
        /// server has fewer records to return. Note that this can be -1 to indicate that 
        /// all records should be returned (although that negates any benefits of 
        /// server-side processing!)
        /// </summary>
        public int Length { get; set; }
        [JsonProperty("search")]
        /// <summary>
        /// Global Search for the table
        /// </summary>
        public DTSearch Search { get; set; }
        [JsonProperty("order")]
        /// <summary>
        /// Collection of all column indexes and their sort directions
        /// </summary>
        public IEnumerable<DTOrder> Order { get; set; }
        [JsonProperty("columns")]
        /// <summary>
        /// Collection of all columns in the table
        /// </summary>
        public IEnumerable<DTColumn> Columns { get; set; }
        [JsonProperty("data")]
        /// <summary>
        /// Dynamic data from mapped data.
        /// </summary>
        public dynamic? Data { get; set; }
        [JsonProperty("recordsFiltered")]
        /// <summary>
        /// Total records filtered from Data property.
        /// </summary>
        public int RecordsFiltered { get; set; }
        [JsonProperty("recordsTotal")]
        /// <summary>
        /// The total records from Data property.
        /// </summary>
        public int RecordsTotal { get; set; }
        [JsonProperty("parametros")]
        /// <summary>
        /// Custom parameters from any element of view.
        /// </summary>
        public List<dynamic>? CustomParameters { get; set; }

        public string SortOrder
        {
            get
            {
                return "Nombre";
            }
        }
    }

    /// <summary>
    /// Represents search values entered into the table
    /// </summary>
    public sealed class DTSearch
    {
        [JsonProperty("value")]
        /// <summary>
        /// Global search value. To be applied to all columns which have searchable as true
        /// </summary>
        public string Value { get; set; }
        [JsonProperty("regex")]
        /// <summary>
        /// true if the global filter should be treated as a regular expression for advanced 
        /// searching, false otherwise. Note that normally server-side processing scripts 
        /// will not perform regular expression searching for performance reasons on large 
        /// data sets, but it is technically possible and at the discretion of your script
        /// </summary>
        public bool Regex { get; set; }
    }

    /// <summary>
    /// Represents a column and it's order direction
    /// </summary>
    public sealed class DTOrder
    {
        [JsonProperty("column")]
        /// <summary>
        /// Column to which ordering should be applied. This is an index reference to the 
        /// columns array of information that is also submitted to the server
        /// </summary>
        public int Column { get; set; }
        [JsonProperty("dir")]
        /// <summary>
        /// Ordering direction for this column. It will be asc or desc to indicate ascending
        /// ordering or descending ordering, respectively
        /// </summary>
        public string Dir { get; set; }
    }

    /// <summary>
    /// Represents an individual column in the table
    /// </summary>
    public sealed class DTColumn
    {
        [JsonProperty("data")]
        /// <summary>
        /// Column's data source
        /// </summary>
        public string Data { get; set; }
        [JsonProperty("name")]
        /// <summary>
        /// Column's name
        /// </summary>
        public string Name { get; set; }
        [JsonProperty("orderable")]
        /// <summary>
        /// Flag to indicate if this column is orderable (true) or not (false)
        /// </summary>
        public bool Orderable { get; set; }
        [JsonProperty("searchable")]
        /// <summary>
        /// Flag to indicate if this column is searchable (true) or not (false)
        /// </summary>
        public bool Searchable { get; set; }
        [JsonProperty("search")]
        /// <summary>
        /// Search to apply to this specific column.
        /// </summary>
        public DTSearch Search { get; set; }
    }
}