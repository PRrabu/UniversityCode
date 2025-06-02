using NUnit.Framework;
using ClassLibraryPharmacy1;
using System.Collections.Generic;

namespace ClassLibraryPharmacy1.Tests
{
    [TestFixture]
    public class TabletsUnitTests
    {
        private Tablets GetTestTablets()
        {
            var tablets = new Tablets("TAB123", "Парацетамол", MedicineDispensingType.OverTheCounter, 
                                   "Фармстандарт", 20);
            tablets.Price = 120.75m;
            tablets.StockQuantity = 15;
            return tablets;
        }

        [Test]
        public void Constructor_ValidParameters_CreatesTabletsWithCorrectProperties()
        {
            var tablets = GetTestTablets();

            Assert.That(tablets.ArticleNumber, Is.EqualTo("TAB123"));
            Assert.That(tablets.Name, Is.EqualTo("Парацетамол"));
            Assert.That(tablets.DispensingType, Is.EqualTo(MedicineDispensingType.OverTheCounter));
            Assert.That(tablets.Manufacturer, Is.EqualTo("Фармстандарт"));
            Assert.That(tablets.CountInPackage, Is.EqualTo(20));
        }

        [Test]
        public void GetInfo_Tablets_ReturnsThreeStringInfo()
        {
            var tablets = GetTestTablets();
            var expectedLines = new[] 
            {
                "Парацетамол (TAB123)",
                "Производитель: Фармстандарт. Тип отпуска: без рецепта. Цена: 120,75 ₽. На складе: 15 шт.",
                "Форма: таблетки. Количество в упаковке: 20 шт."
            };

            var info = tablets.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));
            for (var i = 0; i < info.Length; i++)
            {
                Assert.That(info[i], Is.EqualTo(expectedLines[i]));
            }
        }
    }

    [TestFixture]
    public class MixtureUnitTests
    {
        private Mixture GetTestMixture()
        {
            var mixture = new Mixture("MIX456", "Сироп от кашля", MedicineDispensingType.Prescription, 
                                    "Биохимик", 100.5m);
            mixture.Price = 245.30m;
            mixture.StockQuantity = 8;
            return mixture;
        }

        [Test]
        public void Constructor_ValidParameters_CreatesMixtureWithCorrectProperties()
        {
            var mixture = GetTestMixture();

            Assert.That(mixture.ArticleNumber, Is.EqualTo("MIX456"));
            Assert.That(mixture.Name, Is.EqualTo("Сироп от кашля"));
            Assert.That(mixture.DispensingType, Is.EqualTo(MedicineDispensingType.Prescription));
            Assert.That(mixture.Manufacturer, Is.EqualTo("Биохимик"));
            Assert.That(mixture.BottleVolume, Is.EqualTo(100.5m));
        }

        [Test]
        public void GetInfo_Mixture_ReturnsThreeStringInfo()
        {
            var mixture = GetTestMixture();
            var expectedLines = new[] 
            {
                "Сироп от кашля (MIX456)",
                "Производитель: Биохимик. Тип отпуска: по рецепту. Цена: 245,30 ₽. На складе: 8 шт.",
                "Форма: микстура. Объем бутылки: 100,5 мл."
            };

            var info = mixture.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));
            for (var i = 0; i < info.Length; i++)
            {
                Assert.That(info[i], Is.EqualTo(expectedLines[i]));
            }
        }
    }

    [TestFixture]
    public class OintmentUnitTests
    {
        private Ointment GetTestOintment()
        {
            var ointment = new Ointment("OIN789", "Троксевазин", MedicineDispensingType.OverTheCounter, 
                                      "Балканфарма", 40);
            ointment.Price = 320.00m;
            ointment.StockQuantity = 12;
            return ointment;
        }

        [Test]
        public void Constructor_ValidParameters_CreatesOintmentWithCorrectProperties()
        {
            var ointment = GetTestOintment();

            Assert.That(ointment.ArticleNumber, Is.EqualTo("OIN789"));
            Assert.That(ointment.Name, Is.EqualTo("Троксевазин"));
            Assert.That(ointment.DispensingType, Is.EqualTo(MedicineDispensingType.OverTheCounter));
            Assert.That(ointment.Manufacturer, Is.EqualTo("Балканфарма"));
            Assert.That(ointment.TubeVolume, Is.EqualTo(40));
        }

        [Test]
        public void GetInfo_Ointment_ReturnsThreeStringInfo()
        {
            var ointment = GetTestOintment();
            var expectedLines = new[] 
            {
                "Троксевазин (OIN789)",
                "Производитель: Балканфарма. Тип отпуска: без рецепта. Цена: 320,00 ₽. На складе: 12 шт.",
                "Форма: мазь. Объем тубы: 40 мг."
            };

            var info = ointment.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));
            for (var i = 0; i < info.Length; i++)
            {
                Assert.That(info[i], Is.EqualTo(expectedLines[i]));
            }
        }
    }

    [TestFixture]
    public class MedicineComparableTests
    {
        [Test]
        public void CompareTo_Medicine_SortsByNameThenByPrice()
        {
            var medicine1 = new Tablets("TAB001", "Аспирин", MedicineDispensingType.OverTheCounter, "Bayer", 10) { Price = 100 };
            var medicine2 = new Tablets("TAB002", "Парацетамол", MedicineDispensingType.OverTheCounter, "Фармстандарт", 20) { Price = 120 };
            var medicine3 = new Tablets("TAB003", "Аспирин", MedicineDispensingType.OverTheCounter, "Bayer", 10) { Price = 150 };

            Assert.That(medicine1.CompareTo(medicine2), Is.LessThan(0));
            Assert.That(medicine1.CompareTo(medicine3), Is.LessThan(0));
            Assert.That(medicine1.CompareTo(medicine1), Is.EqualTo(0));
            Assert.That(medicine1.CompareTo(null), Is.GreaterThan(0));
        }
    }

    [TestFixture]
    public class MedicineArticleNumberComparerTests
    {
        [Test]
        public void Compare_Medicine_SortsByArticleNumber()
        {
            var comparer = new MedicineArticleNumberComparer();
            var medicine1 = new Tablets("TAB001", "Аспирин", MedicineDispensingType.OverTheCounter, "Bayer", 10);
            var medicine2 = new Tablets("TAB002", "Парацетамол", MedicineDispensingType.OverTheCounter, "Фармстандарт", 20);
            var medicine3 = new Tablets("TAB003", "Ибупрофен", MedicineDispensingType.OverTheCounter, "Bayer", 15);

            Assert.That(comparer.Compare(medicine1, medicine2), Is.LessThan(0));
            Assert.That(comparer.Compare(medicine2, medicine3), Is.LessThan(0));
            Assert.That(comparer.Compare(medicine1, medicine1), Is.EqualTo(0));
            Assert.That(comparer.Compare(medicine1, null), Is.GreaterThan(0));
        }
    }

    [TestFixture]
    public class PharmacyTests
    {
        private List<Medicine> GetTestMedicines()
        {
            var medicines = new List<Medicine>();
            
            var tablets = new Tablets("TAB123", "Парацетамол", MedicineDispensingType.OverTheCounter, "Фармстандарт", 20);
            tablets.Price = 120.75m;
            medicines.Add(tablets);

            var mixture = new Mixture("MIX456", "Сироп от кашля", MedicineDispensingType.Prescription, "Биохимик", 100.5m);
            mixture.Price = 245.30m;
            medicines.Add(mixture);

            var ointment = new Ointment("OIN789", "Троксевазин", MedicineDispensingType.OverTheCounter, "Балканфарма", 40);
            ointment.Price = 320.00m;
            medicines.Add(ointment);

            return medicines;
        }

        [Test]
        public void Constructor_ValidParameters_CreatesPharmacyWithCorrectProperties()
        {
            var medicines = GetTestMedicines();
            
            var pharmacy = new Pharmacy("Аптека №1", "ул. Ленина, 10", medicines);

            Assert.That(pharmacy.Name, Is.EqualTo("Аптека №1"));
            Assert.That(pharmacy.Address, Is.EqualTo("ул. Ленина, 10"));
            Assert.That(pharmacy.MedicineCount, Is.EqualTo(3));
        }

        [Test]
        public void Constructor_DuplicateMedicines_AddsOnlyUniqueMedicines()
        {
            var medicines = GetTestMedicines();
            medicines.Add(medicines[0]);

            var pharmacy = new Pharmacy("Аптека №1", "ул. Ленина, 10", medicines);

            Assert.That(pharmacy.MedicineCount, Is.EqualTo(3));
        }

        [Test]
        public void IEnumerable_Pharmacy_CanBeUsedInForEach()
        {
            var medicines = GetTestMedicines();
            var pharmacy = new Pharmacy("Аптека №1", "ул. Ленина, 10", medicines);
            var collectedMedicines = new List<Medicine>();

            foreach (var medicine in pharmacy)
            {
                collectedMedicines.Add(medicine);
            }

            Assert.That(collectedMedicines.Count, Is.EqualTo(3));
            Assert.That(collectedMedicines, Is.EquivalentTo(medicines));
        }
    }
}