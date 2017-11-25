

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace teamssd.Data.Enum
{
    public enum ChanelType
    {
        [Display(Name = "Новини дня")]
        NewsDay = 0,
        [Display(Name = "Політика")]
        Policy = 1,
        [Display(Name = "Економіка")]
        Economy = 2,
        [Display(Name = "Розваги")]
        Entertainment = 3,
        [Display(Name = "Надзвичайні ситуації")]
        Emergency = 4,
        [Display(Name = "Спорт")]
        Sport = 5,
        [Display(Name = "Автомобілі")]
        Cars = 6,
        [Display(Name = "Здоров'я")]
        Health = 7,
        [Display(Name = "Визначні особи")]
        ProminentPersons = 8,
        [Display(Name = "Світ")]
        World = 9,
        [Display(Name = "Господарство")]
        Household = 10,
        [Display(Name = "Погода")]
        Weather = 11

    }
}