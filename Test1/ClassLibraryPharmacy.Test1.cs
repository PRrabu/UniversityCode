using NUnit.Framework;
using ClassLibraryPharmacy1;
using System;

namespace ClassLibraryPharmacy1.UnitTests
{
    [TestFixture]
    public class MedicineUnitTests
    {
        [Test]
        public void Constructor_ValidParameters_CreatesMedicineWithCorrectProperties()
        {
            // Arrange
            string articleNumber = "MED123";
            string name = "Аспирин";
            MedicineDispensingType dispensingType = MedicineDispensingType.OverTheCounter;
            string manufacturer = "Bayer";

            // Act
            var medicine = new Medicine(articleNumber, name, dispensingType, manufacturer);

            // Assert
            Assert.That(medicine.ArticleNumber, Is.EqualTo(articleNumber));
            Assert.That(medicine.Name, Is.EqualTo(name));
            Assert.That(medicine.DispensingType, Is.EqualTo(dispensingType));
            Assert.That(medicine.Manufacturer, Is.EqualTo(manufacturer));
            Assert.That(medicine.Price, Is.EqualTo(0));
            Assert.That(medicine.StockQuantity, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_EmptyArticleNumber_ThrowsArgumentException()
        {
            // Arrange
            string articleNumber = "";
            string name = "Аспирин";
            MedicineDispensingType dispensingType = MedicineDispensingType.OverTheCounter;
            string manufacturer = "Bayer";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => 
                new Medicine(articleNumber, name, dispensingType, manufacturer));
            Assert.That(ex.Message, Does.Contain("Артикул не может быть пустым"));
        }

        [Test]
        public void Constructor_EmptyName_ThrowsArgumentException()
        {
            // Arrange
            string articleNumber = "MED123";
            string name = "";
            MedicineDispensingType dispensingType = MedicineDispensingType.OverTheCounter;
            string manufacturer = "Bayer";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => 
                new Medicine(articleNumber, name, dispensingType, manufacturer));
            Assert.That(ex.Message, Does.Contain("Название лекарства не может быть пустым"));
        }

        [Test]
        public void Constructor_EmptyManufacturer_ThrowsArgumentException()
        {
            // Arrange
            string articleNumber = "MED123";
            string name = "Аспирин";
            MedicineDispensingType dispensingType = MedicineDispensingType.OverTheCounter;
            string manufacturer = "";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => 
                new Medicine(articleNumber, name, dispensingType, manufacturer));
            Assert.That(ex.Message, Does.Contain("Производитель не может быть пустым"));
        }

        [Test]
        public void GetInfo_ReturnsCorrectInformation()
        {
            // Arrange
            var medicine = CreateTestMedicine();
            medicine.Price = 150.50m;
            medicine.StockQuantity = 25;

            // Act
            var info = medicine.GetInfo();

            // Assert
            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("Аспирин (MED123)"));
            Assert.That(info[1], Is.EqualTo("Производитель: Bayer. Тип отпуска: без рецепта. Цена: 150,50 ₽. На складе: 25 шт."));
        }

        [Test]
        public void UpdateStock_PositiveQuantity_IncreasesStock()
        {
            // Arrange
            var medicine = CreateTestMedicine();
            int initialQuantity = medicine.StockQuantity;
            int addedQuantity = 10;

            // Act
            medicine.UpdateStock(addedQuantity);

            // Assert
            Assert.That(medicine.StockQuantity, Is.EqualTo(initialQuantity + addedQuantity));
        }

        [Test]
        public void UpdateStock_NegativeQuantity_DecreasesStock()
        {
            // Arrange
            var medicine = CreateTestMedicine();
            medicine.StockQuantity = 20;
            int removedQuantity = -5;

            // Act
            medicine.UpdateStock(removedQuantity);

            // Assert
            Assert.That(medicine.StockQuantity, Is.EqualTo(15));
        }

        [Test]
        public void UpdateStock_NegativeQuantityExceedingStock_ThrowsInvalidOperationException()
        {
            // Arrange
            var medicine = CreateTestMedicine();
            medicine.StockQuantity = 5;
            int removedQuantity = -10;

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => 
                medicine.UpdateStock(removedQuantity));
            Assert.That(ex.Message, Does.Contain("Недостаточное количество на складе"));
        }

        private Medicine CreateTestMedicine()
        {
            return new Medicine("MED123", "Аспирин", MedicineDispensingType.OverTheCounter, "Bayer");
        }
    }
}