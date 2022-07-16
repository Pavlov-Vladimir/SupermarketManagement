namespace SupermarketManagement.WebApp.PageComponents.Controls;

public partial class SelectProductForSelling
{
    [Parameter]
    public EventCallback<Product> ProductSelected { get; set; }
    public IEnumerable<Product>? Products { get; set; }
    public IEnumerable<Category>? Categories { get; set; }
    private int _categoryId;
    public int CategoryId
    {
        get => _categoryId;
        set
        {
            _categoryId = value;
            if (_categoryId > 0)
            {
                _ = GetProductsList(_categoryId);
            }
        }
    }
    private const int STARTED_CATEGORY_ID = -1;
    [Inject]
    public IViewProductsByCategoryIdUseCase ViewProductsByCategoryId { get; set; } = null!;
    [Inject]
    public IViewCategoriesUseCase ViewCategoriesUseCase { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        CategoryId = STARTED_CATEGORY_ID;
        Categories = await ViewCategoriesUseCase.Execute();
    }

    private async Task GetProductsList(int categoryId)
    {
        Products = await ViewProductsByCategoryId.Execute(categoryId);
    }

    private void SelectProduct_Click(Product product)
    {
        ProductSelected.InvokeAsync(product);
    }
}
