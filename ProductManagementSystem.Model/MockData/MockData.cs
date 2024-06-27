using ProductManagementSystem.Model.Entities;

namespace ProductManagementSystem.Model.MockData
{
    public static class MockData
    {
        public static void CreateMockData(this EFContext Context)
        {
            // Создаем 20 пользователей
            var userNames = new List<string> { "Александр", "Иван", "Мария", "Елена", "Андрей", "Сергей", "Ольга", "Наталья", "Дмитрий", "Евгений", "Анна", "Екатерина", "Михаил", "Николай", "Владимир", "Татьяна", "Алексей", "Виктория", "Ирина", "Павел" };
            var userLastNames = new List<string> { "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов", "Попов", "Васильев", "Павлов", "Семенов", "Голубев", "Виноградов", "Богданов", "Воробьев", "Федоров", "Михайлов", "Беляев", "Тарасов", "Белов", "Козлов", "Лебедев" };

            for (int i = 0; i < userNames.Count; i++)
            {
                var user = new User()
                {
                    FirstName = userNames[i],
                    LastName = userLastNames[i],
                    Email = $"user{i + 1}@example.com",
                    Phone = $"+7 (999) 123-45-6{i + 1}",
                    Address = $"Улица {i + 1}, дом {i + 1}",
                    UserRole = UserRole.Admin,
                    Login = $"user{i + 1}",
                    Password = $"password{i + 1}",
                    Avatar = null // Добавьте ваш код для хранения аватаров
                };
                Context.Users.Add(user);
            }

            // Создаем 10 категорий продуктов
            var categoryNames = new List<string> { "Брюки", "Футболки", "Платья", "Джинсы", "Рубашки", "Юбки", "Куртки", "Пальто", "Свитера", "Пиджаки" };
            var categoryDescriptions = new List<string>
            {
                "Категория товаров - брюки.",
                "Категория товаров - футболки.",
                "Категория товаров - платья.",
                "Категория товаров - джинсы.",
                "Категория товаров - рубашки.",
                "Категория товаров - юбки.",
                "Категория товаров - куртки.",
                "Категория товаров - пальто.",
                "Категория товаров - свитера.",
                "Категория товаров - пиджаки."
            };

            var categories = new List<ProductCategory>();

            for (int i = 0; i < categoryNames.Count; i++)
            {
                var productCategory = new ProductCategory()
                {
                    Name = categoryNames[i],
                    Description = categoryDescriptions[i]
                };
                categories.Add(productCategory);
                Context.ProductCategories.Add(productCategory);
            }

            // Создаем 8 единиц измерения
            var unitMeasureNames = new List<string> { "Штука", "Пара", "Грамм", "Килограмм", "Метр", "Квадратный метр", "Кубический метр", "Сантиметр" };
            var unitMeasureDescriptions = new List<string>
            {
                "Единица измерения - штука.",
                "Единица измерения - пара.",
                "Единица измерения - грамм.",
                "Единица измерения - килограмм.",
                "Единица измерения - метр.",
                "Единица измерения - квадратный метр.",
                "Единица измерения - кубический метр.",
                "Единица измерения - сантиметр."
            };

            var unitMeasures = new List<UnitMeasure>();
            for (int i = 0; i < unitMeasureNames.Count; i++)
            {
                var unitMeasure = new UnitMeasure()
                {
                    Name = unitMeasureNames[i],
                    Description = unitMeasureDescriptions[i]
                };
                unitMeasures.Add(unitMeasure);
                Context.UnitMeasures.Add(unitMeasure);
            }

            // Создаем 20 продуктов
            var productNames = new List<string>
            {
                "Брюки спортивные",
                "Футболка хлопковая",
                "Платье вечернее",
                "Джинсы классические",
                "Рубашка с коротким рукавом",
                "Юбка мини-длины",
                "Куртка кожаная",
                "Пальто демисезонное",
                "Свитер с воротником",
                "Пиджак офисный",
                "Джемпер вязаный",
                "Шорты для плавания",
                "Блузка шифоновая",
                "Пиджак из шерсти",
                "Костюм спортивный",
                "Жакет классический",
                "Шарф шерстяной",
                "Платье повседневное",
                "Костюм тематический",
                "Шляпа летняя"
            };

            var productDescriptions = new List<string>
            {
                "Спортивные брюки для активного отдыха и занятий спортом.",
                "Хлопковая футболка с круглым вырезом и короткими рукавами.",
                "Вечернее платье из ткани с блестящим эффектом и глубоким декольте.",
                "Классические джинсы прямого кроя из денима с натуральным составом.",
                "Рубашка с короткими рукавами из легкого материала с принтом.",
                "Юбка мини-длины из эластичного материала с застежкой на молнию.",
                "Кожаная куртка с воротником-стойкой и двумя боковыми карманами.",
                "Демисезонное пальто с отложным воротником и поясом на талии.",
                "Свитер с воротником-стойкой из мягкого материала с крупной вязкой.",
                "Офисный пиджак прямого кроя из хлопковой ткани с двумя пуговицами.",
                "Джемпер вязаный с капюшоном и карманами из теплой пряжи.",
                "Шорты для плавания из быстросохнущего материала с подкладкой.",
                "Блузка шифоновая с V-образным вырезом и красивым принтом.",
                "Пиджак из шерстяной ткани с двубортной застежкой и классическим кроем.",
                "Спортивный костюм из трикотажа с капюшоном и брюками на резинке.",
                "Жакет классический с английским воротником и двумя карманами.",
                "Шерстяной шарф с крупной вязкой и косыми краями.",
                "Повседневное платье из хлопковой ткани с рукавами три четверти.",
                "Тематический костюм для праздничного мероприятия с ярким принтом.",
                "Летняя шляпа из натуральной соломы с широкими полями."
            };

            var categoryIds = categories.Select(c => c.Id).ToList();
            var unitIds = unitMeasures.Select(u => u.Id).ToList();

            for (int i = 0; i < 20; i++)
            {
                var product = new Product()
                {
                    Name = productNames[i],
                    Description = productDescriptions[i],
                    Price = (i + 1) * 24,
                    ProductCategory = categories.FirstOrDefault(p => p.Id == categoryIds[i % categoryIds.Count]),
                    UnitMeasure = unitMeasures.FirstOrDefault(u => u.Id == unitIds[i % unitIds.Count])
                };
                Context.Products.Add(product);
            }

            Context.SaveChanges();

        }
    }
}