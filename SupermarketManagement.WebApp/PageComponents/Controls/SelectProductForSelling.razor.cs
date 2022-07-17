using SupermarketManagement.Entities;

namespace SupermarketManagement.WebApp.PageComponents.Controls;

public partial class SelectProductForSelling
{
    [Parameter]
    public EventCallback<Product?> OnSelectProduct { get; set; }
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
    private int selectedProductId;
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
        await OnSelectProduct.InvokeAsync(null);        
    }

    private void SelectProduct_Click(Product product)
    {
        selectedProductId = product.Id;
        OnSelectProduct.InvokeAsync(product);        
    }
}
