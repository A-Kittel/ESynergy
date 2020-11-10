using System.ComponentModel.DataAnnotations;

namespace ESynergy.Model
{
    public class ProductResponse
    {
        public int Id { set; get; }
        [Display(Name = "Prece nosaukums")]
        public string Name { set; get; }
        [Display(Name = "Vienību skaits")]
        public int Count { set; get; }
        [Display(Name = "Cena par vienu vienību")]
        public decimal Price { set; get; }
        [Display(Name = "Cena ar PVN")]
        public decimal Pvn { set; get; }
    }
}