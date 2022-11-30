using TVprogram.Services.Models;
namespace TVprogram.Services.Abstract;

public interface IProgramService
{
    ProgramModel GetProgram(Guid id);

    ProgramModel UpdateProgram(Guid id, UpdateProgramModel program);

    void DeleteProgram(Guid id);

    PageModel<ProgramPreviewModel> GetPrograms(int limit = 20, int offset = 0);
    ProgramModel CreateProgram(CreateProgramModel programModel);
}