using TVprogram.Services.Models;
namespace TVprogram.Services.Abstract;

public interface IAdminService
{
    AdminModel GetAdmin(Guid id);

    AdminModel UpdateAdmin(Guid id, UpdateAdminModel adminModel);

    void DeleteAdmin(Guid id);

    PageModel<AdminPreviewModel> GetAdmins(int limit = 20, int offset = 0);
}