﻿namespace SupermarketManagement.WebApp.Pages;

public partial class Categories
{
    private List<Category>? _categories;

    [Inject]
    public IViewCategoriesUseCase ViewCategoriesUseCase { get; set; } = null!;
    [Inject]
    public IGetCategoryByIdUseCase GetCategoryByIdUseCase { get; set; } = null!;
    [Inject]
    public IDeleteCategoryUseCase DeleteCategoryUseCase { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    public string? ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _categories = (await ViewCategoriesUseCase.Execute())?.ToList();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    private void HandleAddingCategory_Click()
    {
        NavigationManager.NavigateTo("/AddCategory");
    }

    protected async Task HandleDeleting_Click(int categoryId)
    {
        var category = await GetCategoryByIdUseCase.Execute(categoryId);

        await RemoveCategory(categoryId);
    }

    private async Task RemoveCategory(int id)
    {
        await DeleteCategoryUseCase.Execute(id);
        var category = _categories!.First(c => c.Id == id);
        _categories!.Remove(category);
    }
}
