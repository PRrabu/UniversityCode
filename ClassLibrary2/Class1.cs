using System;
using System.Globalization;

namespace ComplexNumbers
{
    public struct ComplexTr
    {
        private const double TwoPI = 2 * Math.PI;
        
        public double Abs { get; }
        public double Arg { get; }
        
        public double Re => Abs * Math.Cos(Arg);
        public double Im => Abs * Math.Sin(Arg);
        
        public ComplexTr(double abs, double arg)
        {
            if (abs < 0)
                throw new ArgumentException("Модуль числа не может быть отрицательным");
                
            Abs = abs;
            Arg = arg;
        }
        
        public override string ToString()
        {
            if (Abs == 0) return "0";
            
            string absPart = Abs == 1 ? "" : $"{Abs.ToString("G", CultureInfo.InvariantCulture)}(";
            string endPart = Abs == 1 ? "" : ")";
            
            return $"{absPart}cos({Arg.ToString("G", CultureInfo.InvariantCulture)}) + i sin({Arg.ToString("G", CultureInfo.InvariantCulture)}){endPart}";
        }
        
        public override bool Equals(object obj)
        {
            if (!(obj is ComplexTr)) 
                return false;
            
            ComplexTr other = (ComplexTr)obj;
            
            if (Abs == 0 && other.Abs == 0) 
                return true;
            
            return Math.Abs(Abs - other.Abs) < 1e-13 && 
                   Math.Abs((Arg - other.Arg) % TwoPI) < 1e-13;
        }
        
        public override int GetHashCode()
        {
            return HashCode.Combine(Math.Round(Abs, 13), Math.Round(Arg % TwoPI, 13));
        }
        
        public static ComplexTr operator *(ComplexTr a, ComplexTr b)
        {
            return new ComplexTr(a.Abs * b.Abs, a.Arg + b.Arg);
        }
        
        public static ComplexTr operator /(ComplexTr a, ComplexTr b)
        {
            if (b.Abs == 0)
                throw new DivideByZeroException("Деление на нулевое комплексное число невозможно");
                
            return new ComplexTr(a.Abs / b.Abs, a.Arg - b.Arg);
        }
        
        public static bool operator ==(ComplexTr a, ComplexTr b) => a.Equals(b);
        public static bool operator !=(ComplexTr a, ComplexTr b) => !a.Equals(b);
    }
}