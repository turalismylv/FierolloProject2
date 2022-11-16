namespace fiorello_project.ViewModels.Basket
{
    public class BasketIndexViewModel
    {
        public BasketIndexViewModel()
        {
            BasketProducts = new List<BasketProductViewModel>();
        }

        public List<BasketProductViewModel> BasketProducts { get; set; }
    }
}
