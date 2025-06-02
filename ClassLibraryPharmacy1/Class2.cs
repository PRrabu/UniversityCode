using System;

namespace ClassLibraryPharmacy1;

    public class Medicine
    {
        // Свойства
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

        public void UpdateStock(int quantity)
        {
            if (StockQuantity + quantity < 0)
                throw new InvalidOperationException("Недостаточное количество на складе");
            
            StockQuantity += quantity;
        }
    }