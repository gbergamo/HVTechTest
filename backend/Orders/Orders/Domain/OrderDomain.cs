using Orders.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Orders.Domain
{
    public class OrderDomain
    {
        private readonly APIOptions _apiOptions;

        private Enums.TimeOfDayEnum TimeOfDay { get; set; }
        private List<int> FoodList { get; set; }

        private string _originalOrder;

        public OrderDomain(APIOptions apiOptions, string order)
        {
            _apiOptions = apiOptions;
            _originalOrder = order;
        }

        public void ValidateOrderDomain()
        {
            var order = _originalOrder.Split(',');

            if (IsTimeOfDayValid(order[0]))
                TimeOfDay = (Enums.TimeOfDayEnum)Enum.Parse(typeof(Enums.TimeOfDayEnum), order[0], true);
            else
                throw new ValidationException("Invalid Time of Day");

            FoodList = new List<int>();
            for (int i = 1; i < order.Length; i++)
            {
                if (isFoodIdValid(order[i]))
                    FoodList.Add(int.Parse(order[i]));
                else
                    throw new ValidationException("Invalid Food Id");
            }
            FoodList.Sort();
        }

        public string ProcessOrder()
        {
            var foodNameList = ConvertFoodIdToFoodName();
            return ReplaceMultipleFoodName(foodNameList);
        }

        private List<string> ConvertFoodIdToFoodName()
        {
            var foodsRepositoryList = new Repository.Foods().GetFoodsByTimeOfDay(TimeOfDay);

            var foodNameList = new List<string>();
            foreach (var requestedFood in FoodList)
            {
                var foodName = "error";

                var found = (from food in foodsRepositoryList where food.Id == requestedFood select food.Name).FirstOrDefault();
                if (found != null)
                    foodName = found;
                    
                foodNameList.Add(foodName);
            }

            return foodNameList;
        }

        private string ReplaceMultipleFoodName(List<string> foodNameList)
        {
            Dictionary<string, int> dupDictionary = new Dictionary<string, int>();
            foreach (string foodName in foodNameList)
            {
                if (!dupDictionary.ContainsKey(foodName))
                {
                    dupDictionary.Add(foodName, 1);
                }
                else
                {
                    int count = 0;
                    dupDictionary.TryGetValue(foodName, out count);
                    dupDictionary.Remove(foodName);
                    dupDictionary.Add(foodName, count + 1);
                }
            }

            var temporaryFoodNameList = new List<string>();
            foreach (var dictKey in dupDictionary.Keys)
            {
                var dictQuantity = dupDictionary[dictKey];
                if(dictQuantity > 1)
                    temporaryFoodNameList.Add($"{dictKey}(x{dictQuantity})");
                else
                    temporaryFoodNameList.Add($"{dictKey}");
            }

            return String.Join(',', temporaryFoodNameList);
        }

        #region Validation

        private bool IsTimeOfDayValid(string timeOfDay) => _apiOptions.AllowedTimeOfDays.Contains(timeOfDay);

        private bool isFoodIdValid(string foodId)
        {
            int food;

            var isNumber = int.TryParse(foodId, out food);

            return int.TryParse(foodId, out food);
        }

        #endregion
    }
}
