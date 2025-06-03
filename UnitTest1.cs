using System;
using NUnit.Framework;
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
                throw new ArgumentException("Объект для сравнения не является комплексным числом");
            
            ComplexTr other = (ComplexTr)obj;
            
            if (Abs == 0 && other.Abs == 0) return true;
            
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

    [TestFixture]
    public class ComplexTrTests
    {
        [Test]
        public void Constructor_NegativeAbs_ThrowsArgumentException()
        {
            Assert.That(() => new ComplexTr(-1, 0), Throws.ArgumentException);
        }
        
        [Test]
        public void Re_CalculatedCorrectly()
        {
            var num = new ComplexTr(2, Math.PI/3);
            Assert.That(num.Re, Is.EqualTo(1).Within(1e-13));
        }
        
        [Test]
        public void Im_CalculatedCorrectly()
        {
            var num = new ComplexTr(2, Math.PI/3);
            Assert.That(num.Im, Is.EqualTo(Math.Sqrt(3)).Within(1e-13));
        }
        
        [TestCase(0, 0, "0")]
        [TestCase(1, 1.5, "cos(1.5) + i sin(1.5)")]
        [TestCase(2.5, -0.3, "2.5(cos(-0.3) + i sin(-0.3))")]
        public void ToString_ReturnsCorrectFormat(double abs, double arg, string expected)
        {
            var num = new ComplexTr(abs, arg);
            Assert.That(num.ToString(), Is.EqualTo(expected));
        }
        
        [TestCase(2, 1.5, 2, 1.5, true)]
        [TestCase(2, 1.5, 2, 1.5 + 2*Math.PI, true)]
        [TestCase(2, 1.5, 2, 2.5, false)]
        [TestCase(2, 1.5, 3, 1.5, false)]
        [TestCase(0, 0, 0, 0, true)]
        public void Equals_TwoComplexNumbers_ExpectedResult(double abs1, double arg1, double abs2, double arg2, bool expected)
        {
            var num1 = new ComplexTr(abs1, arg1);
            var num2 = new ComplexTr(abs2, arg2);
            Assert.That(num1.Equals(num2), Is.EqualTo(expected));
        }
        
        [Test]
        public void Equals_WrongArgument_ThrowsArgumentException()
        {
            var num = new ComplexTr(1, 0);
            var obj = new object();
            Assert.That(() => num.Equals(obj), Throws.ArgumentException);
        }
        
        [Test]
        public void GetHashCode_EqualNumbers_SameHashCode()
        {
            var num1 = new ComplexTr(2, 1.5);
            var num2 = new ComplexTr(2, 1.5 + 2*Math.PI);
            Assert.That(num1.GetHashCode(), Is.EqualTo(num2.GetHashCode()));
        }
        
        [Test]
        public void Multiplication_ReturnsCorrectResult()
        {
            var num1 = new ComplexTr(2, 1);
            var num2 = new ComplexTr(3, 2);
            var result = num1 * num2;
            
            Assert.That(result.Abs, Is.EqualTo(6).Within(1e-13));
            Assert.That(result.Arg, Is.EqualTo(3).Within(1e-13));
        }
        
        [Test]
        public void Division_ReturnsCorrectResult()
        {
            var num1 = new ComplexTr(6, 3);
            var num2 = new ComplexTr(2, 1);
            var result = num1 / num2;
            
            Assert.That(result.Abs, Is.EqualTo(3).Within(1e-13));
            Assert.That(result.Arg, Is.EqualTo(2).Within(1e-13));
        }
        
        [Test]
        public void Division_ByZero_ThrowsDivideByZeroException()
        {
            var num1 = new ComplexTr(1, 0);
            var num2 = new ComplexTr(0, 0);
            Assert.That(() => num1 / num2, Throws.TypeOf<DivideByZeroException>());
        }
        
        [Test]
        public void ComparisonOperators_WorkCorrectly()
        {
            var num1 = new ComplexTr(2, 1.5);
            var num2 = new ComplexTr(2, 1.5 + 2*Math.PI);
            var num3 = new ComplexTr(3, 1.5);
            
            Assert.That(num1 == num2, Is.True);
            Assert.That(num1 != num2, Is.False);
            Assert.That(num1 == num3, Is.False);
            Assert.That(num1 != num3, Is.True);
        }
    }
}