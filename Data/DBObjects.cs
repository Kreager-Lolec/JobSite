using JobSite.Data.Models;
namespace JobSite.Data
{
    public class DBObjects
    {
        public static void Initial(ApplicationDbContext content)
        {
            try
            {
                if (!content.Categories.Any())
                    content.Categories.AddRange(Categories.Select(c => c.Value));

                if (!content.Solutes.Any())
                    content.Solutes.AddRange(Solutes.Select(c => c.Value));

                if (!content.Vehicles.Any())
                    content.Vehicles.AddRange(Vehicles.Select(c => c.Value));

                if (!content.Deliveries.Any())
                {
                    content.AddRange(
                        new Delivery()
                        {
                            name = "Доставка по місту",
                            isFavourite = false,
                            type = "По місту",
                            CaterogyGood = Categories["Доставка"],
                            Vehicle = Vehicles["Самосвал"],
                            price = 400,
                        },
                        new Delivery()
                        {
                            name = "Доставка по місту",
                            isFavourite = false,
                            type = "По місту",
                            CaterogyGood = Categories["Доставка"],
                            Vehicle = Vehicles["Міксер"],
                            price = 500,
                        },
                        new Delivery()
                        {
                            name = "Доставка поза містом",
                            isFavourite = false,
                            type = "Поза містом",
                            CaterogyGood = Categories["Доставка"],
                            Vehicle = Vehicles["Самосвал"],
                            price = 500,
                            distance = 15,
                        },
                        new Delivery()
                        {
                            name = "Доставка поза містом",
                            isFavourite = false,
                            type = "Поза містом",
                            CaterogyGood = Categories["Доставка"],
                            Vehicle = Vehicles["Міксер"],
                            price = 600,
                            distance = 15,
                        },
                        new Delivery()
                        {
                            name = "Доставка поза містом",
                            isFavourite = false,
                            type = "Поза містом",
                            CaterogyGood = Categories["Доставка"],
                            Vehicle = Vehicles["Самосвал"],
                            price = 600,
                            distance = 20,
                        },
                        new Delivery()
                        {
                            name = "Доставка поза містом",
                            isFavourite = false,
                            type = "Поза містом",
                            CaterogyGood = Categories["Доставка"],
                            Vehicle = Vehicles["Міксер"],
                            price = 750,
                            distance = 20,
                        },
                        new Delivery()
                        {
                            name = "Доставка поза містом",
                            isFavourite = false,
                            type = "Поза містом",
                            CaterogyGood = Categories["Доставка"],
                            Vehicle = Vehicles["Самосвал"],
                            price = 700,
                            distance = 25,
                        },
                        new Delivery()
                        {
                            name = "Доставка поза містом",
                            isFavourite = false,
                            type = "Поза містом",
                            CaterogyGood = Categories["Доставка"],
                            Vehicle = Vehicles["Міксер"],
                            price = 850,
                            distance = 25,
                        },
                        new Delivery()
                        {
                            name = "Доставка поза містом",
                            isFavourite = false,
                            type = "Поза містом",
                            CaterogyGood = Categories["Доставка"],
                            Vehicle = Vehicles["Самосвал"],
                            price = 800,
                            distance = 30,
                        },
                        new Delivery()
                        {
                            name = "Доставка поза містом",
                            isFavourite = false,
                            type = "Поза містом",
                            CaterogyGood = Categories["Доставка"],
                            Vehicle = Vehicles["Міксер"],
                            price = 900,
                            distance = 30,
                        },
                        new Delivery()
                        {
                            name = "Доставка поза містом",
                            isFavourite = false,
                            type = "Поза містом",
                            CaterogyGood = Categories["Доставка"],
                            Vehicle = Vehicles["Самосвал"],
                            price = 900,
                            distance = 35,
                        },
                        new Delivery()
                        {
                            name = "Доставка поза містом",
                            isFavourite = false,
                            type = "Поза містом",
                            CaterogyGood = Categories["Доставка"],
                            Vehicle = Vehicles["Міксер"],
                            price = 1000,
                            distance = 35,
                        },
                        new Delivery()
                        {
                            name = "Доставка поза містом",
                            isFavourite = false,
                            type = "Поза містом",
                            CaterogyGood = Categories["Доставка"],
                            Vehicle = Vehicles["Самосвал"],
                            price = 1000,
                            distance = 40,
                        },
                        new Delivery()
                        {
                            name = "Доставка поза містом",
                            isFavourite = false,
                            type = "Поза містом",
                            CaterogyGood = Categories["Доставка"],
                            Vehicle = Vehicles["Міксер"],
                            price = 1200,
                            distance = 40,
                        }
                        );
                }
                content.SaveChanges();
                if (!content.BuildingMaterials.Any())
                {
                    content.AddRange(
                        new BuildingMaterial
                        {
                            name = "Розчин вапняний",
                            available = true,
                            mark = "4",
                            Caterogy = Categories["Розчин"],
                            isFavourite = false,
                            price = 900,
                            img = "/img/Solute Lime/SoluteLime4.png",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Вапняний"],
                        },
                        new BuildingMaterial
                        {
                            name = "Розчин складний",
                            available = true,
                            mark = "25",
                            Caterogy = Categories["Розчин"],
                            isFavourite = false,
                            price = 1000,
                            img = "/img/Solute Mix/SoluteMix25.png",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Складний"],
                        },
                        new BuildingMaterial
                        {
                            name = "Розчин складний",
                            available = true,
                            mark = "50",
                            Caterogy = Categories["Розчин"],
                            isFavourite = false,
                            price = 1100,
                            img = "/img/Solute Mix/SoluteMix50.png",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Складний"],
                        },
                        new BuildingMaterial
                        {
                            name = "Розчин складний",
                            available = true,
                            mark = "75",
                            Caterogy = Categories["Розчин"],
                            isFavourite = false,
                            price = 1300,
                            img = "/img/Solute Mix/SoluteMix75.png",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Складний"],
                        },
                        new BuildingMaterial
                        {
                            name = "Розчин складний",
                            available = true,
                            mark = "100",
                            Caterogy = Categories["Розчин"],
                            isFavourite = false,
                            price = 1400,
                            img = "/img/Solute Mix/SoluteMix100.png",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Складний"],
                        },
                        new BuildingMaterial
                        {
                            name = "Розчин цементний",
                            available = true,
                            mark = "25",
                            Caterogy = Categories["Розчин"],
                            isFavourite = false,
                            price = 1000,
                            img = "/img/Solute Cement/SoluteCement25.png",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Цементний"],
                        },
                        new BuildingMaterial
                        {
                            name = "Розчин цементний",
                            available = true,
                            mark = "50",
                            Caterogy = Categories["Розчин"],
                            isFavourite = false,
                            price = 1200,
                            img = "/img/Solute Cement/SoluteCement50.png",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Цементний"],
                        },
                        new BuildingMaterial
                        {
                            name = "Розчин цементний",
                            available = true,
                            mark = "75",
                            Caterogy = Categories["Розчин"],
                            isFavourite = false,
                            price = 1300,
                            img = "/img/Solute Cement/SoluteCement75.png",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Цементний"],
                        },
                        new BuildingMaterial
                        {
                            name = "Розчин цементний",
                            available = true,
                            mark = "100",
                            Caterogy = Categories["Розчин"],
                            isFavourite = false,
                            price = 1400,
                            img = "/img/Solute Cement/SoluteCement100.png",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Цементний"],
                        },
                        new BuildingMaterial
                        {
                            name = "Розчин цементний",
                            available = true,
                            mark = "150",
                            Caterogy = Categories["Розчин"],
                            isFavourite = false,
                            price = 1600,
                            img = "/img/Solute Cement/SoluteCement150.png",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Цементний"],
                        },
                        new BuildingMaterial
                        {
                            name = "Бетон",
                            available = true,
                            mark = "100",
                            Caterogy = Categories["Бетон"],
                            isFavourite = false,
                            price = 1400,
                            img = "/img/Concrete/Concrete100.jpg",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Не являється розчином"],
                        },
                        new BuildingMaterial
                        {
                            name = "Бетон",
                            available = true,
                            mark = "150",
                            Caterogy = Categories["Бетон"],
                            isFavourite = false,
                            price = 1500,
                            img = "/img/Concrete/Concrete150.jpg",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Не являється розчином"],
                        },
                        new BuildingMaterial
                        {
                            name = "Бетон",
                            available = true,
                            mark = "200",
                            Caterogy = Categories["Бетон"],
                            isFavourite = false,
                            price = 1550,
                            img = "/img/Concrete/Concrete200.jpg",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Не являється розчином"],
                        },
                        new BuildingMaterial
                        {
                            name = "Бетон",
                            available = true,
                            mark = "250",
                            Caterogy = Categories["Бетон"],
                            isFavourite = false,
                            price = 1600,
                            img = "/img/Concrete/Concrete250.jpg",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Не являється розчином"],
                        },
                        new BuildingMaterial
                        {
                            name = "Бетон",
                            available = true,
                            mark = "300",
                            Caterogy = Categories["Бетон"],
                            isFavourite = false,
                            price = 1750,
                            img = "/img/Concrete/Concrete300.jpg",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Не являється розчином"],
                        },
                        new BuildingMaterial
                        {
                            name = "Бетон",
                            available = true,
                            mark = "350",
                            Caterogy = Categories["Бетон"],
                            isFavourite = false,
                            price = 1800,
                            img = "/img/Concrete/Concrete350.jpg",
                            unit = "м.куб.",
                            CategorySolution = Solutes["Не являється розчином"],
                        }
                        );
                }
                content.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static Dictionary<string, CaterogyGoods> category;
        public static Dictionary<string, CaterogyGoods> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new List<CaterogyGoods>() {
                        new CaterogyGoods() { categoryName = "Бетон", description = "штучний каменеподібний матеріал, результат раціонально" +
                " підібраної суміші в'яжучого, заповнювачів, води і, при потребі, спеціальних добавок."},
                new CaterogyGoods() { categoryName = "Розчин" , description = "матеріал, що отримують внаслідок затвердіння " +
                "суміші в'язкої сполуки (цемент), дрібного заповнювача (пісок), затверджувач (вода) і у необхідних випадках спеціальні добавки."},
                new CaterogyGoods() { categoryName = "Доставка" , description = "Доставка розчину та бетону по місту та за його межами на дистанцію не більше 40 км" +
                "(При більшій відстані ньюанси уточнювати при замовленні)"}
                    };
                    category = new Dictionary<string, CaterogyGoods>();
                    foreach (CaterogyGoods item in list)
                    {
                        category.Add(item.categoryName, item);
                    }
                }
                return category;
            }
        }

        private static Dictionary<string, Solute> categorySolute;
        public static Dictionary<string, Solute> Solutes
        {
            get
            {
                if (categorySolute == null)
                {
                    var list = new List<Solute>() {
                        new Solute() {name = "Вапняний"},
                        new Solute() {name = "Складний"},
                        new Solute() {name = "Цементний"},
                        new Solute() {name = "Не являється розчином"},
                    };
                    categorySolute = new Dictionary<string, Solute>();
                    foreach (Solute item in list)
                    {
                        categorySolute.Add(item.name, item);
                    }
                }
                return categorySolute;
            }
        }
        private static Dictionary<string, Vehicle> categoryVehicle;
        public static Dictionary<string, Vehicle> Vehicles
        {
            get
            {
                if (categoryVehicle == null)
                {
                    var list = new List<Vehicle>() {
                        new Vehicle() {name = "Самосвал", img = "img/Vehicles/Tipper.png"},
                        new Vehicle() {name = "Міксер", img = "img/Vehicles/Mixer.png"},
                    };
                    categoryVehicle = new Dictionary<string, Vehicle>();
                    foreach (Vehicle item in list)
                    {
                        categoryVehicle.Add(item.name, item);
                    }
                }
                return categoryVehicle;
            }
        }
    }
}
