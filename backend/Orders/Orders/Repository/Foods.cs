using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Repository
{
    public class Foods
    {
        private List<Model.Foods> FoodList = new List<Model.Foods>();

        public Foods()
        {
            FoodList.Add(new Model.Foods() { Id = 1, Name = "eggs", TimeOfDay = Model.Enums.TimeOfDayEnum.morning });
            FoodList.Add(new Model.Foods() { Id = 2, Name = "toast", TimeOfDay = Model.Enums.TimeOfDayEnum.morning });
            FoodList.Add(new Model.Foods() { Id = 3, Name = "coffee", TimeOfDay = Model.Enums.TimeOfDayEnum.morning });

            FoodList.Add(new Model.Foods() { Id = 1, Name = "steak", TimeOfDay = Model.Enums.TimeOfDayEnum.night });
            FoodList.Add(new Model.Foods() { Id = 2, Name = "potato", TimeOfDay = Model.Enums.TimeOfDayEnum.night });
            FoodList.Add(new Model.Foods() { Id = 3, Name = "wine", TimeOfDay = Model.Enums.TimeOfDayEnum.night });
            FoodList.Add(new Model.Foods() { Id = 4, Name = "cake", TimeOfDay = Model.Enums.TimeOfDayEnum.night });
        }

        public List<Model.Foods> GetFoodsByTimeOfDay(Model.Enums.TimeOfDayEnum timeOfDay)
        {
            return FoodList.Where(food => food.TimeOfDay == timeOfDay).ToList();
        }
    }
}
