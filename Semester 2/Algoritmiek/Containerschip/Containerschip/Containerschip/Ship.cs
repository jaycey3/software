using System.Collections.Generic;

namespace Containerschip
{
    public class Ship
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public List<Row> Rows { get; set; }

        public Ship(int width, int length)
        {
            Width = width;
            Length = length;
            List<Row> rows = new List<Row>();
            
            for (int i = 0; i < length; i++)
            {
                Row row = new Row(i, width);
                rows.Add(row);
            }

            Rows = rows;
        }
    }
}
