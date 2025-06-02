using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibraryPharmacy1
{
    public class Medicine : IComparable<Medicine>
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        
        public readonly string ArticleNumber;
        public readonly MedicineDispensingType DispensingType;

        public Medicine(string articleNumber, string name, MedicineDispensingType dispensingType, string manufacturer)
        {
            if (string.IsNullOrWhiteSpace(articleNumber))
                throw new ArgumentException("Артикул не может быть пустым");
            
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название лекарства не может быть пустым");
            
            if (string.IsNullOrWhiteSpace(manufacturer))
                throw new ArgumentException("Производитель не может быть пустым");

            ArticleNumber = articleNumber;
            Name = name;
            DispensingType = dispensingType;
            Manufacturer = manufacturer;
            
            Price = 0;
            StockQuantity = 0;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[2];
            info[0] = $"{Name} ({ArticleNumber})";
            
            string dispensingTypeStr = DispensingType == MedicineDispensingType.Prescription ? 
                                      "по рецепту" : "без рецепта";
            
            info[1] = $"Производитель: {Manufacturer}. Тип отпуска: {dispensingTypeStr}. " +
                      $"Цена: {Price:C}. На складе: {StockQuantity} шт.";
            
            return info;
        }

        public int CompareTo(Medicine other)
        {
            if (other == null) return 1;
            
            int nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
            if (nameComparison != 0)
                return nameComparison;
                
            return Price.CompareTo(other.Price);
        }
    }

    public class MedicineArticleNumberComparer : IComparer<Medicine>
    {
        public int Compare(Medicine x, Medicine y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            
            return string.Compare(x.ArticleNumber, y.ArticleNumber, StringComparison.Ordinal);
        }
    }

    public class Tablets : Medicine
    {
        public int CountInPackage { get; set; }

        public Tablets(string articleNumber, string name, MedicineDispensingType dispensingType, 
                      string manufacturer, int countInPackage) 
            : base(articleNumber, name, dispensingType, manufacturer)
        {
            CountInPackage = countInPackage;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[3];
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"Форма: таблетки. Количество в упаковке: {CountInPackage} шт.";
            return info;
        }
    }

    public class Mixture : Medicine
    {
        public decimal BottleVolume { get; set; } // в мл

        public Mixture(string articleNumber, string name, MedicineDispensingType dispensingType, 
                      string manufacturer, decimal bottleVolume) 
            : base(articleNumber, name, dispensingType, manufacturer)
        {
            BottleVolume = bottleVolume;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[3];
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"Форма: микстура. Объем бутылки: {BottleVolume} мл.";
            return info;
        }
    }

    public class Ointment : Medicine
    {
        public decimal TubeVolume { get; set; } // в мг

        public Ointment(string articleNumber, string name, MedicineDispensingType dispensingType, 
                       string manufacturer, decimal tubeVolume) 
            : base(articleNumber, name, dispensingType, manufacturer)
        {
            TubeVolume = tubeVolume;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[3];
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"Форма: мазь. Объем тубы: {TubeVolume} мг.";
            return info;
        }
    }

    public class Pharmacy : IEnumerable<Medicine>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int MedicineCount => medicines.Count;

        private List<Medicine> medicines;

        public Pharmacy(string name, string address, IEnumerable<Medicine> medicinesCollection)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название аптеки не может быть пустым");
                
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Адрес аптеки не может быть пустым");

            Name = name;
            Address = address;
            medicines = new List<Medicine>();

            if (medicinesCollection != null)
            {
                foreach (var medicine in medicinesCollection)
                {
                    if (!medicines.Contains(medicine))
                    {
                        medicines.Add(medicine);
                    }
                }
            }
        }

        public IEnumerator<Medicine> GetEnumerator() => medicines.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}