using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string  Artist { get; set; }

        public AlbumType Type { get; set; }

        public int Stock { get; set; }

        public string Label { get; set; }

    }

    public enum AlbumType
    {
        vinyl=1,
        CD=2
    }
}
