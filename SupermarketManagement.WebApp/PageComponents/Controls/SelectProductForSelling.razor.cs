namespace SupermarketManagement.WebApp.PageComponents.Controls;

public partial class SelectProductForSelling : ComponentBase
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
                GetProductsList(_categoryId);
            }
        }
    }
    private const int STARTED_CATEGORY_ID = -1;
    private int selectedProductId;
    [Inject]
    public IViewProductsByCategoryIdUseCase ViewProductsByCategoryId { get; set; } = null!;
    [Inject]
    public IViewCategoriesUseCase ViewCategoriesUseCase { get; set; } = null!;

    protected override void OnInitialized()
    {
        CategoryId = STARTED_CATEGORY_ID;
        Categories = ViewCategoriesUseCase.Execute();
    }

    private void GetProductsList(int categoryId)
    {
        Products = ViewProductsByCategoryId.Execute(categoryId);
        OnSelectProduct.InvokeAsync(null);        
    }

    private void SelectProduct_Click(Product product)
    {
        selectedProductId = product.Id;
        OnSelectProduct.InvokeAsync(product);        
    }
}
