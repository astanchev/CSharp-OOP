namespace Class_Box
{
    using System;
    using System.Text;
    public class Box
    {
        private decimal length;
        private decimal width;
        private decimal height;

        public Box(decimal length, decimal width, decimal height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }
        public decimal Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }
        public decimal Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }


        public decimal GetSurfaceArea()
        {
            decimal area = 2 * (this.Length * this.Width) + this.GetLateralSurfaceArea();

            return area;
        }
        public decimal GetLateralSurfaceArea()
        {
            decimal lateralArea = 2 * (this.Length * this.Height) + 2 * (this.Height * this.Width);

            return lateralArea;
        }
        public decimal GetVolume()
        {
            decimal volume = this.Length * this.Width * this.Height;

            return volume;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Surface Area - {this.GetSurfaceArea():f2}");
            result.AppendLine($"Lateral Surface Area - {this.GetLateralSurfaceArea():f2}");
            result.AppendLine($"Volume - {this.GetVolume():f2}");

            return result.ToString().TrimEnd();
        }
    }
}