namespace ComplexAlgebra
{
    using System;

    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {

        public Complex(double real, double im)
        {
            Real = real;
            Imaginary = im;
        }
        public double Real { get; }

        public double Imaginary { get; }

        public Complex Complement() => new Complex(Real, -Imaginary);
        
        public double Phase => (Imaginary != 0) ? Math.Atan(Imaginary / Real) : 0.0;

        public double Modulus => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));

        public Complex Plus(Complex c) => new Complex(Real + c.Real, Imaginary + c.Imaginary);

        public Complex Minus(Complex c) => new Complex(Real - c.Real, Imaginary - c.Imaginary);

        public override string ToString()
        {
            if (Imaginary == 0) return Real.ToString();
            else
            {
                if (Real == 0)
                {
                    return string.Concat(Imaginary.ToString() + "i");
                }
            }
            return string.Concat(Real.ToString() + Sign() + Imaginary.ToString() + "i");
        }

        protected bool Equals(Complex c) => Real.Equals(c.Real) && Imaginary.Equals(c.Imaginary);
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Complex) obj);
        }

        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);

        private string Sign() => (Imaginary >= 0) ? "+" : "";
    }
}