using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_ivity.Models
{
        public class GridVM<T> {
            /// <summary>
            /// List of entries in a grid
            /// </summary>
            public List<T> Entries { get; set; }
            /// <summary>
            /// New entry model in a grid
            /// </summary>
            public T NewEntry { get; set; }

            /// <summary>
            /// Default constructor
            /// </summary>
            public GridVM() {
                NewEntry = (T)Activator.CreateInstance(typeof(T));
                Entries = new List<T>();
            }
        }
}