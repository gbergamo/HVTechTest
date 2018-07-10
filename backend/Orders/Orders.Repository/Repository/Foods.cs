using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelClass = Orders.Model;

namespace Orders.Repository
{
    public class Foods
    {
        private List<ModelClass.Foods> FoodList = new List<ModelClass.Foods>();

        public Foods()
        {
            FoodList.Add(new ModelClass.Foods() { Id = 1, Name = "eggs", TimeOfDay = ModelClass.Enums.TimeOfDayEnum.morning });
            FoodList.Add(new ModelClass.Foods() { Id = 2, Name = "toast", TimeOfDay = ModelClass.Enums.TimeOfDayEnum.morning });
            FoodList.Add(new ModelClass.Foods() { Id = 3, Name = "coffee", TimeOfDay = ModelClass.Enums.TimeOfDayEnum.morning });

            FoodList.Add(new ModelClass.Foods() { Id = 1, Name = "steak", TimeOfDay = ModelClass.Enums.TimeOfDayEnum.night });
            FoodList.Add(new ModelClass.Foods() { Id = 2, Name = "potato", TimeOfDay = ModelClass.Enums.TimeOfDayEnum.night });
            FoodList.Add(new ModelClass.Foods() { Id = 3, Name = "wine", TimeOfDay = ModelClass.Enums.TimeOfDayEnum.night });
            FoodList.Add(new ModelClass.Foods() { Id = 4, Name = "cake", TimeOfDay = ModelClass.Enums.TimeOfDayEnum.night });
        }

        public List<ModelClass.Foods> GetFoodsByTimeOfDay(ModelClass.Enums.TimeOfDayEnum timeOfDay)
        {
            return FoodList.Where(food => food.TimeOfDay == timeOfDay).ToList();
        }
    }
}
