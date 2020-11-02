using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Rectangle : IEquatable<Rectangle>
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public Rectangle(int width,int length)
        {
            this.Width = width;
            this.Length = length;
        }
        public int GetArea()
        {
            return this.Width * this.Length;
        }
        public override bool Equals(Object obj)
        {
            var other = obj as Rectangle;
            if (other == null) return false;

            return Equals(other);
        }
        public bool Equals(Rectangle other)
        {
            return (this.Length == other.Length && this.Width == other.Width);

        }
    }
}
